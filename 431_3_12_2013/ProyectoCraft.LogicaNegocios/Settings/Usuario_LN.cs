using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.AccesoDatos.Settings;
using ProyectoCraft.Entidades.Settings;


namespace ProyectoCraft.LogicaNegocios.Settings
{
   public class Usuario_LN
    {
       public static IList<Usuario> GetUser()
       {
           return UsuarioDAO.ObtenerUsuarios();
       }


    }
}
