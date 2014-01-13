using System;
using System.Collections.Generic;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Usuarios;


namespace ProyectoCraft.Entidades.Ventas.Pricing
{
    [Obsolete]
    public class ClsTarifa : IdentifiableObject {
        public String Numero { set; get; }
        public DateTime Fecha { set; get; }
        public DateTime FechaValidesInicio { set; get; }
        public DateTime FechaValidesFin { set; get; }
        public String Agente{ set; get; }
        public String Comentario{ set; get; }
        public String ComentarioInterno { set; get; }
        public DateTime FechaCreacion { set; get; }

        public ClsEstado.Estado Estado { set; get; }
        public List<ClsDetalleTarifa> Detalle { set; get; }
        public clsUsuario CreadoPor { set; get; }
    }
}