using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.Entidades.Ventas.Actividades.Llamadas_Telefonicas
{
    public class ClsLlamadaTelefonica : IdentifiableObject
    {

        public ClsLlamadaTelefonica(){
            FollowUps = new List<clsClienteFollowUp>();
        }

        public string Codigo
        { 
            get; 
            set; 
        }
        public DateTime FechaHora
        {
            get;
            set;
        }
        public string Descripcion
        {
            get;
            set;
        }
        public Entidades.Clientes.Contacto.clsContacto ObjContacto 
        {
            get;
            set;
        }      
        public Entidades.Usuarios.clsUsuario ObjUsuario
        {
            get;
            set;
        }
        public Entidades.Usuarios.clsUsuario ObjVendedor
        {
            get;
            set;
        }
        public Entidades.Usuarios.clsUsuario ObjCustomer
        {
            get;
            set;
        }
        public string EntradaSalida
        {
            get;
            set;
        }
        public string Importancia
        {
            get;
            set;
        }
        public Entidades.Ventas.Productos.clsTipoProducto ObjTipoProducto
        {
            get;
            set;
        }

        public IList<clsClienteFollowUp> FollowUps { set; get; }
    }

    
}
