using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Clientes.Target;
using System.Data;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Clientes.TargetAccount;

namespace ProyectoCraft.AccesoDatos.Clientes
{
    public static class clsEmpresaCompetenciaDAO
    {
        private static SqlParameter[] objParams = null;
        private static SqlConnection conn = null;
        private static SqlTransaction transaction = null;
        private static SqlDataReader dreader = null;
        private static ResultadoTransaccion resTransaccion = null;

        public static IList<clsTargetAccountCompetencia> ListarEmpresasCompetencia(string nombre)
        {
            IList<clsTargetAccountCompetencia> listaempresas = new List<clsTargetAccountCompetencia>();

            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_CLIENTES_TARGET_EMPRESA_COMPETENCIA_POR_NOMBRE");                
                objParams[0].Value = nombre;

                SqlCommand command = new SqlCommand("SP_C_CLIENTES_TARGET_EMPRESA_COMPETENCIA_POR_NOMBRE", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    clsTargetAccountCompetencia empresa = new clsTargetAccountCompetencia();
                    empresa.Id = Convert.ToInt64(dreader[0]);
                    empresa.Nombre = dreader[1].ToString();
                    empresa.FechaCreacion = (DateTime)dreader[2];
                    
                    listaempresas.Add(empresa);
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

            return listaempresas;

        }

        public static ResultadoTransaccion BuscarEmpresaCompetenciaTransaccion(Int64 Id, string nombre)
        {
            return BuscarEmpresCompetencia(Id, nombre);
        }

        public static clsEmpresaCompetencia BuscarEmpresaCompetenciaPorId(Int64 Id)
        {
            ResultadoTransaccion res = BuscarEmpresCompetencia(Id, "-1");
            clsEmpresaCompetencia empresa = new clsEmpresaCompetencia();
            if (res.Estado == Entidades.Enums.Enums.EstadoTransaccion.Aceptada)
            {
                empresa = (clsEmpresaCompetencia)res.ObjetoTransaccion;
            }
            else return null;

            return empresa;
        }

        private static ResultadoTransaccion BuscarEmpresCompetencia(Int64 Id, string nombre)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            clsEmpresaCompetencia empresa = null;

            try
            {                      
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_CLIENTES_TARGET_EMPRESA_COMPETENCIA");
                objParams[0].Value = Id;
                objParams[1].Value = nombre;

                SqlCommand command = new SqlCommand("SP_C_CLIENTES_TARGET_EMPRESA_COMPETENCIA", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    empresa = new clsEmpresaCompetencia();
                    empresa.Id = Convert.ToInt64(dreader[0]);
                    empresa.Nombre = dreader[1].ToString();
                    empresa.FechaCreacion = (DateTime)dreader[2];                                        
                }

                res.Estado = Entidades.Enums.Enums.EstadoTransaccion.Aceptada;
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = empresa;

            }
            catch (Exception ex)
            {
                res.Estado = Entidades.Enums.Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;                
            }
            finally
            {
                conn.Close();
            }

            return res;
        }

    }
}
