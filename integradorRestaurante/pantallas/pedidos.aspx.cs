using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace integradorRestaurante
{
    public partial class pedidos1 : System.Web.UI.Page
    {
        private static int ultimo;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                cant.Text = "1";
                foreach (categorias c in categorias.lista())
                    cmbcategoria.Items.Add(new ListItem(c.Nombre + "", c.IdCategoria.ToString()));
                foreach (mesas m in mesas.listadoComun())
                    if (m.Estado == "ocupada")
                        ddmesas.Items.Add(m.IdMesa.ToString());
               
                            

            }
        }





        protected void Button1_Click(object sender, EventArgs e)
        {

            if (cant.Text == "0" || platosXca.SelectedItem == null || ddmesas.Items.Count == 0 || ddmesas.SelectedValue == "Mesas Ocu.")
                mesanje.Text = "No se selecciono una cantidad para el plato o no selecciono un plato o bien no hay mesas ocupadas";
            else
            {
                //agrego el plato seleccionado a la lista de platos a pedir
                cmbPlatos.Items.Add(new ListItem(cant.Text + " " + platosXca.SelectedItem, platosXca.SelectedValue.ToString()));
                mesanje.Text = "";

                //a la misma vez se guarda temporalmente en un lista de listaplatos para cada plato seleccionado
                int precio = platos.precioPlato(Convert.ToInt32(platosXca.SelectedValue));

                listaPlatos l = new listaPlatos();
                l.Cantidad = Convert.ToInt32(cant.Text);
                l.IdListaPlato = 0;
                l.IdPedido = 0;
                l.IdPlato = Convert.ToInt32(platosXca.SelectedValue);
                l.Precio = precio;
                l.SubTotal = precio * Convert.ToInt32(cant.Text);
                listaPlatos.lista.Add(l);

                cant.Text = "1";
                    
                
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (cmbPlatos.SelectedItem == null)
            {
                mesanje.Text = "No selecciono un plato para borrar";

            }
            else
            {

                foreach (listaPlatos p in listaPlatos.lista)
                {
                    if (p.IdPlato == Convert.ToInt32(cmbPlatos.SelectedValue))
                        listaPlatos.lista.Remove(p);
                }
                mesanje.Text = "";
                //cmbPlatos.Items.Remove(cmbPlatos.SelectedItem);
            }
        }

        protected void cmbcategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            platosXca.Items.Clear();
            List<platos> pla = platos.listadoXcate(Convert.ToInt32(cmbcategoria.SelectedValue));
            foreach (platos p in pla)
                if(p.Estado!="inactivo")
                    platosXca.Items.Add(new ListItem(p.Desc + " $" + p.Precio, p.IdPlato.ToString()));


        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (cant.Text != "0")
                cant.Text = (Convert.ToInt32(cant.Text) - 1).ToString();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            cant.Text = (Convert.ToInt32(cant.Text) + 1).ToString();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            int idP = idAuto.asignarId("pedidos");
            int idL = idAuto.asignarId("listaPlatos");
            //primero se guardan los pedidos para respetar las relaciones en la base de datos
            pedidos ped = new pedidos();
            
            ped.IdListaPlatos = idL;
            ped.IdPed = idP;
            ped.Mesa = Convert.ToInt32(ddmesas.SelectedValue);
            ped.IdMoso = tempApertura.mosoEnMesa(Convert.ToInt32(ddmesas.SelectedValue));
            ped.IdFactura = 0;
            pedidos.guardar(ped);

            //se recorre la lista en donde estan los platos pedidos y se guardan en la tabla listaPlatos
            listaPlatos l = new listaPlatos();
            foreach (listaPlatos p in listaPlatos.lista)
            {
                l.Cantidad = p.Cantidad;
                l.IdListaPlato =idL;
                l.IdPedido = idP;
                l.IdPlato = p.IdPlato;
                l.Precio = p.Precio;
                l.SubTotal = p.SubTotal;
                listaPlatos.guardar(l);
                //guarda en tabla ranking de platos
                rank r = new rank();
                r.CantidadVendido =l.Cantidad;
                r.IdPlato = p.IdPlato;
                rank.guardar(r);

                
            }
            mesanje.Text = "Pedidos realizados con exito";
            //actualiza el ultimo id dado para cada tabla

            idAuto ia = new idAuto();
            ia.Id = idL;
            ia.Tabla = "listaPlatos";
            idAuto.guardar(ia);

            idAuto id = new idAuto();
            id.Id = idP;
            id.Tabla = "pedidos";
            idAuto.guardar(id);
            listaPlatos.lista.Clear();

            cmbPlatos.Items.Clear();

            
        }

        protected void ddmesas_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbPlatos.Items.Clear();
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            mesanje.Text = controlLogeo.turno;
        }
    }
}