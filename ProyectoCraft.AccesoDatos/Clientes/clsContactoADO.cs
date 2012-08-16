using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Clientes.Direcciones;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Clientes.Contacto;
using System.Data;
using System.Data.SqlClient;
using ProyectoCraft.AccesoDatos.Parametros;
using ProyectoCraft.Entidades.Log;

namespace ProyectoCraft.AccesoDatos.Clientes
{
    public static class clsContactoADO
    {
        private static ResultadoTransaccion resTransaccion = null;
        private static SqlConnection conn = null;
        private static SqlTransaction transaction = null;
        private static SqlParameter[] objParams = null;
        private static SqlDataReader dreader = null;

        public static IList<clsContacto> ListarContactos(string nombre, Int64 IdCliente, Int64 IdPropietario, Int16 IdEstado)
        {
            IList<clsContacto> listContactos = new List<clsContacto>();
            clsContacto contacto;

            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Registrar Cliente Master
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_CLIENTES_CONTACTOS");
                objParams[0].Value = nombre;
                objParams[1].Value = IdCliente;
                objParams[2].Value = IdPropietario;
                objParams[3].Value = IdEstado;

                SqlCommand command = new SqlCommand("SP_C_CLIENTES_CONTACTOS", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    contacto = new clsContacto();
                    contacto.Id = Convert.ToInt64(dreader[0]);
                    contacto.Nombre = dreader[1].ToString();
                    contacto.ApellidoPaterno = dreader[2].ToString();
                    contacto.ApellidoMaterno = dreader[3].ToString();
                    contacto.TelefonoOficina = dreader[4].ToString();
                    contacto.TelefonoParticular = dreader[5].ToString();
                    contacto.TelefonoCelular = dreader[6].ToString();
                    contacto.Email = dreader[7].ToString();
                    contacto.EsPrincipal = Convert.ToBoolean(dreader[8].ToString());
                    contacto.Estado = (Enums.Estado)Convert.ToInt16(dreader[9]);

                    contacto.ClienteMaster.Id = Convert.ToInt64(dreader[10]);
                    contacto.ClienteMaster.NombreCompañia = dreader[11].ToString();
                    contacto.ClienteMaster.Nombres = dreader[12].ToString();
                    contacto.ClienteMaster.ApellidoPaterno = dreader[13].ToString();
                    contacto.ClienteMaster.ApellidoMaterno = dreader[14].ToString();
                    contacto.ClienteMaster.Tipo = (Enums.TipoPersona) dreader[15];
                    
                    

                    listContactos.Add(contacto);

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

            return listContactos;
        }

        public static ResultadoTransaccion GuardarContacto(clsContacto contacto, Int64 idClienteMaster)
        {
            Int64 IdContacto = 0;
            resTransaccion = new ResultadoTransaccion();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Registrar Direcciones
                resTransaccion = clsDireccionADO.GuardarDirecciones(contacto.DireccionInfo, conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                {
                    throw new Exception(resTransaccion.Descripcion);
                }
                contacto.DireccionInfo = (clsDireccionInfo)resTransaccion.ObjetoTransaccion;
                                
                //Registrar Contacto
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_N_CLIENTES_CONTACTO");                
                if (contacto.TipoSaludo != null)
                    objParams[0].Value = contacto.TipoSaludo.Id;
                else
                    objParams[0].Value = -1;

                objParams[1].Value = contacto.Nombre;
                objParams[2].Value = contacto.ApellidoPaterno;
                objParams[3].Value = contacto.ApellidoMaterno;
                objParams[4].Value = contacto.Cargo;
                objParams[5].Value = contacto.TelefonoOficina;
                objParams[6].Value = contacto.TelefonoParticular;
                objParams[7].Value = contacto.TelefonoCelular;
                objParams[8].Value = contacto.CuentaSkype;
                objParams[9].Value = contacto.Email;
                objParams[10].Value = contacto.Estado;

                objParams[11].Value = contacto.Observacion;
                if(contacto.Departamento == null)
                    objParams[12].Value = -1;
                else
                    objParams[12].Value = contacto.Departamento.Id;

                objParams[13].Value = contacto.NombreJefe;
                objParams[14].Value = contacto.TelefonoJefe;

                if (contacto.TipoRol == null)
                    objParams[15].Value = -1;
                else
                    objParams[15].Value = contacto.TipoRol.Id;

                objParams[16].Value = contacto.NombreAyudante;
                objParams[17].Value = contacto.TelefonoAyudante;

                objParams[18].Value = contacto.Cumpleaños;
                if (contacto.EstadoCivil == null)
                    objParams[19].Value = -1;
                else 
                    objParams[19].Value = contacto.EstadoCivil.Id;

                if(contacto.Sexo == null)
                    objParams[20].Value = -1;
                else
                    objParams[20].Value = contacto.Sexo.Id;

                objParams[21].Value = contacto.NombrePareja;
                objParams[22].Value = contacto.FechaAniversario;
                objParams[23].Value = contacto.RegaloPreferido;

                if (contacto.FormaContactoPreferida == null)
                    objParams[24].Value = -1;
                else 
                    objParams[24].Value = contacto.FormaContactoPreferida.Id;

                objParams[25].Value = contacto.PermiteTelOficina;
                objParams[26].Value = contacto.PermiteTelParticular;
                objParams[27].Value = contacto.PermiteTelCelular;
                objParams[28].Value = contacto.PermiteSkype;
                objParams[29].Value = contacto.PermiteEmail;
                objParams[30].Value = contacto.PermiteEmailMasivo;

                if (contacto.DiaPreferido == null)
                    objParams[31].Value = -1;
                else 
                    objParams[31].Value = contacto.DiaPreferido.Id;

                if(contacto.JornadaPreferida == null)
                    objParams[32].Value = -1;
                else
                    objParams[32].Value = contacto.JornadaPreferida.Id;

                objParams[33].Value = contacto.EsPrincipal;

                if (contacto.DireccionInfo == null || contacto.DireccionInfo.IdInfo == 0)
                    objParams[34].Value = -1;
                else
                    objParams[34].Value = contacto.DireccionInfo.IdInfo;
                
                objParams[35].Value = contacto.Propietario.Id;
                objParams[36].Value = idClienteMaster;

                SqlCommand command2 = new SqlCommand("SP_N_CLIENTES_CONTACTO", conn);
                command2.Transaction = transaction;
                command2.Parameters.AddRange(objParams);
                command2.CommandType = CommandType.StoredProcedure;
                IdContacto = Convert.ToInt64(command2.ExecuteScalar());
                contacto.Id = IdContacto;

                //resTransaccion = GuardarClienteContactoRelacionado(idClienteMaster, IdContacto, conn, transaction);
                //if(resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                //    throw new Exception(resTransaccion.Descripcion);

              
                //Ejecutar transaccion
                transaction.Commit();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.Descripcion = "Se Creo Cuenta con Id " + contacto.ToString();


                //Registrar Actividad
                LogActividadUsuarios log = new LogActividadUsuarios(contacto.GetType().ToString(), contacto.Id, Enums.TipoActividadUsuario.Creo, Base.Usuario.UsuarioConectado.Usuario);
                LogActividades.clsLogActividadUsuariosADO.GuardaActividad(log);

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                resTransaccion.ArchivoError = "clsTargetDao.cs";
                resTransaccion.MetodoError = "GuardaTarget";

            }
            finally
            {
                conn.Close();
                resTransaccion.Accion = Enums.AccionTransaccion.Insertar;
                contacto.Id = IdContacto;                
                resTransaccion.ObjetoTransaccion = contacto;
            }

            return resTransaccion;

        }
        
        public static ResultadoTransaccion ActualizarContacto(clsContacto contacto)
        {
            Int64 IdContacto = 0;
            resTransaccion = new ResultadoTransaccion();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                //Crear Transaccion
                transaction = conn.BeginTransaction();

                //Registrar Direcciones
                resTransaccion = clsDireccionADO.GuardarDirecciones(contacto.DireccionInfo, conn, transaction);
                if (resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                {
                    throw new Exception(resTransaccion.Descripcion);
                }
                contacto.DireccionInfo = (clsDireccionInfo)resTransaccion.ObjetoTransaccion;

                //Registrar Contacto
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_A_CLIENTES_CONTACTO_POR_ID");
                if (contacto.TipoSaludo != null)
                    objParams[0].Value = contacto.TipoSaludo.Id;
                else
                    objParams[0].Value = -1;

                objParams[1].Value = contacto.Nombre;
                objParams[2].Value = contacto.ApellidoPaterno;
                objParams[3].Value = contacto.ApellidoMaterno;
                objParams[4].Value = contacto.Cargo;
                objParams[5].Value = contacto.TelefonoOficina;
                objParams[6].Value = contacto.TelefonoParticular;
                objParams[7].Value = contacto.TelefonoCelular;
                objParams[8].Value = contacto.CuentaSkype;
                objParams[9].Value = contacto.Email;
                objParams[10].Value = (Int16)contacto.Estado;

                objParams[11].Value = contacto.Observacion;

                if(contacto.Departamento == null)
                    objParams[12].Value = -1;
                else
                    objParams[12].Value = contacto.Departamento.Id;

                objParams[13].Value = contacto.NombreJefe;
                objParams[14].Value = contacto.TelefonoJefe;

                if (contacto.TipoRol == null)
                    objParams[15].Value = -1;
                else 
                    objParams[15].Value = contacto.TipoRol.Id;

                objParams[16].Value = contacto.NombreAyudante;
                objParams[17].Value = contacto.TelefonoAyudante;

                objParams[18].Value = contacto.Cumpleaños;
                if (contacto.EstadoCivil == null)
                    objParams[19].Value = -1;
                else
                    objParams[19].Value = contacto.EstadoCivil.Id;

                if (contacto.Sexo == null)
                    objParams[20].Value = -1;
                else
                    objParams[20].Value = contacto.Sexo.Id;

                objParams[21].Value = contacto.NombrePareja;
                objParams[22].Value = contacto.FechaAniversario;
                objParams[23].Value = contacto.RegaloPreferido;

                if (contacto.FormaContactoPreferida == null)
                    objParams[24].Value = -1;
                else
                    objParams[24].Value = contacto.FormaContactoPreferida.Id;

                objParams[25].Value = contacto.PermiteTelOficina;
                objParams[26].Value = contacto.PermiteTelParticular;
                objParams[27].Value = contacto.PermiteTelCelular;
                objParams[28].Value = contacto.PermiteSkype;
                objParams[29].Value = contacto.PermiteEmail;
                objParams[30].Value = contacto.PermiteEmailMasivo;

                if (contacto.DiaPreferido == null)
                    objParams[31].Value = -1;
                else
                    objParams[31].Value = contacto.DiaPreferido.Id;

                if (contacto.JornadaPreferida == null)
                    objParams[32].Value = -1;
                else
                    objParams[32].Value = contacto.JornadaPreferida.Id;

                objParams[33].Value = contacto.EsPrincipal;

                if (contacto.DireccionInfo == null || contacto.DireccionInfo.IdInfo == 0)
                    objParams[34].Value = -1;
                else
                    objParams[34].Value = contacto.DireccionInfo.IdInfo;

                objParams[35].Value = contacto.Propietario.Id;
                objParams[36].Value = contacto.ClienteMaster.Id;
                objParams[37].Value = contacto.Id;

                SqlCommand command2 = new SqlCommand("SP_A_CLIENTES_CONTACTO_POR_ID", conn);
                command2.Transaction = transaction;
                command2.Parameters.AddRange(objParams);
                command2.CommandType = CommandType.StoredProcedure;
                IdContacto = Convert.ToInt64(command2.ExecuteScalar());
                
                //Ejecutar transaccion
                transaction.Commit();

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.Descripcion = "Se Actualizo Cuenta con Id " + contacto.ToString();

                //Registrar Actividad
                LogActividadUsuarios log = new LogActividadUsuarios(contacto.GetType().ToString(), contacto.Id, Enums.TipoActividadUsuario.Edito, Base.Usuario.UsuarioConectado.Usuario);
                LogActividades.clsLogActividadUsuariosADO.GuardaActividad(log);

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.EscribirLog(ex.Message);

                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                resTransaccion.ArchivoError = "clsTargetDao.cs";
                resTransaccion.MetodoError = "GuardaTarget";

            }
            finally
            {
                conn.Close();
                resTransaccion.Accion = Enums.AccionTransaccion.Actualizar;                
                resTransaccion.ObjetoTransaccion = contacto;
            }

            return resTransaccion;
        }

        public static ResultadoTransaccion EliminarContacto(clsContacto contacto, SqlTransaction transaction)
        {
            bool ejecutaCommit = false;
            ResultadoTransaccion resTransaccion = new ResultadoTransaccion();
            try
            {                
                if(transaction == null)
                {
                    transaction = BaseDatos.Conexion().BeginTransaction();
                    ejecutaCommit = true;
                }
                    

                //Eliminar Direcciones Contacto
                if(contacto.DireccionInfo != null)
                {
                    foreach (var direccion in contacto.DireccionInfo.Items)
                    {
                        resTransaccion = new ResultadoTransaccion();
                        resTransaccion = clsDireccionADO.EliminarDireccion(direccion, transaction);
                        if(resTransaccion.Estado == Enums.EstadoTransaccion.Rechazada)
                            throw new Exception(resTransaccion.Descripcion);
                    }
                }

                //Eliminar Contacto
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_E_CLIENTES_CONTACTO");
                objParams[0].Value = contacto.Id;

                SqlCommand command = new SqlCommand("SP_E_CLIENTES_CONTACTO", BaseDatos.Conexion());
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = transaction;
                command.ExecuteNonQuery();
                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;

                if(ejecutaCommit)
                    transaction.Commit();


                //Registrar Actividad
                LogActividadUsuarios log = new LogActividadUsuarios(contacto.GetType().ToString(), contacto.Id, Enums.TipoActividadUsuario.Elimino, Base.Usuario.UsuarioConectado.Usuario);
                LogActividades.clsLogActividadUsuariosADO.GuardaActividad(log);

            }
            catch (Exception ex)
            {
                if(ejecutaCommit)
                    transaction.Rollback();

                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }

        public static ResultadoTransaccion CambiaEstado(clsContacto contacto)
        {
            ResultadoTransaccion resTransaccion = new ResultadoTransaccion();
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_A_CLIENTES_CONTACTO_CAMBIA_ESTADO");
                objParams[0].Value = contacto.Id;
                objParams[1].Value = (Int16)contacto.Estado;

                SqlCommand command = new SqlCommand("SP_A_CLIENTES_CONTACTO_CAMBIA_ESTADO", BaseDatos.Conexion());
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;

            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            finally
            {
                BaseDatos.CerrarConexion();
            }
            return resTransaccion;

        }


        private static ResultadoTransaccion GuardarClienteContactoRelacionado(Int64 IdCliente, Int64 IdContacto, SqlConnection connection, SqlTransaction transaction)
        {
            ResultadoTransaccion resTransaccion = new ResultadoTransaccion();
            Int64 idInfo = 0;
            try
            {
                objParams = SqlHelperParameterCache.GetSpParameterSet(BaseDatos.Conexion(), "SP_N_CLIENTES_CONTACTOS_RELACIONADOS");
                objParams[0].Value = IdCliente;
                objParams[1].Value = IdContacto;

                SqlCommand command = new SqlCommand("SP_N_CLIENTES_CONTACTOS_RELACIONADOS", BaseDatos.Conexion());
                command.Transaction = transaction;
                command.CommandType = CommandType.StoredProcedure;
                idInfo = Convert.ToInt64(command.ExecuteScalar());

                resTransaccion.Estado = Enums.EstadoTransaccion.Aceptada;
                resTransaccion.ObjetoTransaccion = idInfo;
            }
            catch (Exception ex)
            {
                resTransaccion.Estado = Enums.EstadoTransaccion.Rechazada;
                resTransaccion.Descripcion = ex.Message;
                Log.EscribirLog(ex.Message);
            }
            return resTransaccion;
        }
        
        public static ResultadoTransaccion ObtenerContactoPorIdTransaccion(Int64 IdContacto)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();

            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();

                //Registrar Cliente Master
                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_CLIENTES_CONTACTO_POR_ID");
                objParams[0].Value = IdContacto;
                SqlCommand command = new SqlCommand("SP_C_CLIENTES_CONTACTO_POR_ID", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    clsContacto contacto = new clsContacto();

                    contacto.Id = Convert.ToInt64(dreader["Id"]);

                    if (dreader["IdSaludo"] is DBNull)
                        contacto.TipoSaludo = null;
                    else 
                        contacto.TipoSaludo = clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdSaludo"]));

                    contacto.Nombre = dreader["Nombres"].ToString();
                    contacto.ApellidoPaterno = dreader["ApellidoPaterno"].ToString();
                    contacto.ApellidoMaterno = dreader["ApellidoMaterno"].ToString();
                    contacto.Cargo = dreader["Cargo"].ToString();
                    contacto.TelefonoOficina = dreader["TelefonoOficina"].ToString();
                    contacto.TelefonoParticular = dreader["TelefonoParticular"].ToString();
                    contacto.TelefonoCelular = dreader["TelefonoCelular"].ToString();
                    contacto.CuentaSkype = dreader["CuentaSkype"].ToString();
                    contacto.Email = dreader["Email"].ToString();
                    contacto.Estado = ((Enums.Estado) Convert.ToInt16(dreader["IdEstado"]));
                    contacto.Observacion = dreader["Observacion"].ToString();

                    if (dreader["Departamento"] is DBNull)
                        contacto.Departamento = null;
                    else 
                        contacto.Departamento = clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["Departamento"]));

                    contacto.NombreJefe = dreader["NombreJefe"].ToString();
                    contacto.TelefonoJefe = dreader["TelefonoJefe"].ToString();

                    if (dreader["IdTipoRol"] is DBNull)
                        contacto.TipoRol = null;
                    else 
                        contacto.TipoRol = clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdTipoRol"]));

                    contacto.NombreAyudante = dreader["NombreAyudante"].ToString();
                    contacto.TelefonoAyudante = dreader["TelefonoAyudante"].ToString();
                    contacto.Cumpleaños = dreader["Cumpleanos"].ToString();

                    if (dreader["IdEstadoCivil"] is DBNull)
                        contacto.EstadoCivil = null;
                    else 
                        contacto.EstadoCivil = clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdEstadoCivil"]));

                    if (dreader["IdSexo"] is DBNull)
                        contacto.Sexo = null;
                    else 
                        contacto.Sexo = clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdSexo"]));

                    contacto.NombrePareja = dreader["NombrePareja"].ToString();
                    contacto.FechaAniversario = dreader["FechaAniversario"].ToString();
                    contacto.RegaloPreferido = dreader["RegaloPreferido"].ToString();

                    if (dreader["IdFormaContactoPreferida"] is DBNull)
                        contacto.FormaContactoPreferida = null;
                    else 
                        contacto.FormaContactoPreferida = clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdFormaContactoPreferida"]));
                    
                    contacto.PermiteTelOficina = (bool)dreader["PermiteTelOficina"];
                    contacto.PermiteTelParticular = (bool) dreader["PermiteTelParticular"];
                    contacto.PermiteTelCelular = (bool) dreader["PermiteTelCelular"];
                    contacto.PermiteSkype = (bool) dreader["PermiteSkype"];
                    contacto.PermiteEmail = (bool) dreader["PermiteEmail"];
                    contacto.PermiteEmailMasivo = (bool) dreader["PermiteEmailMasivo"];

                    if (dreader["IdDiaPreferido"] is DBNull)
                        contacto.DiaPreferido = null;
                    else 
                        contacto.DiaPreferido = clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdDiaPreferido"]));

                    if (dreader["IdJornadaPreferida"] is DBNull)
                        contacto.JornadaPreferida = null;
                    else 
                        contacto.JornadaPreferida = clsParametrosDAO.BuscarParametroPorId(Convert.ToInt16(dreader["IdJornadaPreferida"]));
                    
                    contacto.EsPrincipal = (bool)dreader["EsPrincipal"];

                    if (dreader["IdDireccionInfo"] is DBNull)
                        contacto.DireccionInfo = null;
                    else 
                        contacto.DireccionInfo = clsDireccionADO.ListarDireccionesPorIdInfo(Convert.ToInt64(dreader["IdDireccionInfo"]));

                    if (dreader["IdPropietario"] is DBNull)
                        contacto.Propietario = null;
                    else
                        contacto.Propietario = Usuarios.clsUsuarioADO.ObtenerUsuarioPorId(Convert.ToInt16(dreader["IdPropietario"]));

                    if (dreader["IdClienteMaster"] is DBNull)
                        contacto.ClienteMaster = null;
                    else 
                        contacto.ClienteMaster = clsClienteMasterADO.ObtenerClienteMasterPorId(Convert.ToInt64(dreader["IdClienteMaster"]));

                    res.Estado = Enums.EstadoTransaccion.Aceptada;
                    res.ObjetoTransaccion = contacto;
                }               
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);

                res.Estado = Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                res.Accion = Enums.AccionTransaccion.Consultar;
                
            }
            finally
            {
                conn.Close();
            }

            return res;
        }

        public static clsContacto ObtenerContactoPorId(Int64 IdContacto)
        {
            ResultadoTransaccion res = ObtenerContactoPorIdTransaccion(IdContacto);

            if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                return (clsContacto)res.ObjetoTransaccion;
            else
                return null;
        }


        
    }
}
