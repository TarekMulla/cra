using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Ventas.Productos;

namespace ProyectoCraft.Entidades.Calendario
{
    public class clsVisitaInformeProductos: GlobalObject.IdentifiableObject
    {
        public clsVisitaInformeProductos()
        {
            Producto = new clsTipoProducto();
        }

        public clsVisitaInformeProductos(Ventas.Productos.clsTipoProducto producto)
        {
            Producto = producto;
        }

        public Ventas.Productos.clsTipoProducto Producto { get; set; }
    }
}
