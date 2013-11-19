using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace integradorRestaurante
{
    public class tempApertura
    {
        private static ABStempApertura per = PERtempApertura.GetInstancia();
        private int idMesa;

        public int IdMesa
        {
            get { return idMesa; }
            set { idMesa = value; }
        }
        private int ciMoso;

        public int CiMoso
        {
            get { return ciMoso; }
            set { ciMoso = value; }
        }

        public static int mosoMenosOcupado()
        {
            return per.mosoMenosOcupado();
        }
        public static void guardar(tempApertura t)
        {
             per.guardar(t);
        }
        public static int mosoEnMesa(int mesa)
        {
           return per.mozoEnMesa(mesa);
        }
        public static void borrar(int mesa)
        {
             per.borrarXmesa(mesa);
        }
    }
}