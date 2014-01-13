using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Cotizaciones;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Usuarios;


namespace ProyectoCraft.AccesoDatos.Cotizaciones.Directa {
    public class ClsCotizacionDirectaEstadoDao {
        private const String NombreClase = "ClsCotizacionDirectaEstadoDao";
        private static SqlParameter[] objParams = null;
        public static ResultadoTransaccion ListarEstadosCotizacionDirecta() {
            ResultadoTransaccion res = new ResultadoTransaccion();

            IList<Estado> list = new List<Estado>();
            //Abrir Conexion
            var conn = BaseDatos.NuevaConexion();
            try {
                SqlCommand command = new SqlCommand("SP_L_COTIZACION_DIRECTA_ESTADOS", conn);
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_L_COTIZACION_DIRECTA_ESTADOS");
                command.Transaction = conn.BeginTransaction();

                command.CommandType = CommandType.StoredProcedure;

                var reader = command.ExecuteReader();
                while (reader.Read()) {
                    list.Add(GetFromDataReader(reader));
                }

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = list;
                res.Descripcion = "Listado Cotizaciones Directas Estados";

            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = NombreClase;
                res.MetodoError = MethodBase.GetCurrentMethod().Name;
            } finally {
                conn.Close();
            }
            return res;
        }
        public static ResultadoTransaccion CambioEstado(ITableable cotizacion, Int32 idEstado, clsUsuario usuario) {

            var res = new ResultadoTransaccion();
            SqlTransaction trans = null;
            //Abrir Conexion
            var conn = BaseDatos.NuevaConexion();
            try {
                var command = conn.CreateCommand();
                trans = conn.BeginTransaction();
                command.Transaction = trans;
                if (cotizacion is CotizacionDirecta) {
                    command.CommandText = "SP_A_COTIZACION_DIRECTA_ESTADO";
                } else {
                    command.CommandText = "SP_A_COTIZACION_INDIRECTA_ESTADO";
                }

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdCotizacion", cotizacion.Id32);
                command.Parameters.AddWithValue("@IdEstado", idEstado);
                command.Parameters.AddWithValue("@IdUsuario", usuario.Id32);

                command.CommandType = CommandType.StoredProcedure;

                command.ExecuteNonQuery();
                trans.Commit();
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Actualizar;
                res.Estado = ProyectoCraft.Entidades.Enums.Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Cambios se han registrado correctamente";

            } catch (Exception ex) {
                if (trans != null)
                    trans.Rollback();
                Log.EscribirLog(ex.Message);
                res.Estado = ProyectoCraft.Entidades.Enums.Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                res.ArchivoError = NombreClase;
                res.MetodoError = MethodBase.GetCurrentMethod().Name;
            } finally {
                conn.Close();
            }
            return res;
        }

        private static Estado GetFromDataReader(SqlDataReader reader) {
            try {
                var i = new Estado();
                i.Id = i.Id32 = Convert.ToInt32(reader["id"]);//num solicitud                
                i.Nombre = reader["nombre"].ToString();
                i.Activo = Convert.ToBoolean(reader["activo"]);
                return i;
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);
                //throw;
                return null;
            }

        }

    }
}
