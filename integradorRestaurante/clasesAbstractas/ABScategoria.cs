using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace integradorRestaurante
{
    public abstract class ABScategoria
    {
        public abstract List<categorias> listadoCategorias();
        public abstract void guardar(categorias c);
    }
}