using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace integradorRestaurante
{
    public class PERlistaPlatos:ABSlistaPlatos
    {
        private static PERlistaPlatos instancia =null;
        private static OleDbConnection con = null;
        private PERlistaPlatos()
        {

        }

        public static PERlistaPlatos GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new PERlistaPlatos();
                con = restaurante.getInstancia().crearConexion();
            }
            return instancia;
        }
        public override void guardar(listaPlatos l)
        {
            
            OleDbCommand cmdInsert = new OleDbCommand("insert into listaPlatos (idListaPlatos,idPedido, idPlato,cantidad,precio,subTotal) values(@idL,@idP,@idPed,@cat,@precio,@subTotal)", con);
            cmdInsert.Parameters.AddWithValue("@idL", l.IdListaPlato);
            cmdInsert.Parameters.AddWithValue("@idPed", l.IdPedido);
            cmdInsert.Parameters.AddWithValue("@idP", l.IdPlato);
            cmdInsert.Parameters.AddWithValue("@cat", l.Cantidad);
            cmdInsert.Parameters.AddWithValue("@precio", l.Precio);
            cmdInsert.Parameters.AddWithValue("@subTotal", l.SubTotal);


            cmdInsert.ExecuteNonQuery();
        }

        public override List<listaPlatos> pedidos(int ped)
        {
          
            OleDbCommand cmdUpdate = new OleDbCommand("select * from listaPlatos where idPedido=@ped", con);
            cmdUpdate.Parameters.AddWithValue("@ped",ped);
            OleDbDataReader datos = cmdUpdate.ExecuteReader();
            listaPlatos p=null;
            List<listaPlatos> lista = new List<listaPlatos>();
            while(datos.Read())
            {
                p = new listaPlatos();
                
                p.IdListaPlato =Convert.ToInt32(datos["idListaPlatos"]);
                p.IdPedido = Convert.ToInt32(datos["idPedido"]);
                p.IdPlato = Convert.ToInt32(datos["idPlato"]);
                p.Precio = Convert.ToInt32(datos["precio"]);
                p.SubTotal = Convert.ToInt32(datos["subTotal"]);
                lista.Add(p);
            }

            return lista;

        }





        public override int suma(int p)
        {

            OleDbCommand cmdUpdate = new OleDbCommand("SELECT sum(listaPlatos.subTotal) as sumatoria FROM pedidos INNER JOIN listaPlatos ON pedidos.idPedido = listaPlatos.idPedido where idMesa=@ped and pedidos.idFactura=0;", con);
            cmdUpdate.Parameters.AddWithValue("@ped", p);
            OleDbDataReader datos = cmdUpdate.ExecuteReader();
            int suma = 0;

            while (datos.Read())
            {

                suma += Convert.ToInt32(datos["sumatoria"]);

            }

            return suma;
        }
    }
}