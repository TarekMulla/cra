using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Paperless
{
    public  class PaperlessEstadoPreAlerta: GlobalObject.NamedObject
    {
        public PaperlessEstadoPreAlerta(){}

        public Int16 id { get; set; }
        public string descripcion { get; set; }
        public Int16 Activo { get; set; }

    }
}