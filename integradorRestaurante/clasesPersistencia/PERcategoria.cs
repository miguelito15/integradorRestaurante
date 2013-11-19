using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace integradorRestaurante
{
    public class PERcategoria:ABScategoria
    {
        private static PERcategoria instancia =null;
        private static OleDbConnection con = null;
        private PERcategoria()
        {

        }

        public static PERcategoria GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new PERcategoria();
                con = restaurante.getInstancia().crearConexion();
            }
            return instancia;
        }

        public override List<categorias> listadoCategorias()
        {
            List<categorias> lis = new List<categorias>();
           
            OleDbCommand cmdlistado = new OleDbCommand("select * from categoria", con);
            OleDbDataReader datos = cmdlistado.ExecuteReader();



            while (datos.Read())
            {
                categorias x = new categorias();
                x.IdCategoria = Convert.ToInt32(datos["idCate"]);
                x.Nombre = datos["nombre"].ToString();
                

                lis.Add(x);
            }

            return lis;
        }

        public override void guardar(categorias c)
        {
           
            OleDbCommand cmdInsert = new OleDbCommand("insert into categoria (idCate,nombre) values(@cate,@nombre)", con);
          
            cmdInsert.Parameters.AddWithValue("@cate", c.IdCategoria);
            cmdInsert.Parameters.AddWithValue("@nombre", c.Nombre);
           
            cmdInsert.ExecuteNonQuery();
        }
    }
}