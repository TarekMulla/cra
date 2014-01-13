using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.AccesoDatos.Parametros;
using ProyectoCraft.Entidades.Clientes.TargetAccount;
using ProyectoCraft.Entidades.Parametros;

namespace ProyectoCraft.LogicaNegocios.Parametros
{
    public static class clsParametrosClientes
    {
        public static IList<clsIncoTerm> ListarIncoTerms(bool activo)
        {
            return clsParametrosClientesDAO.ListarIncoTerms(activo);
        }

        public static IList<clsTipoServicioComplementario> ListarServiciosComplementarios(bool activo)
        {
            return clsParametrosClientesDAO.ListarServiciosComplementarios(activo);
        }

        public static clsTipoServicioComplementario ObtenerServicioComplementarioPorId(Int16 IdServicio)
        {
            return clsParametrosClientesDAO.ObtenerServicioComplementarioPorId(IdServicio);
        }

        public static IList<clsTipoObjeciones> ListarTipoObjeciones(bool activo)
        {
            return clsParametrosClientesDAO.ListarTipoObjeciones(activo);
        }

        public static clsTipoObjeciones ObtenerObjecionPorId(Int16 IdObjecion)
        {
            return clsParametrosClientesDAO.ObtenerObjecionPorId(IdObjecion);
        }

        //public static IList<clsTipoAccionesTomar> ListarTipoAccionTomar(bool activo)
        //{
        //    return clsParametrosClientesDAO.ListarTipoAccionTomar(activo);
        //}

        //public static clsTipoAccionesTomar ObtenerAccionTomarPorId(Int16 IdAccion)
        //{
        //    return clsParametrosClientesDAO.ObtenerAccionTomarPorId(IdAccion);
        //}
    }
}
