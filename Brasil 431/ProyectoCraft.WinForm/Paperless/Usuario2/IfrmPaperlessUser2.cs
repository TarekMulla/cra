using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Paperless;

namespace SCCMultimodal.Paperless.Usuario2 {
    public interface IFrmPaperlessUser2 {
        PaperlessAsignacion PaperlessAsignacionActual { get; set; }
        Enums.TipoAccionFormulario Accion { get; set; }
        ResultadoTransaccion PrepararPasos();
        void MyShowDialog();
    }
}
