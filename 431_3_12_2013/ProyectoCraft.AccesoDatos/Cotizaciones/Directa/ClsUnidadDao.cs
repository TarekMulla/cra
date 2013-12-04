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
    public class ClsUnidadDao {
        private const String NombreClase = "ClsUnidadDao";
        public static ResultadoTransaccion ObtieneTodasLasUnidades() {
            var res = new ResultadoTransaccion();
            var Unidades = new List<Unidad>();
            //Abrir Conexion
            var conn = BaseDatos.NuevaConexion();
            try {

                SqlCommand command = new SqlCommand("SP_L_COTIZACION_DIRECTA_ITEMS", conn)
                                     {CommandType = CommandType.StoredProcedure};

                //command.Transaction = conn.BeginTransaction();

                var reader = command.ExecuteReader();
                while (reader.Read()) {
                    Unidades.Add(GetFromDataReader(reader));
                }

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = Unidades;
                res.Descripcion = "Se Listaron las unidades Exitosamente";

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
        private static Unidad GetFromDataReader(SqlDataReader reader) {
            var c = new Unidad();
            c.Id = Convert.ToInt16(reader["id"]);
            c.Id32 = Convert.ToInt32(reader["id"]);
            c.Nombre = reader["nombre"].ToString();
            c.Descripcion = reader["descripcion"].ToString();
            c.Activo = Convert.ToBoolean(reader["activo"]);
            return c;
        }
    }
}
