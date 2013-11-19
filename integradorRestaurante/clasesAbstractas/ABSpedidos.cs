using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace integradorRestaurante
{
    public abstract class ABSpedidos
    {
        public abstract void guardar(pedidos p);
        public abstract List<pedidos> buscarXmesa(int m);
        public abstract void actualizarFact(int f, int p);
    }
}