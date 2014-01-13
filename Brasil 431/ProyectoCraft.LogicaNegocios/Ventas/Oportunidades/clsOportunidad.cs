using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.AccesoDatos.Ventas.Oportunidades;

namespace ProyectoCraft.LogicaNegocios.Ventas.Oportunidades
{
    public static class clsOportunidad
    {
        public static Entidades.GlobalObject.ResultadoTransaccion ListarOportunidadesPorCliente(Int64 IdCliente)
        {
            return clsOportunidadAdo.ListarOportunidadesPorCliente(IdCliente);
        }
        public static Entidades.GlobalObject.ResultadoTransaccion ListarOportunidadesActividad(long IdActividad, int IdTipoActividad)
        {
            return clsOportunidadAdo.ListarOportunidadesActividad(IdActividad, IdTipoActividad);
        }
        public static Entidades.GlobalObject.ResultadoTransaccion AsociarActividadOportunidad(int IdTipoActividad,long IdOportunidad,long  IdActividad)
        {
            return clsOportunidadAdo.AgregarActividadOportunidad(IdTipoActividad, IdOportunidad, IdActividad);
        }
        public static Entidades.GlobalObject.ResultadoTransaccion EliminarActividadOportunidad(int IdTipoActividad, long IdOportunidad, long IdActividad)
        {
            return clsOportunidadAdo.EliminarActividadOportunidad(IdTipoActividad, IdOportunidad, IdActividad);
        }
    }
}
