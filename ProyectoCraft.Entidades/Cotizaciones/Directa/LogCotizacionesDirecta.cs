using System;
using System.Collections;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Usuarios;

namespace ProyectoCraft.Entidades.Cotizaciones.Directa {
    public class LogCotizacionesDirecta : IdentifiableObject {
        public LogCotizacionesDirecta() {
            _descripciones = new Hashtable{
                                              {0, ""},
                                              {1, "Ingreso de cotizacion"},
                                              {2, "Modificaciones de cotizacion"},
                                              {3, "Envio de cotizacion"}
                                          };
        }

        private Hashtable _descripciones;
        public clsUsuario Usuario { set; get; }
        public CotizacionDirecta CotizacionDirecta { set; get; }
        public DateTime Fecha { set; get; }
        public EnumTipoLogCotizacionDirecta Tipo { set; get; }
        public String Descripcion { get { return _descripciones[(Int32)Tipo].ToString(); } }
    }

    public enum EnumTipoLogCotizacionDirecta {
        IngresoCotizacion = 1,
        Modificacion = 2,
        Envio = 3,
    }
}
