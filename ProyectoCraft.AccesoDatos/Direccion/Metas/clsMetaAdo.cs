using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoCraft.AccesoDatos.Clientes;
using ProyectoCraft.Entidades.Direccion.Metas;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Ventas.Productos;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Base.BaseDatos;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Enums;

namespace ProyectoCraft.AccesoDatos.Direccion.Metas
 {
    public static class clsMetaAdo
    {
        private static SqlParameter[] objParams = null;
        private static SqlConnection conn = null;
        private static SqlTransaction transaction = null;
        private static SqlDataReader dreader = null;

        public static ResultadoTransaccion ListarProspectoUsuarioEstado(long IdVendedor, string Estados)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            IList<clsMeta> Prospectos = new List<clsMeta>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_DIRECCION_METAS_VENDEDOR");

                SqlCommand command = new SqlCommand("SP_C_DIRECCION_METAS_VENDEDOR", conn);
                objParams[0].Value = IdVendedor;
                objParams[1].Value = Estados;

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    clsMeta ObjProspecto = new clsMeta();

                    ObjProspecto.IdNumMeta = dreader[1].ToString().Trim();
                    ObjProspecto.Id = Convert.ToInt32(dreader[0]);
                    ObjProspecto.Prioridad = new clsItemParametro();
                    ObjProspecto.Prioridad.Codigo =  dreader[2].ToString();
                    //ObjProspecto.Prioridad.Nombre = dreader[3].ToString();
                    ObjProspecto.TipoOportunidad = dreader[3].ToString().Trim();
                    ObjProspecto.GlosaClienteTarget = dreader[4].ToString().Trim();
                    ObjProspecto.ObjClienteMaster = new clsClienteMaster(true);
                    ObjProspecto.ObjClienteMaster.Id = Convert.ToInt32(dreader[5]);
                    ObjProspecto.ObjClienteMaster.NombreFantasia = dreader[6].ToString().Trim();
                    ObjProspecto.ObjMetaAsignacion = new clsMetaAsignacion();
                    ObjProspecto.ObjMetaAsignacion.ObjVendedorAsignado = new clsUsuario();
                    ObjProspecto.ObjMetaAsignacion.ObjVendedorAsignado.Id = Convert.ToInt32(dreader[7]);
                    ObjProspecto.ObjMetaAsignacion.ObjVendedorAsignado.NombreUsuario = dreader[8].ToString().Trim();
                    ObjProspecto.ObjMetaAsignacion.ObjVendedorAsignado.Email = dreader[9].ToString().Trim();
                    ObjProspecto.EstadoMeta = (Enums.EstadosMetas)Convert.ToInt16(dreader[10]);
                    ObjProspecto.FechaApertura = Convert.ToDateTime(dreader[11]);
                    //ObjProspecto.FechaRevision = Convert.ToDateTime(dreader[12]);
                    ObjProspecto.FechaUltActulizacion = Convert.ToDateTime(dreader[13]);
                    ObjProspecto.IdTipoActualizacion = Convert.ToInt32(dreader[14]);
                    ObjProspecto.FechaHoy = Convert.ToDateTime(dreader[15]);
                    ObjProspecto.UsuarioAsignador = new clsUsuario();
                    ObjProspecto.UsuarioAsignador.Id = Convert.ToInt32(dreader[16]);
                    ObjProspecto.UsuarioAsignador.Email = dreader[17].ToString().Trim();
                    ObjProspecto.UsuarioAsignador.Nombre = dreader[18].ToString().Trim();

                    ObjProspecto.FollowUps =clsClienteMasterADO.ObtenerFollowUpActivosClientePorTarget(ObjProspecto.Id32);

                    Prospectos.Add(ObjProspecto);
                }
                
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = Prospectos;
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsMetaAdo.cs";
                res.MetodoError = "ListarProspectos";
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
        public static DataTable PreparaGraficaEstadoVendedor(string Estados, long IdUsuario, DateTime FechaDesde, DateTime FechaHasta)
        {
            DataTable Grafica = new DataTable("Grafico");
            try
            {
                string Estado;
                string Vendedor;
                Int32 Value;

                //Abrir Conexion
                conn = BaseDatos.Conexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_DIRECCION_METAS_GRAFICO_ESTADO_VENDEDOR");

                SqlCommand command = new SqlCommand("SP_C_DIRECCION_METAS_GRAFICO_ESTADO_VENDEDOR", conn);
                objParams[0].Value = Estados;
                objParams[1].Value = FechaDesde;
                objParams[2].Value = FechaHasta;
                objParams[3].Value = IdUsuario;

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                Grafica.Columns.Add("Estado",typeof(String));
                Grafica.Columns.Add("Vendedor", typeof(String));
                Grafica.Columns.Add("Value", typeof(Int32));

                while (dreader.Read())
                {
                    Estado= dreader[0].ToString().Trim();
                    Vendedor=dreader[1].ToString().Trim();
                    Value= Convert.ToInt32(dreader[2]);
                    Grafica.Rows.Add(new object[] { Estado, Vendedor, Value });
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
            return Grafica;
        }        
    
        public static ResultadoTransaccion ListarProspectos()
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            IList<clsMeta> Prospectos = new List<clsMeta>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_DIRECCION_GESTION_METAS");

                SqlCommand command = new SqlCommand("SP_C_DIRECCION_GESTION_METAS", conn);

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    clsMeta ObjProspecto = new clsMeta();

                    ObjProspecto.IdNumMeta = dreader[2].ToString().Trim();
                    ObjProspecto.Id = Convert.ToInt32(dreader[0]);

                    //ObjProspecto.FollowUps = clsClienteMasterADO.ObtenerFollowUpActivosClientePorTarget(ObjProspecto.Id);

                    ObjProspecto.Prioridad = new clsItemParametro();
                    ObjProspecto.Prioridad.Codigo = dreader[1].ToString();
                    ObjProspecto.TipoOportunidad = dreader[3].ToString().Trim();
                    ObjProspecto.GlosaClienteTarget = dreader[4].ToString().Trim();
                    ObjProspecto.ObjClienteMaster = new clsClienteMaster(true);
                    ObjProspecto.ObjClienteMaster.Id = Convert.ToInt32(dreader[5]);
                    ObjProspecto.ObjClienteMaster.NombreFantasia = dreader[6].ToString().Trim();
                    ObjProspecto.ObjMetaAsignacion = new clsMetaAsignacion();
                    ObjProspecto.ObjMetaAsignacion.ObjVendedorAsignado = new clsUsuario();
                    ObjProspecto.ObjMetaAsignacion.ObjVendedorAsignado.Id = Convert.ToInt32(dreader[7]);
                    ObjProspecto.ObjMetaAsignacion.ObjVendedorAsignado.NombreUsuario = dreader[8].ToString().Trim();
                    ObjProspecto.EstadoMeta = (Enums.EstadosMetas)Convert.ToInt16(dreader[9]);
                    ObjProspecto.FechaApertura = Convert.ToDateTime(dreader[10]);
                    ObjProspecto.FechaUltActulizacion = Convert.ToDateTime(dreader[12]);
                    ObjProspecto.IdTipoActualizacion = Convert.ToInt32(dreader[13]);
                    ObjProspecto.FechaHoy = Convert.ToDateTime(dreader[14]);
                    ObjProspecto.UsuarioAsignador = new clsUsuario();
                    ObjProspecto.UsuarioAsignador.Id = Convert.ToInt32(dreader[15]);
                    ObjProspecto.UsuarioAsignador.Email= dreader[16].ToString().Trim();
                    ObjProspecto.ObjMetaAsignacion.ObjVendedorAsignado.Email = dreader[17].ToString().Trim();
                    ObjProspecto.ObjMetaAsignacion.ObjVendedorAsignado.Nombre = dreader[18].ToString().Trim();

                    //ObjProspecto.FollowUps = clsClienteMasterADO.ObtenerFollowUpActivosClientePorTarget(ObjProspecto.Id);
                    //ObjProspecto.FechaRevision = Convert.ToDateTime(dreader[11]);

                    Prospectos.Add(ObjProspecto);
                }
                res.Accion = Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = Prospectos;
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsMetaAdo.cs";
                res.MetodoError = "ListarProspectos";
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
        public static ResultadoTransaccion ListarObservacionesProspecto(long IdProspecto)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            IList<clsMetaObservaciones> Observaciones = new List<clsMetaObservaciones>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_DIRECCION_META_OBSERVACION");

                SqlCommand command = new SqlCommand("SP_C_DIRECCION_META_OBSERVACION", conn);

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                objParams[0].Value = IdProspecto;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    clsMetaObservaciones ObjObservacion = new clsMetaObservaciones();

                    ObjObservacion.Id = Convert.ToInt32(dreader[0]);
                    ObjObservacion.Observacion = dreader[1].ToString().Trim();
                    ObjObservacion.FechaHora = Convert.ToDateTime(dreader[2]); ;
                    ObjObservacion.ObjUsuario = new clsUsuario();
                    ObjObservacion.ObjUsuario.Id = Convert.ToInt32(dreader[3]); ;
                    ObjObservacion.ObjUsuario.NombreUsuario = dreader[4].ToString().Trim();
                    ObjObservacion.ObjUsuario.Email = dreader[5].ToString().Trim();
                    ObjObservacion.ObjUsuario.Nombre = dreader[6].ToString().Trim();

                    Observaciones.Add(ObjObservacion);
                }
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = Observaciones;
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsMetaAdo.cs";
                res.MetodoError = "ListarObservacionesProspecto";
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
        public static ResultadoTransaccion GuardarAsignacion(long IdMeta,int IdEstadoMeta,long IdVendedorAsignado, DateTime FechaAsignacion)
        {
            ResultadoTransaccion Res = new ResultadoTransaccion();
            //Abrir Conexion
            conn = BaseDatos.Conexion();
            //Crear Transaccion
            transaction = conn.BeginTransaction();
            try
            {
                Res = clsMetaAdo.CambioEstado(IdMeta, IdEstadoMeta);
                if (Res.Estado == ProyectoCraft.Entidades.Enums.Enums.EstadoTransaccion.Aceptada)
                {
                    Res = clsMetaAdo.GuardarProspectoUsuario(IdMeta, IdVendedorAsignado, FechaAsignacion);
                    if (Res.Estado == ProyectoCraft.Entidades.Enums.Enums.EstadoTransaccion.Rechazada)
                    {
                        transaction.Rollback();
                        Log.EscribirLog(Res.Descripcion);
                        return Res;
                    }
                }
                //Ejecutar transaccion
                transaction.Commit();
                Res.Estado = Enums.EstadoTransaccion.Aceptada;
                Res.Descripcion = "Se registró la asiganción del prospecto correctamente";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                Res.Descripcion = ex.Message;
                Res.ArchivoError = "clsMetaAdo.cs";
                Res.MetodoError = "GuardarAsignacionProspecto";
                Res.Estado = Enums.EstadoTransaccion.Rechazada;
            }
            finally
            {
                conn.Close();
            }
            return Res;
        }
        public static ResultadoTransaccion GuardarVariosProspectos(IList<clsMeta> ListaProspectos)
        {
            ResultadoTransaccion Res = new ResultadoTransaccion();
            //Abrir Conexion
            conn = BaseDatos.Conexion();
            //Crear Transaccion
            transaction = conn.BeginTransaction();
            try
            {
                foreach (clsMeta Prospecto in ListaProspectos)
                {
                    Res = clsMetaAdo.GuardarProspecto(Prospecto);
                    
                    if (Res.Estado == ProyectoCraft.Entidades.Enums.Enums.EstadoTransaccion.Aceptada)
                    {
                        foreach (var followUp in Prospecto.FollowUps)
                            followUp.IdTarget = Prospecto.Id32;
                        
                        Res =  GuardarFollowups(new List<clsClienteFollowUp>(), Prospecto);
                        Res = clsMetaAdo.GuardarProspectoUsuario(Prospecto.Id, Prospecto.ObjMetaAsignacion.ObjVendedorAsignado.Id, Prospecto.FechaApertura);
                        if (Prospecto.ObjMetaCompetencia != null)
                            foreach (clsMetaCompetencia Competencia in Prospecto.ObjMetaCompetencia)
                            {
                                Res = clsMetaAdo.GuardarProspectoCompetencia(Prospecto.Id, Competencia);
                                if (Res.Estado == ProyectoCraft.Entidades.Enums.Enums.EstadoTransaccion.Rechazada)
                                {
                                    transaction.Rollback();
                                    Log.EscribirLog(Res.Descripcion);
                                    return Res;
                                }
                            }
                        if (Prospecto.ObjMetaGlosasTrafico != null)
                            foreach (clsMetaGlosasTrafico Traficos in Prospecto.ObjMetaGlosasTrafico)
                            {
                                Res = clsMetaAdo.GuardarProspectoTraficos(Prospecto.Id, Traficos);
                                if (Res.Estado == ProyectoCraft.Entidades.Enums.Enums.EstadoTransaccion.Rechazada)
                                {
                                    transaction.Rollback();
                                    Log.EscribirLog(Res.Descripcion);
                                    return Res;
                                }
                            }
                        if (Prospecto.ObjTipoProducto != null)
                            foreach (clsTipoProducto Producto in Prospecto.ObjTipoProducto)
                            {
                                Res = clsMetaAdo.GuardarProspectoTiposProductos(Prospecto.Id, Producto.Id);
                                if (Res.Estado == ProyectoCraft.Entidades.Enums.Enums.EstadoTransaccion.Rechazada)
                                {
                                    transaction.Rollback();
                                    Log.EscribirLog(Res.Descripcion);
                                    return Res;
                                }
                            }
                    }
                }
                //Ejecutar transaccion
                transaction.Commit();
                Res.Estado = Enums.EstadoTransaccion.Aceptada;
                Res.Descripcion = "Se registró la asiganción del prospecto correctamente";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                Res.Descripcion = ex.Message;
                Res.ArchivoError = "clsMetaAdo.cs";
                Res.MetodoError = "GuardarAsignacionProspecto";
                Res.Estado = Enums.EstadoTransaccion.Rechazada;
            }
            finally
            {
                conn.Close();
            }
            return Res;
        }
        public static ResultadoTransaccion GuardarCambioEstado(long IdMeta, int IdEstadoMeta)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();
                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_A_DIRECCION_META_ESTADO");
                objParams[0].Value = IdMeta;
                objParams[1].Value = IdEstadoMeta;

                SqlCommand command = new SqlCommand("SP_A_DIRECCION_META_ESTADO", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                //Ejecutar transaccion
                transaction.Commit();
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se registró el cambio de estado correctamente";

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsMetaAdo.cs";
                res.MetodoError = "GuardarCambioEstado";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
        public static ResultadoTransaccion GuardarCierreTarget(long IdMeta, string Instruction, string Observaciones, DateTime FechaCierre, long IdUsuarioCierra)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();
                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_A_DIRECCION_META_CIERRE");
                objParams[0].Value = IdMeta;
                objParams[1].Value = Instruction;
                objParams[2].Value = Observaciones;
                objParams[3].Value = FechaCierre;
                objParams[4].Value = IdUsuarioCierra;
        
                SqlCommand command = new SqlCommand("SP_A_DIRECCION_META_CIERRE", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                //Ejecutar transaccion
                transaction.Commit();
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se registró el cambio de estado correctamente";

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsMetaAdo.cs";
                res.MetodoError = "GuardarCierreTarget";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
        public static ResultadoTransaccion GuardarCancelacionTarget(long IdMeta, string Observaciones, DateTime FechaCancelacion)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();
                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_A_DIRECCION_META_CANCELA");
                objParams[0].Value = IdMeta;
                objParams[1].Value = Observaciones;
                objParams[2].Value = FechaCancelacion;

                SqlCommand command = new SqlCommand("SP_A_DIRECCION_META_CANCELA", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                //Ejecutar transaccion
                transaction.Commit();
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se registró el cambio de estado correctamente";

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsMetaAdo.cs";
                res.MetodoError = "GuardarCancelacionTarget";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
        private static ResultadoTransaccion CambioEstado(long IdMeta, int IdEstadoMeta)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            try
            {
                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_A_DIRECCION_META_ESTADO");
                objParams[0].Value = IdMeta;
                objParams[1].Value = IdEstadoMeta;

                SqlCommand command = new SqlCommand("SP_A_DIRECCION_META_ESTADO", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                //Ejecutar transaccion
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se registró el cambio de estado correctamente";

            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);
                res.Descripcion = ex.Message;
                res.ArchivoError = "clsMetaAdo.cs";
                res.MetodoError = "GuardarCambioEstado";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            }
            finally
            {
            }
            return res;
        }
        private static ResultadoTransaccion GuardarProspecto(clsMeta ObjMeta)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            try
            {
                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_DIRECCION_META");
                objParams[0].Value = ObjMeta.ObjClienteMaster.Id;
                objParams[1].Value = ObjMeta.EstadoMeta;
                objParams[2].Value = ObjMeta.GlosaClienteTarget;
                objParams[3].Value = ObjMeta.TipoOportunidad;
                objParams[4].Value = ObjMeta.TipoTarget;
                objParams[5].Value = ObjMeta.FechaApertura;
                objParams[6].Value = ObjMeta.FechaRevision ;
                objParams[7].Value = ObjMeta.ObjTipoContenedor.Id;
                objParams[8].Value = ObjMeta.GlosaCommodity ;
                objParams[9].Value = ObjMeta.ObjMetaAsignacion.ObjVendedorAsignado.Id;
                objParams[10].Value = ObjMeta.Prioridad.Codigo;
                objParams[11].Value = ObjMeta.Shipper;
                objParams[12].Value = ObjMeta.UsuarioAsignador.Id;
                objParams[13].Direction = ParameterDirection.Output;
                objParams[14].Direction = ParameterDirection.Output;

                SqlCommand command = new SqlCommand("SP_N_DIRECCION_META", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                //ObjMeta.Id = Convert.ToInt32(command.ExecuteScalar());

                ObjMeta.IdNumMeta = objParams[13].Value.ToString();
                ObjMeta.Id = Convert.ToInt32(objParams[14].Value);

                //Ejecutar transaccion
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se registró la asiganción del prospecto correctamente";

            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsMetaAdo.cs";
                res.MetodoError = "GuardarProspecto";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            }
            finally
            {
            }
            return res;
        }
        private static ResultadoTransaccion GuardarProspectoCompetencia(long IdMeta, clsMetaCompetencia ObjCompetenciaProspecto)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            try
            {
                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_DIRECCION_META_COMPETENCIA");
                objParams[0].Value = IdMeta;
                objParams[1].Value = ObjCompetenciaProspecto.Descripcion;

                SqlCommand command = new SqlCommand("SP_N_DIRECCION_META_COMPETENCIA", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                ObjCompetenciaProspecto.Id = Convert.ToInt32(command.ExecuteScalar());

                //Ejecutar transaccion
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se registraron los datos de competencia correctamente";

            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsMetaAdo.cs";
                res.MetodoError = "GuardarProspectoCompetencia";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            }
            finally
            {
            }
            return res;
        }
        private static ResultadoTransaccion GuardarProspectoTraficos(long IdMeta, clsMetaGlosasTrafico ObjTraficosProspecto)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            try
            {
                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_DIRECCION_META_GLOSA_TRAF");
                objParams[0].Value = IdMeta;
                objParams[1].Value = ObjTraficosProspecto.Glosa;
                objParams[2].Value = ObjTraficosProspecto.TipoGlosa;

                SqlCommand command = new SqlCommand("SP_N_DIRECCION_META_GLOSA_TRAF", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                ObjTraficosProspecto.Id= Convert.ToInt32(command.ExecuteScalar());

                //Ejecutar transaccion
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se registró la información de los tráficos correctamente";
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsMetaAdo.cs";
                res.MetodoError = "GuardarProspectoTraficos";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            }
            finally
            {
            }
            return res;
        }
        public static ResultadoTransaccion GuardarProspectoUsuario(long IdMeta, long IdVenedorAsignado,DateTime FechaAsignacion)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            long Id;
            try
            {
                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_DIRECCION_META_ASIGNACION");
                objParams[0].Value = IdMeta;
                objParams[1].Value = IdVenedorAsignado;
                objParams[2].Value = FechaAsignacion;

                SqlCommand command = new SqlCommand("SP_N_DIRECCION_META_ASIGNACION", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                Id = Convert.ToInt32(command.ExecuteScalar());

                //Ejecutar transaccion
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se registró la asignación correctamente";
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsMetaAdo.cs";
                res.MetodoError = "GuardarProspectoAsignacion";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            }
            finally
            {
            }
            return res;
        }
        public static ResultadoTransaccion GuardarProspectoObservacion(long IdMeta,clsMetaObservaciones ObjObservacion,ref string ModificaGlosa)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            long Id;
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_DIRECCION_META_OBSERVACION");
                objParams[0].Value = ObjObservacion.Id;
                objParams[1].Value = IdMeta;
                objParams[2].Value = ObjObservacion.ObjUsuario.Id;
                objParams[3].Value = ObjObservacion.FechaHora;
                objParams[4].Value = ObjObservacion.Observacion;
                objParams[5].Direction = ParameterDirection.Output;
                objParams[6].Direction = ParameterDirection.Output;

                SqlCommand command = new SqlCommand("SP_N_DIRECCION_META_OBSERVACION", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                ObjObservacion.Id = Convert.ToInt32(objParams[5].Value);
                ModificaGlosa = objParams[6].Value.ToString(); 
                //ObjObservacion.Id = Convert.ToInt32(command.ExecuteScalar());

                //Ejecutar transaccion
                transaction.Commit();
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se registró la observacion correctamente";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsMetaAdo.cs";
                res.MetodoError = "GuardarProspectoObservacion";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
        public static ResultadoTransaccion EliminarProspectoObservacion(long IdObservacion)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            long Id;
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_E_DIRECCION_META_OBSERVACION");
                objParams[0].Value = IdObservacion;

                SqlCommand command = new SqlCommand("SP_E_DIRECCION_META_OBSERVACION", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                //Ejecutar transaccion
                transaction.Commit();
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se eliminó la observacion correctamente";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsMetaAdo.cs";
                res.MetodoError = "EliminarProspectoObservacion";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
        private static ResultadoTransaccion GuardarProspectoTiposProductos(long IdMeta, long IdTipoProducto)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            long Id;
            try
            {
                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_DIRECCION_META_TIPO_PROD");
                objParams[0].Value = IdMeta;
                objParams[1].Value = IdTipoProducto;

                SqlCommand command = new SqlCommand("SP_N_DIRECCION_META_TIPO_PROD", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                Id = Convert.ToInt32(command.ExecuteScalar());

                //Ejecutar transaccion
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se registró la información de productos correctamente";
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsMetaAdo.cs";
                res.MetodoError = "GuardarProspectoTiposProducto";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            }
            finally
            {
            }
            return res;
        }

        public static ResultadoTransaccion GuardarCambioEstadoTransaction(long IdMeta, int IdEstadoMeta, SqlConnection pcon, SqlTransaction ptransaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            try
            {
                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(pcon, "SP_A_DIRECCION_META_ESTADO");
                objParams[0].Value = IdMeta;
                objParams[1].Value = IdEstadoMeta;

                SqlCommand command = new SqlCommand("SP_A_DIRECCION_META_ESTADO", pcon);
                command.Transaction = ptransaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                //Ejecutar transaccion

                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se registró el cambio de estado correctamente";

            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsMetaAdo.cs";
                res.MetodoError = "GuardarCambioEstado";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            }
            finally
            {

            }
            return res;
        }

        public static ResultadoTransaccion ObtenerMetaPorId(Int64 IdMeta)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            clsMeta ObjProspecto = null;
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_DIRECCION_META_PORID");
                objParams[0].Value = IdMeta;
                SqlCommand command = new SqlCommand("SP_C_DIRECCION_META_PORID", conn);

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    ObjProspecto = new clsMeta();
                    ObjProspecto.FollowUps = clsClienteMasterADO.ObtenerFollowUpActivosClientePorTarget(IdMeta);

                    ObjProspecto.GlosaClienteTarget = dreader["GlosaClienteTarget"].ToString().Trim();
                    ObjProspecto.GlosaCommodity = dreader["GlosaCommodity"].ToString();
                    ObjProspecto.ObjTipoContenedor = new clsItemParametro();
                    ObjProspecto.ObjTipoContenedor.Nombre = dreader["TipoContenedor"].ToString();
                    //ObjProspecto.FechaRevision = Convert.ToDateTime(dreader["FechaRevision"]);
                    ObjProspecto.ObjMetaAsignacion = new clsMetaAsignacion();
                    ObjProspecto.ObjMetaAsignacion.ObjVendedorAsignado = new clsUsuario();
                    //ObjProspecto.ObjMetaAsignacion.ObjVendedorAsignado.Id = Convert.ToInt32(dreader[7]);
                    ObjProspecto.ObjMetaAsignacion.ObjVendedorAsignado.Nombre = dreader["VendedorNombres"].ToString().Trim();
                    ObjProspecto.ObjMetaAsignacion.ObjVendedorAsignado.ApellidoPaterno = dreader["VendedorPaterno"].ToString().Trim();
                    ObjProspecto.ObjMetaAsignacion.ObjVendedorAsignado.ApellidoMaterno = dreader["VendedorMaterno"].ToString().Trim();
                    ObjProspecto.FechaApertura = Convert.ToDateTime(dreader["FechaApertura"]);
                    ObjProspecto.Shipper = dreader["Shipper"].ToString();

                    ObjProspecto.NombreUsuarioCierra = dreader["UCNombres"].ToString().Trim() + " " +
                                                       dreader["UCierraPaterno"].ToString().Trim() + " " +
                                                       dreader["UCierraMaterno"].ToString().Trim();
                    if (dreader["FechaCierre"] is DBNull)
                        ObjProspecto.FechaCierre = null;
                    else
                        ObjProspecto.FechaCierre = Convert.ToDateTime(dreader["FechaCierre"]);

                    ObjProspecto.Instruction = dreader["Instruction"].ToString();
                    if (dreader["FechaCancelacion"] is DBNull)
                        ObjProspecto.FechaCancelacion = null;
                    else
                        ObjProspecto.FechaCancelacion = Convert.ToDateTime(dreader["FechaCancelacion"]);


                    ObjProspecto.ObjMetaObservaciones = new clsMetaObservaciones();
                    ObjProspecto.ObjMetaObservaciones.Observacion = dreader["Observaciones"].ToString();
                    ObjProspecto.FollowUps = clsClienteMasterADO.ObtenerFollowUpActivosClientePorTarget(ObjProspecto.Id32);

                }

                
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = ObjProspecto;
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsMetaAdo.cs";
                res.MetodoError = "ListarProspectos";
            }
            finally
            {
                conn.Close();
            }
            return res;
        }

        public static ResultadoTransaccion GuardarFollowups(IList<clsClienteFollowUp> followDatabase, clsMeta Meta) {
            ResultadoTransaccion resTransaccion = new ResultadoTransaccion();
            foreach (var followUp in Meta.FollowUps) {
                if (followUp.IsNew)
                    resTransaccion = Clientes.clsClienteMasterADO.AgregarFollowUpClienteMaster(followUp, transaction);
                else
                    resTransaccion = Clientes.clsClienteMasterADO.ModificarFollowUpClienteMaster(followUp, transaction);

                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);
            }

            if (!Meta.IsNew) {
                var newlist = Meta.FollowUps.ToList();
                foreach (var followUp in followDatabase) {
                    var encontrado = newlist.Find(foo => foo.Id32.Equals(followUp.Id32));
                    if (encontrado == null) {
                        resTransaccion = Clientes.clsClienteMasterADO.EliminarLogicoFollowUpClienteMaster(followUp, transaction);
                        if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                            throw new Exception(resTransaccion.Descripcion);
                    }
                }
            }

            resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
            resTransaccion.Accion = Enums.AccionTransaccion.Insertar;
            resTransaccion.ObjetoTransaccion = Meta;
            resTransaccion.Descripcion = "Se registró los Followup Exitosamente";
            return resTransaccion;
        }

    }
}
