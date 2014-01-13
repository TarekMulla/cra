using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.AccesoDatos.Cotizaciones.Directa;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.LogicaNegocios.Cotizaciones.Directa
{
public class CotizacionDirectaEstado
    {
    public static ResultadoTransaccion ListarEstadosCotizacionDirecta()
    {
        return ClsCotizacionDirectaEstadoDao.ListarEstadosCotizacionDirecta();
    }
    public static ResultadoTransaccion ModificarEstado(Int32 IdCotizacion,Int32 IdEstado)
    {
        return ClsCotizacionDirectaEstadoDao.CambioEstado(IdCotizacion,IdEstado);
    }
    }
}
