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
    public class ClsTiposServiciosDao {
        private const String NombreClase = "ClsTiposServiciosDAO";
        public static ResultadoTransaccion ObtieneTiposServicios() {
            var res = new ResultadoTransaccion();
            var tipos = new List<TiposServicio>();
            //Abrir Conexion
            var conn = BaseDatos.NuevaConexion();
            try {
                SqlCommand command = new SqlCommand("SP_L_COTIZACION_TIPOS_SERVICIO", conn);
                command.CommandType = CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                while (reader.Read()) {
                    tipos.Add(GetFromDataReader(reader));
                }

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = tipos;
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

        private static TiposServicio GetFromDataReader(SqlDataReader reader) {
            var tipoServicio = new TiposServicio{
                                                    Id = Convert.ToInt16(reader["id"]),
                                                    Id32 = Convert.ToInt32(reader["id"]),
                                                    Nombre = reader["nombre"].ToString(),
                                                    Activo = Convert.ToBoolean(reader["activo"].ToString())
                                                };

            return tipoServicio;
        }

    }
}
