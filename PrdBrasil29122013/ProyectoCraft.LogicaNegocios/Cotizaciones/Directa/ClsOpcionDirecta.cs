using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.AccesoDatos.Cotizaciones.Directa;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.LogicaNegocios.Cotizaciones.Directa
{
    public class ClsOpcionDirecta
    {
        public static ResultadoTransaccion ListarTodasLasCotizaciones()
        {
            return ClsOpcionDirectaDao.ListarTodasLasCotizacionesDirectas();
        }
    }
}
