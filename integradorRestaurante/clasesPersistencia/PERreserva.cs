using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;


namespace integradorRestaurante
{
    public class PERreserva:ABSreservas
    {
        private static PERreserva instancia =null;
     //   private static OleDbConnection con = null;
        private PERreserva()
        {

        }

        public static PERreserva GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new PERreserva();
               // con = restaurante.getInstancia().crearConexion();
            }
            return instancia;
        }
        public override string guardar(reservas res)
        {
            string mensaje = "Guardado";
            try
            {

                OleDbConnection con = restaurante.getInstancia().crearConexion();
                OleDbCommand cmdUpdate = new OleDbCommand("update reservas set  idMesa=@mesa, fechaRes=@fec, estado=@est, nombre=@nom , turno=@tur where idRes=@id", con);
                //OleDbCommand cmdUpdate = new OleDbCommand("update reservas set  idMesa=@mesa, fechaRes=@fec, estado=@est, nombre=@nom  where idRes=@id", con);

                cmdUpdate.Parameters.AddWithValue("@mesa", res.IdMesa);
                cmdUpdate.Parameters.AddWithValue("@fec",res.Fecha);
                cmdUpdate.Parameters.AddWithValue("@est", res.Estado);
                cmdUpdate.Parameters.AddWithValue("@nom", res.Nombre);
                cmdUpdate.Parameters.AddWithValue("@tur", res.Turno);
                cmdUpdate.Parameters.AddWithValue("@id", res.IdRes);
                





                int contador = cmdUpdate.ExecuteNonQuery();

                if (contador == 0)
                {
                    OleDbCommand cmdInsert = new OleDbCommand("insert into reservas(idRes, idMesa, fechaRes, estado, nombre, turno) values(@id,@mesa, @fec,@est,@nom,@tur)", con);
                    //OleDbCommand cmdInsert = new OleDbCommand("insert into reservas(idRes, idMesa, fechaRes, estado, nombre) values(@id,@mesa, @fec,@est,@nom)", con);
                   
                    cmdInsert.Parameters.AddWithValue("@id", res.IdRes);
                    cmdInsert.Parameters.AddWithValue("@mesa",res.IdMesa);
                    cmdInsert.Parameters.AddWithValue("@fec",res.Fecha);
                    cmdInsert.Parameters.AddWithValue("@est", res.Estado);
                    cmdInsert.Parameters.AddWithValue("@nom", res.Nombre);
                    cmdInsert.Parameters.AddWithValue("@tur", res.Turno);

                
                    cmdInsert.ExecuteNonQuery();
                }
                
            }

            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return mensaje;
        }

        public override void cambiarEstado(int r, string estado)
        {
            OleDbConnection con = restaurante.getInstancia().crearConexion();
            OleDbCommand cmdUpdate = new OleDbCommand("update reservas set estado=@est where idMesa=@mesa and estado='activa' ", con);
            cmdUpdate.Parameters.AddWithValue("@est", estado);
            cmdUpdate.Parameters.AddWithValue("@mesa", r);

            cmdUpdate.ExecuteNonQuery();
        }

        public override List<reservas> listaReservas()
        {
            OleDbConnection con = restaurante.getInstancia().crearConexion();
            OleDbCommand cmdUpdate = new OleDbCommand("select * from reservas", con);


            OleDbDataReader datos = cmdUpdate.ExecuteReader();
            List<reservas> lis = new List<reservas>();
            while (datos.Read())
            {
                reservas x = new reservas();
                x.IdMesa = Convert.ToInt32(datos["idMesa"]);
                x.IdRes = Convert.ToInt32(datos["idRes"]);
                x.Estado = datos["estado"].ToString();
                x.Fecha=Convert.ToDateTime(datos["fechaRes"]);
                x.Nombre = datos["nombre"].ToString();
                x.Turno = datos["turno"].ToString();
                lis.Add(x);
            }
            return lis;
        }


        public override List<reservas> listaResXturno(string turnoAct, DateTime fecha)
        {
            OleDbConnection con = restaurante.getInstancia().crearConexion();
            OleDbCommand cmdUpdate = new OleDbCommand("select * from reservas where turno = @tur and fechaRes = @fec", con);
            cmdUpdate.Parameters.AddWithValue("@tur", turnoAct);
            cmdUpdate.Parameters.AddWithValue("@fec", fecha.Date);

            OleDbDataReader datos = cmdUpdate.ExecuteReader();
            List<reservas> lis = new List<reservas>();
            while (datos.Read())
            {
                reservas x = new reservas();
                x.IdMesa = Convert.ToInt32(datos["idMesa"]);
                x.IdRes = Convert.ToInt32(datos["idRes"]);
                x.Estado = datos["estado"].ToString();
                x.Fecha = Convert.ToDateTime(datos["fechaRes"]);
                x.Nombre = datos["nombre"].ToString();
                x.Turno = datos["turno"].ToString();
                lis.Add(x);
            }
            return lis;
        }
    }

        
    
}