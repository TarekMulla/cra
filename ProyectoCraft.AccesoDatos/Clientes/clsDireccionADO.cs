using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Entidades.Clientes.Direcciones;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Base;
using ProyectoCraft.Entidades.GlobalObject;
using System.Collections;

namespace ProyectoCraft.AccesoDatos.Clientes
{
    public static class clsDireccionADO
    {
        private static SqlParameter[] objParams = null;                
        private static SqlDataReader dreader = null;
        

        
        public static ResultadoTransaccion GuardarDirecciones(clsDireccionInfo DireccionInfo, SqlConnection conn, SqlTransaction transaction)
        {
            ResultadoTransaccion resTransaccionItems = new ResultadoTransaccion();
            ResultadoTransaccion resTransaccionSalida = new ResultadoTransaccion();
            
            try
            {
                if(DireccionInfo == null) return new ResultadoTransaccion("",Enums.EstadoTransaccion.Aceptada,"","");

                if(DireccionInfo.IdInfo == 0 && DireccionInfo.Items.Count > 0)
                {
                    resTransaccionItems = GenerarDireccionInfo(transaction);
                    if (resTransaccionItems.Estado == Enums.EstadoTransaccion.Aceptada)
                    {
                        DireccionInfo.IdInfo = (Int64)resTransaccionItems.ObjetoTransaccion;
                    }
                    else
                        throw new Exception(resTransaccionItems.Descripcion);
                }
                                
                foreach (clsDireccion direccion in DireccionInfo.Items)
                {                    
                    if(direccion.IsNew && direccion.IsDeleted == false)
                    {
                        direccion.IdDireccionInfo = DireccionInfo.IdInfo;
                        resTransaccionItems = CrearDireccion(direccion, transaction);
                        direccion.Id = (Int64)resTransaccionItems.ObjetoTransaccion;

                        if (resTransaccionItems.Estado == Enums.EstadoTransaccion.Rechazada)
                        {
                            throw new Exception(resTransaccionItems.Descripcion);
                        }                    
                    }   
                    else if(!direccion.IsNew && direccion.IsDeleted == false)
                    {
                        resTransaccionItems = ActualizarDireccion(direccion, transaction);
                        if (resTransaccionItems.Estado == Enums.EstadoTransaccion.Rechazada)
                        {
                            throw new Exception(resTransaccionItems.Descripcion);
                        }                    
                    }
                    else if(direccion.IsDeleted)
                    {
                        resTransaccionSalida = EliminarDireccion(direccion, transaction);
                        if (resTransaccionItems.Estado == Enums.EstadoTransaccion.Rechazada)
                        {
                            throw new Exception(resTransaccionItems.Descripcion);
                        }  
                    }
                }                

                resTransaccionSalida.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccionSalida.ObjetoTransaccion = DireccionInfo;

            }
            catch (Exception ex)
            {               
                resTransaccionSalida.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccionSalida.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            
            return resTransaccionSalida;
        }

        private static ResultadoTransaccion GenerarDireccionInfo(SqlTransaction transaction)
        {
            ResultadoTransaccion resTransaccion = new ResultadoTransaccion();
            Int64 idInfo = 0;
            try
            {
                SqlCommand command = new SqlCommand("SP_N_CLIENTES_DIRECCION_INFO", BaseDatos.Conexion());
                command.Transaction = transaction;                
                command.CommandType = CommandType.StoredProcedure;
                idInfo = Convert.ToInt64(command.ExecuteScalar());

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.ObjetoTransaccion = idInfo;
            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);                
            }
            return resTransaccion;
        }

        private static ResultadoTransaccion CrearDireccion(clsDireccion direccion, SqlTransaction transaction)
        {
            ResultadoTransaccion resTransaccion = new ResultadoTransaccion();
            Int64 idDireccion = 0;
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_N_CLIENTES_DIRECCION");
                objParams[0].Value = direccion.IdDireccionInfo;
                objParams[1].Value = direccion.TipoDireccion.Id;
                objParams[2].Value = direccion.NombreDireccion;
                objParams[3].Value = direccion.Numero;
                objParams[4].Value = direccion.OficinaDpto;
                objParams[5].Value = direccion.Block;
                objParams[6].Value = direccion.Comuna.Id;
                objParams[7].Value = direccion.Ciudad.Id;
                objParams[8].Value = direccion.Pais.Id;
                objParams[9].Value = direccion.Sector.Id;
                objParams[10].Value = direccion.DestinoDireccion.Id;

                SqlCommand command = new SqlCommand("SP_N_CLIENTES_DIRECCION", BaseDatos.Conexion());
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                idDireccion = Convert.ToInt64(command.ExecuteScalar());

                resTransaccion.ObjetoTransaccion = (Int64) idDireccion;
                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;                

            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        private static ResultadoTransaccion ActualizarDireccion(clsDireccion direccion, SqlTransaction transaction)
        {
            ResultadoTransaccion resTransaccion = new ResultadoTransaccion();
            Int64 idDireccion = 0;
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_A_CLIENTES_DIRECCION");
                objParams[0].Value = direccion.Id;
                objParams[1].Value = direccion.TipoDireccion.Id;
                objParams[2].Value = direccion.NombreDireccion;
                objParams[3].Value = direccion.Numero;
                objParams[4].Value = direccion.OficinaDpto;
                objParams[5].Value = direccion.Block;
                objParams[6].Value = direccion.Comuna.Id;
                objParams[7].Value = direccion.Ciudad.Id;
                objParams[8].Value = direccion.Pais.Id;
                if(direccion.Pais == null)
                    objParams[9].Value = -1;
                else
                    objParams[9].Value = direccion.Sector.Id;

                objParams[10].Value = direccion.DestinoDireccion.Id;

                SqlCommand command = new SqlCommand("SP_A_CLIENTES_DIRECCION", BaseDatos.Conexion());
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                resTransaccion.ObjetoTransaccion = (Int64)idDireccion;
                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        public static ResultadoTransaccion EliminarDireccionInfo(Int64 IdInfo, SqlTransaction transaction)
        {
            ResultadoTransaccion resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_E_CLIENTES_DIRECCION_INFO");
                objParams[0].Value = IdInfo;

                SqlCommand command = new SqlCommand("SP_E_CLIENTES_DIRECCION_INFO", BaseDatos.Conexion());
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = transaction;
                command.ExecuteNonQuery();
                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        public static ResultadoTransaccion EliminarDireccion(clsDireccion direccion, SqlTransaction transaction)
        {
            ResultadoTransaccion resTransaccion = new ResultadoTransaccion();            
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_E_CLIENTES_DIRECCION");
                objParams[0].Value = direccion.Id;
               
                SqlCommand command = new SqlCommand("SP_E_CLIENTES_DIRECCION", BaseDatos.Conexion());                
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = transaction;
                command.ExecuteNonQuery();
                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        public static clsDireccionInfo ListarDireccionesPorIdInfo(Int64 idInfo)
        {
            clsDireccionInfo direccionInfo = new clsDireccionInfo();            
            SqlConnection conn = BaseDatos.NuevaConexion();
            DataSet ds = new DataSet();
            
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_CLIENTES_LISTAR_DIRECCIONES_POR_CLIENTEINFO");
                objParams[0].Value = idInfo;

                //SqlCommand command = new SqlCommand("SP_C_CLIENTES_LISTAR_DIRECCIONES_POR_CLIENTEINFO", conn);
                //command.Parameters.AddRange(objParams);
                //command.CommandType = CommandType.StoredProcedure;
                //dreader = command.ExecuteReader();

                ds = SqlHelper.ExecuteDataset(conn, "SP_C_CLIENTES_LISTAR_DIRECCIONES_POR_CLIENTEINFO", objParams);
                if (ds != null)
                {                 
                    if(ds.Tables.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            clsDireccion direccion = new clsDireccion();
                            direccion.Id = Convert.ToInt64(row["Id"]);
                            direccion.IdDireccionInfo = Convert.ToInt64(row["IdDireccionInfo"]);

                            if (row["IdTipoDireccion"] is DBNull)
                                direccion.TipoDireccion = null;
                            else
                            {
                                direccion.TipoDireccion.Id = Convert.ToInt16(row["IdTipoDireccion"]);
                                direccion.TipoDireccion.Nombre = row["TipoDireccion"].ToString();
                            }
                                
                            
                            direccion.NombreDireccion = row["NombreDireccion"].ToString();
                            direccion.Numero = row["Numero"].ToString();
                            direccion.OficinaDpto = row["OficinaDpto"].ToString();
                            direccion.Block = row["Block"].ToString();
                            direccion.Pais.Id = Convert.ToInt64(row["IdPais"]);
                            direccion.Pais.Nombre = row["Pais"].ToString();
                            direccion.Ciudad.Id = Convert.ToInt64(row["IdCiudad"]);
                            direccion.Ciudad.Nombre = row["Ciudad"].ToString();
                            direccion.Comuna.Id = Convert.ToInt64(row["IdComuna"]);
                            direccion.Comuna.Nombre = row["Comuna"].ToString();

                            if (row["IdTipoSector"] is DBNull)
                                direccion.Sector = null;
                            else
                            {
                                direccion.Sector.Id = Convert.ToInt64(row["IdTipoSector"]);
                                direccion.Sector.Nombre = row["Sector"].ToString();    
                            }

                            if (row["IdDestinoDireccion"] is DBNull)
                                direccion.DestinoDireccion = null;
                            else
                            {
                                direccion.DestinoDireccion.Id = Convert.ToInt64(row["IdDestinoDireccion"]);
                                direccion.DestinoDireccion.Nombre = row["DestinoDireccion"].ToString();    
                            }
                            
                            
                            direccionInfo.Items.Add(direccion);
                        }
                    }                                        
                }

                direccionInfo.IdInfo = idInfo;
                
                
                //while (dreader.Read())
                //{
                //    clsDireccion direccion = new clsDireccion();
                //    direccion.Id = Convert.ToInt64(dreader["Id"]);
                //    direccion.IdDireccionInfo = Convert.ToInt64(dreader["IdDireccionInfo"]);
                //    direccion.TipoDireccion.Id = Convert.ToInt16(dreader["IdTipoDireccion"]);
                //    direccion.TipoDireccion.Nombre = dreader["TipoDireccion"].ToString();
                //    direccion.NombreDireccion = dreader["NombreDireccion"].ToString();
                //    direccion.Numero = dreader["Numero"].ToString();
                //    direccion.OficinaDpto = dreader["OficinaDpto"].ToString();
                //    direccion.Block = dreader["Block"].ToString();
                //    direccion.Pais.Id = Convert.ToInt64(dreader["IdPais"]);
                //    direccion.Pais.Nombre = dreader["Pais"].ToString();
                //    direccion.Ciudad.Id = Convert.ToInt64(dreader["IdCiudad"]);
                //    direccion.Ciudad.Nombre = dreader["Ciudad"].ToString();
                //    direccion.Comuna.Id = Convert.ToInt64(dreader["IdComuna"]);
                //    direccion.Comuna.Nombre = dreader["Comuna"].ToString();
                //    direccion.Sector.Id = Convert.ToInt64(dreader["IdTipoSector"]);
                //    direccion.Sector.Nombre = dreader["Sector"].ToString();
                //    direccion.DestinoDireccion.Id = Convert.ToInt64(dreader["IdDestinoDireccion"]);
                //    direccion.DestinoDireccion.Nombre = dreader["DestinoDireccion"].ToString();
                //    listaDirecciones.Add(direccion);
                //}
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);
                
            }
            finally
            {
                conn.Close();
            }

            return direccionInfo;


        }


    }
}
