using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Entidades.Settings;
using Microsoft.ApplicationBlocks.Data;

namespace ProyectoCraft.AccesoDatos.Settings
{
    public class UsuarioDAO
    {
        private string _sql = "";

        public static IList<Usuario> ObtenerUsuarios()
        {
           IList<Usuario> _list = new List<Usuario>();
                                            
           SqlDataReader objReader = null;

           SqlParameter[] objParams;
           objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.GetConexion(), "SP_SETTING_LISTAUSUARIOS");

           try
           {
               objReader = SqlHelper.ExecuteReader(BaseDatos.GetConexion(), "SP_SETTING_LISTAUSUARIOS", objParams);
               while (objReader.Read())
               {
                   Usuario usuario = new Usuario();
                   usuario.Id = Convert.ToInt64(objReader["Id"]);
                   usuario.Nombre = objReader["Nombre"].ToString();
                   usuario.NombreUsuario = objReader["NombreUsuario"].ToString();
                   usuario.EsAdministrador = Convert.ToBoolean(objReader["EsAdministrador"]);
                   usuario.Habilitado = Convert.ToBoolean(objReader["Habilitado"]);
                   usuario.FechaCreacion = Convert.ToDateTime(objReader["FechaCreacion"]);

                   _list.Add(usuario);


               }
           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message);
           }
           finally
           {
               if (objReader != null) objReader.Close();
           }
           return _list;
        }

    }
}
