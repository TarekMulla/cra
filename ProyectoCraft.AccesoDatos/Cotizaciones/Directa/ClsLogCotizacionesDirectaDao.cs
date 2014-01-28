using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.Entidades.GlobalObject;


namespace ProyectoCraft.AccesoDatos.Cotizaciones.Directa {
    public class ClsLogCotizacionesDirectaDao {
        private const String NombreClase = "ClsLogCotizacionesDirectaDao";

        public static ResultadoTransaccion Guardar(LogCotizacionesDirecta logCotizacionDirecta) {
            var  res = new ResultadoTransaccion();
            SqlTransaction trans = null;
            //Abrir Conexion
            var conn = BaseDatos.Conexion();
            try {
                var command = new SqlCommand("SP_N_COTIZACION_SOLICITUD_COTIZACIONES_LOG", conn);
                command.Transaction = conn.BeginTransaction();
                trans = command.Transaction;

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idUsuario", logCotizacionDirecta.Usuario.Id32);
                command.Parameters.AddWithValue("@IdCotizacionDirecta", logCotizacionDirecta.CotizacionDirecta.Id32);
                command.Parameters.AddWithValue("@fecha", logCotizacionDirecta.Fecha);
                command.Parameters.AddWithValue("@Tipo", logCotizacionDirecta.Tipo);
                command.Parameters.AddWithValue("@descripcion", logCotizacionDirecta.Descripcion);
                
                command.CommandType = CommandType.StoredProcedure;

                var outParam = command.Parameters.Add("@Id", SqlDbType.BigInt);
                outParam.Direction = ParameterDirection.Output;
                command.ExecuteScalar();
                command.Transaction.Commit();

                logCotizacionDirecta.Id = Convert.ToInt16(outParam.Value);
                logCotizacionDirecta.Id32 = Convert.ToInt32(outParam.Value);

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = logCotizacionDirecta;
                res.Descripcion = "La cotización Directa se guardó Exitosamente";


            } catch (Exception ex) {
                if (trans != null)
                    trans.Rollback();
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = NombreClase;
                res.MetodoError = MethodBase.GetCurrentMethod().Name;
            } finally {
                conn.Close();
            }
            return res;
        }
    }
}
