using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.AccesoDatos.Clientes;
using ProyectoCraft.AccesoDatos.Direccion.Metas;
using ProyectoCraft.Entidades.Clientes.TargetAccount;
using ProyectoCraft.Entidades.Direccion.Metas;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Clientes.Target;

namespace ProyectoCraft.LogicaNegocios.Clientes
{
    public static class clsTarget
    {
        public static ResultadoTransaccion GuardaTarget(Entidades.Clientes.Target.clsTarget Target)
        {
            if (Target.IsNew)
                return clsTargetDAO.GuardaTarget(Target);

            return clsTargetDAO.ActualizarTarget(Target);
        }

        public static IList<Entidades.Clientes.Target.clsTarget> ListarTarget(string nombre, Int64 vendedor, int tipobusqueda )
        {
            if (nombre.Trim() == "") nombre = "-1";
            
            return clsTargetDAO.ListarTarget(nombre, vendedor,tipobusqueda);
        }

        public static ResultadoTransaccion ObtenerTargetPorId(Int64 IdTarget)
        {
            return clsTargetDAO.ObtenerTargetPorId(IdTarget);
        }


        public static IList<clsTargetAccountCompetencia> ListarEmpresasCompetencia(string nombre)
        {
            if (nombre == "") nombre = "-1";

            return clsEmpresaCompetenciaDAO.ListarEmpresasCompetencia(nombre);
        }

        public static IList<clsOrigenCarga> ListarOrigenCarga(string nombre)
        {
            if (nombre == "") nombre = "-1";

            return clsOrigenCargoADO.ListarEmpresasCompetencia(nombre);
        }

        public static ResultadoTransaccion EliminarTarget(Entidades.Clientes.Target.clsTarget target)
        {
            return clsTargetDAO.EliminarTarget(target);
        }

        public static ResultadoTransaccion DescalificarTarget(Int64 IdTarget)
        {
            return clsTargetDAO.DescalificarTarget(IdTarget);
        }

        public static ResultadoTransaccion ObtenerTargetPorIdMaster(Int64 IdMaster)
        {
            return clsTargetDAO.ObtenerTargetPorIdMaster(IdMaster);
        }

        

        //public static ResultadoTransaccion ListarClienteMasterporUsuario(int IdUsuario)
        //{
        //    return clsTargetDAO.ListarClienteMasterporUsuario(IdUsuario);
        //}
        //public static ResultadoTransaccion ListarContactoporClienteUsuario(int IdUsuario, int IdCliente)
        //{
        //    return clsTargetDAO.ListarContactosporClienteUsuario(IdUsuario, IdCliente);
        //}
    }
}
