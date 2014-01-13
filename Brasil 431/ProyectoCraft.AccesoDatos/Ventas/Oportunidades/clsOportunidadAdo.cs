using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Ventas.Oportunidades;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Base.BaseDatos;
using System.Data.SqlClient;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Base.Log;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using ProyectoCraft.Entidades.Enums;

namespace ProyectoCraft.AccesoDatos.Ventas.Oportunidades
{
    public class clsOportunidadAdo
    {
        private static SqlParameter[] objParams = null;
        private static SqlConnection conn = null;
        private static SqlTransaction transaction = null;
        private static SqlDataReader dreader = null;
        private static ResultadoTransaccion resTransaccion = null;

        public static ResultadoTransaccion ListarOportunidadesActividad(long IdActividad, int IdTipoActividad)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            IList<clsOportunidad> ListaOportunidades = new List<clsOportunidad>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Consultar Asuntos x Tipo Actividad
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "sp_c_ventas_oportunidades_actividad");
                objParams[0].Value = IdActividad;
                objParams[1].Value = IdTipoActividad;

                SqlCommand command = new SqlCommand("sp_c_ventas_oportunidades_actividad", conn);

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    clsOportunidad ObjOportunidad = new clsOportunidad();

                    ObjOportunidad.Id = Convert.ToInt32(dreader[0]);

                    ListaOportunidades.Add(ObjOportunidad);
                }
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = ListaOportunidades;
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsOportunidadAdo.cs";
                res.MetodoError = "Listar Oportunidades Actividad";
            }
            finally
            {
                conn.Close();
            }
            return res;
        }

        public static ResultadoTransaccion ListarOportunidadesPorCliente(Int64 IdCliente)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            IList<clsOportunidad> ListaOportunidades = new List<clsOportunidad>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Consultar Asuntos x Tipo Actividad
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "sp_c_ventas_oportunidad_cliente");
                objParams[0].Value = IdCliente;

                SqlCommand command = new SqlCommand("sp_c_ventas_oportunidad_cliente", conn);

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    clsOportunidad ObjOportunidad = new clsOportunidad();
                    ObjOportunidad.Id32 = Convert.ToInt32(dreader[0]);
                    ObjOportunidad.Codigo = dreader[1].ToString();
                    ObjOportunidad.Tema = dreader[2].ToString();
                    ObjOportunidad.IdVendedor = Convert.ToInt16(dreader[3]);
                    ObjOportunidad.IdCustomer = Convert.ToInt16(dreader[4]);
                    ObjOportunidad.Descripcion = dreader[5].ToString();

                    ListaOportunidades.Add(ObjOportunidad);
                }
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = ListaOportunidades;
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                resTransaccion.Descripcion = ex.Message;
                resTransaccion.ArchivoError = "clsOportunidadAdo.cs";
                resTransaccion.MetodoError = "Listar Oportunidades Por Cliente";
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
        public static ResultadoTransaccion EliminarActividadOportunidad(int IdTipoActividad, long IdOportunidad, long IdActividad)
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
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "sp_e_ventas_actividad_oportunidad");
                objParams[0].Value = IdOportunidad;
                objParams[1].Value = IdActividad;
                objParams[2].Value = IdTipoActividad;
                SqlCommand command = new SqlCommand("sp_e_ventas_actividad_oportunidad", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                id = Convert.ToInt32(command.ExecuteScalar());

                transaction.Commit();

                //Ejecutar transaccion
                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.Descripcion = "Se eliminó la Actividad con la Oportunidad";



            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                resTransaccion.Descripcion = ex.Message;
                resTransaccion.ArchivoError = "clsOportunidadAdo.cs";
                resTransaccion.MetodoError = "Eliminar Actividad Oportunidad";
            }
            finally
            {
                conn.Close();
            }
            return resTransaccion;
        }
        public static ResultadoTransaccion AgregarActividadOportunidad(int IdTipoActividad, long IdOportunidad, long IdActividad)
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
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "sp_n_ventas_actividad_oportunidad");
                objParams[0].Value = IdOportunidad;
                objParams[1].Value = IdActividad;
                objParams[2].Value = IdTipoActividad;
                SqlCommand command = new SqlCommand("sp_n_ventas_actividad_oportunidad", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                id = Convert.ToInt32(command.ExecuteScalar());

                transaction.Commit();

                //Ejecutar transaccion
                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.Descripcion = "Se registró la Actividad con la Oportunidad";



            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                resTransaccion.Descripcion = ex.Message;
                resTransaccion.ArchivoError = "clsOportunidadAdo.cs";
                resTransaccion.MetodoError = "Asociar Actividad Oportunidad";
            }
            finally
            {
                conn.Close();
            }
            return resTransaccion;
        }

    }
}
