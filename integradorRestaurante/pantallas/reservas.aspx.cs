using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace integradorRestaurante
{
    public partial class reservas1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            mesasLibres.Items.Clear();
            foreach (mesas me in mesas.mesasLibres(Convert.ToInt32(txtcapacidad.Text),Convert.ToDateTime(txtfecha.Text), turno.SelectedValue))
            {

                mesasLibres.Items.Add(new ListItem("Mesa  "+me.IdMesa+"  Capacidad: "+"("+me.Capacidad.ToString()+")"+"  Personas",me.IdMesa.ToString()));
            }

            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            mesasRes.Items.Add(mesasLibres.SelectedValue);
            
            mesasAux.lista.Add(Convert.ToInt32(mesasLibres.SelectedValue));
            mesasLibres.Items.Remove(mesasLibres.SelectedItem);
        }

        protected void txtcapacidad_TextChanged(object sender, EventArgs e)
        {
            Button2.Visible = true;
        }

        protected void fecha_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int idm = idAuto.asignarId("mesasAux");
            int idr = idAuto.asignarId("reservas"); 

            reservas r = new reservas();

            r.IdRes = idr;
            r.Fecha =Convert.ToDateTime(txtfecha.Text);
            r.IdMesa = idm;
            r.Nombre = txtnombre.Text;
            r.Estado = "activa";
            r.Turno = turno.SelectedValue;

            reservas.guardar(r);
            mesasAux mx = new mesasAux();
            foreach (int n in mesasAux.lista)
            {
                mx.IdMesa = n;
                mx.IdRes = r.IdRes;
                mesasAux.guardar(mx);
                //mesas.actualizarEstado(n, "reservada");
            }
            mesasAux.lista.Clear();
           

            //actualiza el ultimo id dado para la tabla mesasAux
            //actualiza el ultimo id dado para reservas

            idAuto i = new idAuto();
            i.Id = idr;
            i.Tabla = "reservas";
            idAuto.guardar(i);

            idAuto ia = new idAuto();
            ia.Id = idm;
            ia.Tabla = "mesasAux";
            idAuto.guardar(ia);

           
           
            
           

            Server.Transfer("reservas.aspx");
            
        }

        protected void txtfecha_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(txtfecha.Text) < DateTime.Today)
            {

                mensaje.Text = "La fecha de reserva debe ser mayor o igual a la de hoy";
                Button2.Visible = false;
            }
            else
            {
                mensaje.Text = "";
                Button2.Visible = true;
            }

        }
    }
}