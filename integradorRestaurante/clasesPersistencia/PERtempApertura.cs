using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
namespace integradorRestaurante
{
    public class PERtempApertura:ABStempApertura
    {
        private static PERtempApertura instancia =null;
        private static OleDbConnection con = null;
        private PERtempApertura()
        {

        }

        public static PERtempApertura GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new PERtempApertura();
                con = restaurante.getInstancia().crearConexion();
            }
            return instancia;
        }
        public override int mosoMenosOcupado()
        {
            
            int ciMoso;
            int cont;
            int menor = 99999;
            int ciMenor = 0;
            try
            {
                
                OleDbCommand cmd = new OleDbCommand("SELECT * From tempApertura order by ciMoso", con);
                
                OleDbDataReader datos = cmd.ExecuteReader();
               
               
                tempApertura t = null;
                int[] arreglo = { -5, -4, -3, -2, -1 };
                List<int> lista = personal.listarCi();

                //si la tabla esta vacia la inicializa con valores de mesas negativos 
                if (!datos.Read()) 
                {
                    t = new tempApertura();
                    

                    for (int i = 0; i < arreglo.Length; i++)                     
                        {
                            t.CiMoso = lista[i];
                            t.IdMesa = arreglo[i];
                        //retorna el ultimo moso en la lista
                            ciMenor = t.CiMoso;
                            this.inicializar(t);
                        }
                    
                }
                bool hayDatos = datos.Read();
                //este corte de control devulve el moso con menos mesas asignadas
                while (hayDatos)
                {
                    ciMoso = Convert.ToInt32(datos["ciMoso"]);
                    cont = 0;
                    while (hayDatos && ciMoso == Convert.ToInt32((datos["ciMoso"])))
                    {
                        cont++;
                        hayDatos = datos.Read();

                        
                    }
                    if (cont < menor)
                    {
                        menor = cont;
                        ciMenor = ciMoso;
                        //hayDatos = datos.Read();
                    }


                }
                

            }
            catch (Exception ex)
            {

               
            }
            return ciMenor;
        }

        private void inicializar(tempApertura a) {

            try
            {
                
                OleDbCommand cmdUpdate = new OleDbCommand("insert into tempApertura (idMesa,ciMoso)values(@mesa,@ciMoso)",con);
                cmdUpdate.Parameters.AddWithValue("@mesa",a.IdMesa);
                cmdUpdate.Parameters.AddWithValue("@moso",a.CiMoso);
               
                cmdUpdate.ExecuteNonQuery();

                
            }

            catch (Exception ex)
            {
                
            }
        }

        public override void guardar(tempApertura t)
        {
            try
            {
                
           
                    OleDbCommand cmdInsert = new OleDbCommand("insert into tempApertura (idMesa,ciMoso)values(@mesa,@ciMoso)", con);
                    cmdInsert.Parameters.AddWithValue("@mesa", t.IdMesa);
                    cmdInsert.Parameters.AddWithValue("@ciMoso", t.CiMoso);

                    cmdInsert.ExecuteNonQuery();
                 
                    
               


            }

            catch (Exception ex)
            {

            }
        }

        public override int mozoEnMesa(int mesa)
        {
            
            OleDbCommand cmd = new OleDbCommand("SELECT ciMoso From tempApertura where idMesa=@mesa", con);
            cmd.Parameters.AddWithValue("@mesa",mesa);
            OleDbDataReader datos = cmd.ExecuteReader();
            int id=0;
            if (datos.Read())
                id = Convert.ToInt32(datos["ciMoso"]);
            return id;
        }

        public override void borrarXmesa(int mesa)
        {
      
            OleDbCommand cmd = new OleDbCommand("delete * From tempApertura where idMesa=@mesa", con);
            cmd.Parameters.AddWithValue("@mesa", mesa);
            cmd.ExecuteNonQuery();
            
        }
    }
}