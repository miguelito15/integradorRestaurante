using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace integradorRestaurante
{
    public class listaPlatos
    {
        private static ABSlistaPlatos per = PERlistaPlatos.GetInstancia();
        public static List<listaPlatos> lista = new List<listaPlatos>();
        private int idListaPlato;

        public int IdListaPlato
        {
            get { return idListaPlato; }
            set { idListaPlato = value; }
        }
        private int idPedido;

        public int IdPedido
        {
            get { return idPedido; }
            set { idPedido = value; }
        }
        private int idPlato;

        public int IdPlato
        {
            get { return idPlato; }
            set { idPlato = value; }
        }
        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        private int precio;

        public int Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        private int subTotal;

        public int SubTotal
        {
            get { return subTotal; }
            set { subTotal = value; }
        }

        public static void guardar(listaPlatos l)
        {
            per.guardar(l);
        }

        public static List<listaPlatos> listaXped(int ped)
        {
            return per.pedidos(ped);
        }
        public static int suma(int ped)
        {
            return per.suma(ped);
        }
    }
}