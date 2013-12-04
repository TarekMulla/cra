using System;
using System.Collections.Generic;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Usuarios;


namespace ProyectoCraft.Entidades.Cotizaciones {
    public interface ITableable : IIdentifiableObject {
        String Numero { get; }
        clsUsuario Usuario { set; get; }
        String Producto { get; }
        clsClienteMaster Cliente { set; get; }
        //String NombreCliente { set; get; }
        DateTime FechaSolicitud { set; get; }
        clsIncoTerm IncoTerm { set; get; }
        Estado Estado { set; get; }
        String EstadoDescripcion { get; }
        int CantidadOpciones { get; }
        String ProveedorCarga { set; get; }
        String Tipo { get; }
        bool Seleccionado { set; get; }
        List<ITableableOpcion> OpcionesView { get; }    
    }
}
