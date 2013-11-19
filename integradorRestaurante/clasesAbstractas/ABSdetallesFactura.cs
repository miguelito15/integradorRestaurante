using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace integradorRestaurante
{
    public abstract class ABSdetallesFactura
    {
        public abstract void guardar(detallesFactura d);
        public abstract List<detallesFactura> listado(int fac);
    }
}