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


namespace ProyectoCraft.AccesoDatos.Cotizaciones.Directa {
    public class ClsPuertoDao {
        private const String NombreClase = "ClsPuertoDao";
        public static ResultadoTransaccion ObtienePuertos(Opcion opcion) {
            var res = new ResultadoTransaccion();
            var puerto = new List<Puerto>();
            //Abrir Conexion
            var conn = BaseDatos.NuevaConexion();
            try {
                SqlCommand command = new SqlCommand("SP_L_COTIZACION_DIRECTA_OPCIONES_PUERTOS_POR_ID_OPCION", conn);
                command.Parameters.AddWithValue("@idOpcion", opcion.Id32);
                command.CommandType = CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                while (reader.Read()) {
                    GetFromDataReader(reader, opcion);
                }

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = puerto;
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

        private static void GetFromDataReader(SqlDataReader reader, Opcion opcion) {
            var puerto = new Puerto();
            puerto.Id = Convert.ToInt16(reader["id"]);
            puerto.Id32 = Convert.ToInt32(reader["id"]);
            puerto.Codigo = reader["puerto"].ToString();
            puerto.Nombre = reader["nombre"].ToString();

            if (reader["tipo"].ToString() == "Pol")
                opcion.Pol.Add(puerto);
            else
                opcion.Pod.Add(puerto);

        }
    }
}
