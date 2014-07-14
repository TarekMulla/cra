using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Clientes.Contacto;
using ProyectoCraft.Entidades.Clientes.Direcciones;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Clientes.Cuenta;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Base.BaseDatos;
using System.Data.SqlClient;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Base.Log;
using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Collections;
using ProyectoCraft.Entidades.Log;
using ProyectoCraft.Entidades.Usuarios;

namespace ProyectoCraft.AccesoDatos.Clientes
{
    public  static class clsCuentaADO
    {
        private static SqlParameter[] objParams = null;
        private static SqlConnection conn = null;
        private static SqlTransaction transaction = null;
        private static SqlDataReader dreader = null;
        private static ResultadoTransaccion resTransaccion = null;

        public static IList<clsCuenta> ListarCuentas(string nombre, Int64 vendedor, Int64 customer, int idEstado)
        {
            IList<clsCuenta> listTarget = new List<clsCuenta>();
            clsCuenta cuenta;

            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Registrar Cliente Master
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_L_CLIENTES_CUENTAS");
                objParams[0].Value = nombre;
                objParams[1].Value = vendedor;
                objParams[2].Value = customer;
                objParams[3].Value = idEstado;
                SqlCommand command = new SqlCommand("SP_L_CLIENTES_CUENTAS", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                dreader.NextResult();
                while (dreader.Read())
                {
                    cuenta = new clsCuenta();
                    cuenta.ClienteMaster.Id = Convert.ToInt64(dreader[0]);
                    cuenta.Id = Convert.ToInt64(dreader[1]);
                    cuenta.ClienteMaster.NombreCompañia = dreader[2].ToString();
                    cuenta.ClienteMaster.RUT = dreader[3].ToString();

                    if (dreader[4] is DBNull)
                        cuenta.VendedorAsignado = null;
                    else
                        cuenta.VendedorAsignado = new clsUsuario(dreader[4].ToString(), dreader[5].ToString(), dreader[6].ToString());

                    //if (dreader[7] is DBNull)
                    //    cuenta.CustomerAsignado = null;
                    //else
                    //    cuenta.CustomerAsignado = new clsUsuario(dreader[7].ToString(), dreader[8].ToString(), dreader[9].ToString());

                    cuenta.Telefono = dreader[7].ToString();
                    cuenta.CuentaSkype = dreader[8].ToString();
                    cuenta.SitioWeb = dreader[9].ToString();
                    cuenta.Email = dreader[10].ToString();
                    cuenta.Estado = (Enums.Estado)Convert.ToInt16(dreader[11]);
                    cuenta.ClienteMaster.NombreFantasia = dreader[12].ToString();
                    listTarget.Add(cuenta);
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

        public static ResultadoTransaccion GuardarCuenta(clsCuenta cuenta)
        {
            resTransaccion = new ResultadoTransaccion();
            Int64 idMaster = 0;
            Int64 idCuenta = 0;
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Registrar Direcciones
                resTransaccion = clsDireccionADO.GuardarDirecciones(cuenta.ClienteMaster.DireccionInfo, conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                {
                    throw new Exception(resTransaccion.Descripcion);
                }
                cuenta.ClienteMaster.DireccionInfo = (clsDireccionInfo)resTransaccion.ObjetoTransaccion;

                //Registrar Cliente Master
                resTransaccion = clsClienteMasterADO.GuardarClienteMaster(cuenta.ClienteMaster, conn,
                                                                                          transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);

                idMaster = (Int64)resTransaccion.ObjetoTransaccion;
                
                //Registrar Cuenta
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_CLIENTES_CUENTA");
                objParams[0].Value = idMaster;                
                
                if (cuenta.VendedorAsignado != null)
                    objParams[1].Value = cuenta.VendedorAsignado.Id;
                else
                    objParams[1].Value = -1;

                //if (cuenta.CustomerAsignado != null)
                //    objParams[2].Value = cuenta.CustomerAsignado.Id;
                //else
                //    objParams[2].Value = -1;

                objParams[2].Value = cuenta.Telefono;
                objParams[3].Value = cuenta.CuentaSkype;
                objParams[4].Value = cuenta.SitioWeb;
                objParams[5].Value = cuenta.Email;
                objParams[6].Value = cuenta.Estado;

                if (cuenta.ZonaVentas == null)
                    objParams[7].Value = -1;
                else 
                    objParams[7].Value = cuenta.ZonaVentas.Id;

                if (cuenta.CategoriaCliente == null)
                    objParams[8].Value = -1;
                else 
                    objParams[8].Value = cuenta.CategoriaCliente.Id;

                objParams[9].Value = cuenta.Observacion;

                if (cuenta.SectorEconomico != null)
                    objParams[10].Value = cuenta.SectorEconomico.Id;
                else
                    objParams[10].Value = -1;

                if (cuenta.TipoMonedaVtaEstimada != null)
                    objParams[11].Value = cuenta.TipoMonedaVtaEstimada.Id;
                else
                    objParams[11].Value = -1;

                objParams[12].Value = cuenta.MontoVentaEstimada;
                objParams[13].Value = cuenta.NumEmpleados;

                if (cuenta.UMMovimientoEstimado != null)
                    objParams[14].Value = cuenta.UMMovimientoEstimado.Id;
                else
                    objParams[14].Value = -1;

                objParams[15].Value = cuenta.MontoMovimientoEstimado;

                                
                if (cuenta.FormaContactoPreferida != null)
                    objParams[16].Value = cuenta.FormaContactoPreferida.Id;
                else
                    objParams[16].Value = -1;

                objParams[17].Value = cuenta.PermiteTelOficina;
                objParams[18].Value = cuenta.PermiteTelParticular;
                objParams[19].Value = cuenta.PermiteTelCelular;
                objParams[20].Value = cuenta.PermiteSkype;
                objParams[21].Value = cuenta.PermiteEmail;
                objParams[22].Value = cuenta.PermiteEmailMasivo;
                if (cuenta.DiaPreferido == null)
                    objParams[23].Value = -1;
                else
                    objParams[23].Value = cuenta.DiaPreferido.Id;

                if (cuenta.JornadaPreferida == null)
                    objParams[24].Value = -1;
                else
                    objParams[24].Value = cuenta.JornadaPreferida.Id;
                
                objParams[25].Value = cuenta.AutorizadoAduana;

                if (cuenta.Clasificacion == null)
                    objParams[26].Value = -1;
                else 
                    objParams[26].Value = cuenta.Clasificacion.Id;

                SqlCommand command2 = new SqlCommand("SP_N_CLIENTES_CUENTA", conn);
                command2.Transaction = transaction;
                command2.Parameters.AddRange(objParams);
                command2.CommandType = CommandType.StoredProcedure;
                idCuenta = Convert.ToInt64(command2.ExecuteScalar());
                cuenta.Id = idCuenta;
                if (idMaster > 0)
                {
                    //Productos preferidos
                    //clsClienteMasterADO.BorrarProductos(idTarget, transaction,conn);
                    foreach (var producto in cuenta.ClienteMaster.ProductosPreferidos)
                    {
                        clsClienteMasterADO.AsignarTipoProducto(producto, idMaster, transaction, conn);
                    }

                    //Tipos Relacion
                    //clsClienteMasterADO.BorrarTipoRelacion(idMaster, transaction, conn);
                    foreach (var relacion in cuenta.ClienteMaster.TiposRelaciones)
                    {
                        clsClienteMasterADO.AsignarTipoRelacion(relacion, idMaster, transaction, conn);
                    }
                }

                //Ejecutar transaccion
                transaction.Commit();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.Descripcion = "Se Creo Cuenta con Id " + idMaster.ToString();


                //Registrar Actividad
                LogActividadUsuarios log = new LogActividadUsuarios(cuenta.GetType().ToString(), cuenta.Id, Enums.TipoActividadUsuario.Creo, Base.Usuario.UsuarioConectado.Usuario);
                LogActividades.clsLogActividadUsuariosADO.GuardaActividad(log);

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                resTransaccion.ArchivoError = "clsCuentaADO";
                resTransaccion.MetodoError = MethodBase.GetCurrentMethod().Name;

            }
            finally
            {
                conn.Close();
                resTransaccion.Accion = Enums.AccionTransaccion.Insertar;
                cuenta.Id = idCuenta;
                cuenta.ClienteMaster.Id = idMaster;
                resTransaccion.ObjetoTransaccion = cuenta;
            }

            return resTransaccion;
        }

        public static ResultadoTransaccion ActualizarCuenta(clsCuenta cuenta)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Registrar Direcciones
                resTransaccion = clsDireccionADO.GuardarDirecciones(cuenta.ClienteMaster.DireccionInfo, conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);

                cuenta.ClienteMaster.DireccionInfo = (clsDireccionInfo)resTransaccion.ObjetoTransaccion;


                //Actualizar Master
                resTransaccion = clsClienteMasterADO.ActualizarClienteMaster(cuenta.ClienteMaster, conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);
                
                //Actualizar Cuenta
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_A_CLIENTES_MASTER");
                objParams[0].Value = cuenta.Id;
                objParams[1].Value = cuenta.ClienteMaster.Id;
                                
                if (cuenta.VendedorAsignado != null)
                    objParams[2].Value = cuenta.VendedorAsignado.Id;
                else
                    objParams[2].Value = -1;

                //if (cuenta.CustomerAsignado != null)
                //    objParams[3].Value = cuenta.CustomerAsignado.Id;
                //else
                //    objParams[3].Value = -1;

                objParams[3].Value = cuenta.Telefono;
                objParams[4].Value = cuenta.CuentaSkype;
                objParams[5].Value = cuenta.SitioWeb;
                objParams[6].Value = cuenta.Email;
                objParams[7].Value = cuenta.Estado;

                if (cuenta.ZonaVentas != null)
                    objParams[8].Value = cuenta.ZonaVentas.Id;
                else
                    objParams[8].Value = -1;

                if (cuenta.CategoriaCliente != null)
                    objParams[9].Value = cuenta.CategoriaCliente.Id;
                else
                    objParams[9].Value = -1;

                objParams[10].Value = cuenta.Observacion;

                if (cuenta.SectorEconomico != null)
                    objParams[11].Value = cuenta.SectorEconomico.Id;
                else
                    objParams[11].Value = -1;

                if (cuenta.TipoMonedaVtaEstimada != null)
                    objParams[12].Value = cuenta.TipoMonedaVtaEstimada.Id;
                else
                    objParams[12].Value = -1;

                objParams[13].Value = cuenta.MontoVentaEstimada;
                objParams[14].Value = cuenta.NumEmpleados;

                if (cuenta.UMMovimientoEstimado != null)
                    objParams[15].Value = cuenta.UMMovimientoEstimado.Id;
                else
                    objParams[15].Value = -1;

                objParams[16].Value = cuenta.MontoMovimientoEstimado;
                
                if (cuenta.FormaContactoPreferida != null)
                    objParams[17].Value = cuenta.FormaContactoPreferida.Id;
                else
                    objParams[17].Value = -1;

                objParams[18].Value = cuenta.PermiteTelOficina;
                objParams[19].Value = cuenta.PermiteTelParticular;
                objParams[20].Value = cuenta.PermiteTelCelular;
                objParams[21].Value = cuenta.PermiteSkype;
                objParams[22].Value = cuenta.PermiteEmail;
                objParams[23].Value = cuenta.PermiteEmailMasivo;
                if (cuenta.DiaPreferido == null)
                    objParams[24].Value = -1;
                else
                    objParams[24].Value = cuenta.DiaPreferido.Id;

                if (cuenta.JornadaPreferida == null)
                    objParams[25].Value = -1;
                else
                    objParams[25].Value = cuenta.JornadaPreferida.Id;
                
                objParams[26].Value = cuenta.AutorizadoAduana;

                if (cuenta.Clasificacion == null)
                    objParams[27].Value = -1;
                else 
                    objParams[27].Value = cuenta.Clasificacion.Id;
                
                objParams[28].Value = cuenta.TipoReciboAperturaEmbarcador;

                SqlCommand command2 = new SqlCommand("SP_A_CLIENTES_MASTER", conn, transaction);
                command2.Parameters.AddRange(objParams);
                command2.CommandType = CommandType.StoredProcedure;
                command2.ExecuteNonQuery();

                //Productos preferidos

                foreach (var producto in cuenta.ClienteMaster.ProductosPreferidos)
                {
                    if (producto.IsNew && !producto.IsDeleted)
                        clsClienteMasterADO.AsignarTipoProducto(producto, cuenta.ClienteMaster.Id, transaction, conn);
                    else if (!producto.IsNew && !producto.IsDeleted)
                        clsClienteMasterADO.ActualizarTipoProducto(producto, transaction, conn);
                    else if (producto.IsDeleted)
                        clsClienteMasterADO.BorrarProductosPorId(producto.Id,transaction,conn);
                }


                //resTransaccion = clsClienteMasterADO.BorrarProductos(cuenta.ClienteMaster.Id, transaction, conn);
                //if (resTransaccion.Estado == Enums.EstadoTransaccion.Aceptada)
                //{
                //    foreach (var producto in cuenta.ClienteMaster.ProductosPreferidos)
                //    {
                //        clsClienteMasterADO.AsignarTipoProducto(producto, cuenta.ClienteMaster.Id, transaction, conn);
                //    }
                //}
                //else
                //    throw new Exception(resTransaccion.Descripcion);


                //Tipos Relacion
                resTransaccion = clsClienteMasterADO.BorrarTipoRelacion(cuenta.ClienteMaster.Id, transaction, conn);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Aceptada)
                {
                    foreach (var relacion in cuenta.ClienteMaster.TiposRelaciones)
                    {
                        clsClienteMasterADO.AsignarTipoRelacion(relacion, cuenta.ClienteMaster.Id, transaction, conn);
                    }
                }
                else
                    throw new Exception(resTransaccion.Descripcion);


                //Condiciones comerciales
                //resTransaccion = clsCondicionComercialDAO.GuardaCondicionComercialCliente(cuenta.ClienteMaster, conn,
                                                                                       //   transaction);
                //if(resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                //    throw new Exception(resTransaccion.Descripcion);


                //Ejecutar transaccion
                transaction.Commit();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.Descripcion = "Se actualizo Cuenta con Id " + cuenta.Id.ToString();

                //Registrar Actividad
                LogActividadUsuarios log = new LogActividadUsuarios(cuenta.GetType().ToString(), cuenta.Id, Enums.TipoActividadUsuario.Edito, Base.Usuario.UsuarioConectado.Usuario);
                LogActividades.clsLogActividadUsuariosADO.GuardaActividad(log);

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;                
            }
            finally
            {
                conn.Close();
                resTransaccion.Accion = Enums.AccionTransaccion.Actualizar;
                resTransaccion.ObjetoTransaccion = cuenta;
            }

            return resTransaccion;    
        }

        public static ResultadoTransaccion EliminarCuenta(clsCuenta cuenta)
        {
            ResultadoTransaccion resTransaccion = new ResultadoTransaccion();
            try
            {
                transaction = BaseDatos.Conexion().BeginTransaction();


                //Eliminar Direcciones
                if (cuenta.ClienteMaster.DireccionInfo != null)
                {
                    foreach (var direccion in cuenta.ClienteMaster.DireccionInfo.Items)
                    {
                        resTransaccion = new ResultadoTransaccion();
                        resTransaccion = clsDireccionADO.EliminarDireccion(direccion, transaction);

                        if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                            throw new Exception(resTransaccion.Descripcion);
                    }

                    resTransaccion = new ResultadoTransaccion();
                    resTransaccion = clsDireccionADO.EliminarDireccionInfo(cuenta.ClienteMaster.DireccionInfo.IdInfo,
                                                                           transaction);
                    if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resTransaccion.Descripcion);

                }

                //Eliminar Tipos de Relacion
                resTransaccion = new ResultadoTransaccion();
                resTransaccion = clsClienteMasterADO.BorrarTipoRelacion(cuenta.ClienteMaster.Id, transaction, conn);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);

                //Eliminar Tipos de Carga
                resTransaccion = new ResultadoTransaccion();
                resTransaccion = clsClienteMasterADO.BorrarProductos(cuenta.ClienteMaster.Id, transaction, conn);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);


                //Eliminar Cliente Master
                resTransaccion = new ResultadoTransaccion();
                resTransaccion = clsClienteMasterADO.EliminarClienteMaster(cuenta.ClienteMaster, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);

                //Eliminar Contactos
                IList<clsContacto> listContactos = new List<clsContacto>();
                listContactos = clsClienteMasterADO.ListarContactos(cuenta.ClienteMaster);
                foreach (var contacto in listContactos)
                {
                    resTransaccion = new ResultadoTransaccion();
                    resTransaccion = clsContactoADO.EliminarContacto(contacto, transaction);
                    if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resTransaccion.Descripcion);
                }
                
                //Eliminar Cuenta
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_E_CLIENTES_CUENTA");
                objParams[0].Value = cuenta.Id;

                SqlCommand command = new SqlCommand("SP_E_CLIENTES_CUENTA", BaseDatos.Conexion());
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = transaction;
                command.ExecuteNonQuery();
                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;

                transaction.Commit();


                //Registrar Actividad
                LogActividadUsuarios log = new LogActividadUsuarios(cuenta.GetType().ToString(), cuenta.Id, Enums.TipoActividadUsuario.Elimino, Base.Usuario.UsuarioConectado.Usuario);
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

        public static ResultadoTransaccion CambiaEstado(clsCuenta cuenta)
        {
            ResultadoTransaccion resTransaccion = new ResultadoTransaccion();
            try
            {                                
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_A_CLIENTES_CUENTA_CAMBIA_ESTADO");
                objParams[0].Value = cuenta.Id;
                objParams[1].Value = (Int16)cuenta.Estado;

                SqlCommand command = new SqlCommand("SP_A_CLIENTES_CUENTA_CAMBIA_ESTADO", BaseDatos.Conexion());
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

        public static ResultadoTransaccion ObtenerCuentaPorId(Int64 IdCuenta)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Registrar Cliente Master
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_CLIENTES_CUENTA_POR_ID");
                objParams[0].Value = IdCuenta;
                SqlCommand command = new SqlCommand("SP_C_CLIENTES_CUENTA_POR_ID", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    clsCuenta cuenta= new clsCuenta();
                    cuenta.ClienteMaster.Id = Convert.ToInt64(dreader["IdMaster"]);
                    cuenta.ClienteMaster.NombreCompañia = dreader["NombreCompania"].ToString();
                    cuenta.ClienteMaster.NombreFantasia = dreader["NombreFantasia"].ToString();
                    cuenta.ClienteMaster.RUT = dreader["RUT"].ToString();
                    cuenta.ClienteMaster.Tipo = (Enums.TipoPersona)dreader["CodTipo"];
                    cuenta.ClienteMaster.FechaCreacion = (DateTime)dreader["FechaCreacionMaster"];
                    if (dreader["AutorizadoAduana"] is DBNull)
                        cuenta.AutorizadoAduana = false;
                    else 
                        cuenta.AutorizadoAduana = (bool)dreader["AutorizadoAduana"];

                    if (dreader["IdDireccionInfo"] is DBNull)
                        cuenta.ClienteMaster.DireccionInfo = null;
                    else
                        cuenta.ClienteMaster.DireccionInfo =
                            clsDireccionADO.ListarDireccionesPorIdInfo(Convert.ToInt64(dreader["IdDireccionInfo"]));

                    cuenta.Id = Convert.ToInt64(dreader["IdCuenta"]);
                    
                    if (!(dreader["IdVendedorAsignado"] is DBNull))
                        cuenta.VendedorAsignado =
                            Usuarios.clsUsuarioADO.ObtenerUsuarioPorId(Convert.ToInt16(dreader["IdVendedorAsignado"]));

                    //if(!(dreader["IdCustomerAsignado"] is DBNull))
                    //    cuenta.CustomerAsignado = Usuarios.clsUsuarioADO.ObtenerUsuarioPorId(Convert.ToInt16(dreader["IdCustomerAsignado"]));

                    cuenta.Telefono = dreader["Telefono"].ToString();
                    cuenta.CuentaSkype = dreader["CuentaSkype"].ToString();
                    cuenta.SitioWeb = dreader["SitioWeb"].ToString();
                    cuenta.Email = dreader["Email"].ToString();
                    cuenta.Estado = (Enums.Estado)dreader["IdEstado"];

                    if (!(dreader["IdZonaVentas"] is DBNull))
                        cuenta.ZonaVentas =
                            Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdZonaVentas"]));

                    if (!(dreader["IdCategoriaCliente"] is DBNull))
                        cuenta.CategoriaCliente =
                            Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdCategoriaCliente"]));

                    if (!(dreader["IdClasificacion"] is DBNull))
                        cuenta.Clasificacion = ObtenerClasificacionPorId(Convert.ToInt16(dreader["Idclasificacion"]));

                    cuenta.Observacion = dreader["Observacion"].ToString();

                    if (!(dreader["IdSectorEconomico"] is DBNull))
                        cuenta.SectorEconomico =
                            Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdSectorEconomico"]));

                    if (!(dreader["IdMonedaVtaEst"] is DBNull))
                        cuenta.TipoMonedaVtaEstimada =
                            Parametros.clsParametrosDAO.BuscarMonedaPorId(Convert.ToInt16(dreader["IdMonedaVtaEst"]));

                    if (!(dreader["MontoVtaEst"] is DBNull))
                        cuenta.MontoVentaEstimada = (decimal)dreader["MontoVtaEst"];

                    if (!(dreader["NumEmpleados"] is DBNull))
                        cuenta.NumEmpleados = Convert.ToInt64(dreader["NumEmpleados"]);

                    if (!(dreader["IdUMMovimiento"] is DBNull))
                        cuenta.UMMovimientoEstimado =
                            Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdUMMovimiento"]));

                    if (!(dreader["VolumenMovimiento"] is DBNull))
                        cuenta.MontoMovimientoEstimado = Convert.ToDecimal(dreader["VolumenMovimiento"]);

                    if (!(dreader["IdFormaContactoPref"] is DBNull))
                        cuenta.FormaContactoPreferida =
                            Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdFormaContactoPref"]));

                    cuenta.PermiteTelOficina = (bool)dreader["PermiteTelOfi"];
                    cuenta.PermiteTelParticular = (bool)dreader["PermiteTelPart"];
                    cuenta.PermiteTelCelular = (bool)dreader["PermiteTelCel"];
                    cuenta.PermiteSkype = (bool)dreader["PermiteSkype"];
                    cuenta.PermiteEmail = (bool)dreader["PermiteEmail"];
                    cuenta.PermiteEmailMasivo = (bool)dreader["PermiteEmailMasivo"];

                    if (!(dreader["CodDiaPreferido"] is DBNull))
                        cuenta.DiaPreferido =
                            Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["CodDiaPreferido"]));

                    if (!(dreader["CodJornadaPreferida"] is DBNull))
                        cuenta.JornadaPreferida =
                            Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["CodJornadaPreferida"]));

                    cuenta.ClienteMaster.ProductosPreferidos =
                        clsClienteMasterADO.ObtenerProductosPreferidos(cuenta.ClienteMaster.Id);

                    cuenta.ClienteMaster.TiposRelaciones =
                        clsClienteMasterADO.ObtenerTiposRelacion(cuenta.ClienteMaster.Id);

                    cuenta.ClienteMaster.ClienteMasterTipoCliente = clsClienteMasterADO.ObtenerTiposRelacionClienteMaster(cuenta.ClienteMaster.Id);
                    if (!(dreader["PaperlessTipoRecibo"] is DBNull))
                    cuenta.TipoReciboAperturaEmbarcador = (Enums.PaperlessTipoReciboAperturaEmbarcador)(Convert.ToInt32(dreader["PaperlessTipoRecibo"]));

                    res.Estado = Enums.EstadoTransaccion.Aceptada;
                    res.ObjetoTransaccion = cuenta;

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
                if(!dreader.IsClosed) dreader.Close();
                conn.Close();
            }

            return res;
        }

        public static ResultadoTransaccion ObtenerCuentaPorIdMaster(Int64 IdMaster)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            try
            {
                
                //Abrir Conexion
                //conn = BaseDatos.Conexion();
                conn = BaseDatos.NuevaConexion();

                //Registrar Cliente Master
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_CLIENTES_CUENTA_POR_ID_MASTER");
                objParams[0].Value = IdMaster;
                SqlCommand command = new SqlCommand("SP_C_CLIENTES_CUENTA_POR_ID_MASTER", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    clsCuenta cuenta = new clsCuenta();
                    cuenta.ClienteMaster.Id = Convert.ToInt64(dreader["IdMaster"]);
                    cuenta.ClienteMaster.NombreCompañia = dreader["NombreCompania"].ToString();
                    cuenta.ClienteMaster.NombreFantasia = dreader["NombreFantasia"].ToString();
                    cuenta.ClienteMaster.RUT = dreader["RUT"].ToString();
                    cuenta.ClienteMaster.Tipo = (Enums.TipoPersona)dreader["CodTipo"];
                    cuenta.ClienteMaster.FechaCreacion = (DateTime)dreader["FechaCreacionMaster"];
                    if (dreader["AutorizadoAduana"] is DBNull)
                        cuenta.AutorizadoAduana = false;
                    else
                        cuenta.AutorizadoAduana = (bool)dreader["AutorizadoAduana"];

                    if (dreader["IdDireccionInfo"] is DBNull)
                        cuenta.ClienteMaster.DireccionInfo = null;
                    else
                        cuenta.ClienteMaster.DireccionInfo =
                            clsDireccionADO.ListarDireccionesPorIdInfo(Convert.ToInt64(dreader["IdDireccionInfo"]));

                    cuenta.Id = Convert.ToInt64(dreader["IdCuenta"]);

                    if (!(dreader["IdVendedorAsignado"] is DBNull))
                        cuenta.VendedorAsignado =
                            Usuarios.clsUsuarioADO.ObtenerUsuarioPorId(Convert.ToInt16(dreader["IdVendedorAsignado"]));

                    //if (!(dreader["IdCustomerAsignado"] is DBNull))
                    //    cuenta.CustomerAsignado = Usuarios.clsUsuarioADO.ObtenerUsuarioPorId(Convert.ToInt16(dreader["IdCustomerAsignado"]));

                    cuenta.Telefono = dreader["Telefono"].ToString();
                    cuenta.CuentaSkype = dreader["CuentaSkype"].ToString();
                    cuenta.SitioWeb = dreader["SitioWeb"].ToString();
                    cuenta.Email = dreader["Email"].ToString();
                    cuenta.Estado = (Enums.Estado)dreader["IdEstado"];

                    if (!(dreader["IdZonaVentas"] is DBNull))
                        cuenta.ZonaVentas =
                            Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdZonaVentas"]));

                    if (!(dreader["IdCategoriaCliente"] is DBNull))
                        cuenta.CategoriaCliente =
                            Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdCategoriaCliente"]));

                    if (!(dreader["IdClasificacion"] is DBNull))
                        cuenta.Clasificacion = ObtenerClasificacionPorId(Convert.ToInt16(dreader["IdClasificacion"]));


                    cuenta.Observacion = dreader["Observacion"].ToString();

                    if (!(dreader["IdSectorEconomico"] is DBNull))
                        cuenta.SectorEconomico =
                            Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdSectorEconomico"]));

                    if (!(dreader["IdMonedaVtaEst"] is DBNull))
                        cuenta.TipoMonedaVtaEstimada =
                            Parametros.clsParametrosDAO.BuscarMonedaPorId(Convert.ToInt16(dreader["IdMonedaVtaEst"]));

                    if (!(dreader["MontoVtaEst"] is DBNull))
                        cuenta.MontoVentaEstimada = (decimal)dreader["MontoVtaEst"];

                    if (!(dreader["NumEmpleados"] is DBNull))
                        cuenta.NumEmpleados = Convert.ToInt64(dreader["NumEmpleados"]);

                    if (!(dreader["IdUMMovimiento"] is DBNull))
                        cuenta.UMMovimientoEstimado =
                            Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdUMMovimiento"]));

                    if (!(dreader["VolumenMovimiento"] is DBNull))
                        cuenta.MontoMovimientoEstimado = Convert.ToDecimal(dreader["VolumenMovimiento"]);

                    if (!(dreader["IdFormaContactoPref"] is DBNull))
                        cuenta.FormaContactoPreferida =
                            Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdFormaContactoPref"]));

                    cuenta.PermiteTelOficina = (bool)dreader["PermiteTelOfi"];
                    cuenta.PermiteTelParticular = (bool)dreader["PermiteTelPart"];
                    cuenta.PermiteTelCelular = (bool)dreader["PermiteTelCel"];
                    cuenta.PermiteSkype = (bool)dreader["PermiteSkype"];
                    cuenta.PermiteEmail = (bool)dreader["PermiteEmail"];
                    cuenta.PermiteEmailMasivo = (bool)dreader["PermiteEmailMasivo"];

                    if (!(dreader["CodDiaPreferido"] is DBNull))
                        cuenta.DiaPreferido =
                            Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["CodDiaPreferido"]));

                    if (!(dreader["CodJornadaPreferida"] is DBNull))
                        cuenta.JornadaPreferida =
                            Parametros.clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["CodJornadaPreferida"]));

                    cuenta.ClienteMaster.ProductosPreferidos =
                        clsClienteMasterADO.ObtenerProductosPreferidos(cuenta.ClienteMaster.Id);

                    cuenta.ClienteMaster.TiposRelaciones =
                        clsClienteMasterADO.ObtenerTiposRelacion(cuenta.ClienteMaster.Id);

                    res.Estado = Enums.EstadoTransaccion.Aceptada;
                    res.ObjetoTransaccion = cuenta;

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
                if(!dreader.IsClosed) dreader.Close();
                conn.Close();
            }

            return res;
        }

        public static IList<clsCuentaclasificacion> ListarClasificaciones(Enums.Estado Estado)
        {
            IList<clsCuentaclasificacion> listClasificacion = new List<clsCuentaclasificacion>();
            clsCuentaclasificacion clasificacion;

            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Registrar Cliente Master
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_CLIENTES_CLASIFICACION");
                objParams[0].Value = Estado;

                SqlCommand command = new SqlCommand("SP_C_CLIENTES_CLASIFICACION", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    clasificacion = new clsCuentaclasificacion();
                    clasificacion.Id = Convert.ToInt64(dreader[0]);
                    clasificacion.Nombre = dreader[1].ToString();
                    clasificacion.Estado = (Enums.Estado)Convert.ToInt16(dreader[2]);
                    listClasificacion.Add(clasificacion);
                }
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

            }
            finally
            {
                if(!dreader.IsClosed) dreader.Close();
                conn.Close();
            }

            return listClasificacion;
        }

        public static clsCuentaclasificacion ObtenerClasificacionPorId(int IdClasificacion)
        {            
            clsCuentaclasificacion clasificacion = new clsCuentaclasificacion();

            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();

                //Registrar Cliente Master
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_CLIENTES_CLASIFICACION_POR_ID");
                objParams[0].Value = IdClasificacion;

                DataSet ds = SqlHelper.ExecuteDataset(conn, "SP_C_CLIENTES_CLASIFICACION_POR_ID", objParams);
                if (ds != null)
                {
                    clasificacion = new clsCuentaclasificacion();
                    clasificacion.Id = Convert.ToInt64(ds.Tables[0].Rows[0]["Id"]);
                    clasificacion.Nombre = ds.Tables[0].Rows[0]["Descripcion"].ToString();
                    clasificacion.Estado = (Enums.Estado)Convert.ToInt16(ds.Tables[0].Rows[0]["Estado"].ToString());   
                                       
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

            return clasificacion;
        }
    }
}
