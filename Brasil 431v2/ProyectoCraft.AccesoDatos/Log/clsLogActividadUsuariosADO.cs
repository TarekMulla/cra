using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Log;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Entidades.Enums;

namespace ProyectoCraft.AccesoDatos.LogActividades
{
    public static class clsLogActividadUsuariosADO
    {
        private static SqlParameter[] objParams = null;

        public static ResultadoTransaccion GuardaActividad(LogActividadUsuarios log)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            SqlConnection conn = BaseDatos.NuevaConexion();

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_LOG_ACTIVIDAD_USUARIO");
                objParams[0].Value = log.Entidad;
                objParams[1].Value = log.IdEntidad;
                objParams[2].Value = log.Actividad;
                objParams[3].Value = log.Usuario.Id;
                SqlCommand command3 = new SqlCommand("SP_N_LOG_ACTIVIDAD_USUARIO", conn);
                
                command3.Parameters.AddRange(objParams);
                command3.CommandType = CommandType.StoredProcedure;
                command3.ExecuteNonQuery();

                res.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            finally
            {
                if(conn != null)
                    if(conn.State == ConnectionState.Open) conn.Close();
            }
            return res;
        }


    }
}
