﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.LogicaNegocios.Cotizaciones;

namespace SCCMultimodal.Mantenedores {
    public partial class frmPuertos : Form {
        private Puerto _puerto = null;
        private List<String> _paises = null;

        public frmPuertos() {
            InitializeComponent();
        }

        private static frmPuertos _instancia = null;

        public static frmPuertos Instancia {
            get {
                if (_instancia == null)
                    _instancia = new frmPuertos();

                return _instancia;
            }
            set {
                _instancia = value;
            }
        }

        private void LimpiarDatos() {
            txtCodigo.Text = txtNombre.Text = txtPais.Text = String.Empty;
            groupControl1.Text = "Nuevo";
            txtCodigo.Enabled = true;
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e) {
            _puerto = null;
            ActiveControl = txtCodigo;
            LimpiarDatos();
            gridView1.ClearSelection();
            var seleccionados = gridView1.GetSelectedRows();
            foreach (var i in seleccionados)
                gridView1.UnselectRow(i);
        }

        private void ListarPuertos() {
            var puertos = ClsPuertos.ObtieneTodosLosPuertos().ObjetoTransaccion as List<Puerto>;
            gridPuertos.DataSource = puertos;
            gridPuertos.RefreshDataSource();
        }

        private void frmPuertos_Load(object sender, EventArgs e) {
            _paises = ClsPuertos.ObtieneLosPaisesConPuertos().ObjetoTransaccion as List<String>;
            txtPais.MaskBox.AutoCompleteMode = AutoCompleteMode.Append;
            txtPais.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (var p in _paises)
                auto.Add(p);
            txtPais.MaskBox.AutoCompleteCustomSource = auto;
        }

        private void toolStripButton1_Click(object sender, EventArgs e) {
            Instancia = null;
            Close();
        }

        private void MenuExcel_Click(object sender, EventArgs e) {
            try {
                SaveFileDialog GrabarArchivo = new SaveFileDialog();
                GrabarArchivo.Filter = "Excel(xls)|*.xls";
                GrabarArchivo.Title = "Exportar Excel";
                GrabarArchivo.DefaultExt = "xls";
                GrabarArchivo.FileName = "";
                GrabarArchivo.OverwritePrompt = true;
                GrabarArchivo.ShowDialog();

                if (GrabarArchivo.FileName != "") {
                    // Saves the Image via a FileStream created by the OpenFile method.
                    System.IO.FileStream fs =
                       (System.IO.FileStream)GrabarArchivo.OpenFile();
                    gridPuertos.ExportToXls(fs, true);

                    fs.Close();
                }
            } catch (Exception ex) {
                Log.EscribirLog(ex.Message);
                MessageBox.Show("Error al generar archivo Excel: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            var puerto = GetSelectedRow(sender as GridView);
            if (puerto == null) {//Se seleccionaron los filtros de la grilla
                LimpiarDatos();
                MenuEliminar.Enabled = false;
            } else {
                _puerto = puerto;
                txtCodigo.Text = puerto.Codigo;
                txtPais.Text = puerto.Pais;
                txtNombre.Text = puerto.Nombre;
                groupControl1.Text = "Editar";
                MenuEliminar.Enabled = true;
                txtCodigo.Enabled = false;
            }

        }

        private Puerto GetSelectedRow(GridView view) {
            return (Puerto)view.GetRow(view.FocusedRowHandle);
        }

        private void MenuActualizar_Click(object sender, EventArgs e) {
            ListarPuertos();
        }

        private Puerto BindViewToDomain() {
            var puerto = new Puerto();
            puerto.Codigo = txtCodigo.Text;
            puerto.Nombre = txtNombre.Text;
            puerto.Pais = txtPais.Text;
            return puerto;
        }

        private bool validar(){
            ctrldxError.ClearErrors();
            if (String.IsNullOrEmpty(txtCodigo.Text))
                ctrldxError.SetError(txtCodigo,"Debe ingresar el Codigo");
            if (String.IsNullOrEmpty(txtNombre.Text))
                ctrldxError.SetError(txtNombre, "Debe ingresar el Nombre");
            if (String.IsNullOrEmpty(txtPais.Text))
                ctrldxError.SetError(txtPais, "Debe ingresar el Pais");
            return ctrldxError.HasErrors;
        }
        private void btnGuardar_Click(object sender, EventArgs e) {
            if (validar())
                return;
            var puerto = BindViewToDomain();
            ResultadoTransaccion resultado = null;
            try {
                if (_puerto == null)
                    resultado = ClsPuertos.CreaPuerto(puerto);
                else
                    resultado = ClsPuertos.ActualizaPuerto(puerto);
                MessageBox.Show(resultado.Descripcion, "Mantenedor de Puertos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _puerto = null;

                LimpiarDatos();
                if (gridPuertos.DataSource != null)
                    ListarPuertos();

            } catch (Exception ex) {
                Console.Write(ex.InnerException);
            }
        }

        private void txtPais_EditValueChanged(object sender, EventArgs e) {

        }

        private void MenuEliminar_Click(object sender, EventArgs e)
        {

            DialogResult resultado;
            resultado = MessageBox.Show("¿Está seguro que desea Eliminar el Puerto?", "Eliminar Puerto",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                        MessageBoxDefaultButton.Button2);
            if (resultado == DialogResult.Yes)
            { 
                ClsPuertos.EliminaPuerto(GetSelectedRow(gridView1));
                LimpiarDatos();
                if (gridPuertos.DataSource != null)
                ListarPuertos();
            }

        }

        private void frmPuertos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
        }

        private void gridPuertos_Click(object sender, EventArgs e)
        {

        }
    }
}
