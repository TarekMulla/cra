using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.AccesoDatos.Ventas.Actividades;
using ProyectoCraft.Entidades.Ventas.Actividades;

namespace ProyectoCraft.LogicaNegocios.Ventas.Actividades
{
    public static class clsAsuntoTipoActividad
    {
        public static Entidades.GlobalObject.ResultadoTransaccion ListarAsuntosTipoActividad(int IdTipoActividad, string EntradaSalida)
        {
            return clsAsuntosTipoActividadAdo.ListarAsuntosTipoActividad(IdTipoActividad, EntradaSalida);
        }
        public static Entidades.GlobalObject.ResultadoTransaccion ListarAsuntosActividad(long IdActividad)
        {
            return clsAsuntosTipoActividadAdo.ListarAsuntosActividad(IdActividad);
        }
        public static Entidades.GlobalObject.ResultadoTransaccion AsociarAsuntoActividad(long IdTipoAsunto,long IdActividad)
        {
            return clsAsuntosTipoActividadAdo.AgregarAsuntoActividad(IdTipoAsunto, IdActividad);
        }
        public static Entidades.GlobalObject.ResultadoTransaccion EliminarAsuntoActividad(long IdTipoAsunto, long IdActividad)
        {
            return clsAsuntosTipoActividadAdo.EliminarAsuntoActividad(IdTipoAsunto,IdActividad);
        }

        public static IList<Entidades.Ventas.Actividades.clsTipoActividad> ListarTipoActividad()
        {
            return clsAsuntosTipoActividadAdo.ListarTipoActividad();
        }

        public static clsTipoActividad ObtenerTipoActividadPorId(Int16 IdActividad)
        {
            return clsAsuntosTipoActividadAdo.ObtenerTipoActividadPorId(IdActividad);
        }
    }
}
