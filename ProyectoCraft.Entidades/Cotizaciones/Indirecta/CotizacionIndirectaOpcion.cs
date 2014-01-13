using System;
using System.Collections.Generic;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Settings;
using ProyectoCraft.LogicaNegocios.Mantenedores;

namespace ProyectoCraft.Entidades.Cotizaciones.Indirecta
{
    public class CotizacionIndirectaOpcion : IdentifiableObject, ITableableOpcion
    {

        public String Numero { set; get; }//numero VARCHAR(45),  
        public DateTime FechaValidezInicio { set; get; }//fechaValidezInicio DATETIME, 
        public DateTime FechaValidezFin { set; get; }//fechaValidezFin DATETIME, 
        public ClsNaviera Naviera { set; get; }
        public string NavieraDescripcion { get { return Naviera.Nombre; } }//	Naviera BIGINT,
        public String PickUp { set; get; }//pickup VARCHAR(100),
        public Puerto Pod { set; get; }//POD VARCHAR(50),  
        public Puerto Pol { set; get; }//POL VARCHAR(50),  
        public String TiempoTransbordo { set; get; }//TiempoTransbordo VARCHAR(50),  
        public Usuario Usuario { get; set; }//idUsuario BIGINT, 
        public String Agente { set; get; }//agente VARCHAR(150),
        public DateTime FechaCreacion { set; get; }//createDate DATETIME DEFAULT getdate(), 
        public TipoTransbordo TipoTransbordo { set; get; }//COTIZACION_TIPOS_TRANSBORDOS_id BIGINT,

        public Estado Estado { set; get; }
        public string EstadoDescripcion { get { return Estado.Nombre; } }//COTIZACION_INDIRECTA_ESTADOS_id BIGINT NOT NULL, 
        public String Observaciones { set; get; }//Observaciones varchar (500),
        public String ObservacionesFijas { set; get; }//ObservacionesFijas varchar (500),

        public bool Seleccionado { set; get; }
        
        public List<CotizacionIndirectaOpcionDetalle> Detalles { set; get; }
        
        //COTIZACION_SOLICITUD_COTIZACIONES_id BIGINT NOT NULL, //duda

        //COTIZACION_INDIRECTA_TARIFAS_COPIADA_DE BIGINT,

    }
}