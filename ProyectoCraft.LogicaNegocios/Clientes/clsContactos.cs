using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Clientes.Contacto;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.LogicaNegocios.Clientes
{
    public static class clsContactos
    {
        public static IList<clsContacto> ListarContactos(string nombre, Int64 IdCliente, Int64 IdPropietario, Int16 IdEstado)
        {
            return AccesoDatos.Clientes.clsContactoADO.ListarContactos(nombre, IdCliente, IdPropietario,IdEstado);
        }

        public static ResultadoTransaccion GuardarContacto(clsContacto contacto, Int64 idClienteMaster)
        {
            if (contacto.IsNew)
                return AccesoDatos.Clientes.clsContactoADO.GuardarContacto(contacto, idClienteMaster);
            else
                return AccesoDatos.Clientes.clsContactoADO.ActualizarContacto(contacto);
        }

        public static ResultadoTransaccion EliminarContacto(clsContacto contacto)
        {
            return AccesoDatos.Clientes.clsContactoADO.EliminarContacto(contacto, null);
        }

        public static ResultadoTransaccion CambiaEstado(clsContacto contacto)
        {
            return AccesoDatos.Clientes.clsContactoADO.CambiaEstado(contacto);
        }

        public static ResultadoTransaccion ObtenerContactoPorIdTransaccion(Int64 IdContacto)
        {
            return AccesoDatos.Clientes.clsContactoADO.ObtenerContactoPorIdTransaccion(IdContacto);
        }
    }
}
