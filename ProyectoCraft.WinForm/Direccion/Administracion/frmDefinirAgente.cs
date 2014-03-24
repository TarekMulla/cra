using System;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Paperless;
using ProyectoCraft.Entidades.Enums;


namespace ProyectoCraft.WinForm.Direccion.Administracion
{
    public partial class frmDefinirAgente : Form
    {
        private static frmDefinirAgente _form = null;
        public frmDefinirAgente()
        {
            InitializeComponent();
        }
        public static frmDefinirAgente Instancia
        {
            get
            {
                if (_form == null)
                    _form = new frmDefinirAgente();

                return _form;
            }
            set
            {
                _form = value;
            }
        }
        
        
        private void ActualizarGrilla() {

            var foo = LogicaNegocios.Paperless.Paperless.ObtenerAgentes(Enums.Estado.Habilitado);        
            this.gridAgentes.DataSource = null;
            this.gridAgentes.DataSource = foo;
            gridAgentes.Focus();
        }

        private void MenuSalir_Click(object sender, EventArgs e) {
            Instancia = null;
            this.Close();
        }

        private Boolean Validar() {
            ctrldxError.ClearErrors();
            if (String.IsNullOrEmpty(txtNombre.Text))
                ctrldxError.SetError(txtNombre, "Debe ingresar el nombre", ErrorType.Critical);

            if (String.IsNullOrEmpty(txtAlias.Text))
                ctrldxError.SetError(txtAlias, "Debe ingresar el alias", ErrorType.Critical);

            if (String.IsNullOrEmpty(txtContacto.Text))
                ctrldxError.SetError(txtContacto, "Debe ingresar el contacto", ErrorType.Critical);


            if (String.IsNullOrEmpty(txtEmail.Text))
                ctrldxError.SetError(txtEmail, "Debe ingresar el email", ErrorType.Critical);        

            return !ctrldxError.HasErrors;
        }


       private PaperlessAgente cargarAgentedesdeTextBox() {
            var agente = new PaperlessAgente();
            if (!String.IsNullOrEmpty(txtId.Text))
                agente.Id = Convert.ToInt64(txtId.Text);
            agente.Nombre = txtNombre.Text;
            agente.Contacto = txtContacto.Text;
            agente.Email = txtEmail.Text;
            agente.Alias = txtAlias.Text;
           return agente;
       }
        private void btnAgregar_Click(object sender, EventArgs e) {
            if (Validar()) {
                var agente = cargarAgentedesdeTextBox();
                if (agente.IsNew) {
                    CrearNuevoAgente(agente);
                    ActualizarGrilla();
                    limpiarTextBox();
                }else {
                    ActualizarAgente(agente);
                    ActualizarGrilla();
                }
                    
            }
        }

        private void ActualizarAgente(PaperlessAgente agente) {
            agente.Activo = true;
            var res = LogicaNegocios.Paperless.Paperless.EditarAgente(agente);
            ShowResultadoTransaccion(res);
        }

        private void CrearNuevoAgente(PaperlessAgente agente) {
            var res = LogicaNegocios.Paperless.Paperless.CrearAgente(agente);
            ShowResultadoTransaccion(res);    
        }

        private void EliminarAgente(PaperlessAgente agente) {
            var res = LogicaNegocios.Paperless.Paperless.EliminarAgente(agente);
            ShowResultadoTransaccion(res);
        }
        private void ShowResultadoTransaccion(ResultadoTransaccion res) {
            if (res.Estado.Equals(Enums.EstadoTransaccion.Aceptada))

                MessageBox.Show(res.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            else
                MessageBox.Show(res.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
        }

        private void frmDefinirAgente_Load(object sender, EventArgs e) {
            ActualizarGrilla();
        }
        private void frmDefinirAgente_Closed(object sender, FormClosedEventArgs e) {
            Instancia = null;
        }

        private void CargarEditAgente(PaperlessAgente agente) {
            txtNombre.Text = agente.Nombre;
            txtContacto.Text = agente.Contacto;
            txtEmail.Text = agente.Email;
            txtAlias.Text = agente.Alias;
            txtId.Text = agente.Id.ToString();

            btnGuardar.Text = "Actualizar";
            btnEliminar.Enabled = true;
        }

        private void gridviewLineaCredito_row_changed(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {

            var agente = gridViewLineaCredito.GetRow(e.FocusedRowHandle) as PaperlessAgente;
            if (agente != null)
                CargarEditAgente(agente);
        }


        private void limpiarTextBox(){
            txtNombre.Text = String.Empty;
            txtNombre.Focus();
            txtEmail.Text = String.Empty;
            txtContacto.Text = String.Empty;
            txtAlias.Text = String.Empty;
            txtId.Text = string.Empty;
        }
        private void MenuNuevo_Click(object sender, EventArgs e) {
            limpiarTextBox();
            btnGuardar.Text = "Guardar";
            
            btnEliminar.Enabled = false;
            gridViewLineaCredito.ClearSelection();
            gridViewLineaCredito.CancelSelection();
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            EliminarAgente(cargarAgentedesdeTextBox());
            ActualizarGrilla();
        }

        
    }
}
