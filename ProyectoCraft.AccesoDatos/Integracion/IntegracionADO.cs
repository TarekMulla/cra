using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Integracion;

namespace ProyectoCraft.AccesoDatos.Integracion
{
    public class IntegracionADO
    {
        private static SqlParameter[] objParams = null;
        private static SqlConnection conn = null;
        private static SqlDataReader dreader = null;
        private static ResultadoTransaccion resTransaccion = null;

        public static IList<IntegracionNetShip> ObtieneValoresNetShip(string NumMaster, string StoreProcedureName)
        {
            List<IntegracionNetShip> lista = new List<IntegracionNetShip>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, StoreProcedureName);
                objParams[0].Value = NumMaster;
                SqlCommand command = new SqlCommand(StoreProcedureName, conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                IntegracionNetShip netShip = null;
                while (dreader.Read())
                {                    

                    netShip = new IntegracionNetShip();
                    netShip.Consolidada = dreader["Consolidada"].ToString();
                    netShip.HouseBl = dreader["House BL"].ToString();                    
                    netShip.Rut = dreader["RUT"].ToString();
                    netShip.Cliente = dreader["Cliente"].ToString();
                    netShip.TipoCliente = dreader["Tipo Cliente"].ToString();
                    if (!string.IsNullOrEmpty(dreader["Ruteado"].ToString()))
                        netShip.Ruteado = dreader["Ruteado"].ToString().Equals("1");
                    netShip.ShippingInstruction = dreader["Shipping Instruction"].ToString();
                    netShip.Puerto = dreader["Puerto"].ToString();
                    
                    Base.Log.Log.EscribirLog(netShip.HouseBl);                    

                    lista.Add(netShip);

                }
            }
            catch (Exception ex)
            {
                Base.Log.Log.EscribirLog(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return lista;
        }

        public static void GuardaLogProceso(IntegracionNetShip _int)
        {
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_Paperless_IntegracionNetship");

                objParams[0].Value = _int.IdPaperless;

                if (_int.ValorPaperless != null)
                    objParams[1].Value = _int.ValorPaperless;
                else
                    objParams[1].Value = null;

                if (_int.ValorNetShip != null)
                    objParams[2].Value = _int.ValorNetShip;
                else
                    objParams[2].Value = null;

                if (_int.Mensaje != null)
                    objParams[3].Value = _int.Mensaje;
                else
                    objParams[3].Value = null;

                if (_int.Mensaje != null)
                    try
                    {
                        objParams[4].Value = _int.IdPaperlessTipoError;
                    }
                    catch (Exception)
                    {                       
                    }
                    
                else
                    objParams[4].Value = null;

                SqlCommand command = new SqlCommand("SP_N_Paperless_IntegracionNetship", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                //dreader = command.ExecuteReader();
                var idRetorno = Convert.ToInt64(command.ExecuteScalar());

                
            }
            catch (Exception ex)
            {
                Base.Log.Log.EscribirLog(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            
        }

        public static IList<PaperlessIntegracionNetShipLog> ObtieneLogPaperlessNetShip(Int32 IdPaperless)
        {
            List<PaperlessIntegracionNetShipLog> lista = new List<PaperlessIntegracionNetShipLog>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_L_Paperless_IntegracionNetship");
                objParams[0].Value = IdPaperless;
                SqlCommand command = new SqlCommand("SP_L_Paperless_IntegracionNetship", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                PaperlessIntegracionNetShipLog item = null;
                while (dreader.Read())
                {
                    item = new PaperlessIntegracionNetShipLog();
                    item.IdPaperless = Convert.ToInt32(dreader["IDPaperless"]);
                    item.ValorPaperless = dreader["Valorpaperless"].ToString();
                    item.ValorNetship = dreader["valorNetShip"].ToString();
                    item.Mensaje = dreader["Mensaje"].ToString();
                    item.CreateDate = Convert.ToDateTime(dreader["CreateDate"]);
                    lista.Add(item);

                }
            }
            catch (Exception ex)
            {
                Base.Log.Log.EscribirLog(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return lista;
        }

    }
}
