using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace integradorRestaurante
{
    public partial class impFact : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (controlLogeo.pagOrigen == "factura")
            {
                foreach (imprimirFacturas l in imprimirFacturas.prepararListadoFactura(controlLogeo.idFact))
                {
                    txtfecha.Text = l.Fecha.ToShortDateString();
                    txtid.Text = l.IdFactura.ToString();
                    txtTot.Text ="TOTAL:"+ controlLogeo.tot.ToString();


                }

                detallesF.DataSource = imprimirFacturas.prepararListadoFactura(controlLogeo.idFact);

                detallesF.DataBind();
            }
            if (controlLogeo.pagOrigen == "platos")
            {


                detallesF.DataSource = platos.listadoParaImp(0);

                detallesF.DataBind();
            }

            if (controlLogeo.pagOrigen == "platosEstadisticas")
            {
                detallesF.DataSource = PERdetallesFactura.GetInstancia().union(controlLogeo.parametroDesde.Date,controlLogeo.parametroHasta.Date);
                detallesF.DataBind();
            }
            if (controlLogeo.pagOrigen == "platosEstadisticas1")
            {
                detallesF.DataSource = PERdetallesFactura.GetInstancia().unionXmozo(controlLogeo.parametroDesde.Date, controlLogeo.parametroHasta.Date);
                detallesF.DataBind();
            }
        }

       

        protected void detallesF_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (controlLogeo.pagOrigen == "platos" || controlLogeo.pagOrigen == "platosEstadisticas" || controlLogeo.pagOrigen == "platosEstadisticas1")
            {
            }
            else
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[1].Visible = false;
            }
        }

        
    }
}