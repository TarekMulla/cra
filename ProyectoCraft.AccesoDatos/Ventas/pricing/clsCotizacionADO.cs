using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.AccesoDatos.Usuarios;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.Entidades.Ventas.Pricing;


namespace ProyectoCraft.AccesoDatos.Ventas.pricing
{
    public static class ClsCotizacionADO
    {

        private static SqlParameter[] objParams = null;
        private static SqlConnection conn = null;
        private static SqlTransaction transaction = null;
        private static SqlDataReader dreader = null;


        public static ResultadoTransaccion ListarTodosLosItems()
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            IList<ClsItem> listItems = new List<ClsItem>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Consultar Asuntos x Tipo Actividad
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_Cotizacion_Items");

                SqlCommand command = new SqlCommand("SP_C_Cotizacion_Items", conn);

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    var item = new ClsItem();
                    item.Id = Convert.ToInt32(dreader["id"]);
                    item.Id32 = Convert.ToInt32(dreader["id"]);
                    item.Nombre = dreader["nombre"].ToString();
                    item.Descripcion = dreader["descripcion"].ToString();
                    listItems.Add(item);
                }
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = listItems;
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "ClsCotizacionADO";
                res.MetodoError = "ListarTodosLosItems";
            }
            finally
            {
                conn.Close();
            }
            return res;

        }

        public static ResultadoTransaccion GuardarCotizacion(ClsSolicitudCotizacionIndirecta solicitudCotizacionIndirecta)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            IList<ClsItem> listItems = new List<ClsItem>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();
                SqlCommand command = new SqlCommand("SP_N_Cotizacion_Cotizaciones", conn);

                command.Transaction = transaction;
                command.Parameters.AddWithValue("@idCliente", solicitudCotizacionIndirecta.Cliente.Id32);
                command.Parameters.AddWithValue("@IdUsuario", solicitudCotizacionIndirecta.Usuario.Id32);
                command.Parameters.AddWithValue("@IdTipoCotizacin", solicitudCotizacionIndirecta.Tipo);
                command.Parameters.AddWithValue("@FechaSolicitud", solicitudCotizacionIndirecta.FechaSolicitud);
                command.Parameters.AddWithValue("@IdIncoterm", solicitudCotizacionIndirecta.IncoTerm.Id32);
                command.Parameters.AddWithValue("@PuertoEmbarque", solicitudCotizacionIndirecta.PuertoEmbarque);
                command.Parameters.AddWithValue("@POL", solicitudCotizacionIndirecta.POL);
                command.Parameters.AddWithValue("@POD", solicitudCotizacionIndirecta.POD);
                command.Parameters.AddWithValue("@NavieraReferencia", solicitudCotizacionIndirecta.NavieraReferencia);
                command.Parameters.AddWithValue("@TarifaReferencia", solicitudCotizacionIndirecta.TarifaReferencia);
                command.Parameters.AddWithValue("@Mercaderia", solicitudCotizacionIndirecta.Mercaderia);
                command.Parameters.AddWithValue("@GastosLocales", solicitudCotizacionIndirecta.GastosLocales);
                command.Parameters.AddWithValue("@ProveedorCarga", solicitudCotizacionIndirecta.ProveedorCarga);
                command.Parameters.AddWithValue("@Credito", String.Empty);
                command.Parameters.AddWithValue("@Comentario", solicitudCotizacionIndirecta.Comentario);
                command.Parameters.AddWithValue("@NombreCliente", solicitudCotizacionIndirecta.Cliente.NombreCliente);
                if (solicitudCotizacionIndirecta.UsuarioAsignadoPricing != null)
                    command.Parameters.AddWithValue("@idUsuarioPricingAsignado", solicitudCotizacionIndirecta.UsuarioAsignadoPricing.Id32);

                SqlParameter outParam = command.Parameters.Add("@Id", SqlDbType.BigInt);
                outParam.Direction = ParameterDirection.Output;

                command.CommandType = CommandType.StoredProcedure;
                var id = command.ExecuteScalar();

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = listItems;
                res.Descripcion = "Se creo la solicitudCotizacionIndirecta Exitosamente";

            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "ClsCotizacionADO";
                res.MetodoError = "ListarTodosLosItems";
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
        private static void CargaIncoterm(clsIncoTerm item)
        {
            try{
                item.Id = Convert.ToInt32(dreader["IdIncoterms"]);
                item.Descripcion = dreader["TI_Descripcion"].ToString();
                item.Estado = Convert.ToBoolean(dreader["TI_Estado"]);
                item.Codigo = dreader["TI_Codigo"].ToString();
            }catch(Exception e){
                Console.Write(e.InnerException);
            }
        }

        private static void CargaCotizacion(ClsSolicitudCotizacion item)
        {
            item.Id = Convert.ToInt32(dreader["id"]);
            item.Id32 = Convert.ToInt32(dreader["id"]);
            item.Cliente = new clsClienteMaster(true);//dreader["idCliente"].ToString();

            if (dreader["NombreCliente"] != null)
                item.Cliente.NombreCompañia = dreader["NombreCliente"].ToString();
            item.Usuario = Base.Usuario.UsuarioConectado.Usuario;//,
            if (dreader["IdUsuario"] != null)
            {
                var usr = clsUsuarioADO.ObtenerUsuarioPorId(Convert.ToInt32(dreader["IdUsuario"]));
                item.Usuario = usr;
            }
            if (!string.IsNullOrEmpty(dreader["NombreCliente"].ToString()))
                item.Cliente.NombreCompañia = dreader["NombreCliente"].ToString();

            if (!string.IsNullOrEmpty(dreader["cc_IdEstado"].ToString()))
                item.Estado = (ClsEstado.Estado)Convert.ToInt32(dreader["cc_IdEstado"]);


            if (dreader["FechaSolicitud"] != null && !Equals(dreader["FechaSolicitud"], ""))
                item.FechaSolicitud = Convert.ToDateTime(dreader["FechaSolicitud"]);

            try{
                if (dreader["IdIncoterms"] != null){
                    item.IncoTerm = new clsIncoTerm();
                    item.IncoTerm.Id = Convert.ToInt32(dreader["IdIncoterms"]);
                }
            }catch(Exception e){
                Console.Write(e.InnerException);
            }


            if (dreader["PuertoEmbarque"] != null)
                item.PuertoEmbarque = dreader["PuertoEmbarque"].ToString();

            if (dreader["POL"] != null)
                item.POL = dreader["POL"].ToString();
            if (dreader["POD"] != null)
                item.POD = dreader["POD"].ToString();

            if (dreader["NavieraReferencia"] != null)
                item.NavieraReferencia = dreader["NavieraReferencia"].ToString();

            if (dreader["TarifaReferencia"] != null)
                item.TarifaReferencia = dreader["TarifaReferencia"].ToString();

            if (dreader["Mercaderia"] != null)
                item.Mercaderia = dreader["Mercaderia"].ToString();

            if (dreader["GastosLocales"] != null)
                item.GastosLocales = dreader["GastosLocales"].ToString();

            if (dreader["ProveedorCarga"] != null)
                item.ProveedorCarga = dreader["ProveedorCarga"].ToString();
            return;
        }
        private static void CargaTarifa(ClsSolicitudCotizacionDirectaOpciones tarifa)
        {
            tarifa.Id = Convert.ToInt32(dreader["ctar_ID"]);
            tarifa.Id32 = Convert.ToInt32(dreader["ctar_ID"]);
            tarifa.Fecha = Convert.ToDateTime(dreader["Fecha"]);
            tarifa.FechaValidezInicio = Convert.ToDateTime(dreader["FechaValidezInicio"]);
            tarifa.FechaValidezFin = Convert.ToDateTime(dreader["FechaValidezFin"]);
            tarifa.Estado = (ClsEstado.Estado)Convert.ToInt32(dreader["Ctar_IdEstado"]);


            if (dreader["Agente"] != null)
                tarifa.Agente = dreader["Agente"].ToString();

            /*  if (dreader["ComentarioCotizacion"] != null)
                  tarifa.Comentario = dreader["ComentarioCotizacion"].ToString();
  */
            if (dreader["ComentarioInterno"] != null)
                tarifa.ComentarioInterno = dreader["ComentarioInterno"].ToString();

        }

        private static void CargaDetalle(ClsDetalleTarifa det)
        {
            if (dreader["cdet_id"] != null)
                det.Id = Convert.ToInt32(dreader["cdet_id"]);

            if (dreader["Cantidad"] != null)
                det.Cantidad = Convert.ToDecimal(dreader["Cantidad"]);

            if (dreader["Costo"] != null)
                det.Costo = Convert.ToDecimal(dreader["Costo"]);

            if (dreader["Venta"] != null)
                det.Venta = Convert.ToDecimal(dreader["Venta"]);

            if (dreader["cmon_id"] != null)
                det.Moneda.Id = Convert.ToInt32(dreader["cmon_id"]);

            if (dreader["cmon_nombre"] != null)
                det.Moneda.Nombre = dreader["cmon_nombre"].ToString();

            if (dreader["cit_id"] != null)
                det.Item.Id = Convert.ToInt32(dreader["cit_id"]);

            if (dreader["cit_nombre"] != null)
                det.Item.Nombre = dreader["cit_nombre"].ToString();

            if (dreader["cit_descripcion"] != null)
                det.Item.Descripcion = dreader["cit_descripcion"].ToString();

        }

        public static ResultadoTransaccion ActualizaEstadoCotizacion(ClsSolicitudCotizacionIndirecta cot)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            IList<ClsItem> listItems = new List<ClsItem>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();
                SqlCommand command = new SqlCommand("SP_U_Cotizacion_Cotizaciones_Estado", conn);


                command.Transaction = transaction;
                command.Parameters.AddWithValue("@ID", cot.Id);
                command.Parameters.AddWithValue("@IdEstado", cot.Estado);

                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteScalar();


                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Actualizar;
                res.Descripcion = "Se ha actualizado el estado de la solicitud.";
                res.ObjetoTransaccion = listItems;
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "ClsCotizacionADO";
                res.MetodoError = "ActualizaEstadoCotizacion";
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
        public static ResultadoTransaccion ListarTodosLasCotizaciones()
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            //IList<ClsItem> listItems = new List<ClsItem>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Consultar Asuntos x Tipo Actividad
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_L_Cotizacion_Cotizaciones");

                SqlCommand command = new SqlCommand("SP_L_Cotizacion_Cotizaciones", conn);

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();


                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = GetFromDataReader(dreader);
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "ClsCotizacionADO";
                res.MetodoError = "SP_L_Cotizacion_Cotizaciones";
            }
            finally
            {
                conn.Close();
            }
            return res;

        }

        private static List<ClsSolicitudCotizacionDirecta> GetFromDataReader(SqlDataReader dreader)
        {
            var list = new List<ClsSolicitudCotizacionDirecta>();
            Int32 idAnteriorCot = 0;
            Int32 idAnteriorTar = 0;
            Int32 idAnteriorDet = 0;

            while (dreader.Read())
            {
                if (dreader["id"] != null && Convert.ToInt32(dreader["id"]) != idAnteriorCot)//valido para que cargue 1 vez la cabecera
                {
                    var item = new ClsSolicitudCotizacionDirecta();

                    item.IncoTerm = new clsIncoTerm();


                    CargaCotizacion(item);
                    CargaIncoterm(item.IncoTerm);

                    idAnteriorCot = item.Id32;
                    list.Add(item);
                }

                //Cargo Tarifas
                if (!String.IsNullOrEmpty(dreader["ctar_ID"].ToString()) && Convert.ToInt32(dreader["ctar_ID"]) != idAnteriorTar)
                {
                    var tarifa = new ClsSolicitudCotizacionDirectaOpciones();
                    CargaTarifa(tarifa);

                    idAnteriorTar = tarifa.Id32;
                    //list[list.Count - 1].Tarifas.Add(tarifa);//agrego la nueva tarifa al ultimo elemento de la lista.
                    list[list.Count - 1].AddOpcion(tarifa);
                }
            }
            return list;
        }

        public static ResultadoTransaccion ListarTodosLasCotizacionesPorUsuario(Int64 usuario)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();


            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Consultar Asuntos x Tipo Actividad
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_L_Cotizacion_Cotizaciones");

                SqlCommand command = new SqlCommand("SP_L_Cotizacion_Cotizaciones", conn);

                command.Transaction = transaction;
                objParams[0].Value = usuario;
                //objParams[1].Value = ClsTipoCotizacion.Tipo.SolicitudDeTarifa;//IdTipoCotizacin
                command.Parameters.AddRange(objParams);

                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = GetFromDataReader(dreader);
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "ClsCotizacionADO";
                res.MetodoError = "SP_L_Cotizacion_Cotizaciones";
            }
            finally
            {
                conn.Close();
            }
            return res;

        }

        public static ResultadoTransaccion ListarTodosLasCotizacionesMiscotizaciones(clsUsuario usuario)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();
                SqlCommand command = new SqlCommand("SP_L_Cotizacion_Cotizaciones_Mis_cotizaciones", conn);

                command.Transaction = transaction;
                command.Parameters.AddWithValue("@idUsuario", usuario.Id32);


                command.Transaction = transaction;
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();


                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = GetFromDataReader(dreader);
                return res;
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "ClsCotizacionADO";
                res.MetodoError = "ListarTodosLasCotizacionesMiscotizaciones";
            }
            finally
            {
                conn.Close();

            }
            return res;
        }

        public static ResultadoTransaccion GuardarOpcionesSolicitudDeCotizacionDirecta(ClsSolicitudCotizacionDirecta solicitudCotizacionDirecta, SqlConnection conn, SqlTransaction transaction)
        {

            foreach (var opcion in solicitudCotizacionDirecta.OpcionesDirecta)
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("SP_N_COTIZACION_DIRECTA_OPCIONES", conn);
                    cmd.Transaction = transaction;
                    cmd.Parameters.AddWithValue("@COTIZACION_SOLICITUD_COTIZACIONES_id", solicitudCotizacionDirecta.Id);
                    cmd.Parameters.AddWithValue("@FechaValidezInicio", opcion.FechaValidezInicio);
                    cmd.Parameters.AddWithValue("@FechaValidezFin", opcion.FechaValidezFin);
                    cmd.Parameters.AddWithValue("@naviera", opcion.Naviera);
                    cmd.Parameters.AddWithValue("@COTIZACION_INDIRECTA_ESTADOS_id ", ClsEstado.Estado.Ingresado);
                    var index = solicitudCotizacionDirecta.Opciones.IndexOf(opcion) + 1;
                    if (String.IsNullOrEmpty(opcion.Numero))
                        opcion.Numero = string.Format("{0:d4}-{1:d3}", solicitudCotizacionDirecta.Id32, index);
                    cmd.Parameters.AddWithValue("@numero ", opcion.Numero);
                    cmd.Parameters.AddWithValue("@idUsuario ", solicitudCotizacionDirecta.Usuario.Id32);
                    cmd.Parameters.AddWithValue("@fechaIngreso", DateTime.Now);



                    cmd.CommandType = CommandType.StoredProcedure;


                    SqlParameter outParam = cmd.Parameters.Add("@Id", SqlDbType.BigInt);
                    outParam.Direction = ParameterDirection.Output;


                    cmd.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return new ResultadoTransaccion();
        }


        public static ResultadoTransaccion GuardarSolicitudDeCotizacion(ClsSolicitudCotizacionDirecta solicitudCotizacionDirecta)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            IList<ClsItem> listItems = new List<ClsItem>();
            conn = BaseDatos.Conexion();
            SqlCommand command = new SqlCommand("SP_N_COTIZACION_SOLICITUD_COTIZACIONES", conn);

            try
            {
                //Abrir Conexion

                command.Transaction = conn.BeginTransaction();
                command.Parameters.AddWithValue("@idCliente", solicitudCotizacionDirecta.Cliente.Id32);
                command.Parameters.AddWithValue("@IdUsuario", solicitudCotizacionDirecta.Usuario.Id32);
                command.Parameters.AddWithValue("@COTIZACION_TIPOS_id", solicitudCotizacionDirecta.Tipo);
                command.Parameters.AddWithValue("@FechaSolicitud", solicitudCotizacionDirecta.FechaSolicitud);
                command.Parameters.AddWithValue("@idIncoterms", solicitudCotizacionDirecta.IncoTerm.Id32);
                command.Parameters.AddWithValue("@PuertoEmbarque", solicitudCotizacionDirecta.PuertoEmbarque);
                command.Parameters.AddWithValue("@POL", solicitudCotizacionDirecta.POL);
                command.Parameters.AddWithValue("@POD", solicitudCotizacionDirecta.POD);
                command.Parameters.AddWithValue("@NavieraReferencia", solicitudCotizacionDirecta.NavieraReferencia);
                command.Parameters.AddWithValue("@TarifaReferencia", solicitudCotizacionDirecta.TarifaReferencia);
                command.Parameters.AddWithValue("@Mercaderia", solicitudCotizacionDirecta.Mercaderia);
                command.Parameters.AddWithValue("@GastosLocales", solicitudCotizacionDirecta.GastosLocales);
                command.Parameters.AddWithValue("@ProveedorCarga", solicitudCotizacionDirecta.ProveedorCarga);
                command.Parameters.AddWithValue("@Credito", String.Empty);
                command.Parameters.AddWithValue("@Comentario", solicitudCotizacionDirecta.Comentario);
                command.Parameters.AddWithValue("@NombreCliente", solicitudCotizacionDirecta.Cliente.NombreCliente);
                command.Parameters.AddWithValue("@conAgenciamento", false);
                command.Parameters.AddWithValue("@COTIZACION_ESTADOS_id", (Int32)solicitudCotizacionDirecta.Estado);

                SqlParameter outParam = command.Parameters.Add("@Id", SqlDbType.BigInt);
                outParam.Direction = ParameterDirection.Output;

                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                solicitudCotizacionDirecta.Id = (Int64)outParam.Value;
                solicitudCotizacionDirecta.Id32 = Convert.ToInt32(outParam.Value);
                GuardarOpcionesSolicitudDeCotizacionDirecta(solicitudCotizacionDirecta, conn, command.Transaction);
                command.Transaction.Commit();
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Insertar;
                res.ObjetoTransaccion = listItems;
                res.Descripcion = "Se creo la Solicitud Exitosamente";

            }
            catch (Exception ex)
            {
                command.Transaction.Rollback();
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "ClsCotizacionADO";
                res.MetodoError = "ListarTodosLosItems";
            }
            finally
            {
                conn.Close();
            }
            return res;
        }

        public static ResultadoTransaccion ListarCotizacionDirectaITems()
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            IList<ClsItem> listItems = new List<ClsItem>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Consultar Asuntos x Tipo Actividad
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_COTIZACION_DIRECTA_ITEMS");

                SqlCommand command = new SqlCommand("SP_C_COTIZACION_DIRECTA_ITEMS", conn);

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    var item = new ClsItem();
                    item.Id = Convert.ToInt32(dreader["id"]);
                    item.Id32 = Convert.ToInt32(dreader["id"]);
                    item.Nombre = dreader["nombre"].ToString();
                    item.Descripcion = dreader["descripcion"].ToString();
                    listItems.Add(item);
                }
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = listItems;
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "ClsCotizacionADO";
                res.MetodoError = "ListarCotizacionDirectaITems";
            }
            finally
            {
                conn.Close();
            }
            return res;

        }
    }
}
