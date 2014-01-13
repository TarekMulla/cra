using System;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.Entidades.Paperless {
    public class PaperlessUsuario1Disputas : IdentifiableObject {

        public Int64? Numero { get; set; }
        public PaperlessTipoDisputa TipoDisputa { set; get; }
        public String Descripcion { set; get; }
    }
}
