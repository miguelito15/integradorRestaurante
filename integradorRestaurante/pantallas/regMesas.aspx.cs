using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace integradorRestaurante
{
    public partial class regMesas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = mesas.mesasLibres();
            GridView1.DataBind();
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            txtcap.Visible = true;
            Label2.Visible = true;
            if (txtcap.Text == "")
                Label1.Text = "Ingrese la capacidad de la mesa";
            else
            {
                mesas m = new mesas();
                m.IdMesa = idAuto.asignarId("mesas");
                m.Capacidad = Convert.ToInt32(txtcap.Text);
                m.Estado = "libre";
                mesas.guardar(m);

                idAuto i = new idAuto();
                i.Id = m.IdMesa;
                i.Tabla = "mesas";
            }
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            List<mesas> l = new List<mesas>();
            foreach (mesas m in mesas.listadoComun())
                if (m.Estado == "ocupada")
                    l.Add(m);

            GridView1.DataSource = l;
            GridView1.DataBind();
                
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = mesas.mesasLibres();
            GridView1.DataBind();
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = mesas.mesasReservadas();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = GridView1.SelectedRow.Cells[1].Text;
            txtcap.Text = GridView1.SelectedRow.Cells[2].Text;
            txtcap.Visible = true;
            elim.Visible = true;
            Label2.Visible = true;
        }

        protected void elim_Click(object sender, EventArgs e)
        {
            if (txtcap.Text == "")
                Label1.Text = "Ingrese la capacidad de la mesa";
            else
            {
                mesas.actualizarEstado(Convert.ToInt32(Label1.Text),"noDisponible");

                Server.Transfer("regMesas.aspx");
            }
        }

        protected void txtcap_TextChanged(object sender, EventArgs e)
        {

        }
    }
}