using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.AccesoDatos.Ventas;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Clientes.Direcciones;
using ProyectoCraft.Entidades.Clientes.TargetAccount;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Ventas.Traficos;

namespace ProyectoCraft.AccesoDatos.Clientes
{
    public class clsTargetAccountADO
    {
        private static SqlParameter[] objParams = null;
        private static SqlDataReader dreader = null;

        public static ResultadoTransaccion CreatTargetAccount(string NombreCompania, Int64 IdTargetSource)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_N_CLIENTES_TARGET_ACCOUNT");
                objParams[0].Value = NombreCompania;
                objParams[1].Value = IdTargetSource;
                objParams[2].Value = Enums.EstadosMetas.Asignado;
                objParams[3].Value = Base.Usuario.UsuarioConectado.Usuario.Id;
                SqlCommand command3 = new SqlCommand("SP_N_CLIENTES_TARGET_ACCOUNT", BaseDatos.Conexion());
                command3.Parameters.AddRange(objParams);
                command3.CommandType = CommandType.StoredProcedure;
                command3.ExecuteNonQuery();

                res.Estado = Enums.EstadoTransaccion.Aceptada;
                

            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public static ResultadoTransaccion ObtenerTargetAccountPorIdSource(Int64 IdTargetSource)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            clsTargetAccount taccount = null;
            try
            {

                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_C_CLIENTES_TARGET_ACCOUNT_IDSOURCE");
                objParams[0].Value = IdTargetSource;
                SqlCommand command = new SqlCommand("SP_C_CLIENTES_TARGET_ACCOUNT_IDSOURCE", BaseDatos.Conexion());
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    taccount = new  clsTargetAccount();

                    //PASO 1
                    taccount.ClienteMaster = clsClienteMasterADO.ObtenerClienteMasterPorId(Convert.ToInt64(dreader["IdMaster"]));
                                        
                    //if (dreader["IdDireccionInfo"] is DBNull)
                    //    taccount.ClienteMaster.DireccionInfo = null;
                    //else
                    //    taccount.ClienteMaster.DireccionInfo =
                    //        clsDireccionADO.ListarDireccionesPorIdInfo(Convert.ToInt64(dreader["IdDireccionInfo"]));

                    taccount.ClienteMaster.UsuarioCreo = new clsUsuario();
                    taccount.ClienteMaster.UsuarioCreo.Nombre = dreader["NombreUsuario"].ToString();
                    taccount.ClienteMaster.UsuarioCreo.ApellidoPaterno = dreader["ApellidoPaterno"].ToString();
                    taccount.ClienteMaster.UsuarioCreo.ApellidoMaterno = dreader["ApellidoMaterno"].ToString();

                    taccount.Id = Convert.ToInt64(dreader["IdTargetAccount"]);
                    taccount.IdTargetSource = Convert.ToInt64(dreader["IdTargetSource"]);

                    taccount.TelefonoEmpresa = dreader["TelefonoEmpresa"].ToString();
                    taccount.TelefonoDirecto = dreader["TelefonoDirecto"].ToString();

                    if (dreader["EmbarquesPorMes"] is DBNull)
                        taccount.EmbarquesPorMes = null;
                    else
                        taccount.EmbarquesPorMes = Convert.ToInt16(dreader["EmbarquesPorMes"]);

                    if (dreader["CantidadLCL"] is DBNull)
                        taccount.CantidadLCL = null;
                    else 
                        taccount.CantidadLCL = Convert.ToInt16(dreader["CantidadLCL"]);

                    if (dreader["UMLCL"] is DBNull)
                        taccount.UMLCL = new clsItemParametro();
                    else 
                        taccount.UMLCL = Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["UMLCL"]));

                    if (dreader["CantidadFCL"] is DBNull)
                        taccount.CantidadFCL = null;
                    else 
                        taccount.CantidadFCL = Convert.ToInt16(dreader["CantidadFCL"]);

                    if (dreader["UMFCL"] is DBNull)
                        taccount.UMFCL = new clsItemParametro();
                    else 
                        taccount.UMFCL = Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["UMFCL"]));

                    if (dreader["CantidadAereo"] is DBNull)
                        taccount.CantidadAereo = null;
                    else 
                        taccount.CantidadAereo = Convert.ToInt16(dreader["CantidadAereo"]);

                    if (dreader["UMAereo"] is DBNull)
                        taccount.UMAereo = new clsItemParametro();
                    else 
                        taccount.UMAereo = Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["UMAereo"]));

                    if (dreader["IdTerminoCompra"] is DBNull)
                        taccount.TerminoCompra = new clsItemParametro();
                    else 
                        taccount.TerminoCompra = Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdTerminoCompra"]));

                    if (dreader["IdIncoTerm"] is DBNull)
                        taccount.IncoTerm = new clsIncoTerm();
                    else 
                        taccount.IncoTerm = Parametros.clsParametrosClientesDAO.ObtenerIncoTermPorId(Convert.ToInt16(dreader["IdIncoTerm"]));

                    taccount.Traficos = ObtenerTraficosTargetAccount(taccount.ClienteMaster.Id);

                    taccount.OrigenesCarga = ObtenerOrigenCargaTargetAccount(taccount.ClienteMaster.Id);
                    taccount.DestinosCarga = ObtenerDestinoCargaTargetAccount(taccount.ClienteMaster.Id);

                    taccount.ObservacionInfGeneral = dreader["ObservacionInfGral"].ToString();

                    //PASO 2
                    taccount.ContactoNombre = dreader["ContactoNombre"].ToString();
                    taccount.ContactoEmail = dreader["ContactoEmail"].ToString();
                    taccount.ContactoCargo = dreader["ContactoPosicion"].ToString();
                    taccount.ObservacionLlamadaTelefonica = dreader["ObservacionTelefonico"].ToString();

                    taccount.EmbarcaCon = ObtenerEmpresasCompetenciaTargetAccount(taccount.Id);
                    taccount.TomaDesiciones = ObtenerTomaDesicionesTargetAccount(taccount.Id);


                    //PASO 3
                    taccount.ObservacionVisita = dreader["ObservacionVisita"].ToString();
                    taccount.ClienteMaster.ProductosPreferidos =
                        Clientes.clsClienteMasterADO.ObtenerProductosPreferidos(taccount.ClienteMaster.Id);

                    taccount.ServiciosComplementarios = ObtenerServiciosComplementariosTargetAccount(taccount.Id);
                    taccount.Personales = ObtenerPersonalesTargetAccount(taccount.Id);
                    taccount.Objeciones = ObtenerObjecionesTargetAccount(taccount.Id);
                    taccount.AccionTomar = ObtenerAccionTomarTargetAccount(taccount.Id);




                    taccount.Estado = (Enums.EstadosMetas)Convert.ToInt16(dreader["Estado"]);
                    
                }
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.ObjetoTransaccion = taccount;

            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                res.Accion = Enums.AccionTransaccion.Consultar;
            }
            finally
            {
                if (!dreader.IsClosed) dreader.Close();
                BaseDatos.CerrarConexion();
            }

            return res;
        }

        public static ResultadoTransaccion ObtenerTargetAccountPorIdMaster(Int64 IdMaster)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            clsTargetAccount taccount = null;
            try
            {

                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_C_CLIENTES_TARGET_ACCOUNT_PORIDMASTER");
                objParams[0].Value = IdMaster;
                SqlCommand command = new SqlCommand("SP_C_CLIENTES_TARGET_ACCOUNT_PORIDMASTER", BaseDatos.Conexion());
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    taccount = new clsTargetAccount();

                    //PASO 1
                    taccount.ClienteMaster = clsClienteMasterADO.ObtenerClienteMasterPorId(Convert.ToInt64(dreader["IdMaster"]));

                    //if (dreader["IdDireccionInfo"] is DBNull)
                    //    taccount.ClienteMaster.DireccionInfo = null;
                    //else
                    //    taccount.ClienteMaster.DireccionInfo =
                    //        clsDireccionADO.ListarDireccionesPorIdInfo(Convert.ToInt64(dreader["IdDireccionInfo"]));

                    taccount.ClienteMaster.UsuarioCreo = new clsUsuario();
                    taccount.ClienteMaster.UsuarioCreo.Nombre = dreader["NombreUsuario"].ToString();
                    taccount.ClienteMaster.UsuarioCreo.ApellidoPaterno = dreader["ApellidoPaterno"].ToString();
                    taccount.ClienteMaster.UsuarioCreo.ApellidoMaterno = dreader["ApellidoMaterno"].ToString();

                    taccount.Id = Convert.ToInt64(dreader["IdTargetAccount"]);
                    taccount.IdTargetSource = Convert.ToInt64(dreader["IdTargetSource"]);

                    taccount.TelefonoEmpresa = dreader["TelefonoEmpresa"].ToString();
                    taccount.TelefonoDirecto = dreader["TelefonoDirecto"].ToString();

                    if (dreader["EmbarquesPorMes"] is DBNull)
                        taccount.EmbarquesPorMes = null;
                    else
                        taccount.EmbarquesPorMes = Convert.ToInt16(dreader["EmbarquesPorMes"]);

                    if (dreader["CantidadLCL"] is DBNull)
                        taccount.CantidadLCL = null;
                    else
                        taccount.CantidadLCL = Convert.ToInt16(dreader["CantidadLCL"]);

                    if (dreader["UMLCL"] is DBNull)
                        taccount.UMLCL = new clsItemParametro();
                    else
                        taccount.UMLCL = Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["UMLCL"]));

                    if (dreader["CantidadFCL"] is DBNull)
                        taccount.CantidadFCL = null;
                    else
                        taccount.CantidadFCL = Convert.ToInt16(dreader["CantidadFCL"]);

                    if (dreader["UMFCL"] is DBNull)
                        taccount.UMFCL = new clsItemParametro();
                    else
                        taccount.UMFCL = Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["UMFCL"]));

                    if (dreader["CantidadAereo"] is DBNull)
                        taccount.CantidadAereo = null;
                    else
                        taccount.CantidadAereo = Convert.ToInt16(dreader["CantidadAereo"]);

                    if (dreader["UMAereo"] is DBNull)
                        taccount.UMAereo = new clsItemParametro();
                    else
                        taccount.UMAereo = Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["UMAereo"]));

                    if (dreader["IdTerminoCompra"] is DBNull)
                        taccount.TerminoCompra = new clsItemParametro();
                    else
                        taccount.TerminoCompra = Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdTerminoCompra"]));

                    if (dreader["IdIncoTerm"] is DBNull)
                        taccount.IncoTerm = new clsIncoTerm();
                    else
                        taccount.IncoTerm = Parametros.clsParametrosClientesDAO.ObtenerIncoTermPorId(Convert.ToInt16(dreader["IdIncoTerm"]));

                    taccount.Traficos = ObtenerTraficosTargetAccount(taccount.ClienteMaster.Id);

                    taccount.OrigenesCarga = ObtenerOrigenCargaTargetAccount(taccount.ClienteMaster.Id);
                    taccount.DestinosCarga = ObtenerDestinoCargaTargetAccount(taccount.ClienteMaster.Id);

                    taccount.ObservacionInfGeneral = dreader["ObservacionInfGral"].ToString();

                    //PASO 2
                    taccount.ContactoNombre = dreader["ContactoNombre"].ToString();
                    taccount.ContactoEmail = dreader["ContactoEmail"].ToString();
                    taccount.ContactoCargo = dreader["ContactoPosicion"].ToString();
                    taccount.ObservacionLlamadaTelefonica = dreader["ObservacionTelefonico"].ToString();

                    taccount.EmbarcaCon = ObtenerEmpresasCompetenciaTargetAccount(taccount.Id);
                    taccount.TomaDesiciones = ObtenerTomaDesicionesTargetAccount(taccount.Id);


                    //PASO 3
                    taccount.ObservacionVisita = dreader["ObservacionVisita"].ToString();
                    taccount.ClienteMaster.ProductosPreferidos =
                        Clientes.clsClienteMasterADO.ObtenerProductosPreferidos(taccount.ClienteMaster.Id);

                    taccount.ServiciosComplementarios = ObtenerServiciosComplementariosTargetAccount(taccount.Id);
                    taccount.Personales = ObtenerPersonalesTargetAccount(taccount.Id);
                    taccount.Objeciones = ObtenerObjecionesTargetAccount(taccount.Id);
                    taccount.AccionTomar = ObtenerAccionTomarTargetAccount(taccount.Id);




                    taccount.Estado = (Enums.EstadosMetas)Convert.ToInt16(dreader["Estado"]);

                }
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.ObjetoTransaccion = taccount;

            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                res.Accion = Enums.AccionTransaccion.Consultar;
            }
            finally
            {
                if (!dreader.IsClosed) dreader.Close();
                BaseDatos.CerrarConexion();
            }

            return res;
        }

        #region "Target Account Paso 1"

        public static ResultadoTransaccion ActualizarPaso1(clsTargetAccount targetaccount)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            ResultadoTransaccion resTransaccion = null;
            
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Registrar Direcciones
                resTransaccion = clsDireccionADO.GuardarDirecciones(targetaccount.ClienteMaster.DireccionInfo, conn,
                                                                    transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                {
                    throw new Exception(resTransaccion.Descripcion);
                }
                targetaccount.ClienteMaster.DireccionInfo = (clsDireccionInfo) resTransaccion.ObjetoTransaccion;

                //Registrar Cliente Master
                resTransaccion = clsClienteMasterADO.ActualizarClienteMaster(targetaccount.ClienteMaster, conn,
                                                                          transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);

                //Actualizar Target Account Paso 1
                resTransaccion = ActualizarTargetAccountInfGeneralP1(targetaccount,conn,transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);


                //Borrar traficos
                resTransaccion = BorrarTraficosTargetAccount(targetaccount.ClienteMaster.Id, conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);

                //Guardar Traficos
                Int64 IdTrafico = 0;

                foreach (var trafico in targetaccount.Traficos)
                {
                    IdTrafico = trafico.Id;
                    if (trafico.IsNew)
                    {
                        resTransaccion = new ResultadoTransaccion();
                        resTransaccion = clsTipoProductosADO.CrearNuevoTrafico(trafico, conn, transaction);
                        if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                            throw new Exception(resTransaccion.Descripcion);

                        trafico.Id = (Int64)resTransaccion.ObjetoTransaccion;
                    }


                    resTransaccion = AsignarTraficoTargetAccount(targetaccount.ClienteMaster.Id, trafico.Id, conn,
                                                                 transaction);
                    if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resTransaccion.Descripcion);
                }


                //Borrar Origenes
                resTransaccion = BorrarOrigenesCargaTargetAccount(targetaccount.ClienteMaster.Id, conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);

                //Guardar Origenes de Carga
                Int64 idOrigenCarga = 0;
                foreach (var origen in targetaccount.OrigenesCarga)
                {
                    idOrigenCarga = origen.Id;
                    if(origen.IsNew)
                    {
                        resTransaccion = AgregarOrigenCarga(origen, conn, transaction);
                        if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                            throw new Exception(resTransaccion.Descripcion);

                        idOrigenCarga = (Int64)resTransaccion.ObjetoTransaccion;
                    }

                    resTransaccion = AsignarOrigenCargaTargetAccount(targetaccount.ClienteMaster.Id, idOrigenCarga,conn,transaction);
                    if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resTransaccion.Descripcion);
                    
                }


                //Borrar Destinos
                resTransaccion = BorrarDestinosCargaTargetAccount(targetaccount.ClienteMaster.Id, conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);

                //Guardar Destinos de Carga
                Int64 idDestinoCarga = 0;
                foreach (var destino in targetaccount.DestinosCarga)
                {
                    idDestinoCarga = destino.Id;
                    if (destino.IsNew)
                    {
                        resTransaccion = AgregarDestinoCarga(destino, conn, transaction);
                        if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                            throw new Exception(resTransaccion.Descripcion);

                        idDestinoCarga = (Int64)resTransaccion.ObjetoTransaccion;
                    }

                    resTransaccion = AsignarDestinoCargaTargetAccount(targetaccount.ClienteMaster.Id, idDestinoCarga, conn, transaction);
                    if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resTransaccion.Descripcion);

                }
                
                //Cambiar Estado Meta
                resTransaccion = AccesoDatos.Direccion.Metas.clsMetaAdo.GuardarCambioEstadoTransaction(targetaccount.IdTargetSource, Convert.ToInt16(targetaccount.Estado),conn,transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);


                //Ejecutar transaccion
                transaction.Commit();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;


            }
            catch(Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                resTransaccion.ArchivoError = "clsTargetAccountADO";
                resTransaccion.MetodoError = MethodBase.GetCurrentMethod().Name;
            }
            finally
            {
                conn.Close();                
                                
            }

            return resTransaccion;
        }

        public static ResultadoTransaccion ActualizarPaso2(clsTargetAccount targetaccount)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            ResultadoTransaccion resTransaccion = null;

            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Crear Transaccion
                transaction = conn.BeginTransaction();
                
                //Actualizar Target Account Paso 2
                resTransaccion = ActualizarTargetAccountInfLlamadaP2(targetaccount, conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);


                //Borrar empresas competencia
                resTransaccion = BorrarEmpresaCompetenciaTargetAccount(targetaccount.Id, conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);

                //Registrar empresa competencia
                Int64 idEmpresaCompetencia = 0;
                
                foreach (clsTargetAccountCompetencia competencia in targetaccount.EmbarcaCon)
                {
                    idEmpresaCompetencia = competencia.Id;
                    if(competencia.IsNew)
                    {
                        resTransaccion = AgregarEmpresaCompetencia(competencia, conn, transaction);
                        if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                            throw new Exception(resTransaccion.Descripcion);

                        idEmpresaCompetencia = (Int64)resTransaccion.ObjetoTransaccion;
                    }

                    resTransaccion = AsignarEmpresaCompetenciaTargetAccount(targetaccount.Id, idEmpresaCompetencia,
                                                                            conn, transaction);
                    if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resTransaccion.Descripcion);
                }
                

                //Borrar Personas Toman Desiciones
                resTransaccion = BorrarTomaDesicionesTargetAccount(targetaccount.Id, conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);
               
                //Asignar Personas toman Desiciones
                foreach (var tomadesicion in targetaccount.TomaDesiciones)
                {
                    resTransaccion = AsignarTomaDesicionTargetAccount(targetaccount.Id, tomadesicion, conn, transaction);
                    if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resTransaccion.Descripcion);
                }

                //Cambiar Estado Meta
                resTransaccion = AccesoDatos.Direccion.Metas.clsMetaAdo.GuardarCambioEstadoTransaction(targetaccount.IdTargetSource, Convert.ToInt16(targetaccount.Estado), conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);

                //Ejecutar transaccion
                transaction.Commit();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;


            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                resTransaccion.ArchivoError = "clsTargetAccountADO";
                resTransaccion.MetodoError = MethodBase.GetCurrentMethod().Name;
            }
            finally
            {
                conn.Close();

            }

            return resTransaccion;
        }

        public static ResultadoTransaccion ActualizarPaso3(clsTargetAccount targetaccount)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            ResultadoTransaccion resTransaccion = null;

            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Actualizar Target Account Paso 3
                resTransaccion = ActualizarTargetAccountInfVisitaP3(targetaccount, conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);


                //Asignar productos
                resTransaccion = clsClienteMasterADO.BorrarProductos(targetaccount.ClienteMaster.Id, transaction,conn);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);


                foreach (var producto in targetaccount.ClienteMaster.ProductosPreferidos)
                {
                   resTransaccion = clsClienteMasterADO.AsignarTipoProducto(producto, targetaccount.ClienteMaster.Id, transaction, conn);
                   if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                       throw new Exception(resTransaccion.Descripcion);

                }

                //Servicios Complementarios
                resTransaccion = BorrarServiciosComplementariosTargetAccount(targetaccount.Id, conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);

                foreach (var servicio in targetaccount.ServiciosComplementarios)
                {
                    resTransaccion = AsignarServicioComplementarioTargetAccount(targetaccount.Id, servicio,conn,transaction);
                    if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resTransaccion.Descripcion);
                }
                

                //Personales
                resTransaccion = BorrarPersonalesTargetAccount(targetaccount.Id, conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);
                foreach (var personal in targetaccount.Personales)
                {
                    resTransaccion = AsignarPersonalesTargetAccount(targetaccount.Id, personal, conn, transaction);
                    if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resTransaccion.Descripcion);

                }

                //Objeciones
                resTransaccion = BorrarObjecionesTargetAccount(targetaccount.Id, conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);
                foreach (var objecion in targetaccount.Objeciones)
                {
                    resTransaccion = AsignarObjecionesTargetAccount(targetaccount.Id, objecion, conn, transaction);
                    if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resTransaccion.Descripcion);
                }

                //Acciones Tomar
                resTransaccion = BorrarAccionesTomarTargetAccount(targetaccount.Id, conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);

                resTransaccion = AsignarAccionTomarTargetAccount(targetaccount.Id, targetaccount.AccionTomar, conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);


                //foreach (var accion in targetaccount.AccionesTomar)
                //{
                //    if(accion.IsNew)
                //    {
                //        resTransaccion = CrearAccionATomar(accion, conn, transaction);
                //        if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                //            throw new Exception(resTransaccion.Descripcion);

                //        accion.Id = Convert.ToInt64(resTransaccion.ObjetoTransaccion);
                //    }


                //    resTransaccion = AsignarAccionTomarTargetAccount(targetaccount.Id, accion, conn, transaction);
                //    if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                //        throw new Exception(resTransaccion.Descripcion);
                //}

                //Cambiar Estado Meta
                resTransaccion = AccesoDatos.Direccion.Metas.clsMetaAdo.GuardarCambioEstadoTransaction(targetaccount.IdTargetSource, Convert.ToInt16(targetaccount.Estado), conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);


                //Ejecutar transaccion
                transaction.Commit();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;


            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                resTransaccion.ArchivoError = "clsTargetAccountADO";
                resTransaccion.MetodoError = MethodBase.GetCurrentMethod().Name;
            }
            finally
            {
                conn.Close();

            }

            return resTransaccion;


            

        }

        #endregion

        private static ResultadoTransaccion ActualizarTargetAccountInfGeneralP1(clsTargetAccount targetaccount, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_A_CLIENTES_TARGET_ACCOUNT_INFGENERAL_P1");
                objParams[0].Value = targetaccount.Id;
                objParams[1].Value = targetaccount.TelefonoEmpresa;
                objParams[2].Value = targetaccount.TelefonoDirecto;
                if (targetaccount.EmbarquesPorMes.HasValue)
                    objParams[3].Value = targetaccount.EmbarquesPorMes;
                else
                    objParams[3].Value = -1;

                if (targetaccount.CantidadLCL.HasValue)
                    objParams[4].Value = targetaccount.CantidadLCL;
                else
                    objParams[4].Value = -1;

                objParams[5].Value = targetaccount.UMLCL.Id;

                if (targetaccount.CantidadFCL.HasValue)
                    objParams[6].Value = targetaccount.CantidadFCL;
                else
                    objParams[6].Value = -1;

                objParams[7].Value = targetaccount.UMFCL.Id;

                if (targetaccount.CantidadAereo.HasValue)
                    objParams[8].Value = targetaccount.CantidadAereo;
                else
                    objParams[8].Value = -1;

                objParams[9].Value = targetaccount.UMAereo.Id;
                objParams[10].Value = targetaccount.TerminoCompra.Id;
                objParams[11].Value = targetaccount.IncoTerm.Id32;
                objParams[12].Value = targetaccount.ObservacionInfGeneral;
                objParams[13].Value = targetaccount.Estado;
                SqlCommand command3 = new SqlCommand("SP_A_CLIENTES_TARGET_ACCOUNT_INFGENERAL_P1", conn);
                command3.Transaction = transaction;
                command3.Parameters.AddRange(objParams);
                command3.CommandType = CommandType.StoredProcedure;
                command3.ExecuteNonQuery();

                res.Estado = Enums.EstadoTransaccion.Aceptada;


            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        private static ResultadoTransaccion ActualizarTargetAccountInfLlamadaP2(clsTargetAccount targetaccount, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_A_CLIENTES_TARGET_ACCOUNT_LLAMADA_P2");
                objParams[0].Value = targetaccount.Id;
                objParams[1].Value = targetaccount.ContactoNombre;
                objParams[2].Value = targetaccount.ContactoEmail;
                objParams[3].Value = targetaccount.ContactoCargo;
                objParams[4].Value = targetaccount.ObservacionLlamadaTelefonica;
                objParams[5].Value = targetaccount.Estado;

                SqlCommand command3 = new SqlCommand("SP_A_CLIENTES_TARGET_ACCOUNT_LLAMADA_P2", conn);
                command3.Transaction = transaction;
                command3.Parameters.AddRange(objParams);
                command3.CommandType = CommandType.StoredProcedure;
                command3.ExecuteNonQuery();

                res.Estado = Enums.EstadoTransaccion.Aceptada;


            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        private static ResultadoTransaccion ActualizarTargetAccountInfVisitaP3(clsTargetAccount targetaccount, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_A_CLIENTES_TARGET_ACCOUNT_VISITA_P3");
                objParams[0].Value = targetaccount.Id;
                objParams[1].Value = targetaccount.ObservacionVisita;                
                objParams[2].Value = targetaccount.Estado;

                SqlCommand command3 = new SqlCommand("SP_A_CLIENTES_TARGET_ACCOUNT_VISITA_P3", conn);
                command3.Transaction = transaction;
                command3.Parameters.AddRange(objParams);
                command3.CommandType = CommandType.StoredProcedure;
                command3.ExecuteNonQuery();

                res.Estado = Enums.EstadoTransaccion.Aceptada;


            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public static ResultadoTransaccion AgregarOrigenCarga(clsTipoOrigenCarga origen, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            Int64 idOrigenCarga = 0;
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_TIPO_ORIGEN_CARGA");
                objParams[0].Value = origen.Nombre;
                objParams[1].Value = origen.Usuario.Id;
                SqlCommand command4 = new SqlCommand("SP_N_TIPO_ORIGEN_CARGA", conn);
                command4.Transaction = transaction;
                command4.Parameters.AddRange(objParams);
                command4.CommandType = CommandType.StoredProcedure;
                idOrigenCarga = Convert.ToInt64(command4.ExecuteScalar());

                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.ObjetoTransaccion = idOrigenCarga;

            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public static ResultadoTransaccion AsignarOrigenCargaTargetAccount(Int64 IdMaster, Int64 IdOrigen, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_CLIENTES_MASTER_ORIGENCARGA");
                objParams[0].Value = IdMaster;
                objParams[1].Value = IdOrigen;
                SqlCommand command4 = new SqlCommand("SP_N_CLIENTES_MASTER_ORIGENCARGA", conn);
                command4.Transaction = transaction;
                command4.Parameters.AddRange(objParams);
                command4.CommandType = CommandType.StoredProcedure;
                command4.ExecuteNonQuery();
            
                res.Estado = Enums.EstadoTransaccion.Aceptada;
            
            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public static ResultadoTransaccion AgregarDestinoCarga(clsTipoDestinoCarga destino, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            Int64 idOrigenCarga = 0;
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_TIPO_DESTINO_CARGA");
                objParams[0].Value = destino.Nombre;
                objParams[1].Value = destino.Usuario.Id;
                SqlCommand command4 = new SqlCommand("SP_N_TIPO_DESTINO_CARGA", conn);
                command4.Transaction = transaction;
                command4.Parameters.AddRange(objParams);
                command4.CommandType = CommandType.StoredProcedure;
                idOrigenCarga = Convert.ToInt64(command4.ExecuteScalar());

                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.ObjetoTransaccion = idOrigenCarga;

            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public static ResultadoTransaccion AsignarDestinoCargaTargetAccount(Int64 IdMaster, Int64 IdDestino, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_CLIENTES_MASTER_DESTINOCARGA");
                objParams[0].Value = IdMaster;
                objParams[1].Value = IdDestino;
                SqlCommand command4 = new SqlCommand("SP_N_CLIENTES_MASTER_DESTINOCARGA", conn);
                command4.Transaction = transaction;
                command4.Parameters.AddRange(objParams);
                command4.CommandType = CommandType.StoredProcedure;
                command4.ExecuteNonQuery();

                res.Estado = Enums.EstadoTransaccion.Aceptada;
                
            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }


        public static ResultadoTransaccion BorrarTraficosTargetAccount(Int64 IdMaster, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_E_CLIENTES_MASTER_TRAFICOS");
                objParams[0].Value = IdMaster;                
                SqlCommand command4 = new SqlCommand("SP_E_CLIENTES_MASTER_TRAFICOS", conn);
                command4.Transaction = transaction;
                command4.Parameters.AddRange(objParams);
                command4.CommandType = CommandType.StoredProcedure;
                command4.ExecuteNonQuery();
                res.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public static ResultadoTransaccion AsignarTraficoTargetAccount(Int64 IdMaster, Int64 IdTrafico, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_CLIENTES_MASTER_TRAFICOS");
                objParams[0].Value = IdMaster;
                objParams[1].Value = IdTrafico;
                SqlCommand command4 = new SqlCommand("SP_N_CLIENTES_MASTER_TRAFICOS", conn);
                command4.Transaction = transaction;
                command4.Parameters.AddRange(objParams);
                command4.CommandType = CommandType.StoredProcedure;
                command4.ExecuteNonQuery();
                res.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public static IList<clsTrafico> ObtenerTraficosTargetAccount(Int64 IdTargetAccount)
        {
            IList<clsTrafico> listado = new List<clsTrafico>();
            clsTrafico trafico = null;
            try
            {

                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.NuevaConexion(), "SP_C_CLIENTES_MASTER_TRAFICOS");
                objParams[0].Value = IdTargetAccount;

                DataSet ds = SqlHelper.ExecuteDataset(BaseDatos.NuevaConexion(), CommandType.StoredProcedure, "SP_C_CLIENTES_MASTER_TRAFICOS", objParams);

                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        trafico = new clsTrafico();
                        trafico.Id = Convert.ToInt64(item["IdTrafico"]);                        
                        trafico.Nombre = item["Descripcion"].ToString();

                        listado.Add(trafico);
                    }
                }                
            }
            catch (Exception ex)
            {
                Base.Log.Log.EscribirLog(ex.Message);
            }
            finally
            {
                BaseDatos.CerrarNuevaCOnexion();
            }

            return listado;
        }



        public static IList<clsTipoOrigenCarga> ObtenerOrigenCargaTargetAccount(Int64 IdMaster)
        {
            IList<clsTipoOrigenCarga> listado = new List<clsTipoOrigenCarga>();
            clsTipoOrigenCarga origen = null;
            try
            {

                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.NuevaConexion(), "SP_C_CLIENTES_MASTER_ORIGENCARGA");
                objParams[0].Value = IdMaster;

                DataSet ds = SqlHelper.ExecuteDataset(BaseDatos.NuevaConexion(), CommandType.StoredProcedure, "SP_C_CLIENTES_MASTER_ORIGENCARGA", objParams);

                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        origen = new clsTipoOrigenCarga();
                        origen.Id = Convert.ToInt64(item["IdOrigen"]);
                        origen.Nombre = item["Descripcion"].ToString();

                        listado.Add(origen);
                    }
                }
            }
            catch (Exception ex)
            {
                Base.Log.Log.EscribirLog(ex.Message);
            }
            finally
            {
                BaseDatos.CerrarNuevaCOnexion();
            }

            return listado;
        }

        public static IList<clsTipoDestinoCarga> ObtenerDestinoCargaTargetAccount(Int64 IdMaster)
        {
            IList<clsTipoDestinoCarga> listado = new List<clsTipoDestinoCarga>();
            clsTipoDestinoCarga destino = null;
            try
            {

                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.NuevaConexion(), "SP_C_CLIENTES_MASTER_DESTINOCARGA");
                objParams[0].Value = IdMaster;

                DataSet ds = SqlHelper.ExecuteDataset(BaseDatos.NuevaConexion(), CommandType.StoredProcedure, "SP_C_CLIENTES_MASTER_DESTINOCARGA", objParams);

                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        destino = new clsTipoDestinoCarga();
                        destino.Id = Convert.ToInt64(item["IdDestino"]);
                        destino.Nombre = item["Descripcion"].ToString();

                        listado.Add(destino);
                    }
                }
            }
            catch (Exception ex)
            {
                Base.Log.Log.EscribirLog(ex.Message);
            }
            finally
            {
                BaseDatos.CerrarNuevaCOnexion();
            }

            return listado;
        }


        public static IList<clsTargetAccountCompetencia> ObtenerEmpresasCompetenciaTargetAccount(Int64 IdTargetAccount)
        {
            IList<clsTargetAccountCompetencia> listado = new List<clsTargetAccountCompetencia>();
            clsTargetAccountCompetencia empresa = null;
            try
            {

                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.NuevaConexion(), "SP_C_CLIENTES_TARGET_ACCOUNT_COMPETENCIA");
                objParams[0].Value = IdTargetAccount;

                DataSet ds = SqlHelper.ExecuteDataset(BaseDatos.NuevaConexion(), CommandType.StoredProcedure, "SP_C_CLIENTES_TARGET_ACCOUNT_COMPETENCIA", objParams);

                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        empresa = new clsTargetAccountCompetencia();
                        empresa.Id = Convert.ToInt64(item["IdEmpresaCompetencia"]);
                        empresa.Nombre = item["Descripcion"].ToString();

                        listado.Add(empresa);
                    }
                }
            }
            catch (Exception ex)
            {
                Base.Log.Log.EscribirLog(ex.Message);
            }
            finally
            {
                BaseDatos.CerrarNuevaCOnexion();
            }

            return listado;
        }


        public static IList<clsTargetAccountTomaDesiciones> ObtenerTomaDesicionesTargetAccount(Int64 IdTargetAccount)
        {
            IList<clsTargetAccountTomaDesiciones> listado = new List<clsTargetAccountTomaDesiciones>();
            clsTargetAccountTomaDesiciones desicion = null;
            try
            {

                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.NuevaConexion(), "SP_C_CLIENTES_TARGET_ACCOUNT_TOMADESICIONES");
                objParams[0].Value = IdTargetAccount;

                DataSet ds = SqlHelper.ExecuteDataset(BaseDatos.NuevaConexion(), CommandType.StoredProcedure, "SP_C_CLIENTES_TARGET_ACCOUNT_TOMADESICIONES", objParams);

                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        desicion = new clsTargetAccountTomaDesiciones();
                        desicion.Id = Convert.ToInt64(item["Id"]);
                        desicion.Nombre = item["Descripcion"].ToString();

                        listado.Add(desicion);
                    }
                }
            }
            catch (Exception ex)
            {
                Base.Log.Log.EscribirLog(ex.Message);
            }
            finally
            {
                BaseDatos.CerrarNuevaCOnexion();
            }

            return listado;
        }


        public static ResultadoTransaccion BorrarOrigenesCargaTargetAccount(Int64 IdMaster, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_E_CLIENTES_MASTER_ORIGENESCARGA");
                objParams[0].Value = IdMaster;
                SqlCommand command4 = new SqlCommand("SP_E_CLIENTES_MASTER_ORIGENESCARGA", conn);
                command4.Transaction = transaction;
                command4.Parameters.AddRange(objParams);
                command4.CommandType = CommandType.StoredProcedure;
                command4.ExecuteNonQuery();
                res.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public static ResultadoTransaccion BorrarDestinosCargaTargetAccount(Int64 IdMaster, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_E_CLIENTES_MASTER_DESTINOSCARGA");
                objParams[0].Value = IdMaster;
                SqlCommand command4 = new SqlCommand("SP_E_CLIENTES_MASTER_DESTINOSCARGA", conn);
                command4.Transaction = transaction;
                command4.Parameters.AddRange(objParams);
                command4.CommandType = CommandType.StoredProcedure;
                command4.ExecuteNonQuery();
                res.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public static ResultadoTransaccion AgregarEmpresaCompetencia(clsTargetAccountCompetencia competencia, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            Int64 idEmpresaCompetencia = 0;
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_CLIENTES_TARGET_EMPRESA_TRABAJA");
                objParams[0].Value = competencia.Nombre;
                SqlCommand command3 = new SqlCommand("SP_N_CLIENTES_TARGET_EMPRESA_TRABAJA", conn);
                command3.Transaction = transaction;
                command3.Parameters.AddRange(objParams);
                command3.CommandType = CommandType.StoredProcedure;
                idEmpresaCompetencia = Convert.ToInt64(command3.ExecuteScalar());

                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.ObjetoTransaccion = idEmpresaCompetencia;

            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public static ResultadoTransaccion BorrarEmpresaCompetenciaTargetAccount(Int64 idTargetAccount, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_E_CLIENTES_TARGET_ACCOUNT_COMPETENCIA");
                objParams[0].Value = idTargetAccount;
                SqlCommand command4 = new SqlCommand("SP_E_CLIENTES_TARGET_ACCOUNT_COMPETENCIA", conn);
                command4.Transaction = transaction;
                command4.Parameters.AddRange(objParams);
                command4.CommandType = CommandType.StoredProcedure;
                command4.ExecuteNonQuery();
                res.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public static ResultadoTransaccion AsignarEmpresaCompetenciaTargetAccount(Int64 IdTargetAccount, Int64 IdEmpresa, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_CLIENTES_TARGET_ACCOUNT_COMPETENCIA");
                objParams[0].Value = IdTargetAccount ;
                objParams[1].Value = IdEmpresa ;
                SqlCommand command4 = new SqlCommand("SP_N_CLIENTES_TARGET_ACCOUNT_COMPETENCIA", conn);
                command4.Transaction = transaction;
                command4.Parameters.AddRange(objParams);
                command4.CommandType = CommandType.StoredProcedure;
                command4.ExecuteNonQuery();

                res.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }


        public static ResultadoTransaccion BorrarTomaDesicionesTargetAccount(Int64 idTargetAccount, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_E_CLIENTES_TARGET_ACCOUNT_TOMADESICIONES");
                objParams[0].Value = idTargetAccount;
                SqlCommand command4 = new SqlCommand("SP_E_CLIENTES_TARGET_ACCOUNT_TOMADESICIONES", conn);
                command4.Transaction = transaction;
                command4.Parameters.AddRange(objParams);
                command4.CommandType = CommandType.StoredProcedure;
                command4.ExecuteNonQuery();
                res.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public static ResultadoTransaccion AsignarTomaDesicionTargetAccount(Int64 IdTargetAccount, clsTargetAccountTomaDesiciones tomadesicion, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_CLIENTES_TARGET_ACCOUNT_TOMADESICIONES");
                objParams[0].Value = IdTargetAccount;
                objParams[1].Value = tomadesicion.Nombre;
                SqlCommand command4 = new SqlCommand("SP_N_CLIENTES_TARGET_ACCOUNT_TOMADESICIONES", conn);
                command4.Transaction = transaction;
                command4.Parameters.AddRange(objParams);
                command4.CommandType = CommandType.StoredProcedure;
                command4.ExecuteNonQuery();

                res.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }


        public static ResultadoTransaccion BorrarServiciosComplementariosTargetAccount(Int64 idTargetAccount, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_E_CLIENTES_TARGET_ACCOUNT_SERVICIOCOMPLEMENTARIO");
                objParams[0].Value = idTargetAccount;
                SqlCommand command4 = new SqlCommand("SP_E_CLIENTES_TARGET_ACCOUNT_SERVICIOCOMPLEMENTARIO", conn);
                command4.Transaction = transaction;
                command4.Parameters.AddRange(objParams);
                command4.CommandType = CommandType.StoredProcedure;
                command4.ExecuteNonQuery();
                res.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public static ResultadoTransaccion AsignarServicioComplementarioTargetAccount(Int64 IdTargetAccount, clsTipoServicioComplementario servicio, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_TARGET_ACCOUNT_SERVICIOCOMPLEMENTARIO");
                objParams[0].Value = IdTargetAccount;
                objParams[1].Value = servicio.Id;
                SqlCommand command4 = new SqlCommand("SP_N_TARGET_ACCOUNT_SERVICIOCOMPLEMENTARIO", conn);
                command4.Transaction = transaction;
                command4.Parameters.AddRange(objParams);
                command4.CommandType = CommandType.StoredProcedure;
                command4.ExecuteNonQuery();

                res.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public static IList<clsTipoServicioComplementario> ObtenerServiciosComplementariosTargetAccount(Int64 IdTargetAccount)
        {
            IList<clsTipoServicioComplementario> listado = new List<clsTipoServicioComplementario>();
            clsTipoServicioComplementario servicio = null;
            try
            {

                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.NuevaConexion(), "SP_C_CLIENTES_TARGET_ACCOUNT_SERVICIOCOMPLEMENTARIO");
                objParams[0].Value = IdTargetAccount;

                DataSet ds = SqlHelper.ExecuteDataset(BaseDatos.NuevaConexion(), CommandType.StoredProcedure, "SP_C_CLIENTES_TARGET_ACCOUNT_SERVICIOCOMPLEMENTARIO", objParams);

                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        servicio = new clsTipoServicioComplementario();
                        servicio.Id = Convert.ToInt64(item["IdServicioComplementario"]);
                        servicio.Nombre = item["Descripcion"].ToString();

                        listado.Add(servicio);
                    }
                }
            }
            catch (Exception ex)
            {
                Base.Log.Log.EscribirLog(ex.Message);
            }
            finally
            {
                BaseDatos.CerrarNuevaCOnexion();
            }

            return listado;
        }



        public static ResultadoTransaccion BorrarPersonalesTargetAccount(Int64 idTargetAccount, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_E_CLIENTES_TARGET_ACCOUNT_PERSONALES");
                objParams[0].Value = idTargetAccount;
                SqlCommand command4 = new SqlCommand("SP_E_CLIENTES_TARGET_ACCOUNT_PERSONALES", conn);
                command4.Transaction = transaction;
                command4.Parameters.AddRange(objParams);
                command4.CommandType = CommandType.StoredProcedure;
                command4.ExecuteNonQuery();
                res.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public static ResultadoTransaccion AsignarPersonalesTargetAccount(Int64 IdTargetAccount, clsTargetAccountPersonales personales, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_CLIENTES_TARGET_ACCOUNT_PERSONALES");
                objParams[0].Value = IdTargetAccount;
                objParams[1].Value = personales.Nombre;
                SqlCommand command4 = new SqlCommand("SP_N_CLIENTES_TARGET_ACCOUNT_PERSONALES", conn);
                command4.Transaction = transaction;
                command4.Parameters.AddRange(objParams);
                command4.CommandType = CommandType.StoredProcedure;
                command4.ExecuteNonQuery();

                res.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public static IList<clsTargetAccountPersonales> ObtenerPersonalesTargetAccount(Int64 IdTargetAccount)
        {
            IList<clsTargetAccountPersonales> listado = new List<clsTargetAccountPersonales>();
            clsTargetAccountPersonales personal = null;
            try
            {

                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.NuevaConexion(), "SP_C_CLIENTES_TARGET_ACCOUNT_PERSONALES");
                objParams[0].Value = IdTargetAccount;

                DataSet ds = SqlHelper.ExecuteDataset(BaseDatos.NuevaConexion(), CommandType.StoredProcedure, "SP_C_CLIENTES_TARGET_ACCOUNT_PERSONALES", objParams);

                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        personal = new clsTargetAccountPersonales();                        
                        personal.Id = Convert.ToInt64(item["Id"]);
                        personal.Nombre = item["Descripcion"].ToString();

                        listado.Add(personal);
                    }
                }
            }
            catch (Exception ex)
            {
                Base.Log.Log.EscribirLog(ex.Message);
            }
            finally
            {
                BaseDatos.CerrarNuevaCOnexion();
            }

            return listado;
        }



        public static ResultadoTransaccion BorrarObjecionesTargetAccount(Int64 idTargetAccount, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_E_CLIENTES_TARGET_ACCOUNT_OBJECIONES");
                objParams[0].Value = idTargetAccount;
                SqlCommand command4 = new SqlCommand("SP_E_CLIENTES_TARGET_ACCOUNT_OBJECIONES", conn);
                command4.Transaction = transaction;
                command4.Parameters.AddRange(objParams);
                command4.CommandType = CommandType.StoredProcedure;
                command4.ExecuteNonQuery();
                res.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public static ResultadoTransaccion AsignarObjecionesTargetAccount(Int64 IdTargetAccount, clsTipoObjeciones objecion, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_CLIENTES_TARGET_ACCOUNT_OBJECIONES");
                objParams[0].Value = IdTargetAccount;
                objParams[1].Value = objecion.Id;
                SqlCommand command4 = new SqlCommand("SP_N_CLIENTES_TARGET_ACCOUNT_OBJECIONES", conn);
                command4.Transaction = transaction;
                command4.Parameters.AddRange(objParams);
                command4.CommandType = CommandType.StoredProcedure;
                command4.ExecuteNonQuery();

                res.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public static IList<clsTipoObjeciones> ObtenerObjecionesTargetAccount(Int64 IdTargetAccount)
        {
            IList<clsTipoObjeciones> listado = new List<clsTipoObjeciones>();
            clsTipoObjeciones objecion = null;
            try
            {

                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.NuevaConexion(), "SP_C_CLIENTES_TARGET_ACCOUNT_OBJECIONES");
                objParams[0].Value = IdTargetAccount;

                DataSet ds = SqlHelper.ExecuteDataset(BaseDatos.NuevaConexion(), CommandType.StoredProcedure, "SP_C_CLIENTES_TARGET_ACCOUNT_OBJECIONES", objParams);

                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        objecion = new clsTipoObjeciones();
                        objecion.Id = Convert.ToInt64(item["IdTipoObjecion"]);
                        objecion.Nombre = item["Descripcion"].ToString();
                        objecion.FechaCreacion = Convert.ToDateTime(item["FechaCreacion"]);

                        listado.Add(objecion);
                    }
                }
            }
            catch (Exception ex)
            {
                Base.Log.Log.EscribirLog(ex.Message);
            }
            finally
            {
                BaseDatos.CerrarNuevaCOnexion();
            }

            return listado;
        }




        public static ResultadoTransaccion BorrarAccionesTomarTargetAccount(Int64 idTargetAccount, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_E_CLIENTES_TARGET_ACCOUNT_ACCIONESTOMAR");
                objParams[0].Value = idTargetAccount;
                SqlCommand command4 = new SqlCommand("SP_E_CLIENTES_TARGET_ACCOUNT_ACCIONESTOMAR", conn);
                command4.Transaction = transaction;
                command4.Parameters.AddRange(objParams);
                command4.CommandType = CommandType.StoredProcedure;
                command4.ExecuteNonQuery();
                res.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public static ResultadoTransaccion AsignarAccionTomarTargetAccount(Int64 IdTargetAccount, clsTipoAccionesTomar accion, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_CLIENTES_TARGET_ACCOUNT_ACCIONESTOMAR");
                objParams[0].Value = IdTargetAccount;
                objParams[1].Value = accion.QueNecesita;
                objParams[2].Value = accion.ProximaOrden;
                objParams[3].Value = accion.ComoComunicara;

                SqlCommand command4 = new SqlCommand("SP_N_CLIENTES_TARGET_ACCOUNT_ACCIONESTOMAR", conn);
                command4.Transaction = transaction;
                command4.Parameters.AddRange(objParams);
                command4.CommandType = CommandType.StoredProcedure;
                command4.ExecuteNonQuery();

                res.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;
        }

        public static clsTipoAccionesTomar ObtenerAccionTomarTargetAccount(Int64 IdTargetAccount)
        {            
            clsTipoAccionesTomar accion = null;
            try
            {

                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.NuevaConexion(), "SP_C_CLIENTES_TARGET_ACCOUNT_ACCIONESTOMAR");
                objParams[0].Value = IdTargetAccount;

                DataSet ds = SqlHelper.ExecuteDataset(BaseDatos.NuevaConexion(), CommandType.StoredProcedure, "SP_C_CLIENTES_TARGET_ACCOUNT_ACCIONESTOMAR", objParams);

                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        accion = new clsTipoAccionesTomar();
                        accion.Id = Convert.ToInt64(item["Id"]);
                        accion.QueNecesita = item["QueNecesita"].ToString();
                        
                        if (item["ProximaOrden"] is DBNull)
                            accion.ProximaOrden = null;
                        else 
                            accion.ProximaOrden = Convert.ToDateTime(item["ProximaOrden"]);

                        accion.ComoComunicara = item["ComoComunicara"].ToString();
                        accion.FechaCreacion = Convert.ToDateTime(item["FechaCreacion"]);                        
                    }
                }
            }
            catch (Exception ex)
            {
                Base.Log.Log.EscribirLog(ex.Message);
            }
            finally
            {
                BaseDatos.CerrarNuevaCOnexion();
            }

            return accion;
        }

        //public static ResultadoTransaccion CrearAccionATomar(clsTipoAccionesTomar accion, SqlConnection conn, SqlTransaction transaction)
        //{
        //    ResultadoTransaccion res = new ResultadoTransaccion();
        //    Int64 idAccion = 0;
        //    try
        //    {
        //        objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_TIPO_ACCION_TOMAR");
        //        objParams[0].Value = accion.Nombre;                
        //        SqlCommand command4 = new SqlCommand("SP_N_TIPO_ACCION_TOMAR", conn);
        //        command4.Transaction = transaction;
        //        command4.Parameters.AddRange(objParams);
        //        command4.CommandType = CommandType.StoredProcedure;
        //        idAccion = Convert.ToInt64(command4.ExecuteScalar());

        //        res.Estado = Enums.EstadoTransaccion.Aceptada;
        //        res.ObjetoTransaccion = idAccion;

        //    }
        //    catch (Exception ex)
        //    {
        //        res.Estado = Enums.EstadoTransaccion.Rechazada;
        //        res.Descripcion = ex.Message;
        //        Log.EscribirLog(ex.Message);
        //    }
        //    return res;
        //}


    }
    
}
