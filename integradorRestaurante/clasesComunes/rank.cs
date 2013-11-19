using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace integradorRestaurante
{
    public class rank
    {
        private static ABSrank per = PERrank.GetInstancia();
        private int idPlato;

        public int IdPlato
        {
            get { return idPlato; }
            set { idPlato = value; }
        }
        private int cantidadVendido;

        public int CantidadVendido
        {
            get { return cantidadVendido; }
            set { cantidadVendido = value; }
        }

        public static void guardar(rank r)
        {
            per.guardar(r);
        }
        public static List<rank> diezMasVendidos()
        {
            return per.diezMasVendidos();
        }
    }
}