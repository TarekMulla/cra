using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Parametros
{
    public class clsIncoTerm:GlobalObject.IdentifiableObject
    {
        public clsIncoTerm(){}

        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public bool Estado { get; set; }

        public override string ToString()
        {
            return Codigo + " - " + Descripcion;
        }
    }
}
