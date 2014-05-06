using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Paperless {
    public class PaperlessEmpresa
    {
        public PaperlessEmpresa() { }
        public String Codigo { set; get; }
        public String Nombre { set; get; }
        

        public override string ToString()
        {
            return this.Nombre;
        }

    }
    

}
