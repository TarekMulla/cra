using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.AccesoDatos.PanelDeControl {
    public class ClsPanelDeControlDao {
        public static ResultadoTransaccion ExecuteGenericquery(string query) {
            var resultado = new ResultadoTransaccion();
            try{
            var objReader = SqlHelper.ExecuteDataset(BaseDatos.GetConexion(), CommandType.Text, query);
                resultado.ObjetoTransaccion = objReader.CreateDataReader();
            }catch(Exception e) {
                Console.Write(e.StackTrace);
            }
            return resultado;
        }
        public static ResultadoTransaccion ExecuteGenericqueryDataset(string query) {
            var resultado = new ResultadoTransaccion();
            try {
                var dataset = new DataSet();
                var adapter = new SqlDataAdapter(query, BaseDatos.GetConexion());
                adapter.Fill(dataset);
                resultado.ObjetoTransaccion = dataset;
            } catch (Exception e) {
                Console.Write(e.StackTrace);
            }
            return resultado;
        }
    }
}