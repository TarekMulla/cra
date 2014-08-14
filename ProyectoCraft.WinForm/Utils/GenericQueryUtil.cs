using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Base.BaseDatos;


namespace SCCMultimodal.Utils {
    public class GenericQueryUtil {
        public static IDataReader ExecuteGenericquery(string query) {
            try {
                var objReader = SqlHelper.ExecuteDataset(BaseDatos.GetConexion(), CommandType.Text, query);
                return objReader.CreateDataReader();
            } catch (Exception e) {
                Console.Write(e.StackTrace);
            }
            return null;
        }

        public static DataSet ExecuteGenericqueryDataset(string query) {
            try {
                var dataset = new DataSet();
                var adapter = new SqlDataAdapter(query, BaseDatos.GetConexion());
                adapter.Fill(dataset);
                return dataset;
            } catch (Exception e) {
                Console.Write(e.StackTrace);
            }
            return null;
        }
            
        public static DataSet ExecuteGenericQueryDataSet(SqlCommand command){
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataSet ds = new DataSet();


            command.Connection = BaseDatos.Conexion();
                da.Fill(ds);
            command.Connection.Close();

            return ds;
        }

    }
}
