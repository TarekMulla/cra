using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Clientes.CondicionesComerciales
{
    public class clsTipoCondicionComercial: GlobalObject.NamedObject
    {
        public int DiasPlazo { get; set; }
        public Enums.Enums.TipoCondicionComercial TipoCondicionComercial { get; set; }

    }
}
