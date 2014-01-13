using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Cotizaciones.Indirecta;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.AccesoDatos.Cotizaciones.Indirecta
{
    public class CotizacionIndirectaOpcionDetalleDao
    {
        public static ResultadoTransaccion Crear(CotizacionIndirectaOpcion cotDet, SqlCommand command)
        {
            return new ResultadoTransaccion();
        }
    }
}
