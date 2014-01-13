using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.LogicaNegocios.Mantenedores
{
    
    public class ClsNaviera : IdentifiableObject
    {
        public string Nombre { get; set; }
        //public Int32 Id { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }        
    }
    
}
