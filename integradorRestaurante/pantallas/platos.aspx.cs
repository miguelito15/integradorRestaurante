using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace integradorRestaurante
{
    public partial class platos1 : System.Web.UI.Page
    {
        private static List<platos> lista = new List<platos>();
        private static int bandera = 0;
        private static int control = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (platos pla in platos.listadoComun())
                    desc.Items.Add(new ListItem(pla.Desc,pla.IdPlato.ToString()));
                foreach (categorias c in categorias.lista())
                    categoria.Items.Add(new ListItem(c.Nombre + "", c.IdCategoria.ToString()));
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {


            Button11.Visible = true;
            verRank.Visible = true;
            platos pla = null;
            List<rank> listado = rank.diezMasVendidos();
            foreach (rank ra in listado)
            {
                pla = platos.buscaXid(ra.IdPlato);
                if (pla != null)
                {
                    lista.Add(pla);
                }
            }

            verRank.DataSource = lista;
            verRank.DataBind();
            lista.Clear();

            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtdesc.Text != "" || txtprecio.Text != "" || txtcosto.Text != "")
            {
                if (desc.Visible == true)
                {
                    
                    platos p = new platos(Convert.ToInt32(desc.SelectedValue));
                    p.Costo = Convert.ToInt32(txtcosto.Text);
                    p.Precio = Convert.ToInt32(txtprecio.Text);
                    p.IdCategoria = Convert.ToInt32(categoria.SelectedValue);
                    p.Desc = txtdesc.Text;
                    p.Estado = "activo";
                    platos.guardar(p);

                    Server.Transfer("platos.aspx");
                }
                else
                {

                    platos p = new platos();
                    p.Desc = txtdesc.Text;
                    p.IdPlato = idAuto.asignarId("platos");
                    p.IdCategoria = Convert.ToInt32(categoria.SelectedValue);
                    p.Costo = Convert.ToInt32(txtcosto.Text);
                    p.Precio = Convert.ToInt32(txtprecio.Text);
                    p.Estado = "activo";
                    platos.guardar(p);

                    //guarda plato en ranking
                    rank r = new rank();
                    r.CantidadVendido = 0;
                    r.IdPlato = p.IdPlato;
                    rank.guardar(r);

                    //actualiza tabla autonumerico
                    idAuto id = new idAuto();
                    id.Id = Convert.ToInt32(p.IdPlato);
                    id.Tabla = "platos";
                    idAuto.guardar(id);

                    Server.Transfer("platos.aspx");
                }
            }
            else
                mensaje.Text = "No se ingresaron todos los datos para guardar";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            desc.Visible = true;
               
            
        }

        protected void desc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bandera != 1)
            {
                platos p = platos.buscaXid(Convert.ToInt32(desc.SelectedValue));
                txtdesc.Text = p.Desc;
                txtcosto.Text = p.Costo.ToString();
                txtprecio.Text = p.Precio.ToString();
                categoria.Text = p.IdCategoria.ToString();
                estado.Text = p.Estado;
                mensaje.Text ="El plato con id "+ p.IdPlato + "  esta " + p.Estado;
                Button1.Text = "GUARDAR CAMBIOS";
                Button3.Visible = false;
            }
            else
            {
                platos p = platos.buscaXid(Convert.ToInt32(desc.SelectedValue));
                txtdesc.Text = p.Desc;
                txtcosto.Text = p.Costo.ToString();
                txtprecio.Text = p.Precio.ToString();
                categoria.Text = p.IdCategoria.ToString();
                estado.Text = p.Estado;
                mensaje.Text = "El plato con id " + p.IdPlato + "  esta " + p.Estado;
                Button4.Text = "CONFIRMAR BAJA";
                Button3.Visible = false;
                Button2.Visible = false;
                Button1.Visible = false;
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            cat.Visible = true;

        }

        protected void cat_TextChanged(object sender, EventArgs e)
        {
            if (cat.Text != "")
            {
                categorias c = new categorias();
                c.IdCategoria = idAuto.asignarId("categorias");
                c.Nombre = cat.Text;
                categorias.guardar(c);
                idAuto id = new idAuto();
                id.Id = Convert.ToInt32(c.IdCategoria);
                id.Tabla = "categorias";
                idAuto.guardar(id);
            }
            else
                mensaje.Text = "Ingrese un nombre de categoria para guardar";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (bandera == 1)
            {
                platos p = new platos(Convert.ToInt32(desc.SelectedValue));
                p.Costo = Convert.ToInt32(txtcosto.Text);
                p.Precio = Convert.ToInt32(txtprecio.Text);
                p.IdCategoria = Convert.ToInt32(categoria.SelectedValue);
                p.Desc = txtdesc.Text;
                p.Estado = estado.SelectedValue;
                platos.guardar(p);
                Server.Transfer("platos.aspx");
            }
            else
            {
                bandera = 1;
                desc.Visible = true;
            }

        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Button11.Visible = true;
            control = 1;
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            if (txtdesde.Text != "" && txthasta.Text != "")
            {
                if (ddver.SelectedValue == "platos")
                {
                    verRank.Visible = true;
                    List<string> prueba = PERdetallesFactura.GetInstancia().union(Convert.ToDateTime(txtdesde.Text), Convert.ToDateTime(txthasta.Text));
                    verRank.DataSource = prueba;
                    verRank.DataBind();
                }
                if (ddver.SelectedValue == "mozos")
                {
                    verRank.Visible = true;
                    List<string> prueba = PERdetallesFactura.GetInstancia().unionXmozo(Convert.ToDateTime(txtdesde.Text), Convert.ToDateTime(txthasta.Text));
                    verRank.DataSource = prueba;
                    verRank.DataBind();
                }
            }
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            if (control == 1 && ddver.SelectedValue=="mozos")
            {
                controlLogeo.pagOrigen="platosEstadisticas";
                controlLogeo.parametroDesde = Convert.ToDateTime(txtdesde.Text);
                controlLogeo.parametroHasta = Convert.ToDateTime(txthasta.Text);
            }
            if (control == 1 && ddver.SelectedValue == "platos")
            {
                controlLogeo.pagOrigen = "platosEstadisticas1";
                controlLogeo.parametroDesde = Convert.ToDateTime(txtdesde.Text);
                controlLogeo.parametroHasta = Convert.ToDateTime(txthasta.Text);
            }
            else
                controlLogeo.pagOrigen = "platos";
            Server.Transfer("impFact.aspx");
        }
    }
}