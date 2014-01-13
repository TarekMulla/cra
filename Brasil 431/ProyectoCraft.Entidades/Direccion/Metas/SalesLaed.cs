using System;
using System.Collections.Generic;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.Entidades.Ventas.Productos;
using ProyectoCraft.Entidades.Parametros;

namespace ProyectoCraft.Entidades.Direccion.Metas {
    public class ClsSalesLead : IdentifiableObject {
        public String GlosaSalesLead { get; set; }
        public String Reference { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime FechaRevision
        {
            get
            {
                if (FollowUps == null || FollowUps.Count == 0)
                    return new DateTime();
                if (FollowUps[0].FechaFollowUp == null)
                    return new DateTime();
                return (DateTime)FollowUps[0].FechaFollowUp;
            }
        }
        public DateTime FechaCierre { get; set; }
        public DateTime FechaCancelacion { get; set; }

        public clsUsuario UsuarioAsignador { get; set; }
        public DateTime FechaUltActulizacion { get; set; }
        public int IdTipoActualizacion { get; set; }
        public clsItemParametro Prioridad { get; set; }
        public string ShipperNombre { get; set; }
        public string Shipperdireccion { get; set; }
        public string ShipperZipCode { get; set; }
        public string ShipperCiudad { get; set; }
        public string ShipperContacto { get; set; }
        public string ShipperEmail { get; set; }
        public string ShipperWeb { get; set; }
        public string ConsigNombre { get; set; }
        public string ConsigDireccion { get; set; }
        public string Consigciudad { get; set; }
        public string ConsigTelefono { get; set; }
        public string ConsigEmail { get; set; }
        public string ConsigContacto { get; set; }
        public string GlosaCommodity { get; set; }
        public Int32 EmbarquesPorMes { get; set; }
        public clsItemParametro ObjTipoContenedor { get; set; }
        public long LCLCantidad { get; set; }
        public clsItemParametro LCLMedida { get; set; }
        public long FCLCantidad { get; set; }
        public clsItemParametro FCLMedida { get; set; }
        public long AereoCantidad { get; set; }
        public clsItemParametro AereoMedida { get; set; }
        public string Pol { get; set; }
        public DateTime FechaUltimoEmbarque { get; set; }
        public string CarrierAirline { get; set; }
        public string Pod { get; set; }
        public Paperless.PaperlessAgente Agente { get; set; }

        public IList<clsItemParametro> Incoterms{ get; set; }

        public DateTime FechaHoy {
            get { return DateTime.Now; }
        }
        public IList<clsTipoProducto> TiposProductos { get; set; }
        public IList<clsMetaCompetencia> Competencias { get; set; }
        public IList<clsClienteFollowUp> FollowUps { get; set; }
        public IList<clsItemParametro> TerminosCompra { get; set; }
        public ClsSalesLeadAsignacion Asignacion { get; set; }
        public Enums.Enums.EstadosSLead EstadoSLead { get; set; }

        public string ShipperFono { get; set; }
        public string ShipperPais { get; set; }

        public ClsSalesLead() {
            TiposProductos = new List<clsTipoProducto>();
            Competencias = new List<clsMetaCompetencia>();
            FollowUps = new List<clsClienteFollowUp>();
            TerminosCompra = new List<clsItemParametro>();
            LCLMedida = new clsItemParametro();
            FCLMedida = new clsItemParametro();
            AereoMedida = new clsItemParametro();
            Incoterms = new List<clsItemParametro>();
        }
    }
    public class ClsSalesLeadAsignacion : IdentifiableObject {
        public clsUsuario VendedorAsignado { get; set; }
        public DateTime FechaAsignacion { get; set; }
    }
    public class clsSalesLeadObservaciones : IdentifiableObject
    {
        public clsUsuario ObjUsuario { get; set; }
        public DateTime FechaHora { get; set; }
        public string Observacion { get; set; }
    }
}