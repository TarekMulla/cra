using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Cotizaciones.Indirecta;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.AccesoDatos.Cotizaciones.Indirecta
{
    public class CotizacionIndirectaOpcionDao
    {
        public static ResultadoTransaccion Crear(CotizacionIndirectaOpcion cot)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            SqlTransaction trans = null;
            //Abrir Conexion
            var conn = BaseDatos.Conexion();
            try
            {
                var command = new SqlCommand("SP_N_COTIZACION_SOLICITUD_COTIZACIONES", conn);

                command.Transaction = conn.BeginTransaction();
                trans = command.Transaction;

                command.CommandType = CommandType.StoredProcedure;
                //command.Parameters.AddWithValue("@idUsuario", cotizacionInDirecta.Usuario.Id32);
                //command.Parameters.AddWithValue("@Producto", cotizacionInDirecta.Producto);
                //command.Parameters.AddWithValue("@idCliente", cotizacionInDirecta.Cliente.Id32);
                //command.Parameters.AddWithValue("@nombreCliente", cotizacionInDirecta.NombreCliente);
                //command.Parameters.AddWithValue("@fechaSolicitud", cotizacionInDirecta.FechaSolicitud);
                //command.Parameters.AddWithValue("@idIncoterms", cotizacionInDirecta.IncoTerm.Id32);
                //command.Parameters.AddWithValue("@gastosLocales", cotizacionInDirecta.GastosLocales);
                //command.Parameters.AddWithValue("@ObservacionesFijas", cotizacionInDirecta.ObservacionesFijas);
                //command.Parameters.AddWithValue("@Observaciones", cotizacionInDirecta.Observaciones);
                //command.Parameters.AddWithValue("@COTIZACION_TIPOS_id", 2);
                //command.Parameters.AddWithValue("@COTIZACION_Directa_ESTADOS_id", null);
                //command.Parameters.AddWithValue("@COTIZACION_Indirecta_ESTADOS_id", 1);
                //command.Parameters.AddWithValue("@conAgenciamento", cotizacionInDirecta.ConAgenciamiento);


                ////parametros solo de las cotizaciones Indirectas
                //command.Parameters.AddWithValue("@POL", cotizacionInDirecta.POD.Codigo);
                //command.Parameters.AddWithValue("@POD", cotizacionInDirecta.POL.Codigo);
                //command.Parameters.AddWithValue("@navieraReferencia", cotizacionInDirecta.Naviera.Id32);
                //command.Parameters.AddWithValue("@tarifaReferencia", cotizacionInDirecta.TarifaReferencia);
                //command.Parameters.AddWithValue("@commodity", cotizacionInDirecta.Commodity);
                //command.Parameters.AddWithValue("@fechaEstimadaEmbarque", cotizacionInDirecta.FechaEstimadaEmbarque);
                //command.Parameters.AddWithValue("@credito", cotizacionInDirecta.Credito);
                //command.Parameters.AddWithValue("@proveedorCarga", cotizacionInDirecta.ProveedorCarga);
                //command.Parameters.AddWithValue("@COTIZACION_TIPOS_TRANSBORDOS_id", cotizacionInDirecta.TipoTransbordo.Id32);
                command.CommandType = CommandType.StoredProcedure;

                var outParam = command.Parameters.Add("@Id", SqlDbType.BigInt);
                outParam.Direction = ParameterDirection.Output;
                command.ExecuteScalar();

                //cotizacionInDirecta.Id = Convert.ToInt16(outParam.Value);
                //cotizacionInDirecta.Id32 = Convert.ToInt32(outParam.Value);

                CotizacionIndirectaOpcionDetalleDao.Crear(cot, command);

                command.Transaction.Commit();

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                //res.ObjetoTransaccion = cotizacionInDirecta;
                res.Descripcion = "La cotizacion Directa se guardo Exitosamente";

            }
            catch (Exception ex)
            {
                //cotizacionInDirecta.Id = cotizacionInDirecta.Id32 = 0;
                //foreach (var o in cotizacionInDirecta.Detalles)
                //{
                //    o.Id = o.Id32 = 0;
                //}

                if (trans != null)
                    trans.Rollback();
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                //res.ArchivoError = NombreClase;
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
