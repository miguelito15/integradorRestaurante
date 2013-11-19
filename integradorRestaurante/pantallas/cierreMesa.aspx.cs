using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace integradorRestaurante
{
    public partial class cierreMesa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //se cargan las mesas que estan ocupadas en el momento
            foreach (mesas m in mesas.listadoComun())
                if (m.Estado == "ocupada")
                    mesasOcu.Items.Add(m.IdMesa.ToString());
            }

        }
        private static List<listaPlatos> li = new List<listaPlatos>();
        private static int ped;
        private static int mesa;
        List<pedidos> p;
        List<int> idp;
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (mesasOcu.Items.Count != 0)
            {
                TodoLoPedido.Items.Clear();
                //pedidos p = new pedidos();
                //carga en p el pedido asosiado a la mesa pasada como parametro
                p = pedidos.pedXmesa(Convert.ToInt32(mesasOcu.SelectedValue));
                if (p == null)
                    mensaje.Text = "Esta mesa no ha realizado pedidos todavia";
                else
                {
                    foreach (pedidos pedi in p)
                    {
                        if (pedi.IdFactura == 0)
                        {
                            // idp.Add(pedi.IdPed);
                            mesa = pedi.Mesa;

                            //carga en lp la lista de todos los pedidos con el id de pedido pasado como parametro
                            List<listaPlatos> lp = listaPlatos.listaXped(pedi.IdPed);
                            mensaje.Text = "";
                            foreach (listaPlatos platos in lp)
                            {
                                //para cada id de pedido en listaPlato q sea = a idpedido de pedidos se carga en un listbox
                                if (platos.IdPedido == pedi.IdPed)
                                {
                                    TodoLoPedido.Items.Add("      ID PLATO: " + platos.IdPlato + " PRECIO: " + platos.Precio + " SUBTOTAL " + platos.SubTotal.ToString());
                                    li.Add(platos);
                                }
                            }
                        }
                    }
                    //suma el total de los pedidos para la mesa 
                    Label2.Text = listaPlatos.suma(mesa).ToString();
                }
            }
            else
            {
                mensaje.Text = "No hay mesas disponibles para facturar";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (mesasOcu.Items.Count != 0)
            {
                int idf = idAuto.asignarId("factura");
                int idd = idAuto.asignarId("detallesFactura");

                factura f = new factura();
                f.IdFactura = idf;
                f.IdDetalle = idd;
                f.Fecha = DateTime.Today;
                f.Total = Convert.ToInt32(Label2.Text);
                factura.guardar(f);
                platos det;
                foreach (listaPlatos l in li)
                {
                    det = platos.buscaXid(l.IdPlato);
                    detallesFactura dt = new detallesFactura();
                    dt.Desc = det.Desc;
                    dt.IdDetalle = idd;
                    dt.IdFactura = idf;
                    dt.IdPlato = l.IdPlato;
                    dt.Precio = l.Precio;

                    detallesFactura.guardar(dt);
                    pedidos.actualizarIdFact(idf, ped);
                }
                p = pedidos.pedXmesa(Convert.ToInt32(mesasOcu.SelectedValue));
                foreach (pedidos pe in p)
                {
                    pedidos.actualizarIdFact(idf, pe.IdPed);
                }
                //actualiza id de factura en pedidos
                idAuto i = new idAuto();
                i.Tabla = "factura";
                i.Id = idf;
                idAuto.guardar(i);

                idAuto ifa = new idAuto();
                ifa.Tabla = "detallesFactura";
                ifa.Id = idd;
                idAuto.guardar(ifa);




                //actualiza en estado de la mesa a libre
                //y borra la maesa de la tabla temporan apertura
                mesas.actualizarEstado(Convert.ToInt32(mesasOcu.SelectedValue), "libre");
                tempApertura.borrar(Convert.ToInt32(mesasOcu.SelectedValue));

                if (mesasAux.estaRes(Convert.ToInt32(mesasOcu.SelectedValue)))
                    mesasAux.borrar(Convert.ToInt32(mesasOcu.SelectedValue));
                List<detallesFactura> prueba = detallesFactura.listado(idf);

                controlLogeo.idFact = idf;
                controlLogeo.idDet = idd;
                controlLogeo.tot = Convert.ToInt32(Label2.Text);
                controlLogeo.pagOrigen = "factura";
                Server.Transfer("impFact.aspx");

            }
            else
                mensaje.Text = "No hay datos para facturar";
            
        }
    }
}