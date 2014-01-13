using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ProyectoCraft.Base.BaseDatos
{
    public class BaseDatos
    {
        public static string GetConexion()
        {
            return RutaArchivoBD(Valor_Config("cadenaconexion"));
        }

        private static string RutaArchivoBD(string strRuta)
        {
            return Instancia.GetStrCon(strRuta);
        }

        private static string Valor_Config(string strKey)
        {
            //  return (string)System.Configuration.ConfigurationManager.AppSettings.Get(strKey);                     
            return System.Configuration.ConfigurationSettings.AppSettings.Get(strKey);
        }


        private static SqlConnection _conn = null;
        public static SqlConnection Conexion()
        {
            if(_conn == null)
                _conn = new SqlConnection(GetConexion());

            return _conn;
        }


    }
}
