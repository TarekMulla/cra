using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Clientes.CondicionesComerciales;
using ProyectoCraft.Entidades.Enums;

namespace ProyectoCraft.LogicaNegocios.Clientes
{
    public static class clsCondicionesComerciales
    {
        public static IList<clsTipoCondicionComercial> ListarCondicionesComercialesPorTipo(Enums.TipoCondicionComercial tipo)
        {
            return AccesoDatos.Clientes.clsCondicionComercialDAO.ListarCondicionesComercialesPorTipo(tipo);
        }

    }
}
