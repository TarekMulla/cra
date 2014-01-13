using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.AccesoDatos.Clientes;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Clientes.TargetAccount;

namespace ProyectoCraft.LogicaNegocios.Clientes
{
    public class clsTargetAccount
    {

        public static ResultadoTransaccion CreatTargetAccount(Entidades.Clientes.TargetAccount.clsTargetAccount targetaccount)
        {
            return clsTargetAccountADO.CreatTargetAccount(targetaccount.ClienteMaster.NombreCompañia,targetaccount.IdTargetSource);
        }


        public static ResultadoTransaccion CreatTargetAccount(string NombreCompania, Int64 IdTargetSource)
        {
            return clsTargetAccountADO.CreatTargetAccount(NombreCompania,IdTargetSource);
        }


        public static ResultadoTransaccion ObtenerTargetAccountPorIdSource(Int64 IdTargetSource)
        {
            return clsTargetAccountADO.ObtenerTargetAccountPorIdSource(IdTargetSource);
        }

        public static ResultadoTransaccion ObtenerTargetAccountPorIdMaster(Int64 IdMaster)
        {
            return clsTargetAccountADO.ObtenerTargetAccountPorIdMaster(IdMaster);
        }

        public static ResultadoTransaccion ActualizarPaso1(Entidades.Clientes.TargetAccount.clsTargetAccount targetaccount)
        {
            return clsTargetAccountADO.ActualizarPaso1(targetaccount);
        }

        public static ResultadoTransaccion ActualizarPaso2(Entidades.Clientes.TargetAccount.clsTargetAccount targetaccount)
        {
            return clsTargetAccountADO.ActualizarPaso2(targetaccount);
        }

        public static ResultadoTransaccion ActualizarPaso3(Entidades.Clientes.TargetAccount.clsTargetAccount targetaccount)
        {
            return clsTargetAccountADO.ActualizarPaso3(targetaccount);
        }

    }
}
