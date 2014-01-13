using System;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.Entidades.Cotizaciones.Directa {
    public class Puerto : IdentifiableObject {
        public String Codigo { set; get; }
        public String Nombre { set; get; }

        public override string ToString(){
            return Nombre;
        }
    }
}