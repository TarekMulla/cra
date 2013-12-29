using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.AccesoDatos.Ventas;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.LogicaNegocios.Ventas.Productos
{
    public static class clsTipoProducto
    {
        public static Entidades.GlobalObject.ResultadoTransaccion ListarTiposProducto(string ExpoImpo, string Activo)
        {
            return clsTipoProductosADO.ListarTiposProductosAdo(ExpoImpo,Activo);
        }

        public static ResultadoTransaccion ListarTiposTraficos()
        {
            return clsTipoProductosADO.ListarTiposTraficos();
        }

    }
}
