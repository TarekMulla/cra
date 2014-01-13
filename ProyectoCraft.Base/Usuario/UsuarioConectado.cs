using System;


namespace ProyectoCraft.Base.Usuario
{
    public static class UsuarioConectado
    {

        public static Entidades.Usuarios.clsUsuario Usuario { get; set; }
        public static DateTime HoraInicioConexion { get; set; }

    }
}
