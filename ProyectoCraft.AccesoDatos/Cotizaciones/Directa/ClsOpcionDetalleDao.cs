using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.Entidades.GlobalObject;


namespace ProyectoCraft.AccesoDatos.Cotizaciones.Directa {
    public class ClsOpcionDetalleDao {
        private const String NombreClase = "ClsOpcionDetalleDao";
        public static ResultadoTransaccion ObtieneDetalle(Int64 idOpcion) {
            var res = new ResultadoTransaccion();
            var detalles = new List<DetalleOpcion>();
            //Abrir Conexion
            var conn = BaseDatos.NuevaConexion();
            try {
                SqlCommand command = new SqlCommand("SP_L_COTIZACION_DIRECTA_OPCIONES_DETALLES_POR_ID_OPCION", conn);
                command.Parameters.AddWithValue("@idOpcion", idOpcion);
                command.CommandType = CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                while (reader.Read()) {
                   detalles.Add( GetFromDataReader(reader));
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

        private static DetalleOpcion GetFromDataReader(SqlDataReader reader){
            var opcionDetalle = new DetalleOpcion();
            opcionDetalle.Id = Convert.ToInt16(reader["id"]);
            opcionDetalle.Id32 = Convert.ToInt32(reader["id"]);
            opcionDetalle.Cantidad = Convert.ToDecimal(reader["cantidad"]);
            opcionDetalle.Costo = Convert.ToDecimal(reader["costo"]);
            opcionDetalle.Venta = Convert.ToDecimal(reader["venta"]);

            opcionDetalle.Moneda = new Moneda();
            opcionDetalle.Moneda.Id = Convert.ToInt16(reader["COTIZACION_MONEDAS_id"]);
            opcionDetalle.Moneda.Id32 = Convert.ToInt32(reader["COTIZACION_MONEDAS_id"]);
            opcionDetalle.Moneda.Codigo = reader["monedaCodigo"].ToString();
            opcionDetalle.Moneda.Nombre = reader["monedaCodigo"].ToString();

            opcionDetalle.Concepto = new Concepto();
            opcionDetalle.Concepto.Id = Convert.ToInt16(reader["COTIZACION_DIRECTA_CONCEPTO_ID"]);
            opcionDetalle.Concepto.Id32 = Convert.ToInt32(reader["COTIZACION_DIRECTA_CONCEPTO_ID"]);
            opcionDetalle.Concepto.Nombre = reader["conceptoNombre"].ToString();
            opcionDetalle.Concepto.Descripcion = reader["conceptoDEscripcion"].ToString();

            opcionDetalle.Unidad = new Unidad();
            opcionDetalle.Unidad.Id = Convert.ToInt16(reader["COTIZACION_DIRECTA_ITEMS_id"]);
            opcionDetalle.Unidad.Id32 = Convert.ToInt32(reader["COTIZACION_DIRECTA_ITEMS_id"]);
            opcionDetalle.Unidad.Nombre = reader["detalleNombre"].ToString();
            opcionDetalle.Unidad.Descripcion = reader["detalleDescripcion"].ToString();
            return opcionDetalle;
        }
    }
}
