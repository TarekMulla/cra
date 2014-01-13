using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Paperless;
using ProyectoCraft.Entidades.Usuarios;
using SCCMultimodal.Paperless.Usuario1;
using SCCMultimodal.Paperless.Usuario2;

namespace ProyectoCraft.WinForm.Paperless.Gestion {
    public partial class frmGestionPaperless : Form {
        public frmGestionPaperless() {
            InitializeComponent();
        }

        private static frmGestionPaperless _instancia;
        public static frmGestionPaperless Instancia {
            get {
                if (_instancia == null)
                    _instancia = new frmGestionPaperless();

                return _instancia;
            }
            set { _instancia = value; }
        }


        private void frmGestionPaperless_Load(object sender, EventArgs e) {
            this.Dock = DockStyle.Fill;
            CargarUsuarios();
            CargarNavesExistentes();

        }
        private void CargarNavesExistentes() {
            ComboBoxItemCollection coll = ddlNave.Properties.Items;
            IList<Entidades.Paperless.PaperlessNave> listNaves = new List<Entidades.Paperless.PaperlessNave>();

            listNaves = LogicaNegocios.Paperless.Paperless.ObtenerNaves(Entidades.Enums.Enums.Estado.Habilitado);

            coll = ddlNave.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listNaves) {
                coll.Add(list);
            }
            ddlNave.SelectedIndex = 0;
            ddlNave.Properties.AutoComplete = true;

            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Add(txtNave.Text);
            txtNave.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtNave.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (var list in listNaves) {
                auto.Add(list.Nombre);
            }
            txtNave.AutoCompleteCustomSource = auto;
        }
        private void CargarUsuarios() {
            ComboBoxItemCollection coll = ddlUsuario1.Properties.Items;
            ComboBoxItemCollection coll2 = ddlUsuario2.Properties.Items;
            IList<Entidades.Usuarios.clsUsuario> listusuarios = new List<clsUsuario>();
            Entidades.GlobalObject.ResultadoTransaccion resultado = new ResultadoTransaccion();

            resultado = LogicaNegocios.Usuarios.clsUsuarios.ListarUsuarios(Enums.Estado.Habilitado,
                                                                              Enums.CargosUsuarios.EncargadoDocumental1raEtapa);
            if (resultado.Estado == Enums.EstadoTransaccion.Aceptada)
                listusuarios = (IList<clsUsuario>)resultado.ObjetoTransaccion;

            coll = ddlUsuario1.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listusuarios) {
                coll.Add(list);
            }
            ddlUsuario1.SelectedIndex = 0;


            resultado = LogicaNegocios.Usuarios.clsUsuarios.ListarUsuarios(Enums.Estado.Habilitado,
                                                                              Enums.CargosUsuarios.EncargadoDocumental2daEtapa);
            if (resultado.Estado == Enums.EstadoTransaccion.Aceptada)
                listusuarios = (IList<clsUsuario>)resultado.ObjetoTransaccion;

            coll2 = ddlUsuario2.Properties.Items;
            coll2.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listusuarios) {
                coll2.Add(list);
            }

            ddlUsuario2.SelectedIndex = 0;
            ddlUsuario2.Properties.AutoComplete = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e) {
            Buscar();
        }

        private void Buscar() {
            string nummaster = "-1";
            string numconsolidado = "-1";
            DateTime desde = new DateTime(9999, 1, 1);
            DateTime hasta = new DateTime(9999, 1, 1);
            DateTime desdeNavieras = new DateTime(9999, 1, 1);
            DateTime hastaNavieras = new DateTime(9999, 1, 1);
            DateTime desdeEmbarcadores = new DateTime(9999, 1, 1);
            DateTime hastaEmbarcadores = new DateTime(9999, 1, 1);

            Int64 usuario1 = -1;
            Int64 usuario2 = -1;
            string nave = "";


            if (txtNumMaster.Text.Length > 0)
                nummaster = txtNumMaster.Text;

            if (txtNumConsoidado.Text.Length > 0)
                numconsolidado = txtNumConsoidado.Text;

            if (txtDesde.Enabled.Equals(true) && txtDesde.Text.Length > 0)
                desde = new DateTime(txtDesde.DateTime.Year, txtDesde.DateTime.Month, txtDesde.DateTime.Day, 0, 0, 1);

            if (txtHasta.Enabled.Equals(true) && txtHasta.Text.Length > 0)
                hasta = new DateTime(txtHasta.DateTime.Year, txtHasta.DateTime.Month, txtHasta.DateTime.Day, 23, 59, 59);

            if (txtdesdeEmbarcador.Enabled.Equals(true) && txtdesdeEmbarcador.Text.Length > 0)
                desdeEmbarcadores = new DateTime(txtdesdeEmbarcador.DateTime.Year, txtdesdeEmbarcador.DateTime.Month, txtdesdeEmbarcador.DateTime.Day, 0, 0, 1);

            if (txtHastaEmbarcador.Enabled.Equals(true) && txtHastaEmbarcador.Text.Length > 0)
                hastaEmbarcadores = new DateTime(txtHastaEmbarcador.DateTime.Year, txtHastaEmbarcador.DateTime.Month, txtHastaEmbarcador.DateTime.Day, 23, 59, 59);

            if (txtdesdeNavieras.Enabled.Equals(true) && txtdesdeNavieras.Text.Length > 0)
                desdeNavieras = new DateTime(txtdesdeNavieras.DateTime.Year, txtdesdeNavieras.DateTime.Month, txtdesdeNavieras.DateTime.Day, 0, 0, 1);

            if (txthastaNavieras.Enabled.Equals(true) && txthastaNavieras.Text.Length > 0)
                hastaNavieras = new DateTime(txthastaNavieras.DateTime.Year, txthastaNavieras.DateTime.Month, txthastaNavieras.DateTime.Day, 23, 59, 59);

            if (ddlUsuario1.SelectedIndex > 0)
                usuario1 = ((clsUsuario)ddlUsuario1.SelectedItem).Id;

            if (ddlUsuario2.SelectedIndex > 0)
                usuario2 = ((clsUsuario)ddlUsuario2.SelectedItem).Id;
            if (!string.IsNullOrEmpty(txtNave.Text))
                nave = txtNave.Text;

            IList<Entidades.Paperless.PaperlessFlujo> asignaciones =
                LogicaNegocios.Paperless.Paperless.ConsultarGestionPaperless(nummaster, numconsolidado, desde, hasta,
                                                                             usuario1, usuario2, nave
                                                                             , desdeEmbarcadores, hastaEmbarcadores, desdeNavieras, hastaNavieras);


            grdAsignaciones.DataSource = asignaciones;
            grdAsignaciones.RefreshDataSource();


        }

        private void MENUEXCEL_Click(object sender, EventArgs e) {
            try {
                SaveFileDialog GrabarArchivo = new SaveFileDialog();
                GrabarArchivo.Filter = "Excel(xls)|*.xls";
                GrabarArchivo.Title = "Exportar Excel";
                GrabarArchivo.DefaultExt = "xls";
                GrabarArchivo.FileName = "Gestion Paperless";
                GrabarArchivo.OverwritePrompt = true;
                GrabarArchivo.ShowDialog();

                if (GrabarArchivo.FileName != "") {
                    System.IO.FileStream fs =
                       (System.IO.FileStream)GrabarArchivo.OpenFile();
                    this.grdAsignaciones.ExportToXls(fs, true);

                    fs.Close();
                }
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);
                MessageBox.Show("Error al generar archivo Excel: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdAsignaciones_Click(object sender, EventArgs e) {
            Entidades.Paperless.PaperlessFlujo asignacion = ObtenerAsignacion();

            MenuAsignacion.Enabled = false;
            Menu1raEtapa.Enabled = false;
            Menu2daEtapa.Enabled = false;

            if (asignacion != null && (asignacion.EstadoFlujo == Entidades.Enums.Enums.EstadoPaperless.AceptadoUsuario1 ||
                                       asignacion.EstadoFlujo == Entidades.Enums.Enums.EstadoPaperless.AsignadoUsuario1 ||
                                       asignacion.EstadoFlujo == Entidades.Enums.Enums.EstadoPaperless.EnProcesoUsuario1 ||
                                       asignacion.EstadoFlujo == Entidades.Enums.Enums.EstadoPaperless.EnProcesoUsuario2 ||
                                       asignacion.EstadoFlujo == Entidades.Enums.Enums.EstadoPaperless.EnviadoUsuario2 ||
                                       asignacion.EstadoFlujo == Entidades.Enums.Enums.EstadoPaperless.ProcesoTerminado ||
                                       asignacion.EstadoFlujo == Entidades.Enums.Enums.EstadoPaperless.RechazadaUsuario1)) {
                MenuAsignacion.Enabled = true;
            }

            if (asignacion != null && (asignacion.EstadoFlujo == Enums.EstadoPaperless.EnProcesoUsuario1 ||
                                      asignacion.EstadoFlujo == Enums.EstadoPaperless.EnProcesoUsuario2 ||
                                      asignacion.EstadoFlujo == Enums.EstadoPaperless.EnviadoUsuario2 ||
                                      asignacion.EstadoFlujo == Enums.EstadoPaperless.ProcesoTerminado)) {
                Menu1raEtapa.Enabled = true;
            }

            if (asignacion != null && (asignacion.EstadoFlujo == Enums.EstadoPaperless.EnProcesoUsuario2 ||
                                      asignacion.EstadoFlujo == Enums.EstadoPaperless.ProcesoTerminado)) {
                Menu2daEtapa.Enabled = true;
            }

        }

        private Entidades.Paperless.PaperlessFlujo ObtenerAsignacion() {
            var filaSelected = grdAsignaciones.DefaultView.GetRow(gridView1.FocusedRowHandle);

            if (filaSelected == null) {
                return null;
            }

            Entidades.Paperless.PaperlessFlujo asignacion = (Entidades.Paperless.PaperlessFlujo)filaSelected;

            return asignacion;
        }

        private void MenuSalir_Click(object sender, EventArgs e) {
            Instancia = null;
            Close();
        }

        private void MenuAsignacion_Click(object sender, EventArgs e) {
            Entidades.Paperless.PaperlessFlujo asignacion = ObtenerAsignacion();
            Asignacion.frmPaperlessAsignacion form = Asignacion.frmPaperlessAsignacion.Instancia;

            if (asignacion != null) {
                form.PaperlessAsignacionActual = asignacion.Asignacion;
                form.FormLoad();
                form.CargarFormulario();
                form.Accion = Enums.TipoAccionFormulario.Consultar;
                form.ShowDialog();


            } else
                MessageBox.Show("Debe seleccionar una asignacion", "Paperless - Asignacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Menu1raEtapa_Click(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
            Entidades.Paperless.PaperlessFlujo asignacion = ObtenerAsignacion();

            IFrmPaperlessUser1 form = null;

            if (asignacion != null) {
                if (asignacion.Asignacion.VersionUsuario1 == 1)
                    form = Usuario1.FrmPaperlessUser1.Instancia;
                if (asignacion.Asignacion.VersionUsuario1 == 2)
                    form = Usuario1.frmPaperlessUser1v2.Instancia;


                form.PaperlessAsignacionActual = asignacion.Asignacion;
                form.LimpiarFormulario();
                form.CargarInformacionAsignacionInicial();
                form.Accion = Enums.TipoAccionFormulario.Consultar;
                Cursor.Current = Cursors.Default;
                form.MyShowDialog();

            } else {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Debe seleccionar una asignacion", "Paperless - Asignacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Menu2daEtapa_Click(object sender, EventArgs e) {
            Entidades.Paperless.PaperlessFlujo asignacion = ObtenerAsignacion();
            IFrmPaperlessUser2 form = null;

            if (asignacion.Asignacion.VersionUsuario1 == 1)
                form = Usuario2.frmPaperlessUser2.Instancia;
            if (asignacion.Asignacion.VersionUsuario1 == 2)
                form = Usuario2.frmPaperlessUser2v2.Instancia;

            if (asignacion != null) {
                form.PaperlessAsignacionActual = asignacion.Asignacion;
                form.Accion = Enums.TipoAccionFormulario.Consultar;
                form.MyShowDialog();
            }
        }

        private void ChkPlazoEmbarcadorCheckedChanged(object sender, EventArgs e) {
            if (chkPlazoEmbarcador.Checked.Equals(true)) {
                txtdesdeEmbarcador.Enabled = true;
                txtHastaEmbarcador.Enabled = true;
            } else {
                txtdesdeEmbarcador.Enabled = false;
                txtHastaEmbarcador.Enabled = false;
            }
        }

        private void ChkAperturaNavieraCheckedChanged(object sender, EventArgs e) {
            if (chkAperturaNaviera.Checked.Equals(true)) {
                txtdesdeNavieras.Enabled = true;
                txthastaNavieras.Enabled = true;
            } else {
                txtdesdeNavieras.Enabled = false;
                txthastaNavieras.Enabled = false;
            }
        }

        private void ChkCreacionPaperlessCheckedChanged(object sender, EventArgs e) {
            if (chkCreacionPaperless.Checked.Equals(true)) {
                txtDesde.Enabled = true;
                txtHasta.Enabled = true;
            } else {
                txtDesde.Enabled = false;
                txtHasta.Enabled = false;
            }
        }

        private void checkedComboBoxEdit1_EditValueChanged(object sender, EventArgs e) {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void BtnBuscatTab2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPuerto.Text) || !string.IsNullOrEmpty(txtShipping.Text) )
            {
                IList<PaperlessUsuario1HousesBL> houses =
                LogicaNegocios.Paperless.Paperless.ObtenerHousesBLporShippingInstruction(txtShipping.Text, txtPuerto.Text);
                //houses[0].IdAsignacion
                //IList<PaperlessAsignacion> asignaciones = LogicaNegocios.Paperless.Paperless.ObtenerAsignacionPorId()

                grdHbls.DataSource = houses;
                grdHbls.RefreshDataSource();
            }                        
        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }

       
       
    }
}
