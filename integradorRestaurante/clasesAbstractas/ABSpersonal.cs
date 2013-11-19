using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace integradorRestaurante
{
    public abstract class ABSpersonal
    {
        public abstract string verificar(int ci);
        public abstract string verificarNombre(int ci);
        public abstract List<int> listadoCi();
        public abstract List<personal> listadoComun();
        public abstract void guardar(personal p);
    }
}