using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.Entidades.GlobalObject;


namespace ProyectoCraft.AccesoDatos.Cotizaciones.Directa {
    public class ClsGastosLocalesDao {
        private const String NombreClase = "ClsGastosLocalesDao";
        public static ResultadoTransaccion ObtieneGastosLocales(Int32 idCotizacion) {
            var res = new ResultadoTransaccion();
            var gastosLocales = new List<GastoLocal>();
            //Abrir Conexion
            var conn = BaseDatos.NuevaConexion();
            try {
                var command = new SqlCommand("SP_L_COTIZACION_DIRECTA_GASTOS_LOCALES", conn);
                command.Parameters.AddWithValue("@IdCotizacion", idCotizacion);
                command.CommandType = CommandType.StoredProcedure;

                var reader = command.ExecuteReader();
                while (reader.Read()) {
                    var gastoLocal = GetFromDataReader(reader);
                    gastosLocales.Add(gastoLocal);
                }

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = gastosLocales;

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


        public static ResultadoTransaccion Eliminar(CotizacionDirecta cotizacionDirecta, SqlCommand command) {
            try {
                var com = command.Connection.CreateCommand();
                com.Transaction = command.Transaction;

                com.CommandText = "SP_E_COTIZACION_DIRECTA_GASTOS_LOCALES_POR_ID_COTIZACION";

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@IdCotizacion", cotizacionDirecta.Id32);
                com.CommandType = CommandType.StoredProcedure;

                com.ExecuteNonQuery();

                return new ResultadoTransaccion();
            } catch (Exception e) {
                throw e;
            }
        }
        private static GastoLocal GetFromDataReader(SqlDataReader reader) {
            var gastoLocal = new GastoLocal();
            gastoLocal.Id = Convert.ToInt16(reader["id"]);
            gastoLocal.Id32 = Convert.ToInt32(reader["id"]);

            gastoLocal.Descripcion = reader["descripcion"].ToString();
            if (!String.IsNullOrEmpty(reader["monto"].ToString()))
                gastoLocal.Monto = Convert.ToDecimal(reader["monto"]);

            return gastoLocal;

        }

        public static void CrearGastosLocales(CotizacionDirecta cotizacionDirecta, SqlCommand command) {
            try {
                foreach (var o in cotizacionDirecta.GastosLocalesList) {
                    var com = command.Connection.CreateCommand();
                    com.Transaction = command.Transaction;

                    com.CommandText = "SP_N_COTIZACION_DIRECTA_GASTOS_LOCALES";

                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@IdCotizacion", cotizacionDirecta.Id32);
                    com.Parameters.AddWithValue("@descripcion", o.Descripcion);
                    com.Parameters.AddWithValue("@monto", o.Monto);

                    var outParam = com.Parameters.Add("@Id", SqlDbType.BigInt);
                    outParam.Direction = ParameterDirection.Output;
                    com.ExecuteScalar();

                    o.Id = Convert.ToInt16(outParam.Value);
                    o.Id32 = Convert.ToInt32(outParam.Value);
                }
                return;
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
