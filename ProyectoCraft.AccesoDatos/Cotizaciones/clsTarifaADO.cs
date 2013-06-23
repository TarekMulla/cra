using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.AccesoDatos.Cotizaciones;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Cotizaciones;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Ventas.Pricing;

namespace ProyectoCraft.AccesoDatos.Ventas.pricing
{
    public static class clsTarifaADO
    {
        private static SqlParameter[] objParams = null;
        private static SqlConnection conn = null;
        private static SqlTransaction transaction = null;
        private static SqlDataReader dreader = null;
        public static ResultadoTransaccion ListarTarifas(ClsCotizacion cotizacion)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            IList<ClsTarifa> listItems = new List<ClsTarifa>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Consultar Asuntos x Tipo Actividad
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_L_Cotizacion_Tarifas");

                SqlCommand command = new SqlCommand("SP_L_Cotizacion_Tarifas", conn);

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    var item = new ClsTarifa();
                    item.Id = Convert.ToInt32(dreader["ID"]);
                    item.Id32 = Convert.ToInt32(dreader["ID"]);
                    //item.cotizacion = Convert.ToInt32(dreader["IDCotizacion"]);
                    if (dreader["Fecha"] != null)
                        item.Fecha = Convert.ToDateTime(dreader["Fecha"]);

                    if (dreader["FechaValidezInicio"] != null)
                        item.FechaValidesInicio = Convert.ToDateTime(dreader["FechaValidezInicio"]);

                    if (dreader["FechaValidezFin"] != null)
                        item.FechaValidesFin = Convert.ToDateTime(dreader["FechaValidezFin"]);

                    if (dreader["Agente"] != null)
                        item.Agente = dreader["Agente"].ToString();

                    // if (dreader["ComentarioCotizacion"] != null)
                    //item.ComentarioCotizacion = dreader["ComentarioCotizacion"].ToString();

                    if (dreader["ComentarioInterno"] != null)
                        item.ComentarioInterno = dreader["ComentarioInterno"].ToString();

                    if (dreader["IdEstado"] != null)
                        item.Id32 = Convert.ToInt32(dreader["IdEstado"]);

                    if (dreader["CreateDate"] != null)
                        item.FechaCreacion = Convert.ToDateTime(dreader["CreateDate"]);


                    listItems.Add(item);
                }
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = listItems;
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsTarifaADO";
                res.MetodoError = "ListarTarifas";
            }
            finally
            {
                conn.Close();
            }
            return res;

        }
        public static ResultadoTransaccion GuardarTarifa(ClsCotizacion cot, ClsTarifa tar)
        {
            var res = new ResultadoTransaccion();
            IList<ClsItem> listItems = new List<ClsItem>();
            try
            {

                //Abrir Conexion
                conn = BaseDatos.Conexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_Cotizacion_Tarifas");
                objParams[0].Value = cot.Id;
                objParams[1].Value = tar.Fecha;
                objParams[2].Value = tar.FechaValidesInicio;
                objParams[3].Value = tar.FechaValidesFin;
                objParams[4].Value = tar.Agente;
                objParams[5].Value = tar.Comentario;
                objParams[6].Value = tar.ComentarioInterno;
                objParams[7].Value = (Int32)tar.Estado;
                objParams[8].Value = tar.FechaCreacion;
                objParams[9].Value = tar.Numero;


                var command = new SqlCommand("SP_N_Cotizacion_Tarifas", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;


                var comando = command.ExecuteScalar();
                if (comando != null)
                {
                    var id = Convert.ToInt64(comando);
                    tar.Id = id;
                }
                //guardo Detalle primero
                foreach (var listItem in tar.Detalle)
                {
                    GuardarDetalleTarifa(listItem, conn, tar.Id);//pasarle la conexion, ademas el id.
                }

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.Descripcion = "Se creo la tarifa Exitosamente";
                res.ObjetoTransaccion = listItems;

                //ClsCotizacionADO.ActualizaEstadoCotizacion(cot);
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsTarifaADO";
                res.MetodoError = "GuardarTarifa";
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
        private static void GuardarDetalleTarifa(ClsDetalleTarifa det, SqlConnection conn, long IdTar)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            IList<ClsItem> listItems = new List<ClsItem>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_Cotizacion_DetalleTarifa");


                objParams[0].Value = IdTar;
                objParams[1].Value = det.Item.Id;
                objParams[2].Value = det.Moneda.Id;
                objParams[3].Value = det.Cantidad;
                objParams[4].Value = det.Costo;
                objParams[5].Value = det.Venta;


                SqlCommand command = new SqlCommand("SP_N_Cotizacion_DetalleTarifa", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;

                var id = Convert.ToInt64(command.ExecuteScalar());

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = listItems;


            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsTarifaADO";
                res.MetodoError = "GuardarDetalleTarifa";
            }
            finally
            {
                conn.Close();
            }
            return;
        }
        public static ResultadoTransaccion ActualizaTarifa(ClsCotizacion cot, ClsTarifa tar)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            IList<ClsItem> listItems = new List<ClsItem>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();
                SqlCommand command = new SqlCommand("SP_U_Cotizacion_Tarifas", conn);


                command.Transaction = transaction;
                command.Parameters.AddWithValue("@IDCotizacion", cot.Id);
                command.Parameters.AddWithValue("@Fecha", tar.Fecha);
                command.Parameters.AddWithValue("@FechaValidezInicio", tar.FechaValidesInicio);
                command.Parameters.AddWithValue("@FechaValidezFin", tar.FechaValidesFin);
                command.Parameters.AddWithValue("@Agente", tar.Agente);
                command.Parameters.AddWithValue("@ComentarioCotizacion", tar.Comentario);
                command.Parameters.AddWithValue("@ComentarioInterno", tar.ComentarioInterno);
                command.Parameters.AddWithValue("@IdEstado", tar.Estado);
                command.Parameters.AddWithValue("@CreateDate", tar.FechaCreacion);

                SqlParameter outParam = command.Parameters.Add("@Id", SqlDbType.BigInt);
                outParam.Direction = ParameterDirection.Output;

                command.CommandType = CommandType.StoredProcedure;
                var id = command.ExecuteScalar();

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = listItems;
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsTarifaADO";
                res.MetodoError = "ActualizaTarifa";
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
        public static ResultadoTransaccion ListarItemsTarifas()
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            IList<ClsItem> listItems = new List<ClsItem>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Consultar Asuntos x Tipo Actividad
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_L_Cotizacion_Items");

                SqlCommand command = new SqlCommand("SP_L_Cotizacion_Items", conn);

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    var item = new ClsItem();
                    item.Id = Convert.ToInt32(dreader["ID"]);
                    item.Id32 = Convert.ToInt32(dreader["ID"]);

                    if (dreader["Nombre"] != null)
                        item.Nombre = dreader["Nombre"].ToString();
                    if (dreader["Descripcion"] != null)
                        item.Descripcion = dreader["Descripcion"].ToString();

                    listItems.Add(item);
                }
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = listItems;
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsTarifaADO";
                res.MetodoError = "ListarItemsTarifas";
            }
            finally
            {
                conn.Close();
            }
            return res;

        }
        public static ResultadoTransaccion ListarMonedasTarifas()
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            IList<ClsMonedas> listItems = new List<ClsMonedas>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Consultar Asuntos x Tipo Actividad
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_L_Cotizacion_Monedas");

                SqlCommand command = new SqlCommand("SP_L_Cotizacion_Monedas", conn);

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    var item = new ClsMonedas();
                    item.Id = Convert.ToInt32(dreader["ID"]);
                    item.Id32 = Convert.ToInt32(dreader["ID"]);

                    if (dreader["Nombre"] != null)
                        item.Nombre = dreader["Nombre"].ToString();
                   

                    listItems.Add(item);
                }
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = listItems;
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsTarifaADO";
                res.MetodoError = "ListarMonedasTarifas";
            }
            finally
            {
                conn.Close();
            }
            return res;

        }
    }
}
