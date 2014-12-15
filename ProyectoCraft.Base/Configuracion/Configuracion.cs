using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;


namespace ProyectoCraft.Base.Configuracion {
    public class Configuracion {
        public static Configuracion Instance() {
            if (_instance == null) {
                lock (typeof(Configuracion)) {
                    if (_instance == null) {
                        _instance = new Configuracion();
                    }
                }
            }
            return _instance;
        }

        protected Configuracion() {
            Configs = new Hashtable();
            var conn = BaseDatos.BaseDatos.NuevaConexion();
            try {
                var command = new SqlCommand("SP_L_configuracion", conn);
                command.CommandType = CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                while (reader.Read())
                    Configs.Add(reader["key"], Convert.ToBoolean(reader["value"]));
                    //Configs.Add(reader["key"], reader["value"].ToString().Equals("1")); //PUA


            } catch (Exception ex) {
                Log.Log.EscribirLog(ex.Message);
            } finally {
                conn.Close();
            }
        }

        public bool? GetValue(string key) {
            if (!Configs.ContainsKey(key))
                return null;

            var value = Configs[key];
            return Convert.ToBoolean(value);
        }

        private Hashtable Configs { set; get; }

        private static volatile Configuracion _instance = null;
    }
}
