using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace integradorRestaurante
{
    public class mesas 
    {
        private static ABSmesas per = PERmesas.GetInstancia();
        private int idMesa;

        public int IdMesa
        {
            get { return idMesa; }
            set { idMesa = value; }
        }
        private int capacidad;

        public int Capacidad
        {
            get { return capacidad; }
            set { capacidad = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public static List<mesas> listadoComun() {
            return per.listadoComun();
        }
        public static List<mesas> mesasLibres(int x, DateTime fecha, string turno)
        {
            return per.mesasLibres(x,fecha,turno);
        }
        public static List<mesas> mesasLibres()
        {
            return per.mesasLibres();
        }
        public static List<mesas> mesasReservadas()
        {
            return per.mesasReservadas();
        }
        public static void actualizarEstado(int mesa, string estado)
        {
           per.actualizarEstado(mesa,estado);
        }
        public static void guardar(mesas m)
        {
            per.guardar(m);
        }
        

       
        
    }
}