using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace integradorRestaurante
{
    public class restaurante
    {
        OleDbConnection conexion = null;
        private restaurante()
        {

        }

        private static restaurante instancia = null;
        //singleton para las conexiones a bases de datos
        public static restaurante getInstancia()
        {
            if(instancia==null)
                instancia=new restaurante();
            return instancia;
        }


        public OleDbConnection crearConexion()
        {
            string cadena = HttpRuntime.AppDomainAppPath + "bd\\restaurante.accdb";

            if (conexion == null)
                conexion = new OleDbConnection("Provider=Microsoft.ace.OLEDB.12.0; Data Source=" + cadena);


            if (conexion.State == ConnectionState.Closed)
                conexion.Open();

            return conexion;
        }

    }
}