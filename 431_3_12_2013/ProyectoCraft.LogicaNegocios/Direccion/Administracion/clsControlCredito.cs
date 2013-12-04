using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.AccesoDatos.Direccion.Administracion;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Direccion.Administracion;

namespace ProyectoCraft.LogicaNegocios.Direccion.Administracion
{
    public static class clsControlCredito
    {
        public static ResultadoTransaccion ListarContrlDeudoresFecha(DateTime Fecha)
        {
            return clsControlCreditoAdo.ListarContrlDeudoresFecha(Fecha);
        }
        public static ResultadoTransaccion GuardarCreditoCliente(clsCreditoCliente ObjCredito)
        {
            return clsControlCreditoAdo.GuardarDefinicionCredito(ObjCredito);
        }
        public static ResultadoTransaccion ListarCreditoClientes()
        {
            return clsControlCreditoAdo.ListarCreditoClientes();
        }

    }
}
