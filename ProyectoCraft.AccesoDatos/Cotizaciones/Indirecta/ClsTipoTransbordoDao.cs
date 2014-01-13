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
    public class ClsTipoTransbordoDao {

        private const String NombreClase = "ClsTipoTransbordoDao";
        public static ResultadoTransaccion ObtieneTodos() {

            var res = new ResultadoTransaccion();
            var tipoTransbordos = new List<TipoTransbordo>();
            //Abrir Conexion
            var conn = BaseDatos.NuevaConexion();
            try {

                var command = new SqlCommand("SP_L_COTIZACION_TIPOS_TRANSBORDOS", conn);
                command.CommandType = CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                while (reader.Read())
                    tipoTransbordos.Add(GetFromDataReader(reader));
                

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = tipoTransbordos;
                res.Descripcion = "Se Listaron los tipos de Transbordo Exitosamente";

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

        private static TipoTransbordo GetFromDataReader(SqlDataReader reader) {
            var tipo = new TipoTransbordo();
            tipo.Id = Convert.ToInt16(reader["id"]);
            tipo.Id32 = Convert.ToInt32(reader["id"]);
            tipo.Nombre = reader["nombre"].ToString();
            return tipo;
        }
    }
}
