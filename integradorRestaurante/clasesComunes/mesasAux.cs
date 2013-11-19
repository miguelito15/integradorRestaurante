using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace integradorRestaurante
{
    public class mesasAux
    {
        private static ABSmesasAux per = PERmesasAux.GetInstancia();
        private int idRes;

        public int IdRes
        {
            get { return idRes; }
            set { idRes = value; }
        }
        private int idMesa;

        public int IdMesa
        {
            get { return idMesa; }
            set { idMesa = value; }
        }

        public static List<int> lista = new List<int>();

        public static void guardar(mesasAux mx)
        {
            per.guardar(mx);
        }
        public static List<mesasAux> listado()
        {
            return per.lista();
        }
        public static void borrar(int m)
        {
             per.borrar(m);
        }
        public static bool estaRes(int m)
        {
           return per.estaRes(m);
        }
    }
}