using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace integradorRestaurante
{
    public class imprimirFacturas
    {
        private static Iimprimir per = imprimirListado.GetInstancia(); 
        private int idFactura;

        public int IdFactura
        {
            get { return idFactura; }
            set { idFactura = value; }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private int idPlato;

        public int IdPlato
        {
            get { return idPlato; }
            set { idPlato = value; }
        }
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        private int subTotal;

        public int SubTotal
        {
            get { return subTotal; }
            set { subTotal = value; }
        }

        public static List<object> prepararListadoFactura(int f)
        {
            return per.listadoParaImprimir(f);
        }

            
    }
}