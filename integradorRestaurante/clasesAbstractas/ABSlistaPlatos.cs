using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace integradorRestaurante
{
    public abstract class ABSlistaPlatos
    {
        public abstract void guardar(listaPlatos l);
        public abstract List<listaPlatos> pedidos(int ped);
        public abstract int suma(int p);
        
    }
}