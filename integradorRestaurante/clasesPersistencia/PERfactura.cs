using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace integradorRestaurante
{
    public class PERfactura:ABSfactura
    {
         private static PERfactura instancia =null;
        private static OleDbConnection con = null;
        private PERfactura()
        {

        }

        public static PERfactura GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new PERfactura();
                con = restaurante.getInstancia().crearConexion();
            }
            return instancia;
        }
        public override void guardar(factura f)
        {
            OleDbCommand cmd = new OleDbCommand("UPDATE factura  SET idDetalles=@det, fecha=@fec, total=@tot WHERE idFactura=@idf", con);
            cmd.Parameters.AddWithValue("@det", f.IdDetalle);
            cmd.Parameters.AddWithValue("@fec", f.Fecha);
            cmd.Parameters.AddWithValue("@tot", f.Total);
            cmd.Parameters.AddWithValue("@idf", f.IdFactura);
            
            int dato = cmd.ExecuteNonQuery();
            if (dato == 0)
            {
                OleDbCommand cmdInsert = new OleDbCommand("insert into factura (idFactura,idDetalles,fecha,total) values(@idf,@det,@fec,@tot)", con);
                cmdInsert.Parameters.AddWithValue("@idf", f.IdFactura);
                cmdInsert.Parameters.AddWithValue("@det", f.IdDetalle);
                cmdInsert.Parameters.AddWithValue("@fec", f.Fecha);
                cmdInsert.Parameters.AddWithValue("@tot", f.Total);
                

                cmdInsert.ExecuteNonQuery();

            }
        }

        

        
    }
}