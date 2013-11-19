using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace integradorRestaurante
{
    public abstract class ABSrank
    {
        public abstract void guardar(rank r);
        public abstract List<rank> diezMasVendidos();
    }
}