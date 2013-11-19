using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;


namespace integradorRestaurante
{
    public class imprimirListado:Iimprimir
    {
        private static imprimirListado instancia =null;
        private static OleDbConnection con = null;
        private imprimirListado()
        {

        }

        public static imprimirListado GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new imprimirListado();
                con = restaurante.getInstancia().crearConexion();
            }
            return instancia;
        }
        public List<object> listadoParaImprimir(int f)
        {
           
            List<object> listado = new List<object>();
            OleDbCommand cmdlistado = new OleDbCommand("SELECT factura.idFactura, factura.fecha, detallesFactura.idPlato, detallesFactura.descripcion, listaPlatos.cantidad, listaPlatos.subTotal FROM factura INNER JOIN (listaPlatos INNER JOIN detallesFactura ON listaPlatos.idPlato = detallesFactura.idPlato) ON factura.idFactura = detallesFactura.idFactura where detallesFactura.idFactura=@idf", con);
            cmdlistado.Parameters.AddWithValue("@idf",f);
            OleDbDataReader datos = cmdlistado.ExecuteReader();
            imprimirFacturas im = null;
            while (datos.Read())
            {
                im=new imprimirFacturas();
                im.IdFactura = Convert.ToInt32(datos["idFactura"]);
                im.IdPlato = Convert.ToInt32(datos["idPlato"]);
                im.Descripcion = datos["descripcion"].ToString();
                im.Cantidad = Convert.ToInt32(datos["cantidad"]);
                im.SubTotal = Convert.ToInt32(datos["subTotal"]);
                im.Fecha = Convert.ToDateTime(datos["fecha"]).Date; ;
                listado.Add(im);
            }


            return listado;
        }


        
    }
}