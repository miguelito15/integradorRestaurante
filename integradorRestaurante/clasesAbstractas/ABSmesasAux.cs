using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace integradorRestaurante
{
    public abstract class ABSmesasAux
    {
        public abstract void guardar(mesasAux mx);
        public abstract List<mesasAux> lista();
        public abstract void borrar(int m);
        public abstract bool estaRes(int m);
    }
}