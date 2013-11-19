using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
namespace integradorRestaurante
{
    public class PERmesas:ABSmesas
    {
        private static PERmesas instancia =null;
        private static OleDbConnection con = null;
        private PERmesas()
        {

        }

        public static PERmesas GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new PERmesas();
                con = restaurante.getInstancia().crearConexion();
            }
            return instancia;
        }
        public override List<mesas> listadoComun()
        {
            
            List<mesas> lis = new List<mesas>();
           
            OleDbCommand cmdlistado = new OleDbCommand("select * from mesas", con);
            OleDbDataReader datos = cmdlistado.ExecuteReader();



            while (datos.Read())
            {
                mesas x = new mesas();
                x.IdMesa = Convert.ToInt32(datos["idMesa"]);
                x.Capacidad =Convert.ToInt32( datos["capacidad"]);
                x.Estado = datos["estado"].ToString();
               
                lis.Add(x);
            }

            return lis;
        }

        private static Boolean estaReservada(int me)
        {
            Boolean val=false;
            List<mesasAux> maux = mesasAux.listado();
            foreach (mesasAux mesa in maux)
                if (mesa.IdMesa == me)
                {
                    return val = true;
                    
                }
                else
                    val = false;
            return val;
        }


        public override List<mesas> mesasLibres(int x, DateTime fecha, string turno)
        {
            List<mesas> l = new List<mesas>();
            List<mesasAux> maux = mesasAux.listado();
            List<reservas> res = reservas.listarRes();
            List<mesas> m = mesas.listadoComun();
            
            foreach (mesas me in m)
                if (estaReservada(me.IdMesa)==true)
                {
                    foreach (reservas r in res)
                        if (r.Turno != turno || r.Fecha != fecha)
                            if (me.Capacidad >= x)
                                l.Add(me);
                }
                else
                {
                    l.Add(me);
                }
               

                    
            return l;
        }

        public override List<mesas> mesasLibres()
        {
            List<mesas> l = new List<mesas>();
            foreach (mesas me in this.listadoComun())
                if (me.Estado == "libre" )
                    l.Add(me);
            return l;
        }


        public override void actualizarEstado(int mesa, string estado)
        {
            
            OleDbCommand cmdUpdate = new OleDbCommand("update mesas set estado=@est where idMesa=@mesa", con);
            cmdUpdate.Parameters.AddWithValue("@est", estado);
            cmdUpdate.Parameters.AddWithValue("@mesa", mesa);

            cmdUpdate.ExecuteNonQuery();
        }

        public override List<mesas> mesasReservadas()
        {
            List<mesas> l = new List<mesas>();
            foreach (mesas me in this.listadoComun())
                if (me.Estado == "reservada")

                    l.Add(me);
            return l;
        }

        public override void guardar(mesas m)
        {
            OleDbCommand cmdInsert = new OleDbCommand("insert into mesas (idMesa, capacidad, estado) values(@id,@cap,@est)", con);
            cmdInsert.Parameters.AddWithValue("@id", m.IdMesa);
            cmdInsert.Parameters.AddWithValue("@cap",m.Capacidad);
            cmdInsert.Parameters.AddWithValue("@est", m.Estado);

            cmdInsert.ExecuteNonQuery();
        }
    }
}