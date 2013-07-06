using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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

        public static IList<IntegracionNetShip> ObtieneValoresNetShip(string NumMaster)
        {
            List<IntegracionNetShip> lista = new List<IntegracionNetShip>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "sp_SCC_HouseBLs");
                objParams[0].Value = NumMaster;
                SqlCommand command = new SqlCommand("sp_SCC_HouseBLs", conn);
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
                    netShip.Ruteado = (bool)dreader["Ruteado"];
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
    }
}
