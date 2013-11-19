using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace integradorRestaurante
{
    public partial class aperturaMesa : System.Web.UI.Page
    {
        private static int bandera=0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (mesasLibres.Items.Count==0 && mesasRes.Items.Count==0)
            {
                mesasLibres.Items.Add("Seleccione mesa libre");
                foreach (mesas me in mesas.mesasLibres())
                {

                    mesasLibres.Items.Add(new ListItem("Mesa Numero:  "+ me.IdMesa, me.IdMesa.ToString()));
                }

                mesasRes.Items.Add("Seleccione reserva");
                //carga las mesas q estan reservadas para el dia y el turno actual
                foreach (reservas rv in reservas.listaXturnoYfecha(controlLogeo.turno, DateTime.Now.Date))
                    mesasRes.Items.Add(new ListItem("RESERVA PARA: " + rv.Nombre + " A LA NOCHE" + rv.Turno,rv.IdRes.ToString()));
                        
                    
                
            }
        }
        
        protected void mesasLibres_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (mesasLibres.SelectedValue != "0" || mesasLibres.SelectedValue != " ")
            {
                Label1.Text = tempApertura.mosoMenosOcupado().ToString();
                Label2.Text = personal.verificarNombre(Convert.ToInt32(Label1.Text));
                bandera = 1;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (mesasLibres.SelectedValue != "Seleccione mesa libre" || mesasRes.SelectedValue != "Seleccione reserva")
            {
                tempApertura t = new tempApertura();
                if (bandera == 0)
                {
                    foreach (mesasAux mx in mesasAux.listado())
                    {
                        if (mx.IdRes == Convert.ToInt32(mesasRes.SelectedValue))
                        {
                            t.IdMesa = mx.IdMesa;
                            t.CiMoso = Convert.ToInt32(Label1.Text);
                            tempApertura.guardar(t);
                            mesas.actualizarEstado(Convert.ToInt32(mesasRes.SelectedValue), "ocupada");
                        }


                    }


                    reservas.cambiarEstadoRes(Convert.ToInt32(mesasRes.SelectedValue), "realizada");

                }
                if (bandera == 1)
                {


                    t.IdMesa = Convert.ToInt32(mesasLibres.SelectedValue);
                    t.CiMoso = Convert.ToInt32(Label1.Text);
                    tempApertura.guardar(t);

                    mesas.actualizarEstado(Convert.ToInt32(mesasLibres.SelectedValue), "ocupada");
                }
                //cambiar estado de la reserva
                //reservas.cambiarEstadoRes(Convert.ToInt32(mesasRes.SelectedValue),"realizada");
                Server.Transfer("aperturaMesa.aspx");
            }
            
        }

        protected void mesasRes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mesasRes.SelectedValue != "0" || mesasRes.SelectedValue != " ")
            {
                Label1.Text = tempApertura.mosoMenosOcupado().ToString();
                Label2.Text = personal.verificarNombre(Convert.ToInt32(Label1.Text));
                bandera = 0;
            }
        }
    }
}