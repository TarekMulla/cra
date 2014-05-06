using System;
using System.Collections;
using System.Collections.Generic;
using ProyectoCraft.Base.Log;
using System.Windows.Forms;
using ProyectoCraft.Entidades.Cotizaciones.Directa;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.LogicaNegocios.Clientes;
using ProyectoCraft.LogicaNegocios.Cotizaciones;
using ProyectoCraft.LogicaNegocios.Mantenedores;
using ProyectoCraft.WinForm.Paperless.Asignacion;
using System.Xml;

//namespace SCCMultimodal.Mantenedores
namespace ProyectoCraft.WinForm.Clientes
{
    public partial class frmNavieras : Form
    {
        private static frmNavieras _instancia = null;
        public static frmNavieras Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmNavieras();

                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        private IList<Puerto> PuertosAll { get; set; }
        //public string Nombre { get; set; }
        //public Int64 Id { get; set; }
        //public bool Activo { get; set; }
        //public DateTime FechaCreacion { get; set; }
        public bool fromPaperless { get; set; }
        public frmPaperlessAsignacion InstanciaPaperless { get; set; }
        private ClsNaviera _navieraactual;
        public ClsNaviera NavieraActual
        {
            get
            {
                if (_navieraactual == null)
                    _navieraactual = new ClsNaviera();

                return _navieraactual;
            }
            set { _navieraactual = value; }
        }
        private Enums.TipoAccionFormulario _accion;
        public Enums.TipoAccionFormulario Accion
        {
            get { return _accion; }
            set { _accion = value; }
        }

        public frmNavieras()
        {
            InitializeComponent();
            FormLoad();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
                BuscarNavieraPorTextoLike(txtNombre.Text);
            else
                ListarNavieras();
        }
        public void ListarNavieras()
        {
            IList<ClsNaviera> listNavieras = ClsNavieras.ListarNavieras();
            gridView1.ActiveFilter.Clear();
            grdNavieras.DataSource = listNavieras;
            grdNavieras.RefreshDataSource();
        }
        private  void BuscarNavieraPorTextoLike(string naviera )
        {
           var nav= ClsNavieras.BuscarNavieraPorTextoLike(naviera);
           grdNavieras.DataSource = nav;
           grdNavieras.RefreshDataSource();
        }

        public void FormLoad()
        {
            CargaPuertos();
        }

        private void MenuVerDatos_Click(object sender, EventArgs e)
        {

        }
        private ClsNaviera ObtenerNaviera()
        {
            var filaSelected = grdNavieras.DefaultView.GetRow(gridView1.FocusedRowHandle);

            if (filaSelected == null)
            {
                return null;
            }

            ClsNaviera naviera = (ClsNaviera)filaSelected;

            return naviera;
        }

        private void MenuGuardar_Click(object sender, EventArgs e)
        {


        }
        private void LimpiarDatos()
        {
            txtNombre.Text = "";
            txtId.Text = "";
            txtNombre.Focus();
            ListaPuertos.Items.Clear();
            ListPuertoSeleccionado.Items.Clear();
        }

        private void Menu_Nuevo_Click(object sender, EventArgs e)
        {

        }

        private void MenuEliminar_Click(object sender, EventArgs e)
        {

        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {

        }

        private void frmNavieras_Load(object sender, EventArgs e)
        {
            ListarNavieras();
        }

        private void MenuSalir_Click_1(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }

        private void MenuEliminar_Click_1(object sender, EventArgs e)
        {
            ClsNaviera naviera = ObtenerNaviera();
            frmNavieras form = frmNavieras.Instancia;
            if (naviera != null)
            {
                form.NavieraActual = naviera;
                txtNombre.Text = naviera.Nombre;
                txtId.Text = naviera.Id.ToString();
            }

            if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtId.Text))
            {
                var res = ClsNavieras.EliminaNaviera(Convert.ToInt64(txtId.Text), txtNombre.Text);
                MessageBox.Show(res.Descripcion, "Naviera", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarDatos();
                ListarNavieras();
            }
        }
        private void AddPolClick(object sender, EventArgs e)
        {
            var seleccionados = ListaPuertos.SelectedItems;
            var list = new List<int>();
            ResultadoTransaccion trxAllPort = ClsPuertos.ObtieneTodosLosPuertos();
            foreach (var seleccionado in seleccionados)
            {
                ListPuertoSeleccionado.Items.Add(seleccionado);
                list.Add(ListaPuertos.Items.IndexOf(seleccionado));
            }
            list.Reverse();
            foreach (var i in list)
                if (i != -1)
                    ListaPuertos.Items.RemoveAt(i);
            ListPuertoSeleccionado.Refresh();
        }
        private void RemovePol_Click_1(object sender, EventArgs e)
        {
            var seleccionados = ListPuertoSeleccionado.SelectedItems;
            var list = new List<int>();
            foreach (var seleccionado in seleccionados)
            {
                ListaPuertos.Items.Add(seleccionado);
                list.Add(ListPuertoSeleccionado.Items.IndexOf(seleccionado));
            }
            list.Reverse();
            foreach (var i in list)
                ListPuertoSeleccionado.Items.RemoveAt(i);
        }
        private void CargaPuertos()
        {
            ResultadoTransaccion trxAllPort = ClsPuertos.ObtieneTodosLosPuertos();
            PuertosAll = (IList<Puerto>)trxAllPort.ObjetoTransaccion;
            foreach (var puerto in PuertosAll)
                ListaPuertos.Items.Add(puerto);

        }

        private void CargaPuertosPorNaviera(ClsNaviera naviera)
        {
            ResultadoTransaccion trx = ClsPuertos.ObtienePuertosPorNaviera(naviera);
            ResultadoTransaccion trxAllPort = ClsPuertos.ObtieneTodosLosPuertos();

            IList<Puerto> puertosSel = (IList<Puerto>)trx.ObjetoTransaccion;
            PuertosAll = (IList<Puerto>)trxAllPort.ObjetoTransaccion;
            var existe = false;
            ListaPuertos.Items.Clear();
            foreach (var puerto in PuertosAll)
            {
                foreach (var sel in puertosSel)
                {
                    if (sel.Nombre.Equals(puerto.Nombre))
                        existe = true;
                }
                if (!existe)
                    ListaPuertos.Items.Add(puerto);
                existe = false;
            }

            ListPuertoSeleccionado.Items.Clear();
            foreach (var puerto in puertosSel)
                ListPuertoSeleccionado.Items.Add(puerto);

        }

     

        private void MenuGuardar_Click_1(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtId.Text))
            {
                var res = ClsNavieras.ActualizarNaviera(Convert.ToInt64(txtId.Text), txtNombre.Text, ObtienePuertosSeleccionados());
                MessageBox.Show(res.Descripcion, "Naviera", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarDatos();
                CargaPuertos();
                ListarNavieras();
                if (fromPaperless.Equals(true))
                {
                    InstanciaPaperless.CargarNavierasExistentes();
                }
            }
            else if (!string.IsNullOrEmpty(txtNombre.Text) && string.IsNullOrEmpty(txtId.Text))
            {
                var res = ClsNavieras.NuevaNaviera(txtNombre.Text.Trim(), ObtienePuertosSeleccionados());
                MessageBox.Show(res.Descripcion, "Naviera", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarDatos();
                CargaPuertos();
                ListarNavieras();
                if (fromPaperless.Equals(true))
                {
                    InstanciaPaperless.CargarNavierasExistentes();                    
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro para Editar.", "Naviera", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtienePuertosSeleccionados()
        {
            string puertosConcatenados = "";

            foreach (var puerto in ListPuertoSeleccionado.Items)
            {
                puertosConcatenados += ((Puerto)puerto).Codigo + ",";
            }

            if (!puertosConcatenados.Length.Equals(0))
                puertosConcatenados = puertosConcatenados.Substring(0, puertosConcatenados.Length - 1);

            return puertosConcatenados;
        }


        private void Menu_Nuevo_Click_1(object sender, EventArgs e)
        {
            LimpiarDatos();
            CargaPuertos();
            ListarNavieras();
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
                    this.grdNavieras.ExportToXls(fs, true);

                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                Log.EscribirLog(ex.Message);
                MessageBox.Show("Error al generar archivo Excel: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNombre_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void grdNavieras_Click(object sender, EventArgs e)
        {
            ClsNaviera naviera = ObtenerNaviera();
            if(naviera!= null)
            {
                frmNavieras form = frmNavieras.Instancia;
                CargaPuertosPorNaviera(naviera);

                if (naviera != null)
                {
                    form.NavieraActual = naviera;
                    txtNombre.Text = naviera.Nombre;
                    txtId.Text = naviera.Id.ToString();

                }
                else
                    MessageBox.Show("Debe seleccionar una Naviera", "Naviera", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void frmNavieras_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
        }

        private void MenuEditar_Click(object sender, EventArgs e)
        {
            this.LblNombre.Enabled = true;
            this.txtNombre.Enabled = true;
            this.Puertos.Enabled = true;
        }

        private void grdNavieras_Click_1(object sender, EventArgs e)
        {
            ClsNaviera naviera = ObtenerNaviera();
            if (naviera != null)
            {
                frmNavieras form = frmNavieras.Instancia;
                CargaPuertosPorNaviera(naviera);

                if (naviera != null)
                {
                    form.NavieraActual = naviera;
                    txtNombre.Text = naviera.Nombre;
                    txtId.Text = naviera.Id.ToString();

                }
                else
                    MessageBox.Show("Debe seleccionar una Naviera", "Naviera", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

        }

        private void AddPuertoSeleccionado_Click(object sender, EventArgs e)
        {
            var seleccionados = ListaPuertos.SelectedItems;
            var list = new List<int>();
            ResultadoTransaccion trxAllPort = ClsPuertos.ObtieneTodosLosPuertos();
            foreach (var seleccionado in seleccionados)
            {
                ListPuertoSeleccionado.Items.Add(seleccionado);
                list.Add(ListaPuertos.Items.IndexOf(seleccionado));
            }
            list.Reverse();
            foreach (var i in list)
                if (i != -1)
                    ListaPuertos.Items.RemoveAt(i);
            ListPuertoSeleccionado.Refresh();

        }

        private void RemovePol_Click(object sender, EventArgs e)
        {
            var seleccionados = ListPuertoSeleccionado.SelectedItems;
            var list = new List<int>();
            foreach (var seleccionado in seleccionados)
            {
                ListaPuertos.Items.Add(seleccionado);
                list.Add(ListPuertoSeleccionado.Items.IndexOf(seleccionado));
            }
            list.Reverse();
            foreach (var i in list)
                ListPuertoSeleccionado.Items.RemoveAt(i);

        }
    }
}
