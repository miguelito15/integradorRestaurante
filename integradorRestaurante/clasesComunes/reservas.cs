using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace integradorRestaurante
{
    public class reservas
    {
        private static ABSreservas per = PERreserva.GetInstancia();
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
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string turno;

        public string Turno
        {
            get { return turno; }
            set { turno = value; }
        }
        public static string guardar(reservas r) {
            return per.guardar(r);
        }

        public static void cambiarEstadoRes(int r, string estado)
        {
            per.cambiarEstado(r,estado);
        }

        public static List<reservas> listarRes()
        {
            return per.listaReservas();
        }
        public static List<reservas> listaXturnoYfecha(string turno, DateTime fecha)
        {
            return per.listaResXturno(turno,fecha);
        }

    }
}