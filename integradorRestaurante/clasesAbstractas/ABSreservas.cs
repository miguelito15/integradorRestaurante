using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace integradorRestaurante
{
    public abstract  class ABSreservas
    {
        public abstract string guardar(reservas res);
        public abstract void cambiarEstado(int r, string estado);
        public abstract List<reservas> listaResXturno(string turnoAct, DateTime fecha);
        public abstract List<reservas> listaReservas();
        
    }
}