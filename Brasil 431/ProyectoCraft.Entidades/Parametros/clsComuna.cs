using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Parametros
{
    public class clsComuna: GlobalObject.NamedObject
    {
        public clsPais Pais { get; set; }
        public clsCiudad Ciudad { get; set; }
    }
}
