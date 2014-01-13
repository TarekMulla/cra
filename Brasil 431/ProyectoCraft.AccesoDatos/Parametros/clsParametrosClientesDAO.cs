using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Clientes.TargetAccount;

namespace ProyectoCraft.AccesoDatos.Parametros
{
    public static class clsParametrosClientesDAO
    {

        public static IList<clsIncoTerm> ListarIncoTerms(bool activo)
        {
            IList<clsIncoTerm> lista = new List<clsIncoTerm>();
            clsIncoTerm incoterm;

            SqlDataReader objReader = null;
            SqlParameter[] objParams;

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.GetConexion(), "SP_C_PARAMETROS_INCOTERMS");
                objParams[0].Value = activo;

                objReader = SqlHelper.ExecuteReader(BaseDatos.GetConexion(), "SP_C_PARAMETROS_INCOTERMS", objParams);
                while (objReader.Read())
                {
                    incoterm = new clsIncoTerm();
                    incoterm.Id = Convert.ToInt64(objReader["Id"]);
                    incoterm.Descripcion = objReader["Descripcion"].ToString();
                    incoterm.Codigo = objReader["Codigo"].ToString();
                    incoterm.Estado = Convert.ToBoolean(objReader["Estado"]);                    
                    lista.Add(incoterm);
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

        public static clsIncoTerm ObtenerIncoTermPorId(Int16 IdIncoTerm)
        {            
            clsIncoTerm incoterm = null;

            SqlDataReader objReader = null;
            SqlParameter[] objParams;

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.GetConexion(), "SP_C_TIPO_INCOTERM_PORID");
                objParams[0].Value = IdIncoTerm;

                objReader = SqlHelper.ExecuteReader(BaseDatos.GetConexion(), "SP_C_TIPO_INCOTERM_PORID", objParams);
                while (objReader.Read())
                {
                    incoterm = new clsIncoTerm();
                    incoterm.Id = Convert.ToInt64(objReader["Id"]);
                    incoterm.Descripcion = objReader["Descripcion"].ToString();
                    incoterm.Codigo = objReader["Codigo"].ToString();
                    incoterm.Estado = Convert.ToBoolean(objReader["Estado"]);                    
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
            return incoterm;
        }



        public static IList<clsTipoServicioComplementario> ListarServiciosComplementarios(bool activo)
        {
            IList<clsTipoServicioComplementario> lista = new List<clsTipoServicioComplementario>();
            clsTipoServicioComplementario servicio;

            SqlDataReader objReader = null;
            SqlParameter[] objParams;

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.GetConexion(), "SP_C_TIPO_SERVICIO_COMPLEMENTARIO");
                objParams[0].Value = activo;

                objReader = SqlHelper.ExecuteReader(BaseDatos.GetConexion(), "SP_C_TIPO_SERVICIO_COMPLEMENTARIO", objParams);
                while (objReader.Read())
                {
                    servicio = new clsTipoServicioComplementario();
                    servicio.Id = Convert.ToInt64(objReader["Id"]);
                    servicio.Nombre = objReader["Descripcion"].ToString();                    
                    servicio.Estado = Convert.ToBoolean(objReader["Estado"]);
                    servicio.FechaCreacion = Convert.ToDateTime(objReader["FechaCreacion"]);
                    lista.Add(servicio);
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

        public static clsTipoServicioComplementario ObtenerServicioComplementarioPorId(Int16 IdServicio)
        {
            clsTipoServicioComplementario servicio = null;

            SqlDataReader objReader = null;
            SqlParameter[] objParams;

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.GetConexion(), "SP_C_TIPO_SERVICIO_COMPLEMENTARIO_PORID");
                objParams[0].Value = IdServicio;

                objReader = SqlHelper.ExecuteReader(BaseDatos.GetConexion(), "SP_C_TIPO_SERVICIO_COMPLEMENTARIO_PORID", objParams);
                while (objReader.Read())
                {
                    servicio = new clsTipoServicioComplementario();
                    servicio.Id = Convert.ToInt64(objReader["Id"]);
                    servicio.Nombre = objReader["Descripcion"].ToString();                    
                    servicio.Estado = Convert.ToBoolean(objReader["Estado"]);
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
            return servicio;
        }




        public static IList<clsTipoObjeciones> ListarTipoObjeciones(bool activo)
        {
            IList<clsTipoObjeciones> lista = new List<clsTipoObjeciones>();
            clsTipoObjeciones objecion;

            SqlDataReader objReader = null;
            SqlParameter[] objParams;

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.GetConexion(), "SP_C_TIPO_OBJECIONES");
                objParams[0].Value = activo;

                objReader = SqlHelper.ExecuteReader(BaseDatos.GetConexion(), "SP_C_TIPO_OBJECIONES", objParams);
                while (objReader.Read())
                {
                    objecion = new clsTipoObjeciones();
                    objecion.Id = Convert.ToInt64(objReader["Id"]);
                    objecion.Nombre = objReader["Descripcion"].ToString();
                    objecion.Estado = Convert.ToBoolean(objReader["Estado"]);
                    objecion.FechaCreacion = Convert.ToDateTime(objReader["FechaCreacion"]);
                    lista.Add(objecion);
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

        public static clsTipoObjeciones ObtenerObjecionPorId(Int16 IdObjecion)
        {
            clsTipoObjeciones objecion = null;

            SqlDataReader objReader = null;
            SqlParameter[] objParams;

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.GetConexion(), "SP_C_TIPO_OBJECIONES_PORID");
                objParams[0].Value = IdObjecion;

                objReader = SqlHelper.ExecuteReader(BaseDatos.GetConexion(), "SP_C_TIPO_OBJECIONES_PORID", objParams);
                while (objReader.Read())
                {
                    objecion = new clsTipoObjeciones();
                    objecion.Id = Convert.ToInt64(objReader["Id"]);
                    objecion.Nombre = objReader["Descripcion"].ToString();
                    objecion.Estado = Convert.ToBoolean(objReader["Estado"]);
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
            return objecion;
        }


        //public static IList<clsTipoAccionesTomar> ListarTipoAccionTomar(bool activo)
        //{
        //    IList<clsTipoAccionesTomar> lista = new List<clsTipoAccionesTomar>();
        //    clsTipoAccionesTomar accion;

        //    SqlDataReader objReader = null;
        //    SqlParameter[] objParams;

        //    try
        //    {
        //        objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.GetConexion(), "SP_C_TIPO_ACCION_TOMAR");
        //        objParams[0].Value = activo;

        //        objReader = SqlHelper.ExecuteReader(BaseDatos.GetConexion(), "SP_C_TIPO_ACCION_TOMAR", objParams);
        //        while (objReader.Read())
        //        {
        //            accion = new clsTipoAccionesTomar();
        //            accion.Id = Convert.ToInt64(objReader["Id"]);
        //            accion.Nombre = objReader["Descripcion"].ToString();
        //            accion.Estado = Convert.ToBoolean(objReader["Estado"]);
        //            accion.FechaCreacion = Convert.ToDateTime(objReader["FechaCreacion"]);
        //            lista.Add(accion);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Base.Log.Log.EscribirLog(ex.Message);
        //        return null;

        //    }
        //    finally
        //    {
        //        if (objReader != null) objReader.Close();
        //    }
        //    return lista;
        //}

        //public static clsTipoAccionesTomar ObtenerAccionTomarPorId(Int16 IdAccion)
        //{
        //    clsTipoAccionesTomar accion = null;

        //    SqlDataReader objReader = null;
        //    SqlParameter[] objParams;

        //    try
        //    {
        //        objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.GetConexion(), "SP_C_TIPO_ACCION_TOMAR_PORID");
        //        objParams[0].Value = IdAccion;

        //        objReader = SqlHelper.ExecuteReader(BaseDatos.GetConexion(), "SP_C_TIPO_ACCION_TOMAR_PORID", objParams);
        //        while (objReader.Read())
        //        {
        //            accion = new clsTipoAccionesTomar();
        //            accion.Id = Convert.ToInt64(objReader["Id"]);
        //            accion.Nombre = objReader["Descripcion"].ToString();
        //            accion.Estado = Convert.ToBoolean(objReader["Estado"]);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Base.Log.Log.EscribirLog(ex.Message);
        //        return null;

        //    }
        //    finally
        //    {
        //        if (objReader != null) objReader.Close();
        //    }
        //    return accion;
        //}
    }
}
