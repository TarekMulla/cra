using System;
using System.Collections.Generic;
using ProyectoCraft.Entidades.Perfiles;

namespace ProyectoCraft.Entidades.Usuarios {
    public class clsUsuario : GlobalObject.NamedObject {
        public clsUsuario() {
            Perfiles = new List<clsPerfil>();
        }

        public clsUsuario(string nombre, string apPaterno, string apMaterno) {
            Nombre = nombre;
            ApellidoPaterno = apPaterno;
            ApellidoMaterno = apMaterno;
        }

        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NombreUsuario { get; set; }
        public Enums.Enums.Estado Estado { get; set; }
        public clsUsuarioCargo Cargo { get; set; }


        public IList<clsUsuarioCargo> Cargos { get; set; }
        public IList<clsPerfil> Perfiles { get; set; }

        public Enums.Enums.UsuariosCargo CargoEnum { get; set; }
        public string Email { get; set; }
        public DateTime FechaCreacion { get; set; }

        public string NombreCompleto {
            get {
                return Nombre + " " + ApellidoPaterno + " " + ApellidoMaterno;
            }
        }

        public override string ToString() {
            return Nombre + " " + ApellidoPaterno + " " + ApellidoMaterno;
        }

        public string Iniciales {
            get { return Nombre.Substring(0, 1) + ApellidoPaterno.Substring(0, 1); }
        }

    }
}
