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
                {
                    if (reader["key"].ToString().ToUpper().Contains("_STRING"))
                        Configs.Add(reader["key"], reader["value"].ToString());
                    if (reader["key"].ToString().ToUpper().Contains("_INTEGER"))
                        Configs.Add(reader["key"], Convert.ToInt64(reader["value"]));
                    if ((!reader["key"].ToString().ToUpper().Contains("_INTEGER")) && (!reader["key"].ToString().ToUpper().Contains("_STRING")))
                    {
                        Configs.Add(reader["key"], reader["value"].ToString().Equals("1"));
                    }
                    
                }
                    //Configs.Add(reader["key"], Convert.ToBoolean(reader["value"]));


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

        public string GetValueString(string key)
        {
            if (!Configs.ContainsKey(key))
                return null;

            var value = Configs[key];
            return Convert.ToString(value);
        }
        public Int64 GetValueInteger(string key)
        {
            if (!Configs.ContainsKey(key))
                return 0;

            var value = Configs[key];
            return Convert.ToInt64(value);
        }

        private Hashtable Configs { set; get; }

        private static volatile Configuracion _instance = null;
    }
}
