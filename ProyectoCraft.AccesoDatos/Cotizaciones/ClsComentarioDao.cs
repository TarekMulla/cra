using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Cotizaciones;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Usuarios;


namespace ProyectoCraft.AccesoDatos.Cotizaciones {
    public class ClsComentarioDao {
        private const String NombreClase = "ClsComentarioDao";

        public static ResultadoTransaccion Guardar(ITableable cotizacion, Comentario comentario) {
            return Guardar("SP_N_COTIZACION_COMENTARIOS", cotizacion.Id32, comentario);
        }

        public static ResultadoTransaccion Guardar(Opcion opcionDirecta, Comentario comentario) {
            return Guardar("SP_N_COTIZACION_DIRECTA_COMENTARIOS", opcionDirecta.Id32, comentario);
        }

        private static ResultadoTransaccion Guardar(String storeName, Int64 idCotizacionORopcion, Comentario comentario) {
            var res = new ResultadoTransaccion();
            SqlTransaction trans = null;
            //Abrir Conexion
            var conn = BaseDatos.Conexion();
            try {

                var command = new SqlCommand(storeName, conn){Transaction = conn.BeginTransaction()};

                trans = command.Transaction;

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EsHistorial", comentario.EsHistorial);
                command.Parameters.AddWithValue("@Comentario", comentario.Observacion);
                command.Parameters.AddWithValue("@idUsuario", comentario.Usuario.Id32);
                command.Parameters.AddWithValue("@idOpcion_o_Cotizacion", idCotizacionORopcion);

                command.CommandType = CommandType.StoredProcedure;

                var outParam = command.Parameters.Add("@Id", SqlDbType.BigInt);
                outParam.Direction = ParameterDirection.Output;
                command.ExecuteScalar();

                comentario.Id = Convert.ToInt16(outParam.Value);
                comentario.Id32 = Convert.ToInt32(outParam.Value);
                command.Transaction.Commit();

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = comentario;
                res.Descripcion = "El comentario guardo Exitosamente";

            } catch (Exception ex) {
                comentario.Id = comentario.Id32 = 0;
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

        /// <summary>
        /// Retorna todos los mensajes incluidos los historiales
        /// </summary>
        /// <returns></returns>
        public static ResultadoTransaccion ObtieneTodosLosMensajes(ITableable cotizacion) {
            return ObtieneTodosLosMensajes("SP_L_COTIZACION_COMENTARIOS", cotizacion.Id32);
        }

        /// <summary>
        /// Retorna todos los mensajes incluido los historiales
        /// </summary>
        /// <param name="opcion"></param>
        /// <returns></returns>
        public static ResultadoTransaccion ObtieneTodosLosMensajes(Opcion opcion) {
            return ObtieneTodosLosMensajes("SP_L_COTIZACION_DIRECTA_COMENTARIOS", opcion.Id32);

        }

        private static ResultadoTransaccion ObtieneTodosLosMensajes(String storeName, Int64 idCotizacionORopcion) {
            var res = new ResultadoTransaccion();
            var comentarios = new List<Comentario>();
            //Abrir Conexion
            var conn = BaseDatos.Conexion();
            try {

                var command = new SqlCommand(storeName, conn);
                command.Parameters.AddWithValue("@idOpcion_o_Cotizacion", idCotizacionORopcion);

                command.CommandType = CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                while (reader.Read()) {
                    comentarios.Add(GetFromDataReader(reader));
                }

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = comentarios;
                res.Descripcion = "Se creo la cotizacion Exitosamente";

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

        private static Comentario GetFromDataReader(SqlDataReader reader) {
            var comentario = new Comentario{
                                               Id = Convert.ToInt16(reader["id"].ToString()),
                                               Id32 = Convert.ToInt16(reader["id"].ToString()),
                                               EsHistorial = Convert.ToBoolean(reader["EsHistorial"].ToString()),
                                               Observacion =  reader["Comentario"].ToString(),
                                               Fecha = Convert.ToDateTime(reader["fecha"].ToString())
                                           };
            comentario.Usuario = Usuarios.clsUsuarioADO.ObtenerTransaccionUsuarioPorId(Convert.ToInt32(reader["idUsuario"])).ObjetoTransaccion as clsUsuario;
                
            return comentario;

        }
    }
}
