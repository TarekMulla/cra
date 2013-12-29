using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Direccion.Administracion;
using ProyectoCraft.Entidades.Clientes.Cuenta;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Tarifado;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Base.BaseDatos;
using System.Data.SqlClient;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Base.Log;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using ProyectoCraft.Entidades.Enums;
using System.Collections;

namespace ProyectoCraft.AccesoDatos.Direccion.Administracion
{
    public static class clsControlCreditoAdo
    {
        private static SqlParameter[] objParams = null;
        private static SqlConnection conn = null;
        private static SqlTransaction transaction = null;
        private static SqlDataReader dreader = null;

        public static ResultadoTransaccion ListarContrlDeudoresFecha(DateTime Fecha)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            ClsArrRegistrosGrilla ObjArrRegistrosGrilla = new ClsArrRegistrosGrilla();
            clsArregloDetGrilla ObjArregloDetGrilla = new clsArregloDetGrilla();
            clsRegistroGrilla ObjRegistroGrilla = new clsRegistroGrilla();

            string RutClienteActual="";
            int i = 0;
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "sp_c_direccion_control_deuda");
                objParams[0].Value = Fecha;

                SqlCommand command = new SqlCommand("sp_c_direccion_control_deuda", conn);

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    // primer cliente
                    if (i == 0)
                    {
                        ObjRegistroGrilla = new clsRegistroGrilla();
                        ObjRegistroGrilla.Cliente = dreader[1].ToString();
                        ObjRegistroGrilla.Rut = dreader[2].ToString();
                        ObjRegistroGrilla.TipoCliente = dreader[3].ToString();

                        ClsDetalleGrilla ObjDetalleGrilla = new ClsDetalleGrilla();

                        ObjDetalleGrilla.Moneda = dreader[4].ToString();
                        ObjDetalleGrilla.MontoDeuda = Convert.ToDouble(dreader[5]);
                        ObjDetalleGrilla.MontoDocumentos = Convert.ToDouble(dreader[8]);
                        ObjDetalleGrilla.MontoFacturar = Convert.ToDouble(dreader[11]);
                        ObjDetalleGrilla.MDeudaMB = Convert.ToDouble(dreader[6]);
                        ObjDetalleGrilla.MDeudaUSD = Convert.ToDouble(dreader[7]);
                        ObjDetalleGrilla.MDocuMB = Convert.ToDouble(dreader[9]);
                        ObjDetalleGrilla.MDocuUSD = Convert.ToDouble(dreader[10]);
                        ObjDetalleGrilla.MFacMB = Convert.ToDouble(dreader[12]);
                        ObjDetalleGrilla.MFacUSD = Convert.ToDouble(dreader[13]); 
                        
                        ObjArregloDetGrilla.Add(ObjDetalleGrilla);

                        ObjRegistroGrilla.DeudaMB = Convert.ToDouble(dreader[6]);
                        ObjRegistroGrilla.DeudaOM = Convert.ToDouble(dreader[7]);
                        ObjRegistroGrilla.DocuMB = Convert.ToDouble(dreader[9]);
                        ObjRegistroGrilla.DocuOM = Convert.ToDouble(dreader[10]);
                        ObjRegistroGrilla.FacturarMB = Convert.ToDouble(dreader[12]);
                        ObjRegistroGrilla.FacturarOM = Convert.ToDouble(dreader[13]);
                        ObjRegistroGrilla.TotalDeudaUS = Convert.ToDouble(dreader[16]);
                        // Si cliente viene en blanco quiere decir que está creado sólo en la contabilidad
                        if (dreader[0].ToString().Trim() == "")
                        {
                            ObjRegistroGrilla.TipoRegistro = "Cliente no creado";
                        }
                        else
                        {
                            // En caso que el cliente no tiene definida una línea de crédito
                            if (dreader[15].ToString().Trim() == "")
                            {
                                ObjRegistroGrilla.TipoRegistro = "Cliente sin definición de crédito";
                                ObjRegistroGrilla.TotalCreditoUS = 0;
                            }
                            else
                            {
                                ObjRegistroGrilla.TipoRegistro = "Cliente con crédito";
                                ObjRegistroGrilla.TotalCreditoUS = Convert.ToDouble(dreader[15]);
                            }
                        }
                        ObjRegistroGrilla.Riesgo= ObjRegistroGrilla.TotalCreditoUS - ObjRegistroGrilla.TotalDeudaUS;

                        RutClienteActual = ObjRegistroGrilla.Rut;
                        i = 1;
                    }
                    // cliente nuevo
                    else
                    {
                        if (dreader[2].ToString() != RutClienteActual && i != 0)
                        {
                            ObjRegistroGrilla.ArregloDetalle = ObjArregloDetGrilla;
                            ObjArrRegistrosGrilla.Add(ObjRegistroGrilla);

                            ObjArregloDetGrilla = new clsArregloDetGrilla();
                            ObjRegistroGrilla = new clsRegistroGrilla();

                            ObjRegistroGrilla.TipoRegistro = "";
                            // Si cliente viene en blanco quiere decir que está creado sólo en la contabilidad
                            if (dreader[1].ToString().Trim() == "")
                            {
                                ObjRegistroGrilla.TipoRegistro = "Cliente no creado";
                                ObjRegistroGrilla.TotalCreditoUS = 0;
                            }

                            ObjRegistroGrilla.Cliente = dreader[1].ToString();
                            ObjRegistroGrilla.Rut = dreader[2].ToString();
                            ObjRegistroGrilla.TipoCliente = dreader[3].ToString();

                            ClsDetalleGrilla ObjDetalleGrilla = new ClsDetalleGrilla();

                            ObjDetalleGrilla.Moneda = dreader[4].ToString();
                            ObjDetalleGrilla.MontoDeuda = Convert.ToDouble(dreader[5]);
                            ObjDetalleGrilla.MontoDocumentos = Convert.ToDouble(dreader[8]);
                            ObjDetalleGrilla.MontoFacturar = Convert.ToDouble(dreader[11]);
                            ObjDetalleGrilla.MDeudaMB = Convert.ToDouble(dreader[6]);
                            ObjDetalleGrilla.MDeudaUSD = Convert.ToDouble(dreader[7]);
                            ObjDetalleGrilla.MDocuMB = Convert.ToDouble(dreader[9]);
                            ObjDetalleGrilla.MDocuUSD = Convert.ToDouble(dreader[10]);
                            ObjDetalleGrilla.MFacMB = Convert.ToDouble(dreader[12]);
                            ObjDetalleGrilla.MFacUSD = Convert.ToDouble(dreader[13]); 


                            ObjArregloDetGrilla.Add(ObjDetalleGrilla);

                            ObjRegistroGrilla.DeudaMB = Convert.ToDouble(dreader[6]);
                            ObjRegistroGrilla.DeudaOM = Convert.ToDouble(dreader[7]);
                            ObjRegistroGrilla.DocuMB = Convert.ToDouble(dreader[9]);
                            ObjRegistroGrilla.DocuOM = Convert.ToDouble(dreader[10]);
                            ObjRegistroGrilla.FacturarMB = Convert.ToDouble(dreader[12]);
                            ObjRegistroGrilla.FacturarOM = Convert.ToDouble(dreader[13]);
                            ObjRegistroGrilla.TotalDeudaUS = Convert.ToDouble(dreader[16]);
                            // Si cliente viene en blanco quiere decir que está creado sólo en la contabilidad
                            if (dreader[0].ToString().Trim() == "")
                            {
                                ObjRegistroGrilla.TipoRegistro = "Cliente no creado";
                                ObjRegistroGrilla.TotalCreditoUS = 0;
                            }
                            else
                            {
                                // En caso que el cliente no tiene definida una línea de crédito
                                if (dreader[15].ToString().Trim() == "")
                                {
                                    ObjRegistroGrilla.TipoRegistro = "Cliente sin definición de crédito";
                                    ObjRegistroGrilla.TotalCreditoUS = 0;
                                }
                                else
                                {
                                    ObjRegistroGrilla.TipoRegistro = "Cliente con crédito";
                                    ObjRegistroGrilla.TotalCreditoUS = Convert.ToDouble(dreader[15]);
                                }
                            }
                            ObjRegistroGrilla.Riesgo = ObjRegistroGrilla.TotalCreditoUS - ObjRegistroGrilla.TotalDeudaUS;
                            RutClienteActual = ObjRegistroGrilla.Rut;
                            i = 2;
                        }
                        // mismo cliente
                        //if (dreader[0].ToString() == RutClienteActual )
                        else
                        {
                            ClsDetalleGrilla ObjDetalleGrilla = new ClsDetalleGrilla();

                            ObjDetalleGrilla.Moneda = dreader[4].ToString();
                            ObjDetalleGrilla.MontoDeuda = Convert.ToDouble(dreader[5]);
                            ObjDetalleGrilla.MontoDocumentos = Convert.ToDouble(dreader[8]);
                            ObjDetalleGrilla.MontoFacturar = Convert.ToDouble(dreader[11]);
                            ObjDetalleGrilla.MDeudaMB = Convert.ToDouble(dreader[6]);
                            ObjDetalleGrilla.MDeudaUSD = Convert.ToDouble(dreader[7]);
                            ObjDetalleGrilla.MDocuMB = Convert.ToDouble(dreader[9]);
                            ObjDetalleGrilla.MDocuUSD = Convert.ToDouble(dreader[10]);
                            ObjDetalleGrilla.MFacMB = Convert.ToDouble(dreader[12]);
                            ObjDetalleGrilla.MFacUSD = Convert.ToDouble(dreader[13]); 

                            ObjArregloDetGrilla.Add(ObjDetalleGrilla);

                            ObjRegistroGrilla.DeudaMB = Convert.ToDouble(dreader[6]) + ObjRegistroGrilla.DeudaMB;
                            ObjRegistroGrilla.DeudaOM = Convert.ToDouble(dreader[7]) + ObjRegistroGrilla.DeudaOM;
                            ObjRegistroGrilla.DocuMB = Convert.ToDouble(dreader[9]) + ObjRegistroGrilla.DocuMB;
                            ObjRegistroGrilla.DocuOM = Convert.ToDouble(dreader[10]) + ObjRegistroGrilla.DocuOM;
                            ObjRegistroGrilla.FacturarMB = Convert.ToDouble(dreader[12]) + ObjRegistroGrilla.FacturarMB;
                            ObjRegistroGrilla.FacturarOM = Convert.ToDouble(dreader[13]) + ObjRegistroGrilla.FacturarOM;
                            ObjRegistroGrilla.TotalDeudaUS = Convert.ToDouble(dreader[16]) + ObjRegistroGrilla.TotalDeudaUS;
                            // En caso que el cliente no tiene definida una línea de crédito
                            if (dreader[15].ToString().Trim() == "")
                            {
                                ObjRegistroGrilla.TotalCreditoUS = 0;
                            }
                            else
                            {
                                ObjRegistroGrilla.TotalCreditoUS = Convert.ToDouble(dreader[15]);
                            }
                            ObjRegistroGrilla.Riesgo = ObjRegistroGrilla.TotalCreditoUS - ObjRegistroGrilla.TotalDeudaUS;
                            i = 3;
                        }
                    }
               }
                if (i==1 || i==3)
                {
                    ObjRegistroGrilla.ArregloDetalle = ObjArregloDetGrilla;
                    ObjArrRegistrosGrilla.Add(ObjRegistroGrilla);
                }
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = ObjArrRegistrosGrilla;
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "claTargetDao.cs";
                res.MetodoError = "ListarClienteMasterporUsuario";
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
        public static ResultadoTransaccion ListarCreditoClientes()
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            IList<clsCreditoCliente> ListaCreditoCliente = new List<clsCreditoCliente>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_DIRECCION_CREDITO_CLIENTE");

                SqlCommand command = new SqlCommand("SP_C_DIRECCION_CREDITO_CLIENTE", conn);

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();
                
                while (dreader.Read())
                {
                    clsCreditoCliente ObjClienteCredito = new clsCreditoCliente();

                    ObjClienteCredito.Id= Convert.ToInt32(dreader[0]);
                    ObjClienteCredito.MontoLineaCredito=Convert.ToDouble(dreader[5]);

                    ObjClienteCredito.ObjCuenta = new clsClienteMaster(true);

                    ObjClienteCredito.ObjCuenta.Id = Convert.ToInt32(dreader[1]);
                    ObjClienteCredito.ObjCuenta.RUT = dreader[8].ToString();

                    ObjClienteCredito.ObjCuenta.Cuenta = new clsCuenta();
                    ObjClienteCredito.ObjCuenta.Cuenta.Id = Convert.ToInt32(dreader[1]);
                    ObjClienteCredito.ObjCuenta.NombreFantasia = dreader[2].ToString();
                    ObjClienteCredito.ObjCuenta.NombreCompañia = dreader[2].ToString();

                    ObjClienteCredito.ObjMoneda = new clsTipoMoneda();

                    ObjClienteCredito.ObjMoneda.Id = Convert.ToInt32(dreader[3]);
                    ObjClienteCredito.ObjMoneda.Codigo = dreader[4].ToString();

                    ObjClienteCredito.ObjCuentaClasificacion = new clsCuentaclasificacion();

                    ObjClienteCredito.ObjCuentaClasificacion.Id = Convert.ToInt32(dreader[6]);
                    ObjClienteCredito.ObjCuentaClasificacion.Nombre=dreader[7].ToString();

                    ObjClienteCredito.Vendedor = dreader[9].ToString();

                    if (dreader[10].ToString().Trim() != "" && dreader[11].ToString().Trim() != "")
                    {
                        ObjClienteCredito.TipoCliente = "Ambos";
                    }
                    else
                    {
                        if (dreader[10].ToString().Trim() != "")
                        {
                            ObjClienteCredito.TipoCliente = dreader[10].ToString();
                        }
                        else
                        {
                            ObjClienteCredito.TipoCliente = dreader[11].ToString();
                        }
                    }

                    ListaCreditoCliente.Add(ObjClienteCredito);
                }
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = ListaCreditoCliente;
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsControlCreditoAdo.cs";
                res.MetodoError = "ListarCreditoClientes";
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
        public static ResultadoTransaccion GuardarDefinicionCredito(clsCreditoCliente ObjCredito)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_DIRECCION_CREDITO_CLIENTE");
                objParams[0].Value = ObjCredito.Id;
                objParams[1].Value = ObjCredito.ObjCuenta.Id;
                objParams[2].Value = ObjCredito.ObjMoneda.Id;
                objParams[3].Value = ObjCredito.MontoLineaCredito;

                SqlCommand command = new SqlCommand("SP_N_DIRECCION_CREDITO_CLIENTE", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                ObjCredito.Id = Convert.ToInt32(command.ExecuteScalar());

                //Ejecutar transaccion
                transaction.Commit();
                res.Estado = Enums.EstadoTransaccion.Aceptada;
                res.Descripcion = "Se registró el crédito del cliente correctamente";

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsControlCreditoAdo.cs";
                res.MetodoError = "GuardarDefinicionCredito";
                res.Estado = Enums.EstadoTransaccion.Rechazada;
            }
            finally
            {
                conn.Close();
            }
            return res;
        }

    }
}
