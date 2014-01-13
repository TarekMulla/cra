using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ProyectoCraft.AccesoDatos.Clientes;
using ProyectoCraft.AccesoDatos.Direccion.Metas;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Direccion.Metas;
using ProyectoCraft.Entidades.Ventas.Productos;

namespace ProyectoCraft.LogicaNegocios.Direccion.Metas
{
    public static class clsMetaNegocio
    {
        public static ResultadoTransaccion GuardarVariosProspectos(IList<clsMeta> ListaProspectos)
        {
            return clsMetaAdo.GuardarVariosProspectos(ListaProspectos);
        }
        public static ResultadoTransaccion AsignarProspecto(long IdMeta, int IdEstadoMeta,long IdVendedorAsignado, DateTime FechaAsignacion)
        {
            return clsMetaAdo.GuardarAsignacion(IdMeta, IdEstadoMeta, IdVendedorAsignado, FechaAsignacion);
        }
        public static ResultadoTransaccion CambiarEstado(long IdMeta, int IdEstadoMeta)
        {
            return clsMetaAdo.GuardarCambioEstado(IdMeta, IdEstadoMeta);
        }
        public static ResultadoTransaccion CerrarTarget(long IdMeta, string Instruction, string Observaciones, DateTime FechaCierre, long IdUsuarioCierra)
        {
            return clsMetaAdo.GuardarCierreTarget(IdMeta, Instruction, Observaciones, FechaCierre, IdUsuarioCierra);
        }
        public static ResultadoTransaccion CancelarTarget(long IdMeta, string Observaciones, DateTime FechaCancelacion)
        {
            return clsMetaAdo.GuardarCancelacionTarget(IdMeta, Observaciones, FechaCancelacion);
        }

        public static ResultadoTransaccion GuardarObservacion(long IdMeta,clsMetaObservaciones ObjObservacion, ref string ModificaGlosa)
        {
            return clsMetaAdo.GuardarProspectoObservacion(IdMeta, ObjObservacion, ref ModificaGlosa);
        }
        public static ResultadoTransaccion ListarProspectos()
        {
            return clsMetaAdo.ListarProspectos();
        }
        public static ResultadoTransaccion ListarProspectosUsuarioEstado(long IdVendedor,string Estados)
        {
            return clsMetaAdo.ListarProspectoUsuarioEstado(IdVendedor, Estados);
        }
        public static DataTable GraficaEstadoUsuario(string Estados,long IdUsuario,DateTime FechaDesde, DateTime FechaHasta)
        {
            return clsMetaAdo.PreparaGraficaEstadoVendedor(Estados,IdUsuario,FechaDesde,FechaHasta);
        }
        public static ResultadoTransaccion ListarObservacionesProspecto(long IdProspecto)
        {
            return clsMetaAdo.ListarObservacionesProspecto(IdProspecto);
        }
        public static ResultadoTransaccion EliminarObservacionesProspecto(long IdObservacion)
        {
            return clsMetaAdo.EliminarProspectoObservacion(IdObservacion);
        }

        public static ResultadoTransaccion ObtenerMetaPorId(Int64 IdMeta)
        {
            return clsMetaAdo.ObtenerMetaPorId(IdMeta);
        }

        public static ResultadoTransaccion GuardarFollowUps(clsMeta meta) {
            var followDataBqse = clsClienteMasterADO.ObtenerFollowUpClientePorTarget(meta.Id32);
            return clsMetaAdo.GuardarFollowups(followDataBqse, meta);
        }
    }
}
