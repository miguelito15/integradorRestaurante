using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace integradorRestaurante
{
    public abstract class ABStempApertura
    {
        public abstract int mosoMenosOcupado();
        public abstract void guardar(tempApertura t);
        public abstract int mozoEnMesa(int mesa);
        public abstract void borrarXmesa(int mesa);
    }
}