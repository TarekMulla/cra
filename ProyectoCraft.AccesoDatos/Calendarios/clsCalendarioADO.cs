using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.AccesoDatos.LogPerfomance;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Calendario;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Entidades.Log;
using ProyectoCraft.Entidades.Usuarios;

namespace ProyectoCraft.AccesoDatos.Calendarios
{
    public static class clsCalendarioADO
    {
        private static SqlParameter[] objParams = null;        
        //private static SqlDataReader dreader = null;
        private static ResultadoTransaccion resTransaccion = null;

        public static IList<clsClienteMaster> ListarCuentasPorPlanificar(Int16 Categoria, Int64 IdUsuario)
        {
            SqlDataReader dreader = null;
            clsClienteMaster master = null;
            IList<clsClienteMaster> listMaster = new List<clsClienteMaster>();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_C_CALENDARIO_CUENTAS_POR_CATEGORIA");
                objParams[0].Value = Categoria;
                objParams[1].Value = IdUsuario;
                
                SqlCommand command = new SqlCommand("SP_C_CALENDARIO_CUENTAS_POR_CATEGORIA", BaseDatos.Conexion());
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    master = new clsClienteMaster(true);
                    master.Id = Convert.ToInt64(dreader["IdMaster"]);
                    master.NombreCompañia = dreader["NombreCompania"].ToString();
                    master.Nombres = dreader["Nombres"].ToString();
                    master.ApellidoPaterno = dreader["ApellidoPaterno"].ToString();
                    master.ApellidoMaterno = dreader["ApellidoMaterno"].ToString();
                    master.NombreFantasia = dreader["NombreFantasia"].ToString();                    
                    master.RUT = dreader["RUT"].ToString();
                    listMaster.Add(master);
                }

            }
            catch (Exception ex)
            {
                Base.Log.Log.EscribirLog(ex.Message);                
            }
            finally
            {
                BaseDatos.CerrarConexion();
            }

            return listMaster;
        }

        public static IList<clsClienteMaster> ListarTargetsPorPlanificar(Int64 IdUsuario)
        {
            SqlDataReader dreader = null;
            clsClienteMaster master = null;
            IList<clsClienteMaster> listMaster = new List<clsClienteMaster>();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_C_CALENDARIO_TARGET_SIN_PLANIFICAR");                
                objParams[0].Value = IdUsuario;

                SqlCommand command = new SqlCommand("SP_C_CALENDARIO_TARGET_SIN_PLANIFICAR", BaseDatos.Conexion());
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    master = new clsClienteMaster(true);
                    master.Id = Convert.ToInt64(dreader["IdMaster"]);
                    master.NombreCompañia = dreader["NombreCompania"].ToString();
                    master.Nombres = dreader["Nombres"].ToString();
                    master.ApellidoPaterno = dreader["ApellidoPaterno"].ToString();
                    master.ApellidoMaterno = dreader["ApellidoMaterno"].ToString();
                    master.NombreFantasia = dreader["NombreFantasia"].ToString();
                    master.RUT = dreader["RUT"].ToString();
                    listMaster.Add(master);
                }

            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);
            }
            finally
            {
                BaseDatos.CerrarConexion();
            }

            return listMaster;
        }

        public static IList<clsVisita> ListarVisitas(DateTime fechadesde, DateTime fechahasta, Int16 estado, Int64 idUsuario, Int16 idCategoria,Hashtable htUsuarios)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            SqlDataReader dreader = null;
            clsVisita visita = null;
            IList<clsVisita> listvisitas = new List<clsVisita>();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_C_CALENDARIO_VISITAS");
                objParams[0].Value = fechadesde;
                objParams[1].Value = fechahasta;
                objParams[2].Value = estado;
                objParams[3].Value = idUsuario;
                objParams[4].Value = idCategoria;

                SqlCommand command = new SqlCommand("SP_C_CALENDARIO_VISITAS", BaseDatos.Conexion());
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    visita = new clsVisita();
                    visita.Id = Convert.ToInt64(dreader["Id"]);
                    visita.Asunto = dreader["Asunto"].ToString();
                    visita.Ubicacion = dreader["Ubicacion"].ToString();
                    visita.FechaHoraComienzo = Convert.ToDateTime(dreader["FechaHoraComienzo"].ToString());
                    visita.FechaHoraTermino = Convert.ToDateTime(dreader["FechaHoraTermino"].ToString());
                    visita.Descripcion = dreader["Descripcion"].ToString();
                    visita.NivelImportancia = Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["NivelImportancia"]));
                    visita.EstadoBD = (Enums.VisitaEstado)Convert.ToInt16(dreader["IdEstado"]);
                    visita.EstadoVista = Convert.ToInt16(dreader["EstadoCalendario"]); //(Enums.VisitaEstadoVista)
                    visita.Asistentes = ObtenerAsistentesDeVisita(visita.Id);
                    if (dreader["IdCliente"] is DBNull)
                        visita.Cliente = null;
                    else 
                        visita.Cliente = Clientes.clsClienteMasterADO.ObtenerClienteMasterPorId(
                                        Convert.ToInt64(dreader["IdCliente"]));

                    if (htUsuarios != null)
                        visita.UsuarioOrganizador = (clsUsuario) htUsuarios[dreader["IdUsuario"].ToString()];
                    else
                        visita.UsuarioOrganizador = Usuarios.clsUsuarioADO.ObtenerUsuarioPorId(Convert.ToInt16(dreader["IdUsuario"]));

                    listvisitas.Add(visita);
                }

            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);
            }
            finally
            {
                BaseDatos.CerrarConexion();
            }
            ClsLogPerformanceADO.SaveFromADO(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
            return listvisitas;
        }

        public static IList<clsVisita> ListarVisitasTarget(DateTime fechadesde, DateTime fechahasta, Int16 estado, Int64 idUsuario)
        {
            SqlDataReader dreader = null;
            clsVisita visita = null;
            IList<clsVisita> listvisitas = new List<clsVisita>();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_C_CALENDARIO_VISITAS_TARGET");
                objParams[0].Value = fechadesde;
                objParams[1].Value = fechahasta;
                objParams[2].Value = estado;
                objParams[3].Value = idUsuario;

                SqlCommand command = new SqlCommand("SP_C_CALENDARIO_VISITAS_TARGET", BaseDatos.Conexion());
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    visita = new clsVisita();
                    visita.Id = Convert.ToInt64(dreader["Id"]);
                    visita.Asunto = dreader["Asunto"].ToString();
                    visita.Ubicacion = dreader["Ubicacion"].ToString();
                    visita.FechaHoraComienzo = Convert.ToDateTime(dreader["FechaHoraComienzo"].ToString());
                    visita.FechaHoraTermino = Convert.ToDateTime(dreader["FechaHoraTermino"].ToString());
                    visita.Descripcion = dreader["Descripcion"].ToString();
                    visita.NivelImportancia = Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["NivelImportancia"]));
                    visita.EstadoBD = (Enums.VisitaEstado)Convert.ToInt16(dreader["IdEstado"]);
                    visita.EstadoVista = Convert.ToInt16(dreader["EstadoCalendario"]); //(Enums.VisitaEstadoVista)
                    visita.Asistentes = ObtenerAsistentesDeVisita(visita.Id);
                    listvisitas.Add(visita);
                }

            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);
            }
            finally
            {
                BaseDatos.CerrarConexion();
            }

            return listvisitas;
        }

        public static ResultadoTransaccion GuardarVisita(clsVisita visita)
        {
            SqlTransaction transaction = BaseDatos.Conexion().BeginTransaction();
            ResultadoTransaccion resSalida = new ResultadoTransaccion();

            try
            {                
                resTransaccion = new ResultadoTransaccion();
                resTransaccion = AgregarVisita(visita, transaction);
                if(resTransaccion.Estado == Enums.EstadoTransaccion.Aceptada)
                {
                    Int64 idVisita = 0;
                    idVisita = (Int64)resTransaccion.ObjetoTransaccion;
                    visita.Id = idVisita;
                    foreach (clsVisitaAsistente asistente in visita.Asistentes)
                    {
                        resTransaccion = new ResultadoTransaccion();                        
                        resTransaccion = AgregarAsistente(asistente, idVisita, transaction);
                        if(resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                            throw new Exception(resTransaccion.Descripcion);
                    }
                    
                    transaction.Commit();
                    
                    resSalida.Estado = Enums.EstadoTransaccion.Aceptada;                    
                }
                else
                {
                    throw new Exception(resTransaccion.Descripcion);
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                resSalida.Estado = Enums.EstadoTransaccion.Rechazada;
                resSalida.Descripcion = ex.Message;
            }
            finally
            {
                BaseDatos.CerrarConexion();
            }

            return resSalida;

        }

        public static ResultadoTransaccion ActualizarVisita(clsVisita visita)
        {
            SqlTransaction transaction = BaseDatos.Conexion().BeginTransaction();
            ResultadoTransaccion resSalida = new ResultadoTransaccion();

            try
            {
                resTransaccion = new ResultadoTransaccion();
                resTransaccion = ModificarVisita(visita, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Aceptada)
                {
                    resTransaccion = new ResultadoTransaccion();
                    resTransaccion = EliminarAsistentesVisita(visita.Id,transaction);

                    if(resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resTransaccion.Descripcion);

                    foreach (clsVisitaAsistente asistente in visita.Asistentes)
                    {
                        resTransaccion = new ResultadoTransaccion();
                        asistente.IdVisita = visita.Id;
                        resTransaccion = AgregarAsistente(asistente, visita.Id, transaction);
                        if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                            throw new Exception(resTransaccion.Descripcion);
                    }

                    transaction.Commit();

                    resSalida.Estado = Enums.EstadoTransaccion.Aceptada;
                }
                else
                {
                    throw new Exception(resTransaccion.Descripcion);
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                resSalida.Estado = Enums.EstadoTransaccion.Rechazada;
                resSalida.Descripcion = ex.Message;
            }
            finally
            {
                BaseDatos.CerrarConexion();
            }

            return resSalida;
        }

        private static ResultadoTransaccion ModificarVisita(clsVisita visita, SqlTransaction transaction)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_A_CALENDARIO_VISITA");
                objParams[0].Value = visita.Asunto;
                objParams[1].Value = visita.Ubicacion;
                objParams[2].Value = visita.FechaHoraComienzo;
                objParams[3].Value = visita.FechaHoraTermino;

                if (visita.Cliente == null)
                    objParams[4].Value = -1;
                else 
                    objParams[4].Value = visita.Cliente.Id;

                if (visita.Vendedor == null)
                    objParams[5].Value = -1;
                else 
                    objParams[5].Value = visita.Vendedor.Id;

                objParams[6].Value = visita.Descripcion;

                if (visita.NivelImportancia == null)
                    objParams[7].Value = -1;
                else
                    objParams[7].Value = visita.NivelImportancia.Id;

                objParams[8].Value = visita.EsRecurrente;
                objParams[9].Value = visita.EstadoBD;
                objParams[10].Value = visita.UsuarioOrganizador.Id;
                objParams[11].Value = visita.Id;
                objParams[12].Value = visita.DescripcionCancelacion;
                objParams[13].Value = visita.FechaCancelacion;
                objParams[14].Value = visita.EsReplanificada;
                objParams[15].Value = visita.FechaReplanificacion;
                objParams[16].Value = visita.FechaConfirmacion;
                objParams[17].Value = visita.EsReunionInterna;

                SqlCommand command = new SqlCommand("SP_A_CALENDARIO_VISITA", BaseDatos.Conexion());
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;


                //Registrar Actividad
                LogActividadUsuarios log = new LogActividadUsuarios(visita.GetType().ToString(), visita.Id, Enums.TipoActividadUsuario.Edito, Base.Usuario.UsuarioConectado.Usuario);
                LogActividades.clsLogActividadUsuariosADO.GuardaActividad(log);
            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        private static ResultadoTransaccion AgregarVisita(clsVisita visita, SqlTransaction transaction)
        {
            Int64 idVisita = 0;
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_N_CALENDARIO_VISITA");
                objParams[0].Value = visita.Asunto;
                objParams[1].Value = visita.Ubicacion;
                objParams[2].Value = visita.FechaHoraComienzo;
                objParams[3].Value = visita.FechaHoraTermino;

                if(visita.Cliente == null)
                    objParams[4].Value = -1;
                else
                    objParams[4].Value = visita.Cliente.Id;
                
                if (visita.Vendedor == null)
                    objParams[5].Value = -1;
                else 
                    objParams[5].Value = visita.Vendedor.Id;

                objParams[6].Value = visita.Descripcion;
                
                if(visita.NivelImportancia == null)
                    objParams[7].Value = -1;
                else
                    objParams[7].Value = visita.NivelImportancia.Id;

                objParams[8].Value = visita.EsRecurrente;
                objParams[9].Value = visita.EstadoBD;
                objParams[10].Value = visita.UsuarioOrganizador.Id;
                objParams[11].Value = visita.EsReunionInterna;

                SqlCommand command = new SqlCommand("SP_N_CALENDARIO_VISITA", BaseDatos.Conexion());
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                idVisita = Convert.ToInt64(command.ExecuteScalar());

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.ObjetoTransaccion = idVisita;

                //Registrar Actividad
                LogActividadUsuarios log = new LogActividadUsuarios(visita.GetType().ToString(), idVisita, Enums.TipoActividadUsuario.Creo, Base.Usuario.UsuarioConectado.Usuario);
                LogActividades.clsLogActividadUsuariosADO.GuardaActividad(log);

            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        private static ResultadoTransaccion AgregarAsistente(clsVisitaAsistente asistente, Int64 idVisita, SqlTransaction transaction)
        {            
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_N_CALENDARIO_VISITA_ASISTENTE");
                objParams[0].Value = idVisita;
                if (asistente.Usuario == null)
                    objParams[1].Value = -1;
                else 
                    objParams[1].Value = asistente.Usuario.Id;

                if (asistente.Contacto == null)
                    objParams[2].Value = -1;
                else 
                    objParams[2].Value = asistente.Contacto.Id;

                objParams[3].Value = asistente.TipoAsistente;
                objParams[4].Value = asistente.Confirmo;

                SqlCommand command = new SqlCommand("SP_N_CALENDARIO_VISITA_ASISTENTE", BaseDatos.Conexion());
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                asistente.Id = Convert.ToInt64(command.ExecuteScalar());
                
                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;

                //Registrar Actividad
                LogActividadUsuarios log = new LogActividadUsuarios(asistente.GetType().ToString(), asistente.Id, Enums.TipoActividadUsuario.Creo, Base.Usuario.UsuarioConectado.Usuario);
                LogActividades.clsLogActividadUsuariosADO.GuardaActividad(log);

            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        public static clsVisita ObtenerVisitaPorId(Int64 IdVisita)
        {
            clsVisita visita = null;
            
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_C_CALENDARIO_VISITA_POR_ID");
                objParams[0].Value = IdVisita;
                
                
                DataSet ds = SqlHelper.ExecuteDataset(BaseDatos.Conexion(), CommandType.StoredProcedure, "SP_C_CALENDARIO_VISITA_POR_ID",objParams);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    visita =new clsVisita();
                    visita.Id = Convert.ToInt64(ds.Tables[0].Rows[0]["Id"]);
                    visita.Asunto = ds.Tables[0].Rows[0]["Asunto"].ToString();
                    visita.Ubicacion = ds.Tables[0].Rows[0]["Ubicacion"].ToString();
                    if (ds.Tables[0].Rows[0]["IdCliente"] is DBNull)
                        visita.Cliente = null;
                    else 
                        visita.Cliente = Clientes.clsClienteMasterADO.ObtenerClienteMasterPorId(Convert.ToInt64(ds.Tables[0].Rows[0]["IdCliente"]));
                    
                    if (ds.Tables[0].Rows[0]["IdVendedor"] is DBNull)
                        visita.Vendedor = null;
                    else
                        visita.Vendedor = Usuarios.clsUsuarioADO.ObtenerUsuarioPorId(Convert.ToInt16(ds.Tables[0].Rows[0]["IdVendedor"]));

                    visita.FechaHoraComienzo = Convert.ToDateTime(ds.Tables[0].Rows[0]["FechaHoraComienzo"].ToString());
                    visita.FechaHoraTermino = Convert.ToDateTime(ds.Tables[0].Rows[0]["FechaHoraTermino"].ToString());
                    visita.Descripcion = ds.Tables[0].Rows[0]["Descripcion"].ToString();
                    visita.NivelImportancia = Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(ds.Tables[0].Rows[0]["NivelImportancia"]));
                    visita.EstadoBD = (Enums.VisitaEstado)Convert.ToInt16(ds.Tables[0].Rows[0]["IdEstado"]);
                    visita.EstadoBDOld = (Enums.VisitaEstado)Convert.ToInt16(ds.Tables[0].Rows[0]["IdEstado"]);
                    if (ds.Tables[0].Rows[0]["DescripcionCancelacion"] is DBNull)
                        visita.DescripcionCancelacion = "";
                    else
                        visita.DescripcionCancelacion = ds.Tables[0].Rows[0]["DescripcionCancelacion"].ToString();


                    if (ds.Tables[0].Rows[0]["FechaCancelacion"] is DBNull)
                        visita.FechaCancelacion = DateTime.Now;
                    else
                        visita.FechaCancelacion = (DateTime)ds.Tables[0].Rows[0]["FechaCancelacion"];

                    if (ds.Tables[0].Rows[0]["EsReplanificada"] is DBNull)
                        visita.EsReplanificada = false;
                    else
                        visita.EsReplanificada = (bool)ds.Tables[0].Rows[0]["EsReplanificada"];

                    if (ds.Tables[0].Rows[0]["FechaReplanificacion"] is DBNull)
                        visita.FechaReplanificacion = new DateTime(9999,1,1,0,0,0);
                    else
                        visita.FechaReplanificacion = (DateTime) ds.Tables[0].Rows[0]["FechaReplanificacion"];

                    if (ds.Tables[0].Rows[0]["IdUsuario"] is DBNull)
                        visita.UsuarioOrganizador = null;
                    else
                        visita.UsuarioOrganizador = Usuarios.clsUsuarioADO.ObtenerUsuarioPorId(Convert.ToInt16(ds.Tables[0].Rows[0]["IdUsuario"]));

                    if (ds.Tables[0].Rows[0]["FechaConfirmacion"] is DBNull)
                        visita.FechaConfirmacion = new DateTime(9999, 1, 1, 0, 0, 0);
                    else 
                        visita.FechaConfirmacion = (DateTime)ds.Tables[0].Rows[0]["FechaConfirmacion"];

                    if (ds.Tables[0].Rows[0]["EsReunionInterna"] is DBNull)
                        visita.EsReunionInterna = false;
                    else
                        visita.EsReunionInterna = Convert.ToBoolean(ds.Tables[0].Rows[0]["EsReunionInterna"]);

                    visita.Asistentes = ObtenerAsistentesDeVisita(IdVisita);

                    resTransaccion = new ResultadoTransaccion();
                    resTransaccion = ObtenerInformeVisitaPor(-1, visita.Id);
                    if (resTransaccion.Estado == Enums.EstadoTransaccion.Aceptada)
                        visita.Informvisita = (clsVisitaInforme) resTransaccion.ObjetoTransaccion;
                    
                }                                
            }
            catch (Exception ex)
            {                
                Log.EscribirLog(ex.Message);
            }
            finally
            {
                BaseDatos.CerrarConexion();
            }

            return visita;
        
        }

        public static IList<clsVisitaAsistente> ObtenerAsistentesDeVisita(Int64 IdVisita)
        {
            SqlDataReader dreader = null;
            clsVisitaAsistente asistente = null;
            IList<clsVisitaAsistente> listaasistentes = new List<clsVisitaAsistente>();
            SqlConnection conn = null;

            try
            {
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_CALENDARIO_VISITA_ASISTENTES_POR_ID_VISITA");
                objParams[0].Value = IdVisita;

                SqlCommand command = new SqlCommand("SP_C_CALENDARIO_VISITA_ASISTENTES_POR_ID_VISITA", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    asistente = new clsVisitaAsistente();
                    asistente.Id = Convert.ToInt64(dreader["Id"]);
                    asistente.IdVisita = Convert.ToInt64(dreader["IdVisita"]);
                    if (dreader["IdUsuario"] is DBNull)
                        asistente.Usuario = null;
                    else
                        asistente.Usuario =
                            Usuarios.clsUsuarioADO.ObtenerUsuarioPorId(Convert.ToInt16(dreader["IdUsuario"]));

                    if (dreader["IdContacto"] is DBNull)
                        asistente.Contacto = null;
                    else
                        asistente.Contacto =
                            Clientes.clsContactoADO.ObtenerContactoPorId(Convert.ToInt16(dreader["IdContacto"]));

                    asistente.TipoAsistente = (Enums.VisitaTipoAsistente)Convert.ToInt16(dreader["TipoAsistente"]);
                    asistente.Confirmo = (Enums.VisitaEstadoAsistente)Convert.ToInt16(dreader["Asistio"]);
                                        
                    listaasistentes.Add(asistente);
                }

            }
            catch (Exception ex)
            {

                Base.Log.Log.EscribirLog(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return listaasistentes;
        }

        public static ResultadoTransaccion EliminarAsistentesVisita(Int64 IdVisita, SqlTransaction transaction)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_E_CALENDARIO_VISITA_ASISTENTES");
                objParams[0].Value = IdVisita;
                
                SqlCommand command = new SqlCommand("SP_E_CALENDARIO_VISITA_ASISTENTES", BaseDatos.Conexion());
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        public static ResultadoTransaccion EliminarVisita(clsVisita visita)
        {
            SqlTransaction transaction = BaseDatos.Conexion().BeginTransaction();
            ResultadoTransaccion resSalida = new ResultadoTransaccion();

            try
            {                
                foreach (var asistente in visita.Asistentes)
                {
                    resTransaccion = new ResultadoTransaccion();
                    resTransaccion = EliminarAsistente(asistente, transaction);
                    if(resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resTransaccion.Descripcion);

                }

                resTransaccion = new ResultadoTransaccion();
                resTransaccion = EliminaVisita(visita, transaction);

                if(resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);

                                
                transaction.Commit();

                resSalida.Estado = Enums.EstadoTransaccion.Aceptada;
                
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                resSalida.Estado = Enums.EstadoTransaccion.Rechazada;
                resSalida.Descripcion = ex.Message;
            }
            finally
            {
                BaseDatos.CerrarConexion();
            }

            return resSalida;
        }

        private static ResultadoTransaccion EliminaVisita(clsVisita visita, SqlTransaction transaction)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_E_CALENDARIO_VISITA");
                objParams[0].Value = visita.Id;

                SqlCommand command = new SqlCommand("SP_E_CALENDARIO_VISITA", BaseDatos.Conexion());
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;

                //Registrar Actividad
                LogActividadUsuarios log = new LogActividadUsuarios(visita.GetType().ToString(), visita.Id, Enums.TipoActividadUsuario.Elimino, Base.Usuario.UsuarioConectado.Usuario);
                LogActividades.clsLogActividadUsuariosADO.GuardaActividad(log);

            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        private static ResultadoTransaccion EliminarAsistente(clsVisitaAsistente asistente, SqlTransaction transaction)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_E_CALENDARIO_VISITA_ASISTENTE");
                objParams[0].Value = asistente.Id;
              
                SqlCommand command = new SqlCommand("SP_E_CALENDARIO_VISITA_ASISTENTE", BaseDatos.Conexion());
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;

                //Registrar Actividad
                LogActividadUsuarios log = new LogActividadUsuarios(asistente.GetType().ToString(), asistente.Id, Enums.TipoActividadUsuario.Elimino, Base.Usuario.UsuarioConectado.Usuario);
                LogActividades.clsLogActividadUsuariosADO.GuardaActividad(log);

            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        private static ResultadoTransaccion EliminarDatosInformeVisita(clsVisitaInforme informe , SqlTransaction transaction)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_E_CALENDARIO_VISITA_INFORME_DATOS");
                objParams[0].Value = informe.Id;

                SqlCommand command = new SqlCommand("SP_E_CALENDARIO_VISITA_INFORME_DATOS", BaseDatos.Conexion());
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                
            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        private static ResultadoTransaccion EliminarUsuarioParaRespuestaInformeVisita(clsVisitaInforme informe, SqlTransaction transaction)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_E_CALENDARIO_VISITA_INFORME_COMENTARIO_USUARIO");
                objParams[0].Value = informe.Id;

                SqlCommand command = new SqlCommand("SP_E_CALENDARIO_VISITA_INFORME_COMENTARIO_USUARIO", BaseDatos.Conexion());
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        public static ResultadoTransaccion ValidarUsuarioEnOtraVisita(Entidades.Usuarios.clsUsuario usuario, DateTime inicio, DateTime termino, Int64 IdVisita)
        {
            SqlDataReader dreader = null;
            resTransaccion = new ResultadoTransaccion();
            
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_C_CALENDARIO_VISITA_ASISTENTE_EN_OTRA_VISITA");
                objParams[0].Value = usuario.Id;
                objParams[1].Value = inicio;
                objParams[2].Value = termino;
                objParams[3].Value = IdVisita;

                SqlCommand command = new SqlCommand("SP_C_CALENDARIO_VISITA_ASISTENTE_EN_OTRA_VISITA", BaseDatos.Conexion());
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                
                clsUsuario asistente = null;
                IList<clsUsuario> asistentes = new List<clsUsuario>();

                while (dreader.Read())
                {
                    asistente = new clsUsuario();
                    asistente.Id = Convert.ToInt64(dreader["Id"]);
                    asistente.Nombre = dreader["Nombres"].ToString();
                    asistente.ApellidoPaterno = dreader["ApellidoPaterno"].ToString();
                    asistente.ApellidoMaterno = dreader["ApellidoMaterno"].ToString();
                    asistentes.Add(asistente);                    
                }

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.ObjetoTransaccion = asistentes;

            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                Log.EscribirLog(ex.Message);
            }
            finally
            {
                BaseDatos.CerrarConexion();
            }

            return resTransaccion;
        }

        public static ResultadoTransaccion GuardarInformeVisita(clsVisitaInforme informe)
        {

            SqlTransaction transaction = BaseDatos.Conexion().BeginTransaction();
            ResultadoTransaccion resSalida = new ResultadoTransaccion();

            try
            {
                resTransaccion = new ResultadoTransaccion();
                resTransaccion = AgregarInformVisita(informe, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Aceptada)
                {
                    Int64 idInforme = 0;
                    idInforme = (Int64)resTransaccion.ObjetoTransaccion;
                    informe.Id = idInforme;

                    foreach (clsVisitaInformeProductos producto in informe.Productos)
                    {
                        resTransaccion = new ResultadoTransaccion();
                        resTransaccion = AgregarProductoInformVisita(producto.Producto.Id, idInforme, transaction);
                        if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                            throw new Exception(resTransaccion.Descripcion);
                    }

                    foreach (clsVisitaInformeTrafico trafico in informe.Traficos)
                    {
                        resTransaccion = new ResultadoTransaccion();
                        resTransaccion = AgregarTraficoInformVisita(trafico.Trafico.Id, idInforme, transaction);
                        if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                            throw new Exception(resTransaccion.Descripcion);                        
                    }

                    foreach (var param in informe.UsuariosParaRespuesta)
                    {
                        param.IdInforme = idInforme;
                        resTransaccion = new ResultadoTransaccion();
                        resTransaccion = AgregarUsuarioRequiereRespuesta(param, transaction);
                        if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                            throw new Exception(resTransaccion.Descripcion);
                    }

                    resTransaccion = new ResultadoTransaccion();
                    informe.FollowUp.IdInformeVisita = informe.Id;
                    resTransaccion = Clientes.clsClienteMasterADO.AgregarFollowUpClienteMaster(informe.FollowUp,
                                                                                               transaction);
                    if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resTransaccion.Descripcion);


                    transaction.Commit();

                    informe.Id = idInforme;
                    resSalida.Estado = Enums.EstadoTransaccion.Aceptada;
                    resSalida.ObjetoTransaccion = informe;
                    
                }
                else
                {
                    throw new Exception(resTransaccion.Descripcion);
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                resSalida.Estado = Enums.EstadoTransaccion.Rechazada;
                resSalida.Descripcion = ex.Message;
            }
            finally
            {
                BaseDatos.CerrarConexion();
            }

            return resSalida;

        }

        public static ResultadoTransaccion ActualizarInformeVisita(clsVisitaInforme informe)
        {

            SqlTransaction transaction = BaseDatos.Conexion().BeginTransaction();
            ResultadoTransaccion resSalida = new ResultadoTransaccion();

            try
            {
                resTransaccion = new ResultadoTransaccion();
                resTransaccion = ModificarInformVisita(informe, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Aceptada)
                {

                    resTransaccion = new ResultadoTransaccion();
                    resTransaccion = EliminarDatosInformeVisita(informe, transaction);
                    if(resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    {
                        throw new Exception(resTransaccion.Descripcion);
                    }

                    foreach (clsVisitaInformeProductos producto in informe.Productos)
                    {
                        resTransaccion = new ResultadoTransaccion();
                        resTransaccion = AgregarProductoInformVisita(producto.Producto.Id, informe.Id, transaction);
                        if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                            throw new Exception(resTransaccion.Descripcion);
                    }

                    foreach (clsVisitaInformeTrafico trafico in informe.Traficos)
                    {
                        resTransaccion = new ResultadoTransaccion();
                        resTransaccion = AgregarTraficoInformVisita(trafico.Trafico.Id, informe.Id, transaction);
                        if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                            throw new Exception(resTransaccion.Descripcion);
                    }

                    resTransaccion = new ResultadoTransaccion();
                    resTransaccion = EliminarUsuarioParaRespuestaInformeVisita(informe, transaction);
                    if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    {
                        throw new Exception(resTransaccion.Descripcion);
                    }

                    foreach (var param in informe.UsuariosParaRespuesta)
                    {
                        param.IdInforme = informe.Id;
                        resTransaccion = new ResultadoTransaccion();
                        resTransaccion = AgregarUsuarioRequiereRespuesta(param, transaction);
                        if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                            throw new Exception(resTransaccion.Descripcion);
                    }

                    resTransaccion = new ResultadoTransaccion();
                    resTransaccion =
                        AccesoDatos.Clientes.clsClienteMasterADO.ModificarFollowUpClienteMaster(informe.FollowUp,transaction);
                    if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    {
                        throw new Exception(resTransaccion.Descripcion);
                    }


                    transaction.Commit();
                    
                    resSalida.Estado = Enums.EstadoTransaccion.Aceptada;
                    resSalida.ObjetoTransaccion = informe;

                }
                else
                {
                    throw new Exception(resTransaccion.Descripcion);
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                resSalida.Estado = Enums.EstadoTransaccion.Rechazada;
                resSalida.Descripcion = ex.Message;
            }
            finally
            {
                BaseDatos.CerrarConexion();
            }

            return resSalida;

        }

        private static ResultadoTransaccion AgregarInformVisita(clsVisitaInforme informe, SqlTransaction transaction)
        {
            Int64 idInformeVisita = 0;
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_N_CALENDARIO_VISITA_INFORME");
                objParams[0].Value = informe.Visita.Id;
                objParams[1].Value = informe.EspectativaCierre;
                objParams[2].Value = informe.FollowUp.FechaFollowUp;
                objParams[3].Value = informe.ResumenVisita;
                objParams[4].Value = informe.IdUsuario;
                objParams[5].Value = informe.TieneEspectativaCierre;
                objParams[6].Value = informe.OtroTema;
                objParams[7].Value = informe.EsBorrador;
                
                SqlCommand command = new SqlCommand("SP_N_CALENDARIO_VISITA_INFORME", BaseDatos.Conexion());
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                idInformeVisita = Convert.ToInt64(command.ExecuteScalar());

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.ObjetoTransaccion = idInformeVisita;

                //Registrar Actividad
                LogActividadUsuarios log = new LogActividadUsuarios(informe.GetType().ToString(), idInformeVisita, Enums.TipoActividadUsuario.Creo, Base.Usuario.UsuarioConectado.Usuario);
                LogActividades.clsLogActividadUsuariosADO.GuardaActividad(log);

            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        private static ResultadoTransaccion ModificarInformVisita(clsVisitaInforme informe, SqlTransaction transaction)
        {
            Int64 idInformeVisita = 0;
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_A_CALENDARIO_VISITA_INFORME");
                objParams[0].Value = informe.Visita.Id;
                objParams[1].Value = informe.EspectativaCierre;
                objParams[2].Value = informe.FollowUp.FechaFollowUp;
                objParams[3].Value = informe.ResumenVisita;
                objParams[4].Value = informe.IdUsuario;
                objParams[5].Value = informe.TieneEspectativaCierre;
                objParams[6].Value = informe.OtroTema;
                objParams[7].Value = informe.EsBorrador;
                objParams[8].Value = informe.Id;
                objParams[9].Value = informe.RequiereRespuesta;
                

                SqlCommand command = new SqlCommand("SP_A_CALENDARIO_VISITA_INFORME", BaseDatos.Conexion());
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                
                //Registrar Actividad
                LogActividadUsuarios log = new LogActividadUsuarios(informe.GetType().ToString(), idInformeVisita, Enums.TipoActividadUsuario.Edito, Base.Usuario.UsuarioConectado.Usuario);
                LogActividades.clsLogActividadUsuariosADO.GuardaActividad(log);

            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        private static ResultadoTransaccion AgregarProductoInformVisita(Int64 IdProducto, Int64 IdInforme, SqlTransaction transaction)
        {
            Int64 idVisita = 0;
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_N_CALENDARIO_VISITA_INFORME_PRODUCTO");
                objParams[0].Value = IdInforme;
                objParams[1].Value = IdProducto;

                SqlCommand command = new SqlCommand("SP_N_CALENDARIO_VISITA_INFORME_PRODUCTO", BaseDatos.Conexion());
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                idVisita = Convert.ToInt64(command.ExecuteScalar());

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.ObjetoTransaccion = idVisita;

            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        private static ResultadoTransaccion AgregarTraficoInformVisita(Int64 IdTrafico, Int64 IdInforme, SqlTransaction transaction)
        {
            Int64 idVisita = 0;
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_N_CALENDARIO_VISITA_INFORME_TRAFICO");
                objParams[0].Value = IdInforme;
                objParams[1].Value = IdTrafico;

                SqlCommand command = new SqlCommand("SP_N_CALENDARIO_VISITA_INFORME_TRAFICO", BaseDatos.Conexion());
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                idVisita = Convert.ToInt64(command.ExecuteScalar());

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.ObjetoTransaccion = idVisita;

            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        public static ResultadoTransaccion ObtenerInformeVisitaPor(Int64 IdInforme, Int64 IdVisita)
        {
            clsVisitaInforme informe = null;
            resTransaccion = new ResultadoTransaccion();
            SqlConnection cnn = BaseDatos.NuevaConexion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(cnn, "SP_C_CALENDARIO_VISITA_INFORME");
                objParams[0].Value = IdInforme;
                objParams[1].Value = IdVisita;


                DataSet ds = SqlHelper.ExecuteDataset(cnn, CommandType.StoredProcedure, "SP_C_CALENDARIO_VISITA_INFORME", objParams);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    informe = new clsVisitaInforme();
                    informe.Id = Convert.ToInt64(ds.Tables[0].Rows[0]["Id"]);
                    //informe.Visita = ObtenerVisitaPorId(Convert.ToInt64(ds.Tables[0].Rows[0]["IdVisita"].ToString()));

                    if (ds.Tables[0].Rows[0]["EspectativaCierre"] is DBNull)
                        informe.EspectativaCierre = -1;
                    else 
                        informe.EspectativaCierre = Convert.ToInt16(ds.Tables[0].Rows[0]["EspectativaCierre"].ToString());
                    
                    informe.ResumenVisita = ds.Tables[0].Rows[0]["ResumenVisita"].ToString();
                    informe.IdUsuario = Convert.ToInt64(ds.Tables[0].Rows[0]["IdUsuario"].ToString());
                    informe.Productos = ObtenerProductosInformeVisita(informe.Id);
                    informe.Traficos = ObtenerTraficosInformeVisita(informe.Id);
                    if (ds.Tables[0].Rows[0]["TieneEspectativaCierre"] is DBNull)
                        informe.TieneEspectativaCierre = false;
                    else
                        informe.TieneEspectativaCierre =
                            Convert.ToBoolean(ds.Tables[0].Rows[0]["TieneEspectativaCierre"]);

                    if (ds.Tables[0].Rows[0]["OtroTema"] is DBNull)
                        informe.OtroTema = false;
                    else
                        informe.OtroTema = Convert.ToBoolean(ds.Tables[0].Rows[0]["OtroTema"]);


                    if (ds.Tables[0].Rows[0]["RequiereRespuesta"] is DBNull)
                        informe.RequiereRespuesta = false;
                    else
                        informe.RequiereRespuesta = Convert.ToBoolean(ds.Tables[0].Rows[0]["RequiereRespuesta"]);

                    if (ds.Tables[0].Rows[0]["EsBorrador"] is DBNull)
                        informe.EsBorrador = false;
                    else
                        informe.EsBorrador = Convert.ToBoolean(ds.Tables[0].Rows[0]["EsBorrador"]);

                    var FollowUP = AccesoDatos.Clientes.clsClienteMasterADO.ObtenerFollowUpClientePorInforme(informe.Id);

                    if(FollowUP != null)
                    {
                        informe.FollowUp = FollowUP[0];
                    }

                    //if (ds.Tables[0].Rows[0]["FechaFollowUp"] is DBNull)
                    //    informe.FollowUp = null;
                    //else
                    //    informe.FollowUp = Convert.ToDateTime(ds.Tables[0].Rows[0]["FechaFollowUp"].ToString());

                }

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.ObjetoTransaccion = informe;
            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                Log.EscribirLog(ex.Message);
            }
            finally
            {
                cnn.Close();                
            }

            return resTransaccion;
        }

        private static IList<clsVisitaInformeProductos> ObtenerProductosInformeVisita(Int64 IdInforme)
        {
            clsVisitaInformeProductos producto = null;
            IList<clsVisitaInformeProductos> lista = new List<clsVisitaInformeProductos>();
            SqlConnection con = BaseDatos.NuevaConexion();

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(con, "SP_C_CALENDARIO_VISITA_INFORME_PRODUCTOS");
                objParams[0].Value = IdInforme;

                DataSet ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "SP_C_CALENDARIO_VISITA_INFORME_PRODUCTOS", objParams);

                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        producto = new clsVisitaInformeProductos();
                        producto.Id = Convert.ToInt64(item["Id"]);
                        producto.Producto.Id = Convert.ToInt64(item["IdProducto"].ToString());
                        producto.Producto.Nombre = item["Descripcion"].ToString();

                        lista.Add(producto);
                    }                                       
                }
            }
            catch (Exception ex)
            {                
                Log.EscribirLog(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return lista;
        }

        private static IList<clsVisitaInformeTrafico> ObtenerTraficosInformeVisita(Int64 IdInforme)
        {
            clsVisitaInformeTrafico trafico = null;
            IList<clsVisitaInformeTrafico> lista = new List<clsVisitaInformeTrafico>();
            SqlConnection con = BaseDatos.NuevaConexion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(con, "SP_C_CALENDARIO_VISITA_INFORME_TRAFICOS");
                objParams[0].Value = IdInforme;

                DataSet ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "SP_C_CALENDARIO_VISITA_INFORME_TRAFICOS", objParams);

                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        trafico = new clsVisitaInformeTrafico();
                        trafico.Id = Convert.ToInt64(item["Id"]);
                        trafico.Trafico.Id = Convert.ToInt64(item["IdTrafico"].ToString());
                        //trafico.Producto.Nombre = item["Descripcion"].ToString();

                        lista.Add(trafico);
                    }

                }
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return lista;
        }


        #region "Informe"

        public static IList<clsVisitaEstado> ListarVisitaEstados()
        {
            SqlDataReader dreader = null;
            clsVisitaEstado estado = null;
            IList<clsVisitaEstado> listestados = new List<clsVisitaEstado>();

            try
            {
                SqlCommand command = new SqlCommand("SP_C_CALENDARIO_LISTAR_ESTADOS", BaseDatos.Conexion());                
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    estado = new clsVisitaEstado();
                    estado.Id = Convert.ToInt64(dreader["Id"]);
                    estado.Nombre = dreader["Descripcion"].ToString();

                    listestados.Add(estado);

                }

            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);
            }
            finally
            {
                BaseDatos.CerrarConexion();
            }

            return listestados;

        }

        public static IList<clsVisita> ListarVisitasInforme(Int64 IdVendedor, Int64 IdCliente,DateTime fechadesde, DateTime fechahasta, Int64 estado)
        {
            SqlDataReader dreader = null;
            clsVisita visita = null;
            IList<clsVisita> listvisitas = new List<clsVisita>();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_C_CALENDARIO_VISITAS_INFORME");
                objParams[0].Value = IdVendedor;
                objParams[1].Value = IdCliente;
                objParams[2].Value = fechadesde;
                objParams[3].Value = fechahasta;
                objParams[4].Value = estado;
                
                SqlCommand command = new SqlCommand("SP_C_CALENDARIO_VISITAS_INFORME", BaseDatos.Conexion());
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    visita = new clsVisita();
                    visita.Id = Convert.ToInt64(dreader["IdVisita"]);
                    visita.Vendedor.Nombre = dreader["NombreVendedor"].ToString();
                    visita.Vendedor.ApellidoPaterno = dreader["PaternoVendedor"].ToString();
                    visita.Vendedor.ApellidoMaterno = dreader["MaternoVendedor"].ToString();

                    visita.Cliente.NombreCompañia = dreader["NombreCompania"].ToString();
                    visita.Cliente.NombreFantasia = dreader["NombreFantasia"].ToString();
                    visita.Cliente.ProductosPreferidos =
                        AccesoDatos.Clientes.clsClienteMasterADO.ObtenerProductosPreferidos(Convert.ToInt64(dreader["IdCliente"]));

                    if (visita.Cliente.NombreFantasia == "")
                        visita.Cliente.NombreFantasia = visita.Cliente.NombreCompañia;

                    visita.NivelImportancia =
                        Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["NivelImportancia"]));
                    visita.FechaHoraComienzo = Convert.ToDateTime(dreader["FechaHoraComienzo"].ToString());
                    visita.FechaHoraTermino = Convert.ToDateTime(dreader["FechaHoraTermino"].ToString());
                    visita.EstadoBD = (Enums.VisitaEstado)Convert.ToInt16(dreader["IdEstado"]);
                    visita.EstadoVista = Convert.ToInt16(dreader["EstadoCalendario"]);
                    visita.EsReplanificada = Convert.ToBoolean(dreader["EsReplanificada"]);
                    visita.Asunto = dreader["Asunto"].ToString();
                    visita.Ubicacion = dreader["Ubicacion"].ToString();
                    visita.UsuarioOrganizador =
                        Usuarios.clsUsuarioADO.ObtenerUsuarioPorId(Convert.ToInt16(dreader["IdUsuario"]));

                    ResultadoTransaccion res = new ResultadoTransaccion();
                    res = ObtenerInformeVisitaPor(-1, Convert.ToInt64(dreader["IdVisita"]));
                    if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                        visita.Informvisita = (clsVisitaInforme) res.ObjetoTransaccion;

                    //visita.Descripcion = dreader["Descripcion"].ToString();
                    //visita.NivelImportancia = Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["NivelImportancia"]));                                        
                    //visita.Asistentes = ObtenerAsistentesDeVisita(visita.Id);
                    listvisitas.Add(visita);
                }

            }
            catch (Exception ex)
            {
                Base.Log.Log.EscribirLog(ex.Message);
            }
            finally
            {
                BaseDatos.CerrarConexion();
            }

            return listvisitas;
        }

        #endregion


        #region "Proceso Actualizar Estados"

        public static ResultadoTransaccion ProcesoActualizarEstados()
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                SqlCommand command = new SqlCommand("SP_JOB_VALIDA_VISITAS_NO_REALIZADAS", BaseDatos.Conexion());                                
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        #endregion

        #region "Log Emails"

        public static ResultadoTransaccion LogEmailVisita(Entidades.Emails.clsEmail email)
        {            
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_N_CALENDARIO_LOG_EMAIL");
                objParams[0].Value = email.Visita.Id;
                objParams[1].Value = email.Visita.EstadoBDOld;
                objParams[2].Value = email.Visita.EstadoBD;
                objParams[3].Value = email.Asunto;
                objParams[4].Value = email.Cuerpo;
                objParams[5].Value = email.Emisor;
                objParams[6].Value = email.Receptores;
                objParams[7].Value = Base.Usuario.UsuarioConectado.Usuario.Id;
                objParams[8].Value = email.TipoEmail;
                
                SqlCommand command = new SqlCommand("SP_N_CALENDARIO_LOG_EMAIL", BaseDatos.Conexion());                
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                
            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        #endregion

        #region "Respuestas y Comentarios"

        public static ResultadoTransaccion AgregarUsuarioRequiereRespuesta(clsInformeRespuestaUsuario usuario, SqlTransaction transaction)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_CALENDARIO_VISITA_INFORME_COMENTARIO_USUARIO");
                objParams[0].Value = usuario.IdComentario;
                objParams[1].Value = usuario.IdInforme;
                objParams[2].Value = usuario.Usuario.Id;
                
                SqlCommand command = new SqlCommand("SP_CALENDARIO_VISITA_INFORME_COMENTARIO_USUARIO", BaseDatos.Conexion());
                command.Parameters.AddRange(objParams);
                command.Transaction = transaction;
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }


        public static ResultadoTransaccion AgregarComentarioInformeVisita(clsInformeComentario comentario)
        {
            resTransaccion = new ResultadoTransaccion();
            
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_N_CALENDARIO_VISITA_INFORME_COMENTARIO");
                objParams[0].Value = comentario.Usuario.Id;
                objParams[1].Value = comentario.IdInforme;
                objParams[2].Value = comentario.Comentario;

                SqlCommand command = new SqlCommand("SP_N_CALENDARIO_VISITA_INFORME_COMENTARIO", BaseDatos.Conexion());                
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                comentario.Id = Convert.ToInt64(command.ExecuteScalar());

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;

                //Registrar Actividad
                LogActividadUsuarios log = new LogActividadUsuarios(comentario.GetType().ToString(), comentario.Id, Enums.TipoActividadUsuario.Creo, Base.Usuario.UsuarioConectado.Usuario);
                LogActividades.clsLogActividadUsuariosADO.GuardaActividad(log);
            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        public static IList<clsInformeComentario> ListarComentariosVisita(Int64 IdVisita)
        {
            SqlDataReader dreader = null;
            clsInformeComentario comentario = null;
            IList<clsInformeComentario> listcomentarios = new List<clsInformeComentario>();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_C_CALENDARIO_VISITA_INFORME_COMENTARIO");
                objParams[0].Value = IdVisita;
                
                SqlCommand command = new SqlCommand("SP_C_CALENDARIO_VISITA_INFORME_COMENTARIO", BaseDatos.Conexion());
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    comentario = new clsInformeComentario();
                    comentario.Id = Convert.ToInt64(dreader["Id"]);
                    comentario.IdInforme = Convert.ToInt64(dreader["IdInforme"]);

                    comentario.Usuario =
                        AccesoDatos.Usuarios.clsUsuarioADO.ObtenerUsuarioPorId(Convert.ToInt16(dreader["IdUsuario"]));

                    //comentario.Usuario.Id = Convert.ToInt64(dreader["IdUsuario"]);
                    //comentario.Usuario.Nombre = dreader["Nombres"].ToString();
                    //comentario.Usuario.ApellidoPaterno = dreader["ApellidoPaterno"].ToString();
                    //comentario.Usuario.ApellidoMaterno = dreader["ApellidoMaterno"].ToString();
                    comentario.Comentario = dreader["Comentario"].ToString();
                    comentario.FechaComentario = (DateTime) dreader["FechaComentario"];
                    listcomentarios.Add(comentario);                    
                }

            }
            catch (Exception ex)
            {
                Base.Log.Log.EscribirLog(ex.Message);
            }
            finally
            {
                BaseDatos.CerrarConexion();
            }

            return listcomentarios;
        }

        public static IList<clsInformeRespuestaUsuario> ListarUsuariosParaRespuestaInforme(clsVisitaInforme informe)
        {
            SqlDataReader dreader = null;
            clsInformeRespuestaUsuario comentario = null;
            IList<clsInformeRespuestaUsuario> listcomentarios = new List<clsInformeRespuestaUsuario>();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_C_CALENDARIO_VISITA_INFORME_COMENTARIO_USUARIO");
                if (informe != null) objParams[0].Value = informe.Id;

                SqlCommand command = new SqlCommand("SP_C_CALENDARIO_VISITA_INFORME_COMENTARIO_USUARIO", BaseDatos.Conexion());
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    comentario = new clsInformeRespuestaUsuario();
                    comentario.Id = Convert.ToInt64(dreader["Id"]);
                    comentario.IdInforme = Convert.ToInt64(dreader["IdInforme"]);                    
                    comentario.Usuario =
                        Usuarios.clsUsuarioADO.ObtenerUsuarioPorId(Convert.ToInt16(dreader["IdUsuario"]));
                                       
                    listcomentarios.Add(comentario);
                }

            }
            catch (Exception ex)
            {
                Base.Log.Log.EscribirLog(ex.Message);
            }
            finally
            {
                BaseDatos.CerrarConexion();
            }

            return listcomentarios;
        }

        #endregion
    }
}
