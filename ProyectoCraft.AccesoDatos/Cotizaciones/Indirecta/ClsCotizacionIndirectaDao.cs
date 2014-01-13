using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.AccesoDatos.Clientes;
using ProyectoCraft.AccesoDatos.Cotizaciones.Directa;
using ProyectoCraft.AccesoDatos.Parametros;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Cotizaciones;
using ProyectoCraft.Entidades.Cotizaciones.Indirecta;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.LogicaNegocios.Mantenedores;


namespace ProyectoCraft.AccesoDatos.Cotizaciones.Indirecta {
    public class ClsCotizacionIndirectaDao {
        private const String NombreClase = "ClsCotizacionInDirectaDao";
        private static List<Estado> _estados;
        private static List<TipoTransbordo> _tiposTransbordos;
        private static List<ClsNaviera> _navieras;

        private static List<TipoTransbordo> TiposDeTransbordo {
            set { _tiposTransbordos = value; }
            get {
                if (_tiposTransbordos == null) {
                    _tiposTransbordos = ClsTipoTransbordoDao.ObtieneTodos().ObjetoTransaccion as List<TipoTransbordo>;
                }
                return
                    _tiposTransbordos;
            }
        }

        public static ResultadoTransaccion Crear(CotizacionIndirecta cotizacionInDirecta) {
            ResultadoTransaccion res = new ResultadoTransaccion();
            SqlTransaction trans = null;
            //Abrir Conexion
            var conn = BaseDatos.Conexion();
            try {

                var command = new SqlCommand("SP_N_COTIZACION_SOLICITUD_COTIZACIONES", conn);

                command.Transaction = conn.BeginTransaction();
                trans = command.Transaction;

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idUsuario", cotizacionInDirecta.Usuario.Id32);
                command.Parameters.AddWithValue("@Producto", cotizacionInDirecta.Producto);
                command.Parameters.AddWithValue("@idCliente", cotizacionInDirecta.Cliente.Id32);
                command.Parameters.AddWithValue("@nombreCliente", cotizacionInDirecta.NombreCliente);
                command.Parameters.AddWithValue("@fechaSolicitud", cotizacionInDirecta.FechaSolicitud);
                command.Parameters.AddWithValue("@idIncoterms", cotizacionInDirecta.IncoTerm.Id32);
                command.Parameters.AddWithValue("@gastosLocales", cotizacionInDirecta.GastosLocales);
                command.Parameters.AddWithValue("@ObservacionesFijas", cotizacionInDirecta.ObservacionesFijas);
                command.Parameters.AddWithValue("@Observaciones", cotizacionInDirecta.Observaciones);
                command.Parameters.AddWithValue("@COTIZACION_TIPOS_id", 2);
                command.Parameters.AddWithValue("@COTIZACION_Directa_ESTADOS_id", null);
                command.Parameters.AddWithValue("@COTIZACION_Indirecta_ESTADOS_id", 1);
                command.Parameters.AddWithValue("@conAgenciamento", cotizacionInDirecta.ConAgenciamiento);


                //parametros solo de las cotizaciones Indirectas
                command.Parameters.AddWithValue("@POL", cotizacionInDirecta.POD.Codigo);
                command.Parameters.AddWithValue("@POD", cotizacionInDirecta.POL.Codigo);
                command.Parameters.AddWithValue("@navieraReferencia", cotizacionInDirecta.Naviera.Id32);
                command.Parameters.AddWithValue("@tarifaReferencia", cotizacionInDirecta.TarifaReferencia);
                command.Parameters.AddWithValue("@commodity", cotizacionInDirecta.Commodity);
                command.Parameters.AddWithValue("@fechaEstimadaEmbarque", cotizacionInDirecta.FechaEstimadaEmbarque);
                command.Parameters.AddWithValue("@credito", cotizacionInDirecta.Credito);
                command.Parameters.AddWithValue("@proveedorCarga", cotizacionInDirecta.ProveedorCarga);
                command.Parameters.AddWithValue("@COTIZACION_TIPOS_TRANSBORDOS_id", cotizacionInDirecta.TipoTransbordo.Id32);
                command.CommandType = CommandType.StoredProcedure;

                var outParam = command.Parameters.Add("@Id", SqlDbType.BigInt);
                outParam.Direction = ParameterDirection.Output;
                command.ExecuteScalar();

                cotizacionInDirecta.Id = Convert.ToInt16(outParam.Value);
                cotizacionInDirecta.Id32 = Convert.ToInt32(outParam.Value);

                ClsCotizacionIndirectaDetalleDao.Crear(cotizacionInDirecta, command);

                command.Transaction.Commit();

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = cotizacionInDirecta;
                res.Descripcion = "La cotizacion Directa se guardo Exitosamente";

            } catch (Exception ex) {
                cotizacionInDirecta.Id = cotizacionInDirecta.Id32 = 0;
                foreach (var o in cotizacionInDirecta.Detalles) {
                    o.Id = o.Id32 = 0;
                }

                if (trans != null)
                    trans.Rollback();
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = NombreClase;
                res.MetodoError = MethodBase.GetCurrentMethod().Name;
            } finally {
                conn.Close();
            }
            return res;
        }

        public static ResultadoTransaccion ListarTodasLasCotizacionesIndirectas(clsUsuario usuario) {
            ResultadoTransaccion res = new ResultadoTransaccion();
            _estados = (List<Estado>)ClsCotizacionDirectaEstadoDao.ListarEstadosCotizacionDirecta().ObjetoTransaccion;

            var listCot = new List<CotizacionIndirecta>();
            //Abrir Conexion
            var conn = BaseDatos.Conexion();
            try {
                var command = new SqlCommand("SP_L_COTIZACION_SOLICITUD_COTIZACIONES", conn);
                var objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_L_COTIZACION_SOLICITUD_COTIZACIONES");
                command.Transaction = conn.BeginTransaction();

                command.CommandType = CommandType.StoredProcedure;
                objParams[0].Value = 2;
                objParams[1].Value = usuario.Id;

                command.Parameters.AddRange(objParams);

                var reader = command.ExecuteReader();
                while (reader.Read()) {
                    listCot.Add(GetFromDataReader(reader));
                }

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = listCot;
                res.Descripcion = "Listado Cotizaciones INDirectas";

            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = NombreClase;
                res.MetodoError = MethodBase.GetCurrentMethod().Name;
            } finally {
                conn.Close();
            }
            return res;
        }

        private static CotizacionIndirecta GetFromDataReader(IDataRecord reader) {
            try {
                var i = new CotizacionIndirecta();
                i.Id = i.Id32 = Convert.ToInt32(reader["CSC_ID"]);//num solicitud                
                i.FechaSolicitud = Convert.ToDateTime(reader["fechasolicitud"]);//fecha solicitud
                i.Cliente = new clsClienteMaster(true);
                i.Cliente = clsClienteMasterADO.ObtenerClienteMasterPorId(Convert.ToInt64(reader["idcliente"]));
                i.IncoTerm = new clsIncoTerm();
                i.IncoTerm = Parametros.clsParametrosClientesDAO.ObtenerIncoTermPorId(Convert.ToInt16(reader["idincoterms"]));
                if (!string.IsNullOrEmpty(reader["proveedorCarga"].ToString()))
                    i.ProveedorCarga = reader["proveedorCarga"].ToString();

                i.Estado = new Estado();
                if (!String.IsNullOrEmpty(reader["estado_id"].ToString()))
                    i.Estado.Id = Convert.ToInt32(reader["estado_id"]);//Estado

                foreach (var estado in _estados) {
                    if (estado.Id.Equals(i.Estado.Id)) {
                        i.Estado.Nombre = estado.Nombre;
                        i.Estado.Activo = estado.Activo;
                    }
                }
                return i;
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);
                throw;
            }
        }

        public static ResultadoTransaccion ObtieneCotizacionIndirecta(Int32 id) {
            var res = new ResultadoTransaccion();
            CotizacionIndirecta cotizacion = null;
            //Abrir Conexion
            var conn = BaseDatos.Conexion();
            try {

                var command = new SqlCommand("SP_L_COTIZACION_SOLICITUD_COTIZACIONES_POR_ID", conn) { CommandType = CommandType.StoredProcedure };

                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();
                while (reader.Read())
                    cotizacion = GetFromComnpleteDataReader(reader);

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = cotizacion;
                res.Descripcion = "Se creo la cargo Exitosamente la Cotizacion Indirecta";
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);
                res.Descripcion = ex.Message;
                res.ArchivoError = NombreClase;
                res.MetodoError = MethodBase.GetCurrentMethod().Name;
            } finally {
                conn.Close();
            }
            return res;
        }

        public static ResultadoTransaccion AsignaUsuarioPricing(CotizacionIndirecta cotizacionInDirecta, clsUsuario usuario) {
            var res = new ResultadoTransaccion();
            SqlTransaction trans = null;
            //Abrir Conexion
            var conn = BaseDatos.Conexion();
            try {

                var command = new SqlCommand("SP_A_COTIZACION_INDIRECTA_ASIGNA_USUARIO_PRICING", conn) { Transaction = conn.BeginTransaction() };

                
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdCotizacion", cotizacionInDirecta.Id32);
                command.Parameters.AddWithValue("@IdUsuario", usuario.Id32);
                command.ExecuteNonQuery();
                command.Transaction.Commit();
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = cotizacionInDirecta;
                res.Descripcion = "Se asigno el usuario Pricing exitosamente";

            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);
                res.Descripcion = ex.Message;
                res.ArchivoError = NombreClase;
                res.MetodoError = MethodBase.GetCurrentMethod().Name;
            } finally {
                conn.Close();
            }
            return res;
        }

        private static CotizacionIndirecta GetFromComnpleteDataReader(IDataRecord reader) {
            try {
                var cot = new CotizacionIndirecta();
                cot.Id = cot.Id32 = Convert.ToInt32(reader["id"]);
                cot.Producto = reader["producto"].ToString();

                cot.Usuario = Usuarios.clsUsuarioADO.ObtenerTransaccionUsuarioPorId(Convert.ToInt32(reader["idUsuario"])).ObjetoTransaccion as clsUsuario;

                cot.Cliente = new clsClienteMaster(true);
                cot.Cliente = clsClienteMasterADO.ObtenerClienteMasterPorId(Convert.ToInt64(reader["idcliente"]));

                cot.NombreCliente = reader["nombreCliente"].ToString();
                cot.FechaSolicitud = Convert.ToDateTime(reader["fechaSolicitud"]);//fecha solicitud             

                cot.IncoTerm = new clsIncoTerm();
                cot.IncoTerm = clsParametrosClientesDAO.ObtenerIncoTermPorId(Convert.ToInt16(reader["idincoterms"]));
                if (_navieras == null)
                    _navieras = ClsNavierasDAO.ListarNavieras() as List<ClsNaviera>;

                var idNaviera = Convert.ToInt32(reader["navieraReferencia"]);
                cot.Naviera = _navieras.Find(foo => foo.Id32 == idNaviera);


                cot.Commodity = reader["commodity"].ToString();
                if (!String.IsNullOrEmpty(reader["gastosLocales"].ToString()))
                    cot.GastosLocales = Convert.ToDecimal(reader["gastosLocales"]);

                cot.POD = ClsPuertosDao.ObtienePuertoPorCodigo(reader["POD"].ToString()).ObjetoTransaccion as Puerto;
                cot.POL = ClsPuertosDao.ObtienePuertoPorCodigo(reader["POL"].ToString()).ObjetoTransaccion as Puerto;

                cot.ConAgenciamiento = Convert.ToBoolean(reader["conAgenciamento"].ToString());
                cot.FechaEstimadaEmbarque = Convert.ToDateTime(reader["fechaEstimadaEmbarque"]);
                cot.Observaciones = reader["Observaciones"].ToString();
                cot.ObservacionesFijas = reader["ObservacionesFijas"].ToString();

                cot.Credito = reader["credito"].ToString();
                cot.ProveedorCarga = reader["proveedorCarga"].ToString();
                cot.TarifaReferencia = reader["tarifaReferencia"].ToString();
                if (!String.IsNullOrEmpty(reader["COTIZACION_TIPOS_TRANSBORDOS_id"].ToString()))
                    cot.TipoTransbordo = TiposDeTransbordo.Find(
                        foo => foo.Id32.Equals(Convert.ToInt32(reader["COTIZACION_TIPOS_TRANSBORDOS_id"])));

                cot.Detalles = ClsCotizacionIndirectaDetalleDao.ObtieneDetalles(cot).ObjetoTransaccion as List<CotizacionIndirectaDetalle>;

                //fixme: colocar codigo de cotizaciones Indirecta para los estados
                /*
                 * var listEstados = (List<Estado>)ClsCotizacionDirectaEstadoDao.ListarEstadosCotizacionDirecta().ObjetoTransaccion;
                 * cot.Estado = listEstados.Find(estado => estado.Id == Convert.ToInt32(reader["COTIZACION_InDirecta_ESTADOS_id"]));
                 */
                return cot;
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);
                //throw;
                return null;
            }

        }


    }
}
