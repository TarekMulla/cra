using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Clientes.Contacto;
using ProyectoCraft.Entidades.Clientes.Direcciones;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Clientes.Target;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Base.BaseDatos;
using System.Data.SqlClient;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Base.Log;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Collections;
using ProyectoCraft.Entidades.Log;

namespace ProyectoCraft.AccesoDatos.Clientes
{
    public static class clsTargetDAO
    {
        private static SqlParameter[] objParams = null;
        private static SqlConnection conn = null;
        private static SqlTransaction transaction = null;
        private static SqlDataReader dreader = null;
        private static ResultadoTransaccion resTransaccion = null;
        private static Int64 idMaster = 0;
        private static Int64 idTarget = 0;

        public static IList<clsTarget> ListarTarget(string nombre, Int64 vendedor, int idTipoBusqueda)
        {
            IList<clsTarget> listTarget = new List<clsTarget>();
            clsTarget target;

            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();
                                
                //Registrar Cliente Master
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_CLIENTES_TARGETS");
                objParams[0].Value = nombre;
                objParams[1].Value = vendedor;
                objParams[2].Value = idTipoBusqueda;
                SqlCommand command = new SqlCommand("SP_C_CLIENTES_TARGETS", conn);                
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    clsTarget trg = new clsTarget();
                    trg.ClienteMaster.Id = Convert.ToInt64(dreader[0]);
                    trg.ClienteMaster.NombreCompañia = dreader[1].ToString();

                    trg.ClienteMaster.Nombres = dreader[2].ToString();
                    trg.ClienteMaster.ApellidoPaterno = dreader[3].ToString();
                    trg.ClienteMaster.ApellidoMaterno = dreader[4].ToString();
                    trg.Telefono = dreader[5].ToString();
                    trg.Email = dreader[6].ToString();

                    var id = dreader[7].ToString();

                    if (dreader[7] is DBNull)
                        trg.EmpresaConQueTrabaja = null;
                    else
                    {
                        trg.EmpresaConQueTrabaja = new clsEmpresaCompetencia();
                        trg.EmpresaConQueTrabaja.Id = Convert.ToInt64(dreader[7].ToString());
                        trg.EmpresaConQueTrabaja.Nombre = dreader[8].ToString();
                    }

                    if (dreader[9] is DBNull)
                        trg.OrigenCarga = null;
                    else
                    {
                        trg.OrigenCarga = new clsOrigenCarga();
                        trg.OrigenCarga.Id = Convert.ToInt64(dreader[9].ToString());
                        trg.OrigenCarga.Nombre = dreader[10].ToString();
                    }                        

                    trg.Id = Convert.ToInt64(dreader[11]);

                    if (dreader[12] is DBNull)
                        trg.VendedorAsignado = null;
                    else
                        trg.VendedorAsignado = Usuarios.clsUsuarioADO.ObtenerUsuarioPorId(Convert.ToInt16(dreader[12]));

                    trg.Estado = (Enums.EstadoTarget)Convert.ToInt16(dreader[13]);

                    listTarget.Add(trg);
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

            return listTarget;
        }

        public static ResultadoTransaccion GuardaTarget(clsTarget Target)
        {       
            resTransaccion = new ResultadoTransaccion();
            try
            {                       
                //Abrir Conexion
                conn = BaseDatos.Conexion();
                
                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Registrar Direcciones
                resTransaccion = clsDireccionADO.GuardarDirecciones(Target.ClienteMaster.DireccionInfo, conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                {
                    throw new Exception(resTransaccion.Descripcion);
                }
                Target.ClienteMaster.DireccionInfo = (clsDireccionInfo) resTransaccion.ObjetoTransaccion;

                //Registrar Cliente Master
                resTransaccion = clsClienteMasterADO.GuardarClienteMaster(Target.ClienteMaster, conn,
                                                                                          transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);

                idMaster = (Int64)resTransaccion.ObjetoTransaccion;
                
                //Registrar empresa competencia
                Int64 idEmpresaCompetencia = 0;
                if(Target.EmpresaConQueTrabaja == null)
                {
                    idEmpresaCompetencia = -1;
                }
                else if (Target.EmpresaConQueTrabaja.IsNew)
                {
                    resTransaccion = AsignarEmpresaCompetencia(Target, conn, transaction);
                    if(resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resTransaccion.Descripcion);

                    idEmpresaCompetencia = (Int64) resTransaccion.ObjetoTransaccion;
                }
                else
                    idEmpresaCompetencia = Target.EmpresaConQueTrabaja.Id;


                //Resitrar Origen Carga
                Int64 idOrigenCarga = 0;
                if(Target.OrigenCarga == null)
                {
                    idOrigenCarga = -1;
                }
                else if(Target.OrigenCarga.IsNew)
                {
                    resTransaccion = AsignarOrigenCarga(Target, conn, transaction);
                    if(resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resTransaccion.Descripcion);

                    idOrigenCarga =(Int64)resTransaccion.ObjetoTransaccion;
                }
                else
                {
                    idOrigenCarga = Target.OrigenCarga.Id;
                }

                
                //Registrar Target
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_CLIENTES_TARGET");
                objParams[0].Value = idMaster;
                if (Target.TipoSaludo != null)
                    objParams[1].Value = Target.TipoSaludo.Id;
                else
                    objParams[1].Value = -1;

                objParams[2].Value = Target.Cargo;
                
                if (Target.VendedorAsignado != null)
                    objParams[3].Value = Target.VendedorAsignado.Id;
                else
                    objParams[3].Value = -1;

                objParams[4].Value = Target.Telefono;
                objParams[5].Value = Target.CuentaSkype;
                objParams[6].Value = Target.SitioWeb;
                objParams[7].Value = Target.Email;
                objParams[8].Value = Target.Estado;
                objParams[9].Value = Target.Observacion;

                if (Target.SectorEconomico != null)
                    objParams[10].Value = Target.SectorEconomico.Id;
                else
                    objParams[10].Value = -1;

                if (Target.TipoMonedaVtaEstimada != null)
                    objParams[11].Value = Target.TipoMonedaVtaEstimada.Id;
                else
                    objParams[11].Value = -1;

                objParams[12].Value = Target.MontoVentaEstimada;
                objParams[13].Value = Target.NumEmpleados;

                if (Target.OrigenCliente != null)
                    objParams[14].Value = Target.OrigenCliente.Id;
                else
                    objParams[14].Value = -1;

                if (Target.MotivoInteres != null)
                    objParams[15].Value = Target.MotivoInteres.Id;
                else
                    objParams[15].Value = -1;

                if (Target.NivelInteres != null)
                    objParams[16].Value = Target.NivelInteres.Id;
                else
                    objParams[16].Value = -1;

                
                objParams[17].Value = idEmpresaCompetencia;                
                objParams[18].Value = idOrigenCarga;
                

                if (Target.FormaContactoPreferida != null)
                    objParams[19].Value = Target.FormaContactoPreferida.Id;
                else
                    objParams[19].Value = -1;

                objParams[20].Value = Target.PermiteTelOficina;
                objParams[21].Value = Target.PermiteTelParticular;
                objParams[22].Value = Target.PermiteTelCelular;
                objParams[23].Value = Target.PermiteSkype;
                objParams[24].Value = Target.PermiteEmail;
                objParams[25].Value = Target.PermiteEmailMasivo;
                if (Target.DiaPreferido == null)
                    objParams[26].Value = "-1";
                else 
                    objParams[26].Value = Target.DiaPreferido.Id;

                if (Target.JornadaPreferida == null)
                    objParams[27].Value = "-1";
                else 
                    objParams[27].Value = Target.JornadaPreferida.Id;

                SqlCommand command2 = new SqlCommand("SP_N_CLIENTES_TARGET", conn);
                command2.Transaction = transaction;
                command2.Parameters.AddRange(objParams);
                command2.CommandType = CommandType.StoredProcedure;
                idTarget = Convert.ToInt64(command2.ExecuteScalar());

                Target.Id = idTarget;

                if(idMaster > 0)
                {
                    //Productos preferidos
                    //clsClienteMasterADO.BorrarProductos(idTarget, transaction,conn);
                    foreach (var producto in Target.ClienteMaster.ProductosPreferidos)
                    {
                        clsClienteMasterADO.AsignarTipoProducto(producto, idMaster,transaction,conn);
                    }    

                    //Tipos Relacion
                    //clsClienteMasterADO.BorrarTipoRelacion(idMaster, transaction, conn);
                    foreach (var relacion in Target.ClienteMaster.TiposRelaciones)
                    {
                        clsClienteMasterADO.AsignarTipoRelacion(relacion, idMaster, transaction, conn);
                    }
                }
                
                //Ejecutar transaccion
                transaction.Commit();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.Descripcion = "Se Creo Target con Id " + idMaster.ToString();

                //Registrar Actividad
                LogActividadUsuarios log = new LogActividadUsuarios(Target.GetType().ToString(),Target.Id,Enums.TipoActividadUsuario.Creo,Base.Usuario.UsuarioConectado.Usuario);
                LogActividades.clsLogActividadUsuariosADO.GuardaActividad(log);

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                resTransaccion.ArchivoError = "clsTargetDao.cs";
                resTransaccion.MetodoError = "GuardaTarget";
                
            }
            finally
            {                
                conn.Close();
                resTransaccion.Accion = Enums.AccionTransaccion.Insertar;
                Target.Id = idTarget;
                Target.ClienteMaster.Id = idMaster;
                resTransaccion.ObjetoTransaccion = Target;
            }

            return resTransaccion;
        }

        public static ResultadoTransaccion AsignarEmpresaCompetencia(clsTarget target, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            Int64 idEmpresaCompetencia = 0;
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_CLIENTES_TARGET_EMPRESA_TRABAJA");
                objParams[0].Value = target.EmpresaConQueTrabaja.Nombre;
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

        public static ResultadoTransaccion AsignarOrigenCarga(clsTarget target, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            Int64 idOrigenCarga = 0;
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_CLIENTES_TARGET_ORIGEN_CARGA");
                objParams[0].Value = target.OrigenCarga.Nombre;
                SqlCommand command4 = new SqlCommand("SP_N_CLIENTES_TARGET_ORIGEN_CARGA", conn);
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

        public static ResultadoTransaccion ActualizarTarget(clsTarget Target)
        {            
            resTransaccion = new ResultadoTransaccion();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();
                
                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Registrar Direcciones
                resTransaccion = clsDireccionADO.GuardarDirecciones(Target.ClienteMaster.DireccionInfo, conn, transaction);
                if(resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);

                Target.ClienteMaster.DireccionInfo = (clsDireccionInfo) resTransaccion.ObjetoTransaccion;


                //Actualizar Master
                resTransaccion = clsClienteMasterADO.ActualizarClienteMaster(Target.ClienteMaster, conn, transaction);
                if(resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);


                //Registrar empresa competencia
                Int64 idEmpresaCompetencia = 0;
                if (Target.EmpresaConQueTrabaja == null)
                {
                    idEmpresaCompetencia = -1;
                }
                else if (Target.EmpresaConQueTrabaja.IsNew)
                {
                    resTransaccion = AsignarEmpresaCompetencia(Target, conn, transaction);
                    if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resTransaccion.Descripcion);

                    idEmpresaCompetencia = (Int64)resTransaccion.ObjetoTransaccion;
                }
                else
                    idEmpresaCompetencia = Target.EmpresaConQueTrabaja.Id;


                //Resitrar Origen Carga
                Int64 idOrigenCarga = 0;
                if (Target.OrigenCarga == null)
                {
                    idOrigenCarga = -1;
                }
                else if (Target.OrigenCarga.IsNew)
                {
                    resTransaccion = AsignarOrigenCarga(Target, conn, transaction);
                    if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resTransaccion.Descripcion);

                    idOrigenCarga = (Int64)resTransaccion.ObjetoTransaccion;
                }
                else
                {
                    idOrigenCarga = Target.OrigenCarga.Id;
                }


                //Actualizar Target
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_A_CLIENTES_TARGET");
                objParams[0].Value = Target.Id;
                objParams[1].Value = Target.ClienteMaster.Id;
                if (Target.TipoSaludo != null)
                    objParams[2].Value = Target.TipoSaludo.Id;
                else
                    objParams[2].Value = -1;

                objParams[3].Value = Target.Cargo;

                if (Target.VendedorAsignado != null)
                    objParams[4].Value = Target.VendedorAsignado.Id;
                else
                    objParams[4].Value = -1;

                objParams[5].Value = Target.Telefono;
                objParams[6].Value = Target.CuentaSkype;
                objParams[7].Value = Target.SitioWeb;
                objParams[8].Value = Target.Email;
                objParams[9].Value = Target.Estado;
                objParams[10].Value = Target.Observacion;

                if (Target.SectorEconomico != null)
                    objParams[11].Value = Target.SectorEconomico.Id;
                else
                    objParams[11].Value = -1;

                if (Target.TipoMonedaVtaEstimada != null)
                    objParams[12].Value = Target.TipoMonedaVtaEstimada.Id;
                else
                    objParams[12].Value = -1;

                objParams[13].Value = Target.MontoVentaEstimada;
                objParams[14].Value = Target.NumEmpleados;

                if (Target.OrigenCliente != null)
                    objParams[15].Value = Target.OrigenCliente.Id;
                else
                    objParams[15].Value = -1;

                if (Target.MotivoInteres != null)
                    objParams[16].Value = Target.MotivoInteres.Id;
                else
                    objParams[16].Value = -1;

                if (Target.NivelInteres != null)
                    objParams[17].Value = Target.NivelInteres.Id;
                else
                    objParams[17].Value = -1;


                objParams[18].Value = idEmpresaCompetencia;
                objParams[19].Value = idOrigenCarga;


                if (Target.FormaContactoPreferida != null)
                    objParams[20].Value = Target.FormaContactoPreferida.Id;
                else
                    objParams[20].Value = -1;

                objParams[21].Value = Target.PermiteTelOficina;
                objParams[22].Value = Target.PermiteTelParticular;
                objParams[23].Value = Target.PermiteTelCelular;
                objParams[24].Value = Target.PermiteSkype;
                objParams[25].Value = Target.PermiteEmail;
                objParams[26].Value = Target.PermiteEmailMasivo;
                if (Target.DiaPreferido == null)
                    objParams[27].Value = "-1";
                else
                    objParams[27].Value = Target.DiaPreferido.Id;

                if (Target.JornadaPreferida == null)
                    objParams[28].Value = "-1";
                else
                    objParams[28].Value = Target.JornadaPreferida.Id;

                SqlCommand command2 = new SqlCommand("SP_A_CLIENTES_TARGET", conn, transaction);
                command2.Parameters.AddRange(objParams);
                command2.CommandType = CommandType.StoredProcedure;
                command2.ExecuteNonQuery();



                
                
                //Productos preferidos
                resTransaccion = clsClienteMasterADO.BorrarProductos(Target.ClienteMaster.Id, transaction, conn);
                if(resTransaccion.Estado == Enums.EstadoTransaccion.Aceptada)
                {
                    foreach (var producto in Target.ClienteMaster.ProductosPreferidos)
                    {
                        clsClienteMasterADO.AsignarTipoProducto(producto, Target.ClienteMaster.Id, transaction, conn);
                    }    
                }
                else 
                    throw new Exception(resTransaccion.Descripcion);
                

                //Tipos Relacion
                resTransaccion = clsClienteMasterADO.BorrarTipoRelacion(Target.ClienteMaster.Id, transaction, conn);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Aceptada)
                {
                    foreach (var relacion in Target.ClienteMaster.TiposRelaciones)
                    {
                        clsClienteMasterADO.AsignarTipoRelacion(relacion, Target.ClienteMaster.Id, transaction, conn);
                    }
                }
                else
                    throw new Exception(resTransaccion.Descripcion);


                //Ejecutar transaccion
                transaction.Commit();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.Descripcion = "Se actualido Target con Id " + Target.Id.ToString();


                //Registrar Actividad
                LogActividadUsuarios log = new LogActividadUsuarios(Target.GetType().ToString(), Target.Id, Enums.TipoActividadUsuario.Edito, Base.Usuario.UsuarioConectado.Usuario);
                LogActividades.clsLogActividadUsuariosADO.GuardaActividad(log);

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                resTransaccion.ArchivoError = "clsTargetDao.cs";
                resTransaccion.MetodoError = "GuardaTarget";

            }
            finally
            {

                conn.Close();

                resTransaccion.Accion = Enums.AccionTransaccion.Actualizar;                
                resTransaccion.ObjetoTransaccion = Target;

            }

            return resTransaccion;            
        }

        public static ResultadoTransaccion EliminarTarget(clsTarget Target)
        {
            ResultadoTransaccion resTransaccion = new ResultadoTransaccion();
            try
            {
                transaction = BaseDatos.Conexion().BeginTransaction();


                //Eliminar Direcciones
                if(Target.ClienteMaster.DireccionInfo != null)
                {
                    foreach (var direccion in Target.ClienteMaster.DireccionInfo.Items)
                    {
                        resTransaccion = new ResultadoTransaccion();
                        resTransaccion = clsDireccionADO.EliminarDireccion(direccion, transaction);

                        if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                            throw new Exception(resTransaccion.Descripcion);
                    }    

                    resTransaccion = new ResultadoTransaccion();
                    resTransaccion = clsDireccionADO.EliminarDireccionInfo(Target.ClienteMaster.DireccionInfo.IdInfo,
                                                                           transaction);
                    if(resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resTransaccion.Descripcion);

                }

                //Eliminar Tipos de Relacion
                resTransaccion = new ResultadoTransaccion();
                resTransaccion = clsClienteMasterADO.BorrarTipoRelacion(Target.ClienteMaster.Id, transaction, conn);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);

                //Eliminar Tipos de Carga
                resTransaccion = new ResultadoTransaccion();
                resTransaccion = clsClienteMasterADO.BorrarProductos(Target.ClienteMaster.Id, transaction, conn);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);

                
                //Eliminar Cliente Master
                resTransaccion = new ResultadoTransaccion();
                resTransaccion = clsClienteMasterADO.EliminarClienteMaster(Target.ClienteMaster, transaction);
                if(resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);

                //Eliminar Contactos
                IList<clsContacto> listContactos = new List<clsContacto>();
                listContactos = clsClienteMasterADO.ListarContactos(Target.ClienteMaster);
                foreach (var contacto in listContactos)
                {
                    resTransaccion = new ResultadoTransaccion();
                    resTransaccion = clsContactoADO.EliminarContacto(contacto, transaction);
                    if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resTransaccion.Descripcion);
                }

               
                //Eliminar Target
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_E_CLIENTES_TARGET");
                objParams[0].Value = Target.Id;

                SqlCommand command = new SqlCommand("SP_E_CLIENTES_TARGET", BaseDatos.Conexion());
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = transaction;
                command.ExecuteNonQuery();
                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;

                transaction.Commit();

                //Registrar Actividad
                LogActividadUsuarios log = new LogActividadUsuarios(Target.GetType().ToString(), Target.Id, Enums.TipoActividadUsuario.Elimino, Base.Usuario.UsuarioConectado.Usuario);
                LogActividades.clsLogActividadUsuariosADO.GuardaActividad(log);


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
                BaseDatos.CerrarConexion();
            }
            return resTransaccion;

        }

        public static ResultadoTransaccion DescalificarTarget(Int64 IdTarget)
        {
            ResultadoTransaccion resTransaccion = new ResultadoTransaccion();
            try
            {                                               
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_A_CLIENTES_TARGET_DESCALIFICAR");
                objParams[0].Value = IdTarget;

                SqlCommand command = new SqlCommand("SP_A_CLIENTES_TARGET_DESCALIFICAR", BaseDatos.Conexion());
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
                BaseDatos.CerrarConexion();
            }
            return resTransaccion;

        }

        public static ResultadoTransaccion ObtenerTargetPorId(Int64 IdTarget)
        {                        
            ResultadoTransaccion res = new ResultadoTransaccion();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Registrar Cliente Master
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_CLIENTES_TARGET_POR_ID");
                objParams[0].Value = IdTarget;                
                SqlCommand command = new SqlCommand("SP_C_CLIENTES_TARGET_POR_ID", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    clsTarget trg = new clsTarget();
                    trg.ClienteMaster.Id = Convert.ToInt64(dreader["IdMaster"]);
                    trg.ClienteMaster.NombreCompañia = dreader["NombreCompania"].ToString();

                    trg.ClienteMaster.Nombres = dreader["Nombres"].ToString();
                    trg.ClienteMaster.ApellidoPaterno = dreader["ApellidoPaterno"].ToString();
                    trg.ClienteMaster.ApellidoMaterno = dreader["ApellidoMaterno"].ToString();
                    trg.ClienteMaster.RUT = dreader["RUT"].ToString();
                    trg.ClienteMaster.Tipo = (Enums.TipoPersona)dreader["CodTipo"];
                    trg.ClienteMaster.FechaCreacion = (DateTime) dreader["FechaCreacionMaster"];

                    if (dreader["IdDireccionInfo"] is DBNull)
                        trg.ClienteMaster.DireccionInfo = null;
                    else
                        trg.ClienteMaster.DireccionInfo =
                            clsDireccionADO.ListarDireccionesPorIdInfo(Convert.ToInt64(dreader["IdDireccionInfo"]));

                    //trg.ClienteMaster.DireccionInfo  = new clsDireccionInfo(Convert.ToInt64(dreader["IdDireccionInfo"]));

                    trg.Id = Convert.ToInt64(dreader["IdTarget"]);
                    if(!(dreader["IdSaludo"] is DBNull))
                        trg.TipoSaludo = Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdSaludo"]));

                    trg.Cargo = dreader["Cargo"].ToString();

                    if(!(dreader["IdVendedorAsignado"] is DBNull))
                        trg.VendedorAsignado =
                            Usuarios.clsUsuarioADO.ObtenerUsuarioPorId(Convert.ToInt16(dreader["IdVendedorAsignado"]));

                    trg.Telefono = dreader["Telefono"].ToString();
                    trg.CuentaSkype = dreader["CuentaSkype"].ToString();
                    trg.SitioWeb = dreader["SitioWeb"].ToString();
                    trg.Email = dreader["Email"].ToString();
                    trg.Estado = (Enums.EstadoTarget) dreader["IdEstado"];
                    trg.Observacion = dreader["Observacion"].ToString();

                    if (!(dreader["IdSectorEconomico"] is DBNull))
                        trg.SectorEconomico =
                            Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdSectorEconomico"]));

                    if (!(dreader["IdMonedaVtaEst"] is DBNull))
                        trg.TipoMonedaVtaEstimada =
                            Parametros.clsParametrosDAO.BuscarMonedaPorId(Convert.ToInt16(dreader["IdMonedaVtaEst"]));

                    if(!(dreader["MontoVtaEst"] is DBNull))
                        trg.MontoVentaEstimada = (decimal)dreader["MontoVtaEst"];

                    if (!(dreader["NumEmpleados"] is DBNull))
                        trg.NumEmpleados = Convert.ToInt64(dreader["NumEmpleados"]);

                    if (!(dreader["IdOrigenCliente"] is DBNull))
                        trg.OrigenCliente = Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdOrigenCliente"]));

                    if (!(dreader["IdMotivoInteres"] is DBNull))
                        trg.MotivoInteres =
                            Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdMotivoInteres"]));

                    if (!(dreader["IdOrigenCarga"] is DBNull))
                        trg.OrigenCarga = clsOrigenCargoADO.BuscarOrigenCargaPorId(Convert.ToInt64(dreader["IdOrigenCarga"]));

                    if (!(dreader["IdNivelInteres"] is DBNull))
                        trg.NivelInteres = Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdNivelInteres"]));

                    if (!(dreader["IdEmpresaTrabaja"] is DBNull))
                        trg.EmpresaConQueTrabaja =
                            clsEmpresaCompetenciaDAO.BuscarEmpresaCompetenciaPorId(Convert.ToInt64(dreader["IdEmpresaTrabaja"]));

                    if (!(dreader["IdFormaContactoPref"] is DBNull))
                        trg.FormaContactoPreferida =
                            Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdFormaContactoPref"]));


                    trg.PermiteTelOficina = (bool)dreader["PermiteTelOfi"];
                    trg.PermiteTelParticular = (bool)dreader["PermiteTelPart"];
                    trg.PermiteTelCelular = (bool) dreader["PermiteTelCel"];
                    trg.PermiteSkype = (bool)dreader["PermiteSkype"];
                    trg.PermiteEmail = (bool)dreader["PermiteEmail"];
                    trg.PermiteEmailMasivo = (bool)dreader["PermiteEmailMasivo"];

                    if (!(dreader["CodDiaPreferido"] is DBNull))
                        trg.DiaPreferido =
                            Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["CodDiaPreferido"]));

                    if (!(dreader["CodJornadaPreferida"] is DBNull))
                        trg.JornadaPreferida =
                            Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["CodJornadaPreferida"]));

                    trg.ClienteMaster.ProductosPreferidos =
                        clsClienteMasterADO.ObtenerProductosPreferidos(trg.ClienteMaster.Id);

                    trg.ClienteMaster.TiposRelaciones =
                        clsClienteMasterADO.ObtenerTiposRelacion(trg.ClienteMaster.Id);
                    
                    res.Estado = Enums.EstadoTransaccion.Aceptada;
                    res.ObjetoTransaccion = trg;

                }
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
                conn.Close();
            }

            return res;
        }


        public static ResultadoTransaccion ObtenerTargetPorIdMaster(Int64 IdMaster)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Registrar Cliente Master
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_CLIENTES_TARGET_POR_ID_MASTER");
                objParams[0].Value = IdMaster;
                SqlCommand command = new SqlCommand("SP_C_CLIENTES_TARGET_POR_ID_MASTER", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    clsTarget trg = new clsTarget();
                    trg.ClienteMaster.Id = Convert.ToInt64(dreader["IdMaster"]);
                    trg.ClienteMaster.NombreCompañia = dreader["NombreCompania"].ToString();

                    trg.ClienteMaster.Nombres = dreader["Nombres"].ToString();
                    trg.ClienteMaster.ApellidoPaterno = dreader["ApellidoPaterno"].ToString();
                    trg.ClienteMaster.ApellidoMaterno = dreader["ApellidoMaterno"].ToString();
                    trg.ClienteMaster.RUT = dreader["RUT"].ToString();
                    trg.ClienteMaster.Tipo = (Enums.TipoPersona)dreader["CodTipo"];
                    trg.ClienteMaster.FechaCreacion = (DateTime)dreader["FechaCreacionMaster"];

                    if (dreader["IdDireccionInfo"] is DBNull)
                        trg.ClienteMaster.DireccionInfo = null;
                    else
                        trg.ClienteMaster.DireccionInfo =
                            clsDireccionADO.ListarDireccionesPorIdInfo(Convert.ToInt64(dreader["IdDireccionInfo"]));

                    //trg.ClienteMaster.DireccionInfo  = new clsDireccionInfo(Convert.ToInt64(dreader["IdDireccionInfo"]));

                    trg.Id = Convert.ToInt64(dreader["IdTarget"]);
                    if (!(dreader["IdSaludo"] is DBNull))
                        trg.TipoSaludo = Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdSaludo"]));

                    trg.Cargo = dreader["Cargo"].ToString();

                    if (!(dreader["IdVendedorAsignado"] is DBNull))
                        trg.VendedorAsignado =
                            Usuarios.clsUsuarioADO.ObtenerUsuarioPorId(Convert.ToInt16(dreader["IdVendedorAsignado"]));

                    trg.Telefono = dreader["Telefono"].ToString();
                    trg.CuentaSkype = dreader["CuentaSkype"].ToString();
                    trg.SitioWeb = dreader["SitioWeb"].ToString();
                    trg.Email = dreader["Email"].ToString();
                    trg.Estado = (Enums.EstadoTarget)dreader["IdEstado"];
                    trg.Observacion = dreader["Observacion"].ToString();

                    if (!(dreader["IdSectorEconomico"] is DBNull))
                        trg.SectorEconomico =
                            Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdSectorEconomico"]));

                    if (!(dreader["IdMonedaVtaEst"] is DBNull))
                        trg.TipoMonedaVtaEstimada =
                            Parametros.clsParametrosDAO.BuscarMonedaPorId(Convert.ToInt16(dreader["IdMonedaVtaEst"]));

                    if (!(dreader["MontoVtaEst"] is DBNull))
                        trg.MontoVentaEstimada = (decimal)dreader["MontoVtaEst"];

                    if (!(dreader["NumEmpleados"] is DBNull))
                        trg.NumEmpleados = Convert.ToInt64(dreader["NumEmpleados"]);

                    if (!(dreader["IdOrigenCliente"] is DBNull))
                        trg.OrigenCliente = Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdOrigenCliente"]));

                    if (!(dreader["IdMotivoInteres"] is DBNull))
                        trg.MotivoInteres =
                            Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdMotivoInteres"]));

                    if (!(dreader["IdOrigenCarga"] is DBNull))
                        trg.OrigenCarga = clsOrigenCargoADO.BuscarOrigenCargaPorId(Convert.ToInt64(dreader["IdOrigenCarga"]));

                    if (!(dreader["IdNivelInteres"] is DBNull))
                        trg.NivelInteres = Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdNivelInteres"]));

                    if (!(dreader["IdEmpresaTrabaja"] is DBNull))
                        trg.EmpresaConQueTrabaja =
                            clsEmpresaCompetenciaDAO.BuscarEmpresaCompetenciaPorId(Convert.ToInt64(dreader["IdEmpresaTrabaja"]));

                    if (!(dreader["IdFormaContactoPref"] is DBNull))
                        trg.FormaContactoPreferida =
                            Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdFormaContactoPref"]));


                    trg.PermiteTelOficina = (bool)dreader["PermiteTelOfi"];
                    trg.PermiteTelParticular = (bool)dreader["PermiteTelPart"];
                    trg.PermiteTelCelular = (bool)dreader["PermiteTelCel"];
                    trg.PermiteSkype = (bool)dreader["PermiteSkype"];
                    trg.PermiteEmail = (bool)dreader["PermiteEmail"];
                    trg.PermiteEmailMasivo = (bool)dreader["PermiteEmailMasivo"];

                    if (!(dreader["CodDiaPreferido"] is DBNull))
                        trg.DiaPreferido =
                            Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["CodDiaPreferido"]));

                    if (!(dreader["CodJornadaPreferida"] is DBNull))
                        trg.JornadaPreferida =
                            Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["CodJornadaPreferida"]));

                    trg.ClienteMaster.ProductosPreferidos =
                        clsClienteMasterADO.ObtenerProductosPreferidos(trg.ClienteMaster.Id);

                    trg.ClienteMaster.TiposRelaciones =
                        clsClienteMasterADO.ObtenerTiposRelacion(trg.ClienteMaster.Id);

                    res.Estado = Enums.EstadoTransaccion.Aceptada;
                    res.ObjetoTransaccion = trg;

                }
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
                conn.Close();
            }

            return res;
        }


        //// Metodo temporal en espera de que Gabriel implemente las clases cliente y target
        //public static ResultadoTransaccion ListarClienteMasterporUsuario(int IdUsuario)
        //{
        //    ResultadoTransaccion res = new ResultadoTransaccion();
        //    IList<clsClienteMaster> ListaClienteMaster = new List<clsClienteMaster>();
        //    try
        //    {
        //        //Abrir Conexion
        //        conn = BaseDatos.Conexion();

        //        //Consultar Asuntos x Tipo Actividad
        //        //objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "sp_c_ventas_tipo_actividad_asunto");
        //        //objParams[0].Value = IdTipoActividad;

        //        //SqlCommand command = new SqlCommand("sp_c_ventas_tipo_actividad_asunto", conn);

        //        //command.Transaction = transaction;
        //        //command.Parameters.AddRange(objParams);
        //        //command.CommandType = CommandType.StoredProcedure;
        //        //dreader = command.ExecuteReader();

        //        //while (dreader.Read())
        //        //{
        //        clsClienteMaster ObjClienteMaster = new clsClienteMaster();
        //        ObjClienteMaster.Id = 1;
        //        //ObjTarget.RUT  = "1-1";
        //        ObjClienteMaster.Nombres = "Target 1-1 Nombre Target";
        //        //ObjTarget.NombreCompañia = "Target 1-1 Nombre de Compañia";
        //        //ObjTarget.Nombres = "Target 1-1 Nombres de Prueba";
        //        //ObjTarget.ApellidoMaterno = "Target 1-1 Apellido Materno";
        //        //ObjTarget.ApellidoPaterno = "Target 1-1 Apellido Paterno";

        //        ListaClienteMaster.Add(ObjClienteMaster);

        //        clsClienteMaster ObjClienteMaster2 = new clsClienteMaster();
        //        ObjClienteMaster2.Id = 2;
        //        //ObjTarget2.RUT = "1-2";
        //        ObjClienteMaster2.Nombres = "Target 1-2 Nombre Target";
        //        //ObjTarget2.NombreCompañia = "Target 1-2 Nombre de Compañia";
        //        //ObjTarget2.Nombres = "Target 1-2 Nombres de Prueba";
        //        //ObjTarget2.ApellidoMaterno = "Target 1-2 Apellido Materno";
        //        //ObjTarget2.ApellidoPaterno = "Target 1-2 Apellido Paterno";

        //        ListaClienteMaster.Add(ObjClienteMaster2);

        //        clsClienteMaster ObjClienteMaster3 = new clsClienteMaster();
        //        ObjClienteMaster3.Id = 3;
        //        //ObjTarget3.RUT = "1-3";
        //        ObjClienteMaster3.Nombres = "Target 1-3 Nombre Target";
        //        //ObjTarget3.NombreCompañia = "Target 1-3 Nombre de Compañia";
        //        //ObjTarget3.Nombres = "Target 1-3 Nombres de Prueba";
        //        //ObjTarget3.ApellidoMaterno = "Target 1-3 Apellido Materno";
        //        //ObjTarget3.ApellidoPaterno = "Target 1-3 Apellido Paterno";

        //        ListaClienteMaster.Add(ObjClienteMaster3);
        //        //}
        //        res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
        //        res.ObjetoTransaccion = ListaClienteMaster;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.EscribirLog(ex.Message);

        //        resTransaccion.Descripcion = ex.Message;
        //        resTransaccion.ArchivoError = "claTargetDao.cs";
        //        resTransaccion.MetodoError = "ListarClienteMasterporUsuario";
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return res;
        //}

        //// Metodo temporal en espera de que Gabriel implemente las clases cliente y target
        //public static ResultadoTransaccion ListarContactosporClienteUsuario(int IdUsuario, int IdCliente)
        //{
        //    ResultadoTransaccion res = new ResultadoTransaccion();
        //    IList<clsContacto> ListaContactos = new List<clsContacto>();
        //    try
        //    {
        //        //Abrir Conexion
        //        conn = BaseDatos.Conexion();

        //        //Consultar Asuntos x Tipo Actividad
        //        //objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "sp_c_ventas_tipo_actividad_asunto");
        //        //objParams[0].Value = IdTipoActividad;

        //        //SqlCommand command = new SqlCommand("sp_c_ventas_tipo_actividad_asunto", conn);

        //        //command.Transaction = transaction;
        //        //command.Parameters.AddRange(objParams);
        //        //command.CommandType = CommandType.StoredProcedure;
        //        //dreader = command.ExecuteReader();

        //        //while (dreader.Read())
        //        //{
        //        clsContacto ObjContacto = new clsContacto();
        //        ObjContacto.Id = 1;
        //        ObjContacto.Nombre = "Nombre Contacto 1";
        //        ObjContacto.ClienteMaster = new clsClienteMaster();
        //        ObjContacto.ClienteMaster.Id = 1;

        //        ListaContactos.Add(ObjContacto);

        //        clsContacto ObjContacto2 = new clsContacto();
        //        ObjContacto2.Id = 2;
        //        ObjContacto2.Nombre = "Nombre Contacto 2";
        //        ObjContacto2.ClienteMaster = new clsClienteMaster();
        //        ObjContacto2.ClienteMaster.Id = 1;

        //        ListaContactos.Add(ObjContacto2);

        //        clsContacto ObjContacto3 = new clsContacto();
        //        ObjContacto3.Id = 3;
        //        ObjContacto3.Nombre = "Nombre Contacto 3";
        //        ObjContacto3.ClienteMaster = new clsClienteMaster();
        //        ObjContacto3.ClienteMaster.Id = 1;

        //        ListaContactos.Add(ObjContacto3);
        //        //}
        //        res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
        //        res.ObjetoTransaccion = ListaContactos;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.EscribirLog(ex.Message);

        //        resTransaccion.Descripcion = ex.Message;
        //        resTransaccion.ArchivoError = "claTargetDao.cs";
        //        resTransaccion.MetodoError = "Listar Contactos x Cuenta x Usuario";
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return res;
        //}

    }
}
