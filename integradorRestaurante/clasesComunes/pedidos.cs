using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace integradorRestaurante
{
    public class pedidos
    {
        private static ABSpedidos per = PERpedidos.GetInstancia();
        private int idPed;

        public int IdPed
        {
            get { return idPed; }
            set { idPed = value; }
        }
        private int idListaPlatos;

        public int IdListaPlatos
        {
            get { return idListaPlatos; }
            set { idListaPlatos = value; }
        }
        private int idMoso;

        public int IdMoso
        {
            get { return idMoso; }
            set { idMoso = value; }
        }
       
        private int mesa;

        public int Mesa
        {
            get { return mesa; }
            set { mesa = value; }
        }

        private int idFactura;

        public int IdFactura
        {
            get { return idFactura; }
            set { idFactura = value; }
        }
        public static void guardar(pedidos p)
        {
            per.guardar(p);
        }
        public static List<pedidos> pedXmesa(int m)
        {
            return per.buscarXmesa(m);
        }
        public static void actualizarIdFact(int f, int p)
        {
            per.actualizarFact(f,p);
        }
    }
}