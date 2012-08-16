using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using ProyectoCraft.Base.BaseDatos;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Perfiles;
using ProyectoCraft.Entidades.Usuarios;

namespace ProyectoCraft.AccesoDatos.Usuarios
{
    public static class clsUsuarioADO
    {
        private static SqlParameter[] objParams = null;
        private static SqlConnection conn = null;
        private static SqlTransaction transaction = null;
        private static SqlDataReader dreader = null;
        private static ResultadoTransaccion resTransaccion = null;


        public static ResultadoTransaccion ObtenerTransaccionUsuarioPorId(int idUsuario)
        {
            return BuscaUsuarioPorId(idUsuario);
        }

        public static clsUsuario ObtenerUsuarioPorId(int idUsuario)
        {
            ResultadoTransaccion resTran = BuscaUsuarioPorId(idUsuario);
            if (resTran.Estado == Entidades.Enums.Enums.EstadoTransaccion.Aceptada)
                return (clsUsuario)resTran.ObjetoTransaccion;

            return null;
        }

        private static ResultadoTransaccion BuscaUsuarioPorId(int idUsuario)
        {

            ResultadoTransaccion res = new ResultadoTransaccion();
            clsUsuario usuario = null;

            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_USUARIO_POR_ID");
                objParams[0].Value = idUsuario;

                SqlCommand command = new SqlCommand("SP_C_USUARIO_POR_ID", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    usuario = new clsUsuario();
                    usuario.Id = Convert.ToInt64(dreader[0]);
                    usuario.Nombre = dreader[1].ToString();
                    usuario.ApellidoPaterno = dreader[2].ToString();
                    usuario.ApellidoMaterno = dreader[3].ToString();
                    usuario.NombreUsuario = dreader[4].ToString();
                    usuario.Estado = (Entidades.Enums.Enums.Estado)dreader[5];
                    usuario.FechaCreacion = (DateTime)dreader[6];
                    usuario.Email = dreader["Email"].ToString();
                    usuario.Cargo = new clsUsuarioCargo(Convert.ToInt16(dreader[8]),dreader[9].ToString());
                    usuario.CargoEnum = (Entidades.Enums.Enums.UsuariosCargo)Convert.ToInt64(dreader["IdCargo"]);
                }

                res.Estado = Entidades.Enums.Enums.EstadoTransaccion.Aceptada;
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = usuario;

            }
            catch (Exception ex)
            {
                res.Estado = Entidades.Enums.Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Base.Log.Log.EscribirLog(ex.Message);
            }
            finally
            {
                if(dreader != null) dreader.Close();
                if(conn != null) conn.Close();
            }

            return res;
        }

        public static ResultadoTransaccion BuscaUsuarioPorUserName(string username)
        {

            ResultadoTransaccion res = new ResultadoTransaccion();
            clsUsuario usuario = null;

            try
            {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_USUARIO_POR_USERNAME");
                objParams[0].Value = username;

                SqlCommand command = new SqlCommand("SP_C_USUARIO_POR_USERNAME", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    usuario = new clsUsuario();
                    usuario.Id = Convert.ToInt64(dreader["Id"]);
                    usuario.Nombre = dreader["Nombres"].ToString();
                    usuario.ApellidoPaterno = dreader["ApellidoPaterno"].ToString();
                    usuario.ApellidoMaterno = dreader["ApellidoMaterno"].ToString();
                    usuario.NombreUsuario = dreader["NombreUsuario"].ToString();
                    usuario.Estado = (Entidades.Enums.Enums.Estado)dreader["Estado"];
                    usuario.FechaCreacion = (DateTime)dreader["FechaCreacion"];
                    usuario.Cargo = new clsUsuarioCargo(Convert.ToInt16(dreader["IdCargo"]), dreader["Descripcion"].ToString());
                    usuario.CargoEnum = (Entidades.Enums.Enums.UsuariosCargo)Convert.ToInt64(dreader["IdCargo"]);
                    if (dreader["Email"] is DBNull)
                        usuario.Email = "";
                    else 
                        usuario.Email = dreader["Email"].ToString();
                }

                res.Estado = Entidades.Enums.Enums.EstadoTransaccion.Aceptada;
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = usuario;

            }
            catch (Exception ex)
            {
                res.Estado = Entidades.Enums.Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Base.Log.Log.EscribirLog(ex.Message);
            }
            finally
            {
                if (dreader != null) dreader.Close();
                if (conn != null) conn.Close();
            }

            return res;
        }

        public static ResultadoTransaccion ListarUsuarios(Entidades.Enums.Enums.Estado estado,Entidades.Enums.Enums.CargosUsuarios cargo)
        {
            ResultadoTransaccion res = new ResultadoTransaccion();
            clsUsuario usuario = null;
            IList<clsUsuario> listUsuarios = new List<clsUsuario>();
            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_USUARIO");
                objParams[0].Value = estado;
                objParams[1].Value = cargo;

                SqlCommand command = new SqlCommand("SP_C_USUARIO", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    usuario = new clsUsuario();
                    usuario.Id = Convert.ToInt64(dreader[0]);
                    usuario.Nombre = dreader[1].ToString();
                    usuario.ApellidoPaterno = dreader[2].ToString();
                    usuario.ApellidoMaterno = dreader[3].ToString();
                    usuario.NombreUsuario = dreader[4].ToString();
                    usuario.Estado = (Entidades.Enums.Enums.Estado)dreader[5];
                    usuario.FechaCreacion = (DateTime)dreader[6];
                    usuario.Cargo = new clsUsuarioCargo(Convert.ToInt16(dreader[8]), dreader[9].ToString());
                    usuario.Email = dreader["Email"].ToString();
                    listUsuarios.Add(usuario);
                }

                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.Estado = Entidades.Enums.Enums.EstadoTransaccion.Aceptada;
                res.ObjetoTransaccion = listUsuarios;

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

        public static IList<clsUsuarioCargo> ObtenerCargosUsuario(string username)
        {
            IList<clsUsuarioCargo> cargos = new List<clsUsuarioCargo>();
            clsUsuarioCargo cargo;

            try
            {
                //Abrir Conexion
                conn = BaseDatos.Conexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_USUARIOS_CARGO");
                objParams[0].Value = username;

                SqlCommand command = new SqlCommand("SP_C_USUARIOS_CARGO", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read())
                {
                    cargo = new clsUsuarioCargo();
                    cargo.Id = Convert.ToInt64(dreader["Id"]);
                    cargo.Nombre = dreader["Descripcion"].ToString();
                    cargo.CargoEnum = (Entidades.Enums.Enums.UsuariosCargo)Convert.ToInt64(dreader["Id"]);
                    cargos.Add(cargo);
                }
            }
            catch(Exception ex)
            {
                
            }
            finally
            {
                conn.Close();
            }
            return cargos;
        }

        public static ResultadoTransaccion ObtenerPerfilesUsuarios(int idUsuario) {
            ResultadoTransaccion res = new ResultadoTransaccion();
            var listPerfiles = new List<clsPerfil>();

            try {
                //Abrir Conexion
                conn = BaseDatos.NuevaConexion();

                objParams = SqlHelperParameterCache.GetSpParameterSet(conn, "SP_C_USUARIO_PERFILES");
                objParams[0].Value = idUsuario;

                SqlCommand command = new SqlCommand("SP_C_USUARIO_PERFILES", conn);
                command.Parameters.AddRange(objParams);
                command.CommandType = CommandType.StoredProcedure;
                dreader = command.ExecuteReader();

                while (dreader.Read()) {
                    var perfil = new clsPerfil();
                    perfil.Id = Convert.ToInt64(dreader["id_perfil"]);
                    perfil.Nombre = dreader["nombre_perfil"].ToString();
                    perfil.Prioridad = Convert.ToInt32(dreader["prioridad"]);
                    if (!String.IsNullOrEmpty(dreader["id_panel"].ToString())) {
                        perfil.PanelDeControl.Id = Convert.ToInt32(dreader["id_panel"]);
                        perfil.PanelDeControl.Nombre = dreader["nombre_panel"].ToString();
                        perfil.PanelDeControl.XmlFile = dreader["xml_file"].ToString();
                    }
                    else {
                        perfil.PanelDeControl = null;
                    }
                    listPerfiles.Add(perfil);
                }
                res.Estado = Entidades.Enums.Enums.EstadoTransaccion.Aceptada;
                res.Accion = Entidades.Enums.Enums.AccionTransaccion.Consultar;
                res.ObjetoTransaccion = listPerfiles;
            } catch (Exception ex) {
                res.Estado = Entidades.Enums.Enums.EstadoTransaccion.Rechazada;
                res.Descripcion = ex.Message;
                Base.Log.Log.EscribirLog(ex.Message);
            } finally {
                if (dreader != null) dreader.Close();
                if (conn != null) conn.Close();
            }
            return res;
        }
    }
}
