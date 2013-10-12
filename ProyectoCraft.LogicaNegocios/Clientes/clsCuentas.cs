using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Clientes.Cuenta;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.LogicaNegocios.Clientes
{
    public static class clsCuentas
    {
        public static IList<clsCuenta> ListarCuentas(string nombre, Int64 vendedor, Int64 customer, int IdEstado)
        {
            return AccesoDatos.Clientes.clsCuentaADO.ListarCuentas(nombre, vendedor, customer, IdEstado);
        }


        public static ResultadoTransaccion GuardarCuenta(clsCuenta cuenta)
        {
            if(cuenta.IsNew)
                return AccesoDatos.Clientes.clsCuentaADO.GuardarCuenta(cuenta);

            return AccesoDatos.Clientes.clsCuentaADO.ActualizarCuenta(cuenta);
        }

        public static ResultadoTransaccion EliminarCuenta(clsCuenta cuenta)
        {
            return AccesoDatos.Clientes.clsCuentaADO.EliminarCuenta(cuenta);
        }

        public static ResultadoTransaccion CambiaEstado(clsCuenta cuenta)
        {
            return AccesoDatos.Clientes.clsCuentaADO.CambiaEstado(cuenta);
        }

        public static ResultadoTransaccion BuscarCuentaPorId(Int64 idCuenta)
        {
            return AccesoDatos.Clientes.clsCuentaADO.ObtenerCuentaPorId(idCuenta);
        }

        public static ResultadoTransaccion ObtenerCuentaPorIdMaster(Int64 IdMaster)
        {
            return AccesoDatos.Clientes.clsCuentaADO.ObtenerCuentaPorIdMaster(IdMaster);
        }

        public static clsCuenta ObtenerCuentaPorIdMasterObj(Int64 IdMaster)
        {
            ResultadoTransaccion res = ObtenerCuentaPorIdMaster(IdMaster);
            if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                return (clsCuenta) res.ObjetoTransaccion;

            return null;
        }

        public static IList<clsCuentaclasificacion> ListarClasificaciones(Enums.Estado Estado)
        {
            return AccesoDatos.Clientes.clsCuentaADO.ListarClasificaciones(Estado);
        }

    }
}
