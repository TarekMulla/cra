using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Perfiles;
using ProyectoCraft.Entidades.Usuarios;

namespace ProyectoCraft.LogicaNegocios.Usuarios
{
    public static class clsUsuarios
    {
        public static ResultadoTransaccion ObtenerTransaccionUsuarioPorId(int idUsuario)
        {
            return AccesoDatos.Usuarios.clsUsuarioADO.ObtenerTransaccionUsuarioPorId(idUsuario);
        }

        public static ResultadoTransaccion ListarUsuarios(Entidades.Enums.Enums.Estado estado, Entidades.Enums.Enums.CargosUsuarios cargo)
        {
            return AccesoDatos.Usuarios.clsUsuarioADO.ListarUsuarios(estado, cargo);
        }

        public static clsUsuario ObtenerUsuarioPorId(int idUsuario)
        {
            return AccesoDatos.Usuarios.clsUsuarioADO.ObtenerUsuarioPorId(idUsuario);
        }

        private static ResultadoTransaccion BuscaUsuarioPorUserName(string username)
        {
            return AccesoDatos.Usuarios.clsUsuarioADO.BuscaUsuarioPorUserName(username);
        }

        public static ResultadoTransaccion ValidaUsuarioAutorizado(string username)
        {
            ResultadoTransaccion resSalida = new ResultadoTransaccion();
            ResultadoTransaccion resUsuario = new ResultadoTransaccion();


            resUsuario = BuscaUsuarioPorUserName(username);
            if(resUsuario.Estado == Entidades.Enums.Enums.EstadoTransaccion.Aceptada)
            {
                resSalida.Estado = resUsuario.Estado;

                if(resUsuario.ObjetoTransaccion == null)
                {                    
                    resSalida.Descripcion = "El Usuario no esta autorizado para entrar al Sistema Comercial Craft";
                    resSalida.ObjetoTransaccion = null;
                }
                else
                {
                    resSalida.Descripcion = "Usuario autorizado";
                    resSalida.ObjetoTransaccion = resUsuario.ObjetoTransaccion;                    
                }
            }
            else
            {
                resSalida = resUsuario;
            }

            return resSalida;
        }

        public static clsUsuario ObtenerUsuarioPorEmail(string email)
        {
            clsUsuario usuario = null;
            ResultadoTransaccion resUsuarios = ListarUsuarios(Entidades.Enums.Enums.Estado.Habilitado,
                                                        Entidades.Enums.Enums.CargosUsuarios.Todos);
            if(resUsuarios.Estado == Entidades.Enums.Enums.EstadoTransaccion.Aceptada)
            {
                IList<clsUsuario> usuarios = (IList<clsUsuario>)resUsuarios.ObjetoTransaccion;

                foreach (var user in usuarios)
                {
                    if (user.Email.Trim().ToUpper() == email.Trim().ToUpper())
                    {
                        usuario = user;
                        break;
                    }                        
                }
            }

            

            return usuario;
        }

        public static IList<clsUsuarioCargo> ObtenerCargosUsuario(string username)
        {
            return AccesoDatos.Usuarios.clsUsuarioADO.ObtenerCargosUsuario(username);
        }

        public static ResultadoTransaccion ObtenerPerfilesUsuarios(int idUsuario) {
            return AccesoDatos.Usuarios.clsUsuarioADO.ObtenerPerfilesUsuarios(idUsuario);
        }
    }
}
