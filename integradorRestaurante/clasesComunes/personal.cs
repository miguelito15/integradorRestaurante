using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace integradorRestaurante
{
    public class personal
    {
        private static ABSpersonal per = PERpersistencia.GetInstancia();
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string apellido;

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        private int ci;

        public int Ci
        {
            get { return ci; }
            set { ci = value; }
        }
        private int tel;

        public int Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        private string rol;

        public string Rol
        {
            get { return rol; }
            set { rol = value; }
        }

        public static string verificar(int ci)
        {
            return per.verificar(ci);
        }
        public static string verificarNombre(int ci)
        {
            return per.verificarNombre(ci);
        }
        public static List<int> listarCi()
        {
            return per.listadoCi();
        }
        public static void guardar(personal p)
        {
            per.guardar(p);
        }
        public static List<personal> listadoComun()
        {
            return per.listadoComun();
        }

        public static Boolean verif(personal p)
        {
            if (p.Apellido != null && p.Direccion != null && p.Nombre != null && p.Rol != null && p.Tel != null && p.Ci != null)
                return true;
            else
                return false;
        }
    }
}