using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Data;
using ProyectoCraft.AccesoDatos.Clientes;
using ProyectoCraft.AccesoDatos.Direccion.Metas;
using ProyectoCraft.Entidades.Direccion.Metas;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.LogicaNegocios.Direccion.Metas {
    public class ClsSalesLeadNegocio {
        public static ResultadoTransaccion GuardarVariosClsSalesLead(IList<ClsSalesLead> salesLeads) {
            return ClsSalesLeadAdo.GuardarVariosClsSalesLead(salesLeads);
        }
        public static ResultadoTransaccion ListarSalesLeadUsuarioEstado(long IdVendedor, string Estados)
        {
            return ClsSalesLeadAdo.ListarSalesLeadUsuarioEstado(IdVendedor, Estados);
        }
        public static ResultadoTransaccion ListarSalesLeads()
        {
            return ClsSalesLeadAdo.ListarSLeads();
        }
        public static DataTable GraficaEstadoAgente(string Estados, long IdAgente, DateTime FechaDesde, DateTime FechaHasta)
        {
            return ClsSalesLeadAdo.PreparaGraficaEstadoAgente(Estados, IdAgente, FechaDesde, FechaHasta);
        }
        public static ResultadoTransaccion EliminarObservacionesSalesLead(long IdObservacion)
        {
            return ClsSalesLeadAdo.EliminarSalesLeadObservacion(IdObservacion);
        }
        public static ResultadoTransaccion GuardarObservacion(long IdSalesLead, clsSalesLeadObservaciones ObjObservacion, ref string ModificaGlosa)
        {
            return ClsSalesLeadAdo.GuardarSalesLeadObservacion(IdSalesLead, ObjObservacion, ref ModificaGlosa);
        }
        public static ResultadoTransaccion ListarObservacionesSalesLead(long IdSalesLead)
        {
            return ClsSalesLeadAdo.ListarObservacionesSalesLead(IdSalesLead);
        }
        public static ResultadoTransaccion CancelarSalesLead(long IdSalesLead, string Observaciones, DateTime FechaCancelacion)
        {
            return ClsSalesLeadAdo.GuardarCancelacionSalesLead(IdSalesLead, Observaciones, FechaCancelacion);
        }
        public static ResultadoTransaccion CerrarSalesLead(long IdSalesLead,  string Observaciones, DateTime FechaCierre)
        {
            return ClsSalesLeadAdo.GuardarCierreSalesLead(IdSalesLead, Observaciones, FechaCierre);
        }

        public static ResultadoTransaccion GuardarFollowUps(ClsSalesLead salesLead) {
            var followDataBqse = clsClienteMasterADO.ObtenerFollowUpClientePorSalesLead(salesLead.Id32);
            return ClsSalesLeadAdo.GuardarFollowups(followDataBqse, salesLead);
        }

        public static ResultadoTransaccion EditarClsSalesLead(ClsSalesLead saleslead) {
            return ClsSalesLeadAdo.EditarClsSalesLead(saleslead);
        }
    }
}
