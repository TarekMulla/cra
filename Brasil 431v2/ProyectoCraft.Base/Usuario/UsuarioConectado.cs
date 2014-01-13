using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Base.Usuario
{
    public static class UsuarioConectado
    {

        public static Entidades.Usuarios.clsUsuario Usuario { get; set; }
        public static DateTime HoraInicioConexion { get; set; }
        public static string BasedeDatos
        {
            get
            {
                try
                {
                    return BaseDatos.BaseDatos.GetConexion().Split(';')[1].Replace("initial catalog=", "");
                }
                catch (Exception ex)
                {                    
                }
                return "";
            }           
        }

    }
}
