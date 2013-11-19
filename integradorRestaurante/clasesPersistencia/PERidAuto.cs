using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace integradorRestaurante
{
    public class PERidAuto:ABSidAuto
    {
        private static PERidAuto instancia =null;
        private static OleDbConnection con = null;
        private PERidAuto()
        {

        }

        public static PERidAuto GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new PERidAuto();
                con = restaurante.getInstancia().crearConexion();
            }
            return instancia;
        }
        public override int asignarId(string tabla)
        {
           
            OleDbCommand cmd = new OleDbCommand("SELECT ultimoId From autoId where tabla=@tabla", con);
            cmd.Parameters.AddWithValue("@tabla", tabla);
            OleDbDataReader datos = cmd.ExecuteReader();

            int proximoId = 1;
            if (!datos.Read())
            {
                idAuto ia = new idAuto();
                ia.Tabla = tabla;
                ia.Id = proximoId;
                this.iniciar(ia);
            }

            else
            {
                proximoId = Convert.ToInt32(datos["ultimoId"])+1;
            }
            return proximoId;
        }

        public override void guardar(idAuto i)
        {
           
            OleDbCommand cmdUpdate = new OleDbCommand("update autoId set  ultimoId=@id where tabla=@tab", con);

            cmdUpdate.Parameters.AddWithValue("@id", i.Id);
            cmdUpdate.Parameters.AddWithValue("@tab", i.Tabla);
            cmdUpdate.ExecuteNonQuery();
        }

        private void iniciar(idAuto i)
        {
            
            OleDbCommand cmdUpdate = new OleDbCommand("insert into autoId (tabla,ultimoId) values(@tab,@id)", con);
            cmdUpdate.Parameters.AddWithValue("@tab", i.Tabla);
            cmdUpdate.Parameters.AddWithValue("@id", i.Id);
            
            cmdUpdate.ExecuteNonQuery();
        }
    }
}