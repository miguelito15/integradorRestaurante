using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace integradorRestaurante
{

    public class PERplato:ABSplato,Iimprimir
    {
        
        private static PERplato instancia =null;
        private static OleDbConnection con = null;
        private PERplato()
        {

        }

        public static PERplato GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new PERplato();
                con = restaurante.getInstancia().crearConexion();
            }
            return instancia;
        }
        public override List<platos> buscarXcategoria(int cat)
        {
            
            
            OleDbCommand cmdlistado = new OleDbCommand("select * from platos where idCategoria=@cate", con);
            cmdlistado.Parameters.AddWithValue("@cate",cat);
            OleDbDataReader datos = cmdlistado.ExecuteReader();

            List<platos> listado = new List<platos>();
               
            while (datos.Read())
            {
                platos x = new platos();
             
                x.Costo = Convert.ToInt32(datos["costo"]);
                x.Desc = datos["descripcion"].ToString();
                x.IdCategoria=Convert.ToInt32(datos["idCategoria"]);
                x.IdPlato=Convert.ToInt32(datos["idPlato"]);
                x.Precio=Convert.ToInt32(datos["precio"]);
                x.Estado = datos["estado"].ToString();
                listado.Add(x);

               
            }

            return listado;
        }


        public override int precioId(int plato)
        {
            
            OleDbCommand cmdlistado = new OleDbCommand("select precio from platos where idPlato=@plato", con);
            cmdlistado.Parameters.AddWithValue("@plato", plato);
            OleDbDataReader datos = cmdlistado.ExecuteReader();

            int precio=0;
            if(datos.Read())
                precio=Convert.ToInt32(datos["precio"]);
            return precio;
        }

        public override platos buscaXid(int id)
        {
            
            OleDbCommand cmdlistado = new OleDbCommand("select * from platos where idPlato=@plato", con);
            cmdlistado.Parameters.AddWithValue("@plato", id);
            OleDbDataReader datos = cmdlistado.ExecuteReader();

            platos p = null;
            if (datos.Read())
            {
                p = new platos();
                p.IdPlato = Convert.ToInt32(datos["idPlato"]);
                p.IdCategoria = Convert.ToInt32(datos["idCategoria"]);
                p.Desc = datos["descripcion"].ToString();
                p.Precio = Convert.ToInt32(datos["precio"]);
                p.Costo = Convert.ToInt32(datos["costo"]);
                p.Estado = datos["estado"].ToString();
            }
            return p;
        }

        public override void guardar(platos p)
        {
           
            OleDbCommand cmd = new OleDbCommand("UPDATE platos  SET idCategoria=@cate, descripcion=@desc, costo=@cost, precio=@precio, estado=@est WHERE idPlato=@plato", con);
            cmd.Parameters.AddWithValue("@cate", p.IdCategoria);
            cmd.Parameters.AddWithValue("@desc", p.Desc);
            cmd.Parameters.AddWithValue("@cost", p.Costo);
            cmd.Parameters.AddWithValue("@precio", p.Precio);
            cmd.Parameters.AddWithValue("@est", p.Estado);
            cmd.Parameters.AddWithValue("@plato", p.IdPlato);
            int dato= cmd.ExecuteNonQuery();
            if (dato == 0)
            {
                OleDbCommand cmdInsert = new OleDbCommand("insert into platos (idPlato,idCategoria,descripcion,costo, precio,estado) values(@plato,@cate,@desc,@cost,@precio,@est)", con);
                cmdInsert.Parameters.AddWithValue("@plato", p.IdPlato);
                cmdInsert.Parameters.AddWithValue("@cate", p.IdCategoria);
                cmdInsert.Parameters.AddWithValue("@desc", p.Desc);
                cmdInsert.Parameters.AddWithValue("@cost", p.Costo);
                cmdInsert.Parameters.AddWithValue("@precio", p.Precio);
                cmdInsert.Parameters.AddWithValue("@est", p.Estado);
                cmdInsert.ExecuteNonQuery();
                
            }
        }

       
        public override List<platos> listadoComun()
        {
           
            OleDbCommand cmdlistado = new OleDbCommand("select * from platos", con);
            
            OleDbDataReader datos = cmdlistado.ExecuteReader();

            List<platos> listado = new List<platos>();

            while (datos.Read())
            {
                platos x = new platos();

                x.Costo = Convert.ToInt32(datos["costo"]);
                x.Desc = datos["descripcion"].ToString();
                x.IdCategoria = Convert.ToInt32(datos["idCategoria"]);
                x.IdPlato = Convert.ToInt32(datos["idPlato"]);
                x.Precio = Convert.ToInt32(datos["precio"]);
                x.Estado = datos["estado"].ToString();
                listado.Add(x);


            }

            return listado;
        }

        public int costoP(int idp)
        {
            OleDbCommand cmdlistado = new OleDbCommand("select costo from platos where idPlato=@plato", con);
            cmdlistado.Parameters.AddWithValue("@plato", idp);
            OleDbDataReader datos = cmdlistado.ExecuteReader();

            int costoPlato = 0;
            if (datos.Read())
                costoPlato = Convert.ToInt32(datos["costo"]);
            return costoPlato;
        }



        public List<object> listadoParaImprimir(int f)
        {
            List<object> lista = new List<object>();
            foreach (rank r in rank.diezMasVendidos())
            {
                platos p = buscaXid(r.IdPlato);
                if (p != null)
                {
                    lista.Add(p);
                }
                
            }
            return lista;
        }
    }
}