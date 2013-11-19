using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace integradorRestaurante
{
    public class PERrank:ABSrank
    {
        private static PERrank instancia =null;
        private static OleDbConnection con = null;
        private PERrank()
        {

        }

        public static PERrank GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new PERrank();
                con = restaurante.getInstancia().crearConexion();
            }
            return instancia;
        }
        public override void guardar(rank r)
        {
            
            int acumulador = 0;
            OleDbConnection con = restaurante.getInstancia().crearConexion();
            OleDbCommand cmdselect = new OleDbCommand("select cantidadVendido from ranking where idPlato = @plat",con);
            
            cmdselect.Parameters.AddWithValue("@plato", r.IdPlato);
            OleDbDataReader datos= cmdselect.ExecuteReader();
            if (datos.Read())
            {
                acumulador = Convert.ToInt32(datos["cantidadVendido"]);
                acumulador += r.CantidadVendido;
                OleDbCommand cmd = new OleDbCommand("UPDATE ranking  SET cantidadVendido=@cant WHERE idPlato=@plato", con);
                cmd.Parameters.AddWithValue("@cant", acumulador);
                cmd.Parameters.AddWithValue("@plato", r.IdPlato);
                cmd.ExecuteNonQuery();
            }
            else
            {
                
                {
                    OleDbCommand cmdUpdate = new OleDbCommand("insert into ranking (idPlato,cantidadVendido) values(@pla,@cant)", con);
                    cmdUpdate.Parameters.AddWithValue("@pla", r.IdPlato);
                    cmdUpdate.Parameters.AddWithValue("@cant", r.CantidadVendido);

                    cmdUpdate.ExecuteNonQuery();
                }
            }
        }

        public override List<rank> diezMasVendidos()
        {
            int cont = 0;
            OleDbConnection con = restaurante.getInstancia().crearConexion();
            OleDbCommand cmdselect = new OleDbCommand("select * from ranking order by cantidadVendido desc", con);
            OleDbDataReader datos= cmdselect.ExecuteReader();
            rank p = null;
            List<rank> lista = new List<rank>();
            while (datos.Read() && cont <= 10)
            {
                p = new rank();
                p.IdPlato = Convert.ToInt32(datos["idPlato"]);
                p.CantidadVendido = Convert.ToInt32(datos["cantidadVendido"]);
                cont++;
                lista.Add(p);

            }
            return lista;

        }
    }
}