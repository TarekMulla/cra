using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Base.Log;
using ProyectoCraft.LogicaNegocios.Parametros;
using ProyectoCraft.WinForm.Clientes.Contacto;

//namespace SCCMultimodal.Mantenedores
namespace ProyectoCraft.WinForm.Clientes
{
    public partial class frmComunas : Form
    {
        private static frmComunas _instancia = null;
        public static frmComunas Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmComunas();

                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmContacto InstanciaContacto { get; set; }
        
        //public string Nombre { get; set; }
        //public Int64 Id { get; set; }
        //public bool Activo { get; set; }
        //public DateTime FechaCreacion { get; set; }
        private IList<clsCiudad> ciudades;
        private clsComuna _actual;
        public clsComuna Actual
        {
            get
            {
                if (_actual == null)
                    _actual = new clsComuna();

                return _actual;
            }
            set { _actual = value; }
        }
        private Enums.TipoAccionFormulario _accion;
        public Enums.TipoAccionFormulario Accion
        {
            get { return _accion; }
            set { _accion = value; }
        }

        public frmComunas()
        {
            InitializeComponent();
            FormLoad();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (! string.IsNullOrEmpty(txtNombre.Text))
            {
                IList<clsComuna> comunas = clsParametros.ListarComunasPorLike(txtNombre.Text);
                grdComunas.DataSource = comunas;
                grdComunas.RefreshDataSource();
            }

            else
            {
                Listar();    
            }
            
        }
        public void Listar()
        {
            if (cboPais.SelectedIndex > 0 && cboCiudad.SelectedIndex > 0)
            {
                if (cboCiudad.SelectedItem != null)
                    cargarComunas(((clsCiudad)cboCiudad.SelectedItem).Id);
            }
            else
                cargarComunas(-9);
        }
        public void FormLoad()
        {
            CargarPaises();
        }

        private void MenuVerDatos_Click(object sender, EventArgs e)
        {

        }
        private clsComuna ObtenerRegistro()
        {
            var filaSelected = grdComunas.DefaultView.GetRow(gridView1.FocusedRowHandle);

            if (filaSelected == null)
            {
                return null;
            }

            clsComuna com = (clsComuna)filaSelected;

            return com;
        }
        private Int64 BuscaIdComunaPorNombre(string nombreComuna)
        {
            Int64 idciudad = 0;
            foreach (var ciu in ciudades)
            {
                if (ciu.ToString().Equals(nombreComuna))
                    idciudad = ciu.Id;
            }
            return idciudad;
        }

        private void MenuGuardar_Click(object sender, EventArgs e)
        {


        }
        private void LimpiarDatos()
        {
            txtNombre.Text = "";
            txtId.Text = "";
            txtPais.Text = "";
        }

        private void Menu_Nuevo_Click(object sender, EventArgs e)
        {

        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {

        }
        private void CargarPaises()
        {
            IList<clsPais> paises = clsParametros.ListarPaises();
            ComboBoxItemCollection coll = cboPais.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in paises)
            {
                coll.Add(list);
            }
            cboPais.SelectedIndex = 0;
            if (paises.Count < 2)
                cboPais.SelectedIndex = 1;

        }

        private void CargarCiudades(Int64 idPais)
        {
            ciudades = clsParametros.ListarCiudades(idPais);

            ComboBoxItemCollection coll = cboCiudad.Properties.Items;
            coll.Clear();
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in ciudades)
            {
                coll.Add(list);
            }
            cboCiudad.SelectedIndex = 0;

        }

        private void cargarComunas(Int64 idCiudad)
        {
            IList<clsComuna> comunas = clsParametros.ListarComunas(idCiudad);

            //ComboBoxItemCollection coll = cboComuna.Properties.Items;
            //coll.Clear();
            //coll.Add(Utils.Utils.ObtenerPrimerItem());
            //foreach (var list in comunas)
            //{
            //coll.Add(list);
            //}
            //cboComuna.SelectedIndex = 0;

            grdComunas.DataSource = comunas;
            grdComunas.RefreshDataSource();
        }

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPais.SelectedIndex > 0)
            {
                if ((clsPais)cboPais.SelectedItem != null)
                    CargarCiudades(((clsPais)cboPais.SelectedItem).Id);
            }
            else
                CargarCiudades(-9);
        }

        private void cboCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void grdComunas_Click(object sender, EventArgs e)
        {
            clsComuna comuna = ObtenerRegistro();
            if (comuna != null)
            {
                frmComunas form = frmComunas.Instancia;
                //if (comuna != null)
                //{
                    form.Actual = comuna;
                    txtNombre.Text = comuna.Nombre;
                    txtId.Text = comuna.Id.ToString();
                    txtPais.Text = comuna.Ciudad.Pais.Nombre;
                //}
                //else
                //    MessageBox.Show("Debe seleccionar una Comuna", "Comuna", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }

        private void frmComunas_Load(object sender, EventArgs e)
        {

        }

        private void MenuGuardar_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtId.Text))
            {
                var idciudad = BuscaIdComunaPorNombre(cboCiudad.SelectedItem.ToString());
                var res = clsParametros.ActualizarComuna(Convert.ToInt64(txtId.Text), idciudad, txtNombre.Text);//(Convert.ToInt64(txtId.Text), txtNombre.Text.Trim(), txtPais.Text);
                MessageBox.Show(res.Descripcion, "Comuna", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarComunas(idciudad);
                LimpiarDatos();
            }
            else if (!string.IsNullOrEmpty(txtNombre.Text) && string.IsNullOrEmpty(txtId.Text))
            {
                if (cboCiudad.SelectedItem.ToString().Equals("Seleccione..."))
                {
                    MessageBox.Show("Seleccione una Region", "Comuna", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var idciudad = BuscaIdComunaPorNombre(cboCiudad.SelectedItem.ToString());
                    if (idciudad != 0)
                    {
                        var res = clsParametros.CrearComuna(Convert.ToInt64(idciudad), txtNombre.Text.Trim(), cboPais.SelectedItem.ToString());
                        MessageBox.Show(res.Descripcion, "Comuna", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarDatos();
                    }
                    //colocar log por error                    
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro para Editar", "Comuna", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenuVerDatos_Click_1(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
        }

        private void MenuEliminar_Click(object sender, EventArgs e)
        {

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
                    this.grdComunas.ExportToXls(fs, true);

                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);
                MessageBox.Show("Error al generar archivo Excel: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
