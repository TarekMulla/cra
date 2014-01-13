using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Parametros ;
using ProyectoCraft.Entidades.Ventas.Productos;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.Entidades.Enums;

namespace ProyectoCraft.Entidades.Direccion.Metas
{
    public class clsMeta : IdentifiableObject
    {
        public clsClienteMaster ObjClienteMaster { get; set; }
        public string GlosaClienteTarget { get; set; }
        public string TipoOportunidad { get; set; }
        public string TipoTarget { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime FechaRevision { 
            get {
                if (FollowUps == null || FollowUps.Count==0) 
                    return new DateTime();
                
                return (DateTime)FollowUps[0].FechaFollowUp;
            }

            //set { FollowUps[0].FechaFollowUp = value; } 
        }
        public string GlosaCommodity { get; set; }
        public clsItemParametro ObjTipoContenedor { get; set; }
        public Enums.Enums.EstadosMetas EstadoMeta { get; set; }
        public IList<clsTipoProducto> ObjTipoProducto { get; set; }
        public clsMetaAsignacion ObjMetaAsignacion { get; set; }
        public IList<clsMetaCompetencia> ObjMetaCompetencia { get; set; }
        public clsMetaObservaciones ObjMetaObservaciones { get; set; }
        public IList<clsMetaGlosasTrafico> ObjMetaGlosasTrafico { get; set; }
        public string IdNumMeta { get; set; }
        public DateTime FechaUltActulizacion { get; set; }
        public int IdTipoActualizacion { get; set; }
        public DateTime FechaHoy { get; set; }
        public clsItemParametro Prioridad { get; set; }
        public string Shipper { get; set; }
        public clsUsuario UsuarioAsignador { get; set; }

        public string NombreUsuarioCierra { get; set; }
        public DateTime? FechaCierre { get; set; }
        public string Instruction { get; set; }
        public DateTime? FechaCancelacion { get; set; }
        public IList<clsClienteFollowUp> FollowUps { get; set; }

        public void  clsmeta() {
            FollowUps = new List<clsClienteFollowUp>();
        }

    }
    public class clsMetaAsignacion : IdentifiableObject
    {
        public clsUsuario ObjVendedorAsignado { get; set; }
        public DateTime FechaAsignacion { get; set; }
    }
    public class clsMetaCompetencia : IdentifiableObject
    {
        public string Descripcion { get; set; }
        public clsItemParametro TipoCompetencia { set; get; }
    }
    public class clsMetaObservaciones : IdentifiableObject
    {
        public clsUsuario ObjUsuario { get; set; }
        public DateTime FechaHora { get; set; }
        public string Observacion { get; set; }
    }
    public class clsMetaGlosasTrafico : IdentifiableObject
    {
        public string Glosa { get; set; }
        public string TipoGlosa { get; set; }
    }
    
    
    
    
    
   

    
}
