using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.AccesoDatos.Clientes;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Clientes.Direcciones;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Log;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.LogicaNegocios.Mantenedores;

namespace ProyectoCraft.AccesoDatos.Parametros
{
    public static class ClsNavierasDAO
    {
        private static SqlParameter[] objParams = null;
        private static SqlConnection conn = null;
        private static SqlTransaction transaction = null;
        private static SqlDataReader dreader = null;
        private static ResultadoTransaccion resTransaccion = null;
        public static IList<ClsNaviera> ListarNavieras(bool activo)
        {
            IList<ClsNaviera> lista = new List<ClsNaviera>();
            ClsNaviera naviera;

            SqlDataReader objReader = null;
            SqlParameter[] objParams;

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.GetConexion(), "SP_L_PAPERLESS_NAVIERA");
                objParams[0].Value = activo;

                objReader = SqlHelper.ExecuteReader(BaseDatos.GetConexion(), "SP_L_PAPERLESS_NAVIERA", objParams);
                while (objReader.Read())
                {

                    naviera = new ClsNaviera();
                    naviera.Id = Convert.ToInt64(objReader["Id"]);
                    naviera.Nombre = objReader["Descripcion"].ToString();
                    naviera.Activo = Convert.ToBoolean(objReader["Activo"]);
                    //naviera.FechaCreacion = Convert.ToDateTime(objReader["FechaCreacion"]);
                    lista.Add(naviera);
                }
            }
            catch (Exception ex)
            {
                Base.Log.Log.EscribirLog(ex.Message);
                return null;

            }
            finally
            {
                if (objReader != null) objReader.Close();
            }
            return lista;
        }
        public static IList<ClsNaviera> ListarNavieras()
        {
            IList<ClsNaviera> lista = new List<ClsNaviera>();
            ClsNaviera naviera;

            SqlDataReader objReader = null;
            SqlParameter[] objParams;

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.GetConexion(), "SP_L_PAPERLESS_NAVIERAALL");


                objReader = SqlHelper.ExecuteReader(BaseDatos.GetConexion(), "SP_L_PAPERLESS_NAVIERAALL", objParams);
                while (objReader.Read())
                {

                    naviera = new ClsNaviera();
                    naviera.Id = Convert.ToInt64(objReader["Id"]);
                    naviera.Nombre = objReader["Descripcion"].ToString();
                    naviera.Activo = Convert.ToBoolean(objReader["Activo"]);
                    naviera.FechaCreacion = Convert.ToDateTime(objReader["FechaCreacion"]);
                    lista.Add(naviera);
                }
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);
                return null;

            }
            finally
            {
                if (objReader != null) objReader.Close();
            }
            return lista;
        }

        private static void CreaRelacionPuertos(Int64 id, string relacionPuertos, SqlConnection conn)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                //Abrir Conexion
                //conn = BaseDatos.Conexion();

                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Actualizar
                //objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_A_CLIENTES_DIRECCION");
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_NAVIERA_PUERTO_RELACION");
                objParams[0].Value = id;
                objParams[1].Value = relacionPuertos;

                SqlCommand command = new SqlCommand("SP_N_NAVIERA_PUERTO_RELACION", conn, transaction);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                transaction.Commit();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.Accion = Enums.AccionTransaccion.Actualizar;
                resTransaccion.ObjetoTransaccion = id;
                //resTransaccion.Descripcion = "Se actualizó la relación de la naviera con los puertos.";

                //Registrar Actividad
                //LogActividadUsuarios log = new LogActividadUsuarios(cuenta.GetType().ToString(), cuenta.Id, Enums.TipoActividadUsuario.Edito, Base.Usuario.UsuarioConectado.Usuario);
                //LogActividades.clsLogActividadUsuariosADO.GuardaActividad(log);

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
                //conn.Close();

            }

            //return resTransaccion;

        }

        public static ResultadoTransaccion NuevaNaviera(string nombre, string relacionPuertos)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                var Existe=0; 
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Actualizar
                //objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_A_CLIENTES_DIRECCION");
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_PAPERLESS_NAVIERAV2");
                objParams[0].Value = nombre;
                objParams[1].Value = 1;
                objParams[2].Direction = ParameterDirection.Output;

                SqlCommand command = new SqlCommand("SP_N_PAPERLESS_NAVIERAV2", conn, transaction);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                resTransaccion.ObjetoTransaccion = Convert.ToInt64(command.ExecuteScalar());
                //command.ExecuteNonQuery();

                transaction.Commit();
                
                // Variable de salida para determinar si el nombre de la naviera ya existia en la BD
                // NULL significa que es nuevo
                Existe = Convert.ToInt16(objParams[2].Value);
                if (Existe.Equals(0))
                {
                    resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                    resTransaccion.Accion = Enums.AccionTransaccion.Insertar;

                    var id = (Int64)resTransaccion.ObjetoTransaccion;
                    CreaRelacionPuertos(id, relacionPuertos, conn);
                    resTransaccion.Descripcion = "Se creó naviera '" + nombre + "'.";
                }
                //Significa que la glosa ya existia por lo tanto no la creò
                else
                {
                    resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                    resTransaccion.Accion = Enums.AccionTransaccion.Insertar;
                    resTransaccion.Descripcion = "Ya existe una naviera con el mismo Nombre, registro no fue insertado.";
                }
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

            }

            return resTransaccion;
        }

        public static ResultadoTransaccion ActualizarNaviera(Int64 id, string nombre, string relacionPuertos)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Actualizar
                //objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_A_CLIENTES_DIRECCION");
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_U_PAPERLESS_NAVIERA");
                objParams[0].Value = id;
                objParams[1].Value = nombre;

                SqlCommand command = new SqlCommand("SP_U_PAPERLESS_NAVIERA", conn, transaction);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                transaction.Commit();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.Accion = Enums.AccionTransaccion.Actualizar;
                resTransaccion.ObjetoTransaccion = id;
                //Registrar Actividad
                //LogActividadUsuarios log = new LogActividadUsuarios(cuenta.GetType().ToString(), cuenta.Id, Enums.TipoActividadUsuario.Edito, Base.Usuario.UsuarioConectado.Usuario);
                //LogActividades.clsLogActividadUsuariosADO.GuardaActividad(log);
                CreaRelacionPuertos(id, relacionPuertos, conn);
                resTransaccion.Descripcion = "Se actualizó naviera '" + nombre + "'.";
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

            }

            return resTransaccion;
        }

        public static ResultadoTransaccion EliminaNaviera(Int64 id, string nombre)
        {
            resTransaccion = new ResultadoTransaccion();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Actualizar
                //objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_A_CLIENTES_DIRECCION");
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_E_PAPERLESS_NAVIERA");
                objParams[0].Value = id;


                SqlCommand command = new SqlCommand("SP_E_PAPERLESS_NAVIERA", conn, transaction);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                transaction.Commit();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.Accion = Enums.AccionTransaccion.Eliminar;
                resTransaccion.ObjetoTransaccion = id;
                resTransaccion.Descripcion = "Se eliminó naviera '" + nombre + "'.";

                //Registrar Actividad
                //LogActividadUsuarios log = new LogActividadUsuarios(cuenta.GetType().ToString(), cuenta.Id, Enums.TipoActividadUsuario.Edito, Base.Usuario.UsuarioConectado.Usuario);
                //LogActividades.clsLogActividadUsuariosADO.GuardaActividad(log);

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

            }

            return resTransaccion;
        }
        public static IList<ClsNaviera> BuscarNavieraPorTextoLike(string Naviera)
        {
            IList<ClsNaviera> lista = new List<ClsNaviera>();
            ClsNaviera naviera;

            SqlDataReader objReader = null;
            SqlParameter[] objParams;

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.GetConexion(), "SP_L_PAPERLESS_NAVIERA_POR_LIKE");
                objParams[0].Value = Naviera;
                objReader = SqlHelper.ExecuteReader(BaseDatos.GetConexion(), "SP_L_PAPERLESS_NAVIERA_POR_LIKE", objParams);
                
                while (objReader.Read())
                {
                    naviera = new ClsNaviera();
                    naviera.Id = Convert.ToInt64(objReader["Id"]);
                    naviera.Nombre = objReader["Descripcion"].ToString();
                    naviera.Activo = Convert.ToBoolean(objReader["Activo"]);
                    naviera.FechaCreacion = Convert.ToDateTime(objReader["FechaCreacion"]);
                    lista.Add(naviera);
                }
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);
                return null;

            }
            finally
            {
                if (objReader != null) objReader.Close();
            }
            return lista;
        }
    }
}
