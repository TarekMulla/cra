using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Paperless
{
    public class PaperlessTipoCarga: GlobalObject.NamedObject
    {
        public PaperlessTipoCarga(){}

        public bool Activo { get; set; }

        public bool EsFCL
        {
            get { return this.Nombre == "FCL"; }
        }

        public bool EsLCL
        {
            get { return this.Nombre == "LCL"; }
        }

        public bool EsFAK
        {
            get { return this.Nombre == "FAK"; }
        }
    }
}
