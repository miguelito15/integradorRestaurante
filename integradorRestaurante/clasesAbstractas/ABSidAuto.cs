using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace integradorRestaurante
{
    public abstract class ABSidAuto
    {
        public abstract int asignarId(string tabla);
        public abstract void guardar(idAuto i);
    }
}