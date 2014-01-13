using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Log;

namespace ProyectoCraft.AccesoDatos.LogPerfomance {
    public class ClsLogPerformanceADO {
        private static SqlParameter[] objParams = null;

        public static void SaveFromADO(LogPerformance logPerformance) {
            var st = new System.Diagnostics.StackTrace();
            if (String.IsNullOrEmpty(logPerformance.Accion))
                logPerformance.Accion = st.GetFrame(1).GetMethod().Name;
            if (String.IsNullOrEmpty(logPerformance.Modulo))
                logPerformance.Modulo = st.GetFrame(1).GetMethod().ReflectedType.FullName;
            Save(logPerformance);
        }

        public static void Save(LogPerformance logPerformance) {
            var res = new ResultadoTransaccion();
            var conn = BaseDatos.NuevaConexion();

            try {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_LOG_PERFORMANCE");
                objParams[0].Value = logPerformance.Usuario.NombreUsuario;
                objParams[1].Value = logPerformance.Modulo;
                objParams[2].Value = logPerformance.Accion;
                objParams[3].Value = logPerformance.Tiempo;
                SqlCommand command3 = new SqlCommand("SP_N_LOG_PERFORMANCE", conn);

                command3.Parameters.AddRange(objParams);
                command3.CommandType = CommandType.StoredProcedure;
                command3.ExecuteNonQuery();

                res.Estado = Enums.EstadoTransaccion.Aceptada;

            } catch (Exception ex) {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            } finally {
                if (conn != null)
                    if (conn.State == ConnectionState.Open) conn.Close();
            }
        }
    }
}
