using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Parametros;

namespace ProyectoCraft.Entidades.Clientes.Direcciones
{
    public class clsDireccion: GlobalObject.Item
    {
        public clsDireccion()
        {
            TipoDireccion = new clsItemParametro();
            Pais = new clsPais();
            Ciudad = new clsCiudad();
            Comuna = new clsComuna();
            Sector = new clsItemParametro();
            DestinoDireccion = new clsItemParametro();
        }

        public Int64 IdDireccionInfo { get; set; }
        public Parametros.clsItemParametro TipoDireccion { get; set; }
        public string NombreDireccion { get; set; }
        public string Numero { get; set; }
        public string OficinaDpto { get; set; }
        public string Block { get; set; }
        public Parametros.clsPais Pais { get; set; }
        public Parametros.clsCiudad Ciudad { get; set; }
        public Parametros.clsComuna Comuna { get; set; }
        public Parametros.clsItemParametro Sector { get; set; }
        public Parametros.clsItemParametro DestinoDireccion { get; set; }
        public bool IsDeleted { get; set; }
        public override string ToString()
        {
            return NombreDireccion;
        }

    }
}
