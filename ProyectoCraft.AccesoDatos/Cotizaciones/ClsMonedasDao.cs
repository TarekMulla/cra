using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.Entidades.GlobalObject;


namespace ProyectoCraft.AccesoDatos.Cotizaciones {
    public class ClsMonedasDao {
        private const String NombreClase = "ClsMonedasDao";

        public static ResultadoTransaccion ObtieneTodasLasMonedas() {
            ResultadoTransaccion res = new ResultadoTransaccion();
            IList<Moneda> monedas = new List<Moneda>();
            //Abrir Conexion
            var conn = BaseDatos.Conexion();
            try {

                SqlCommand command = new SqlCommand("SP_L_monedas", conn);

                //command.Transaction = conn.BeginTransaction();

                command.CommandType = CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                while (reader.Read()) {
                    monedas.Add(GetFromDataReader(reader));
                }

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = monedas;
                res.Descripcion = "Se Listaron las monedas Exitosamente";

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

        private static Moneda GetFromDataReader(SqlDataReader reader) {
            var m = new Moneda();
            m.Id = Convert.ToInt16(reader["id"]);
            m.Id32 = Convert.ToInt32(reader["id"]);
            m.Codigo = reader["codigo"].ToString();
            m.Nombre = reader["codigo"].ToString();
            m.Activo = Convert.ToBoolean(reader["activo"]);
            return m;
        }
    }

}
