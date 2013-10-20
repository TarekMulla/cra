using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using ProyectoCraft.Base.Log;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Parametros;

namespace SCCMultimodal.Mantenedores
{
    public partial class frmAgentes : Form
    {
        private Agente _agente = null;

        public frmAgentes()
        {
            InitializeComponent();
        }

        private static frmAgentes _instancia = null;

        public static frmAgentes Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmAgentes();

                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        private void LimpiarDatos()
        {
            txtDescripcion.Text = txtContacto.Text = txtEmail.Text = txtAlias.Text = String.Empty;
            groupControl1.Text = "Nuevo";
            txtDescripcion.Enabled = true;
        }

        private void ListarAgentes()
        {
            var agentes = ClsAgente.ObtenerAgentes().ObjetoTransaccion as List<Agente>;
            GridAgentes2.DataSource = agentes;
            GridAgentes2.RefreshDataSource();
        }


        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            _agente = null;
            ActiveControl = txtDescripcion;
            LimpiarDatos();
            gridView1.ClearSelection();
            var seleccionados = gridView1.GetSelectedRows();
            foreach (var i in seleccionados)
                gridView1.UnselectRow(i);
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Instancia = null;
            Close();
        }

        private void MenuExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog GrabarArchivo = new SaveFileDialog();
                GrabarArchivo.Filter = "Excel(xls)|*.xls";
                GrabarArchivo.Title = "Exportar Excel";
                GrabarArchivo.DefaultExt = "xls";
                GrabarArchivo.FileName = "";
                GrabarArchivo.OverwritePrompt = true;
                GrabarArchivo.ShowDialog();

                if (GrabarArchivo.FileName != "")
                {
                    // Saves the Image via a FileStream created by the OpenFile method.
                    System.IO.FileStream fs =
                       (System.IO.FileStream)GrabarArchivo.OpenFile();
                    GridAgentes2.ExportToXls(fs, true);

                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);
                MessageBox.Show("Error al generar archivo Excel: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var agente = GetSelectedRow(sender as GridView);
            if (agente == null)
            {//Se seleccionaron los filtros de la grilla
                LimpiarDatos();
                MenuEliminar.Enabled = false;
            }
            else
            {
                _agente = agente;
                txtDescripcion.Text = agente.Descripcion;
                txtContacto.Text = agente.Contacto;
                txtEmail.Text = agente.Email;
                txtAlias.Text = agente.Alias;
                groupControl1.Text = "Editar";
                MenuEliminar.Enabled = true;
                txtDescripcion.Enabled = false;
            }

        }

        private Agente GetSelectedRow(GridView view)
        {
            return (Agente)view.GetRow(view.FocusedRowHandle);
        }

        private void MenuActualizar_Click(object sender, EventArgs e)
        {
            ListarAgentes();
        }



        private bool validar()
        {
            ctrldxError.ClearErrors();
            if (String.IsNullOrEmpty(txtDescripcion.Text))
                ctrldxError.SetError(txtDescripcion, "Debe ingresar el Nombre del Agente");
            if (String.IsNullOrEmpty(txtContacto.Text))
                ctrldxError.SetError(txtContacto, "Debe ingresar el Contacto");
            if (String.IsNullOrEmpty(txtEmail.Text))
                ctrldxError.SetError(txtEmail, "Debe ingresar el E-Mail");
            return ctrldxError.HasErrors;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
                return;
            var agente = BindViewToDomain();
            ResultadoTransaccion resultado = null;
            try
            {
                if (_agente == null)
                    resultado = ClsAgente.CreaAgente(agente);
                else
                    resultado = ClsAgente.ActualizaAgente(agente);
                MessageBox.Show(resultado.Descripcion, "Mantenedor de Agentes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _agente = null;

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException);
            }
        }

        //pasar valores del form al objeto
        private Agente BindViewToDomain()
        {
            var item = new Agente();
            item.Contacto = txtContacto.Text;
            item.Descripcion = txtDescripcion.Text;
            item.Email = txtEmail.Text;
            item.Alias = txtAlias.Text;
            return item;
        }

        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            var agente = BindViewToDomain();
            //var agente = GetSelectedRow(gridView1);
            ClsAgente.EliminaAgente(agente);
            LimpiarDatos();
            //if (gridPuertos.DataSource != null)
            //ListarPuertos();
        }

    }
}
