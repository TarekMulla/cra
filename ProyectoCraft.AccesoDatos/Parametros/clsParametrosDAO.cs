using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Tarifado;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Ventas.Productos;

namespace ProyectoCraft.AccesoDatos.Parametros
{
    public static class clsParametrosDAO
    {                        
        public static clsParametrosInfo ListarParametrosPorTipo(Enums.TipoParametro Parametro)
        {
            clsParametrosInfo paramInfo = new clsParametrosInfo();

            SqlDataReader objReader = null;
            SqlParameter[] objParams;
            
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.GetConexion(), "SP_C_PARAM_PARAMETROS_POR_TIPO");
                objParams[0].Value = (int)Parametro;

                objReader = SqlHelper.ExecuteReader(BaseDatos.GetConexion(), "SP_C_PARAM_PARAMETROS_POR_TIPO", objParams);
                while (objReader.Read())
                {
                    paramInfo.AddItem(AgregarItemLista(objReader,Parametro));
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
            return paramInfo;
        }

        public static clsItemParametro BuscarParametroPorId(Int16 idParam)
        {
            clsItemParametro parametro = new clsItemParametro();

            SqlDataReader objReader = null;
            SqlParameter[] objParams;
            SqlConnection conn = null;

            try
            {
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_PARAM_BUSCA_PARAMETRO_POR_ID");
                objParams[0].Value = (int)idParam;

                DataSet ds = SqlHelper.ExecuteDataset(conn, "SP_C_PARAM_BUSCA_PARAMETRO_POR_ID", objParams);
                if (ds != null)
                {
                    parametro = new clsItemParametro();
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count >0) {
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
            }
            catch (Exception ex)
            {
                Base.Log.Log.EscribirLog(ex.Message);
                return null;

            }
            finally
            {
                if (objReader != null) objReader.Close();
                 conn.Close();
            }
            return parametro;
        }

        private static clsItemParametro AgregarItemLista(SqlDataReader objReader, Enums.TipoParametro parametro)
        {
            clsItemParametro item = new clsItemParametro();
            item.Id = Convert.ToInt64(objReader["Id"]);
            item.Nombre = objReader["Descripcion"] == DBNull.Value ? "" : objReader["Descripcion"].ToString();
            item.Codigo = objReader["CodParametro"] == DBNull.Value ? "" : objReader["CodParametro"].ToString();

            return item;           
        }

        public static IList<clsTipoMoneda> ListarMonedas()
        {
            IList<clsTipoMoneda> lista = new  List<clsTipoMoneda>();
            SqlDataReader objReader = null;
            SqlParameter[] objParams;

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.GetConexion(), "SP_C_TARIFAS_MONEDAS");
                objReader = SqlHelper.ExecuteReader(BaseDatos.GetConexion(), "SP_C_TARIFAS_MONEDAS", objParams);
                while (objReader.Read())
                {
                    clsTipoMoneda moneda = new clsTipoMoneda();
                    moneda.Id = Convert.ToInt64(objReader["Id"]);
                    moneda.Codigo = objReader["Codigo"].ToString();
                    moneda.Descripcion = objReader["Descripcion"].ToString();
                    lista.Add(moneda);
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

        public static clsTipoMoneda BuscarMonedaPorId(Int16 IdMoneda)
        {            
            SqlDataReader objReader = null;
            SqlParameter[] objParams;
            clsTipoMoneda moneda = new clsTipoMoneda();
            SqlConnection conn = null;
            try
            {
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_TARIFAS_BUSCAR_MONEDA_POR_ID");
                objParams[0].Value = (int)IdMoneda;

                DataSet ds = SqlHelper.ExecuteDataset(conn, "SP_C_TARIFAS_BUSCAR_MONEDA_POR_ID", objParams);
                if (ds != null)
                {
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
            }
            catch (Exception ex)
            {
                Base.Log.Log.EscribirLog(ex.Message);
                return null;

            }
            finally
            {
                if (objReader != null) objReader.Close();
                conn.Close();
            }
            return moneda;
        }

        public static IList<clsTipoProducto> ListarProductos(string Activo)
        {
            IList<clsTipoProducto> lista = new List<clsTipoProducto>();
            SqlDataReader objReader = null;
            SqlParameter[] objParams;

            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.GetConexion(), "SP_C_VENTAS_PRODUCTOS_POR_ESTADO");
                objParams[0].Value = Activo;
                objReader = SqlHelper.ExecuteReader(BaseDatos.GetConexion(), "SP_C_VENTAS_PRODUCTOS_POR_ESTADO", objParams);
                while (objReader.Read())
                {
                    clsTipoProducto producto = new clsTipoProducto();
                    producto.Id = Convert.ToInt64(objReader["Id"]);                    
                    producto.Nombre = objReader["Descripcion"].ToString();
                    producto.ExpoImpo = objReader["ExpoImpo"].ToString();
                    producto.Activo = objReader["Activo"].ToString();
                    lista.Add(producto);
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

        #region "Direcciones"

        public static IList<clsPais> ListarPaises()
        {
            IList<clsPais> lista = new List<clsPais>();
            SqlDataReader objReader = null;            

            try
            {
                objReader = SqlHelper.ExecuteReader(BaseDatos.Conexion(), "SP_C_ListarPaises");
                while (objReader.Read())
                {
                    clsPais pais = new clsPais();
                    pais.Id = Convert.ToInt64(objReader["Id"]);                    
                    pais.Nombre = objReader["Descripcion"].ToString();
                    lista.Add(pais);
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
                BaseDatos.CerrarConexion();
                
            }
            return lista;
        }

        public static IList<clsCiudad> ListarCiudades(Int64 idPais)
        {
            IList<clsCiudad> lista = new List<clsCiudad>();
            SqlDataReader objReader = null;
            SqlParameter[] objParams;
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.GetConexion(), "SP_C_PARAM_LISTAR_CIUDADES");
                objParams[0].Value = idPais;
                objReader = SqlHelper.ExecuteReader(BaseDatos.Conexion(), "SP_C_PARAM_LISTAR_CIUDADES",objParams);
                while (objReader.Read())
                {
                    clsCiudad ciudad = new clsCiudad();
                    ciudad.Id = Convert.ToInt64(objReader["Id"]);
                    ciudad.Nombre = objReader["Ciudad"].ToString();
                    ciudad.Pais = new clsPais();
                    ciudad.Pais.Id = Convert.ToInt64(objReader["IdPais"]);
                    ciudad.Pais.Nombre = objReader["Pais"].ToString();
                    lista.Add(ciudad);
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
                BaseDatos.CerrarConexion();

            }
            return lista;
        }

        public static IList<clsComuna> ListarComunas(Int64 idCiudad)
        {
            IList<clsComuna> lista = new List<clsComuna>();
            SqlDataReader objReader = null;
            SqlParameter[] objParams;
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.GetConexion(), "SP_C_PARAM_LISTAR_COMUNAS");
                objParams[0].Value = idCiudad;
                objReader = SqlHelper.ExecuteReader(BaseDatos.Conexion(), "SP_C_PARAM_LISTAR_COMUNAS",objParams);
                while (objReader.Read())
                {
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
            }
            catch (Exception ex)
            {
                Base.Log.Log.EscribirLog(ex.Message);
                return null;

            }
            finally
            {
                if (objReader != null) objReader.Close();
                BaseDatos.CerrarConexion();

            }
            return lista;
        }


        #endregion


    }
}
