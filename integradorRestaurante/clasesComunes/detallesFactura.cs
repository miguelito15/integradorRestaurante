using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace integradorRestaurante
{
    public class detallesFactura
    {
        private static ABSdetallesFactura per = PERdetallesFactura.GetInstancia();
        private int idDetalle;

        public int IdDetalle
        {
            get { return idDetalle; }
            set { idDetalle = value; }
        }
        private int idFactura;

        public int IdFactura
        {
            get { return idFactura; }
            set { idFactura = value; }
        }
        private int idPlato;

        public int IdPlato
        {
            get { return idPlato; }
            set { idPlato = value; }
        }
        private string desc;

        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }
        private int precio;

        public int Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public static void guardar(detallesFactura d)
        {
            per.guardar(d);
        }
        public static List<detallesFactura> listado(int f)
        {
            return per.listado(f);
        }
    }
}