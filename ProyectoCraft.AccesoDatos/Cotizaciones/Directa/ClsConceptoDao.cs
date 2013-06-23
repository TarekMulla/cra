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
    public class ClsConceptoDao {
        private const String NombreClase = "ClsConceptoDao";
        public static ResultadoTransaccion ObtieneTodosLosConceptos() {
            ResultadoTransaccion res = new ResultadoTransaccion();
            List<Concepto> conceptos = new List<Concepto>();
            //Abrir Conexion
            var conn = BaseDatos.Conexion();
            try {

                SqlCommand command = new SqlCommand("SP_L_COTIZACION_DIRECTA_CONCEPTOS", conn);

                //command.Transaction = conn.BeginTransaction();

                command.CommandType = CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                while (reader.Read()) {
                    conceptos.Add(GetFromDataReader(reader));
                }

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = conceptos;
                res.Descripcion = "Se Listaron los conceptos Exitosamente";

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

        private static Concepto GetFromDataReader(SqlDataReader reader){
            var c = new Concepto();
            c.Id = Convert.ToInt16(reader["id"]);
            c.Id32 = Convert.ToInt32(reader["id"]);
            c.Nombre = reader["nombre"].ToString();
            c.Descripcion = reader["descripcion"].ToString();
            c.Activo = Convert.ToBoolean(reader["activo"]);
            return c;
        }
    }
}
