using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.LogicaNegocios.PanelDeControl;
using SCCMultimodal.Paperless.Usuario1;
using SCCMultimodal.Paperless.Usuario2;


namespace SCCMultimodal.Panel_de_control {
    public partial class formDetailPanelDeControl : Form {
        private static formDetailPanelDeControl _form = null;
        public String query { set; get; }

        public formDetailPanelDeControl() {
            InitializeComponent();
        }

        public static formDetailPanelDeControl Instancia {
            get {
                if (_form == null)
                    _form = new formDetailPanelDeControl();

                return _form;
            }
            set {
                _form = value;
            }
        }

        private void formDetailPanelDeControl_Load(object sender, EventArgs e) {
            var resultado = ClsPanelDeControl.ExecuteGenericqueryDataset(query);

            var colorsGreen = new List<int>();
            var colorsRed = new List<int>();
            var hide = new List<int>();
            var dt = resultado.ObjetoTransaccion as DataSet;

            var i = 0;
            foreach (DataColumn column in dt.Tables[0].Columns) {
                if (column.ColumnName.Trim().ToUpper().Contains("_GREEN")) {
                    colorsGreen.Add(i);
                    column.ColumnName = column.ColumnName.Replace("_GREEN", "");
                    column.ColumnName = column.ColumnName.Replace("_green", "");
                }
                if (column.ColumnName.Trim().ToUpper().Contains("_RED")) {
                    colorsRed.Add(i);
                    column.ColumnName = column.ColumnName.Replace("_RED", "");
                    column.ColumnName = column.ColumnName.Replace("_red", "");
                }
                if (column.ColumnName.Trim().ToUpper().Contains("_HIDE")) {
                    hide.Add(i);
                    column.ColumnName = column.ColumnName.Replace("_HIDE", "");
                    column.ColumnName = column.ColumnName.Replace("_hide", "");
                }
                i++;
            }

            gridControl1.DataSource = dt.Tables[0];

            foreach (var i1 in colorsGreen) {
                gridView1.Columns[i1].AppearanceCell.BackColor = System.Drawing.Color.Green;
                gridView1.Columns[i1].AppearanceCell.ForeColor = System.Drawing.Color.White;
            }

            foreach (var i1 in colorsRed) {
                gridView1.Columns[i1].AppearanceCell.BackColor = System.Drawing.Color.Red;
                gridView1.Columns[i1].AppearanceCell.ForeColor = System.Drawing.Color.White;
            }

            foreach (var i1 in hide) {
                gridView1.Columns[i1].Visible = false;
            }

            if (!query.ToUpper().Contains("PAPERLESS")) {
                MenuAsignacion.Visible = Menu1raEtapa.Visible = Menu2daEtapa.Visible = false;
            }
            //gridView1.BestFitColumns();
        }

        private void formDetailPanelDeControl_closed(object sender, FormClosedEventArgs e) {
            Instancia = null;
        }

        private void MENUEXCEL_Click(object sender, EventArgs e) {
            try {
                var grabarArchivo = new SaveFileDialog();
                grabarArchivo.Filter = "Excel(xls)|*.xls";
                grabarArchivo.Title = "Exportar Excel";
                grabarArchivo.DefaultExt = "xls";
                grabarArchivo.FileName = "";
                grabarArchivo.OverwritePrompt = true;
                grabarArchivo.ShowDialog();

                if (grabarArchivo.FileName != "") {
                    gridView1.BestFitColumns();
                    gridView1.OptionsPrint.AutoWidth = false;
                    // Saves the Image via a FileStream created by the OpenFile method.
                    var fs = (FileStream)grabarArchivo.OpenFile();
                    var options = new XlsExportOptions();
                    options.ShowGridLines = true;
                    options.UseNativeFormat = false;
                    gridView1.BestFitColumns();
                    gridView1.OptionsPrint.AutoWidth = false;
                    gridView1.ExportToXls(fs, options);
                    fs.Close();
                }
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);
                MessageBox.Show("Error al generar archivo Excel: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenuSalir_Click(object sender, EventArgs e) {
            Instancia = null;
            Close();
        }

        private ProyectoCraft.Entidades.Paperless.PaperlessAsignacion ObtenerAsignacion() {
            var filaSelected = gridControl1.DefaultView.GetRow(gridView1.FocusedRowHandle);
            if (filaSelected == null) {
                return null;
            }

            var temp = Convert.ToInt64(((DataRowView)gridView1.GetRow(gridView1.FocusedRowHandle)).Row["id_asignacion"]);
            var asignacion = ProyectoCraft.LogicaNegocios.Paperless.Paperless.ObtenerAsignacionPorId(temp);
            return asignacion;
        }


        private void MenuAsignacion_Click(object sender, EventArgs e) {
            ProyectoCraft.Entidades.Paperless.PaperlessAsignacion asignacion = ObtenerAsignacion();
            ProyectoCraft.WinForm.Paperless.Asignacion.frmPaperlessAsignacion form = ProyectoCraft.WinForm.Paperless.Asignacion.frmPaperlessAsignacion.Instancia;

            if (asignacion != null) {
                form.PaperlessAsignacionActual = asignacion;
                form.FormLoad();
                form.CargarFormulario();
                form.Accion = Enums.TipoAccionFormulario.Consultar;
                form.ShowDialog();


            } else
                MessageBox.Show("Debe seleccionar una asignacion", "Paperless - Asignacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void Menu1raEtapa_Click(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
            var asignacion = ObtenerAsignacion();

            IFrmPaperlessUser1 form = null;

            if (asignacion != null) {
                if (asignacion.VersionUsuario1 == 1)
                    form = ProyectoCraft.WinForm.Paperless.Usuario1.FrmPaperlessUser1.Instancia;
                if (asignacion.VersionUsuario1 == 2)
                    form = ProyectoCraft.WinForm.Paperless.Usuario1.frmPaperlessUser1v2.Instancia;


                form.PaperlessAsignacionActual = asignacion;
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
            var asignacion = ObtenerAsignacion();
            IFrmPaperlessUser2 form = null;

            if (asignacion.VersionUsuario1 == 1)
                form = ProyectoCraft.WinForm.Paperless.Usuario2.frmPaperlessUser2.Instancia;
            if (asignacion.VersionUsuario1 == 2)
                form = ProyectoCraft.WinForm.Paperless.Usuario2.frmPaperlessUser2v2.Instancia;

            if (asignacion != null) {
                form.PaperlessAsignacionActual = asignacion;
                form.Accion = Enums.TipoAccionFormulario.Consultar;
                form.MyShowDialog();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            var asignacion = ObtenerAsignacion();

            MenuAsignacion.Enabled = false;
            Menu1raEtapa.Enabled = false;
            Menu2daEtapa.Enabled = false;

            if (asignacion != null && (asignacion.Estado == Enums.EstadoPaperless.AceptadoUsuario1 ||
                                       asignacion.Estado == Enums.EstadoPaperless.AsignadoUsuario1 ||
                                       asignacion.Estado == Enums.EstadoPaperless.EnProcesoUsuario1 ||
                                       asignacion.Estado == Enums.EstadoPaperless.EnProcesoUsuario2 ||
                                       asignacion.Estado == Enums.EstadoPaperless.EnviadoUsuario2 ||
                                       asignacion.Estado == Enums.EstadoPaperless.ProcesoTerminado ||
                                       asignacion.Estado == Enums.EstadoPaperless.RechazadaUsuario1)) {
                MenuAsignacion.Enabled = true;
            }

            if (asignacion != null && (asignacion.Estado == Enums.EstadoPaperless.EnProcesoUsuario1 ||
                                      asignacion.Estado == Enums.EstadoPaperless.EnProcesoUsuario2 ||
                                      asignacion.Estado == Enums.EstadoPaperless.EnviadoUsuario2 ||
                                      asignacion.Estado == Enums.EstadoPaperless.ProcesoTerminado)) {
                Menu1raEtapa.Enabled = true;
            }

            if (asignacion != null && (asignacion.Estado == Enums.EstadoPaperless.EnProcesoUsuario2 ||
                                      asignacion.Estado == Enums.EstadoPaperless.ProcesoTerminado ||
                                      asignacion.Estado == Enums.EstadoPaperless.EnviadoMercante
                                      )) {
                Menu2daEtapa.Enabled = true;
            }

        }

    }
}
