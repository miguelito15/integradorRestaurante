using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace integradorRestaurante
{
    public partial class personal1 : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            if (txtci.Text == "" || txtape.Text == "" || txtci.Text == "" || txtdir.Text == "" || txttel.Text == "")
            {
                mensaje.Text = "Faltan datos para guardar";
            }
            else
            {
                personal p = new personal();

                p.Ci = Convert.ToInt32(txtci.Text);
                p.Nombre = txtnom.Text;
                p.Apellido = txtape.Text;
                p.Tel = Convert.ToInt32(txttel.Text);
                p.Direccion = txtdir.Text;
                p.Rol = ddlcajero.SelectedValue;

                personal.guardar(p);

                Server.Transfer("personal.aspx");
            }
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            if (ddlmodif.Items.Count == 0)
            {
                List<personal> l = personal.listadoComun();

                foreach (personal p in l)
                    if (p.Rol != "inactivo")
                     ddlmodif.Items.Add(new ListItem(p.Nombre + " " + p.Apellido, p.Ci.ToString()));
                ddlmodif.Visible = true;
                Button9.Text = "GUARDAR CAMBIOS";
                
            }
        }

        protected void ddlmodif_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                List<personal> l = personal.listadoComun();
                foreach (personal p in l)
                {
                    if (p.Ci == Convert.ToInt32(ddlmodif.SelectedValue))
                    {
                        txtape.Text = p.Apellido;
                        txtnom.Text = p.Nombre;
                        txtci.Text = p.Ci.ToString();
                        txtdir.Text = p.Direccion;
                        txttel.Text = p.Tel.ToString();
                        ddlcajero.Text = p.Rol;

                    }
                }
            

            if (Button11.Text == "Confirmar baja")
            {
                Button10.Visible = false;
                Button9.Visible = false;


                foreach (personal p in l)
                {
                    if (p.Ci == Convert.ToInt32(ddlmodif.SelectedValue))
                    {
                        txtape.Text = p.Apellido;
                        txtnom.Text = p.Nombre;
                        txtci.Text = p.Ci.ToString();
                        txtdir.Text = p.Direccion;
                        txttel.Text = p.Tel.ToString();
                        ddlcajero.Text = p.Rol;

                    }
                }
                

            }
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            
                if (ddlmodif.Items.Count == 0)
                {
                    
                    List<personal> l = personal.listadoComun();
                    foreach (personal p in l)
                        if (p.Rol != "inactivo")
                            ddlmodif.Items.Add(new ListItem(p.Nombre + " " + p.Apellido, p.Ci.ToString()));
                    ddlmodif.Visible = true;
                    
                }


                if (Button11.Text != "Confirmar baja")
                {

                    Button11.Text = "Confirmar baja";

                }
                else
                {
                    personal p = new personal();
                    p.Ci = Convert.ToInt32(txtci.Text);
                    p.Nombre = txtnom.Text;
                    p.Apellido = txtape.Text;
                    p.Tel = Convert.ToInt32(txttel.Text);
                    p.Direccion = txtdir.Text;
                    p.Rol = "inactivo";
                    personal.guardar(p);
                    Server.Transfer("personal.aspx");
                }
            
        }
    }
}