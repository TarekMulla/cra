using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Entidades.Parametros;

namespace ProyectoCraft.AccesoDatos.Parametros
{
    public static class clsTipoOrigenDestinoCargaDAO
    {

        public static IList<clsTipoOrigenCarga> ListarTiposOrigenCarga(string descripcion)
        {
            IList<clsTipoOrigenCarga> lista = new List<clsTipoOrigenCarga>();
            clsTipoOrigenCarga origen;

            SqlDataReader objReader = null;
            SqlParameter[] objParams;

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.GetConexion(), "SP_C_TIPO_ORIGEN_CARGA");
                objParams[0].Value = descripcion;

                objReader = SqlHelper.ExecuteReader(BaseDatos.GetConexion(), "SP_C_TIPO_ORIGEN_CARGA", objParams);
                while (objReader.Read())
                {
                    origen = new clsTipoOrigenCarga();
                    origen.Id = Convert.ToInt64(objReader["Id"]);
                    origen.Nombre = objReader["Descripcion"].ToString();
                    origen.Usuario.Id = Convert.ToInt64(objReader["IdUsuario"]);
                    origen.Usuario.Nombre = objReader["Nombres"].ToString();
                    origen.Usuario.ApellidoPaterno = objReader["ApellidoPaterno"].ToString();
                    origen.Usuario.ApellidoMaterno = objReader["ApellidoMaterno"].ToString();
                    origen.FechaCreacion = Convert.ToDateTime(objReader["FechaCreacion"]);
                    lista.Add(origen);
                }
            }
            catch (Exception ex)
            {
                Base.Log.Log.EscribirLog(ex.Message);
                return null;

            }
            finally
            {
                if (objReader != null) objReader.Close();
            }
            return lista;
        }


        public static IList<clsTipoDestinoCarga> ListarTiposDestinoCarga(string descripcion)
        {
            IList<clsTipoDestinoCarga> lista = new List<clsTipoDestinoCarga>();
            clsTipoDestinoCarga destino;

            SqlDataReader objReader = null;
            SqlParameter[] objParams;

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.GetConexion(), "SP_C_TIPO_DESTINO_CARGA");
                objParams[0].Value = descripcion;

                objReader = SqlHelper.ExecuteReader(BaseDatos.GetConexion(), "SP_C_TIPO_DESTINO_CARGA", objParams);
                while (objReader.Read())
                {
                    destino = new clsTipoDestinoCarga();
                    destino.Id = Convert.ToInt64(objReader["Id"]);
                    destino.Nombre = objReader["Descripcion"].ToString();
                    destino.Usuario.Id = Convert.ToInt64(objReader["IdUsuario"]);
                    destino.Usuario.Nombre = objReader["Nombres"].ToString();
                    destino.Usuario.ApellidoPaterno = objReader["ApellidoPaterno"].ToString();
                    destino.Usuario.ApellidoMaterno = objReader["ApellidoMaterno"].ToString();
                    destino.FechaCreacion = Convert.ToDateTime(objReader["FechaCreacion"]);
                    lista.Add(destino);
                }
            }
            catch (Exception ex)
            {
                Base.Log.Log.EscribirLog(ex.Message);
                return null;

            }
            finally
            {
                if (objReader != null) objReader.Close();
            }
            return lista;
        }

    }
}
