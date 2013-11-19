using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace integradorRestaurante
{
    public class platos
    {
        public platos(int idp)
        {
            IdPlato = idp;
        }
        public platos() {
        
        }
        private static ABSplato per = PERplato.GetInstancia();
        private static Iimprimir per2 = PERplato.GetInstancia();
        private int idPlato;

        public int IdPlato
        {
            get { return idPlato; }
            set { idPlato = value; }
        }
        private int idCategoria;

        public int IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }
        private string desc;

        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }
        private int costo;

        public int Costo
        {
            get { return costo; }
            set { costo = value; }
        }
        private int precio;

        public int Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public static List<platos> listadoXcate(int cat)
        {
            return per.buscarXcategoria(cat);
        }
        public static int precioPlato(int p)
        {
            return per.precioId(p);
        }
        public static platos buscaXid(int p)
        {
            return per.buscaXid(p);
        }
        public static void guardar(platos p)
        {
             per.guardar(p);
        }
        public static List<platos> listadoComun()
        {
            return per.listadoComun();
        }
        public static List<object> listadoParaImp(int f)
        {
            return per2.listadoParaImprimir(f);
        }
        
    }
}