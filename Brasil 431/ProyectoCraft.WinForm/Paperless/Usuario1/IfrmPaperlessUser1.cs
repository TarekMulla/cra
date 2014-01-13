using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Paperless;

namespace SCCMultimodal.Paperless.Usuario1 {
    public interface IFrmPaperlessUser1 {
        PaperlessAsignacion PaperlessAsignacionActual { get; set; }
        Enums.TipoAccionFormulario Accion { get; set; }
        ResultadoTransaccion PrepararPasos ();
        void LimpiarFormulario();
        void CargarInformacionAsignacionInicial();
        void MyShowDialog();
    }
}
