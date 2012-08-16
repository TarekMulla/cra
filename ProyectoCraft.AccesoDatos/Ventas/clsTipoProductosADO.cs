using System;
using System.Collections.Generic;
using ProyectoCraft.Entidades.Ventas.Productos;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Base.BaseDatos;
using System.Data.SqlClient;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Base.Log;
using System.Data;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Ventas.Traficos;

namespace ProyectoCraft.AccesoDatos.Ventas
{
    public static class clsTipoProductosADO
    {
        private static SqlParameter[] objParams = null;
        private static SqlConnection conn = null;
        private static SqlTransaction transaction = null;
        private static SqlDataReader dreader = null;

        public static  clsTipoProducto ObtieneDesdeDataReader(IDataReader dreader) {
            var objTipoProducto = new clsTipoProducto();
            objTipoProducto.Id = Convert.ToInt16(dreader[0]); ;
            objTipoProducto.Nombre = dreader[1].ToString();
            objTipoProducto.ExpoImpo = dreader[2].ToString();
            objTipoProducto.Activo = dreader[3].ToString();
            return objTipoProducto;
        }

        public static ResultadoTransaccion ListarTiposProductosAdo(string ExpoImpo, string Activo)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            IList<clsTipoProducto> ListaTiposProducto = new List<clsTipoProducto>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Consultar Asuntos x Tipo Actividad
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "sp_c_ventas_tipos_producto");
                objParams[0].Value = ExpoImpo;
                objParams[1].Value = Activo;

                SqlCommand command = new SqlCommand("sp_c_ventas_tipos_producto", conn);

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    ListaTiposProducto.Add(ObtieneDesdeDataReader(dreader));
                }
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = ListaTiposProducto;
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsTipoProductoAdo.cs";
                res.MetodoError = "Listar Tipos Producto";
            }
            finally
            {
                conn.Close();
            }
            return res;
        }

        public static ResultadoTransaccion ListarTiposProductosPorIdSalesLead(Int64 idSalesLead) {
            ResultadoTransaccion res = new ResultadoTransaccion();
            IList<clsTipoProducto> ListaTiposProducto = new List<clsTipoProducto>();
            try {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_VENTAS_TIPOS_PRODUCTO_POR_SLEAD");
                objParams[0].Value = idSalesLead;

                SqlCommand command = new SqlCommand("SP_C_VENTAS_TIPOS_PRODUCTO_POR_SLEAD", conn);

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read()) {
                    ListaTiposProducto.Add(ObtieneDesdeDataReader(dreader));
                }
                res.Accion = Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = ListaTiposProducto;
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsTipoProductoAdo.cs";
                res.MetodoError = "ListarTiposProductosPorIdSalesLead";
            } finally {
                conn.Close();
            }
            return res;
        }

        


        public static ResultadoTransaccion ListarTiposTraficos()
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            IList<Entidades.Ventas.Traficos.clsTrafico> ListaTiposTrafico = new List<clsTrafico>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Consultar Asuntos x Tipo Actividad
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_VENTAS_TIPO_TRAFICO");


                SqlCommand command = new SqlCommand("SP_C_VENTAS_TIPO_TRAFICO", conn);

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    clsTrafico ObjTipoTrafico = new clsTrafico();
                    ObjTipoTrafico.Id = Convert.ToInt16(dreader["Id"]); ;
                    ObjTipoTrafico.Nombre = dreader["Descripcion"].ToString();
                    
                    ListaTiposTrafico.Add(ObjTipoTrafico);
                }
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.ObjetoTransaccion = ListaTiposTrafico;
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;                
            }
            finally
            {
                conn.Close();
            }
            return res;
        }

        public static ResultadoTransaccion CrearNuevoTrafico(clsTrafico trafico, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            Int64 idTrafico = 0;
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_VENTAS_TIPOS_TRAFICO");
                objParams[0].Value = trafico.Nombre;
                objParams[1].Value = trafico.VigenciaDesde;
                objParams[2].Value = trafico.VigenciaHasta;
                SqlCommand command4 = new SqlCommand("SP_N_VENTAS_TIPOS_TRAFICO", conn);
                command4.Transaction = transaction;
                command4.Parameters.AddRange(objParams);
                command4.CommandType = CommandType.StoredProcedure;
                idTrafico = Convert.ToInt64(command4.ExecuteScalar());

                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.ObjetoTransaccion = idTrafico;

            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }

    }
}
