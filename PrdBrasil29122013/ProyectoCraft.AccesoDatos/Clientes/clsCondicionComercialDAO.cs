using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Clientes.CondicionesComerciales;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.AccesoDatos.Clientes
{
    public static class clsCondicionComercialDAO
    {
        private static SqlParameter[] objParams = null;
        private static SqlConnection conn = null;
        private static SqlTransaction transaction = null;
        private static SqlDataReader dreader = null;
        private static ResultadoTransaccion resTransaccion = null;

        public static ResultadoTransaccion GuardaCondicionComercialCliente(Entidades.Clientes.clsClienteMaster cliente, SqlConnection conection, SqlTransaction transaction)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            Int64 IdCondicion = 0;            
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conection, "SP_N_CLIENTES_CONDICION_COMERCIAL");
                objParams[0].Value = cliente.Id;
                objParams[1].Value = cliente.CondicionComercial.CondicionComercialFlete.Id;
                objParams[2].Value = cliente.CondicionComercial.CondicionComercialGastosLocales.Id;
                objParams[3].Value = cliente.CondicionComercial.MontoLineaCredito;
                objParams[4].Value = cliente.CondicionComercial.VigenciaDesde;
                objParams[5].Value = cliente.CondicionComercial.VigenciaHasta;
                objParams[6].Value = cliente.CondicionComercial.UsuarioSolicita.Id;
                if (cliente.CondicionComercial.UsuarioAutoriza == null)
                    objParams[7].Value = -1;
                else 
                    objParams[7].Value = cliente.CondicionComercial.UsuarioAutoriza.Id;

                objParams[8].Value = cliente.CondicionComercial.FechaSolicita;
                objParams[9].Value = cliente.CondicionComercial.FechaAutoriza;
                objParams[10].Value = cliente.CondicionComercial.Estado;
                
                SqlCommand command3 = new SqlCommand("SP_N_CLIENTES_CONDICION_COMERCIAL", conection);
                command3.Transaction = transaction;
                command3.Parameters.AddRange(objParams);
                command3.CommandType = CommandType.StoredProcedure;
                IdCondicion = Convert.ToInt64(command3.ExecuteScalar());

                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.ObjetoTransaccion = IdCondicion;

            }
            catch (Exception ex)
            {
                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return res;


        }

        public static IList<clsTipoCondicionComercial> ListarCondicionesComercialesPorTipo(Enums.TipoCondicionComercial tipo)
        {
            IList<clsTipoCondicionComercial> listaCondiciones = new List<clsTipoCondicionComercial>();

            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_CLIENTES_CONDICIONES_COMERCIALES");
                objParams[0].Value = tipo;

                SqlCommand command = new SqlCommand("SP_C_CLIENTES_CONDICIONES_COMERCIALES", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    clsTipoCondicionComercial condicion = new clsTipoCondicionComercial();
                    condicion.Id = Convert.ToInt64(dreader[0]);
                    condicion.Nombre = dreader[1].ToString();
                    condicion.DiasPlazo = Convert.ToInt16(dreader[2]);
                    condicion.TipoCondicionComercial = (Enums.TipoCondicionComercial)dreader[3];
                    listaCondiciones.Add(condicion);
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

            return listaCondiciones;


        }


    }
}
