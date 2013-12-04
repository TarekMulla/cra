using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.AccesoDatos.Clientes;
using ProyectoCraft.AccesoDatos.Usuarios;
using ProyectoCraft.AccesoDatos.Direccion;
using ProyectoCraft.AccesoDatos.Parametros;
using ProyectoCraft.AccesoDatos.Ventas;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Ventas.Productos;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.Entidades.Paperless;
using ProyectoCraft.Entidades.Direccion.Metas;
using ProyectoCraft.Entidades.Clientes;

namespace ProyectoCraft.AccesoDatos.Direccion.Metas {
    public class ClsSalesLeadAdo {
        private static SqlParameter[] objParams = null;
        private static SqlConnection conn = null;
        private static SqlTransaction transaction = null;
        private static SqlDataReader dreader = null;
        public static ResultadoTransaccion GuardarVariosClsSalesLead(IList<ClsSalesLead> ListaSalesLead) {
            ResultadoTransaccion Res = new ResultadoTransaccion();
            //Abrir Conexion
            conn = BaseDatos.Conexion();
            //Crear Transaccion
            transaction = conn.BeginTransaction();
            try {
                foreach (ClsSalesLead salesLead in ListaSalesLead) 
                {
                    //Graba Encabezado SalesLead 
                    Res = GuardarSalesLead(salesLead);

                    if (Res.Estado == Enums.EstadoTransaccion.Aceptada) 
                    {
                        foreach (var followUp in salesLead.FollowUps)
                        {
                            followUp.IdSalesLead = salesLead.Id32;
                        }
                        // Guardar Primer Follow Up del SalesLead
                        Res = GuardarFollowups(new List<clsClienteFollowUp>(), salesLead);
                        // Guardar Asignacion del SalesLead
                        Res = GuardarSalesLeadUsuario(salesLead.Id, salesLead.Asignacion.VendedorAsignado.Id, salesLead.FechaApertura);
                        // Guardar Competencia
                        foreach (clsMetaCompetencia Competencia in salesLead.Competencias)
                        {
                            Res = ClsSalesLeadAdo.GuardarSalesLeadCompetencia( salesLead.Id, Competencia);
                            if (Res.Estado == ProyectoCraft.Entidades.Enums.Enums.EstadoTransaccion.Rechazada)
                            {
                                transaction.Rollback();
                                Log.EscribirLog(Res.Descripcion);
                                return Res;
                            }
                        }
                        // Guardar Terminos de Compra
                        foreach (var TerminosCompra in salesLead.TerminosCompra)
                        {
                            Res = ClsSalesLeadAdo.GuardarTerminosCompra(salesLead.Id, TerminosCompra.Codigo);
                            if (Res.Estado == ProyectoCraft.Entidades.Enums.Enums.EstadoTransaccion.Rechazada)
                            {
                                transaction.Rollback();
                                Log.EscribirLog(Res.Descripcion);
                                return Res;
                            }
                        }
                        // Guardar Tipo Productos
                        foreach (clsTipoProducto Producto in salesLead.TiposProductos) {
                            Res = GuardarTiposProductos(salesLead.Id, Producto.Id);
                            if (Res.Estado == Enums.EstadoTransaccion.Rechazada) {
                                transaction.Rollback();
                                Log.EscribirLog(Res.Descripcion);
                                return Res;
                            }
                        }

                        //guardar Incoterms
                        foreach (var objParam in salesLead.Incoterms) {
                            Res = GuardarIncoteterm(salesLead.Id, objParam.Id);
                            if (Res.Estado == Enums.EstadoTransaccion.Rechazada) {
                                transaction.Rollback();
                                Log.EscribirLog(Res.Descripcion);
                                return Res;
                            }
                        }
                    }
                }
                //Ejecutar transaccion
                transaction.Commit();
                Res.Estado = Enums.EstadoTransaccion.Aceptada;
                Res.Descripcion = "Se registró la asignación de Sales Lead correctamente";
            } catch (Exception ex) {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                Res.Descripcion = ex.Message;
                Res.ArchivoError = "clsSalesLeadAdo.cs";
                Res.MetodoError = "GuardarVariosClsSalesLead";
                Res.Estado = Enums.EstadoTransaccion.Rechazada;
            } finally {
                conn.Close();
            }
            return Res;
        }

        public static ResultadoTransaccion ListarSalesLeadCompetencias(Int32 idSalesLead) {
            ResultadoTransaccion res = new ResultadoTransaccion();
            var clsMetaCompetencias = new List<clsMetaCompetencia>();
            try {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_DIRECCION_SLEAD_COMPETENCIA");

                SqlCommand command = new SqlCommand("SP_C_DIRECCION_SLEAD_COMPETENCIA", conn);
                objParams[0].Value = idSalesLead;

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read()) {
                    var objSLeasMetaComepentecia = new clsMetaCompetencia();

                    objSLeasMetaComepentecia.Id = Convert.ToInt32(dreader[0]);
                    objSLeasMetaComepentecia.Descripcion = dreader[2].ToString().Trim();
                    if (!String.IsNullOrEmpty(dreader[3].ToString()))
                        objSLeasMetaComepentecia.TipoCompetencia = clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader[3].ToString().Trim()));
                    clsMetaCompetencias.Add(objSLeasMetaComepentecia);
                }
                res.Accion = Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = clsMetaCompetencias;
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsSalesLeadAdo.cs";
                res.MetodoError = "ListarSalesLeadCompetencias";
            } finally {
                conn.Close();
            }
            return res;
            
        }
       
        public static ResultadoTransaccion ListarSalesLeadTerminosDeCompras(Int32 idSalesLead) {
            ResultadoTransaccion res = new ResultadoTransaccion();
            var clsItemParametros = new List<clsItemParametro>();
            try {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "[SP_C_DIRECCION_SLEAD_TERMINOS_COMPRA]");

                SqlCommand command = new SqlCommand("[SP_C_DIRECCION_SLEAD_TERMINOS_COMPRA]", conn);
                objParams[0].Value = idSalesLead;

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read()) {
                    var objclsItemParametro = new clsItemParametro();

                    objclsItemParametro.Id = Convert.ToInt32(dreader[0].ToString());
                    objclsItemParametro.Codigo = dreader[1].ToString();
                    objclsItemParametro.Nombre = dreader[2].ToString().Trim();

                    clsItemParametros.Add(objclsItemParametro);

                }
                res.Accion = Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = clsItemParametros;
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsSalesLeadAdo.cs";
                res.MetodoError = "ListarSalesLeadTerminosDeCompras";
            } finally {
                conn.Close();
            }
            return res;

        }

        public static ResultadoTransaccion ListarIncoterms(Int32 idSalesLead) {
            ResultadoTransaccion res = new ResultadoTransaccion();
            var clsItemParametros = new List<clsItemParametro>();
            try {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "[SP_C_DIRECCION_SLEAD_INCOTERMS]");

                SqlCommand command = new SqlCommand("[SP_C_DIRECCION_SLEAD_INCOTERMS]", conn);
                objParams[0].Value = idSalesLead;

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read()) {
                    var objclsItemParametro = new clsItemParametro();
                    objclsItemParametro.Id = Convert.ToInt32(dreader[0].ToString());
                    objclsItemParametro.Codigo = dreader[1].ToString();
                    objclsItemParametro.Nombre = dreader[2].ToString().Trim();
                    clsItemParametros.Add(objclsItemParametro);

                }
                res.Accion = Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = clsItemParametros;
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsSalesLeadAdo.cs";
                res.MetodoError = "ListarIncoterms";
            } finally {
                conn.Close();
            }
            return res;
        }

        public static ResultadoTransaccion ListarTiposDeProductos(Int32 idSalesLead) {
            ResultadoTransaccion res = new ResultadoTransaccion();
            try {
                res = clsTipoProductosADO.ListarTiposProductosPorIdSalesLead(idSalesLead);
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsSalesLeadAdo.cs";
                res.MetodoError = "ListarTiposDeProductos";
            } finally {
                conn.Close();
            }
            return res;
        }
        
        private static List<ClsSalesLead> CargarDatosDataReader(SqlDataReader dreader) {
            var SalesLead = new List<ClsSalesLead>();
            while (dreader.Read()) {
                ClsSalesLead ObjSLead = new ClsSalesLead();

                ObjSLead.Id = Convert.ToInt32(dreader[0]);
                ObjSLead.Reference = dreader[1].ToString().Trim();
                ObjSLead.ShipperNombre = dreader[2].ToString().Trim();
                ObjSLead.ShipperZipCode = dreader[16].ToString().Trim();
                ObjSLead.ShipperCiudad = dreader[17].ToString().Trim();
                ObjSLead.ShipperContacto = dreader[18].ToString().Trim();
                ObjSLead.ShipperEmail = dreader[19].ToString().Trim();
                ObjSLead.ShipperWeb = dreader[20].ToString().Trim();
                ObjSLead.ShipperFono = dreader[44].ToString().Trim();
                ObjSLead.ShipperPais = dreader[45].ToString().Trim();
                ObjSLead.Shipperdireccion = dreader[46].ToString().Trim();

                ObjSLead.ConsigNombre = dreader[21].ToString().Trim();
                ObjSLead.ConsigDireccion = dreader[22].ToString().Trim();
                ObjSLead.Consigciudad = dreader[23].ToString().Trim();
                ObjSLead.ConsigTelefono = dreader[24].ToString().Trim();
                ObjSLead.ConsigContacto = dreader[25].ToString().Trim();
                ObjSLead.ConsigEmail = dreader[42].ToString();

                ObjSLead.GlosaCommodity = dreader[26].ToString().Trim();

                ObjSLead.Pol = dreader[27].ToString().Trim();
                ObjSLead.Pod = dreader[28].ToString().Trim();
                ObjSLead.CarrierAirline = dreader[29].ToString().Trim();
                ObjSLead.CarrierAirline = dreader[29].ToString().Trim();
                if (!String.IsNullOrEmpty(dreader[30].ToString()))
                    ObjSLead.EmbarquesPorMes = Convert.ToInt32(dreader[30]);

                if (!String.IsNullOrEmpty(dreader[31].ToString()))
                    ObjSLead.FechaUltimoEmbarque = Convert.ToDateTime(dreader[31]);


                ObjSLead.Agente = new PaperlessAgente();
                ObjSLead.Agente.Id = Convert.ToInt32(dreader[3]);
                ObjSLead.Agente.Nombre = dreader[4].ToString().Trim();
                ObjSLead.Agente.Contacto = dreader[5].ToString().Trim();
                ObjSLead.Agente.Email = dreader[6].ToString().Trim();

                ObjSLead.Asignacion = new ClsSalesLeadAsignacion();
                ObjSLead.Asignacion.VendedorAsignado = new clsUsuario();
                ObjSLead.Asignacion.VendedorAsignado.Id = Convert.ToInt32(dreader[7]);
                ObjSLead.Asignacion.VendedorAsignado.NombreUsuario = dreader[8].ToString().Trim();
                ObjSLead.Asignacion.VendedorAsignado.Nombre = dreader[32].ToString().Trim();
                ObjSLead.Asignacion.VendedorAsignado.ApellidoPaterno = dreader[33].ToString().Trim();
                ObjSLead.Asignacion.VendedorAsignado.ApellidoMaterno = dreader[34].ToString().Trim();
                ObjSLead.Asignacion.VendedorAsignado.Email = dreader[35].ToString().Trim();

                ObjSLead.EstadoSLead = (Enums.EstadosSLead)Convert.ToInt16(dreader[9]);
                ObjSLead.FechaApertura = Convert.ToDateTime(dreader[10]);
                ObjSLead.FechaUltActulizacion = Convert.ToDateTime(dreader[12]);
                ObjSLead.GlosaSalesLead = dreader[14].ToString().Trim();
                ObjSLead.ConsigNombre = dreader[15].ToString().Trim();

                if (!String.IsNullOrEmpty(dreader[36].ToString()))
                    ObjSLead.AereoCantidad = Convert.ToInt64(dreader[36].ToString().Trim());

                if (!String.IsNullOrEmpty(dreader[37].ToString()))
                    ObjSLead.AereoMedida = clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader[37].ToString().Trim()));


                if (!String.IsNullOrEmpty(dreader[38].ToString()))
                    ObjSLead.FCLCantidad = Convert.ToInt64(dreader[38].ToString().Trim());

                if (!String.IsNullOrEmpty(dreader[39].ToString()))
                    ObjSLead.FCLMedida = clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader[39].ToString().Trim()));

                if (!String.IsNullOrEmpty(dreader[40].ToString()))
                    ObjSLead.LCLCantidad = Convert.ToInt64(dreader[40].ToString().Trim());

                if (!String.IsNullOrEmpty(dreader[41].ToString()))
                    ObjSLead.LCLMedida = clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader[41].ToString().Trim()));


                if (!String.IsNullOrEmpty(dreader[43].ToString()))
                    ObjSLead.ObjTipoContenedor = clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader[43].ToString().Trim()));

                ObjSLead.UsuarioAsignador = (clsUsuario)clsUsuarioADO.ObtenerTransaccionUsuarioPorId(Convert.ToInt16(dreader[47].ToString().Trim())).ObjetoTransaccion;
                SalesLead.Add(ObjSLead);
            }
            dreader.Close();

            foreach (var clsSalesLead in SalesLead) {
                clsSalesLead.Competencias = ListarSalesLeadCompetencias(clsSalesLead.Id32).ObjetoTransaccion as IList<clsMetaCompetencia>;
                clsSalesLead.TerminosCompra = ListarSalesLeadTerminosDeCompras(clsSalesLead.Id32).ObjetoTransaccion as IList<clsItemParametro>;
                clsSalesLead.Incoterms=  ListarIncoterms(clsSalesLead.Id32).ObjetoTransaccion as IList<clsItemParametro>;
                clsSalesLead.FollowUps = clsClienteMasterADO.ObtenerFollowUpClientePorSalesLead(clsSalesLead.Id32);
                clsSalesLead.TiposProductos = ListarTiposDeProductos(clsSalesLead.Id32).ObjetoTransaccion as IList<clsTipoProducto>;
            }
            return SalesLead;
        } 
    
        public static ResultadoTransaccion ListarSalesLeadUsuarioEstado(long IdVendedor, string Estados)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_DIRECCION_SLEAD_VENDEDOR");

                SqlCommand command = new SqlCommand("SP_C_DIRECCION_SLEAD_VENDEDOR", conn);
                objParams[0].Value = IdVendedor;
                objParams[1].Value = Estados;

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                var salesLeads = CargarDatosDataReader(dreader);
             

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = salesLeads;
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsSalesLeadAdo.cs";
                res.MetodoError = "ListarSalesLead";
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
        
        private static ResultadoTransaccion GuardarSalesLead(ClsSalesLead salesLead) {
            ResultadoTransaccion res = new ResultadoTransaccion();
            try {
                
                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_DIRECCION_SLEAD");
                objParams[0].Value = salesLead.EstadoSLead;
                objParams[1].Value = salesLead.GlosaSalesLead;
                objParams[2].Value = salesLead.FechaApertura;
                objParams[3].Value = salesLead.FechaRevision;
                objParams[4].Value = salesLead.UsuarioAsignador.Id;
                objParams[5].Value = salesLead.ShipperNombre;
                objParams[6].Value = salesLead.Shipperdireccion;
                objParams[7].Value = salesLead.ShipperZipCode;
                objParams[8].Value = salesLead.ShipperCiudad;
                objParams[9].Value = salesLead.ShipperContacto;
                objParams[10].Value = salesLead.ShipperEmail;
                objParams[11].Value = salesLead.ShipperWeb;
                objParams[12].Value = salesLead.ConsigNombre;
                objParams[13].Value = salesLead.ConsigDireccion;
                objParams[14].Value = salesLead.Consigciudad;
                objParams[15].Value = salesLead.ConsigTelefono;
                objParams[16].Value = salesLead.ConsigContacto;
                objParams[17].Value = salesLead.GlosaCommodity;
                objParams[18].Value = salesLead.EmbarquesPorMes;
                objParams[19].Value = salesLead.LCLCantidad;
                objParams[20].Value = salesLead.LCLMedida.Id;
                objParams[21].Value = salesLead.FCLCantidad;
                objParams[22].Value = salesLead.FCLMedida.Id;
                objParams[23].Value = salesLead.AereoCantidad;
                objParams[24].Value = salesLead.AereoMedida.Id;
                objParams[25].Value = salesLead.Pol;
                objParams[26].Value = salesLead.FechaUltimoEmbarque;
                objParams[27].Value = salesLead.CarrierAirline;
                objParams[28].Value = salesLead.Pod;
                objParams[29].Value = salesLead.Agente.Id;
                objParams[30].Value = salesLead.Asignacion.VendedorAsignado.Id;
                objParams[31].Value = salesLead.ConsigEmail;
                objParams[32].Value = salesLead.ObjTipoContenedor.Id32;
                objParams[33].Value = salesLead.ShipperFono;
                objParams[34].Value = salesLead.ShipperPais;

                objParams[35].Direction = ParameterDirection.Output;
                objParams[36].Direction = ParameterDirection.Output;

                SqlCommand command = new SqlCommand("SP_N_DIRECCION_SLEAD", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                salesLead.Reference = objParams[35].Value.ToString();
                salesLead.Id = Convert.ToInt32(objParams[36].Value);

                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se registró la asiganción del SalesLead correctamente";
                
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsSalesLeadAdo.cs";
                res.MetodoError = "GuardarSalesLead";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            } finally {
            }
            return res;
        }
       
        public static ResultadoTransaccion GuardarFollowups(IList<clsClienteFollowUp> followDatabase, ClsSalesLead salesLead) {
            ResultadoTransaccion resTransaccion = new ResultadoTransaccion();
            foreach (var followUp in salesLead.FollowUps) {
                if (followUp.IsNew)
                    resTransaccion = Clientes.clsClienteMasterADO.AgregarFollowUpClienteMaster(followUp, transaction);
                else
                    resTransaccion = Clientes.clsClienteMasterADO.ModificarFollowUpClienteMaster(followUp, transaction);

                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);
            }

            if (!salesLead.IsNew) {
                var newlist = salesLead.FollowUps.ToList();
                foreach (var followUp in followDatabase) {
                    var encontrado = newlist.Find(foo => foo.Id32.Equals(followUp.Id32));
                    if (encontrado == null) {
                        resTransaccion = Clientes.clsClienteMasterADO.EliminarLogicoFollowUpClienteMaster(followUp, transaction);
                        if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                            throw new Exception(resTransaccion.Descripcion);
                    }
                }
            }

            resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
            resTransaccion.Accion = Enums.AccionTransaccion.Insertar;
            resTransaccion.ObjetoTransaccion = salesLead;
            resTransaccion.Descripcion = "Se registró los Followup Exitosamente";
            return resTransaccion;
        }
        
        private static ResultadoTransaccion GuardarTiposProductos(long idSalesLead, long IdTipoProducto) {
            ResultadoTransaccion res = new ResultadoTransaccion();
            long Id;
            try {
                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_DIRECCION_SLEAD_TIPO_PROD");
                objParams[0].Value = idSalesLead;
                objParams[1].Value = IdTipoProducto;

                SqlCommand command = new SqlCommand("SP_N_DIRECCION_SLEAD_TIPO_PROD", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                Id = Convert.ToInt32(command.ExecuteScalar());

                //Ejecutar transaccion
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se registró la información de productos correctamente";
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsSalesLeadAdo.cs";
                res.MetodoError = "GuardarTiposProducto";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            } finally {
            }
            return res;
        }
        private static ResultadoTransaccion EliminarTipoProducto(long idSalesLead) {
            ResultadoTransaccion res = new ResultadoTransaccion();
            long Id;
            try {
                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_E_DIRECCION_SLEAD_TIPO_PROD");
                objParams[0].Value = idSalesLead;

                SqlCommand command = new SqlCommand("SP_E_DIRECCION_SLEAD_TIPO_PROD", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                //Ejecutar transaccion
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se registró la información de productos correctamente";
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsSalesLeadAdo.cs";
                res.MetodoError = "GuardarTiposProducto";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            } finally {
            }
            return res;
        }

        private static ResultadoTransaccion GuardarIncoteterm(long idSalesLead, long idincoterms) {
            ResultadoTransaccion res = new ResultadoTransaccion();
            long Id;
            try {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_DIRECCION_SLEAD_INCOTERMS");
                objParams[0].Value = idSalesLead;
                objParams[1].Value = idincoterms;

                SqlCommand command = new SqlCommand("SP_N_DIRECCION_SLEAD_INCOTERMS", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                Id = Convert.ToInt32(command.ExecuteScalar());

                //Ejecutar transaccion
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se registró la información de incoterms correctamente";
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsSalesLeadAdo.cs";
                res.MetodoError = "GuardarIncoteterm";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            } finally {
            }
            return res;
        }
        private static ResultadoTransaccion EliminarIncoteterm(long idSalesLead) {
            ResultadoTransaccion res = new ResultadoTransaccion();
            long Id;
            try {
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_E_DIRECCION_SLEAD_INCOTERMS");
                objParams[0].Value = idSalesLead;
                

                SqlCommand command = new SqlCommand("SP_E_DIRECCION_SLEAD_INCOTERMS", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                Id = Convert.ToInt32(command.ExecuteScalar());

                //Ejecutar transaccion
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se registró la información de incoterms correctamente";
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsSalesLeadAdo.cs";
                res.MetodoError = "GuardarIncoteterm";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            } finally {
            }
            return res;
        }
        
        private static ResultadoTransaccion GuardarTerminosCompra(long idSalesLead, string CodTermCompra)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            long Id;
            try
            {
                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_DIRECCION_SLEAD_TERM_COMPRA");
                objParams[0].Value = idSalesLead;
                objParams[1].Value = CodTermCompra;

                SqlCommand command = new SqlCommand("SP_N_DIRECCION_SLEAD_TERM_COMPRA", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                Id = Convert.ToInt32(command.ExecuteScalar());

                //Ejecutar transaccion
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se registró la información de terminos de compra correctamente";
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsSalesLeadAdo.cs";
                res.MetodoError = "GuardarTerminosCompra";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            }
            finally
            {
            }
            return res;
        }
        private static ResultadoTransaccion EliminarTerminosCompra(long idSalesLead) {
            ResultadoTransaccion res = new ResultadoTransaccion();
            long Id;
            try {
                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_E_DIRECCION_SLEAD_TERM_COMPRA");
                objParams[0].Value = idSalesLead;

                SqlCommand command = new SqlCommand("[SP_E_DIRECCION_SLEAD_TERM_COMPRA]", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                //Ejecutar transaccion
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se registró la información de terminos de compra correctamente";
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsSalesLeadAdo.cs";
                res.MetodoError = "EliminarTerminosCompra";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            } finally {
            }
            return res;
        }
        
        public static ResultadoTransaccion GuardarSalesLeadUsuario(long idSalesLead, long IdVenedorAsignado, DateTime FechaAsignacion) {
            ResultadoTransaccion res = new ResultadoTransaccion();
            long Id;
            try {
                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_DIRECCION_SLEAD_ASIGNACION");
                objParams[0].Value = idSalesLead;
                objParams[1].Value = IdVenedorAsignado;
                objParams[2].Value = FechaAsignacion;

                SqlCommand command = new SqlCommand("SP_N_DIRECCION_SLEAD_ASIGNACION", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                Id = Convert.ToInt32(command.ExecuteScalar());

                //Ejecutar transaccion
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se registró la asignación correctamente";
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsSalesLeadAdo.cs";
                res.MetodoError = "GuardarSalesLeadUsuario";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            }
            return res;
        }
        
        private static ResultadoTransaccion GuardarSalesLeadCompetencia(long IdSLead, clsMetaCompetencia ObjCompetenciaSLead)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            try
            {
                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_DIRECCION_SLEAD_COMPETENCIA");
                objParams[0].Value = IdSLead;
                objParams[1].Value = ObjCompetenciaSLead.Descripcion;
                objParams[2].Value = ObjCompetenciaSLead.TipoCompetencia.Id;

                SqlCommand command = new SqlCommand("SP_N_DIRECCION_SLEAD_COMPETENCIA", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                ObjCompetenciaSLead.Id = Convert.ToInt32(command.ExecuteScalar());

                //Ejecutar transaccion
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se registraron los datos de competencia correctamente";

            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsMetaAdo.cs";
                res.MetodoError = "GuardarProspectoCompetencia";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            }
            finally
            {
            }
            return res;
        }
        private static ResultadoTransaccion EliminarCompetencias(long IdSLead) {
            ResultadoTransaccion res = new ResultadoTransaccion();
            try {
                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_E_DIRECCION_SLEAD_COMPETENCIA");
                objParams[0].Value = IdSLead;
                
                SqlCommand command = new SqlCommand("SP_E_DIRECCION_SLEAD_COMPETENCIA", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                //Ejecutar transaccion
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se registraron los datos de competencia correctamente";

            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsMetaAdo.cs";
                res.MetodoError = "EliminarCompetencias";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            } finally {
            }
            return res;
        }
        
        public static ResultadoTransaccion ListarSLeads()
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_DIRECCION_GESTION_SLEAD");

                SqlCommand command = new SqlCommand("SP_C_DIRECCION_GESTION_SLEAD", conn);

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                var saleLeads = CargarDatosDataReader(dreader);
                res.Accion = Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = saleLeads;
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsSalesLeadAdo.cs";
                res.MetodoError = "ListarSLeads";
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
        
        public static DataTable PreparaGraficaEstadoAgente(string Estados, long IdAgente, DateTime FechaDesde, DateTime FechaHasta)
        {
            DataTable Grafica = new DataTable("Grafico");
            try
            {
                string Estado;
                string Agente;
                Int32 Value;

                //Abrir Conexion
                conn = BaseDatos.Conexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_DIRECCION_SLEAD_GRAFICO_ESTADO_AGENTE");

                SqlCommand command = new SqlCommand("SP_C_DIRECCION_SLEAD_GRAFICO_ESTADO_AGENTE", conn);
                objParams[0].Value = Estados;
                objParams[1].Value = FechaDesde;
                objParams[2].Value = FechaHasta;
                objParams[3].Value = IdAgente;

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                Grafica.Columns.Add("Estado", typeof(String));
                Grafica.Columns.Add("Agente", typeof(String));
                Grafica.Columns.Add("Value", typeof(Int32));

                while (dreader.Read())
                {
                    Estado = dreader[0].ToString().Trim();
                    Agente = dreader[1].ToString().Trim();
                    Value = Convert.ToInt32(dreader[2]);
                    Grafica.Rows.Add(new object[] { Estado, Agente, Value });
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
            return Grafica;
        }
       
        public static ResultadoTransaccion EliminarSalesLeadObservacion(long IdObservacion)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            long Id;
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_E_DIRECCION_SLEAD_OBSERVACION");
                objParams[0].Value = IdObservacion;

                SqlCommand command = new SqlCommand("SP_E_DIRECCION_SLEAD_OBSERVACION", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                //Ejecutar transaccion
                transaction.Commit();
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se eliminó la observacion correctamente";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsSalesLeadAdo.cs";
                res.MetodoError = "EliminarSalesLeadObservacion";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
        
        public static ResultadoTransaccion GuardarSalesLeadObservacion(long IdSalesLead, clsSalesLeadObservaciones ObjObservacion, ref string ModificaGlosa)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            long Id;
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_DIRECCION_SLEAD_OBSERVACION");
                objParams[0].Value = ObjObservacion.Id;
                objParams[1].Value = IdSalesLead;
                objParams[2].Value = ObjObservacion.ObjUsuario.Id;
                objParams[3].Value = ObjObservacion.FechaHora;
                objParams[4].Value = ObjObservacion.Observacion;
                objParams[5].Direction = ParameterDirection.Output;
                objParams[6].Direction = ParameterDirection.Output;

                SqlCommand command = new SqlCommand("SP_N_DIRECCION_SLEAD_OBSERVACION", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                ObjObservacion.Id = Convert.ToInt32(objParams[5].Value);
                ModificaGlosa = objParams[6].Value.ToString();
                //ObjObservacion.Id = Convert.ToInt32(command.ExecuteScalar());

                //Ejecutar transaccion
                transaction.Commit();
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se registró la observacion correctamente";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsSalesLeadAdo.cs";
                res.MetodoError = "GuardarSalesLeadObservacion";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
        
        public static ResultadoTransaccion ListarObservacionesSalesLead(long IdSalesLead)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            IList<clsSalesLeadObservaciones> Observaciones = new List<clsSalesLeadObservaciones>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_DIRECCION_SLEAD_OBSERVACION");

                SqlCommand command = new SqlCommand("SP_C_DIRECCION_SLEAD_OBSERVACION", conn);

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                objParams[0].Value = IdSalesLead;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    clsSalesLeadObservaciones ObjObservacion = new clsSalesLeadObservaciones();

                    ObjObservacion.Id = Convert.ToInt32(dreader[0]);
                    ObjObservacion.Observacion = dreader[1].ToString().Trim();
                    ObjObservacion.FechaHora = Convert.ToDateTime(dreader[2]); ;
                    ObjObservacion.ObjUsuario = new clsUsuario();
                    ObjObservacion.ObjUsuario.Id = Convert.ToInt32(dreader[3]); ;
                    ObjObservacion.ObjUsuario.NombreUsuario = dreader[4].ToString().Trim();
                    ObjObservacion.ObjUsuario.Email = dreader[5].ToString().Trim();
                    ObjObservacion.ObjUsuario.Nombre = dreader[6].ToString().Trim();

                    Observaciones.Add(ObjObservacion);
                }
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = Observaciones;
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsSalesLeadAdo.cs";
                res.MetodoError = "ListarObservacionesSalesLead";
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
        
        public static ResultadoTransaccion GuardarCancelacionSalesLead(long IdSalesLead, string Observaciones, DateTime FechaCancelacion)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();
                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_A_DIRECCION_SLEAD_CANCELA");
                objParams[0].Value = IdSalesLead;
                objParams[1].Value = Observaciones;
                objParams[2].Value = FechaCancelacion;

                SqlCommand command = new SqlCommand("SP_A_DIRECCION_SLEAD_CANCELA", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                //Ejecutar transaccion
                transaction.Commit();
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se registró el cambio de estado correctamente";

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsSalesLeadAdo.cs";
                res.MetodoError = "GuardarCancelacionSalesLead";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
        
        public static ResultadoTransaccion GuardarCierreSalesLead(long IdSalesLead,  string Observaciones, DateTime FechaCierre)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();
                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_A_DIRECCION_SLEAD_CIERRE");
                objParams[0].Value = IdSalesLead;
                objParams[1].Value = Observaciones;
                objParams[2].Value = FechaCierre;

                SqlCommand command = new SqlCommand("SP_A_DIRECCION_SLEAD_CIERRE", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                //Ejecutar transaccion
                transaction.Commit();
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se registró el cambio de estado correctamente";

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsSalesLeadAdo.cs";
                res.MetodoError = "GuardarCierreSalesLead";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            }
            finally
            {
                conn.Close();
            }
            return res;
        }

        public static ResultadoTransaccion EditarClsSalesLead(ClsSalesLead salesLead) {

            //cargando datos desde la base de datos
            var incotermDatabase = (List<clsItemParametro>)ListarIncoterms(salesLead.Id32).ObjetoTransaccion;
            
            
            conn = BaseDatos.Conexion();
            
            //Crear Transaccion
            transaction = conn.BeginTransaction();
            ResultadoTransaccion res = new ResultadoTransaccion();
            try {

                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_E_DIRECCION_SLEAD");
                objParams[0].Value = salesLead.EstadoSLead;
                objParams[1].Value = salesLead.GlosaSalesLead;
                objParams[2].Value = salesLead.FechaApertura;
                objParams[3].Value = salesLead.FechaRevision;
                objParams[4].Value = salesLead.UsuarioAsignador.Id;
                objParams[5].Value = salesLead.ShipperNombre;
                objParams[6].Value = salesLead.Shipperdireccion;
                objParams[7].Value = salesLead.ShipperZipCode;
                objParams[8].Value = salesLead.ShipperCiudad;
                objParams[9].Value = salesLead.ShipperContacto;
                objParams[10].Value = salesLead.ShipperEmail;
                objParams[11].Value = salesLead.ShipperWeb;
                objParams[12].Value = salesLead.ConsigNombre;
                objParams[13].Value = salesLead.ConsigDireccion;
                objParams[14].Value = salesLead.Consigciudad;
                objParams[15].Value = salesLead.ConsigTelefono;
                objParams[16].Value = salesLead.ConsigContacto;
                objParams[17].Value = salesLead.GlosaCommodity;
                objParams[18].Value = salesLead.EmbarquesPorMes;
                objParams[19].Value = salesLead.LCLCantidad;
                objParams[20].Value = salesLead.LCLMedida.Id;
                objParams[21].Value = salesLead.FCLCantidad;
                objParams[22].Value = salesLead.FCLMedida.Id;
                objParams[23].Value = salesLead.AereoCantidad;
                objParams[24].Value = salesLead.AereoMedida.Id;
                objParams[25].Value = salesLead.Pol;
                objParams[26].Value = salesLead.FechaUltimoEmbarque;
                objParams[27].Value = salesLead.CarrierAirline;
                objParams[28].Value = salesLead.Pod;
                objParams[29].Value = salesLead.Agente.Id;
                objParams[30].Value = salesLead.Asignacion.VendedorAsignado.Id;
                objParams[31].Value = salesLead.ConsigEmail;
                objParams[32].Value = salesLead.ObjTipoContenedor.Id32;
                objParams[33].Value = salesLead.ShipperFono;
                objParams[34].Value = salesLead.ShipperPais;

                objParams[35].Value = salesLead.Id32;

                SqlCommand command = new SqlCommand("SP_E_DIRECCION_SLEAD", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();





                //editando incoterms
                EliminarIncoteterm(salesLead.Id32);
                foreach (var incoterm in salesLead.Incoterms) {
                    GuardarIncoteterm(salesLead.Id32, incoterm.Id);
                }

                EliminarTerminosCompra(salesLead.Id32);
                foreach (var termino in salesLead.TerminosCompra) {
                    res = GuardarTerminosCompra(salesLead.Id32, termino.Codigo);
                }

                EliminarTipoProducto(salesLead.Id32);
                foreach (var tipoProducto in salesLead.TiposProductos) {
                    res = GuardarTiposProductos(salesLead.Id32, tipoProducto.Id);
                }

                EliminarCompetencias(salesLead.Id32);
                foreach (var competencia in salesLead.Competencias) {
                    res = GuardarSalesLeadCompetencia(salesLead.Id32, competencia);
                }

                transaction.Commit();

                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Sales Lead guardado Exitosamente";

            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsSalesLeadAdo.cs";
                res.MetodoError = "EditarClsSalesLead";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            } finally {
                conn.Close();
            }
            return res;
        }
    }
}