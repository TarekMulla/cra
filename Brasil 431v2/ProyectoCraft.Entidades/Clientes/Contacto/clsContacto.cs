using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Clientes.Direcciones;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Usuarios;

namespace ProyectoCraft.Entidades.Clientes.Contacto
{
    public class clsContacto: NamedObject
    {        
        public clsContacto()
        {
            TipoSaludo = new clsItemParametro();
            Estado = new Enums.Enums.Estado();
            EstadoCivil = new clsItemParametro();
            Sexo = new clsItemParametro();
            FormaContactoPreferida = new clsItemParametro();
            DiaPreferido = new clsItemParametro();
            JornadaPreferida = new clsItemParametro();
            DireccionInfo = new clsDireccionInfo();
            Propietario = new clsUsuario();
            ClienteMaster = new clsClienteMaster(true);
            TipoRol = new clsItemParametro();
            Departamento = new clsItemParametro();
        }
        
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Cargo { get; set; }
        public string TelefonoOficina { get; set; }
        public string TelefonoParticular { get; set; }
        public string TelefonoCelular { get; set; }
        public string CuentaSkype { get; set; }
        public string Email { get; set; }
        public string Observacion { get; set; }
        
        public string NombreJefe { get; set; }
        public string TelefonoJefe { get; set; }
        public string NombreAyudante { get; set; }
        public string TelefonoAyudante { get; set; }
        public string Cumpleaños { get; set; }
        public string NombrePareja { get; set; }
        public string FechaAniversario { get; set; }
        public string RegaloPreferido { get; set; }

        public bool PermiteTelOficina { get; set; }
        public bool PermiteTelParticular { get; set; }
        public bool PermiteTelCelular { get; set; }
        public bool PermiteSkype { get; set; }
        public bool PermiteEmail { get; set; }
        public bool PermiteEmailMasivo { get; set; }
        
        public clsItemParametro TipoSaludo { get; set; }
        public Enums.Enums.Estado Estado { get; set; }
        public clsItemParametro EstadoCivil { get; set; }
        public clsItemParametro Sexo { get; set; }
        public clsItemParametro FormaContactoPreferida { get; set; }
        public clsItemParametro DiaPreferido { get; set; }
        public clsItemParametro JornadaPreferida { get; set; }
        public clsItemParametro TipoRol { get; set; }
        public clsItemParametro Departamento { get; set; }
        public bool EsPrincipal { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Direcciones.clsDireccionInfo DireccionInfo { get; set; }
        public Entidades.Usuarios.clsUsuario Propietario { get; set; }
        public Entidades.Clientes.clsClienteMaster ClienteMaster { get; set; }


        public string NombreCliente
        {
            get
            {
                if (ClienteMaster.NombreCompañia != "" && ClienteMaster.Nombres == "")
                    return ClienteMaster.NombreCompañia;
                else
                    return ClienteMaster.Nombres + " " + ClienteMaster.ApellidoMaterno + " " +
                           ClienteMaster.ApellidoPaterno;


            }
        }

        public string NombreCompleto
        {
            get
            {
                return Nombre + " " + ApellidoPaterno + " " + ApellidoMaterno;
            }
            
        }

        public override string ToString()
        {
            return Nombre + " " + ApellidoPaterno + " " + ApellidoMaterno;
        }

    }
}
