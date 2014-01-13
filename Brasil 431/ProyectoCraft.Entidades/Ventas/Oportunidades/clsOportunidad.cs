using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Clientes;  

namespace ProyectoCraft.Entidades.Ventas.Oportunidades
{
    public class clsOportunidad: IdentifiableObject
    {
        public string Codigo{get;set;}
        public string Tema { get; set; }
        public string Descripcion { get; set; }
        public int Probabilidad { get; set; }
        public int IdNivelInteres { get; set; }
        public clsClienteMaster ObjCliente { get; set; }
        public int IdUsuarioIngresa { get; set; }
        public int IdVendedor { get; set; }
        public int IdCustomer { get; set; }
        public int IdEstado { get; set; }
    }

    public class ClsRegistro
    {
        public string Codigo { get; set; }
        public string Tema { get; set; }
        public string Vendedor { get; set; }
        public string Customer { get; set; }
        public string Estado { get; set; }
    }

}
