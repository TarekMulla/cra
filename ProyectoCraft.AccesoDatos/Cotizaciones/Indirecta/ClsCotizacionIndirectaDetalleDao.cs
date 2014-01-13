using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Cotizaciones.Indirecta;
using ProyectoCraft.Entidades.GlobalObject;


namespace ProyectoCraft.AccesoDatos.Cotizaciones.Indirecta {
    public class ClsCotizacionIndirectaDetalleDao {
        private const String NombreClase = "ClsCotizacionInDirectaDao";

        public static ResultadoTransaccion Crear(CotizacionIndirecta cotizacionIndirecta, SqlCommand command) {
            var num = 1;
            try {
                foreach (var d in cotizacionIndirecta.Detalles) {
                    var com = command.Connection.CreateCommand();
                    com.Transaction = command.Transaction;
                    com.CommandText = "SP_N_COTIZACION_INDIRECTA_DETALLES";

                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@COTIZACION_INDIRECTA_ITEMS_id", d.Item.Id32);
                    com.Parameters.AddWithValue("@cantidad", d.Cantidad);
                    com.Parameters.AddWithValue("@COTIZACION_SOLICITUD_COTIZACIONES_id", cotizacionIndirecta.Id32);
                    com.CommandType = CommandType.StoredProcedure;

                    var outParam = com.Parameters.Add("@Id", SqlDbType.BigInt);
                    outParam.Direction = ParameterDirection.Output;
                    com.ExecuteScalar();

                    d.Id = Convert.ToInt16(outParam.Value);
                    d.Id32 = Convert.ToInt32(outParam.Value);
                    num++;
                }
                return new ResultadoTransaccion();
            } catch (Exception e) {
                throw e;
            }
        }

        public static ResultadoTransaccion ObtieneDetalles(CotizacionIndirecta cotizacionIndirecta){
            var detalles = new List<CotizacionIndirectaDetalle>();
            var res = new ResultadoTransaccion();
            var conn = BaseDatos.NuevaConexion();
            try {
                
                var com = conn.CreateCommand();
                com.CommandText = "SP_L_COTIZACION_INDIRECTA_DETALLES_POR_ID_SOLICITUD";

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", cotizacionIndirecta.Id32);

                var reader = com.ExecuteReader();
                while (reader.Read()) {
                    CotizacionIndirectaDetalle detalle = GetFromDataReader(reader);
                    detalles.Add(detalle);
                }
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = detalles;
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

        private static CotizacionIndirectaDetalle GetFromDataReader(SqlDataReader reader){
            var detalle = new CotizacionIndirectaDetalle();
            detalle.Id = detalle.Id32 = Convert.ToInt32(reader["det_id"]);
            detalle.Cantidad = Convert.ToDecimal(reader["det_cantidad"]);
            detalle.Item = new CotizacionIndirectaItem();
            detalle.Item.Id = detalle.Item.Id32 = Convert.ToInt32(reader["item_id"]);
            detalle.Item.Nombre = reader["item_nombre"].ToString();
            detalle.Item.Descripcion = reader["item_descripcion"].ToString();
            detalle.Item.Activo = Convert.ToBoolean(reader["item_activo"].ToString());

            return detalle;
        }
    }
}
