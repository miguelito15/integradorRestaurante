using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace integradorRestaurante
{
    public class factura
    {
        private static ABSfactura per = PERfactura.GetInstancia();
        private int idFactura;

        public int IdFactura
        {
            get { return idFactura; }
            set { idFactura = value; }
        }
        private int idDetalle;

        public int IdDetalle
        {
            get { return idDetalle; }
            set { idDetalle = value; }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private int total;

        public int Total
        {
            get { return total; }
            set { total = value; }
        }

        public static void guardar(factura f)
        {
            per.guardar(f);
        }
    }
}