using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Tarifado
{
    public class clsTipoMoneda: GlobalObject.IdentifiableObject
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Codigo;
        }
    }
}
