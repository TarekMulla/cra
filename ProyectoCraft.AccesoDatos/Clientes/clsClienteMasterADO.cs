using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ProyectoCraft.AccesoDatos.LogPerfomance;
using ProyectoCraft.AccesoDatos.Parametros;
using ProyectoCraft.Entidades.Clientes.Contacto;
using ProyectoCraft.Entidades.Clientes.Cuenta;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Log;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.Entidades.Ventas.Actividades;
using ProyectoCraft.Entidades.Ventas.Productos;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Base.BaseDatos;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Base;
using System.Reflection;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Base.Log;

namespace ProyectoCraft.AccesoDatos.Clientes {
    public static class clsClienteMasterADO {
        private static SqlParameter[] objParams = null;
        private static SqlConnection conn = null;
        private static SqlDataReader dreader = null;
        private static ResultadoTransaccion resTransaccion = null;

        #region "Cliente Master"

        public static ResultadoTransaccion GuardarClienteMaster(clsClienteMaster ClienteMaster, SqlConnection conection, SqlTransaction transaction) {
            Int64 idMaster = 0;
            resTransaccion = new ResultadoTransaccion();
            try {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conection, "SP_N_CLIENTES_CLIENTE_MASTER");

                // fixme: se reemplaza tipo de cuenta, esto es un error de paperless
                var nombreCom = String.Empty;
                if (!String.IsNullOrEmpty(ClienteMaster.NombreCompañia)) {
                    nombreCom = ClienteMaster.NombreCompañia.Replace("(CuentaPaperless)", "");
                    nombreCom = nombreCom.Replace("(Cuenta)", "");
                }
                objParams[0].Value = nombreCom;
                objParams[1].Value = ClienteMaster.Nombres;
                objParams[2].Value = ClienteMaster.ApellidoPaterno;
                objParams[3].Value = ClienteMaster.ApellidoMaterno;
                objParams[4].Value = ClienteMaster.RUT;
                objParams[5].Value = (int)ClienteMaster.Tipo;

                if (ClienteMaster.DireccionInfo == null || ClienteMaster.DireccionInfo.IdInfo == 0)
                    objParams[6].Value = -1;
                else
                    objParams[6].Value = ClienteMaster.DireccionInfo.IdInfo;

                objParams[7].Value = ClienteMaster.Tipo;

                // fixme: se reemplaza tipo de cuenta, esto es un error de paperless
                var nombreFantasia = String.Empty;
                if (!String.IsNullOrEmpty(ClienteMaster.NombreFantasia)) {
                    nombreFantasia = ClienteMaster.NombreFantasia.Replace("(CuentaPaperless)", "");
                    nombreFantasia = nombreFantasia.Replace("(Cuenta)", "");
                }

                objParams[8].Value = nombreFantasia;
                objParams[9].Value = Base.Usuario.UsuarioConectado.Usuario.Id;
                SqlCommand command = new SqlCommand("SP_N_CLIENTES_CLIENTE_MASTER", conection);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                idMaster = Convert.ToInt64(command.ExecuteScalar());

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.ObjetoTransaccion = idMaster;

            } catch (Exception ex) {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        public static ResultadoTransaccion ActualizarClienteMaster(clsClienteMaster master, SqlConnection conection, SqlTransaction transaction) {
            resTransaccion = new ResultadoTransaccion();
            try {
                //Actualizar Cliente Master
                objParams = SqlHelperParameterCache.GetSpParameterSet(conection, "SP_A_CLIENTES_CLIENTE_MASTER");
                objParams[0].Value = master.Id;
                objParams[1].Value = master.NombreCompañia;
                objParams[2].Value = master.Nombres;
                objParams[3].Value = master.ApellidoPaterno;
                objParams[4].Value = master.ApellidoMaterno;
                objParams[5].Value = master.RUT;
                objParams[6].Value = (int)master.Tipo;
                if (master.DireccionInfo == null)
                    objParams[7].Value = -1;
                else
                    objParams[7].Value = master.DireccionInfo.IdInfo;

                objParams[8].Value = master.NombreFantasia;
                objParams[9].Value = Base.Usuario.UsuarioConectado.Usuario.Id;

                SqlCommand command = new SqlCommand("SP_A_CLIENTES_CLIENTE_MASTER", conection);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;

            }

            return resTransaccion;
        }

        public static ResultadoTransaccion EliminarClienteMaster(clsClienteMaster cliente, SqlTransaction transaction) {
            ResultadoTransaccion resTransaccion = new ResultadoTransaccion();
            try {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_E_CLIENTES_MASTER");
                objParams[0].Value = cliente.Id;

                SqlCommand command = new SqlCommand("SP_E_CLIENTES_MASTER", BaseDatos.Conexion());
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = transaction;
                command.ExecuteNonQuery();
                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;

            } catch (Exception ex) {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;

        }

        public static IList<clsClienteMaster> ListarClienteMaster(string busqueda, Enums.TipoPersona tipo, Enums.Estado estado, bool mostrarNombreFantasia) {
            var listMaster = new List<clsClienteMaster>();
            var timer = System.Diagnostics.Stopwatch.StartNew();
            try {
                //Abrir Conexion

                conn = BaseDatos.NuevaConexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_CLIENTE_MASTER");
                objParams[0].Value = busqueda;
                objParams[1].Value = (int)tipo;
                objParams[2].Value = (int)estado;

                SqlCommand command = new SqlCommand("SP_C_CLIENTE_MASTER", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();
                ClsLogPerformanceADO.SaveFromADO(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds, "Consultando SP_C_CLIENTE_MASTER"));
                timer = System.Diagnostics.Stopwatch.StartNew();
                while (dreader.Read()) {
                    var idMaster = Convert.ToInt64(dreader[0]);
                    /*var masterEncontrado = listMaster.Find(
                        foo => foo.Id.Equals(idMaster));*/
                    clsClienteMaster masterEncontrado = null;
                    if (masterEncontrado == null) {
                        var master = new clsClienteMaster(mostrarNombreFantasia);
                        master.Id = idMaster;
                        master.NombreCompañia = dreader[1].ToString();
                        master.Nombres = dreader[2].ToString();
                        master.ApellidoPaterno = dreader[3].ToString();
                        master.ApellidoMaterno = dreader[4].ToString();
                        master.Tipo = (Enums.TipoPersona)dreader[7];
                        master.NombreFantasia = "";
                        if (master.Tipo == Enums.TipoPersona.Target)
                            master.EstadoTarget = (Enums.Estado)dreader[5];
                        else if (master.Tipo == Enums.TipoPersona.Cuenta) {
                            master.EstadoCuenta = (Enums.Estado)dreader[6];
                            master.Cuenta = new clsCuenta();
                            master.NombreFantasia = dreader["NombreFantasia"].ToString();
                        }

                        master.ProductosPreferidos = ObtenerProductosPreferidos(master.Id);
                        master.ProductosPreferidos = new List<clsClientesProductos>();
                        var producto = GetProducto(dreader);
                        if (producto != null)
                            master.ProductosPreferidos.Add(producto);
                        master.RUT = dreader[8].ToString();
                        listMaster.Add(master);
                    } else {
                        var producto = GetProducto(dreader);
                        if (producto != null)
                            masterEncontrado.ProductosPreferidos.Add(producto);
                    }
                }

                ClsLogPerformanceADO.SaveFromADO(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds, "llenando objetos del resultado de SP_C_CLIENTE_MASTER"));    

            } catch (Exception ex) {
                Base.Log.Log.EscribirLog(ex.Message);
                //resTransaccion.MetodoError = MethodBase.GetCurrentMethod().Name;
                //resTransaccion.ArchivoError = MethodBase.GetCurrentMethod().ToString();
            } finally {
                conn.Close();
            }

            
            return listMaster;
        }

        private static clsClientesProductos GetProducto(IDataReader dataReader) {
            try {
                var row = dataReader;
                if ((row["IdTipoCarga"] is DBNull))
                    return null;

                var producto = new clsClientesProductos();
                producto.Producto.Id = Convert.ToInt64(row["IdTipoCarga"]);
                producto.Producto.Nombre = row["Descripcion"].ToString();
                producto.Producto.Activo = row["Activo"].ToString();
                producto.Id = Convert.ToInt64(row["Id"]);

                if (!(row["u_Nombres"] is DBNull)) {
                    producto.Customer.Id = Convert.ToInt64(row["IdCliente"]);
                    producto.Customer.Nombre = row["u_Nombres"].ToString();
                    producto.Customer.ApellidoPaterno = row["u_ApellidoPaterno"].ToString();
                    producto.Customer.ApellidoMaterno = row["u_ApellidoMaterno"].ToString();
                    producto.Customer.Email = row["Email"].ToString();
                }

                return producto;
            } catch (Exception e) {
                Console.Write(e.Message);
                return null;
            }
        }
        public static clsClienteMaster ObtenerClienteMasterPorId(Int64 IdCliente) {
            clsClienteMaster master = null;
            SqlDataReader readercliente = null;
            try {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_CLIENTES_MASTER_POR_ID");
                objParams[0].Value = IdCliente;

                SqlCommand command = new SqlCommand("SP_C_CLIENTES_MASTER_POR_ID", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                readercliente = command.ExecuteReader();

                while (readercliente.Read()) {
                    master = new clsClienteMaster(true);
                    master.Id = Convert.ToInt64(readercliente["Id"]);
                    master.NombreCompañia = readercliente["NombreCompania"].ToString();
                    master.Nombres = readercliente["Nombres"].ToString();
                    master.ApellidoPaterno = readercliente["ApellidoPaterno"].ToString();
                    master.ApellidoMaterno = readercliente["ApellidoMaterno"].ToString();
                    master.RUT = readercliente["RUT"].ToString();

                    if (readercliente["NombreFantasia"] is DBNull)
                        master.NombreFantasia = "";
                    else
                        master.NombreFantasia = readercliente["NombreFantasia"].ToString();

                    master.Tipo = (Enums.TipoPersona)readercliente["CodTipo"];

                    if (readercliente["IdDireccionInfo"] is DBNull)
                        master.DireccionInfo = null;
                    else
                        master.DireccionInfo = clsDireccionADO.ListarDireccionesPorIdInfo(Convert.ToInt64(readercliente["IdDireccionInfo"]));

                    master.ProductosPreferidos = ObtenerProductosPreferidos(master.Id);

                }

            } catch (Exception ex) {
                Base.Log.Log.EscribirLog(ex.Message);
            } finally {
                if (!readercliente.IsClosed)
                    readercliente.Close();
            }

            return master;
        }

        public static bool ValidarExisteRut(string rut, Enums.TipoPersona tipo) {
            bool existe = false;
            try {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_CLIENTE_MASTER_EXISTE_RUT");
                objParams[0].Value = rut;
                objParams[1].Value = (int)tipo;

                SqlCommand command = new SqlCommand("SP_C_CLIENTE_MASTER_EXISTE_RUT", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                Int16 count = Convert.ToInt16(command.ExecuteScalar());

                if (count > 0)
                    existe = true;

            } catch (Exception ex) {
                Base.Log.Log.EscribirLog(ex.Message);
                existe = false;
            } finally {
                conn.Close();
            }

            return existe;
        }

        #endregion

        #region "Contactos"

        public static IList<clsContacto> ListarContactos(clsClienteMaster cliente) {
            IList<clsContacto> listContactos = new List<clsContacto>();
            try {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();

                //Registrar Cliente Master
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_CLIENTES_CONTACTOS_POR_ID_CLIENTE");
                objParams[0].Value = cliente.Id;
                SqlCommand command = new SqlCommand("SP_C_CLIENTES_CONTACTOS_POR_ID_CLIENTE", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read()) {
                    clsContacto contacto = new clsContacto();

                    contacto.Id = Convert.ToInt64(dreader["Id"]);

                    if (dreader["IdSaludo"] is DBNull)
                        contacto.TipoSaludo = null;
                    else
                        contacto.TipoSaludo = clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdSaludo"]));

                    contacto.Nombre = dreader["Nombres"].ToString();
                    contacto.ApellidoPaterno = dreader["ApellidoPaterno"].ToString();
                    contacto.ApellidoMaterno = dreader["ApellidoMaterno"].ToString();
                    contacto.Cargo = dreader["Cargo"].ToString();
                    contacto.TelefonoOficina = dreader["TelefonoOficina"].ToString();
                    contacto.TelefonoParticular = dreader["TelefonoParticular"].ToString();
                    contacto.TelefonoCelular = dreader["TelefonoCelular"].ToString();
                    contacto.CuentaSkype = dreader["CuentaSkype"].ToString();
                    contacto.Email = dreader["Email"].ToString();
                    contacto.Estado = ((Enums.Estado)Convert.ToInt16(dreader["IdEstado"]));
                    contacto.Observacion = dreader["Observacion"].ToString();

                    if (dreader["Departamento"] is DBNull)
                        contacto.Departamento = null;
                    else
                        contacto.Departamento = clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["Departamento"]));

                    contacto.NombreJefe = dreader["NombreJefe"].ToString();
                    contacto.TelefonoJefe = dreader["TelefonoJefe"].ToString();

                    if (dreader["IdTipoRol"] is DBNull)
                        contacto.TipoRol = null;
                    else
                        contacto.TipoRol = clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdTipoRol"]));

                    contacto.NombreAyudante = dreader["NombreAyudante"].ToString();
                    contacto.TelefonoAyudante = dreader["TelefonoAyudante"].ToString();
                    contacto.Cumpleaños = dreader["Cumpleanos"].ToString();

                    if (dreader["IdEstadoCivil"] is DBNull)
                        contacto.EstadoCivil = null;
                    else
                        contacto.EstadoCivil = clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdEstadoCivil"]));

                    if (dreader["IdSexo"] is DBNull)
                        contacto.Sexo = null;
                    else
                        contacto.Sexo = clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdSexo"]));

                    contacto.NombrePareja = dreader["NombrePareja"].ToString();
                    contacto.FechaAniversario = dreader["FechaAniversario"].ToString();
                    contacto.RegaloPreferido = dreader["RegaloPreferido"].ToString();

                    if (dreader["IdFormaContactoPreferida"] is DBNull)
                        contacto.FormaContactoPreferida = null;
                    else
                        contacto.FormaContactoPreferida = clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdFormaContactoPreferida"]));

                    contacto.PermiteTelOficina = (bool)dreader["PermiteTelOficina"];
                    contacto.PermiteTelParticular = (bool)dreader["PermiteTelCelular"];
                    contacto.PermiteTelCelular = (bool)dreader["PermiteTelCelular"];
                    contacto.PermiteSkype = (bool)dreader["PermiteSkype"];
                    contacto.PermiteEmail = (bool)dreader["PermiteEmail"];
                    contacto.PermiteEmailMasivo = (bool)dreader["PermiteEmailMasivo"];

                    if (dreader["IdDiaPreferido"] is DBNull)
                        contacto.DiaPreferido = null;
                    else
                        contacto.DiaPreferido = clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdDiaPreferido"]));

                    if (dreader["IdJornadaPreferida"] is DBNull)
                        contacto.JornadaPreferida = null;
                    else
                        contacto.JornadaPreferida = clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdJornadaPreferida"]));

                    contacto.EsPrincipal = (bool)dreader["EsPrincipal"];

                    if (dreader["IdDireccionInfo"] is DBNull)
                        contacto.DireccionInfo = null;
                    else
                        contacto.DireccionInfo = clsDireccionADO.ListarDireccionesPorIdInfo(Convert.ToInt64(dreader["IdDireccionInfo"]));

                    if (dreader["IdPropietario"] is DBNull)
                        contacto.Propietario = null;
                    else
                        contacto.Propietario = Usuarios.clsUsuarioADO.ObtenerUsuarioPorId(Convert.ToInt16(dreader["IdPropietario"]));

                    contacto.ClienteMaster = cliente;

                    listContactos.Add(contacto);

                }
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);
            } finally {
                conn.Close();
            }
            return listContactos;
        }

        #endregion

        #region "Productos Preferidos"
        public static IList<clsClientesProductos> ObtenerProductosPreferidos(Int64 IdCiente) {
            clsClientesProductos producto = null;
            IList<clsClientesProductos> listProductos = new List<clsClientesProductos>();
            SqlDataReader dreaderProd = null;
            try {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_CLIENTES_PRODUCTOS_PREFERIDOS");
                objParams[0].Value = IdCiente;


                DataSet ds = SqlHelper.ExecuteDataset(conn, "SP_C_CLIENTES_PRODUCTOS_PREFERIDOS", objParams);
                if (ds != null) {
                    foreach (DataRow row in ds.Tables[0].Rows) {
                        producto = new clsClientesProductos();
                        producto.Producto.Id = Convert.ToInt64(row["IdTipoCarga"]);
                        producto.Producto.Nombre = row["Descripcion"].ToString();
                        producto.Producto.Activo = row["Activo"].ToString();
                        producto.Id = Convert.ToInt64(row["Id"]);

                        if (!(row["Nombres"] is DBNull)) {
                            producto.Customer.Id = Convert.ToInt64(row["IdCliente"]);
                            producto.Customer.Nombre = row["Nombres"].ToString();
                            producto.Customer.ApellidoPaterno = row["ApellidoPaterno"].ToString();
                            producto.Customer.ApellidoMaterno = row["ApellidoMaterno"].ToString();
                            producto.Customer.Email = row["Email"].ToString();
                        }

                        listProductos.Add(producto);
                    }
                }


                //SqlCommand command = new SqlCommand("SP_C_CLIENTES_PRODUCTOS_PREFERIDOS", conn);
                //command.Parameters.AddRange(objParams);
                //command.CommandType = CommandType.StoredProcedure;
                //dreaderProd = command.ExecuteReader();

                //while (dreaderProd.Read())
                //{
                //    producto = new clsClientesProductos();
                //    producto.Producto.Id = Convert.ToInt64(dreaderProd["IdTipoCarga"]);
                //    producto.Producto.Nombre = dreaderProd["Descripcion"].ToString();
                //    producto.Producto.Activo = dreaderProd["Activo"].ToString();
                //    producto.Id = Convert.ToInt64(dreaderProd["Id"]);

                //    if (!(dreaderProd["IdCustomer"] is DBNull))
                //    {                                                
                //        producto.Customer = Usuarios.clsUsuarioADO.ObtenerUsuarioPorId(
                //                Convert.ToInt16(dreaderProd["IdCustomer"].ToString()));
                //    }

                //    listProductos.Add(producto);
                //}

            } catch (Exception ex) {
                Base.Log.Log.EscribirLog(ex.Message);
                resTransaccion.MetodoError = MethodBase.GetCurrentMethod().Name;
                resTransaccion.ArchivoError = MethodBase.GetCurrentMethod().ToString();
            } finally {
                conn.Close();
            }

            return listProductos;
        }

        public static ResultadoTransaccion BorrarProductos(Int64 IdCliente, SqlTransaction transaccion, SqlConnection conection) {
            resTransaccion = new ResultadoTransaccion();
            try {

                objParams = SqlHelperParameterCache.GetSpParameterSet(conection, "SP_E_CLIENTES_PRODUCTO_PREFERIDO");
                objParams[0].Value = IdCliente;

                SqlCommand command = new SqlCommand("SP_E_CLIENTES_PRODUCTO_PREFERIDO", conection);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = transaccion;
                command.ExecuteNonQuery();
                resTransaccion.Estado = Entidades.Enums.Enums.EstadoTransaccion.Aceptada;
            } catch (Exception ex) {
                Base.Log.Log.EscribirLog(ex.Message);
                resTransaccion.Descripcion = ex.Message;
                resTransaccion.MetodoError = MethodBase.GetCurrentMethod().Name;
                resTransaccion.ArchivoError = MethodBase.GetCurrentMethod().ToString();
                resTransaccion.Estado = Entidades.Enums.Enums.EstadoTransaccion.Rechazada;
            } finally {
                //conn.Close();
            }
            return resTransaccion;
        }

        public static ResultadoTransaccion AsignarTipoProducto(clsClientesProductos producto, Int64 idCliente, SqlTransaction transaccion, SqlConnection conection) {
            resTransaccion = new ResultadoTransaccion();
            try {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conection, "SP_N_CLIENTES_PRODUCTO_PREFERIDO");
                objParams[0].Value = idCliente;
                objParams[1].Value = producto.Producto.Id;
                objParams[2].Value = producto.Customer.Id;

                SqlCommand command = new SqlCommand("SP_N_CLIENTES_PRODUCTO_PREFERIDO", conection);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = transaccion;
                command.ExecuteNonQuery();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;


            } catch (Exception ex) {
                Base.Log.Log.EscribirLog(ex.Message);
                resTransaccion.Descripcion = ex.Message;
                resTransaccion.MetodoError = MethodBase.GetCurrentMethod().Name;
                resTransaccion.ArchivoError = MethodBase.GetCurrentMethod().ToString();
                resTransaccion.Estado = Entidades.Enums.Enums.EstadoTransaccion.Rechazada;
            } finally {
                //conn.Close();
            }
            return resTransaccion;
        }

        public static ResultadoTransaccion ActualizarTipoProducto(clsClientesProductos producto, SqlTransaction transaccion, SqlConnection conection) {
            resTransaccion = new ResultadoTransaccion();
            try {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conection, "SP_A_CLIENTES_PRODUCTO_PREFERIDO");
                objParams[0].Value = producto.Producto.Id;
                objParams[1].Value = producto.Customer.Id;
                objParams[2].Value = producto.Id;

                SqlCommand command = new SqlCommand("SP_A_CLIENTES_PRODUCTO_PREFERIDO", conection);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = transaccion;
                command.ExecuteNonQuery();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;


            } catch (Exception ex) {
                Base.Log.Log.EscribirLog(ex.Message);
                resTransaccion.Descripcion = ex.Message;
                resTransaccion.MetodoError = MethodBase.GetCurrentMethod().Name;
                resTransaccion.ArchivoError = MethodBase.GetCurrentMethod().ToString();
                resTransaccion.Estado = Entidades.Enums.Enums.EstadoTransaccion.Rechazada;
            } finally {
                //conn.Close();
            }
            return resTransaccion;
        }

        public static ResultadoTransaccion BorrarProductosPorId(Int64 Id, SqlTransaction transaccion, SqlConnection conection) {
            resTransaccion = new ResultadoTransaccion();
            try {

                objParams = SqlHelperParameterCache.GetSpParameterSet(conection, "SP_E_CLIENTES_PRODUCTO_PREFERIDO_POR_ID");
                objParams[0].Value = Id;

                SqlCommand command = new SqlCommand("SP_E_CLIENTES_PRODUCTO_PREFERIDO_POR_ID", conection);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = transaccion;
                command.ExecuteNonQuery();
                resTransaccion.Estado = Entidades.Enums.Enums.EstadoTransaccion.Aceptada;
            } catch (Exception ex) {
                Base.Log.Log.EscribirLog(ex.Message);
                resTransaccion.Descripcion = ex.Message;
                resTransaccion.MetodoError = MethodBase.GetCurrentMethod().Name;
                resTransaccion.ArchivoError = MethodBase.GetCurrentMethod().ToString();
                resTransaccion.Estado = Entidades.Enums.Enums.EstadoTransaccion.Rechazada;
            } finally {
                //conn.Close();
            }
            return resTransaccion;
        }
        #endregion

        #region "Tipos de Relacion"

        public static ResultadoTransaccion BorrarTipoRelacion(Int64 IdCliente, SqlTransaction transaccion, SqlConnection conection) {
            resTransaccion = new ResultadoTransaccion();
            try {

                objParams = SqlHelperParameterCache.GetSpParameterSet(conection, "SP_E_CLIENTES_TIPO_RELACION");
                objParams[0].Value = IdCliente;

                SqlCommand command = new SqlCommand("SP_E_CLIENTES_TIPO_RELACION", conection);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = transaccion;
                command.ExecuteNonQuery();
                resTransaccion.Estado = Entidades.Enums.Enums.EstadoTransaccion.Aceptada;
            } catch (Exception ex) {
                Base.Log.Log.EscribirLog(ex.Message);
                resTransaccion.Descripcion = ex.Message;
                resTransaccion.MetodoError = MethodBase.GetCurrentMethod().Name;
                resTransaccion.ArchivoError = MethodBase.GetCurrentMethod().ToString();
                resTransaccion.Estado = Entidades.Enums.Enums.EstadoTransaccion.Rechazada;
            } finally {
                //conn.Close();
            }
            return resTransaccion;
        }

        public static ResultadoTransaccion AsignarTipoRelacion(clsItemParametro relacion, Int64 idCliente, SqlTransaction transaccion, SqlConnection conection) {
            resTransaccion = new ResultadoTransaccion();
            try {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conection, "SP_N_CLIENTES__TIPO_RELACION");
                objParams[0].Value = idCliente;
                objParams[1].Value = relacion.Id;

                SqlCommand command = new SqlCommand("SP_N_CLIENTES__TIPO_RELACION", conection);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = transaccion;
                command.ExecuteNonQuery();

                resTransaccion.Estado = Entidades.Enums.Enums.EstadoTransaccion.Aceptada;


            } catch (Exception ex) {
                Base.Log.Log.EscribirLog(ex.Message);
                resTransaccion.Descripcion = ex.Message;
                resTransaccion.MetodoError = MethodBase.GetCurrentMethod().Name;
                resTransaccion.ArchivoError = MethodBase.GetCurrentMethod().ToString();
                resTransaccion.Estado = Entidades.Enums.Enums.EstadoTransaccion.Rechazada;
            } finally {
                //conn.Close();
            }
            return resTransaccion;
        }

        public static IList<clsItemParametro> ObtenerTiposRelacion(Int64 IdCiente) {
            clsItemParametro relacion = null;
            IList<clsItemParametro> listrelaciones = new List<clsItemParametro>();
            try {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_CLIENTES_TIPOS_RELACIONES");
                objParams[0].Value = IdCiente;

                SqlCommand command = new SqlCommand("SP_C_CLIENTES_TIPOS_RELACIONES", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read()) {
                    relacion = new clsItemParametro();
                    relacion.Id = Convert.ToInt64(dreader["Id"]);
                    relacion.Nombre = dreader["Descripcion"].ToString();
                    relacion.Codigo = dreader["CodParametro"].ToString();
                    relacion.TipoParam = (Entidades.Enums.Enums.TipoParametro)dreader["IdTipoParametro"];

                    listrelaciones.Add(relacion);
                }

            } catch (Exception ex) {
                Base.Log.Log.EscribirLog(ex.Message);
                resTransaccion.MetodoError = MethodBase.GetCurrentMethod().Name;
                resTransaccion.ArchivoError = MethodBase.GetCurrentMethod().ToString();
            } finally {
                conn.Close();
            }

            return listrelaciones;
        }

        public static IList<clsItemParametro> ObtenerTiposRelacionClienteMaster(Int64 IdCiente) {
            clsItemParametro relacion = null;
            IList<clsItemParametro> listrelaciones = new List<clsItemParametro>();
            try {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_CLIENTES_MASTER_TIPOS_RELACIONES");
                objParams[0].Value = IdCiente;

                SqlCommand command = new SqlCommand("SP_C_CLIENTES_MASTER_TIPOS_RELACIONES", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read()) {
                    relacion = new clsItemParametro();
                    relacion.Id = Convert.ToInt64(dreader["idTipoCliente"]);
                    relacion.Nombre = dreader["Tipo"].ToString();
                    relacion.Codigo = dreader["CodParametro"].ToString();
                    relacion.TipoParam = (Entidades.Enums.Enums.TipoParametro)dreader["IdTipoParametro"];

                    listrelaciones.Add(relacion);
                }

            } catch (Exception ex) {
                Base.Log.Log.EscribirLog(ex.Message);
                resTransaccion.MetodoError = MethodBase.GetCurrentMethod().Name;
                resTransaccion.ArchivoError = MethodBase.GetCurrentMethod().ToString();
            } finally {
                conn.Close();
            }

            return listrelaciones;
        }

        #endregion

        #region "Follow Up"

        public static ResultadoTransaccion AgregarFollowUpClienteMaster(clsClienteFollowUp FollowUp, SqlTransaction transaction) {
            resTransaccion = new ResultadoTransaccion();
            try {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_N_CLIENTES_FOLLOW_UP");
                objParams[0].Value = FollowUp.IdInformeVisita ?? -1;
                objParams[1].Value = FollowUp.IdLlamadaTelefonica ?? -1;
                objParams[2].Value = FollowUp.FechaFollowUp;
                if (FollowUp.TipoActividad == null)
                    objParams[3].Value = -1;
                else
                    objParams[3].Value = FollowUp.TipoActividad.Id;

                objParams[4].Value = FollowUp.Cliente.Id;
                objParams[5].Value = FollowUp.Descripcion;
                objParams[6].Value = DateTime.Now;
                objParams[7].Value = FollowUp.Usuario.Id;
                objParams[8].Value = FollowUp.IdTarget ?? -1;
                objParams[9].Value = FollowUp.Activo;
                objParams[10].Value = FollowUp.IdSalesLead ?? -1;

                SqlCommand command = new SqlCommand("SP_N_CLIENTES_FOLLOW_UP", BaseDatos.Conexion());
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;

            } catch (Exception ex) {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        public static ResultadoTransaccion ModificarFollowUpClienteMaster(clsClienteFollowUp FollowUp, SqlTransaction transaction) {
            resTransaccion = new ResultadoTransaccion();
            try {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_A_CLIENTES_FOLLOW_UP");
                objParams[0].Value = FollowUp.Id;
                objParams[1].Value = FollowUp.FechaFollowUp;
                if (FollowUp.TipoActividad == null)
                    objParams[2].Value = -1;
                else
                    objParams[2].Value = FollowUp.TipoActividad.Id;

                objParams[3].Value = FollowUp.Descripcion;
                objParams[4].Value = FollowUp.Activo;


                SqlCommand command = new SqlCommand("SP_A_CLIENTES_FOLLOW_UP", BaseDatos.Conexion());
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;

            } catch (Exception ex) {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        public static ResultadoTransaccion EliminarLogicoFollowUpClienteMaster(clsClienteFollowUp FollowUp, SqlTransaction transaction) {
            FollowUp.Activo = false;
            return ModificarFollowUpClienteMaster(FollowUp, transaction);
        }
        public static ResultadoTransaccion EliminarFollowUpClienteMaster(clsClienteFollowUp FollowUp, SqlTransaction transaction) {
            resTransaccion = new ResultadoTransaccion();
            try {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_E_CLIENTES_FOLLOW_UP");
                objParams[0].Value = FollowUp.Id32;

                SqlCommand command = new SqlCommand("SP_E_CLIENTES_FOLLOW_UP", BaseDatos.Conexion());
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;

            } catch (Exception ex) {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        public static IList<clsClienteFollowUp> ObtenerFollowUpCliente(Int64 IdCiente) {
            IList<clsClienteFollowUp> listado = new List<clsClienteFollowUp>();
            try {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_CLIENTES_FOLLOW_UP_POR_ID");
                objParams[0].Value = IdCiente;

                SqlCommand command = new SqlCommand("SP_C_CLIENTES_FOLLOW_UP_POR_ID", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();
                listado = ObtenerfollowUp(dreader);
            } catch (Exception ex) {
                Base.Log.Log.EscribirLog(ex.Message);
                resTransaccion.MetodoError = MethodBase.GetCurrentMethod().Name;
                resTransaccion.ArchivoError = MethodBase.GetCurrentMethod().ToString();
            } finally {
                conn.Close();
            }

            return listado;
        }
        public static IList<clsClienteFollowUp> ObtenerFollowUpActivosCliente(Int64 IdCiente) {
            var list = ObtenerFollowUpCliente(IdCiente);
            return ((List<clsClienteFollowUp>)list).FindAll(delegate(clsClienteFollowUp foo) { return foo.Activo; });
        }

        public static IList<clsClienteFollowUp> ObtenerFollowUpClientePorInforme(Int64 IdInforme) {
            IList<clsClienteFollowUp> followUps = new List<clsClienteFollowUp>();
            try {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_CLIENTES_FOLLOW_UP_POR_IDINFORME");
                objParams[0].Value = IdInforme;

                SqlCommand command = new SqlCommand("SP_C_CLIENTES_FOLLOW_UP_POR_IDINFORME", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();
                followUps = ObtenerfollowUp(dreader);
            } catch (Exception ex) {
                Base.Log.Log.EscribirLog(ex.Message);
                resTransaccion.MetodoError = MethodBase.GetCurrentMethod().Name;
                resTransaccion.ArchivoError = MethodBase.GetCurrentMethod().ToString();
            } finally {
                conn.Close();
            }
            return followUps;

        }
        public static IList<clsClienteFollowUp> ObtenerFollowUpActivosClientePorInforme(Int64 IdInforme) {
            var list = ObtenerFollowUpClientePorInforme(IdInforme);
            return ((List<clsClienteFollowUp>)list).FindAll(delegate(clsClienteFollowUp foo) { return foo.Activo; });
        }

        public static IList<clsClienteFollowUp> ObtenerFollowUpClientePorLlamada(long idLlamada) {
            return ObtenerFollowUpClientePorLlamada(idLlamada, BaseDatos.NuevaConexion());
        }
        public static IList<clsClienteFollowUp> ObtenerFollowUpActivosClientePorLlamada(long idLlamada) {
            var list = ObtenerFollowUpClientePorLlamada(idLlamada);
            return ((List<clsClienteFollowUp>)list).FindAll(delegate(clsClienteFollowUp foo) { return foo.Activo; });
        }
        public static IList<clsClienteFollowUp> ObtenerFollowUpClientePorSalesLead(long idSalesLead) {
            return ObtenerFollowUpClientePorSalesLead(idSalesLead, BaseDatos.NuevaConexion());
        }
        public static IList<clsClienteFollowUp> ObtenerFollowUpActivosClientePorLSalesLead(long idSalesLead) {
            var list = ObtenerFollowUpClientePorSalesLead(idSalesLead);
            return ((List<clsClienteFollowUp>)list).FindAll(delegate(clsClienteFollowUp foo) { return foo.Activo; });
        }


        public static IList<clsClienteFollowUp> ObtenerFollowUpClientePorTarget(long idTarget) {
            IList<clsClienteFollowUp> followUps = new List<clsClienteFollowUp>();
            try {
                conn = BaseDatos.NuevaConexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_CLIENTES_FOLLOW_UP_POR_IDTARGET");
                objParams[0].Value = idTarget;

                SqlCommand command = new SqlCommand("SP_C_CLIENTES_FOLLOW_UP_POR_IDTARGET", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();
                followUps = ObtenerfollowUp(dreader);

            } catch (Exception ex) {
                Base.Log.Log.EscribirLog(ex.Message);
                resTransaccion.MetodoError = MethodBase.GetCurrentMethod().Name;
                resTransaccion.ArchivoError = MethodBase.GetCurrentMethod().ToString();
            } finally {
                conn.Close();
            }

            return followUps;
        }
        public static IList<clsClienteFollowUp> ObtenerFollowUpActivosClientePorTarget(long idTarget) {
            var list = ObtenerFollowUpClientePorTarget(idTarget);
            return ((List<clsClienteFollowUp>)list).FindAll(delegate(clsClienteFollowUp foo) { return foo.Activo; });
        }


        public static IList<clsClienteFollowUp> ObtenerFollowUpClientePorLlamada(long idLlamada, SqlConnection conn) {
            IList<clsClienteFollowUp> followUps = new List<clsClienteFollowUp>();
            try {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_CLIENTES_FOLLOW_UP_POR_IDLLAMADA");
                objParams[0].Value = idLlamada;

                SqlCommand command = new SqlCommand("SP_C_CLIENTES_FOLLOW_UP_POR_IDLLAMADA", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();
                followUps = ObtenerfollowUp(dreader);

            } catch (Exception ex) {
                Base.Log.Log.EscribirLog(ex.Message);
                resTransaccion.MetodoError = MethodBase.GetCurrentMethod().Name;
                resTransaccion.ArchivoError = MethodBase.GetCurrentMethod().ToString();
            } finally {
                conn.Close();
            }

            return followUps;
        }
        public static IList<clsClienteFollowUp> ObtenerFollowUpActivosClientePorLlamada(long idLlamada, SqlConnection conn) {
            var list = ObtenerFollowUpClientePorLlamada(idLlamada, conn);
            return ((List<clsClienteFollowUp>)list).FindAll(delegate(clsClienteFollowUp foo) { return foo.Activo; });
        }


        public static IList<clsClienteFollowUp> ObtenerFollowUpClientePorSalesLead(long idSalesLead, SqlConnection conn) {
            IList<clsClienteFollowUp> followUps = new List<clsClienteFollowUp>();
            try {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "[SP_C_CLIENTES_FOLLOW_UP_POR_IDSLEAD]");
                objParams[0].Value = idSalesLead;

                SqlCommand command = new SqlCommand("[SP_C_CLIENTES_FOLLOW_UP_POR_IDSLEAD]", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();
                followUps = ObtenerfollowUp(dreader);

            } catch (Exception ex) {
                Base.Log.Log.EscribirLog(ex.Message);
                resTransaccion.MetodoError = MethodBase.GetCurrentMethod().Name;
                resTransaccion.ArchivoError = MethodBase.GetCurrentMethod().ToString();
            } finally {
                conn.Close();
            }

            return followUps;
        }
        public static IList<clsClienteFollowUp> ObtenerFollowUpActivosClientePorSalesLead(long idSalesLead, SqlConnection conn) {
            var list = ObtenerFollowUpClientePorSalesLead(idSalesLead, conn);
            return ((List<clsClienteFollowUp>)list).FindAll(delegate(clsClienteFollowUp foo) { return foo.Activo; });
        }

        private static IList<clsClienteFollowUp> ObtenerfollowUp(IDataReader dataReader) {
            var retorno = new List<clsClienteFollowUp>();
            while (dataReader.Read()) {
                var followup = new clsClienteFollowUp();
                followup.Id = Convert.ToInt64(dataReader["Id"]);
                followup.FechaFollowUp = Convert.ToDateTime(dataReader["FechaFollowUp"]);

                if (dataReader["IdActividad"] is DBNull) {
                    followup.TipoActividad = new clsTipoActividad();
                } else {
                    followup.TipoActividad.Id = Convert.ToInt64(dataReader["IdActividad"]);
                    followup.TipoActividad.Nombre = dataReader["Actividad"].ToString();
                    followup.TipoActividad.Alias = dataReader["Alias"].ToString();
                }


                followup.Descripcion = dataReader["Descripcion"].ToString();
                followup.FechaCreacion = Convert.ToDateTime(dataReader["FechaCreacion"]);
                followup.Usuario.Nombre = dataReader["Nombres"].ToString();
                followup.Usuario.ApellidoPaterno = dataReader["ApellidoPaterno"].ToString();
                followup.Usuario.ApellidoMaterno = dataReader["ApellidoMaterno"].ToString();

                if (!String.IsNullOrEmpty(dataReader["IdLlamadaTelefonica"].ToString()))
                    followup.IdLlamadaTelefonica = Convert.ToInt64(dataReader["IdLlamadaTelefonica"].ToString());

                if (!String.IsNullOrEmpty(dataReader["IdInformeVisita"].ToString()))
                    followup.IdInformeVisita = Convert.ToInt64(dataReader["IdInformeVisita"].ToString());

                if (!String.IsNullOrEmpty(dataReader["idtarget"].ToString()))
                    followup.IdTarget = Convert.ToInt64(dataReader["idtarget"].ToString());

                if (!String.IsNullOrEmpty(dataReader["activo"].ToString()))
                    followup.Activo = Convert.ToBoolean(dataReader["activo"].ToString());

                try {
                    if (!String.IsNullOrEmpty(dataReader["idSLead"].ToString()))
                        followup.IdSalesLead = Convert.ToInt64(dataReader["idSLead"].ToString());
                } catch (Exception e) {
                    Console.Write(e.Message);
                }

                retorno.Add(followup);
            }
            return retorno;

        }
        #endregion
    }
}