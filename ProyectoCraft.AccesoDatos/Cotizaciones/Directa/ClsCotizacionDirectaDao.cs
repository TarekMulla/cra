using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.AccesoDatos.Clientes;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.LogicaNegocios.Mantenedores;


namespace ProyectoCraft.AccesoDatos.Cotizaciones.Directa {
    public class ClsCotizacionDirectaDao {
        private const String NombreClase = "ClsCotizacionDirectaDao";
        private static SqlParameter[] objParams = null;
        private static List<Estado> estados;

        public static ResultadoTransaccion ListarTodasLasCotizacionesDirectas(clsUsuario usuario, DateTime desde) {
            ResultadoTransaccion res = new ResultadoTransaccion();
            estados = (List<Estado>)ClsCotizacionDirectaEstadoDao.ListarEstadosCotizacionDirecta().ObjetoTransaccion;

            IList<CotizacionDirecta> listCot = new List<CotizacionDirecta>();
            //Abrir Conexion
            var conn = BaseDatos.Conexion();
            try {
                SqlCommand command = new SqlCommand("SP_L_COTIZACION_SOLICITUD_COTIZACIONES_POR_USUARIO", conn);
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn,
                                                                      "SP_L_COTIZACION_SOLICITUD_COTIZACIONES_POR_USUARIO");
                command.Transaction = conn.BeginTransaction();

                command.CommandType = CommandType.StoredProcedure;
                objParams[0].Value = usuario.Id;
                objParams[1].Value = desde;
                command.Parameters.AddRange(objParams);

                var reader = command.ExecuteReader();
                while (reader.Read()) {
                    var incoterm = Parametros.clsParametrosClientesDAO.ObtenerIncoTermPorId(4);
                    var cotizacion = GetFromDataReader(reader);
                    cotizacion.IncoTerm = incoterm;
                    listCot.Add(cotizacion);
                }

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = listCot;
                res.Descripcion = "Listado Cotizaciones Directas";

            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = NombreClase;
                res.MetodoError = MethodBase.GetCurrentMethod().Name;
            } finally {
                conn.Close();
            }
            CargaOpciones(listCot);
            return res;
        }

        public static ResultadoTransaccion ListarTodasLasCotizacionesDirectas(DateTime desde) {
            ResultadoTransaccion res = new ResultadoTransaccion();
            estados = (List<Estado>)ClsCotizacionDirectaEstadoDao.ListarEstadosCotizacionDirecta().ObjetoTransaccion;

            IList<CotizacionDirecta> listCot = new List<CotizacionDirecta>();
            //Abrir Conexion
            var conn = BaseDatos.Conexion();
            try {
                var command = new SqlCommand("SP_L_COTIZACION_SOLICITUD_COTIZACIONES", conn);
                command.Parameters.AddWithValue("@desde", desde);

                command.Transaction = conn.BeginTransaction();
                command.CommandType = CommandType.StoredProcedure;

                var reader = command.ExecuteReader();

                while (reader.Read()) {
                    var incoterm = Parametros.clsParametrosClientesDAO.ObtenerIncoTermPorId(4);
                    var cotizacion = GetFromDataReader(reader);
                    cotizacion.IncoTerm = incoterm;
                    listCot.Add(cotizacion);
                }

                res.Accion = Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = listCot;
                res.Descripcion = "Listado Cotizaciones Directas";

            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = NombreClase;
                res.MetodoError = MethodBase.GetCurrentMethod().Name;
            } finally {
                conn.Close();
            }
            CargaOpciones(listCot);
            return res;
        }

        private static void CargaOpciones(IList<CotizacionDirecta> listCot) {
            foreach (var cotizacionDirecta in listCot) {
                cotizacionDirecta.Opciones = GetOpcionesByCotizacionDirectaId(cotizacionDirecta.Id);
            }
        }

        private static List<Opcion> GetOpcionesByCotizacionDirectaId(Int64 id) {
            var conn = BaseDatos.Conexion();
            try {

                ResultadoTransaccion res = new ResultadoTransaccion();

                IList<Opcion> list = new List<Opcion>();

                SqlCommand command = new SqlCommand("SP_L_COTIZACION_DIRECTA_OPCIONES", conn);
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_L_COTIZACION_DIRECTA_OPCIONES");
                command.Transaction = conn.BeginTransaction();

                command.CommandType = CommandType.StoredProcedure;
                objParams[0].Value = id;
                command.Parameters.AddRange(objParams);

                var reader = command.ExecuteReader();
                while (reader.Read()) {
                    var i = GetOpcionFromDataReader(reader);
                    list.Add(i);
                }

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = list;
                res.Descripcion = "Listado Cotizaciones Directas Opciones";

                return (List<Opcion>)list;

            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);
            } finally {
                conn.Close();
            }
            return new List<Opcion>();
        }

        private static Opcion GetOpcionFromDataReader(IDataRecord reader) {
            try {
                var i = new Opcion();
                i.Id = i.Id32 = Convert.ToInt32(reader["id"]);
                i.Numero = reader["numero"].ToString();
                i.FechaValidezFin = Convert.ToDateTime(reader["fechavalidezfin"]);
                i.FechaValidezInicio = Convert.ToDateTime(reader["fechavalidezinicio"]);
                i.Naviera = new ClsNaviera();
                i.Naviera.Nombre = reader["naviera"].ToString();
                i.TiempoTransito = reader["tiempotransito"].ToString();
                i.FechaCreacion = Convert.ToDateTime(reader["createDate"]);
                i.Estado = new Estado();
                i.Estado.Id32 = Convert.ToInt32(reader["Estado"]);
                i.Estado.Nombre = reader["EstadoDescripcion"].ToString();
                //idusuario,createdate,cotizacion_solicitud_cotizaciones_id,cotizacion_indirecta_estados_id

                return i;
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);
                //throw;
                return null;
            }

        }
        private static clsClienteMaster GetClienteFromDataReader(IDataRecord readercliente) {
            var master = new clsClienteMaster(true);
            master.Id = Convert.ToInt64(readercliente["cliente_Id"]);
            master.NombreCompañia = readercliente["cliente_NombreCompania"].ToString();
            master.Nombres = readercliente["cliente_Nombres"].ToString();
            master.ApellidoPaterno = readercliente["cliente_ApellidoPaterno"].ToString();
            master.ApellidoMaterno = readercliente["cliente_ApellidoMaterno"].ToString();
            master.RUT = readercliente["cliente_RUT"].ToString();

            if (readercliente["cliente_NombreFantasia"] is DBNull)
                master.NombreFantasia = "";
            else
                master.NombreFantasia = readercliente["cliente_NombreFantasia"].ToString();
            if (!String.IsNullOrEmpty(readercliente["cliente_CodTipo"].ToString()))
                master.Tipo = (Enums.TipoPersona)readercliente["cliente_CodTipo"];
            return master;
        }

        private static CotizacionDirecta GetFromDataReader(IDataRecord reader) {
            try {
                var i = new CotizacionDirecta();
                i.Id = i.Id32 = Convert.ToInt32(reader["CSC_ID"]); //num solicitud                
                i.FechaSolicitud = Convert.ToDateTime(reader["fechasolicitud"]); //fecha solicitud
                //traer la clase cliente completa
                i.Cliente = GetClienteFromDataReader(reader);
                //i.Cliente = clsClienteMasterADO.ObtenerClienteMasterPorId(Convert.ToInt64(reader["idcliente"]));
               
                i.IncoTerm = new clsIncoTerm();
                if (!string.IsNullOrEmpty(reader["proveedorCarga"].ToString()))
                    i.ProveedorCarga = reader["proveedorCarga"].ToString();

                //i.//Tipo
                i.Estado = new Estado();
                i.Estado.Id = Convert.ToInt32(reader["cotizacion_directa_estados_id"]); //Estado
                i.Opciones = new List<Opcion>();

                i.Usuario = new clsUsuario();
                i.Usuario.Id = i.Usuario.Id32 = Convert.ToInt32(reader["usuario_id"]);
                i.Usuario.Nombre = reader["usuario_nombres"].ToString();
                i.Usuario.ApellidoPaterno = reader["usuario_ApellidoPaterno"].ToString();
                i.Usuario.ApellidoMaterno = reader["usuario_ApellidoMaterno"].ToString();
                i.Usuario.NombreUsuario = reader["usuario_NombreUsuario"].ToString();
                if (!String.IsNullOrEmpty(reader["NextFollowUp"].ToString()))
                    i.NextFollowup = Convert.ToDateTime(reader["NextFollowUp"]);

            

                foreach (var estado in estados) {
                    if (estado.Id.Equals(i.Estado.Id)) {
                        i.Estado.Nombre = estado.Nombre;
                        i.Estado.Activo = estado.Activo;
                    }
                }

                return i;
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);
                //throw;
                return null;
            }

        }

        private static CotizacionDirecta GetFromComnpleteDataReader(IDataRecord reader) {
            try {
                var cot = new CotizacionDirecta();
                cot.Id = cot.Id32 = Convert.ToInt32(reader["id"]);
                cot.Producto = reader["producto"].ToString();

                cot.Usuario =
                    Usuarios.clsUsuarioADO.ObtenerTransaccionUsuarioPorId(Convert.ToInt32(reader["idUsuario"])).
                        ObjetoTransaccion as clsUsuario;

                cot.Cliente = new clsClienteMaster(true);
                cot.Cliente = clsClienteMasterADO.ObtenerClienteMasterPorId(Convert.ToInt64(reader["idcliente"]));

                cot.NombreCliente = reader["nombreCliente"].ToString();
                cot.FechaSolicitud = Convert.ToDateTime(reader["fechaSolicitud"]); //fecha solicitud             

                cot.IncoTerm = new clsIncoTerm();
                cot.IncoTerm =
                    Parametros.clsParametrosClientesDAO.ObtenerIncoTermPorId(Convert.ToInt16(reader["idincoterms"]));

                cot.Commodity = reader["commodity"].ToString();
                cot.GastosLocales = 0;

                if (!String.IsNullOrEmpty(reader["gastosLocales"].ToString()))
                    cot.GastosLocales = Convert.ToDecimal(reader["gastosLocales"]);

                cot.Observaciones = reader["Observaciones"].ToString();
                cot.ObservacionesFijas = reader["ObservacionesFijas"].ToString();

                if (!string.IsNullOrEmpty(reader["copiadode"].ToString()))
                    cot.CopiadoDe = Convert.ToInt32(reader["copiadode"]);

                var listEstados =
                    (List<Estado>)ClsCotizacionDirectaEstadoDao.ListarEstadosCotizacionDirecta().ObjetoTransaccion;
                cot.Estado =
                    listEstados.Find(estado => estado.Id == Convert.ToInt32(reader["COTIZACION_Directa_ESTADOS_id"]));

                cot.GastosLocalesList =
                    ClsGastosLocalesDao.ObtieneGastosLocales(cot.Id32).ObjetoTransaccion as List<GastoLocal>;

                cot.Opciones = ClsOpcionDao.ObtieneOpciones(cot.Id32).ObjetoTransaccion as List<Opcion>;

                return cot;
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);
                //throw;
                return null;
            }

        }

        public static ResultadoTransaccion Crear(CotizacionDirecta cotizacionDirecta) {
            ResultadoTransaccion res = new ResultadoTransaccion();
            SqlTransaction trans = null;
            //Abrir Conexion
            var conn = BaseDatos.Conexion();
            try {

                SqlCommand command = new SqlCommand("SP_N_COTIZACION_SOLICITUD_COTIZACIONES", conn);

                command.Transaction = conn.BeginTransaction();
                trans = command.Transaction;

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idUsuario", cotizacionDirecta.Usuario.Id32);
                command.Parameters.AddWithValue("@Producto", cotizacionDirecta.Producto);
                //command.Parameters.AddWithValue("@Producto", "FCL");
                command.Parameters.AddWithValue("@idCliente", cotizacionDirecta.Cliente.Id32);
                command.Parameters.AddWithValue("@nombreCliente", cotizacionDirecta.NombreCliente);
                command.Parameters.AddWithValue("@fechaSolicitud", cotizacionDirecta.FechaSolicitud);
                command.Parameters.AddWithValue("@idIncoterms", cotizacionDirecta.IncoTerm.Id32);
                command.Parameters.AddWithValue("@gastosLocales", cotizacionDirecta.GastosLocales);
                command.Parameters.AddWithValue("@ObservacionesFijas", cotizacionDirecta.ObservacionesFijas);
                command.Parameters.AddWithValue("@Observaciones", cotizacionDirecta.Observaciones);
                command.Parameters.AddWithValue("@commodity", cotizacionDirecta.Commodity);
                command.Parameters.AddWithValue("@COTIZACION_TIPOS_id", 1);
                command.Parameters.AddWithValue("@COTIZACION_Directa_ESTADOS_id", 1);
                command.Parameters.AddWithValue("@conAgenciamento", false);
                command.Parameters.AddWithValue("@CopiadoDe", cotizacionDirecta.CopiadoDe);

                command.CommandType = CommandType.StoredProcedure;

                var outParam = command.Parameters.Add("@Id", SqlDbType.BigInt);
                outParam.Direction = ParameterDirection.Output;
                command.ExecuteScalar();

                cotizacionDirecta.Id = Convert.ToInt16(outParam.Value);
                cotizacionDirecta.Id32 = Convert.ToInt32(outParam.Value);

                CrearOpcion(cotizacionDirecta, command);
                ClsGastosLocalesDao.CrearGastosLocales(cotizacionDirecta, command);
                command.Transaction.Commit();

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = cotizacionDirecta;
                res.Descripcion = "La cotización se guardó Exitosamente";

            } catch (Exception ex) {
                cotizacionDirecta.Id = cotizacionDirecta.Id32 = 0;
                foreach (var o in cotizacionDirecta.Opciones) {
                    o.Id = o.Id32 = 0;
                    foreach (var d in o.Detalles) {
                        d.Id = d.Id32 = 0;
                    }
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

        private static void CrearOpcion(CotizacionDirecta cotizacionDirecta, Opcion o, SqlCommand command) {
            var com = command.Connection.CreateCommand();
            com.Transaction = command.Transaction;

            com.CommandText = "SP_N_COTIZACION_DIRECTA_OPCIONES";

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@numero", o.Numero);
            com.Parameters.AddWithValue("@fechaValidezInicio", o.FechaValidezInicio);
            com.Parameters.AddWithValue("@fechaValidezFin", o.FechaValidezFin);
            com.Parameters.AddWithValue("@Naviera", o.Naviera.Id32);
            com.Parameters.AddWithValue("@TiempoTransito", o.TiempoTransito);
            com.Parameters.AddWithValue("@idUsuario", o.Usuario.Id32);
            com.Parameters.AddWithValue("@COTIZACION_SOLICITUD_COTIZACIONES_id", cotizacionDirecta.Id32);
            com.Parameters.AddWithValue("@idTipoServicio", o.TiposServicio.Id32);
            if (o.TipoVia != null)
                com.Parameters.AddWithValue("@idTipoVia", o.TipoVia.Id32);
            else
                com.Parameters.AddWithValue("@idTipoVia", null);

            com.CommandType = CommandType.StoredProcedure;

            var outParam = com.Parameters.Add("@Id", SqlDbType.BigInt);
            outParam.Direction = ParameterDirection.Output;
            com.ExecuteScalar();

            o.Id = Convert.ToInt16(outParam.Value);
            o.Id32 = Convert.ToInt32(outParam.Value);
            CrearRelacionPuertos(o, com);
            CrearOpcionDetalles(o, com);
        }

        public static ResultadoTransaccion CrearOpcion(CotizacionDirecta cotizacionDirecta, SqlCommand command) {
            var num = 1;
            try {
                foreach (var o in cotizacionDirecta.Opciones) {
                    if (o.IsNew)
                        o.Numero = String.Format("{0:d4}-{1:d4}", cotizacionDirecta.Id32, num);
                    CrearOpcion(cotizacionDirecta, o, command);
                    num++;
                }
                return new ResultadoTransaccion();
            } catch (Exception e) {
                throw e;
            }
        }

        public static ResultadoTransaccion CrearRelacionPuertos(Opcion opcion, SqlCommand command) {
            try {
                foreach (var o in opcion.Pod) {
                    var com = command.Connection.CreateCommand();
                    com.Transaction = command.Transaction;

                    com.CommandText = "SP_N_COTIZACION_DIRECTA_OPCIONES_PUERTOS";

                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@puerto", o.Codigo);
                    com.Parameters.AddWithValue("@cotizacion_directa_opciones_id", opcion.Id32);
                    com.Parameters.AddWithValue("@tipo", "Pod");
                    com.CommandType = CommandType.StoredProcedure;

                    var outParam = com.Parameters.Add("@Id", SqlDbType.BigInt);
                    outParam.Direction = ParameterDirection.Output;
                    com.ExecuteScalar();

                    o.Id = Convert.ToInt16(outParam.Value);
                    o.Id32 = Convert.ToInt32(outParam.Value);
                }
                foreach (var o in opcion.Pol) {
                    var com = command.Connection.CreateCommand();
                    com.Transaction = command.Transaction;

                    com.CommandText = "SP_N_COTIZACION_DIRECTA_OPCIONES_PUERTOS";

                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@puerto", o.Codigo);
                    com.Parameters.AddWithValue("@cotizacion_directa_opciones_id", opcion.Id32);
                    com.Parameters.AddWithValue("@tipo", "Pol");
                    com.CommandType = CommandType.StoredProcedure;

                    var outParam = com.Parameters.Add("@Id", SqlDbType.BigInt);
                    outParam.Direction = ParameterDirection.Output;
                    com.ExecuteScalar();

                    o.Id = Convert.ToInt16(outParam.Value);
                    o.Id32 = Convert.ToInt32(outParam.Value);
                }
                return new ResultadoTransaccion();
            } catch (Exception e) {
                throw e;
            }
        }

        private static void CrearOpcionDetalle(Opcion opcion, DetalleOpcion detalle, SqlCommand command) {
            var com = command.Connection.CreateCommand();
            com.Transaction = command.Transaction;

            com.CommandText = "SP_N_COTIZACION_DIRECTA_OPCIONES_DETALLES";

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
            com.Parameters.AddWithValue("@costo", detalle.Costo);
            com.Parameters.AddWithValue("@venta", detalle.Venta);
            com.Parameters.AddWithValue("@COTIZACION_MONEDAS_id", detalle.Moneda.Id32);
            com.Parameters.AddWithValue("@COTIZACION_DIRECTA_ITEMS_id", detalle.Unidad.Id32);
            com.Parameters.AddWithValue("@COTIZACION_DIRECTA_CONCEPTO_ID", detalle.Concepto.Id32);
            com.Parameters.AddWithValue("@COTIZACION_DIRECTA_OPCIONES_id", opcion.Id32);
            com.CommandType = CommandType.StoredProcedure;
            var outParam = com.Parameters.Add("@Id", SqlDbType.BigInt);
            outParam.Direction = ParameterDirection.Output;
            com.ExecuteScalar();

            detalle.Id = Convert.ToInt16(outParam.Value);
            detalle.Id32 = Convert.ToInt32(outParam.Value);

        }

        public static ResultadoTransaccion CrearOpcionDetalles(Opcion opcion, SqlCommand command) {

            try {
                foreach (var detalle in opcion.Detalles) {
                    CrearOpcionDetalle(opcion, detalle, command);
                }

                return new ResultadoTransaccion();
            } catch (Exception e) {
                throw e;
            }
        }

        public static ResultadoTransaccion ObtieneCotizacionDirecta(Int32 id) {
            var res = new ResultadoTransaccion();
            CotizacionDirecta cotizacion = null;
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
                res.Descripcion = "Se creo la cargo Exitosamente la cotizacion directa";

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

        public static ResultadoTransaccion Modificar(CotizacionDirecta cotizacionDirecta) {
            var Res = new ResultadoTransaccion();
            SqlTransaction trans = null;

            var cotizacionDB = ObtieneCotizacionDirecta(cotizacionDirecta.Id32).ObjetoTransaccion as CotizacionDirecta;
            //Abrir Conexion
            var conn = BaseDatos.Conexion();
            try {
                SqlCommand command = new SqlCommand("SP_A_COTIZACION_SOLICITUD_COTIZACIONES", conn);

                command.Transaction = conn.BeginTransaction();
                trans = command.Transaction;

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", cotizacionDirecta.Id32);
                command.Parameters.AddWithValue("@Producto", cotizacionDirecta.Producto);
                command.Parameters.AddWithValue("@idUsuario", cotizacionDirecta.Usuario.Id32);
                command.Parameters.AddWithValue("@idCliente", cotizacionDirecta.Cliente.Id32);
                command.Parameters.AddWithValue("@nombreCliente", cotizacionDirecta.NombreCliente);
                command.Parameters.AddWithValue("@fechaSolicitud", cotizacionDirecta.FechaSolicitud);
                command.Parameters.AddWithValue("@idIncoterms", cotizacionDirecta.IncoTerm.Id32);
                command.Parameters.AddWithValue("@commodity", cotizacionDirecta.Commodity);
                command.Parameters.AddWithValue("@puertoEmbarque", "");
                command.Parameters.AddWithValue("@navieraReferencia", "");
                command.Parameters.AddWithValue("@tarifaReferencia", "");
                command.Parameters.AddWithValue("@Observaciones", cotizacionDirecta.Observaciones);
                command.Parameters.AddWithValue("@mercaderia", "");
                command.Parameters.AddWithValue("@gastosLocales", cotizacionDirecta.GastosLocales);
                command.Parameters.AddWithValue("@proveedorCarga", "");
                command.Parameters.AddWithValue("@credito", "");
                command.Parameters.AddWithValue("@fechaEstimadaEmbarque", "");
                command.Parameters.AddWithValue("@conAgenciamento", false);

                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteScalar();

                ModificarOpciones(cotizacionDirecta, command);

                //Marcamos las opciones que el usuario marco para borrar.
                foreach (var opcion in cotizacionDB.Opciones) {
                    var op = cotizacionDirecta.Opciones.Find(foo => foo.Id32 == opcion.Id32);
                    if (op == null)
                        EliminaOpcion(opcion, command);
                }

                ClsGastosLocalesDao.Eliminar(cotizacionDirecta, command);
                ClsGastosLocalesDao.CrearGastosLocales(cotizacionDirecta, command);

                //Ejecutar transaccion
                trans.Commit();
                Res.Estado = Entidades.Enums.Enums.EstadoTransaccion.Aceptada;
                Res.Descripcion = "Se modificó la cotización correctamente";
            } catch (Exception ex) {
                if (trans != null)
                    trans.Rollback();
                Log.EscribirLog(ex.Message);
                Res.Descripcion = ex.Message;
                Res.ArchivoError = NombreClase;
                Res.MetodoError = MethodBase.GetCurrentMethod().Name;
            } finally {
                conn.Close();
            }
            return Res;
        }

        private static void EliminaOpcion(Opcion op, SqlCommand command) {
            try {
                var com = command.Connection.CreateCommand();
                com.Transaction = command.Transaction;

                com.CommandText = "SP_E_COTIZACION_DIRECTA_OPCIONES";

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", op.Id32);

                com.CommandType = CommandType.StoredProcedure;
                com.ExecuteNonQuery();

            } catch (Exception e) {
                throw e;
            }
        }

        private static void ModificarOpcion(CotizacionDirecta cotizacionDirecta, Opcion o, SqlCommand command) {
            var com = command.Connection.CreateCommand();
            com.Transaction = command.Transaction;

            com.CommandText = "SP_A_COTIZACION_DIRECTA_OPCIONES";

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", o.Id32);
            com.Parameters.AddWithValue("@numero", o.Numero);
            com.Parameters.AddWithValue("@fechaValidezInicio", o.FechaValidezInicio);
            com.Parameters.AddWithValue("@fechaValidezFin", o.FechaValidezFin);
            com.Parameters.AddWithValue("@Naviera", o.Naviera.Id32);
            com.Parameters.AddWithValue("@TiempoTransito", o.TiempoTransito);
            com.Parameters.AddWithValue("@idUsuario", o.Usuario.Id32);
            com.Parameters.AddWithValue("@idTipoServicio", o.TiposServicio.Id32);
            if (o.TipoVia != null)
                com.Parameters.AddWithValue("@idTipoVia", o.TipoVia.Id32);
            else
                com.Parameters.AddWithValue("@idTipoVia", DBNull.Value);

            com.CommandType = CommandType.StoredProcedure;

            com.ExecuteScalar();
            ModificarDetalle(o, command);
            ModificarRelacionPuertos(o, command);
        }

        public static ResultadoTransaccion ModificarOpciones(CotizacionDirecta cotizacionDirecta, SqlCommand command) {
            var num = 1;
            try {
                foreach (var o in cotizacionDirecta.Opciones) {
                    if (o.IsNew == false) {
                        ModificarOpcion(cotizacionDirecta, o, command);
                    } else {
                        o.Numero = String.Format("{0:d4}-{1:d4}", cotizacionDirecta.Id32, num);
                        CrearOpcion(cotizacionDirecta, o, command);
                    }
                    num++;
                }
                return new ResultadoTransaccion();
            } catch (Exception e) {
                throw e;
            }
        }

        public static ResultadoTransaccion ModificarDetalle(Opcion opcion, SqlCommand command) {
            try {
                EliminarDetallesDeOpcion(opcion, command);
                foreach (var detalle in opcion.Detalles) {

                    detalle.Id = detalle.Id32 = 0;
                }

                foreach (var detalle in opcion.Detalles) {
                    if (detalle.IsNew)
                        CrearOpcionDetalle(opcion, detalle, command);
                }

                return new ResultadoTransaccion();
            } catch (Exception e) {
                throw e;
            }
        }

        private static void EliminarDetallesDeOpcion(Opcion opcion, SqlCommand command) {
            var com = command.Connection.CreateCommand();
            com.Transaction = command.Transaction;

            com.CommandText = "SP_E_COTIZACION_DIRECTA_OPCIONES_DETALLES_POR_OPCION";

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id_opcion", opcion.Id);
            com.CommandType = CommandType.StoredProcedure;
            com.ExecuteScalar();
        }

        public static void EliminarRelacionPuertosDeOpcion(Opcion opcion, SqlCommand command) {
            var com = command.Connection.CreateCommand();
            com.Transaction = command.Transaction;

            com.CommandText = "SP_E_COTIZACION_DIRECTA_OPCIONES_PUERTOS";

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id_opcion", opcion.Id);
            com.CommandType = CommandType.StoredProcedure;
            com.ExecuteNonQuery();

        }

        public static ResultadoTransaccion ModificarRelacionPuertos(Opcion opcion, SqlCommand command) {
            try {

                EliminarRelacionPuertosDeOpcion(opcion, command);
                foreach (var puerto in opcion.Pod)
                    puerto.Id = puerto.Id32 = 0;

                foreach (var puerto in opcion.Pol)
                    puerto.Id = puerto.Id32 = 0;

                CrearRelacionPuertos(opcion, command);
                return new ResultadoTransaccion();
            } catch (Exception e) {
                throw e;
            }
        }

        public static ResultadoTransaccion GuardarFollowUps(IList<clsClienteFollowUp> followDatabase,
                                                            CotizacionDirecta cotizacionDirecta) {
            ResultadoTransaccion resTransaccion = new ResultadoTransaccion();
            var conn = BaseDatos.Conexion();
            try {
                //conn.Open();
                var transaction = BaseDatos.Conexion().BeginTransaction();


                foreach (var followUp in cotizacionDirecta.FollowUps) {
                    if (followUp.IsNew)
                        resTransaccion = clsClienteMasterADO.AgregarFollowUpClienteMaster(followUp, transaction);
                    else
                        resTransaccion = clsClienteMasterADO.ModificarFollowUpClienteMaster(followUp,
                                                                                                     transaction);
                    //Ejecutar transaccion
                    if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                        throw new Exception(resTransaccion.Descripcion);
                }

                if (!cotizacionDirecta.IsNew) {
                    var newlist = cotizacionDirecta.FollowUps.ToList();
                    foreach (var followUp in followDatabase) {
                        var encontrado = newlist.Find(foo => foo.Id32.Equals(followUp.Id32));
                        if (encontrado == null) {
                            resTransaccion = Clientes.clsClienteMasterADO.EliminarLogicoFollowUpClienteMaster(followUp,
                                                                                                              transaction);
                            if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                                throw new Exception(resTransaccion.Descripcion);
                        }
                    }
                }

                resTransaccion.Descripcion = "Se registró los Followup Exitosamente";
                transaction.Commit();

            } catch (Exception e) {
                Log.EscribirLog(e.Message);

            } finally {
                conn.Close();
            }
            return resTransaccion;
        }
    }
}
