using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProyectoCraft.Base.Usuario;
using ProyectoCraft.Entidades.Ventas.Pricing;

namespace SCCMultimodal.Ventas.Pricing
{
    public partial class FrmListarTarifas : Form
    {

        private static FrmListarTarifas _form = null;
        public static FrmListarTarifas Instancia
        {
            get
            {
                if (_form == null)
                    _form = new FrmListarTarifas();

                return _form;
            }
            set
            {
                _form = value;
            }
        }

        public FrmListarTarifas()
        {
            InitializeComponent();
        }

        private void MenuSalir_Click(object sender, System.EventArgs e)
        {
            Instancia = null;
            this.Close();
        }

        private void FrmListarTarifas_Load(object sender, System.EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            //var cot = ProyectoCraft.LogicaNegocios.Ventas.pricing.ClsCotizacion.ListarTodosLasCotizacionesPorUsuario(UsuarioConectado.Usuario.Id32).ObjetoTransaccion as List<ClsSolicitudCotizacionIndirecta>; ;
            var cot = new List<ClsSolicitudCotizacionIndirecta>();
            var foo = new ClsSolicitudCotizacionIndirecta();
            foo.NavieraReferencia = "hola";
            cot.Add(foo);
            GridMisTarifas.DataSource = cot;

        }

        private void MenuIngresarTarifa_Click(object sender, System.EventArgs e)
        {
            var foo = FrmIngresarTarifa.Instancia;
            foo.SolicitudCotizacionIndirecta = GetActualCotizacion();
            foo.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, System.EventArgs e)
        {
            var foo = FrmSolicitarTarifa.Instancia;
            foo.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, System.EventArgs e)
        {
            var fila_sel = gridViewMisTarifas.GetSelectedRows()[0];
            if (fila_sel >= 0)
            {
                var objTarifa = (ClsSolicitudCotizacionIndirecta)gridViewMisTarifas.GetRow(fila_sel);
                var foo = FrmFichaTarifa.Instancia;
                foo.LlenaDatos(objTarifa);
                foo.ShowDialog();

            }
        }


        private ClsSolicitudCotizacionIndirecta GetActualCotizacion()
        {
            ClsSolicitudCotizacionIndirecta cot = new ClsSolicitudCotizacionIndirecta();
            int fila_sel = 0;
            if (gridViewMisTarifas.RowCount > 0)
            {
                fila_sel = gridViewMisTarifas.GetSelectedRows()[0];
                if (fila_sel >= 0)
                {
                    var objCotTarifa = (ClsSolicitudCotizacionIndirecta)gridViewMisTarifas.GetRow(fila_sel);
                    cot = objCotTarifa;
                }
            }
            return cot;
        }

        private void FrmListarTarifas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
        }

        private void GridMistarifas_Click(object sender, EventArgs e)
        {

            Aceptar_Logica();

        }
        private void Aceptar_Logica()
        {
            var fila_sel = gridViewMisTarifas.GetSelectedRows()[0];
            if (fila_sel >= 0)
            {
                var objTarifa = (ClsSolicitudCotizacionIndirecta)gridViewMisTarifas.GetRow(fila_sel);
                MenuAceptar.Enabled = objTarifa.Estado.Equals(ClsEstado.Estado.Ingresado);
                MenuIngresarTarifa.Enabled = !objTarifa.Estado.Equals(ClsEstado.Estado.Ingresado);
            }
        }

        private void GridViewMisTarifasFocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            Aceptar_Logica();
        }

        private void MenuAceptar_Click(object sender, EventArgs e)
        {
            var cot = this.GetActualCotizacion();
            cot.Estado = ClsEstado.Estado.Enproceso;

            var res = ProyectoCraft.LogicaNegocios.Ventas.pricing.ClsCotizacion.ActualizaEstadoCotizacion(
            cot);

            MessageBox.Show(res.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            MenuAceptar.Enabled = false;
            MenuIngresarTarifa.Enabled = true;
        }

    }
}