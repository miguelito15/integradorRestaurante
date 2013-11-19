using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace integradorRestaurante
{
    public abstract class ABSmesas
    {
        public abstract List<mesas> listadoComun();
        public abstract List<mesas> mesasLibres(int x,DateTime fecha,string turno);
        public abstract List<mesas> mesasLibres();
        public abstract List<mesas> mesasReservadas();
        public abstract void actualizarEstado(int mesa, string estado);
        public abstract void guardar(mesas m);
    }
}