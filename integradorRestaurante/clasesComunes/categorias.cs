using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace integradorRestaurante
{
    public class categorias
    {
        private static ABScategoria per =  PERcategoria.GetInstancia();
        private int idCategoria;

        public int IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public static List<categorias> lista()
        {
            return per.listadoCategorias();
        }
        public static void guardar(categorias c)
        {
            per.guardar(c);
        }
    }
}