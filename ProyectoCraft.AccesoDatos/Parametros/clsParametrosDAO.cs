using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Tarifado;
using System.Data.SqlClient;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Ventas.Productos;

namespace ProyectoCraft.AccesoDatos.Parametros {
    public static class clsParametrosDAO {

        private static SqlParameter[] objParams = null;
        private static SqlConnection conn = null;
        private static SqlTransaction transaction = null;
        private static SqlDataReader dreader = null;
        private static ResultadoTransaccion resTransaccion = null;

        public static clsParametrosInfo ListarParametrosPorTipo(Enums.TipoParametro Parametro) {
            clsParametrosInfo paramInfo = new clsParametrosInfo();

            SqlDataReader objReader = null;
            SqlParameter[] objParams;

            try {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.GetConexion(), "SP_C_PARAM_PARAMETROS_POR_TIPO");
                objParams[0].Value = (int)Parametro;

                objReader = SqlHelper.ExecuteReader(BaseDatos.GetConexion(), "SP_C_PARAM_PARAMETROS_POR_TIPO", objParams);
                while (objReader.Read()) {
                    paramInfo.AddItem(AgregarItemLista(objReader, Parametro));
                }
            } catch (Exception ex) {
                Base.Log.Log.EscribirLog(ex.Message);
                return null;

            } finally {
                if (objReader != null) objReader.Close();
            }
            return paramInfo;
        }

        public static clsItemParametro BuscarParametroPorId(Int16 idParam) {
            clsItemParametro parametro = new clsItemParametro();

            SqlDataReader objReader = null;
            SqlParameter[] objParams;
            SqlConnection conn = null;

            try {
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_PARAM_BUSCA_PARAMETRO_POR_ID");
                objParams[0].Value = (int)idParam;

                DataSet ds = SqlHelper.ExecuteDataset(conn, "SP_C_PARAM_BUSCA_PARAMETRO_POR_ID", objParams);
                if (ds != null) {
                    parametro = new clsItemParametro();
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) {
                        parametro.Id = Convert.ToInt64(ds.Tables[0].Rows[0]["Id"]);
                        parametro.Nombre = ds.Tables[0].Rows[0]["Descripcion"].ToString();
                        parametro.Codigo = ds.Tables[0].Rows[0]["CodParametro"].ToString();
                    }
                }


                //objReader = SqlHelper.ExecuteReader(BaseDatos.GetConexion(), "SP_C_PARAM_BUSCA_PARAMETRO_POR_ID", objParams);
                //while (objReader.Read())
                //{                    
                //    parametro = AgregarItemLista(objReader,Enums.TipoParametro.Any);
                //}
            } catch (Exception ex) {
                Base.Log.Log.EscribirLog(ex.Message);
                return null;

            } finally {
                if (objReader != null) objReader.Close();
                conn.Close();
            }
            return parametro;
        }

        private static clsItemParametro AgregarItemLista(SqlDataReader objReader, Enums.TipoParametro parametro) {
            clsItemParametro item = new clsItemParametro();
            item.Id = Convert.ToInt64(objReader["Id"]);
            item.Nombre = objReader["Descripcion"] == DBNull.Value ? "" : objReader["Descripcion"].ToString();
            item.Codigo = objReader["CodParametro"] == DBNull.Value ? "" : objReader["CodParametro"].ToString();

            return item;
        }

        public static IList<clsTipoMoneda> ListarMonedas() {
            IList<clsTipoMoneda> lista = new List<clsTipoMoneda>();
            SqlDataReader objReader = null;
            SqlParameter[] objParams;

            try {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.GetConexion(), "SP_C_TARIFAS_MONEDAS");
                objReader = SqlHelper.ExecuteReader(BaseDatos.GetConexion(), "SP_C_TARIFAS_MONEDAS", objParams);
                while (objReader.Read()) {
                    clsTipoMoneda moneda = new clsTipoMoneda();
                    moneda.Id = Convert.ToInt64(objReader["Id"]);
                    moneda.Codigo = objReader["Codigo"].ToString();
                    moneda.Descripcion = objReader["Descripcion"].ToString();
                    lista.Add(moneda);
                }
            } catch (Exception ex) {
                Base.Log.Log.EscribirLog(ex.Message);
                return null;

            } finally {
                if (objReader != null) objReader.Close();
            }
            return lista;
        }

        public static clsTipoMoneda BuscarMonedaPorId(Int16 IdMoneda) {
            SqlDataReader objReader = null;
            SqlParameter[] objParams;
            clsTipoMoneda moneda = new clsTipoMoneda();
            SqlConnection conn = null;
            try {
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_TARIFAS_BUSCAR_MONEDA_POR_ID");
                objParams[0].Value = (int)IdMoneda;

                DataSet ds = SqlHelper.ExecuteDataset(conn, "SP_C_TARIFAS_BUSCAR_MONEDA_POR_ID", objParams);
                if (ds != null) {
                    moneda.Id = Convert.ToInt64(ds.Tables[0].Rows[0]["Id"]);
                    moneda.Descripcion = ds.Tables[0].Rows[0]["Descripcion"].ToString();
                    moneda.Codigo = ds.Tables[0].Rows[0]["Codigo"].ToString();
                }


                //objReader = SqlHelper.ExecuteReader(BaseDatos.GetConexion(), "SP_C_TARIFAS_BUSCAR_MONEDA_POR_ID", objParams);
                //while (objReader.Read())
                //{
                //    moneda = new clsTipoMoneda();
                //    moneda.Id = Convert.ToInt64(objReader["Id"]);
                //    moneda.Codigo = objReader["Codigo"].ToString();
                //    moneda.Descripcion = objReader["Descripcion"].ToString();

                //}
            } catch (Exception ex) {
                Base.Log.Log.EscribirLog(ex.Message);
                return null;

            } finally {
                if (objReader != null) objReader.Close();
                conn.Close();
            }
            return moneda;
        }

        public static IList<clsTipoProducto> ListarProductos(string Activo) {
            IList<clsTipoProducto> lista = new List<clsTipoProducto>();
            SqlDataReader objReader = null;
            SqlParameter[] objParams;

            try {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.GetConexion(), "SP_C_VENTAS_PRODUCTOS_POR_ESTADO");
                objParams[0].Value = Activo;
                objReader = SqlHelper.ExecuteReader(BaseDatos.GetConexion(), "SP_C_VENTAS_PRODUCTOS_POR_ESTADO", objParams);
                while (objReader.Read()) {
                    clsTipoProducto producto = new clsTipoProducto();
                    producto.Id = Convert.ToInt64(objReader["Id"]);
                    producto.Nombre = objReader["Descripcion"].ToString();
                    producto.ExpoImpo = objReader["ExpoImpo"].ToString();
                    producto.Activo = objReader["Activo"].ToString();
                    lista.Add(producto);
                }
            } catch (Exception ex) {
                Base.Log.Log.EscribirLog(ex.Message);
                return null;

            } finally {
                if (objReader != null) objReader.Close();
            }
            return lista;
        }

        public static ResultadoTransaccion ActualizaParametroPorId(clsItemParametro item) {
            var Res = new ResultadoTransaccion();
            SqlTransaction trans = null;
            //Abrir Conexion
            var conn = BaseDatos.Conexion();
            try {
                var command = new SqlCommand("SP_A_PARAM_PARAMETROS_POR_ID", conn);

                command.Transaction = conn.BeginTransaction();
                trans = command.Transaction;

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", item.Id32);
                command.Parameters.AddWithValue("@descripcion", item.Nombre);

                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteScalar();

                //Ejecutar transaccion
                trans.Commit();
                Res.Estado = Enums.EstadoTransaccion.Aceptada;
                Res.Descripcion = "Se modificó la cotización correctamente";
            } catch (Exception ex) {
                if (trans != null)
                    trans.Rollback();
                Log.EscribirLog(ex.Message);
                Res.Descripcion = ex.Message;
                Res.ArchivoError = "clsParametrosDAO";
                Res.MetodoError = MethodBase.GetCurrentMethod().Name;
            } finally {
                conn.Close();
            }
            return Res;
        }

        #region "Direcciones"

        public static IList<clsPais> ListarPaises() {
            IList<clsPais> lista = new List<clsPais>();
            SqlDataReader objReader = null;

            try {
                objReader = SqlHelper.ExecuteReader(BaseDatos.Conexion(), "SP_C_ListarPaises");
                while (objReader.Read()) {
                    clsPais pais = new clsPais();
                    pais.Id = Convert.ToInt64(objReader["Id"]);
                    pais.Nombre = objReader["Descripcion"].ToString();
                    lista.Add(pais);
                }
            } catch (Exception ex) {
                Base.Log.Log.EscribirLog(ex.Message);
                return null;

            } finally {
                if (objReader != null) objReader.Close();
                BaseDatos.CerrarConexion();

            }
            return lista;
        }

        public static IList<clsCiudad> ListarCiudades(Int64 idPais) {
            IList<clsCiudad> lista = new List<clsCiudad>();
            SqlDataReader objReader = null;
            SqlParameter[] objParams;
            try {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.GetConexion(), "SP_C_PARAM_LISTAR_CIUDADES");
                objParams[0].Value = idPais;
                objReader = SqlHelper.ExecuteReader(BaseDatos.Conexion(), "SP_C_PARAM_LISTAR_CIUDADES", objParams);
                while (objReader.Read()) {
                    clsCiudad ciudad = new clsCiudad();
                    ciudad.Id = Convert.ToInt64(objReader["Id"]);
                    ciudad.Nombre = objReader["Ciudad"].ToString();
                    ciudad.Pais = new clsPais();
                    ciudad.Pais.Id = Convert.ToInt64(objReader["IdPais"]);
                    ciudad.Pais.Nombre = objReader["Pais"].ToString();
                    lista.Add(ciudad);
                }
            } catch (Exception ex) {
                Base.Log.Log.EscribirLog(ex.Message);
                return null;

            } finally {
                if (objReader != null) objReader.Close();
                BaseDatos.CerrarConexion();

            }
            return lista;
        }

        public static IList<clsComuna> ListarComunasPorLike(string Ciudad)
        {
            IList<clsComuna> lista = new List<clsComuna>();
            SqlDataReader objReader = null;
            SqlParameter[] objParams;
            try {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.GetConexion(), "SP_C_PARAM_LISTAR_COMUNAS_POR_LIKE");
                objParams[0].Value = Ciudad;
                objReader = SqlHelper.ExecuteReader(BaseDatos.Conexion(), "SP_C_PARAM_LISTAR_COMUNAS_POR_LIKE", objParams);
                while (objReader.Read()) {
                    clsComuna comuna = new clsComuna();
                    comuna.Id = Convert.ToInt64(objReader["Id"]);
                    comuna.Nombre = objReader["Comuna"].ToString();
                    comuna.Ciudad = new clsCiudad();
                    comuna.Ciudad.Id = Convert.ToInt64(objReader["IdCiudad"]);
                    comuna.Ciudad.Nombre = objReader["Ciudad"].ToString();
                    comuna.Ciudad.Pais = new clsPais();
                    comuna.Ciudad.Pais.Id = Convert.ToInt64(objReader["IdPais"]);
                    comuna.Ciudad.Pais.Nombre = objReader["Pais"].ToString();
                    lista.Add(comuna);
                }
            } catch (Exception ex) {
                Base.Log.Log.EscribirLog(ex.Message);
                return null;

            } finally {
                if (objReader != null) objReader.Close();
                BaseDatos.CerrarConexion();

            }
            return lista;
        }

        public static IList<clsComuna> ListarComunas(Int64 idCiudad) {
            IList<clsComuna> lista = new List<clsComuna>();
            SqlDataReader objReader = null;
            SqlParameter[] objParams;
            try {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.GetConexion(), "SP_C_PARAM_LISTAR_COMUNAS");
                objParams[0].Value = idCiudad;
                objReader = SqlHelper.ExecuteReader(BaseDatos.Conexion(), "SP_C_PARAM_LISTAR_COMUNAS", objParams);
                while (objReader.Read()) {
                    clsComuna comuna = new clsComuna();
                    comuna.Id = Convert.ToInt64(objReader["Id"]);
                    comuna.Nombre = objReader["Comuna"].ToString();
                    comuna.Ciudad = new clsCiudad();
                    comuna.Ciudad.Id = Convert.ToInt64(objReader["IdCiudad"]);
                    comuna.Ciudad.Nombre = objReader["Ciudad"].ToString();
                    comuna.Ciudad.Pais = new clsPais();
                    comuna.Ciudad.Pais.Id = Convert.ToInt64(objReader["IdPais"]);
                    comuna.Ciudad.Pais.Nombre = objReader["Pais"].ToString();
                    lista.Add(comuna);
                }
            } catch (Exception ex) {
                Base.Log.Log.EscribirLog(ex.Message);
                return null;

            } finally {
                if (objReader != null) objReader.Close();
                BaseDatos.CerrarConexion();

            }
            return lista;
        }

        public static ResultadoTransaccion CrearComuna(Int64 idCiudad, string comuna, string pais) {
            try {
                resTransaccion = new ResultadoTransaccion();
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Actualizar

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_PARAM_COMUNA");
                objParams[0].Value = idCiudad;
                objParams[1].Value = comuna;

                SqlCommand command = new SqlCommand("SP_N_PARAM_COMUNA", conn, transaction);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                resTransaccion.ObjetoTransaccion = Convert.ToInt64(command.ExecuteScalar());
                //command.ExecuteNonQuery();

                transaction.Commit();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.Accion = Enums.AccionTransaccion.Insertar;

                resTransaccion.Descripcion = "Se Creo Comuna con Id " + (Int64)resTransaccion.ObjetoTransaccion;

                //Registrar Actividad
                //LogActividadUsuarios log = new LogActividadUsuarios(cuenta.GetType().ToString(), cuenta.Id, Enums.TipoActividadUsuario.Edito, Base.Usuario.UsuarioConectado.Usuario);
                //LogActividades.clsLogActividadUsuariosADO.GuardaActividad(log);
            } catch (Exception ex) {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
            } finally {
                conn.Close();

            }

            return resTransaccion;
        }

        public static ResultadoTransaccion Actualizarcomuna(Int64 IdCiudad, Int64 IdRegion, string Descripcion) {
            resTransaccion = new ResultadoTransaccion();
            try {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Actualizar               
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_U_PARAM_COMUNA");
                objParams[0].Value = IdCiudad;//comuna
                objParams[1].Value = IdRegion;
                objParams[2].Value = Descripcion;

                SqlCommand command = new SqlCommand("SP_U_PARAM_COMUNA", conn, transaction);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                transaction.Commit();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.Accion = Enums.AccionTransaccion.Actualizar;
                resTransaccion.ObjetoTransaccion = IdCiudad;
                resTransaccion.Descripcion = "Se actualizo la Comuna con Id " + IdCiudad.ToString();

                //Registrar Actividad
                //LogActividadUsuarios log = new LogActividadUsuarios(cuenta.GetType().ToString(), cuenta.Id, Enums.TipoActividadUsuario.Edito, Base.Usuario.UsuarioConectado.Usuario);
                //LogActividades.clsLogActividadUsuariosADO.GuardaActividad(log);

            } catch (Exception ex) {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
            } finally {
                conn.Close();

            }

            return resTransaccion;
        }

        #endregion


    }
}
