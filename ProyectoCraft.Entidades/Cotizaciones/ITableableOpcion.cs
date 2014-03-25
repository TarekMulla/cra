using System;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.Entidades.Cotizaciones
{
    public interface ITableableOpcion : IIdentifiableObject
    {
        String Numero { get; }
        DateTime FechaValidezInicio { set; get; }
        DateTime FechaValidezFin { set; get; }
        String NavieraDescripcion { get; }
        DateTime FechaCreacion { set; get; }
        String EstadoDescripcion { get; }
        //bool Seleccionado { set; get; }
    }
}
