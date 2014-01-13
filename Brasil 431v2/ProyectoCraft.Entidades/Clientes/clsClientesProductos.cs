using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.Entidades.Ventas.Productos;

namespace ProyectoCraft.Entidades.Clientes
{
    public class clsClientesProductos:GlobalObject.IdentifiableObject
    {
        public clsClientesProductos()
        {
            Producto = new clsTipoProducto();
            Customer = new clsUsuario();
        }

        public clsTipoProducto Producto { get; set; }
        public clsUsuario Customer { get; set; }
        public bool IsDeleted { get; set; }
    }
}
