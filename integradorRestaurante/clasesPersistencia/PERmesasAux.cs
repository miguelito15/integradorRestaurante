using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
namespace integradorRestaurante
{
    public class PERmesasAux:ABSmesasAux
    {
        private static PERmesasAux instancia =null;
        private static OleDbConnection con = null;
        private PERmesasAux()
        {

        }

        public static PERmesasAux GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new PERmesasAux();
                con = restaurante.getInstancia().crearConexion();
            }
            return instancia;
        }



        public override void guardar(mesasAux mx)
        {
            
            OleDbCommand cmdInsert = new OleDbCommand("insert into mesasAux (idRes, idMesa) values(@id,@mesa)", con);
            cmdInsert.Parameters.AddWithValue("@id", mx.IdRes);
            cmdInsert.Parameters.AddWithValue("@mesa", mx.IdMesa);
          

            
            cmdInsert.ExecuteNonQuery();
        }

        public override List<mesasAux> lista()
        {
           
            OleDbConnection con = restaurante.getInstancia().crearConexion();
            OleDbCommand cmdselect = new OleDbCommand("select * from mesasAux", con);
            OleDbDataReader datos = cmdselect.ExecuteReader();
            mesasAux p = null;
            List<mesasAux> lista = new List<mesasAux>();
            while (datos.Read())
            {
                p = new mesasAux();
                p.IdMesa = Convert.ToInt32(datos["idMesa"]);
                p.IdRes = Convert.ToInt32(datos["idRes"]);
               
                lista.Add(p);

            }
            return lista;
        }

        public override void borrar(int m)
        {
            OleDbCommand cmd = new OleDbCommand("delete * From mesasAux where idMesa=@mesa", con);
            cmd.Parameters.AddWithValue("@mesa", m);
            cmd.ExecuteNonQuery();
        }

        public override bool estaRes(int m)
        {
            OleDbCommand cmd = new OleDbCommand("select * From mesasAux where idMesa=@mesa", con);
            cmd.Parameters.AddWithValue("@mesa", m);
            int datos= cmd.ExecuteNonQuery();
            if (datos != 0)
                return true;
            else
                return false;
        }
    }
}