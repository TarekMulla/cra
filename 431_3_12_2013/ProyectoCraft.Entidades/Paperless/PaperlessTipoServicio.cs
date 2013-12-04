using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Paperless
{
    public class PaperlessTipoServicio: GlobalObject.NamedObject
    {
        public PaperlessTipoServicio(){}

        public bool Activo { get; set; }
    }
}
