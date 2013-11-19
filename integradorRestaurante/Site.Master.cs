using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace integradorRestaurante
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour < 12 && DateTime.Now.Hour > 9)
               controlLogeo.turno = "mediodia";
            if (DateTime.Now.Hour == 0 || DateTime.Now.Hour >= 18)
                controlLogeo.turno = "noche";
            else
                controlLogeo.turno = "fuerahora";
            
           
            

            Button1.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            Button4.Visible = false;
            Button5.Visible = false;
            Button6.Visible = false;
            Button7.Visible = false;
            if (controlLogeo.logeado == "mozo")
            {
                Button1.Visible = false;
                Button2.Visible = false;
                Button3.Visible = false;
                Button4.Visible = false;
                Button5.Visible = false;
                Button6.Visible = false;
                Button7.Visible = true;
            }
            if (controlLogeo.logeado == "gerente")
            {
                Button1.Visible = true;
                Button2.Visible = true;
                Button3.Visible = true;
                Button4.Visible = true;
                Button5.Visible = true;
                Button6.Visible = true;
                Button7.Visible = true;
            }
            if (controlLogeo.logeado == "recepcionista")
            {
                Button1.Visible = false;
                Button2.Visible = false;
                Button3.Visible = true;
                Button4.Visible = true;
                Button5.Visible = false;
                Button6.Visible = false;
                Button7.Visible = false;
            }
            if (controlLogeo.logeado == "cajero")
            {
                Button1.Visible = false;
                Button2.Visible = false;
                Button3.Visible = false;
                Button4.Visible = false;
                Button5.Visible = true;
                Button6.Visible = true;
                Button7.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("platos.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Server.Transfer("reservas.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Server.Transfer("aperturaMesa.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Server.Transfer("cierreMesa.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Server.Transfer("pedidos.aspx");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            controlLogeo.logeado = "";
            Server.Transfer("logIn.aspx");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("personal.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Server.Transfer("regMesas.aspx");
        }
    }
}
