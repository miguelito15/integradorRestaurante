using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace integradorRestaurante
{
    public class PERpedidos:ABSpedidos
    {
        private static PERpedidos instancia =null;
        private static OleDbConnection con = null;
        private PERpedidos()
        {

        }

        public static PERpedidos GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new PERpedidos();
                con = restaurante.getInstancia().crearConexion();
            }
            return instancia;
        }
        public override void guardar(pedidos p)
        {
            try
            {

              
                OleDbCommand cmdUpdate = new OleDbCommand("update pedidos set  ciMozo=@mozo, idListaPlatos=@platos, idMesa=@mesa, idFactura=@fact where idPedido=@id", con);

                cmdUpdate.Parameters.AddWithValue("@mozo", p.IdMoso);
                cmdUpdate.Parameters.AddWithValue("@platos", p.IdListaPlatos);
                cmdUpdate.Parameters.AddWithValue("@mesa",p.Mesa);
                cmdUpdate.Parameters.AddWithValue("@fact", p.IdFactura);
                cmdUpdate.Parameters.AddWithValue("@id", p.IdPed);





                int contador = cmdUpdate.ExecuteNonQuery();

                if (contador == 0)
                {
                    OleDbCommand cmdInsert = new OleDbCommand("insert into pedidos (idPedido, ciMozo, idListaPlatos,idMesa,idFactura) values(@id,@moso, @plato,@mesa,@fact)", con);
                    cmdInsert.Parameters.AddWithValue("@id", p.IdPed);
                    cmdInsert.Parameters.AddWithValue("@mozo", p.IdMoso);
                    cmdInsert.Parameters.AddWithValue("@plato", p.IdListaPlatos);
                    cmdInsert.Parameters.AddWithValue("@mesa", p.Mesa);
                    cmdInsert.Parameters.AddWithValue("@fact",p.IdFactura);
                  
                    

                    cmdInsert.ExecuteNonQuery();
                }
                
            }

            catch (Exception ex)
            {
                 
            }
        }

        public override List<pedidos> buscarXmesa(int m)
        {
            
            OleDbCommand cmdUpdate = new OleDbCommand("select * from pedidos where idMesa=@mesa", con);
            cmdUpdate.Parameters.AddWithValue("@mesa",m);
            OleDbDataReader datos = cmdUpdate.ExecuteReader();
            pedidos p=null;
            List<pedidos> l = new List<pedidos>();
            while(datos.Read())
            {
                p = new pedidos();
                
                p.IdListaPlatos =Convert.ToInt32(datos["idListaPlatos"]);
                p.IdMoso = Convert.ToInt32(datos["ciMozo"]);
                p.IdPed = Convert.ToInt32(datos["idPedido"]);
                p.Mesa = Convert.ToInt32(datos["idMesa"]);
                p.IdFactura = Convert.ToInt32(datos["idFactura"]);
                l.Add(p);
            }

            return l;

        }

        public override void actualizarFact(int f, int p)
        {
            OleDbCommand cmdUpdate = new OleDbCommand("update pedidos set idFactura=@fact where idPedido=@ped", con);
            cmdUpdate.Parameters.AddWithValue("@fact", f);
            cmdUpdate.Parameters.AddWithValue("@ped", p);

            cmdUpdate.ExecuteNonQuery();
        }
    }
}