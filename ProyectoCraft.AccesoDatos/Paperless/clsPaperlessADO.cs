using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Paperless;
using System.Data;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Usuarios;

namespace ProyectoCraft.AccesoDatos.Paperless
{
    public class clsPaperlessADO
    {
        private static SqlParameter[] objParams = null;
        private static SqlConnection conn = null;
        private static SqlDataReader dreader = null;
        private static ResultadoTransaccion resTransaccion = null;



        public static IList<PaperlessNaviera> ObtenerNavieras(Enums.Estado estado)
        {
            PaperlessNaviera naviera = null;
            IList<PaperlessNaviera> listNavieras = new List<PaperlessNaviera>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_L_PAPERLESS_NAVIERA");
                objParams[0].Value = estado;
                SqlCommand command = new SqlCommand("SP_L_PAPERLESS_NAVIERA", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    naviera = new PaperlessNaviera();
                    naviera.Id = Convert.ToInt64(dreader["Id"]);
                    naviera.Nombre = dreader["Descripcion"].ToString();
                    //naviera.Activo = (Entidades.Enums.Enums.Estado)(Convert.ToInt16(dreader["Activo"]));
                    listNavieras.Add(naviera);
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

            return listNavieras;
        }

        public static IList<PaperlessAgente> ObtenerAgentes(Enums.Estado estado)
        {
            PaperlessAgente agente = null;
            IList<PaperlessAgente> listagentes = new List<PaperlessAgente>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_L_PAPERLESS_AGENTE");
                objParams[0].Value = estado;
                SqlCommand command = new SqlCommand("SP_L_PAPERLESS_AGENTE", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    agente = new PaperlessAgente();
                    agente.Id = Convert.ToInt64(dreader["Id"]);
                    agente.Nombre = dreader["Descripcion"].ToString();
                    agente.Contacto = dreader["Contacto"].ToString();
                    agente.Email = dreader["Email"].ToString();
                    agente.Alias = dreader["Alias"].ToString();
                    agente.Activo = true;
                    //agente.FechaCreacion = Convert.ToDateTime(dreader["FechaCreacion"]);
                    listagentes.Add(agente);
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

            return listagentes;
        }

        public static IList<PaperlessNave> ObtenerNaves(Enums.Estado estado)
        {
            PaperlessNave nave = null;
            IList<PaperlessNave> listnaves = new List<PaperlessNave>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_L_PAPERLESS_NAVE");
                objParams[0].Value = estado;
                SqlCommand command = new SqlCommand("SP_L_PAPERLESS_NAVE", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    nave = new PaperlessNave();
                    nave.Id = Convert.ToInt64(dreader["Id"]);
                    nave.Nombre = dreader["Descripcion"].ToString();
                    // nave.FechaCreacion = Convert.ToDateTime(dreader["FechaCreacion"]);
                    listnaves.Add(nave);
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

            return listnaves;
        }

        public static IList<PaperlessFlujo> ObtenerAsignaciones(DateTime desde, DateTime hasta, Int64 usuario1, Int64 usuario2, string estado,
            string numconsolidado, string nave, DateTime desdeEmbarcadores, DateTime hastaEmbarcadores, DateTime desdeNavieras, DateTime hastaNavieras,
            string nummaster)
        {
            PaperlessFlujo flujopaperless = null;
            IList<PaperlessFlujo> listasignaciones = new List<PaperlessFlujo>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_L_PAPERLESS_ASIGNACION");
                objParams[0].Value = desde;
                objParams[1].Value = hasta;
                objParams[2].Value = usuario1;
                objParams[3].Value = usuario2;
                objParams[4].Value = estado;
                objParams[5].Value = numconsolidado;
                objParams[6].Value = nave;
                objParams[7].Value = desdeEmbarcadores;
                objParams[8].Value = hastaEmbarcadores;
                objParams[9].Value = desdeNavieras;
                objParams[10].Value = hastaNavieras;
                objParams[11].Value = nummaster;

                SqlCommand command = new SqlCommand("SP_L_PAPERLESS_ASIGNACION", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    flujopaperless = new PaperlessFlujo();
                    flujopaperless.Asignacion.Id = Convert.ToInt64(dreader["Id"]);
                    flujopaperless.Asignacion.NumMaster = dreader["NumMaster"].ToString();
                    flujopaperless.Asignacion.NumHousesBL = Convert.ToInt16(dreader["NumHousesBL"]);
                    flujopaperless.Asignacion.FechaMaster = Convert.ToDateTime(dreader["FechaMaster"]);

                    flujopaperless.Asignacion.UsuarioCreacion = new clsUsuario()
                    {
                        ApellidoPaterno = dreader["UCAP"].ToString(),
                        ApellidoMaterno = dreader["UCAM"].ToString(),
                        Nombre = dreader["UCN"].ToString(),
                        Email = dreader["EmailUC"].ToString()
                    };

                    flujopaperless.Asignacion.Usuario1 = new clsUsuario()
                    {
                        ApellidoPaterno = dreader["APU1"].ToString(),
                        ApellidoMaterno = dreader["AMU1"].ToString(),
                        Nombre = dreader["NU1"].ToString(),
                        Email = dreader["Email1"].ToString()
                    };
                    if (dreader["IdImportancia"] is DBNull)
                        flujopaperless.Asignacion.ImportanciaUsuario1 = null;
                    else
                        flujopaperless.Asignacion.ImportanciaUsuario1 = new clsItemParametro() { Id = Convert.ToInt64(dreader["IdImportancia"].ToString()), Nombre = dreader["Importancia"].ToString() };

                    flujopaperless.Asignacion.Usuario2 = new clsUsuario()
                    {
                        ApellidoPaterno = dreader["APU2"].ToString(),
                        ApellidoMaterno = dreader["AMU2"].ToString(),
                        Nombre = dreader["NU2"].ToString(),
                        Email = dreader["Email2"].ToString()
                    };

                    flujopaperless.EstadoFlujo = (Enums.EstadoPaperless)(int.Parse(dreader["IdEstado"].ToString()));
                    flujopaperless.EstadoFlujoDescripcion = dreader["Estado"].ToString();
                    flujopaperless.Asignacion.Estado = (Enums.EstadoPaperless)(int.Parse(dreader["IdEstado"].ToString()));
                    flujopaperless.Asignacion.FechaCreacion = Convert.ToDateTime(dreader["FechaCreacion"]);
                    flujopaperless.Asignacion.Agente = new PaperlessAgente()
                    {
                        Id = Convert.ToInt64(dreader["IdAgente"]),
                        Nombre = dreader["Agente"].ToString()
                    };
                    flujopaperless.Asignacion.Naviera = new PaperlessNaviera()
                    {
                        Id = Convert.ToInt64(dreader["IdNaviera"]),
                        Nombre = dreader["Naviera"].ToString()
                    };
                    flujopaperless.Asignacion.Nave = new PaperlessNave()
                    {
                        Id = Convert.ToInt64(dreader["IdNave"]),
                        Nombre = dreader["Nave"].ToString()
                    };

                    flujopaperless.Asignacion.NaveTransbordo = new PaperlessNave()
                    {
                        Id = Convert.ToInt64(dreader["IdNaveTransbordo"]),
                        Nombre = dreader["NaveTransbordo"].ToString()
                    };

                    flujopaperless.Asignacion.VersionUsuario1 = Convert.ToInt16(dreader["versionUsuario1"]);

                    flujopaperless.Asignacion.Viaje = dreader["Viaje"].ToString();
                    flujopaperless.Asignacion.TipoCarga = new PaperlessTipoCarga()
                    {
                        Id = Convert.ToInt64(dreader["IdTipoCarga"]),
                        Nombre = dreader["TipoCarga"].ToString()
                    };

                    if (dreader["FechaETA"] is DBNull)
                        flujopaperless.Asignacion.FechaETA = null;
                    else
                        flujopaperless.Asignacion.FechaETA = Convert.ToDateTime(dreader["FechaETA"]);

                    if (dreader["FechaMaximaVinculacion"] is DBNull)
                        flujopaperless.Asignacion.FechaMaximaVinculacion = null;
                    else
                        flujopaperless.Asignacion.FechaMaximaVinculacion = Convert.ToDateTime(dreader["FechaMaximaVinculacion"]);



                    if (dreader["AperturaNavieras"] is DBNull)
                        flujopaperless.Asignacion.AperturaNavieras = null;
                    else
                        flujopaperless.Asignacion.AperturaNavieras = Convert.ToDateTime(dreader["AperturaNavieras"]);

                    if (dreader["PlazoEmbarcadores"] is DBNull)
                        flujopaperless.Asignacion.PlazoEmbarcadores = null;
                    else
                        flujopaperless.Asignacion.PlazoEmbarcadores = Convert.ToDateTime(dreader["PlazoEmbarcadores"]);


                    flujopaperless.Asignacion.ObservacionUsuario1 = dreader["ObservacionUsuario1"].ToString();
                    flujopaperless.Asignacion.ObservacionUsuario2 = dreader["ObservacionUsuario2"].ToString();
                    flujopaperless.Asignacion.DataUsuario1.Paso1HousesBLInfo.NumConsolidado = dreader["NumConsolidado"].ToString();

                    listasignaciones.Add(flujopaperless);
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

            return listasignaciones;
        }

        public static PaperlessAsignacion ObtenerAsignacionPorId(Int64 IdAsignacion)
        {
            PaperlessAsignacion Asignacion = null;
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_PAPERLESS_ASIGNACION_POR_ID");
                objParams[0].Value = IdAsignacion;

                SqlCommand command = new SqlCommand("SP_C_PAPERLESS_ASIGNACION_POR_ID", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    Asignacion = new PaperlessAsignacion();

                    Asignacion.Id = Convert.ToInt64(dreader["Id"]);
                    Asignacion.NumMaster = dreader["NumMaster"].ToString();
                    Asignacion.FechaMaster = Convert.ToDateTime(dreader["FechaMaster"]);

                    if (dreader["IdAgente"] is DBNull)
                        Asignacion.Agente = new PaperlessAgente();
                    else
                        Asignacion.Agente = new PaperlessAgente() { Id = Convert.ToInt64(dreader["IdAgente"]), Nombre = dreader["Agente"].ToString() };

                    if (dreader["IdNaviera"] is DBNull)
                        Asignacion.Naviera = new PaperlessNaviera();
                    else
                        Asignacion.Naviera = new PaperlessNaviera() { Id = Convert.ToInt64(dreader["IdNaviera"]), Nombre = dreader["Naviera"].ToString() };

                    if (dreader["IdNave"] is DBNull)
                        Asignacion.Nave = new PaperlessNave();
                    else
                        Asignacion.Nave = new PaperlessNave() { Id = Convert.ToInt64(dreader["IdNave"]), Nombre = dreader["Nave"].ToString() };

                    if (dreader["IdNaveTransbordo"] is DBNull)
                        Asignacion.NaveTransbordo = new PaperlessNave();
                    else
                        Asignacion.NaveTransbordo = new PaperlessNave() { Id = Convert.ToInt64(dreader["IdNaveTransbordo"]), Nombre = dreader["NaveTransbordo"].ToString() };




                    Asignacion.Viaje = dreader["Viaje"].ToString();
                    Asignacion.NumHousesBL = Convert.ToInt16(dreader["NumHousesBL"]);

                    Asignacion.TipoCarga = new PaperlessTipoCarga() { Id = Convert.ToInt64(dreader["IdTipoCarga"]), Nombre = dreader["TipoCarga"].ToString() };

                    if (dreader["IdTipoServicio"] is DBNull)
                        Asignacion.TipoServicio = null;
                    else
                        Asignacion.TipoServicio = new PaperlessTipoServicio() { Id = Convert.ToInt64(dreader["IdTipoServicio"]), Nombre = dreader["TipoServicio"].ToString() };



                    if (dreader["FechaETA"] is DBNull)
                        Asignacion.FechaETA = null;
                    else
                        Asignacion.FechaETA = Convert.ToDateTime(dreader["FechaETA"]);

                    if (dreader["FechaMaximaVinculacion"] is DBNull)
                        Asignacion.FechaMaximaVinculacion = null;
                    else
                        Asignacion.FechaMaximaVinculacion = Convert.ToDateTime(dreader["FechaMaximaVinculacion"]);

                    if (dreader["AperturaNavieras"] is DBNull)
                        Asignacion.AperturaNavieras = null;
                    else
                        Asignacion.AperturaNavieras = Convert.ToDateTime(dreader["AperturaNavieras"]);

                    if (dreader["PlazoEmbarcadores"] is DBNull)
                        Asignacion.PlazoEmbarcadores = null;
                    else
                        Asignacion.PlazoEmbarcadores = Convert.ToDateTime(dreader["PlazoEmbarcadores"]);

                    if (dreader["Usuario1"] is DBNull)
                        Asignacion.Usuario1 = null;
                    else
                        Asignacion.Usuario1 = new clsUsuario()
                        {
                            Id = Convert.ToInt64(dreader["Usuario1"].ToString()),
                            ApellidoPaterno = dreader["APU1"].ToString(),
                            ApellidoMaterno = dreader["AMU1"].ToString(),
                            Nombre = dreader["NU1"].ToString(),
                            Email = dreader["EmailU1"].ToString()
                        };

                    if (dreader["ObservacionUsuario1"] is DBNull)
                        Asignacion.ObservacionUsuario1 = "";
                    else
                        Asignacion.ObservacionUsuario1 = dreader["ObservacionUsuario1"].ToString();

                    if (dreader["IdImportancia"] is DBNull)
                        Asignacion.ImportanciaUsuario1 = null;
                    else
                        Asignacion.ImportanciaUsuario1 = Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdImportancia"].ToString()));

                    if (dreader["Usuario2"] is DBNull)
                        Asignacion.Usuario2 = null;
                    else
                        Asignacion.Usuario2 = new clsUsuario()
                        {
                            Id = Convert.ToInt64(dreader["Usuario2"].ToString()),
                            ApellidoPaterno = dreader["APU2"].ToString(),
                            ApellidoMaterno = dreader["AMU2"].ToString(),
                            Nombre = dreader["NU2"].ToString(),
                            Email = dreader["EmailU2"].ToString()
                        };

                    if (dreader["ObservacionUsuario2"] is DBNull)
                        Asignacion.ObservacionUsuario2 = "";
                    else
                        Asignacion.ObservacionUsuario2 = dreader["ObservacionUsuario2"].ToString();

                    Asignacion.EstadoDescripcion = dreader["Estado"].ToString();
                    Asignacion.Estado = (Enums.EstadoPaperless)Convert.ToInt16(dreader["IdEstado"].ToString());

                    Asignacion.FechaCreacion = Convert.ToDateTime(dreader["FechaCreacion"]);
                    Asignacion.FechaPaso1 = Convert.ToDateTime(dreader["FechaPaso1"]);
                    if (!(dreader["FechaPaso2"] is DBNull))
                        Asignacion.FechaPaso2 = Convert.ToDateTime(dreader["FechaPaso2"]);
                    if (!(dreader["FechaPaso3"] is DBNull))
                        Asignacion.FechaPaso3 = Convert.ToDateTime(dreader["FechaPaso3"]);

                    if (!(dreader["Courier"] is DBNull))
                        Asignacion.ChkCourier = Convert.ToBoolean(dreader["Courier"]);

                    if (!(dreader["EnDestino"] is DBNull))
                        Asignacion.ChkEnDestino = Convert.ToBoolean(dreader["EnDestino"]);

                    if (!(dreader["MasterConfirmado"] is DBNull))
                        Asignacion.ChkMasterConfirmado = Convert.ToBoolean(dreader["MasterConfirmado"]);

                    if (!(dreader["FechaMasterConfirmado"] is DBNull))
                        Asignacion.FechaMasterConfirmado = Convert.ToDateTime(dreader["FechaMasterConfirmado"]);

                    if (!(dreader["txtCourier"] is DBNull))
                        Asignacion.TxtCourier = dreader["txtCourier"].ToString();

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

            return Asignacion;
        }

        public static ResultadoTransaccion GuardaPaso1(PaperlessAsignacion paso1)
        {
            ResultadoTransaccion resultado = new ResultadoTransaccion();
            conn = Base.BaseDatos.BaseDatos.NuevaConexion();
            SqlTransaction transaction = conn.BeginTransaction();


            try
            {
                if (paso1.Agente != null && paso1.Agente.IsNew)
                {
                    resultado = new ResultadoTransaccion();
                    resultado = GuardaNuevoAgente(paso1.Agente, conn, transaction);
                    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                    {
                        throw new Exception(resultado.Descripcion);
                    }
                    else
                    {
                        paso1.Agente.Id = Convert.ToInt64(resultado.ObjetoTransaccion);
                    }
                }

                if (paso1.Naviera != null && paso1.Naviera.IsNew)
                {
                    resultado = new ResultadoTransaccion();
                    resultado = GuardaNuevaNaviera(paso1.Naviera, conn, transaction);
                    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                    {
                        throw new Exception(resultado.Descripcion);
                    }
                    else
                    {
                        paso1.Naviera.Id = Convert.ToInt64(resultado.ObjetoTransaccion);
                    }
                }

                if (paso1.Nave != null && paso1.Nave.IsNew)
                {
                    resultado = new ResultadoTransaccion();
                    resultado = GuardaNuevaNave(paso1.Nave, conn, transaction);
                    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                    {
                        throw new Exception(resultado.Descripcion);
                    }
                    else
                    {
                        paso1.Nave.Id = Convert.ToInt64(resultado.ObjetoTransaccion);
                    }
                }

                if (paso1.NaveTransbordo != null && paso1.NaveTransbordo.IsNew)
                {
                    resultado = new ResultadoTransaccion();
                    resultado = GuardaNuevaNave(paso1.NaveTransbordo, conn, transaction);
                    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                    {
                        throw new Exception(resultado.Descripcion);
                    }
                    else
                    {
                        paso1.NaveTransbordo.Id = Convert.ToInt64(resultado.ObjetoTransaccion);
                    }
                }

                resultado = new ResultadoTransaccion();
                resultado = AsignacionPaso1(paso1, conn, transaction);
                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                {
                    throw new Exception(resultado.Descripcion);
                }
                else
                {
                    paso1.Id = Convert.ToInt64(resultado.ObjetoTransaccion);
                }

                transaction.Commit();
                resultado.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                resultado.Estado = Enums.EstadoTransaccion.Rechazada;
                resultado.Descripcion = ex.Message;
            }
            finally
            {
                BaseDatos.CerrarConexion();
            }

            return resultado;
        }

        public static ResultadoTransaccion AsignacionActualizarPaso1(PaperlessAsignacion paso1)
        {
            ResultadoTransaccion resultado = new ResultadoTransaccion();
            conn = Base.BaseDatos.BaseDatos.NuevaConexion();
            SqlTransaction transaction = conn.BeginTransaction();


            try
            {
                if (paso1.Agente != null && paso1.Agente.IsNew)
                {
                    resultado = new ResultadoTransaccion();
                    resultado = GuardaNuevoAgente(paso1.Agente, conn, transaction);
                    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                    {
                        throw new Exception(resultado.Descripcion);
                    }
                    else
                    {
                        paso1.Agente.Id = Convert.ToInt64(resultado.ObjetoTransaccion);
                    }
                }

                if (paso1.Naviera != null && paso1.Naviera.IsNew)
                {
                    resultado = new ResultadoTransaccion();
                    resultado = GuardaNuevaNaviera(paso1.Naviera, conn, transaction);
                    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                    {
                        throw new Exception(resultado.Descripcion);
                    }
                    else
                    {
                        paso1.Naviera.Id = Convert.ToInt64(resultado.ObjetoTransaccion);
                    }
                }

                if (paso1.Nave != null && paso1.Nave.IsNew)
                {
                    resultado = new ResultadoTransaccion();
                    resultado = GuardaNuevaNave(paso1.Nave, conn, transaction);
                    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                    {
                        throw new Exception(resultado.Descripcion);
                    }
                    else
                    {
                        paso1.Nave.Id = Convert.ToInt64(resultado.ObjetoTransaccion);
                    }
                }

                resultado = new ResultadoTransaccion();
                resultado = ActualizaAsignacionPaso1(paso1, conn, transaction);
                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resultado.Descripcion);



                transaction.Commit();
                resultado.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                resultado.Estado = Enums.EstadoTransaccion.Rechazada;
                resultado.Descripcion = ex.Message;
            }
            finally
            {
                BaseDatos.CerrarConexion();
            }

            return resultado;
        }

        private static ResultadoTransaccion GuardaNuevoAgente(PaperlessAgente agente, SqlConnection connparam, SqlTransaction tranparam)
        {
            Int64 idagente = 0;
            resTransaccion = new ResultadoTransaccion();
            try
            {

                objParams = SqlHelperParameterCache.GetSpParameterSet(connparam, "SP_N_PAPERLESS_AGENTEV2");
                objParams[0].Value = agente.Nombre;
                objParams[1].Value = agente.Activo;

                SqlCommand command = new SqlCommand("SP_N_PAPERLESS_AGENTEV2", connparam);
                command.Transaction = tranparam;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                idagente = Convert.ToInt64(command.ExecuteScalar());

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.ObjetoTransaccion = idagente;

            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        private static ResultadoTransaccion GuardaNuevaNaviera(PaperlessNaviera naviera, SqlConnection connparam, SqlTransaction tranparam)
        {
            Int64 idnaviera = 0;
            resTransaccion = new ResultadoTransaccion();
            try
            {

                objParams = SqlHelperParameterCache.GetSpParameterSet(connparam, "SP_N_PAPERLESS_NAVIERA");
                objParams[0].Value = naviera.Nombre;
                objParams[1].Value = naviera.Activo;

                SqlCommand command = new SqlCommand("SP_N_PAPERLESS_NAVIERA", connparam);
                command.Transaction = tranparam;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                idnaviera = Convert.ToInt64(command.ExecuteScalar());

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.ObjetoTransaccion = idnaviera;

            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        private static ResultadoTransaccion GuardaNuevaNave(PaperlessNave nave, SqlConnection connparam, SqlTransaction tranparam)
        {
            Int64 idnave = 0;
            resTransaccion = new ResultadoTransaccion();
            try
            {

                objParams = SqlHelperParameterCache.GetSpParameterSet(connparam, "SP_N_PAPERLESS_NAVE");
                objParams[0].Value = nave.Nombre;
                objParams[1].Value = nave.Activo;

                SqlCommand command = new SqlCommand("SP_N_PAPERLESS_NAVE", connparam);
                command.Transaction = tranparam;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                idnave = Convert.ToInt64(command.ExecuteScalar());

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.ObjetoTransaccion = idnave;

            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        private static ResultadoTransaccion AsignacionPaso1(PaperlessAsignacion AsignacionPaso1, SqlConnection connparam, SqlTransaction tranparam)
        {
            Int64 idAsignacion = 0;
            resTransaccion = new ResultadoTransaccion();
            try
            {

                objParams = SqlHelperParameterCache.GetSpParameterSet(connparam, "SP_N_PAPERLESS_ASIGNACION_PASO1");
                objParams[0].Value = AsignacionPaso1.NumMaster;
                objParams[1].Value = AsignacionPaso1.FechaMaster;
                if (AsignacionPaso1.Agente == null)
                    objParams[2].Value = -1;
                else
                    objParams[2].Value = AsignacionPaso1.Agente.Id;

                if (AsignacionPaso1.Naviera == null)
                    objParams[3].Value = -1;
                else
                    objParams[3].Value = AsignacionPaso1.Naviera.Id;

                if (AsignacionPaso1.Nave == null)
                    objParams[4].Value = -1;
                else
                    objParams[4].Value = AsignacionPaso1.Nave.Id;

                objParams[5].Value = AsignacionPaso1.Viaje;
                objParams[6].Value = AsignacionPaso1.NumHousesBL;
                objParams[7].Value = AsignacionPaso1.TipoCarga.Id;
                objParams[8].Value = AsignacionPaso1.Estado;
                objParams[9].Value = Base.Usuario.UsuarioConectado.Usuario.Id;

                if (AsignacionPaso1.TipoServicio != null)
                    objParams[10].Value = AsignacionPaso1.TipoServicio.Id;
                else
                    objParams[10].Value = -1;


                if (AsignacionPaso1.NaveTransbordo != null)
                    objParams[11].Value = AsignacionPaso1.NaveTransbordo.Id;
                else
                    objParams[11].Value = -1;

                SqlCommand command = new SqlCommand("SP_N_PAPERLESS_ASIGNACION_PASO1", connparam);
                command.Transaction = tranparam;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                idAsignacion = Convert.ToInt64(command.ExecuteScalar());

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.ObjetoTransaccion = idAsignacion;

            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        private static ResultadoTransaccion ActualizaAsignacionPaso1(PaperlessAsignacion AsignacionPaso1, SqlConnection connparam, SqlTransaction tranparam)
        {
            Int64 idAsignacion = 0;
            resTransaccion = new ResultadoTransaccion();
            try
            {

                objParams = SqlHelperParameterCache.GetSpParameterSet(connparam, "SP_U_PAPERLESS_ASIGNACION_PASO1");
                objParams[0].Value = AsignacionPaso1.NumMaster;
                objParams[1].Value = AsignacionPaso1.FechaMaster;
                if (AsignacionPaso1.Agente == null)
                    objParams[2].Value = -1;
                else
                    objParams[2].Value = AsignacionPaso1.Agente.Id;

                if (AsignacionPaso1.Naviera == null)
                    objParams[3].Value = -1;
                else
                    objParams[3].Value = AsignacionPaso1.Naviera.Id;

                if (AsignacionPaso1.Nave == null)
                    objParams[4].Value = -1;
                else
                    objParams[4].Value = AsignacionPaso1.Nave.Id;

                objParams[5].Value = AsignacionPaso1.Viaje;
                objParams[6].Value = AsignacionPaso1.NumHousesBL;
                objParams[7].Value = AsignacionPaso1.TipoCarga.Id;
                objParams[8].Value = AsignacionPaso1.Id;

                if (AsignacionPaso1.TipoServicio != null)
                    objParams[9].Value = AsignacionPaso1.TipoServicio.Id;
                else
                    objParams[9].Value = -1;


                if (AsignacionPaso1.NaveTransbordo != null) objParams[10].Value = AsignacionPaso1.NaveTransbordo.Id32;
                if (!string.IsNullOrEmpty(AsignacionPaso1.MotivoModificacion))
                    objParams[11].Value = AsignacionPaso1.MotivoModificacion;
                //else
                //  objParams[10].Value = null;

                SqlCommand command = new SqlCommand("SP_U_PAPERLESS_ASIGNACION_PASO1", connparam);
                command.Transaction = tranparam;
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

        public static ResultadoTransaccion GuardaPaso2(PaperlessAsignacion paso2, PaperlessLogAperturaNavieras LogApertura)
        {
            resTransaccion = new ResultadoTransaccion();
            SqlTransaction transaction = null;
            try
            {
                conn = BaseDatos.NuevaConexion();
                transaction = conn.BeginTransaction();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_U_PAPERLESS_ASIGNACION_PASO2");
                objParams[0].Value = paso2.FechaETA;

                if (!paso2.AperturaNavieras.HasValue)
                    objParams[1].Value = new DateTime(9999, 1, 1);
                else
                    objParams[1].Value = paso2.AperturaNavieras;

                if (!paso2.PlazoEmbarcadores.HasValue)
                    objParams[2].Value = new DateTime(9999, 1, 1);
                else
                    objParams[2].Value = paso2.PlazoEmbarcadores;
                objParams[3].Value = paso2.Id;
                objParams[4].Value = paso2.Estado;
                objParams[5].Value = paso2.ChkCourier;
                objParams[6].Value = paso2.ChkEnDestino;
                objParams[7].Value = paso2.ChkMasterConfirmado;
                objParams[8].Value = paso2.FechaMasterConfirmado.HasValue ? paso2.FechaMasterConfirmado : new DateTime(9999, 1, 1);

                objParams[9].Value = !string.IsNullOrEmpty(paso2.TxtCourier) ? paso2.TxtCourier : "";
                objParams[10].Value = paso2.FechaMaximaVinculacionDiff;
                objParams[11].Value = paso2.FechaMaximaVinculacion.HasValue ? paso2.FechaMaximaVinculacion : new DateTime(9999, 1, 1);

                SqlCommand command = new SqlCommand("SP_U_PAPERLESS_ASIGNACION_PASO2", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = transaction;
                command.ExecuteNonQuery();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;


                if (!(!LogApertura.ValorNuevo.HasValue && LogApertura.Accion == Enums.TipoActividadUsuario.Creo))
                {
                    resTransaccion = AgregarLogAperturaNavieras(LogApertura, conn, transaction);
                    if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resTransaccion.Descripcion);
                }

                transaction.Commit();


            }
            catch (Exception ex)
            {
                transaction.Rollback();

                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return resTransaccion;
        }

        public static ResultadoTransaccion GuardaPaso3(PaperlessAsignacion paso3)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_U_PAPERLESS_ASIGNACION_PASO3");
                objParams[0].Value = paso3.Usuario1.Id;
                objParams[1].Value = paso3.ObservacionUsuario1;
                objParams[2].Value = paso3.ImportanciaUsuario1.Id;
                objParams[3].Value = paso3.Usuario2.Id;
                objParams[4].Value = paso3.ObservacionUsuario2;
                objParams[5].Value = paso3.Estado;
                objParams[6].Value = paso3.Id;

                SqlCommand command = new SqlCommand("SP_U_PAPERLESS_ASIGNACION_PASO3", conn);
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

        public static IList<PaperlessEstado> ObtenerEstadosPaperless(Enums.Estado activo)
        {
            PaperlessEstado estado = null;
            IList<PaperlessEstado> listestados = new List<PaperlessEstado>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_L_PAPERLESS_ESTADO");
                objParams[0].Value = activo;

                SqlCommand command = new SqlCommand("SP_L_PAPERLESS_ESTADO", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    estado = new PaperlessEstado();
                    estado.Id = Convert.ToInt64(dreader["Id"]);
                    estado.Nombre = dreader["Descripcion"].ToString();
                    if (dreader["PasoAnterior"] is DBNull)
                        estado.EstadoAnterior = null;
                    else
                        estado.EstadoAnterior = new PaperlessEstado()
                        {
                            Id = Convert.ToInt64(dreader["PasoAnterior"].ToString()),
                            Nombre = dreader["Anterior"].ToString()
                        };

                    if (dreader["PasoSiguiente"] is DBNull)
                        estado.EstadoSiguiente = null;
                    else
                        estado.EstadoSiguiente = new PaperlessEstado()
                        {
                            Id = Convert.ToInt64(dreader["PasoSiguiente"].ToString()),
                            Nombre = dreader["Siguiente"].ToString()
                        };


                    listestados.Add(estado);
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

            return listestados;
        }


        public static ResultadoTransaccion CambiaEstadoAsignacion(PaperlessAsignacion asignacion)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_U_PAPERLESS_ASIGNACION_ESTADo");
                objParams[0].Value = asignacion.Estado;
                objParams[1].Value = asignacion.Id;

                SqlCommand command = new SqlCommand("SP_U_PAPERLESS_ASIGNACION_ESTADo", conn);
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
            finally
            {
                conn.Close();
            }
            return resTransaccion;
        }

        public static ResultadoTransaccion CambiaEstadoAsignacion(PaperlessAsignacion asignacion, SqlConnection connparam, SqlTransaction tranparam)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(connparam, "SP_U_PAPERLESS_ASIGNACION_ESTADo");
                objParams[0].Value = asignacion.Estado;
                objParams[1].Value = asignacion.Id;

                SqlCommand command = new SqlCommand("SP_U_PAPERLESS_ASIGNACION_ESTADo", connparam);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = tranparam;
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

        public static IList<PaperlessPasos> ListarPasosUsuario1(Enums.Estado activo)
        {
            PaperlessPasos paso = null;
            IList<PaperlessPasos> pasos = new List<PaperlessPasos>();

            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_L_PAPERLESS_PASOS_USUARIO1");
                objParams[0].Value = activo;

                SqlCommand command = new SqlCommand("SP_L_PAPERLESS_PASOS_USUARIO1", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    paso = new PaperlessPasos();
                    paso.Id = Convert.ToInt64(dreader["IdPaso"]);
                    paso.NumPaso = Convert.ToInt16(dreader["NumPaso"]);
                    paso.Nombre = dreader["Descripcion"].ToString();
                    paso.Activo = Convert.ToBoolean(dreader["Activo"]);

                    if (dreader["PasoAnterior"] is DBNull)
                        paso.PasoAnterior = null;
                    else
                        paso.PasoAnterior = new PaperlessPasos()
                        {
                            Id = Convert.ToInt64(dreader["PasoAnterior"].ToString()),
                            Nombre = dreader["Anterior"].ToString()
                        };

                    if (dreader["PasoSiguiente"] is DBNull)
                        paso.PasoSiguiente = null;
                    else
                        paso.PasoSiguiente = new PaperlessPasos()
                        {
                            Id = Convert.ToInt64(dreader["PasoSiguiente"].ToString()),
                            Nombre = dreader["Siguiente"].ToString()
                        };



                    pasos.Add(paso);
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

            return pasos;

        }

        private static ResultadoTransaccion PreparaPasosUsuario1(PaperlessAsignacion asignacion, PaperlessProcesoRegistroTiempo inicio, String sp)
        {

            //aqui trabajar --  vhspiceros
            resTransaccion = new ResultadoTransaccion();
            SqlTransaction transaction = null;
            try
            {
                conn = BaseDatos.NuevaConexion();
                transaction = conn.BeginTransaction();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, sp);
                objParams[0].Value = asignacion.Id;

                var command = new SqlCommand(sp, conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = transaction;
                command.ExecuteNonQuery();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;

                resTransaccion = Usuario1RegistraComienzo(inicio, conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);

                transaction.Commit();


            }
            catch (Exception ex)
            {
                transaction.Rollback();

                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return resTransaccion;
        }

        public static ResultadoTransaccion PreparaPasosUsuario1(PaperlessAsignacion asignacion, PaperlessProcesoRegistroTiempo inicio)
        {
            return PreparaPasosUsuario1(asignacion, inicio, "SP_N_PAPERLESS_USUARIO1_PREPARA_PASOS");
        }

        public static ResultadoTransaccion PreparaPasosUsuario1V2(PaperlessAsignacion asignacion, PaperlessProcesoRegistroTiempo inicio)
        {
            return PreparaPasosUsuario1(asignacion, inicio, "SP_N_PAPERLESS_USUARIO1_PREPARA_PASOS_V2");
        }


        public static ResultadoTransaccion PreparaPasosUsuario2(PaperlessAsignacion asignacion)
        {
            resTransaccion = new ResultadoTransaccion();
            SqlTransaction transaction = null;
            try
            {
                conn = BaseDatos.NuevaConexion();
                transaction = conn.BeginTransaction();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_PAPERLESS_USUARIO2_PREPARA_PASOS");
                objParams[0].Value = asignacion.Id;

                SqlCommand command = new SqlCommand("SP_N_PAPERLESS_USUARIO2_PREPARA_PASOS", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = transaction;
                command.ExecuteNonQuery();

                //resTransaccion = Usuario2RegistraComienzo(inicio, conn, transaction);
                //if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                //    throw new Exception(resTransaccion.Descripcion);


                resTransaccion = CambiaEstadoAsignacion(asignacion, conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;

                transaction.Commit();


            }
            catch (Exception ex)
            {
                transaction.Rollback();

                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return resTransaccion;
        }


        public static IList<PaperlessPasosEstado> ListarPasosEstadoUsuario1(Int64 IdAsignacion, String sp)
        {
            PaperlessPasosEstado paso = null;
            IList<PaperlessPasosEstado> pasos = new List<PaperlessPasosEstado>();

            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, sp);
                objParams[0].Value = IdAsignacion;

                SqlCommand command = new SqlCommand(sp, conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    paso = new PaperlessPasosEstado();
                    paso.IdAsignacion = Convert.ToInt64(dreader["IdAsignacion"]);
                    paso.Paso.NumPaso = Convert.ToInt16(dreader["NumPaso"]);
                    paso.Estado = Convert.ToBoolean(dreader["Estado"]);
                    paso.Paso.Nombre = dreader["Descripcion"].ToString();
                    paso.IdPasoEstado = Convert.ToInt64(dreader["IdPasoEstado"]);
                    paso.Paso.NumPaso = Convert.ToInt16(dreader["NumPaso"]);
                    paso.Pantalla = dreader["pantalla"].ToString();
                    pasos.Add(paso);
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

            return pasos;
        }
        public static IList<PaperlessPasosEstado> ListarPasosEstadoUsuario1(Int64 IdAsignacion)
        {
            return ListarPasosEstadoUsuario1(IdAsignacion, "SP_C_PAPERLESS_USUARIO1_PASOS_ESTADO");
        }

        public static IList<PaperlessPasosEstado> ListarPasosEstadoUsuario1V2(Int64 IdAsignacion)
        {
            return ListarPasosEstadoUsuario1(IdAsignacion, "SP_C_PAPERLESS_USUARIO1_PASOS_ESTADO_v2");
        }

        public static IList<PaperlessPasosEstado> ListarPasosEstadoUsuario2(Int64 IdAsignacion)
        {
            PaperlessPasosEstado paso = null;
            IList<PaperlessPasosEstado> pasos = new List<PaperlessPasosEstado>();

            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_PAPERLESS_USUARIO2_PASOS_ESTADO");
                objParams[0].Value = IdAsignacion;

                SqlCommand command = new SqlCommand("SP_C_PAPERLESS_USUARIO2_PASOS_ESTADO", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    paso = new PaperlessPasosEstado();
                    paso.IdAsignacion = Convert.ToInt64(dreader["IdAsignacion"]);
                    paso.Paso.NumPaso = Convert.ToInt16(dreader["NumPaso"]);
                    paso.Estado = Convert.ToBoolean(dreader["Estado"]);
                    paso.Paso.Nombre = dreader["Descripcion"].ToString();
                    paso.IdPasoEstado = Convert.ToInt64(dreader["IdPasoEstado"]);
                    paso.Paso.NumPaso = Convert.ToInt16(dreader["NumPaso"]);
                    paso.Pantalla = dreader["pantalla"].ToString();
                    pasos.Add(paso);
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

            return pasos;
        }

        public static IList<PaperlessUsuario1HousesBL> Usuario1ObtenerHousesBL(Int64 IdAsignacion)
        {
            PaperlessUsuario1HousesBL house = null;
            IList<PaperlessUsuario1HousesBL> houses = new List<PaperlessUsuario1HousesBL>();

            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_PAPERLESS_USUARIO1_HOUSEBL");
                objParams[0].Value = IdAsignacion;

                SqlCommand command = new SqlCommand("SP_C_PAPERLESS_USUARIO1_HOUSEBL", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    house = new PaperlessUsuario1HousesBL();
                    house.Id = Convert.ToInt64(dreader["Id"]);
                    house.IdAsignacion = Convert.ToInt64(dreader["IdAsignacion"]);
                    house.Index = Convert.ToInt16(dreader["IndexHouse"]);
                    house.HouseBL = dreader["HouseBL"].ToString();
                    house.Freehand = Convert.ToBoolean(dreader["Freehand"].ToString());
                    if (dreader["Ruteado"] is DBNull)
                        house.Ruteado = false;
                    else
                        house.Ruteado = Convert.ToBoolean(dreader["Ruteado"]);

                    if (dreader["IdCliente"] is DBNull)
                        house.Cliente = null;
                    else
                        house.Cliente = Clientes.clsClienteMasterADO.ObtenerClienteMasterPorId(Convert.ToInt64(dreader["IdCliente"]));

                    if (dreader["IdTipoCliente"] is DBNull)
                        house.TipoCliente = null;
                    else
                        house.TipoCliente = new PaperlessTipoCliente() { Id = Convert.ToInt16(dreader["IdTipoCliente"].ToString()), Nombre = dreader["TipoCliente"].ToString() };

                    if (dreader["EmbarcadorContactado"] is DBNull)
                        house.EmbarcadorContactado = false;
                    else
                        house.EmbarcadorContactado = Convert.ToBoolean(dreader["EmbarcadorContactado"]);

                    if (dreader["ReciboAperturaEmbarcador"] is DBNull)
                        house.ReciboAperturaEmbarcador = false;
                    else
                        house.ReciboAperturaEmbarcador = Convert.ToBoolean(dreader["ReciboAperturaEmbarcador"]);

                    if (dreader["FechaReciboAperturaEmbarcador"] is DBNull)
                        house.FechaReciboAperturaEmbarcador = null;
                    else
                        house.FechaReciboAperturaEmbarcador = Convert.ToDateTime(dreader["FechaReciboAperturaEmbarcador"]);

                    if (dreader["TipoReciboAperturaEmbarcador"] is DBNull)
                        house.TipoReciboAperturaEmbarcador = Enums.PaperlessTipoReciboAperturaEmbarcador.NoDefinido;
                    else
                        house.TipoReciboAperturaEmbarcador =
                            (Enums.PaperlessTipoReciboAperturaEmbarcador)
                            Convert.ToInt16(dreader["TipoReciboAperturaEmbarcador"]);

                    if (dreader["RecargoCollect"] is DBNull)
                        house.ExcepcionRecargoCollect = null;
                    else
                        house.ExcepcionRecargoCollect = new PaperlessExcepcion()
                        {
                            RecargoCollect = Convert.ToBoolean(dreader["RecargoCollect"]),
                            Id = Convert.ToInt64(dreader["IdExcepcion"])
                        };

                    try
                    {
                        if (dreader["Observacion"] is DBNull)
                            house.Observacion = "";
                        else
                            house.Observacion = dreader["Observacion"].ToString();


                        if (dreader["PaperlessTipoRecibo"] is DBNull)
                        {
                            if (house.Cliente != null && house.Cliente.Cuenta != null)
                                house.Cliente.Cuenta.TipoReciboAperturaEmbarcador = Enums.PaperlessTipoReciboAperturaEmbarcador.NoDefinido;
                        }
                        else if (house.Cliente != null && house.Cliente.Cuenta != null)
                        {

                            //LogicaNegocios.Clientes.clsCuentas.BuscarCuentaPorId(house.Cliente);
                            house.Cliente.Cuenta.TipoReciboAperturaEmbarcador = (Enums.PaperlessTipoReciboAperturaEmbarcador)Convert.ToInt16(dreader["PaperlessTipoRecibo"]);
                        }
                        if (dreader["Shippinginstruction"] is DBNull)
                            house.ShippingInstruction = "";
                        else
                            house.ShippingInstruction = dreader["Shippinginstruction"].ToString();


                        if (dreader["puerto"] is DBNull)
                            house.Puerto = "";
                        else
                            house.Puerto = dreader["puerto"].ToString();

                    }
                    catch (Exception ex)
                    {
                        Log.EscribirLog(ex.Message);
                    }

                    houses.Add(house);
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

            return houses;
        }
        public static IList<PaperlessUsuario1HousesBL> ObtenerHousesBLporShippingInstruction(string ShippingInstruction, string puerto)
        {
            PaperlessUsuario1HousesBL house = null;
            IList<PaperlessUsuario1HousesBL> houses = new List<PaperlessUsuario1HousesBL>();

            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_PAPERLESS_USUARIO1_HOUSEBL_SHIPPING");
                objParams[0].Value = ShippingInstruction;
                objParams[1].Value = puerto;

                SqlCommand command = new SqlCommand("SP_C_PAPERLESS_USUARIO1_HOUSEBL_SHIPPING", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    house = new PaperlessUsuario1HousesBL();
                    house.Id = Convert.ToInt64(dreader["Id"]);
                    house.IdAsignacion = Convert.ToInt64(dreader["IdAsignacion"]);
                    house.Index = Convert.ToInt16(dreader["IndexHouse"]);
                    house.HouseBL = dreader["HouseBL"].ToString();
                    house.Freehand = Convert.ToBoolean(dreader["Freehand"].ToString());
                    if (dreader["Ruteado"] is DBNull)
                        house.Ruteado = false;
                    else
                        house.Ruteado = Convert.ToBoolean(dreader["Ruteado"]);

                    if (dreader["IdCliente"] is DBNull)
                        house.Cliente = null;
                    else
                        house.Cliente = Clientes.clsClienteMasterADO.ObtenerClienteMasterPorId(Convert.ToInt64(dreader["IdCliente"]));

                    if (dreader["IdTipoCliente"] is DBNull)
                        house.TipoCliente = null;
                    else
                        house.TipoCliente = new PaperlessTipoCliente() { Id = Convert.ToInt16(dreader["IdTipoCliente"].ToString()), Nombre = dreader["TipoCliente"].ToString() };

                    if (dreader["EmbarcadorContactado"] is DBNull)
                        house.EmbarcadorContactado = false;
                    else
                        house.EmbarcadorContactado = Convert.ToBoolean(dreader["EmbarcadorContactado"]);

                    if (dreader["ReciboAperturaEmbarcador"] is DBNull)
                        house.ReciboAperturaEmbarcador = false;
                    else
                        house.ReciboAperturaEmbarcador = Convert.ToBoolean(dreader["ReciboAperturaEmbarcador"]);

                    if (dreader["FechaReciboAperturaEmbarcador"] is DBNull)
                        house.FechaReciboAperturaEmbarcador = null;
                    else
                        house.FechaReciboAperturaEmbarcador = Convert.ToDateTime(dreader["FechaReciboAperturaEmbarcador"]);

                    if (dreader["TipoReciboAperturaEmbarcador"] is DBNull)
                        house.TipoReciboAperturaEmbarcador = Enums.PaperlessTipoReciboAperturaEmbarcador.NoDefinido;
                    else
                        house.TipoReciboAperturaEmbarcador =
                            (Enums.PaperlessTipoReciboAperturaEmbarcador)
                            Convert.ToInt16(dreader["TipoReciboAperturaEmbarcador"]);

                    if (dreader["RecargoCollect"] is DBNull)
                        house.ExcepcionRecargoCollect = null;
                    else
                        house.ExcepcionRecargoCollect = new PaperlessExcepcion()
                        {
                            RecargoCollect = Convert.ToBoolean(dreader["RecargoCollect"]),
                            Id = Convert.ToInt64(dreader["IdExcepcion"])
                        };

                    try
                    {
                        if (dreader["Observacion"] is DBNull)
                            house.Observacion = "";
                        else
                            house.Observacion = dreader["Observacion"].ToString();


                        if (dreader["PaperlessTipoRecibo"] is DBNull)
                        {
                            if (house.Cliente != null && house.Cliente.Cuenta != null)
                                house.Cliente.Cuenta.TipoReciboAperturaEmbarcador = Enums.PaperlessTipoReciboAperturaEmbarcador.NoDefinido;
                        }
                        else if (house.Cliente != null && house.Cliente.Cuenta != null)
                        {

                            //LogicaNegocios.Clientes.clsCuentas.BuscarCuentaPorId(house.Cliente);
                            house.Cliente.Cuenta.TipoReciboAperturaEmbarcador = (Enums.PaperlessTipoReciboAperturaEmbarcador)Convert.ToInt16(dreader["PaperlessTipoRecibo"]);
                        }
                        if (dreader["Shippinginstruction"] is DBNull)
                            house.ShippingInstruction = "";
                        else
                            house.ShippingInstruction = dreader["Shippinginstruction"].ToString();


                        if (dreader["puerto"] is DBNull)
                            house.Puerto = "";
                        else
                            house.Puerto = dreader["puerto"].ToString();

                        if (dreader["NumMaster"] is DBNull)
                            house.NumMaster = "";
                        else
                            house.NumMaster = dreader["NumMaster"].ToString();

                    }
                    catch (Exception ex)
                    {
                        Log.EscribirLog(ex.Message);
                    }

                    houses.Add(house);
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

            return houses;
        }



        public static ResultadoTransaccion Usuario1GuardaHousesBL(IList<PaperlessUsuario1HousesBL> houses,
                                                                  PaperlessUsuario1HouseBLInfo info,
                                                                  PaperlessPasosEstado paso)
        {
            ResultadoTransaccion resultado = new ResultadoTransaccion();
            conn = Base.BaseDatos.BaseDatos.NuevaConexion();
            SqlTransaction transaction = conn.BeginTransaction();
            bool esupdate = false;

            try
            {
                //Eliminar Info anterior
                //resultado = Usuario1EliminarHousesBLFull(houses[0].IdAsignacion, conn, transaction);
                //if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                //    throw new Exception(resultado.Descripcion);

                //Registrar houses
                foreach (var house in houses)
                {
                    if (house.IsNew)
                    {
                        if (house.Cliente.IsNew)
                        {
                            resultado = Clientes.clsClienteMasterADO.GuardarClienteMaster(house.Cliente, conn, transaction);
                            if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                                throw new Exception(resultado.Descripcion);
                            else
                            {
                                house.Cliente.Id = Convert.ToInt64(resultado.ObjetoTransaccion);
                            }
                        }


                        resultado = Usuario1AgregarHouseBL(house, conn, transaction);
                        if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                            throw new Exception(resultado.Descripcion);
                        else
                        {
                            house.Id = Convert.ToInt64(resultado.ObjetoTransaccion);
                        }

                        //verificar si tiene recargo collect

                        house.ExcepcionRecargoCollect.IdAsignacion = house.IdAsignacion;
                        house.ExcepcionRecargoCollect.HouseBL.Id = house.Id;


                        resultado = Usuario1MarcaIngresoExcepcion(house.ExcepcionRecargoCollect, conn, transaction);
                        if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                            throw new Exception(resultado.Descripcion);

                    }
                    else
                    {
                        if (house.Cliente.IsNew)
                        {
                            resultado = Clientes.clsClienteMasterADO.GuardarClienteMaster(house.Cliente, conn, transaction);
                            if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                                throw new Exception(resultado.Descripcion);
                            else
                            {
                                house.Cliente.Id = Convert.ToInt64(resultado.ObjetoTransaccion);
                            }
                        }

                        resultado = Usuario1ActualizaPaso1(house, conn, transaction);
                        if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                            throw new Exception(resultado.Descripcion);
                        esupdate = true;

                        resultado = Usuario1ActualizaExcepcion(house.ExcepcionRecargoCollect, conn, transaction);
                        if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                            throw new Exception(resultado.Descripcion);
                    }

                }

                //guardar info
                if (!esupdate)
                {
                    resultado = Usuario1GuardaHouseBLInfo(info, conn, transaction);
                    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resultado.Descripcion);
                    else
                        info.Id = Convert.ToInt64(resultado.ObjetoTransaccion);
                }
                else
                {
                    resultado = Usuario1ActualizaPaso1Info(info, conn, transaction);
                    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resultado.Descripcion);
                }


                //cambiar estado paso
                resultado = Usuario1CambiarEstadoPaso(paso, conn, transaction);
                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resultado.Descripcion);


                transaction.Commit();
                resultado.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                resultado.Estado = Enums.EstadoTransaccion.Rechazada;
                resultado.Descripcion = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return resultado;
        }

        private static ResultadoTransaccion Usuario1AgregarHouseBL(PaperlessUsuario1HousesBL housebl, SqlConnection connparam, SqlTransaction tranparam)
        {
            resTransaccion = new ResultadoTransaccion();
            Int64 IdHouse = 0;
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(connparam, "SP_N_PAPERLESS_USUARIO1_HOUSESBL");
                objParams[0].Value = housebl.IdAsignacion;
                objParams[1].Value = housebl.Index;
                objParams[2].Value = housebl.HouseBL;
                objParams[3].Value = housebl.Freehand;
                objParams[4].Value = housebl.Cliente.Id;
                objParams[5].Value = housebl.TipoCliente.Id;

                /*descomentar despues */
                /* objParams[6].Value = housebl.ShippingInstruction;
                 objParams[7].Value = housebl.Puerto;
 */
                SqlCommand command = new SqlCommand("SP_N_PAPERLESS_USUARIO1_HOUSESBL", connparam);
                command.Parameters.AddRange(objParams);
                command.Transaction = tranparam;
                command.CommandType = CommandType.StoredProcedure;
                IdHouse = Convert.ToInt64(command.ExecuteScalar());

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.ObjetoTransaccion = IdHouse;
            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        private static ResultadoTransaccion Usuario1GuardaHouseBLInfo(PaperlessUsuario1HouseBLInfo infohousesbl, SqlConnection connparam, SqlTransaction tranparam)
        {
            resTransaccion = new ResultadoTransaccion();
            Int64 IdHouseInfo = 0;
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(connparam, "SP_N_PAPERLESS_USUARIO1_HOUSESBL_INFO");
                objParams[0].Value = infohousesbl.IdAsignacion;
                objParams[1].Value = infohousesbl.NumConsolidado;
                objParams[2].Value = infohousesbl.CantHouses;
                //objParams[3].Value = infohousesbl.NumHouse;

                SqlCommand command = new SqlCommand("SP_N_PAPERLESS_USUARIO1_HOUSESBL_INFO", connparam);
                command.Parameters.AddRange(objParams);
                command.Transaction = tranparam;
                command.CommandType = CommandType.StoredProcedure;
                IdHouseInfo = Convert.ToInt64(command.ExecuteScalar());

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.ObjetoTransaccion = IdHouseInfo;
            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        public static ResultadoTransaccion Usuario1CambiarEstadoPaso(Entidades.Paperless.PaperlessPasosEstado paso, SqlConnection connparam, SqlTransaction tranparam)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(connparam, "SP_U_PAPERLESS_USUARIO1_PASOS_ESTADO");
                objParams[0].Value = paso.Estado;
                objParams[1].Value = paso.IdPasoEstado;

                SqlCommand command = new SqlCommand("SP_U_PAPERLESS_USUARIO1_PASOS_ESTADO", connparam);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = tranparam;
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

        public static ResultadoTransaccion Usuario1CambiarEstadoPaso(Entidades.Paperless.PaperlessPasosEstado paso)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_U_PAPERLESS_USUARIO1_PASOS_ESTADO");
                objParams[0].Value = paso.Estado;
                objParams[1].Value = paso.IdPasoEstado;

                SqlCommand command = new SqlCommand("SP_U_PAPERLESS_USUARIO1_PASOS_ESTADO", conn);
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

        public static ResultadoTransaccion Usuario1CambiarEstadoPaso_CambiarEstadoAsignacion(Entidades.Paperless.PaperlessPasosEstado paso,
                                                                                             PaperlessAsignacion asignacion,
                                                                                             PaperlessProcesoRegistroTiempo termino,
                                                                                            PaperlessProcesoRegistroTiempo iniciousuario2
            )
        {
            resTransaccion = new ResultadoTransaccion();
            SqlTransaction transaction = null;
            try
            {
                conn = BaseDatos.NuevaConexion();
                transaction = conn.BeginTransaction();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_U_PAPERLESS_USUARIO1_PASOS_ESTADO");
                objParams[0].Value = paso.Estado;
                objParams[1].Value = paso.IdPasoEstado;

                SqlCommand command = new SqlCommand("SP_U_PAPERLESS_USUARIO1_PASOS_ESTADO", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = transaction;
                command.ExecuteNonQuery();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;

                //Cambiar estado asignacion                
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_U_PAPERLESS_ASIGNACION_ESTADo");
                objParams[0].Value = asignacion.Estado;
                objParams[1].Value = asignacion.Id;

                command = new SqlCommand("SP_U_PAPERLESS_ASIGNACION_ESTADo", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = transaction;
                command.ExecuteNonQuery();


                resTransaccion = Usuario1RegistraTermino(termino, conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);


                resTransaccion = Usuario2RegistraComienzo(iniciousuario2, conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;


                transaction.Commit();


            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
                if (transaction != null)
                    transaction.Rollback();
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return resTransaccion;
        }

        public static ResultadoTransaccion Usuario1EliminarHousesBLFull(Int64 IdAsignacion, SqlConnection connparam, SqlTransaction tranparam)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(connparam, "SP_E_PAPERLESS_USUARIO1_HOUSESBL");
                objParams[0].Value = IdAsignacion;

                SqlCommand command = new SqlCommand("SP_E_PAPERLESS_USUARIO1_HOUSESBL", connparam);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = tranparam;
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

        public static ResultadoTransaccion Usuario1EliminarHousesBL(Int64 IdAsignacion, SqlConnection connparam, SqlTransaction tranparam)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(connparam, "SP_E_PAPERLESS_USUARIO1_HOUSESBL_POR_ASIGNACION");
                objParams[0].Value = IdAsignacion;

                SqlCommand command = new SqlCommand("SP_E_PAPERLESS_USUARIO1_HOUSESBL_POR_ASIGNACION", connparam);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = tranparam;
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

        public static PaperlessUsuario1HouseBLInfo Usuario1ObtenerHousesBLInfo(Int64 IdAsignacion)
        {
            PaperlessUsuario1HouseBLInfo info = null;

            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_PAPERLESS_USUARIO1_HOUSESBL_INFO");
                objParams[0].Value = IdAsignacion;

                SqlCommand command = new SqlCommand("SP_C_PAPERLESS_USUARIO1_HOUSESBL_INFO", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    info = new PaperlessUsuario1HouseBLInfo();
                    info.Id = Convert.ToInt64(dreader["Id"]);
                    info.IdAsignacion = Convert.ToInt64(dreader["IdAsignacion"]);
                    info.NumConsolidado = dreader["NumConsolidado"].ToString();
                    info.CantHouses = Convert.ToInt16(dreader["CantHouses"]);
                    //info.NumHouse = Convert.ToInt16(dreader["NumHouse"]);

                    //info.Cliente = Clientes.clsClienteMasterADO.ObtenerClienteMasterPorId(Convert.ToInt64(dreader["IdCliente"]));
                    //info.Cliente = new clsClienteMaster(true) { NombreCompañia = dreader["NombreCompania"].ToString() };

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

            return info;
        }

        public static ResultadoTransaccion Usuario1MarcarHousesRuteados(IList<PaperlessUsuario1HousesBL> houses, PaperlessPasosEstado paso)
        {
            ResultadoTransaccion resultado = new ResultadoTransaccion();
            conn = Base.BaseDatos.BaseDatos.NuevaConexion();
            SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                //Eliminar Info anterior
                //resultado = Usuario1EliminarHousesBL(houses[0].IdAsignacion, conn, transaction);
                //if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                //    throw new Exception(resultado.Descripcion);

                //Registrar houses
                foreach (var house in houses)
                {
                    resultado = Usuario1MarcaHouseRuteado(house, conn, transaction);
                    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resultado.Descripcion);
                }

                //cambiar estado paso
                resultado = Usuario1CambiarEstadoPaso(paso, conn, transaction);
                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resultado.Descripcion);


                transaction.Commit();
                resultado.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                resultado.Estado = Enums.EstadoTransaccion.Rechazada;
                resultado.Descripcion = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return resultado;
        }

        private static ResultadoTransaccion Usuario1GuardarTipoTransito(PaperlessUsuario1HousesBL house, SqlConnection connparam, SqlTransaction tranparam)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(connparam, "SP_U_PAPERLESS_USUARIO1_TRANSBORDOTRANSITO");
                if (house.TransbordoTransito != null)
                    objParams[0].Value = house.TransbordoTransito.Id;
                else
                    objParams[0].Value = 1;
                objParams[1].Value = house.Id;

                SqlCommand command = new SqlCommand("SP_U_PAPERLESS_USUARIO1_TRANSBORDOTRANSITO", connparam);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = tranparam;
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
        private static ResultadoTransaccion Usuario1MarcaHouseRuteado(PaperlessUsuario1HousesBL house, SqlConnection connparam, SqlTransaction tranparam)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(connparam, "SP_U_PAPERLESS_USUARIO1_HOUSESBL");
                objParams[0].Value = house.Ruteado;
                objParams[1].Value = house.Id;

                SqlCommand command = new SqlCommand("SP_U_PAPERLESS_USUARIO1_HOUSESBL", connparam);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = tranparam;
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

        public static ResultadoTransaccion Usuario1ActuazarPaso1(IList<PaperlessUsuario1HousesBL> houses, PaperlessPasosEstado paso)
        {
            ResultadoTransaccion resultado = new ResultadoTransaccion();
            conn = Base.BaseDatos.BaseDatos.NuevaConexion();
            SqlTransaction transaction = conn.BeginTransaction();

            try
            {

                //Registrar houses
                foreach (var house in houses)
                {
                    resultado = Usuario1ActualizaPaso1(house, conn, transaction);
                    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resultado.Descripcion);
                }

                //cambiar estado paso
                resultado = Usuario1CambiarEstadoPaso(paso, conn, transaction);
                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resultado.Descripcion);


                transaction.Commit();
                resultado.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                resultado.Estado = Enums.EstadoTransaccion.Rechazada;
                resultado.Descripcion = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return resultado;
        }

        private static ResultadoTransaccion Usuario1ActualizaPaso1(PaperlessUsuario1HousesBL house, SqlConnection connparam, SqlTransaction tranparam)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(connparam, "SP_U_PAPERLESS_USUARIO1_HOUSESBL_P1");
                objParams[0].Value = house.HouseBL;
                objParams[1].Value = house.Freehand;
                objParams[2].Value = house.Id;
                objParams[3].Value = house.Cliente.Id;
                objParams[4].Value = house.TipoCliente.Id;

                SqlCommand command = new SqlCommand("SP_U_PAPERLESS_USUARIO1_HOUSESBL_P1", connparam);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = tranparam;
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

        private static ResultadoTransaccion Usuario1ActualizaPaso1Info(PaperlessUsuario1HouseBLInfo house, SqlConnection connparam, SqlTransaction tranparam)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(connparam, "SP_U_PAPERLESS_USUARIO1_HOUSESBL_INFO");
                objParams[0].Value = house.IdAsignacion;
                objParams[1].Value = house.NumConsolidado;
                objParams[2].Value = house.CantHouses;

                SqlCommand command = new SqlCommand("SP_U_PAPERLESS_USUARIO1_HOUSESBL_INFO", connparam);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = tranparam;
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

        public static IList<PaperlessTipoCliente> ListarTiposCliente(Enums.Estado activo)
        {
            PaperlessTipoCliente tipo = null;
            IList<PaperlessTipoCliente> tipos = new List<PaperlessTipoCliente>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_L_PAPERLESS_TIPO_CLIENTE");
                objParams[0].Value = activo;

                SqlCommand command = new SqlCommand("SP_L_PAPERLESS_TIPO_CLIENTE", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    tipo = new PaperlessTipoCliente();
                    tipo.Id = Convert.ToInt64(dreader["Id"]);
                    tipo.Nombre = dreader["Descripcion"].ToString();
                    tipo.Activo = Convert.ToBoolean(dreader["Activo"]);

                    tipos.Add(tipo);
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

            return tipos;
        }

        public static IList<PaperlessExcepcion> Usuario1ObtenerExcepciones(Int64 IdAsignacion)
        {
            PaperlessExcepcion excepcion = null;
            IList<PaperlessExcepcion> excepciones = new List<PaperlessExcepcion>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_PAPERLESS_USUARIO1_EXCEPCIONES");
                objParams[0].Value = IdAsignacion;

                SqlCommand command = new SqlCommand("SP_C_PAPERLESS_USUARIO1_EXCEPCIONES", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    excepcion = new PaperlessExcepcion();
                    excepcion.Id = Convert.ToInt64(dreader["Id"]);
                    excepcion.IdAsignacion = Convert.ToInt64(dreader["IdAsignacion"]);
                    excepcion.HouseBL.Id = Convert.ToInt64(dreader["IdHouseBL"]);
                    excepcion.RecargoCollect = Convert.ToBoolean(dreader["RecargoCollect"]);
                    excepcion.RecargoCollectResuelto = Convert.ToBoolean(dreader["RecargoCollectResuelto"]);
                    excepcion.SobreValorPendiente = Convert.ToBoolean(dreader["SobrevalorPendiente"]);
                    excepcion.SobreValorPendienteResuelto = Convert.ToBoolean(dreader["SobrevalorPendienteResuelto"]);
                    excepcion.AvisoNoEnviado = Convert.ToBoolean(dreader["AvisoNoEnviado"]);
                    excepcion.AvisoNoEnviadoResuelto = Convert.ToBoolean(dreader["AvisoNoEnviadoResuelto"]);

                    excepcion.HouseBL = new PaperlessUsuario1HousesBL();
                    excepcion.HouseBL.Cliente = Clientes.clsClienteMasterADO.ObtenerClienteMasterPorId(Convert.ToInt64(dreader["IdCliente"]));
                    excepcion.HouseBL.TipoCliente = new PaperlessTipoCliente()
                    {
                        Id = Convert.ToInt64(dreader["IdTipoCliente"]),
                        Nombre = dreader["TipoCliente"].ToString()
                    };
                    excepcion.HouseBL.Freehand = Convert.ToBoolean(dreader["Freehand"]);
                    excepcion.HouseBL.HouseBL = dreader["HouseBL"].ToString();
                    excepcion.HouseBL.Index = Convert.ToInt32(dreader["IndexHouse"].ToString());
                    try
                    {
                        excepcion.Comentario = dreader["Comentario"].ToString();
                    }
                    catch (Exception e)
                    {
                        //Log.EscribirLog(e);
                        Console.Write(e.Message);
                    }

                    excepciones.Add(excepcion);
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

            return excepciones;
        }


        public static ResultadoTransaccion Usuario1IngresarExcepxiones(IList<PaperlessExcepcion> excepciones, PaperlessPasosEstado paso)
        {
            ResultadoTransaccion resultado = new ResultadoTransaccion();
            conn = Base.BaseDatos.BaseDatos.NuevaConexion();
            SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                //Eliminar Info anterior
                //resultado = Usuario1EliminarHousesBL(houses[0].IdAsignacion, conn, transaction);
                //if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                //    throw new Exception(resultado.Descripcion);

                //Registrar excepciones
                foreach (var excepcion in excepciones)
                {
                    if (excepcion.IsNew)
                    {
                        resultado = Usuario1MarcaIngresoExcepcion(excepcion, conn, transaction);
                        if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                            throw new Exception(resultado.Descripcion);

                        excepcion.Id = Convert.ToInt64(resultado.ObjetoTransaccion);
                    }
                    else
                    {
                        resultado = Usuario1ActualizaExcepcion(excepcion, conn, transaction);
                        if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                            throw new Exception(resultado.Descripcion);
                    }

                }

                //cambiar estado paso
                resultado = Usuario1CambiarEstadoPaso(paso, conn, transaction);
                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resultado.Descripcion);


                transaction.Commit();
                resultado.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                resultado.Estado = Enums.EstadoTransaccion.Rechazada;
                resultado.Descripcion = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return resultado;
        }


        private static ResultadoTransaccion Usuario1MarcaIngresoExcepcion(PaperlessExcepcion excepcion, SqlConnection connparam, SqlTransaction tranparam)
        {
            resTransaccion = new ResultadoTransaccion();
            Int64 IdExcepcion = 0;
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(connparam, "SP_N_PAPERLESS_USUARIO1_EXCEPCIONES");
                objParams[0].Value = excepcion.IdAsignacion;
                objParams[1].Value = excepcion.HouseBL.Id;
                objParams[2].Value = excepcion.RecargoCollect;
                objParams[3].Value = excepcion.RecargoCollectResuelto;
                objParams[4].Value = excepcion.SobreValorPendiente;
                objParams[5].Value = excepcion.SobreValorPendienteResuelto;
                objParams[6].Value = excepcion.AvisoNoEnviado;
                objParams[7].Value = excepcion.AvisoNoEnviadoResuelto;

                SqlCommand command = new SqlCommand("SP_N_PAPERLESS_USUARIO1_EXCEPCIONES", connparam);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = tranparam;
                IdExcepcion = Convert.ToInt64(command.ExecuteScalar());

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.ObjetoTransaccion = IdExcepcion;
            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        private static ResultadoTransaccion Usuario1ActualizaExcepcion(PaperlessExcepcion excepcion, SqlConnection connparam, SqlTransaction tranparam)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(connparam, "SP_U_PAPERLESS_USUARIO1_EXCEPCIONES");
                objParams[0].Value = excepcion.RecargoCollect;
                objParams[1].Value = excepcion.RecargoCollectResuelto;
                objParams[2].Value = excepcion.SobreValorPendiente;
                objParams[3].Value = excepcion.SobreValorPendienteResuelto;
                objParams[4].Value = excepcion.AvisoNoEnviado;
                objParams[5].Value = excepcion.AvisoNoEnviadoResuelto;
                objParams[6].Value = excepcion.Id;


                SqlCommand command = new SqlCommand("SP_U_PAPERLESS_USUARIO1_EXCEPCIONES", connparam);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = tranparam;
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

        public static IList<PaperlessTipoCarga> ListarTipoCarga(Enums.Estado activo)
        {
            PaperlessTipoCarga tipo = null;
            IList<PaperlessTipoCarga> tipos = new List<PaperlessTipoCarga>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_L_PAPERLESS_TIPO_CARGA");
                objParams[0].Value = activo;

                SqlCommand command = new SqlCommand("SP_L_PAPERLESS_TIPO_CARGA", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    tipo = new PaperlessTipoCarga();
                    tipo.Id = Convert.ToInt64(dreader["Id"]);
                    tipo.Nombre = dreader["Descripcion"].ToString();
                    tipo.Activo = Convert.ToBoolean(dreader["Activo"]);
                 
                    tipos.Add(tipo);
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

            return tipos;
        }
        public static IList<PaperlessTipoCarga> ListarTipoCargaDescripcionLarga(Enums.Estado activo)
        {
            PaperlessTipoCarga tipo = null;
            IList<PaperlessTipoCarga> tipos = new List<PaperlessTipoCarga>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_L_PAPERLESS_TIPO_CARGA_DESCRIPCION_LARGA");
                objParams[0].Value = activo;

                SqlCommand command = new SqlCommand("SP_L_PAPERLESS_TIPO_CARGA_DESCRIPCION_LARGA", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    tipo = new PaperlessTipoCarga();
                    tipo.Id = Convert.ToInt64(dreader["Id"]);
                    tipo.Nombre = dreader["Descripcion"].ToString();
                    tipo.Activo = Convert.ToBoolean(dreader["Activo"]);
                    tipo.DescripcionLarga = dreader["DescripcionLarga"].ToString();
                    tipos.Add(tipo);
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

            return tipos;
        }

        public static IList<PaperlessTipoServicio> ListarTipoServicios(Enums.Estado activo)
        {
            PaperlessTipoServicio tipo = null;
            IList<PaperlessTipoServicio> tipos = new List<PaperlessTipoServicio>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_L_PAPERLESS_TIPO_SERVICIO");
                objParams[0].Value = activo;

                SqlCommand command = new SqlCommand("SP_L_PAPERLESS_TIPO_SERVICIO", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    tipo = new PaperlessTipoServicio();
                    tipo.Id = Convert.ToInt64(dreader["Id"]);
                    tipo.Nombre = dreader["Descripcion"].ToString();
                    tipo.Activo = Convert.ToBoolean(dreader["Activo"]);

                    tipos.Add(tipo);
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

            return tipos;
        }


        public static PaperlessProcesoDuracion ObtenerDuracionProcesoPaperless(PaperlessTipoCarga tipocarga)
        {
            PaperlessProcesoDuracion tipo = null;

            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_PAPERLESS_PROCESO_DURACION");
                objParams[0].Value = tipocarga.Id;

                SqlCommand command = new SqlCommand("SP_C_PAPERLESS_PROCESO_DURACION", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    tipo = new PaperlessProcesoDuracion();
                    tipo.Id = Convert.ToInt64(dreader["Id"]);
                    tipo.TipoCarga = new PaperlessTipoCarga()
                    {
                        Id = Convert.ToInt64(dreader["IdTipoCarga"]),
                        Nombre = dreader["TipoCarga"].ToString()
                    };
                    tipo.Duracion = Convert.ToDecimal(dreader["Duracion"]);
                    //tipo.Activo = Convert.ToBoolean(dreader["Activo"]);
                    tipo.TiempoAlerta = Convert.ToDecimal(dreader["TiempoAlerta"]);

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

            return tipo;
        }


        //PROCESO TIEMPOS
        public static ResultadoTransaccion Usuario1RegistraComienzo(PaperlessProcesoRegistroTiempo inicio, SqlConnection connparam, SqlTransaction tranparam)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(connparam, "SP_N_PAPERLESS_PROCESOS_REGISTRO_COMIENZO_USUARIO1");
                objParams[0].Value = inicio.IdAsignacion;
                objParams[1].Value = inicio.ComienzoUsuario1;

                SqlCommand command = new SqlCommand("SP_N_PAPERLESS_PROCESOS_REGISTRO_COMIENZO_USUARIO1", connparam);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = tranparam;
                command.ExecuteNonQuery();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            finally
            {
                //conn.Close();
            }
            return resTransaccion;
        }

        public static ResultadoTransaccion Usuario2RegistraComienzo(PaperlessProcesoRegistroTiempo inicio, SqlConnection connparam, SqlTransaction tranparam)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(connparam, "SP_N_PAPERLESS_PROCESOS_REGISTRO_INICIO_USUARIO2");
                objParams[0].Value = inicio.IdAsignacion;
                objParams[1].Value = inicio.ComienzoUsuario2;

                SqlCommand command = new SqlCommand("SP_N_PAPERLESS_PROCESOS_REGISTRO_INICIO_USUARIO2", connparam);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = tranparam;
                command.ExecuteNonQuery();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            finally
            {
                //conn.Close();
            }
            return resTransaccion;
        }

        public static ResultadoTransaccion Usuario1RegistraTermino(PaperlessProcesoRegistroTiempo termino, SqlConnection connparam, SqlTransaction tranparam)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                //conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(connparam, "SP_N_PAPERLESS_PROCESOS_REGISTRO_TERMINO_USUARIO1");
                objParams[0].Value = termino.IdAsignacion;
                objParams[1].Value = termino.TerminoUsuario1;

                SqlCommand command = new SqlCommand("SP_N_PAPERLESS_PROCESOS_REGISTRO_TERMINO_USUARIO1", connparam);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = tranparam;
                command.ExecuteNonQuery();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            finally
            {
                //conn.Close();
            }
            return resTransaccion;
        }


        public static ResultadoTransaccion Usuario2RegistraTermino(PaperlessProcesoRegistroTiempo termino, SqlConnection connparam, SqlTransaction tranparam)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                //conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(connparam, "SP_N_PAPERLESS_PROCESOS_REGISTRO_TERMINO_USUARIO2");
                objParams[0].Value = termino.IdAsignacion;
                objParams[1].Value = termino.TerminoUsuario2;

                SqlCommand command = new SqlCommand("SP_N_PAPERLESS_PROCESOS_REGISTRO_TERMINO_USUARIO2", connparam);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = tranparam;
                command.ExecuteNonQuery();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            finally
            {
                //conn.Close();
            }
            return resTransaccion;
        }



        public static PaperlessProcesoRegistroTiempo ObtenerTiemposProceso(Int64 IdAsignacion)
        {
            PaperlessProcesoRegistroTiempo tipo = null;

            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_PAPERLESS_PROCESOS_REGISTRO_TIEMPOS");
                objParams[0].Value = IdAsignacion;

                SqlCommand command = new SqlCommand("SP_C_PAPERLESS_PROCESOS_REGISTRO_TIEMPOS", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    tipo = new PaperlessProcesoRegistroTiempo();
                    tipo.Id = Convert.ToInt64(dreader["Id"]);
                    tipo.IdAsignacion = IdAsignacion;

                    if (dreader["ComienzoUsuario1"] is DBNull)
                        tipo.ComienzoUsuario1 = null;
                    else
                        tipo.ComienzoUsuario1 = Convert.ToDateTime(dreader["ComienzoUsuario1"]);

                    if (dreader["TerminoUsuario1"] is DBNull)
                        tipo.TerminoUsuario1 = null;
                    else
                        tipo.TerminoUsuario1 = Convert.ToDateTime(dreader["TerminoUsuario1"]);

                    if (dreader["ComienzoUsuario2"] is DBNull)
                        tipo.ComienzoUsuario2 = null;
                    else
                        tipo.ComienzoUsuario2 = Convert.ToDateTime(dreader["ComienzoUsuario2"]);

                    if (dreader["TerminoUsaurio2"] is DBNull)
                        tipo.TerminoUsuario2 = null;
                    else
                        tipo.TerminoUsuario2 = Convert.ToDateTime(dreader["TerminoUsaurio2"]);
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

            return tipo;
        }

        public static ResultadoTransaccion Usuario2IngresarExcepxiones(IList<PaperlessExcepcion> excepciones, PaperlessPasosEstado paso)
        {
            ResultadoTransaccion resultado = new ResultadoTransaccion();
            conn = Base.BaseDatos.BaseDatos.NuevaConexion();
            SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                //Registrar excepciones
                foreach (var excepcion in excepciones)
                {
                    resultado = Usuario1ActualizaExcepcion(excepcion, conn, transaction);
                    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resultado.Descripcion);
                }

                //cambiar estado paso
                resultado = Usuario2CambiarEstadoPaso(paso, conn, transaction);
                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resultado.Descripcion);


                transaction.Commit();
                resultado.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                resultado.Estado = Enums.EstadoTransaccion.Rechazada;
                resultado.Descripcion = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return resultado;
        }

        public static ResultadoTransaccion Usuario2CambiarEstadoPaso(Entidades.Paperless.PaperlessPasosEstado paso, SqlConnection connparam, SqlTransaction tranparam)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(connparam, "SP_U_PAPERLESS_USUARIO2_PASOS_ESTADO");
                objParams[0].Value = paso.Estado;
                objParams[1].Value = paso.IdPasoEstado;

                SqlCommand command = new SqlCommand("SP_U_PAPERLESS_USUARIO2_PASOS_ESTADO", connparam);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = tranparam;
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

        public static ResultadoTransaccion Usuario2ActualizarHouseBL(IList<PaperlessUsuario1HousesBL> housesbl, PaperlessPasosEstado paso)
        {
            ResultadoTransaccion resultado = new ResultadoTransaccion();
            conn = Base.BaseDatos.BaseDatos.NuevaConexion();
            SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                //Actualiza house BL
                foreach (var house in housesbl)
                {
                    if (paso.Paso.NumPaso == 3)
                    {
                        if (house.ReciboAperturaEmbarcador && house.TipoReciboAperturaEmbarcador != Enums.PaperlessTipoReciboAperturaEmbarcador.NoDefinido)
                        {
                            resultado = Usuario2ActualizaHouseBL(house, conn, transaction);
                            if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                                throw new Exception(resultado.Descripcion);
                        }
                        else if (!house.ReciboAperturaEmbarcador && house.TipoReciboAperturaEmbarcador.Equals(Enums.PaperlessTipoReciboAperturaEmbarcador.NoRecibida))
                        {
                            resultado = Usuario2ActualizaHouseBL(house, conn, transaction);
                            if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                                throw new Exception(resultado.Descripcion);
                        }
                    }
                    else
                    {
                        resultado = Usuario2ActualizaHouseBL(house, conn, transaction);
                        if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                            throw new Exception(resultado.Descripcion);
                    }

                }

                //cambiar estado paso
                resultado = Usuario2CambiarEstadoPaso(paso, conn, transaction);
                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resultado.Descripcion);


                transaction.Commit();
                resultado.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                resultado.Estado = Enums.EstadoTransaccion.Rechazada;
                resultado.Descripcion = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return resultado;
        }

        public static ResultadoTransaccion Usuario2ActualizaHouseBL(PaperlessUsuario1HousesBL house, SqlConnection connparam, SqlTransaction tranparam)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(connparam, "SP_U_USUARIO2_HOUSESBL");
                objParams[0].Value = house.EmbarcadorContactado;
                objParams[1].Value = house.ReciboAperturaEmbarcador;
                objParams[2].Value = house.FechaReciboAperturaEmbarcador;
                objParams[3].Value = house.TipoReciboAperturaEmbarcador;
                objParams[4].Value = house.Id;
                objParams[5].Value = house.Observacion;


                SqlCommand command = new SqlCommand("SP_U_USUARIO2_HOUSESBL", connparam);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = tranparam;
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
        public static ResultadoTransaccion Usuario2ActualizaPaso(PaperlessAsignacion asignacion, PaperlessPasosEstado paso)
        {
            resTransaccion = new ResultadoTransaccion();
            SqlTransaction transaction = null;
            try
            {
                conn = BaseDatos.NuevaConexion();
                transaction = conn.BeginTransaction();

                //Cambia estado paso
                resTransaccion = Usuario2CambiarEstadoPaso(paso, conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                transaction.Commit();
            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
                if (transaction != null)
                    transaction.Rollback();
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return resTransaccion;
        }

        public static ResultadoTransaccion Usuario2TerminaProceso(PaperlessAsignacion asignacion, PaperlessPasosEstado paso, PaperlessProcesoRegistroTiempo termino)
        {
            resTransaccion = new ResultadoTransaccion();
            SqlTransaction transaction = null;
            try
            {
                conn = BaseDatos.NuevaConexion();
                transaction = conn.BeginTransaction();

                //Cambia estado paso
                resTransaccion = Usuario2CambiarEstadoPaso(paso, conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);

                //Cambiar estado asignacion                
                resTransaccion = CambiaEstadoAsignacion(asignacion, conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);

                //registrar termino proceso
                resTransaccion = Usuario2RegistraTermino(termino, conn, transaction);

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;


                transaction.Commit();


            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
                if (transaction != null)
                    transaction.Rollback();
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return resTransaccion;
        }


        public static ResultadoTransaccion AgregarLogAperturaNavieras(PaperlessLogAperturaNavieras LogApertura, SqlConnection connparam, SqlTransaction tranparam)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(connparam, "SP_N_PAPERLESS_LOG_FECHA_APERTURA_NAVIERAS");
                objParams[0].Value = LogApertura.IdAsignacion;
                objParams[1].Value = LogApertura.Accion;
                objParams[2].Value = LogApertura.IdUsuario;
                objParams[3].Value = LogApertura.ValorAnterior;
                objParams[4].Value = LogApertura.ValorNuevo;


                SqlCommand command = new SqlCommand("SP_N_PAPERLESS_LOG_FECHA_APERTURA_NAVIERAS", connparam);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = tranparam;
                command.ExecuteNonQuery();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            finally
            {
                //conn.Close();
            }
            return resTransaccion;
        }

        public static ResultadoTransaccion Usuario1RechazaAsignacion(PaperlessUsuario1Rechaza rechazo)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                conn = Base.BaseDatos.BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_PAPERLESS_ASIGNACION_RECHAZO");
                objParams[0].Value = rechazo.IdAsignacion;
                objParams[1].Value = rechazo.Usuario.Id;
                objParams[2].Value = rechazo.Motivo;

                SqlCommand command = new SqlCommand("SP_N_PAPERLESS_ASIGNACION_RECHAZO", conn);
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
            finally
            {
                conn.Close();
            }
            return resTransaccion;
        }

        public static PaperlessUsuario1Rechaza ObtenerRechazoAsignacion(Int64 IdAsignacion)
        {
            PaperlessUsuario1Rechaza rechazo = null;

            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_PAPERLESS_ASIGNACION_RECHAZO");
                objParams[0].Value = IdAsignacion;

                SqlCommand command = new SqlCommand("SP_C_PAPERLESS_ASIGNACION_RECHAZO", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    rechazo = new PaperlessUsuario1Rechaza();
                    rechazo.Id = Convert.ToInt64(dreader["Id"]);
                    rechazo.IdAsignacion = Convert.ToInt64(dreader["IdAsignacion"]);
                    rechazo.FechaRechazo = Convert.ToDateTime(dreader["FechaRechazo"]);
                    rechazo.Usuario = new clsUsuario()
                    {
                        ApellidoPaterno = dreader["ApellidoPaterno"].ToString(),
                        ApellidoMaterno = dreader["ApellidoMaterno"].ToString(),
                        Nombre = dreader["Nombres"].ToString()
                    };
                    rechazo.Motivo = dreader["Motivo"].ToString();
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

            return rechazo;
        }

        public static IList<PaperlessFlujo> ConsultarGestionPaperless(string nummaster, string numconsolidad, DateTime desde, DateTime hasta, Int64 usuario1, Int64 usuario2, string nave
            , DateTime desdeEmbarcadores, DateTime hastaEmbarcadores, DateTime desdeNavieras, DateTime hastaNavieras)
        {
            PaperlessFlujo asignaciones = null;
            IList<PaperlessFlujo> listasignaciones = new List<PaperlessFlujo>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_PAPERLESS_GESTION");
                objParams[0].Value = nummaster;
                objParams[1].Value = numconsolidad;
                objParams[2].Value = desde;
                objParams[3].Value = hasta;
                objParams[4].Value = usuario1;
                objParams[5].Value = usuario2;
                objParams[6].Value = nave;
                objParams[7].Value = desdeEmbarcadores;
                objParams[8].Value = hastaEmbarcadores;
                objParams[9].Value = desdeNavieras;
                objParams[10].Value = hastaNavieras;
                SqlCommand command = new SqlCommand("SP_C_PAPERLESS_GESTION", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    asignaciones = new PaperlessFlujo();
                    asignaciones.Asignacion.Id = Convert.ToInt64(dreader["Id"]);
                    asignaciones.Asignacion.NumMaster = dreader["NumMaster"].ToString();
                    asignaciones.Asignacion.FechaMaster = Convert.ToDateTime(dreader["FechaMaster"]);
                    asignaciones.Asignacion.Agente = new PaperlessAgente() { Nombre = dreader["Agente"].ToString() };
                    asignaciones.Asignacion.Naviera = new PaperlessNaviera() { Nombre = dreader["Naviera"].ToString() };
                    asignaciones.Asignacion.Nave = new PaperlessNave() { Nombre = dreader["Nave"].ToString() };
                    asignaciones.Asignacion.Viaje = dreader["Viaje"].ToString();
                    asignaciones.Asignacion.NumHousesBL = Convert.ToInt16(dreader["NumHousesBL"]);
                    asignaciones.Asignacion.TipoCarga = new PaperlessTipoCarga() { Nombre = dreader["TipoCarga"].ToString(), Id = Convert.ToInt64(dreader["IdTipoCarga"]) };
                    asignaciones.Asignacion.FechaPaso1 = Convert.ToDateTime(dreader["FechaPaso1"]);

                    if (dreader["FechaETA"] is DBNull)
                        asignaciones.Asignacion.FechaETA = null;
                    else
                        asignaciones.Asignacion.FechaETA = Convert.ToDateTime(dreader["FechaETA"]);

                    if (dreader["AperturaNavieras"] is DBNull)
                        asignaciones.Asignacion.AperturaNavieras = null;
                    else
                        asignaciones.Asignacion.AperturaNavieras = Convert.ToDateTime(dreader["AperturaNavieras"]);

                    if (dreader["PlazoEmbarcadores"] is DBNull)
                        asignaciones.Asignacion.PlazoEmbarcadores = null;
                    else
                        asignaciones.Asignacion.PlazoEmbarcadores = Convert.ToDateTime(dreader["PlazoEmbarcadores"]);

                    if (dreader["FechaPaso2"] is DBNull)
                        asignaciones.Asignacion.FechaPaso2 = null;
                    else
                        asignaciones.Asignacion.FechaPaso2 = Convert.ToDateTime(dreader["FechaPaso2"]);

                    if (dreader["U1N"] is DBNull)
                        asignaciones.Asignacion.Usuario1 = null;
                    else
                        asignaciones.Asignacion.Usuario1 = new clsUsuario(dreader["U1N"].ToString(), dreader["U1AP"].ToString(), dreader["U1AM"].ToString());

                    if (dreader["ObservacionUsuario1"] is DBNull)
                        asignaciones.Asignacion.ObservacionUsuario1 = "";
                    else
                        asignaciones.Asignacion.ObservacionUsuario1 = dreader["ObservacionUsuario1"].ToString();

                    if (dreader["Importancia"] is DBNull)
                        asignaciones.Asignacion.ImportanciaUsuario1 = null;
                    else
                        asignaciones.Asignacion.ImportanciaUsuario1 = new clsItemParametro() { Nombre = dreader["Importancia"].ToString() };

                    if (dreader["U2N"] is DBNull)
                        asignaciones.Asignacion.Usuario2 = null;
                    else
                        asignaciones.Asignacion.Usuario2 = new clsUsuario(dreader["U2N"].ToString(), dreader["U2AP"].ToString(), dreader["U2AM"].ToString());

                    if (dreader["ObservacionUsuario2"] is DBNull)
                        asignaciones.Asignacion.ObservacionUsuario2 = "";
                    else
                        asignaciones.Asignacion.ObservacionUsuario2 = dreader["ObservacionUsuario2"].ToString();

                    if (dreader["FechaPaso3"] is DBNull)
                        asignaciones.Asignacion.FechaPaso3 = null;
                    else
                        asignaciones.Asignacion.FechaPaso3 = Convert.ToDateTime(dreader["FechaPaso3"]);

                    asignaciones.EstadoFlujoDescripcion = dreader["Estado"].ToString();
                    asignaciones.EstadoFlujo = (Enums.EstadoPaperless)(int.Parse(dreader["IdEstado"].ToString()));
                    asignaciones.Asignacion.Estado = (Enums.EstadoPaperless)(int.Parse(dreader["IdEstado"].ToString()));

                    if (dreader["NumConsolidado"] is DBNull)
                        asignaciones.Asignacion.DataUsuario1.Paso1HousesBLInfo.NumConsolidado = "";
                    else
                        asignaciones.Asignacion.DataUsuario1.Paso1HousesBLInfo.NumConsolidado = dreader["NumConsolidado"].ToString();

                    if (dreader["ComienzoUsuario1"] is DBNull)
                        asignaciones.Asignacion.TiemposUsuarios.ComienzoUsuario1 = null;
                    else
                        asignaciones.Asignacion.TiemposUsuarios.ComienzoUsuario1 =
                            Convert.ToDateTime(dreader["ComienzoUsuario1"]);

                    if (dreader["TerminoUsuario1"] is DBNull)
                        asignaciones.Asignacion.TiemposUsuarios.TerminoUsuario1 = null;
                    else
                        asignaciones.Asignacion.TiemposUsuarios.TerminoUsuario1 =
                            Convert.ToDateTime(dreader["TerminoUsuario1"]);

                    if (dreader["ComienzoUsuario2"] is DBNull)
                        asignaciones.Asignacion.TiemposUsuarios.ComienzoUsuario2 = null;
                    else
                        asignaciones.Asignacion.TiemposUsuarios.ComienzoUsuario2 =
                            Convert.ToDateTime(dreader["ComienzoUsuario2"]);

                    if (dreader["TerminoUsaurio2"] is DBNull)
                        asignaciones.Asignacion.TiemposUsuarios.TerminoUsuario2 = null;
                    else
                        asignaciones.Asignacion.TiemposUsuarios.TerminoUsuario2 =
                            Convert.ToDateTime(dreader["TerminoUsaurio2"]);

                    if (dreader["UltimoPasoU1"] is DBNull)
                        asignaciones.Asignacion.TiemposUsuarios.UltimoPasoUsuario1 = null;
                    else
                        asignaciones.Asignacion.TiemposUsuarios.UltimoPasoUsuario1 =
                            Convert.ToDateTime(dreader["UltimoPasoU1"]);

                    if (dreader["UltimoPasoU2"] is DBNull)
                        asignaciones.Asignacion.TiemposUsuarios.UltimoPasoUsuario2 = null;
                    else
                        asignaciones.Asignacion.TiemposUsuarios.UltimoPasoUsuario2 =
                            Convert.ToDateTime(dreader["UltimoPasoU2"]);

                    asignaciones.Asignacion.FechaCreacion = Convert.ToDateTime(dreader["FechaCreacion"]);

                    asignaciones.Asignacion.VersionUsuario1 = Convert.ToInt16(dreader["versionUsuario1"]);
                    listasignaciones.Add(asignaciones);
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

            return listasignaciones;
        }

        public static ResultadoTransaccion CrearAgente(PaperlessAgente agente)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();

            conn = BaseDatos.Conexion();
            //Crear Transaccion
            var transaction = conn.BeginTransaction();

            long Id;
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_PAPERLESS_AGENTE");
                objParams[0].Value = agente.Nombre;
                objParams[1].Value = agente.Contacto;
                objParams[2].Value = agente.Email;
                objParams[3].Value = agente.Alias;

                SqlCommand command = new SqlCommand("SP_N_PAPERLESS_AGENTE", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                //Ejecutar transaccion
                transaction.Commit();
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se registró la información del agente correctamente";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsPaperlessADO.cs";
                res.MetodoError = "CrearAgente";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            }
            finally
            {
                conn.Close();
            }
            return res;
        }

        public static ResultadoTransaccion EliminarAgente(PaperlessAgente agente)
        {
            agente.Activo = false;
            var foo = EditarAgente(agente);
            if (foo.Estado.Equals(Enums.EstadoTransaccion.Aceptada))
                foo.Descripcion = "Se Elimino el agente correctamente";
            return foo;

        }

        public static ResultadoTransaccion EditarAgente(PaperlessAgente agente)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();

            conn = BaseDatos.Conexion();
            //Crear Transaccion
            var transaction = conn.BeginTransaction();

            long Id;
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_A_PAPERLESS_AGENTE");
                objParams[0].Value = agente.Id;
                objParams[1].Value = agente.Nombre;
                objParams[2].Value = agente.Contacto;
                objParams[3].Value = agente.Email;
                objParams[4].Value = agente.Activo;
                objParams[5].Value = agente.Alias;

                SqlCommand command = new SqlCommand("SP_A_PAPERLESS_AGENTE", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                //Ejecutar transaccion
                transaction.Commit();
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se actualizo la información del agente correctamente";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsPaperlessADO.cs";
                res.MetodoError = "CrearAgente";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            }
            finally
            {
                conn.Close();
            }
            return res;
        }

        public static bool ValidaNumMaster(string numMaster)
        {
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_PAPERLESS_NUMMASTER");
                objParams[0].Value = numMaster;

                SqlCommand command = new SqlCommand("SP_C_PAPERLESS_NUMMASTER", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    string num = dreader["nummaster"].ToString();
                    if (!string.IsNullOrEmpty(num))
                        return true;
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
            return false;
        }

        public static bool ValidaNumConsolidado(string numMaster, string idAsignacion)
        {
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_PAPERLESS_NUMCONSOLIDADO");
                objParams[0].Value = numMaster;

                SqlCommand command = new SqlCommand("SP_C_PAPERLESS_NUMCONSOLIDADO", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    string num = dreader["NumConsolidado"].ToString();
                    string idasignacionquery = dreader["idasignacion"].ToString();

                    if (idAsignacion != null && (numMaster != null && numMaster.Equals(num) && (idasignacionquery.Equals(idAsignacion))))
                        return false;
                    else if (!string.IsNullOrEmpty(num))
                        return true;
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
            return false;
        }

        public static ResultadoTransaccion Usuario1GuardarTipoTransito(IList<PaperlessUsuario1HousesBL> houses, PaperlessPasosEstado paso)
        {
            ResultadoTransaccion resultado = new ResultadoTransaccion();
            conn = Base.BaseDatos.BaseDatos.NuevaConexion();
            SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                //Eliminar Info anterior
                //resultado = Usuario1EliminarHousesBL(houses[0].IdAsignacion, conn, transaction);
                //if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                //    throw new Exception(resultado.Descripcion);

                //Registrar houses
                foreach (var house in houses)
                {
                    resultado = Usuario1GuardarTipoTransito(house, conn, transaction);
                    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resultado.Descripcion);
                }

                //cambiar estado paso
                resultado = Usuario1CambiarEstadoPaso(paso, conn, transaction);
                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resultado.Descripcion);


                transaction.Commit();
                resultado.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                resultado.Estado = Enums.EstadoTransaccion.Rechazada;
                resultado.Descripcion = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return resultado;

        }

        public static IList<PaperlessTipoTransito> ListarTiposTransitoTransbordo()
        {
            IList<PaperlessTipoTransito> tipos = new List<PaperlessTipoTransito>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();

                SqlCommand command = new SqlCommand("SP_L_PAPERLESS_TIPO_TRANSITO_TRANSBORDO", conn);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    var tipo = new PaperlessTipoTransito();
                    tipo.Id = Convert.ToInt64(dreader["Id"]);
                    tipo.Nombre = dreader["Descripcion"].ToString();
                    tipos.Add(tipo);
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

            return tipos;
        }

        public static IList<PaperlessUsuario1HousesBL> RefrescarTiposTransitoTransbordo(List<PaperlessUsuario1HousesBL> houses)
        {
            IList<PaperlessTipoTransito> tipos = new List<PaperlessTipoTransito>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                foreach (var house in houses)
                {


                    objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_PAPERLESS_USUARIO1_TRANSBORDOTRANSITO");
                    objParams[0].Value = house.Id;

                    SqlCommand command = new SqlCommand("SP_C_PAPERLESS_USUARIO1_TRANSBORDOTRANSITO", conn);
                    command.Parameters.AddRange(objParams);
                    command.CommandType = CommandType.StoredProcedure;
                    dreader = command.ExecuteReader();

                    while (dreader.Read())
                    {
                        var tipo = new PaperlessTipoTransito();
                        tipo.Id = Convert.ToInt64(dreader["Id"]);
                        tipo.Nombre = dreader["Descripcion"].ToString();
                        house.TransbordoTransito = tipo;
                    }
                    dreader.Close();
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

            return houses;
        }

        public static IList<PaperlessTipoExcepcion> ListarTiposExcepciones(string tipoE)
        {
            var tipos = new List<PaperlessTipoExcepcion>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_L_PAPERLESS_TIPO_EXCEPCIONES");
                objParams[0].Value = tipoE;


                SqlCommand command = new SqlCommand("SP_L_PAPERLESS_TIPO_EXCEPCIONES", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    var tipo = new PaperlessTipoExcepcion();
                    tipo.Id = Convert.ToInt64(dreader["Id"]);
                    tipo.Nombre = dreader["Descripcion"].ToString();
                    tipos.Add(tipo);
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

            return tipos;
        }

        public static IList<PaperlessTipoDisputa> ListarTiposDisputas()
        {
            var tipos = new List<PaperlessTipoDisputa>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();

                SqlCommand command = new SqlCommand("SP_L_PAPERLESS_TIPO_DISPUTAS", conn);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    var tipo = new PaperlessTipoDisputa();
                    tipo.Id = Convert.ToInt64(dreader["Id"]);
                    tipo.Nombre = dreader["Descripcion"].ToString();
                    tipos.Add(tipo);
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

            return tipos;
        }

        public static List<PaperlessTipoResponsabilidad> ListarTiposResponsabilidad(string resp)
        {
            var tipos = new List<PaperlessTipoResponsabilidad>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_L_PAPERLESS_TIPO_EXCEPCIONES");
                objParams[0].Value = resp;

                var command = new SqlCommand("SP_L_PAPERLESS_TIPO_RESPONSABILIDAD", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    var tipo = new PaperlessTipoResponsabilidad();
                    tipo.Id = Convert.ToInt64(dreader["Id"]);
                    tipo.Nombre = dreader["Descripcion"].ToString();
                    tipos.Add(tipo);
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
            return tipos;
        }

        public static ResultadoTransaccion Usuario1IngresarExcepxionesV2(IList<PaperlessExcepcion> excepciones, PaperlessPasosEstado pasoSeleccionado)
        {
            ResultadoTransaccion resultado = new ResultadoTransaccion();
            conn = BaseDatos.NuevaConexion();
            SqlTransaction transaction = conn.BeginTransaction();
            try
            {
                //Registrar excepciones
                foreach (var excepcion in excepciones)
                {
                    resultado = Usuario1ActualizaExcepcionV2(excepcion, conn, transaction);
                    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resultado.Descripcion);
                }

                //cambiar estado paso
                resultado = Usuario1CambiarEstadoPaso(pasoSeleccionado, conn, transaction);
                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resultado.Descripcion);


                transaction.Commit();
                resultado.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                resultado.Estado = Enums.EstadoTransaccion.Rechazada;
                resultado.Descripcion = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return resultado;
        }
        private static ResultadoTransaccion Usuario1ActualizaExcepcionV2(PaperlessExcepcion excepcion, SqlConnection connparam, SqlTransaction tranparam)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(connparam, "SP_U_PAPERLESS_USUARIO1_EXCEPCIONES_V2");
                objParams[0].Value = excepcion.TieneExcepcion;
                if (excepcion.TipoExcepcion != null)
                    objParams[1].Value = excepcion.TipoExcepcion.Id;
                else
                    objParams[1].Value = -1;
                if (excepcion.Responsabilidad != null)
                    objParams[2].Value = excepcion.Responsabilidad.Id;
                else
                    objParams[2].Value = -1;
                objParams[3].Value = excepcion.Id;

                objParams[4].Value = excepcion.Comentario ?? "";
                objParams[5].Value = excepcion.Resuelto;
                objParams[6].Value = excepcion.ResueltoUser2;

                SqlCommand command = new SqlCommand("SP_U_PAPERLESS_USUARIO1_EXCEPCIONES_V2", connparam);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = tranparam;
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

        public static IList<PaperlessExcepcion> RefrescarExcepciones(List<PaperlessExcepcion> excepciones)
        {
            IList<PaperlessTipoTransito> tipos = new List<PaperlessTipoTransito>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                foreach (var excepcion in excepciones)
                {


                    objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_PAPERLESS_USUARIO1_EXCEPCIONES_V2");
                    objParams[0].Value = excepcion.Id;

                    SqlCommand command = new SqlCommand("SP_C_PAPERLESS_USUARIO1_EXCEPCIONES_V2", conn);
                    command.Parameters.AddRange(objParams);
                    command.CommandType = CommandType.StoredProcedure;
                    dreader = command.ExecuteReader();

                    while (dreader.Read())
                    {
                        if (!String.IsNullOrEmpty(dreader["TieneExcepciones"].ToString()))
                            excepcion.TieneExcepcion = Convert.ToBoolean(dreader["TieneExcepciones"]);


                        var tipoExcepcion = new PaperlessTipoExcepcion();
                        if (!String.IsNullOrEmpty(dreader["id_tipo_excepcion"].ToString()))
                        {
                            tipoExcepcion.Id = Convert.ToInt64(dreader["id_tipo_excepcion"]);
                            tipoExcepcion.Nombre = dreader["descripcion_tipo_excepcion"].ToString();
                        }

                        var tipoResponsabilidad = new PaperlessTipoResponsabilidad();
                        if (!String.IsNullOrEmpty(dreader["id_tipo_responsabilidad"].ToString()))
                        {
                            tipoResponsabilidad.Id = Convert.ToInt64(dreader["id_tipo_responsabilidad"]);
                            tipoResponsabilidad.Nombre = dreader["descripcion_tipo_responsabilidad"].ToString();
                        }

                        if (!String.IsNullOrEmpty(dreader["Resuelto"].ToString()))
                            excepcion.Resuelto = Convert.ToBoolean(dreader["Resuelto"]);

                        if (!String.IsNullOrEmpty(dreader["Resuelto_User2"].ToString()))
                            excepcion.ResueltoUser2 = Convert.ToBoolean(dreader["Resuelto_User2"]);

                        excepcion.TipoExcepcion = tipoExcepcion;
                        excepcion.Responsabilidad = tipoResponsabilidad;


                    }
                    dreader.Close();
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

            return excepciones;
        }

        public static ResultadoTransaccion Usuario1GuardaDisputas(IList<PaperlessUsuario1Disputas> disputas, PaperlessAsignacion info, PaperlessPasosEstado pasoSeleccionado)
        {
            resTransaccion = new ResultadoTransaccion();
            conn = BaseDatos.NuevaConexion();
            var trans = conn.BeginTransaction();
            Int64 IdHouseInfo = 0;
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_D_PAPERLESS_USUARIO1_DISPUTAS_POR_ASIGNACION");
                objParams[0].Value = info.Id;

                SqlCommand command = new SqlCommand("SP_D_PAPERLESS_USUARIO1_DISPUTAS_POR_ASIGNACION", conn);
                command.Parameters.AddRange(objParams);
                command.Transaction = trans;
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                var error = false;
                foreach (var paperlessUsuario1Disputase in disputas)
                {
                    var res = GuardarDisputra(paperlessUsuario1Disputase, conn, trans, info);
                    if (res.Estado == Enums.EstadoTransaccion.Rechazada)
                        error = true;
                }

                //cambiar estado paso
                var resultado = Usuario1CambiarEstadoPaso(pasoSeleccionado, conn, trans);
                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resultado.Descripcion);


                if (error)
                {
                    resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                    trans.Rollback();
                }
                else
                {
                    resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                    trans.Commit();
                }

            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;

        }

        private static ResultadoTransaccion GuardarDisputra(PaperlessUsuario1Disputas disputa, SqlConnection connparam, SqlTransaction tranparam, PaperlessAsignacion asignacion)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_PAPERLESS_USUARIO1_DISPUTAS");
                objParams[0].Value = asignacion.Id;
                objParams[1].Value = disputa.Numero;
                objParams[2].Value = disputa.TipoDisputa.Id;
                objParams[3].Value = disputa.Descripcion;



                SqlCommand command = new SqlCommand("SP_N_PAPERLESS_USUARIO1_DISPUTAS", conn);
                command.Parameters.AddRange(objParams);
                command.Transaction = tranparam;
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

        public static IList<PaperlessUsuario1Disputas> ObtieneDisputas(PaperlessAsignacion paperlessAsignacion)
        {
            var listDisputas = new List<PaperlessUsuario1Disputas>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_L_PAPERLESS_USUARIO1_DISPUTAS_POR_ASIGNACION");
                objParams[0].Value = paperlessAsignacion.Id;
                SqlCommand command = new SqlCommand("SP_L_PAPERLESS_USUARIO1_DISPUTAS_POR_ASIGNACION", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    var disputa = new PaperlessUsuario1Disputas();
                    disputa.Id = Convert.ToInt64(dreader["Id"]);
                    if (!string.IsNullOrEmpty(dreader["Numero"].ToString()))
                        disputa.Numero = Convert.ToInt64(dreader["Numero"]);
                    disputa.Descripcion = dreader["Descripcion"].ToString();
                    //naviera.Activo = (Entidades.Enums.Enums.Estado)(Convert.ToInt16(dreader["Activo"]));
                    disputa.TipoDisputa = new PaperlessTipoDisputa();
                    disputa.TipoDisputa.Id = Convert.ToInt64(dreader["tipoId"]);
                    disputa.TipoDisputa.Nombre = dreader["tipoDescripcion"].ToString();
                    listDisputas.Add(disputa);
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

            return listDisputas;
        }

        public static DataTable ObtenerCantidadAsignacionesGrafico(string usuario, DateTime desde, DateTime hasta)
        {
            DataTable Grafica = new DataTable("Grafico");
            string Estado;
            string Vendedor;
            Int32 Value;
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_L_PAPERLESS_CANTIDAD_ASIGNACIONES");
                objParams[0].Value = usuario;
                objParams[1].Value = desde;
                objParams[2].Value = hasta;
                SqlCommand command = new SqlCommand("SP_L_PAPERLESS_CANTIDAD_ASIGNACIONES", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();


                Grafica.Columns.Add("Estado", typeof(String));
                Grafica.Columns.Add("Vendedor", typeof(String));
                Grafica.Columns.Add("Value", typeof(Int32));
                //Estado = "Polaco";
                //Vendedor ="Usuario 1";
                //Value = Convert.ToInt32(10);
                //Grafica.Rows.Add(new object[] { Estado, Vendedor, Value });


                while (dreader.Read())
                {
                    Estado = dreader["NOMBREUSUARIO"].ToString();
                    Vendedor = usuario;
                    Value = Convert.ToInt32(dreader["CANT"]);
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

        public static IList<PaperlessCantUsuarios> ObtenerCantidadAsignaciones(string usuario, DateTime desde, DateTime hasta)
        {
            var lista = new List<PaperlessCantUsuarios>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_L_PAPERLESS_CANTIDAD_ASIGNACIONES");
                objParams[0].Value = usuario;
                objParams[1].Value = desde;
                objParams[2].Value = hasta;
                SqlCommand command = new SqlCommand("SP_L_PAPERLESS_CANTIDAD_ASIGNACIONES", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    var ht = new PaperlessCantUsuarios();
                    ht.NombreUsuario = dreader["NOMBREUSUARIO"].ToString();
                    ht.Cantidad = Convert.ToInt32(dreader["CANT"]);
                    lista.Add(ht);
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

            return lista;
        }


    }
}

