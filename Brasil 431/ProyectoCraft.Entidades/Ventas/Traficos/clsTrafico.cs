using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Ventas.Traficos
{
    public class clsTrafico: Entidades.GlobalObject.NamedObject
    {
        public clsTrafico(){}

        public DateTime VigenciaDesde { get; set; }
        public DateTime VigenciaHasta { get; set; }

    }
}
