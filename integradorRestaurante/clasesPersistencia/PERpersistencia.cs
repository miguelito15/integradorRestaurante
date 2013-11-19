using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace integradorRestaurante
{
    public class PERpersistencia:ABSpersonal
    {
        private static PERpersistencia instancia =null;
        private static OleDbConnection con = null;
        private PERpersistencia()
        {

        }

        public static PERpersistencia GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new PERpersistencia();
                con = restaurante.getInstancia().crearConexion();
            }
            return instancia;
        }
        public override string verificar(int ci)
        {
            string rolVerificado = null;
            try
            {
             
                OleDbCommand cmd = new OleDbCommand("SELECT * From personal where ci=@ci", con);
                cmd.Parameters.AddWithValue("@ci", ci);
                OleDbDataReader datos = cmd.ExecuteReader();

                


                if (datos.Read())
                {
                    rolVerificado = datos["rol"].ToString();
                }
                
            }
            catch (Exception ex)
            {

                rolVerificado = ex.Message;
            }
            return rolVerificado;
        }

        public override List<int> listadoCi()
        {
            List<int> lista = new List<int>();
            OleDbConnection cone = restaurante.getInstancia().crearConexion();
            OleDbCommand cmd = new OleDbCommand("SELECT ci From personal where rol='mozo' ", cone);
           
            OleDbDataReader datos = cmd.ExecuteReader();




            while(datos.Read())
            {
                lista.Add(Convert.ToInt32(datos["ci"]));
            }
            return lista;
        }



        public override string verificarNombre(int ci)
        {
            string nombre = null;
            try
            {
                
                OleDbCommand cmd = new OleDbCommand("SELECT * From personal where ci=@ci", con);
                cmd.Parameters.AddWithValue("@ci", ci);
                OleDbDataReader datos = cmd.ExecuteReader();
                if (datos.Read())
                {
                    nombre = datos["nombre"].ToString();
                }

            }
            catch (Exception ex)
            {

                nombre = ex.Message;
            }
            return nombre;
        }

        public override void guardar(personal p)
        {
            OleDbCommand cmd = new OleDbCommand("UPDATE personal  SET nombre=@nom, apellido=@ape, tel=@tel, dir=@dir, rol=@rol WHERE ci=@ci", con);
            cmd.Parameters.AddWithValue("@nom", p.Nombre);
            cmd.Parameters.AddWithValue("@ape", p.Apellido);
            cmd.Parameters.AddWithValue("@tel", p.Tel);
            cmd.Parameters.AddWithValue("@dir", p.Direccion);
            cmd.Parameters.AddWithValue("@rol", p.Rol);
            cmd.Parameters.AddWithValue("@ci", p.Ci);
            int dato = cmd.ExecuteNonQuery();
            if (dato == 0)
            {
                OleDbCommand cmdInsert = new OleDbCommand("insert into personal (ci,nombre,apellido,tel,dir,rol) values(@ci,@nom,@ape,@tel,@dir,@rol)", con);
                cmdInsert.Parameters.AddWithValue("@ci", p.Ci);
                cmdInsert.Parameters.AddWithValue("@nom", p.Nombre);
                cmdInsert.Parameters.AddWithValue("@ape", p.Apellido);
                cmdInsert.Parameters.AddWithValue("@tel", p.Tel);
                cmdInsert.Parameters.AddWithValue("@dir", p.Direccion);
                cmdInsert.Parameters.AddWithValue("@rol", p.Rol);
                
                cmdInsert.ExecuteNonQuery();

            }
        }

        public override List<personal> listadoComun()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * From personal", con);
           
            OleDbDataReader datos = cmd.ExecuteReader();
            List<personal> lista = new List<personal>();
            personal per = null;
            while (datos.Read())
            {
                 per=new personal();
                 per.Nombre =datos["nombre"].ToString();
                 per.Ci = Convert.ToInt32(datos["ci"]);
                 per.Apellido = datos["apellido"].ToString();
                 per.Direccion = datos["dir"].ToString();
                 per.Tel = Convert.ToInt32(datos["tel"]);
                 per.Rol = datos["rol"].ToString();
                 lista.Add(per);
            }
            return lista;
        }
    }
}