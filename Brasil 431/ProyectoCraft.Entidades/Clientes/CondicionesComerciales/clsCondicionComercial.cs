using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.Entidades.Clientes.CondicionesComerciales
{
    public class clsCondicionComercial: IdentifiableObject
    {
        public clsCondicionComercial(){}

        public Clientes.clsClienteMaster Cliente { get; set; }        
        public clsTipoCondicionComercial CondicionComercialFlete { get; set; }
        public clsTipoCondicionComercial CondicionComercialGastosLocales { get; set; }
        public decimal MontoLineaCredito { get; set; }
        public DateTime VigenciaDesde { get; set; }
        public DateTime VigenciaHasta { get; set; }
        public Usuarios.clsUsuario UsuarioSolicita { get; set; }
        public DateTime FechaSolicita { get; set; }
        public Usuarios.clsUsuario UsuarioAutoriza { get; set; }
        public DateTime FechaAutoriza { get; set; }
        public Enums.Enums.EstadoCondicionComercial Estado { get; set; }


    }
}
