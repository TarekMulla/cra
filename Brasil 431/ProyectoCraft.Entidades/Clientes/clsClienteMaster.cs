using System;
using System.Collections.Generic;
using ProyectoCraft.Entidades.Clientes.Contacto;
using ProyectoCraft.Entidades.Clientes.Direcciones;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.Entidades.Clientes
{
    public class clsClienteMaster: IdentifiableObject
    {
        //public clsClienteMaster()
        //{
        //    NombreCompañia = "";
        //    Nombres = "";
        //    ApellidoPaterno = "";
        //    ApellidoMaterno = "";
        //    NombreFantasia = "";
        //    RUT = "";
        //    DireccionInfo = new clsDireccionInfo();
        //    ProductosPreferidos = new List<clsTipoProducto>();
        //    TiposRelaciones = new List<clsItemParametro>();
        //    Contactos = new List<clsContacto>();            
        //}

        public clsClienteMaster(bool MostrarFantasia)
        {
            NombreCompañia = "";
            Nombres = "";
            ApellidoPaterno = "";
            ApellidoMaterno = "";
            NombreFantasia = "";
            RUT = "";
            DireccionInfo = new clsDireccionInfo();
            //ProductosPreferidos = new List<clsTipoProducto>();
            ProductosPreferidos = new List<clsClientesProductos>();
            TiposRelaciones = new List<clsItemParametro>();
            Contactos = new List<clsContacto>();
            MostrarNombreFantasia = MostrarFantasia;
        }
        
        public string NombreCompañia { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NombreFantasia { get; set; }
        public string RUT { get; set; }
        public Enums.Enums.TipoPersona Tipo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Direcciones.clsDireccionInfo DireccionInfo { get; set; }

        public Enums.Enums.Estado EstadoTarget { get; set; }
        public Enums.Enums.Estado EstadoCuenta { get; set; }
        public Target.clsTarget Target { get; set; }
        public Cuenta.clsCuenta Cuenta { get; set; }
        //{
        //    get {
        //        if (Cuenta ==null)

        //        {
        //            ProyectoCraft.Entidades.Clientes.Cuenta.clsCuenta
        //            LogicaNegocios.Clientes.clsCuentas.BuscarCuentaPorId(house.Cliente);
        //            this.Id
        //        }
        //    }
        //     set { }
        //}
        
        //public IList<clsTipoProducto> ProductosPreferidos { get; set; }
        public IList<clsClientesProductos> ProductosPreferidos { get; set; }
        public IList<clsItemParametro> TiposRelaciones { get; set; }
        public IList<clsItemParametro> ClienteMasterTipoCliente { get; set; }

        public IList<CondicionesComerciales.clsCondicionComercial> CondicionesComerciales { get; set; }
        public CondicionesComerciales.clsCondicionComercial CondicionComercial { get; set; }
        public IList<clsContacto> Contactos { get; set; }
        
        public string NombreCliente
        {
            get
            {
                string name = "";
                if (NombreCompañia == null || NombreCompañia == "")
                    name = Nombres + " " + ApellidoPaterno + " " + ApellidoMaterno;
                else
                    name = NombreCompañia;

                return name;
            }
        }

        public override string ToString()
        {
            string name = "";
            if (NombreCompañia == null || NombreCompañia == "")
                name = Nombres + " " + ApellidoPaterno + " " + ApellidoMaterno;
            else
            {
                if(Tipo == Enums.Enums.TipoPersona.Cuenta)
                    if(MostrarNombreFantasia)
                        name = NombreFantasia;
                    else
                        name = NombreCompañia;
                else
                    name = NombreCompañia;
            }
                

            return name + "(" + Tipo + ")";
        }

        public bool MostrarNombreFantasia { get; set; }

        public Usuarios.clsUsuario UsuarioCreo { get; set; }
        
    }
}
