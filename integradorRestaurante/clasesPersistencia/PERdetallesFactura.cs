using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace integradorRestaurante
{
    public class PERdetallesFactura:ABSdetallesFactura
    {
         private static PERdetallesFactura instancia =null;
        private static OleDbConnection con = null;
        private PERdetallesFactura()
        {

        }

        public static PERdetallesFactura GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new PERdetallesFactura();
                con = restaurante.getInstancia().crearConexion();
            }
            return instancia;
        }
        public override void guardar(detallesFactura d)
        {
           
                    OleDbCommand cmdInsert = new OleDbCommand("insert into detallesFactura (idDetalle,idFactura,idPlato,descripcion,precio) values(@det,@idf,@plato,@des,@pre)", con);
                    cmdInsert.Parameters.AddWithValue("@det", d.IdDetalle);
                    cmdInsert.Parameters.AddWithValue("@idf", d.IdFactura);
                    cmdInsert.Parameters.AddWithValue("@plato", d.IdPlato);
                    cmdInsert.Parameters.AddWithValue("@des", d.Desc);
                    cmdInsert.Parameters.AddWithValue("@pre", d.Precio);
                    cmdInsert.ExecuteNonQuery();

        }

        public override List<detallesFactura> listado(int fac)
        {
            List<detallesFactura> listado = new List<detallesFactura>();
            OleDbCommand cmdlistado = new OleDbCommand("select * from detallesFactura where idFactura=@idf", con);
            cmdlistado.Parameters.AddWithValue("@idf",fac);
            OleDbDataReader datos = cmdlistado.ExecuteReader();
            detallesFactura f = null;
            while (datos.Read())
            {
                f = new detallesFactura();
                f.Desc = datos["descripcion"].ToString();
                f.IdDetalle = Convert.ToInt32(datos["idDetalle"]);
                f.IdFactura = Convert.ToInt32(datos["idFactura"]);
                f.IdPlato = Convert.ToInt32(datos["idPlato"]);
                f.Precio = Convert.ToInt32(datos["precio"]);
                listado.Add(f);
            }
            return listado;
            

        }

        public List<string> union(DateTime desde, DateTime hasta)
        {

            OleDbCommand cmdlistado = new OleDbCommand("select * from listadoXtotales where fecha between @desde and @hasta order by idPlato", con);
            cmdlistado.Parameters.AddWithValue("@desde",desde.Date);
            cmdlistado.Parameters.AddWithValue("@hasta", hasta.Date);
            OleDbDataReader datos = cmdlistado.ExecuteReader();
            List<string> li = new List<string>();
            bool hayDatos = datos.Read();
            int costo;
            int precio;
            int platoActual;
            string descripcion;
            while(hayDatos)
            {
                platoActual=Convert.ToInt32(datos["idPlato"]);
                descripcion = datos["descripcion"].ToString();
                costo = 0;
                precio = 0;
                while (hayDatos && platoActual == Convert.ToInt32(datos["idPlato"]))
                {
                    precio += Convert.ToInt32(datos["subTotal"]);
                    costo += Convert.ToInt32(datos["costoTotal"]);
                    hayDatos = datos.Read();
                }

                li.Add("" + descripcion + " (TOTAL PRECIO:) " + precio+ "  (TOTAL COSTO:) "+ costo);
            }

            return li;

        }

        public List<string> unionXmozo(DateTime desde, DateTime hasta)
        {

            OleDbCommand cmdlistado = new OleDbCommand("select * from listadoXtotales where fecha between @desde and @hasta order by ciMozo", con);
            cmdlistado.Parameters.AddWithValue("@desde", desde.Date);
            cmdlistado.Parameters.AddWithValue("@hasta", hasta.Date);
            OleDbDataReader datos = cmdlistado.ExecuteReader();
            List<string> li = new List<string>();
            bool hayDatos = datos.Read();
            int costo;
            int precio;
            int mozoActual;
            string nombre;
            string apellido;
            while (hayDatos)
            {
                mozoActual = Convert.ToInt32(datos["ciMozo"]);
                nombre = datos["nombre"].ToString();
                apellido = datos["nombre"].ToString();
                costo = 0;
                precio = 0;
                while (hayDatos && mozoActual == Convert.ToInt32(datos["ciMozo"]))
                {
                    precio += Convert.ToInt32(datos["subTotal"]);
                    costo += Convert.ToInt32(datos["costoTotal"]);
                    hayDatos = datos.Read();
                }

                li.Add(mozoActual+" || " + nombre +" || "+apellido+" || VENDIO TOTAL PRECIO: || " + precio + " ||  TOTAL COSTO: || " + costo);
            }

            return li;

        }
        
    }
}