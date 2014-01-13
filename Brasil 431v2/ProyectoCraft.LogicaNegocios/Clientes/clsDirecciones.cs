using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.AccesoDatos.Clientes;
using ProyectoCraft.Entidades.Clientes.Direcciones;
using ProyectoCraft.Entidades.GlobalObject;


namespace ProyectoCraft.LogicaNegocios.Clientes
{
    public static class clsDirecciones
    {
        public static clsDireccionInfo ListarDireccionesPorIdInfo(Int64 idInfo)
        {
            return clsDireccionADO.ListarDireccionesPorIdInfo(idInfo);
        }

        //public static ResultadoTransaccion EliminarDireccion(clsDireccion direccion)
        //{
        //    return clsDireccionADO.EliminarDireccion(direccion);
        //}
    }
}
