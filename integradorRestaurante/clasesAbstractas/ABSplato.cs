using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace integradorRestaurante
{
    public abstract class ABSplato
    {
        public abstract List<platos> buscarXcategoria(int cat);
        public abstract int precioId(int plato);
        public abstract platos buscaXid(int id);
        public abstract void guardar(platos p);
        public abstract List<platos> listadoComun();
       
    }
}