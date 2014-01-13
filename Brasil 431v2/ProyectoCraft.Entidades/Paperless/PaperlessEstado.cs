using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Paperless
{
    public  class PaperlessEstado: GlobalObject.NamedObject
    {
        public PaperlessEstado(){}

        public bool Activo { get; set; }
        public PaperlessEstado EstadoAnterior { get; set; }
        public PaperlessEstado EstadoSiguiente { get; set; }
    }
}
