using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace integradorRestaurante
{
    public class idAuto
    {
        private static ABSidAuto per = PERidAuto.GetInstancia();
        private string tabla;

        public string Tabla
        {
            get { return tabla; }
            set { tabla = value; }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public static int asignarId(string tabla)
        {
            return per.asignarId(tabla);
        }
        public static void guardar(idAuto i)
        {
             per.guardar(i);
        }
    }

}