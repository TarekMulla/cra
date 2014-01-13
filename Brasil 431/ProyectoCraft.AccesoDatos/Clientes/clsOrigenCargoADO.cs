using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Clientes.Target;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.AccesoDatos.Clientes
{
    public  static class clsOrigenCargoADO
    {
        private static SqlParameter[] objParams = null;
        private static SqlConnection conn = null;
        private static SqlTransaction transaction = null;
        private static SqlDataReader dreader = null;
        private static ResultadoTransaccion resTransaccion = null;

        public static IList<clsOrigenCarga> ListarEmpresasCompetencia(string nombre)
        {
            IList<clsOrigenCarga> listaempresas = new List<clsOrigenCarga>();

            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_CLIENTES_TARGET_ORIGEN_CARGA");
                objParams[0].Value = nombre;

                SqlCommand command = new SqlCommand("SP_C_CLIENTES_TARGET_ORIGEN_CARGA", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    clsOrigenCarga empresa = new clsOrigenCarga();
                    empresa.Id = Convert.ToInt64(dreader[0]);
                    empresa.Nombre = dreader[1].ToString();
                    empresa.FechaCreacion = (DateTime)dreader[2];

                    listaempresas.Add(empresa);
                }
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return listaempresas;

        }

        public static clsOrigenCarga BuscarOrigenCargaPorId(Int64 IdOrigen)
        {
            clsOrigenCarga TipoOrigen = new clsOrigenCarga();

            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_TARGET_BUSCAR_ORIGEN_CARGA_POR_ID");
                objParams[0].Value = IdOrigen;

                //SqlCommand command = new SqlCommand("SP_C_TARGET_BUSCAR_ORIGEN_CARGA_POR_ID", conn);
                //command.Parameters.AddRange(objParams);
                //command.CommandType = CommandType.StoredProcedure;
                //dreader = command.ExecuteReader();
                DataSet ds = SqlHelper.ExecuteDataset(conn, "SP_C_TARGET_BUSCAR_ORIGEN_CARGA_POR_ID", objParams);
                if(ds != null)
                {
                    TipoOrigen = new clsOrigenCarga();
                    TipoOrigen.Id =Convert.ToInt64(ds.Tables[0].Rows[0]["Id"]);
                    TipoOrigen.Nombre = ds.Tables[0].Rows[0]["Descripcion"].ToString();
                    TipoOrigen.FechaCreacion = (DateTime)ds.Tables[0].Rows[0]["FechaCreacion"];
                }


                //while (dreader.Read())
                //{
                //    TipoOrigen = new clsOrigenCarga();
                //    TipoOrigen.Id = Convert.ToInt64(dreader[0]);
                //    TipoOrigen.Nombre = dreader[1].ToString();
                //    TipoOrigen.FechaCreacion = (DateTime)dreader[2];                    
                //}
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }

            return TipoOrigen;

        }

    }
}
