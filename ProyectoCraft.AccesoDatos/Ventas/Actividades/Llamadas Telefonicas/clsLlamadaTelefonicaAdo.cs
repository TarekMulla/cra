using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoCraft.Entidades.Ventas.Actividades.Llamadas_Telefonicas;
using ProyectoCraft.Entidades.Ventas.Productos;
using ProyectoCraft.Entidades.Clientes.Contacto;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Usuarios;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Base.BaseDatos;
using System.Data.SqlClient;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Base.Log;
using System.Data;
using ProyectoCraft.Entidades.Enums;

namespace ProyectoCraft.AccesoDatos.Ventas.Actividades.Llamadas_Telefonicas
{
    public static class clsLlamadaTelefonicaAdo
    {
        private static SqlParameter[] objParams = null;
        private static SqlConnection conn = null;
        private static SqlTransaction transaction = null;
        private static SqlDataReader dreader = null;
        private static ResultadoTransaccion resTransaccion = null;

        public static ResultadoTransaccion ListarLlamadasRecientes(long IdCliente)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            IList<ClsLlamadaTelefonica> ListaLlamadas = new List<ClsLlamadaTelefonica>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Consultar Asuntos x Tipo Actividad
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "sp_c_ventas_llamadas_telefonicas_recientes");
                objParams[0].Value = IdCliente;

                SqlCommand command = new SqlCommand("sp_c_ventas_llamadas_telefonicas_recientes", conn);

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    ClsLlamadaTelefonica ObjLlamadaTelefonica = new ClsLlamadaTelefonica();

                    ObjLlamadaTelefonica.FechaHora = Convert.ToDateTime(dreader[0]);
                    ObjLlamadaTelefonica.Descripcion = dreader[1].ToString();

                    ObjLlamadaTelefonica.ObjContacto = new clsContacto();

                    ObjLlamadaTelefonica.ObjContacto.Nombre = dreader[2].ToString();

                    ObjLlamadaTelefonica.ObjUsuario = new clsUsuario();

                    ObjLlamadaTelefonica.ObjUsuario.Nombre = dreader[3].ToString();

                    ListaLlamadas.Add(ObjLlamadaTelefonica);
                }
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = ListaLlamadas;
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsLlamadaTelefonicaAdo.cs";
                res.MetodoError = "Listar Llamadas Recientes";
            }
            finally
            {
                conn.Close();
            }
            return res;
        }

        
        public static ResultadoTransaccion GuardaLlamada(ClsLlamadaTelefonica ObjLlamada) {

            var followDatabase = Clientes.clsClienteMasterADO.ObtenerFollowUpClientePorLlamada(ObjLlamada.Id32);

            resTransaccion = new ResultadoTransaccion();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_VENTAS_LLAMADA");
                objParams[0].Value = ObjLlamada.Codigo;   
                objParams[1].Value = ObjLlamada.FechaHora  ;
                objParams[2].Value = ObjLlamada.Descripcion ;
                objParams[3].Value = ObjLlamada.ObjContacto.Id;
                objParams[4].Value = ObjLlamada.ObjUsuario.Id;
                objParams[5].Value = ObjLlamada.ObjVendedor.Id;
                objParams[6].Value = ObjLlamada.ObjCustomer.Id;
                objParams[7].Value = ObjLlamada.EntradaSalida;
                objParams[8].Value = ObjLlamada.Importancia;
                objParams[9].Value = ObjLlamada.ObjTipoProducto.Id;

                SqlCommand command = new SqlCommand("SP_N_VENTAS_LLAMADA", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                ObjLlamada.Id32= Convert.ToInt32(command.ExecuteScalar());


                foreach (var followup in ObjLlamada.FollowUps)  
                    followup.IdLlamadaTelefonica = ObjLlamada.Id32;
                
                resTransaccion = SaveFollowups(followDatabase, ObjLlamada);
                
                //Ejecutar transaccion
                transaction.Commit();
                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.Descripcion = "Se registró Llamada Telefónica Exitosamente";


                
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                resTransaccion.Descripcion = ex.Message;
                resTransaccion.ArchivoError = "clsLlamadaTelefonica.cs";
                resTransaccion.MetodoError = "GuardaLlamada";
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada ;

            }
            finally
            {

                conn.Close();


            }
            return resTransaccion;
        }
        public static ResultadoTransaccion EliminarLlamada(long IdLlamada)
        {
            long IdSalida;
            resTransaccion = new ResultadoTransaccion();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_E_VENTAS_LLAMADA_TELEFONICA");
                objParams[0].Value = IdLlamada;

                SqlCommand command = new SqlCommand("SP_E_VENTAS_LLAMADA_TELEFONICA", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                IdSalida = Convert.ToInt32(command.ExecuteScalar());

                //Ejecutar transaccion
                transaction.Commit();
                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.Descripcion = "Se eliminó Llamada Telefónica Exitosamente";

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                resTransaccion.Descripcion = ex.Message;
                resTransaccion.ArchivoError = "clsLlamadaTelefonicaAdo.cs";
                resTransaccion.MetodoError = "EliminarLlamada";
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
            }
            finally
            {

                conn.Close();
            }
            return resTransaccion;
        }
        public static ResultadoTransaccion ModificarLlamada(ClsLlamadaTelefonica ObjLlamada)
        {
            var followDatabase = Clientes.clsClienteMasterADO.ObtenerFollowUpClientePorLlamada(ObjLlamada.Id32);
            resTransaccion = new ResultadoTransaccion();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();
                int IdSalida;

                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Registrar Llamada Telefonica
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "sp_u_ventas_llamada");
                objParams[0].Value = ObjLlamada.Id;
                objParams[1].Value = ObjLlamada.Codigo;
                objParams[2].Value = ObjLlamada.FechaHora;
                objParams[3].Value = ObjLlamada.Descripcion;
                objParams[4].Value = ObjLlamada.ObjContacto.Id;
                objParams[5].Value = ObjLlamada.ObjUsuario.Id;
                objParams[6].Value = ObjLlamada.ObjVendedor.Id;
                objParams[7].Value = ObjLlamada.ObjCustomer.Id;
                objParams[8].Value = ObjLlamada.EntradaSalida;
                objParams[9].Value = ObjLlamada.Importancia;
                objParams[10].Value = ObjLlamada.ObjTipoProducto.Id;

                SqlCommand command = new SqlCommand("sp_u_ventas_llamada", conn);
                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                IdSalida = Convert.ToInt32(command.ExecuteScalar());
                resTransaccion = SaveFollowups(followDatabase,ObjLlamada);

                //Ejecutar transaccion
                transaction.Commit();
                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.Descripcion = "Se actualizó Llamada Telefónica Exitosamente";

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                resTransaccion.Descripcion = ex.Message;
                resTransaccion.ArchivoError = "clsLlamadaTelefonicaAdo.cs";
                resTransaccion.MetodoError = "ModificarLlamada";
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;

            }
            finally
            {
                conn.Close();
            }
            return resTransaccion;
        }

        private static ResultadoTransaccion SaveFollowups(IList<clsClienteFollowUp> followDatabase, ClsLlamadaTelefonica ObjLlamada) {
            foreach (var followUp in ObjLlamada.FollowUps) {
                if (followUp.IsNew)
                    resTransaccion = Clientes.clsClienteMasterADO.AgregarFollowUpClienteMaster(followUp, transaction);
                else
                    resTransaccion = Clientes.clsClienteMasterADO.ModificarFollowUpClienteMaster(followUp, transaction);

                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                    throw new Exception(resTransaccion.Descripcion);
            }

            if (!ObjLlamada.IsNew) {
                var newlist = ObjLlamada.FollowUps.ToList();
                foreach (var followUp in followDatabase) {
                    var encontrado = newlist.Find(foo => foo.Id32.Equals(followUp.Id32));
                    if (encontrado == null) {
                        resTransaccion = Clientes.clsClienteMasterADO.EliminarLogicoFollowUpClienteMaster(followUp, transaction);
                        if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                            throw new Exception(resTransaccion.Descripcion);
                    }
                }
            }
            return resTransaccion;
        }

        public static ResultadoTransaccion ListarLlamadas(DateTime FechaInicio, DateTime FechaTermino, long IdContacto, long IdClienteMaster, long IdUsuario, int TipoSelect)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            IList<ClsLlamadaTelefonica> ListaLlamadas = new List<ClsLlamadaTelefonica>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Consultar Asuntos x Tipo Actividad
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "sp_c_ventas_llamadas_telefonicas");
                objParams[0].Value = FechaInicio;
                objParams[1].Value = FechaTermino;
                objParams[2].Value = IdContacto;
                objParams[3].Value = IdClienteMaster;
                objParams[4].Value = IdUsuario;
                objParams[5].Value = TipoSelect;

                SqlCommand command = new SqlCommand("sp_c_ventas_llamadas_telefonicas", conn);

                command.Transaction = transaction;
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    ClsLlamadaTelefonica ObjLlamadaTelefonica = new ClsLlamadaTelefonica();

                    ObjLlamadaTelefonica.Id = Convert.ToInt32(dreader[0]);
                    ObjLlamadaTelefonica.Codigo = dreader[1].ToString();
                    ObjLlamadaTelefonica.FechaHora = Convert.ToDateTime(dreader[2]);
                    ObjLlamadaTelefonica.Descripcion = dreader[3].ToString();

                    ObjLlamadaTelefonica.ObjContacto = new clsContacto();

                    ObjLlamadaTelefonica.ObjContacto.Id = Convert.ToInt16(dreader[4]);
                    ObjLlamadaTelefonica.ObjContacto.Nombre = dreader[5].ToString();

                    ObjLlamadaTelefonica.ObjContacto.ClienteMaster = new clsClienteMaster(true);
                    ObjLlamadaTelefonica.ObjContacto.ClienteMaster.Id = Convert.ToInt16(dreader[7]);
                    ObjLlamadaTelefonica.ObjContacto.ClienteMaster.Nombres = dreader[6].ToString();

                    ObjLlamadaTelefonica.ObjUsuario = new clsUsuario();

                    ObjLlamadaTelefonica.ObjUsuario.Nombre = dreader[10].ToString();
                    ObjLlamadaTelefonica.ObjUsuario.Id = Convert.ToInt16(dreader[11]);

                    ObjLlamadaTelefonica.ObjVendedor = new clsUsuario();

                    ObjLlamadaTelefonica.ObjVendedor.Nombre = dreader[8].ToString();
                    if (dreader[12] != null && dreader[12].ToString() != "")
                    {
                        ObjLlamadaTelefonica.ObjVendedor.Id = Convert.ToInt16(dreader[12]);
                    }
                    else
                    {
                        ObjLlamadaTelefonica.ObjVendedor.Id = 0;
                    }

                    ObjLlamadaTelefonica.ObjCustomer = new clsUsuario();

                    ObjLlamadaTelefonica.ObjCustomer.Nombre = dreader[9].ToString();
                    if (dreader[13] != null && dreader[13].ToString() != "")
                    {
                        ObjLlamadaTelefonica.ObjCustomer.Id = Convert.ToInt16(dreader[13]);
                    }
                    else
                    {
                        ObjLlamadaTelefonica.ObjCustomer.Id = 0;
                    }
                    ObjLlamadaTelefonica.EntradaSalida = dreader[14].ToString();
                    ObjLlamadaTelefonica.Importancia = dreader[15].ToString();


                    if (dreader[16] != null && dreader[16].ToString() != "")
                    {
                        ObjLlamadaTelefonica.ObjTipoProducto = new clsTipoProducto();
                        ObjLlamadaTelefonica.ObjTipoProducto.Id = Convert.ToInt32(dreader[16]);
                        ObjLlamadaTelefonica.ObjTipoProducto.Nombre = dreader[17].ToString();
                    }

                    if (ObjLlamadaTelefonica.ObjUsuario.Id.Equals(Base.Usuario.UsuarioConectado.Usuario.Id) || ObjLlamadaTelefonica.ObjVendedor.Id.Equals(Base.Usuario.UsuarioConectado.Usuario.Id))
                    {
                        ListaLlamadas.Add(ObjLlamadaTelefonica);
                    }
                    else
                    {
                        ObjLlamadaTelefonica.Descripcion = "";
                        ListaLlamadas.Add(ObjLlamadaTelefonica);
                    }                     
                }
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = ListaLlamadas;
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Descripcion = ex.Message;
                res.ArchivoError = "clsLlamadaTelefonicaAdo.cs";
                res.MetodoError = "Listar Llamadas";
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
    }
}
