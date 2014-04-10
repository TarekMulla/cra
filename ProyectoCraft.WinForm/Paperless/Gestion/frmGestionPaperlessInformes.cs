using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraPrinting;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Paperless;
using SCCMultimodal.Utils;


namespace SCCMultimodal.Paperless.Gestion {
    public partial class frmGestionPaperlessInformes : Form {
        private static frmGestionPaperlessInformes _instancia = null;
        public static frmGestionPaperlessInformes Instancia {
            get {
                if (_instancia == null)
                    _instancia = new frmGestionPaperlessInformes();

                return _instancia;
            }
            set {
                _instancia = value;
            }
        }

        public frmGestionPaperlessInformes() {
            InitializeComponent();

        }

        private void frmGestionPaperlessInformes_Load(object sender, EventArgs e) {
            CargarTiposDeInforme();
            CargarValoresIniciales();
        }

        private void CargarValoresIniciales() {
            CargarTipoCargas();
            CargarEstados();
            CargarEmpresas();
            CargarFechasDefault();
            gridControl1.DataSource = null;
            gridView1.Columns.Clear();
        }

        public void CargarTipoCargas() {
            var tipoDeCarga = ProyectoCraft.LogicaNegocios.Paperless.Paperless.ListarTipoCargaDescripcionLarga(Enums.Estado.Todos);
            chkListTipoCarga.Items.Clear();
            chkListTipoCarga.BackColor = groupControl1.Parent.BackColor;
            foreach (var carga in tipoDeCarga) {
                var item = new CheckedListBoxItem();
                item.Value = carga.Id32;
                item.Description = carga.DescripcionLarga;
                item.CheckState = CheckState.Checked;
                chkListTipoCarga.Items.Add(item);
            }

        }
        public void CargarEstados() {
            var estados = ProyectoCraft.LogicaNegocios.Paperless.Paperless.ObtenerEstadosPaperless(Enums.Estado.Todos);
            chkListEstado.Items.Clear();
            chkListEstado.BackColor = groupControl1.Parent.BackColor;
            foreach (var estado in estados) {
                var item = new CheckedListBoxItem();
                item.Value = estado.Id32;
                item.CheckState = CheckState.Checked;
                item.Description = estado.Nombre;
                chkListEstado.Items.Add(item);
            }
        }

        public void CargarEmpresas() {
            List<PaperlessEmpresa> empresas = ProyectoCraft.LogicaNegocios.Paperless.Paperless.ListarEmpresas();
            ChkListMarca.Items.Clear();
            ChkListMarca.BackColor = groupControl1.Parent.BackColor;
            foreach (var carga in empresas) {
                var item = new CheckedListBoxItem();
                item.Value = carga.Codigo;
                item.Description = carga.Nombre;
                item.CheckState = CheckState.Checked;
                ChkListMarca.Items.Add(item);
            }
        }

        private void CargarFechasDefault() {
            /*TxtDesdeCreacion.EditValue = TxtDesdeEmbarcador.EditValue = DateTime.Now.AddDays(-30);
            TxtHastaCreacion.EditValue = TxtHastaEmbarcador.EditValue = DateTime.Now;*/
        }

        private void CargarTiposDeInforme() {
            ddlInforme.Properties.Items.Clear();
            ddlInforme.Properties.Items.Add(new InformeTypes { Id32 = 1, Id = 1, Nombre = "Informe de Asignaciones" });
            ddlInforme.Properties.Items.Add(new InformeTypes { Id32 = 2, Id = 2, Nombre = "Informe de Excepciones de HBL" });
            ddlInforme.Properties.Items.Add(new InformeTypes { Id32 = 3, Id = 3, Nombre = "Informe de Excepciones Master" });
            ddlInforme.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
            MenuExportar.Enabled = true;


            var sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            var nombreProcedure = String.Empty;
            if (((InformeTypes)ddlInforme.SelectedItem).Id32 == 1)
                nombreProcedure = "SP_PAPERLESS_INFORME_ASIGNACION";

            if (((InformeTypes)ddlInforme.SelectedItem).Id32 == 2)
                nombreProcedure = "SP_PAPERLESS_INFORME_EXCEPCIONES_HBL";

            if (((InformeTypes)ddlInforme.SelectedItem).Id32 == 3)
                nombreProcedure = "SP_PAPERLESS_INFORME_EXCEPCIONES_MASTER";

            var estadosToSP = String.Join(",", chkListEstado.CheckedItems.Cast<CheckedListBoxItem>().ToList().Select(foo => foo.Value.ToString()).ToArray());
            var cargasToSP = String.Join(",", chkListTipoCarga.CheckedItems.Cast<CheckedListBoxItem>().ToList().Select(foo => foo.Value.ToString()).ToArray());
            var marcaToSP = String.Join(",", ChkListMarca.CheckedItems.Cast<CheckedListBoxItem>().ToList().Select(foo => foo.Value.ToString()).ToArray());


            DateTime fechaCreacionIni, fechaCreacionFin, fechaEmbarcadorIni, fechaEmbarcadorFin;

            if (TxtDesdeCreacion.EditValue != null)
                fechaCreacionIni = ((DateTime)TxtDesdeCreacion.EditValue);
            else
                fechaCreacionIni = new DateTime(1990, 1, 1);

            if (TxtHastaCreacion.EditValue != null)
                fechaCreacionFin = ((DateTime)TxtHastaCreacion.EditValue);
            else
                fechaCreacionFin = DateTime.Now.AddYears(500);


            if (TxtDesdeEmbarcador.EditValue != null)
                fechaEmbarcadorIni = ((DateTime)TxtDesdeEmbarcador.EditValue);
            else
                fechaEmbarcadorIni = new DateTime(1990, 1, 1);

            if (TxtHastaEmbarcador.EditValue != null)
                fechaEmbarcadorFin = ((DateTime)TxtHastaEmbarcador.EditValue);
            else
                fechaEmbarcadorFin = DateTime.Now.AddYears(500);

            fechaCreacionIni = new DateTime(fechaCreacionIni.Year, fechaCreacionIni.Month, fechaCreacionIni.Day, 00, 01, 00);
            fechaEmbarcadorIni = new DateTime(fechaEmbarcadorIni.Year, fechaEmbarcadorIni.Month, fechaEmbarcadorIni.Day, 00, 01, 00);

            fechaCreacionFin = new DateTime(fechaCreacionFin.Year, fechaCreacionFin.Month, fechaCreacionFin.Day, 23, 59, 59);
            fechaEmbarcadorFin = new DateTime(fechaEmbarcadorFin.Year, fechaEmbarcadorFin.Month, fechaEmbarcadorFin.Day, 23, 59, 59);

            sqlCommand.CommandText = nombreProcedure;

            sqlCommand.Parameters.AddWithValue("estados", estadosToSP);
            sqlCommand.Parameters.AddWithValue("cargas", cargasToSP);
            sqlCommand.Parameters.AddWithValue("empresas", marcaToSP);
            sqlCommand.Parameters.AddWithValue("fechaCreacionIni", fechaCreacionIni);
            sqlCommand.Parameters.AddWithValue("fechaCreacionFin", fechaCreacionFin);
            sqlCommand.Parameters.AddWithValue("fechaEmbarcadorIni", fechaEmbarcadorIni);
            sqlCommand.Parameters.AddWithValue("fechaEmbarcadorFin", fechaEmbarcadorFin);

            var dt = GenericQueryUtil.ExecuteGenericQueryDataSet(sqlCommand);

            gridView1.BeginUpdate();
            gridView1.Columns.Clear();
            gridControl1.DataSource = dt.Tables[0];
            //Logica para que muestra todos los datos de tipo fecha con su hora.
            foreach (DataColumn column in dt.Tables[0].Columns) {
                if (column.DataType == typeof(DateTime))
                    if (column.ColumnName != "FechaMaster" && column.ColumnName != "FechaETA" && column.ColumnName != "PlazoEmbarcadores")
                        gridView1.Columns[column.ColumnName].DisplayFormat.FormatString = "G";

            }
            gridView1.BestFitColumns();
            gridView1.HorzScrollVisibility = ScrollVisibility.Always;
            gridView1.EndUpdate();
            Cursor.Current = Cursors.Default;
        }


        private void chkListTipoCarga_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void toolStripButton2_Click(object sender, EventArgs e) {
            Instancia = null;
            Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e) {
            try {
                var grabarArchivo = new SaveFileDialog();
                grabarArchivo.Filter = "Excel(xls)|*.xls";
                grabarArchivo.Title = "Exportar Excel";
                grabarArchivo.DefaultExt = "xls";
                grabarArchivo.FileName = "";
                grabarArchivo.OverwritePrompt = true;
                grabarArchivo.ShowDialog();

                if (grabarArchivo.FileName != "") {
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

        private void frmGestionPaperlessInformes_FormClosed(object sender, FormClosedEventArgs e) {
            Instancia = null;
        }

        private void ddlInforme_SelectedIndexChanged(object sender, EventArgs e) {
            CargarValoresIniciales();
        }
    }

    class InformeTypes : NamedObject { }
}
