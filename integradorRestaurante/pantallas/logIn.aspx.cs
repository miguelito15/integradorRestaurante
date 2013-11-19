using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace integradorRestaurante
{
    public partial class logIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtCi.Text != "")
            {
                if (personal.verificar(Convert.ToInt32(txtCi.Text)) == "mozo")
                {
                    controlLogeo.logeado = "mozo";
                    Server.Transfer("pedidos.aspx");
                }

                if (personal.verificar(Convert.ToInt32(txtCi.Text)) == "recepcionista")
                {
                    controlLogeo.logeado = "recepcionista";
                    Server.Transfer("reservas.aspx");
                }

                if (personal.verificar(Convert.ToInt32(txtCi.Text)) == "gerente")
                {
                    controlLogeo.logeado = "gerente";
                    Server.Transfer("platos.aspx");
                }

                if (personal.verificar(Convert.ToInt32(txtCi.Text)) == "cajero")
                {
                    controlLogeo.logeado = "cajero";
                    Server.Transfer("aperturaMesa.aspx");
                }

            }

        }

        protected void txtCi_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}