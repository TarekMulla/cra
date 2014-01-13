using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Ventas.Actividades;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Base.BaseDatos;
using System.Data.SqlClient;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Base.Log;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using ProyectoCraft.Entidades.Enums;

namespace ProyectoCraft.AccesoDatos.Ventas.Actividades
{
    public class clsAsuntosTipoActividadAdo
    {
        private static SqlParameter[] objParams = null;
        private static SqlConnection conn = null;
        private static SqlTransaction transaction = null;
        private static SqlDataReader dreader = null;
        
        public static ResultadoTransaccion ListarAsuntosTipoActividad(int IdTipoActividad, string EntradaSalida)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            IList<clsAsuntoTipoActividad> ListaAsuntos = new List<clsAsuntoTipoActividad>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Consultar Asuntos x Tipo Actividad
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "sp_c_ventas_tipo_actividad_asunto");
                objParams[0].Value = IdTipoActividad ;
                objParams[1].Value = EntradaSalida;

                SqlCommand command = new SqlCommand("sp_c_ventas_tipo_actividad_asunto", conn);

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                 {
                    clsAsuntoTipoActividad AsuntoTipoActividad = new clsAsuntoTipoActividad ();
                    AsuntoTipoActividad.Id   = Convert.ToInt16(dreader[0]);
                    AsuntoTipoActividad.Nombre  = dreader[1].ToString();

                    ListaAsuntos.Add(AsuntoTipoActividad);
                 }
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = ListaAsuntos; 
            }   
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsAsuntosTipoActividadAdo.cs";
                res.MetodoError = "Listar Asuntos Tipo Actividad";
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
        public static ResultadoTransaccion ListarAsuntosActividad(long IdActividad)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            IList<clsAsuntoActividad> ListaAsuntosActividad = new List<clsAsuntoActividad>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Consultar Asuntos x Tipo Actividad
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_VENTAS_ASUNTO_ACTIVIDAD");
                objParams[0].Value = IdActividad;

                SqlCommand command = new SqlCommand("SP_C_VENTAS_ASUNTO_ACTIVIDAD", conn);

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    clsAsuntoActividad ObjAsuntoActividad = new clsAsuntoActividad();

                    ObjAsuntoActividad.Id = Convert.ToInt32(dreader[0]);

                    ObjAsuntoActividad.ObjAsuntoTipoActividad = new clsAsuntoTipoActividad();

                    ObjAsuntoActividad.ObjAsuntoTipoActividad.Id = Convert.ToInt32(dreader[1]);
                    ObjAsuntoActividad.ObjAsuntoTipoActividad.Nombre = dreader[2].ToString();

                    ListaAsuntosActividad.Add(ObjAsuntoActividad);
                }
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = ListaAsuntosActividad;
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsAsuntosTipoActividadAdo.cs";
                res.MetodoError = "Listar Asuntos de la Actividad";
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
        public static ResultadoTransaccion EliminarAsuntoActividad(long IdTipoAsunto, long IdActividad)
        {
            ResultadoTransaccion resTransaccion = new ResultadoTransaccion();
            long id;
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();
                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Agregar Actividad Oportunidad
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_E_VENTAS_TIPO_ASUNTO_ACTIVIDAD");
                objParams[0].Value = IdTipoAsunto;
                objParams[1].Value = IdActividad;
                SqlCommand command = new SqlCommand("SP_E_VENTAS_TIPO_ASUNTO_ACTIVIDAD", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                id = Convert.ToInt32(command.ExecuteScalar());

                transaction.Commit();

                //Ejecutar transaccion
                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.Descripcion = "Se eliminó el asunto de la actividad";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                resTransaccion.Descripcion = ex.Message;
                resTransaccion.ArchivoError = "clsAsuntosTipoActividadAdo.cs";
                resTransaccion.MetodoError = "Eliminar Asunto Actividad";
            }
            finally
            {
                conn.Close();
            }
            return resTransaccion;
        }
        public static ResultadoTransaccion AgregarAsuntoActividad(long IdTipoAsunto, long IdActividad)
        {
            ResultadoTransaccion resTransaccion = new ResultadoTransaccion();
            long id;
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();
                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Agregar Actividad Oportunidad
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_VENTAS_TIPO_ASUNTO_ACTIVIDAD");
                objParams[0].Value = IdTipoAsunto;
                objParams[1].Value = IdActividad;

                SqlCommand command = new SqlCommand("SP_N_VENTAS_TIPO_ASUNTO_ACTIVIDAD", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                id = Convert.ToInt32(command.ExecuteScalar());

                transaction.Commit();

                //Ejecutar transaccion
                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.Descripcion = "Se registró el asunto a la actividad";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                resTransaccion.Descripcion = ex.Message;
                resTransaccion.ArchivoError = "clsAsuntoActividadAdo.cs";
                resTransaccion.MetodoError = "Asociar Asunto Actividad";
            }
            finally
            {
                conn.Close();
            }
            return resTransaccion;
        }


        public static IList<clsTipoActividad> ListarTipoActividad()
        {
            IList<clsTipoActividad> ListaTipos = new List<clsTipoActividad>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Consultar Asuntos x Tipo Actividad
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_VENTAS_TIPO_ACTIVIDAD");                

                SqlCommand command = new SqlCommand("SP_C_VENTAS_TIPO_ACTIVIDAD", conn);
                
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    clsTipoActividad actividad = new clsTipoActividad();
                    actividad.Id = Convert.ToInt16(dreader["Id"]);
                    actividad.Nombre = dreader["Descripcion"].ToString();
                    actividad.Alias = dreader["Alias"].ToString();
                    actividad.Activo = dreader["Activo"].ToString();

                    ListaTipos.Add(actividad);
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
            return ListaTipos;
        }

        public static clsTipoActividad ObtenerTipoActividadPorId(Int16 IdActividad)
        {            
            clsTipoActividad Actividad = null;
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Consultar Asuntos x Tipo Actividad
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_VENTAS_TIPO_ACTIVIDAD_POR_ID");
                objParams[0].Value = IdActividad;

                SqlCommand command = new SqlCommand("SP_C_VENTAS_TIPO_ACTIVIDAD_POR_ID", conn);
                
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(objParams);
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    Actividad.Id = Convert.ToInt16(dreader["Id"]);
                    Actividad.Nombre = dreader["Descripcion"].ToString();
                    Actividad.Alias = dreader["Alias"].ToString();
                    Actividad.Activo = dreader["Activo"].ToString();                    
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
            return Actividad;

        }


    }
}
