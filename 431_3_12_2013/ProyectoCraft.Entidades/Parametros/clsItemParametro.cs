using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.Parametros
{
    public class clsItemParametro:Entidades.GlobalObject.Item
    {
        public string Codigo { get; set; }
        public Enums.Enums.TipoParametro TipoParam { get; set; }
    }
}
