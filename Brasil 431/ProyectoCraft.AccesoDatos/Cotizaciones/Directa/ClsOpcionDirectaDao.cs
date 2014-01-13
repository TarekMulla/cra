using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.AccesoDatos.Cotizaciones.Directa
{
    public class ClsOpcionDirectaDao
    {
        private const String NombreClase = "ClsOpcionDirectaDao";
        private static SqlParameter[] objParams = null;
        
        public static ResultadoTransaccion ListarTodasLasCotizacionesDirectas()
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            //estados = (List<Estado>)ClsCotizacionDirectaEstadoDao.ListarEstadosCotizacionDirecta().ObjetoTransaccion;

            //IList<CotizacionDirecta> listCot = new List<CotizacionDirecta>();
            //Abrir Conexion
            var conn = BaseDatos.Conexion();
            try
            {
            //    SqlCommand command = new SqlCommand("SP_L_COTIZACION_SOLICITUD_COTIZACIONES", conn);
            //    objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_L_COTIZACION_SOLICITUD_COTIZACIONES");
            //    command.Transaction = conn.BeginTransaction();

            //    command.CommandType = CommandType.StoredProcedure;
            //    objParams[0].Value = 1;
            //    command.Parameters.AddRange(objParams);

            //    var reader = command.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        listCot.Add(GetFromDataReader(reader));
            //    }

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                //res.ObjetoTransaccion = listCot;
                res.Descripcion = "Listado Opciones Directas";

            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = NombreClase;
                res.MetodoError = MethodBase.GetCurrentMethod().Name;
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
    }
}
