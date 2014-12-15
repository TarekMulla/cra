using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Paperless;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.LogicaNegocios.Paperless;
using ProyectoCraft.AccesoDatos.Paperless;
using ProyectoCraft.Entidades.Emails;
using SCCMultimodal.Utils;

namespace ProyectoCraft.WinForm.Paperless.PreAlerta
{
    public partial class frmPaperlessPreAlerta : Form
    {
        public string NuevoEditar = "";

        public frmPaperlessPreAlerta()
        {
            InitializeComponent();
        }

        private static frmPaperlessPreAlerta _instancia;
        public static frmPaperlessPreAlerta Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmPaperlessPreAlerta();


                return _instancia;
            }
            set { _instancia = value; }
        }

        private PaperlessPreAlerta _prealerta;

        public PaperlessPreAlerta PaperlessPreAlertaActual
        {
            get
            {
                if (_prealerta == null)
                    _prealerta = new PaperlessPreAlerta();

                return _prealerta;
            }
            set { _prealerta = value; }
        }

        //TSC
        private clsUsuario _usuario;
        public clsUsuario UsuarioActual
        {
            get
            {
                if (_usuario == null)
                    _usuario = new clsUsuario();

                return _usuario;
            }
            set { _usuario = value; }
        }
        //FIN TSC

        private Enums.TipoAccionFormulario _accion;

        public Enums.TipoAccionFormulario Accion
        {
            get { return _accion; }
            set { _accion = value; }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void FormLoad()
        {
            CargarNavierasExistentes();
            CargarAgentesExistentes();
            CargarNavesExistentes(); 
            CargarPuertosOrigenExistentes();
            CargarPuertosDestinoExistentes();
            LimpiarFormulario();
            
            if (Accion == Enums.TipoAccionFormulario.Nuevo)
            {
                PaperlessPreAlertaActual = null;
                DesBloquearFormulario();
                txtNumConsolidada.Focus();
                NuevoEditar = "Nuevo";
            }

            if (Accion == Enums.TipoAccionFormulario.Consultar)
            {
                NuevoEditar = "Editar";
                CargarFormulario();


                if (PaperlessPreAlertaActual.Estado.Nombre.Equals("Cerrado") || PaperlessPreAlertaActual.Estado.Nombre.Equals("Cancelado")||
                    PaperlessPreAlertaActual.Estado.Nombre.Equals("Vinculado"))
                {
                    BloquearFormulario();
                }
                else
                {
                    DesBloquearFormulario();
                }

            }
        }

        private void frmPaperlessPreAlerta_Load(object sender, EventArgs e)
        {
            dxErrorProvider1.ClearErrors();
            FormLoad();

        }

        public void CargarFormulario()
        {
            PaperlessPreAlerta PreAlerta = 
                LogicaNegocios.Paperless.Paperless.ObtenerPreAlertaPorNumConsolidada(PaperlessPreAlertaActual.NumConsolidada);

            if (PreAlerta != null)
            {
                PaperlessPreAlertaActual = PreAlerta;

                txtNumConsolidada.Text = PreAlerta.NumConsolidada;

                ddlAgente.SelectedItem = PreAlerta.Agente;
                ddlNaviera.SelectedItem = PreAlerta.Naviera;

                txtNave.Text = PreAlerta.Nave.Nombre;
                ddlNave.SelectedItem = PreAlerta.Nave;

                if (PreAlerta.FechaSalida == null)
                    txtFechaSalida.Text = "";
                else
                    txtFechaSalida.Text = PreAlerta.FechaSalida.Value.ToShortDateString();

                if (PreAlerta.FechaLlegada == null)
                    txtFechaLlegada.Text = "";
                else
                    txtFechaLlegada.Text = PreAlerta.FechaLlegada.Value.ToShortDateString();

                
                ddlPuertoOrigen.SelectedItem = PreAlerta.PuertoOrigen;
                ddlPuertoDestino.SelectedItem = PreAlerta.PuertoDestino;

                
                if (PreAlerta.FechaRecibimiento == null)
                    txtFechaCierrePreAlerta.Text = "";
                else
                    txtFechaCierrePreAlerta.Text = PreAlerta.FechaRecibimiento.Value.ToShortDateString();

                txtNumMaster.Text = PreAlerta.NumMaster;

                if (PaperlessPreAlertaActual.Estado.Nombre.Equals("Cerrado") || PaperlessPreAlertaActual.Estado.Nombre.Equals("Vinculado"))
                    chkCerrarPreAlerta.Checked = true;
                else
                    chkCerrarPreAlerta.Checked = false;
                
            }
        }

        private void BloquearFormulario()
        {
            txtNumConsolidada.Properties.ReadOnly = true;
            ddlAgente.Properties.ReadOnly = true;
            ddlNaviera.Properties.ReadOnly = true;
            ddlPuertoOrigen.Properties.ReadOnly = true;
            ddlPuertoDestino.Properties.ReadOnly = true;
            txtNave.ReadOnly = true;
            txtFechaSalida.Properties.ReadOnly = true;
            txtFechaLlegada.Properties.ReadOnly = true;
            txtFechaCierrePreAlerta.Properties.ReadOnly = true;
            txtNumMaster.Properties.ReadOnly = true;

            txtNumConsolidada.Enabled = true;
            txtNave.Enabled = true;
            txtFechaSalida.Enabled = true;
            txtFechaLlegada.Enabled = true;
            txtPuertoOrigen.Enabled = true;
            txtPuertoDestino.Enabled = true;
            txtFechaCierrePreAlerta.Enabled = true;
            txtNumMaster.Enabled = true;
            chkCerrarPreAlerta.Enabled = false;
            btnGuardar.Enabled = false;
        }

        private void DesBloquearFormulario()
        {
            txtNumConsolidada.Enabled = true;
            ddlAgente.Enabled = true;
            ddlNaviera.Enabled = true;
            ddlPuertoDestino.Enabled = true;
            ddlPuertoOrigen.Enabled = true;
            txtNave.Enabled = true;
            txtFechaSalida.Enabled = true;
            txtFechaLlegada.Enabled = true;
            txtPuertoOrigen.Enabled = true;
            txtPuertoDestino.Enabled = true;
            txtFechaCierrePreAlerta.Enabled = true;
            txtNumMaster.Enabled = true;
            chkCerrarPreAlerta.Enabled = true;
            btnGuardar.Enabled = true;

            txtNumConsolidada.Properties.ReadOnly = false;
            ddlAgente.Properties.ReadOnly = false;
            ddlNaviera.Properties.ReadOnly = false;
            ddlPuertoOrigen.Properties.ReadOnly = false;
            ddlPuertoDestino.Properties.ReadOnly = false;
            txtNave.ReadOnly = false;
            txtFechaSalida.Properties.ReadOnly = false;
            txtFechaLlegada.Properties.ReadOnly = false;
            txtFechaCierrePreAlerta.Properties.ReadOnly = false;
            txtNumMaster.Properties.ReadOnly = false;
        }

        public void LimpiarFormulario()
        {
            txtNumConsolidada.Text = "";
            txtAgente.Text = "";
            txtNaviera.Text = "";
            txtNave.Text = "";
            txtFechaSalida.Text = "";
            txtFechaLlegada.Text = "";
            txtPuertoOrigen.Text = "";
            txtPuertoDestino.Text = "";
            txtFechaCierrePreAlerta.Text = "";
            txtNumMaster.Text = "";

            //ddlAgente.SelectedIndex = 0;
            //ddlNave.SelectedIndex = 0;
            //ddlNaviera.SelectedIndex = 0;
        }

        public void CargarNavierasExistentes()
        {
            ddlNaviera.Properties.Items.Clear();
            
            ComboBoxItemCollection coll = ddlNaviera.Properties.Items;

            IList<Entidades.Paperless.PaperlessNaviera> listNavieras = new List<Entidades.Paperless.PaperlessNaviera>();

            listNavieras = LogicaNegocios.Paperless.Paperless.ObtenerNavieras(Entidades.Enums.Enums.Estado.Habilitado);

            coll = ddlNaviera.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listNavieras)
            {
                coll.Add(list);
            }
            ddlNaviera.SelectedIndex = 0;
            ddlNaviera.Properties.AutoComplete = true;


            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Add(txtNaviera.Text);
            txtNaviera.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtNaviera.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (var list in listNavieras)
            {
                auto.Add(list.Nombre);
            }
            txtNaviera.AutoCompleteCustomSource = auto;
        }
        
        private void CargarAgentesExistentes()
        {
            ComboBoxItemCollection coll = ddlAgente.Properties.Items;

            IList<Entidades.Paperless.PaperlessAgente> listAgentes = new List<Entidades.Paperless.PaperlessAgente>();

            listAgentes = LogicaNegocios.Paperless.Paperless.ObtenerAgentes(Entidades.Enums.Enums.Estado.Habilitado);

            coll = ddlAgente.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listAgentes)
            {
                coll.Add(list);
            }
            ddlAgente.SelectedIndex = 0;
            ddlAgente.Properties.AutoComplete = true;

            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Add(txtAgente.Text);
            txtAgente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtAgente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (var list in listAgentes)
            {
                auto.Add(list.Nombre);
            }
            txtAgente.AutoCompleteCustomSource = auto;
        }

        private void CargarNavesExistentes()
        {
            ComboBoxItemCollection coll = ddlNave.Properties.Items;

            IList<Entidades.Paperless.PaperlessNave> listNaves = new List<Entidades.Paperless.PaperlessNave>();

            listNaves = LogicaNegocios.Paperless.Paperless.ObtenerNaves(Entidades.Enums.Enums.Estado.Habilitado);

            coll = ddlNave.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());

            foreach (var list in listNaves)
            {
                coll.Add(list);
            }
            ddlNave.SelectedIndex = 0;
            ddlNave.Properties.AutoComplete = true;

            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Add(txtNave.Text);
            txtNave.AutoCompleteMode = txtNave.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtNave.AutoCompleteSource = txtNave.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (var list in listNaves)
            {
                auto.Add(list.Nombre);
            }
            txtNave.AutoCompleteCustomSource = auto;
        }

        private void CargarPuertosOrigenExistentes()
        {
            ComboBoxItemCollection coll = ddlPuertoOrigen.Properties.Items;

            IList<Entidades.Paperless.PaperlessPuerto> listPuertos = new List<Entidades.Paperless.PaperlessPuerto>();

            listPuertos = LogicaNegocios.Paperless.Paperless.ObtenerPuertosPaperless();

            coll = ddlPuertoOrigen.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());

            foreach (var list in listPuertos)
            { 
                coll.Add(list);
            }
            ddlPuertoOrigen.SelectedIndex = 0;
            ddlPuertoOrigen.Properties.AutoComplete = true;

            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Add(txtNave.Text);
            txtPuertoOrigen.AutoCompleteMode = txtPuertoOrigen.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtPuertoOrigen.AutoCompleteSource = txtPuertoOrigen.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (var list in listPuertos)
            {
                auto.Add(list.Nombre);
            }
            txtPuertoOrigen.AutoCompleteCustomSource = auto;
        }

        private void CargarPuertosDestinoExistentes()
        {
            ComboBoxItemCollection coll = ddlPuertoDestino.Properties.Items;

            IList<Entidades.Paperless.PaperlessPuerto> listPuertos = new List<Entidades.Paperless.PaperlessPuerto>();

            listPuertos = LogicaNegocios.Paperless.Paperless.ObtenerPuertosPaperless();

            coll = ddlPuertoDestino.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());

            foreach (var list in listPuertos)
            {
                coll.Add(list);
            }
            ddlPuertoDestino.SelectedIndex = 0;
            ddlPuertoDestino.Properties.AutoComplete = true;

            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Add(txtPuertoDestino.Text);
            txtPuertoDestino.AutoCompleteMode = txtPuertoDestino.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtPuertoDestino.AutoCompleteSource = txtPuertoDestino.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (var list in listPuertos)
            {
                auto.Add(list.Nombre);
            }
            txtPuertoDestino.AutoCompleteCustomSource = auto;
        }

        private bool ValidaDatos()
        {
            bool valida = true;
            dxErrorProvider1.ClearErrors();

            if (String.IsNullOrEmpty(txtNumConsolidada.Text.Trim()))
            {
                dxErrorProvider1.SetError(txtNumConsolidada, "Debe ingresar un N° Consolidada.", ErrorType.Critical);
                txtNumConsolidada.Focus();
                valida = false;
            }
            else
            {
                var configuracion = Base.Configuracion.Configuracion.Instance();
                var opcion = configuracion.GetValue("Paperless_Usuario1_Valida_Num_Consolidado"); //puede retornar un true, false o null
                if (opcion.HasValue && opcion.Value.Equals(true))
                {
                    if (NuevoEditar == "Nuevo")
                    {
                        if (LogicaNegocios.Paperless.Paperless.ValidaNumConsolidadoPreAlerta(txtNumConsolidada.Text))
                        {
                            dxErrorProvider1.SetError(txtNumConsolidada, "Ya existe el N° de Consolidada.", ErrorType.Critical);
                            txtNumConsolidada.Focus();
                            valida = false;
                        }
                    }
                }

                if (NuevoEditar == "Nuevo")
                {
                    var opcion2 = configuracion.GetValue("Paperless_Usuario1_Valida_Num_Consolidado"); //puede retornar un true, false o null
                    if (opcion2.HasValue && opcion2.Value.Equals(true))
                    {
                        if (LogicaNegocios.Paperless.Paperless.ValidaNumConsolidadoPreAlerta2(txtNumConsolidada.Text))
                        {
                            dxErrorProvider1.SetError(txtNumConsolidada, "Ya existe el N° de Consolidada.", ErrorType.Critical);
                            txtNumConsolidada.Focus();
                            valida = false;
                        }
                    }
                }
            }


            if (ddlAgente.SelectedIndex <= 0)
            {
                dxErrorProvider1.SetError(ddlAgente, "Debe seleccionar un Agente válido.", ErrorType.Critical);
                txtAgente.Focus();
                valida = false;
            }

            if (ddlNaviera.SelectedIndex <= 0)
            {
                dxErrorProvider1.SetError(ddlNaviera, "Debe seleccionar una Naviera válida.", ErrorType.Critical);
                txtNaviera.Focus();
                valida = false;
            }

            if (String.IsNullOrEmpty(txtNave.Text.Trim()))
            {
                dxErrorProvider1.SetError(txtNave, "Debe ingresar una Nave válida.", ErrorType.Critical);
                txtNave.Focus();
                valida = false;
            }

            /*
            if (String.IsNullOrEmpty(txtFechaMaster.Text.Trim()))
                MessageBox.Show("Ingrese Fecha Master");

            if (String.IsNullOrEmpty(txtFechaLlegada.Text.Trim()))
                MessageBox.Show("Ingrese Fecha Llegada");
            */
            //if (String.IsNullOrEmpty(txtPuertoOrigen.Text.Trim()))
            if (ddlPuertoOrigen.SelectedIndex <= 0)
            {
                dxErrorProvider1.SetError(ddlPuertoOrigen, "Debe seleccionar un Puerto de Origen.", ErrorType.Critical);
                ddlPuertoOrigen.Focus();
                valida = false;
            }

            //if (String.IsNullOrEmpty(txtPuertoDestino.Text.Trim()))
            if (ddlPuertoDestino.SelectedIndex <= 0)
            {
                    dxErrorProvider1.SetError(ddlPuertoDestino, "Debe seleccionar un Puerto de Destino.", ErrorType.Critical);
                ddlPuertoDestino.Focus();
                valida = false;
            }

            if (chkCerrarPreAlerta.Checked.Equals(true))
            {
                if (String.IsNullOrEmpty(txtFechaCierrePreAlerta.Text.Trim()))
                {
                    dxErrorProvider1.SetError(txtFechaCierrePreAlerta, "Debe ingresar una Fecha Cierre Pre-Alerta.", ErrorType.Critical);
                    txtFechaCierrePreAlerta.Focus();
                    valida = false;
                }

                if (String.IsNullOrEmpty(txtNumMaster.Text.Trim()))
                {
                    dxErrorProvider1.SetError(txtNumMaster, "Debe ingresar un N° de Master.", ErrorType.Critical);
                    txtNumMaster.Focus();
                    valida = false;
                }
            }

            return valida;
        }

        private bool ValidaFechas()
        {
            bool valida = true;
            DateTime FechaSalida = new DateTime(9999, 1, 1);
            DateTime FechaLlegada = new DateTime(9999, 1, 1);
            DateTime FechaRecibimiento = new DateTime(9999, 1, 1);

            if (txtFechaSalida.Text == "")
            {
                MessageBox.Show("Debe ingresar una Fecha de Salida.", "PreAlerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                valida = false;
                txtFechaSalida.Focus();
                return false;
            }

            if (txtFechaSalida.Enabled.Equals(true) && txtFechaSalida.Text.Length > 0)
                FechaSalida = new DateTime(txtFechaSalida.DateTime.Year, txtFechaSalida.DateTime.Month, txtFechaSalida.DateTime.Day, 0, 0, 1);

            if (txtFechaLlegada.Enabled.Equals(true) && txtFechaLlegada.Text.Length > 0)
                FechaLlegada = new DateTime(txtFechaLlegada.DateTime.Year, txtFechaLlegada.DateTime.Month, txtFechaLlegada.DateTime.Day, 0, 0, 1);

            if (txtFechaCierrePreAlerta.Enabled.Equals(true) && txtFechaCierrePreAlerta.Text.Length > 0)
                FechaRecibimiento = new DateTime(txtFechaCierrePreAlerta.DateTime.Year, txtFechaCierrePreAlerta.DateTime.Month, txtFechaCierrePreAlerta.DateTime.Day, 0, 0, 1);

            if (txtFechaSalida.Enabled.Equals(true) && txtFechaSalida.Text.Length > 0 &&
                txtFechaLlegada.Enabled.Equals(true) && txtFechaLlegada.Text.Length > 0)
            {
                int result = DateTime.Compare(FechaSalida, FechaLlegada);
                if (result > 0)
                {
                    MessageBox.Show("Fecha de Salida no puede ser mayor que Fecha de Llegada.", "PreAlerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valida = false;
                }
            }

            if (txtFechaLlegada.Enabled.Equals(true) && txtFechaLlegada.Text.Length > 0 &&
                txtFechaCierrePreAlerta.Enabled.Equals(true) && txtFechaCierrePreAlerta.Text.Length > 0)
            {
                int result = DateTime.Compare(FechaLlegada, FechaRecibimiento);
                if (result < 0)
                {
                    MessageBox.Show("Fecha de Recibimiento de PreAlerta no debe ser mayor a Fecha de Llegada.", "PreAlerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valida = false;
                }
            }

            return valida;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidaDatos())
            {
                return;
            }

            if (!ValidaFechas())
            {
                return;
            }

            if (Accion == Enums.TipoAccionFormulario.Consultar)
            {
                if (PaperlessPreAlertaActual.Estado.Nombre.Equals("Abierto"))
                    ActualizarPreAlerta();
            }
            else
                GuardarPreAlerta();
            
        }

        private void EnvioMail()
        {
            var mail = new EnvioMailObject();
            Cursor.Current = Cursors.WaitCursor;

            Entidades.GlobalObject.ResultadoTransaccion resultado = mail.EnviarMailPaperlessPreAlerta(PaperlessPreAlertaActual);

            if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Ocurrio un problema al intentar enviar el email. \n" + resultado.Descripcion,
                                "Paperless PreAlerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Cursor.Current = Cursors.Default;
                //MessageBox.Show("Se ha enviado la información Usuario.", "Paperless PreAlerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                frmListarPreAlerta form = frmListarPreAlerta.Instancia;
                form.ObtenerPreAlertas();
            }
        }


        private void ActualizarPreAlerta()
        {

            PaperlessPreAlertaActual.NumConsolidada = txtNumConsolidada.Text.Trim();
            PaperlessPreAlertaActual.Agente = (PaperlessAgente)ddlAgente.SelectedItem;
            PaperlessPreAlertaActual.Naviera = (PaperlessNaviera)ddlNaviera.SelectedItem;

            if (txtNave.Text.Trim() == "")
            {
                PaperlessPreAlertaActual.Nave = null;
            }
            else
            {
                for (int i = 0; i < ddlNave.Properties.Items.Count; i++)
                {
                    if (ddlNave.Properties.Items[i].ToString() == txtNave.Text)
                        ddlNave.SelectedIndex = i;
                }

                if (ddlNave.SelectedIndex == 0)
                {
                    PaperlessPreAlertaActual.Nave = new PaperlessNave() { Nombre = txtNave.Text, Id = 0, Activo = true };
                }
                else
                    PaperlessPreAlertaActual.Nave = (PaperlessNave)this.ddlNave.SelectedItem;
            }

            if (txtFechaSalida.Text.Length.Equals(0))
                PaperlessPreAlertaActual.FechaSalida = new DateTime(9999, 1, 1);
            else
                PaperlessPreAlertaActual.FechaSalida = Convert.ToDateTime(txtFechaSalida.Text.Trim());

            if (txtFechaLlegada.Text.Length.Equals(0))
                PaperlessPreAlertaActual.FechaLlegada = new DateTime(9999, 1, 1);
            else
                PaperlessPreAlertaActual.FechaLlegada = Convert.ToDateTime(txtFechaLlegada.Text.Trim());

            PaperlessPreAlertaActual.PuertoOrigen = (PaperlessPuerto)ddlPuertoOrigen.SelectedItem;
            PaperlessPreAlertaActual.PuertoDestino = (PaperlessPuerto)ddlPuertoDestino.SelectedItem;
     

            PaperlessPreAlertaActual.FechaModificacion = DateTime.Now;
            
            PaperlessPreAlertaActual.NumMaster = txtNumMaster.Text.Trim();

            if (txtFechaCierrePreAlerta.Text.Length.Equals(0))
                PaperlessPreAlertaActual.FechaRecibimiento = new DateTime(9999, 1, 1);
            else
                PaperlessPreAlertaActual.FechaRecibimiento = Convert.ToDateTime(txtFechaCierrePreAlerta.Text.Trim());

            if (chkCerrarPreAlerta.Checked.Equals(true))
                PaperlessPreAlertaActual.Estado = new PaperlessEstadoPreAlerta() { id = 2, descripcion = "Cerrado", Activo = 1 };
            else
                PaperlessPreAlertaActual.Estado = new PaperlessEstadoPreAlerta() { id = 1, descripcion = "Abierto", Activo = 1 };

            ResultadoTransaccion resultado = new ResultadoTransaccion();

            resultado = LogicaNegocios.Paperless.Paperless.ActualizarPreAlerta(PaperlessPreAlertaActual);
            if (resultado.Estado == Enums.EstadoTransaccion.Aceptada)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("PreAlerta actualizada correctamente.", "Paperless - PreAlerta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (chkCerrarPreAlerta.Checked.Equals(true))
                    EnvioMail();

                Paperless.PreAlerta.frmListarPreAlerta form = frmListarPreAlerta.Instancia;
                form.ObtenerPreAlertas();

                Instancia = null;
                this.Close();
            }
            else
            {
                MessageBox.Show(resultado.Descripcion, "Paperless - PreAlerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GuardarPreAlerta()
        {

            PaperlessPreAlertaActual.NumConsolidada = txtNumConsolidada.Text.Trim();
            PaperlessPreAlertaActual.Agente = (PaperlessAgente) ddlAgente.SelectedItem;
            PaperlessPreAlertaActual.Naviera = (PaperlessNaviera) ddlNaviera.SelectedItem;

            if (txtNave.Text.Trim() == "")
            {
                PaperlessPreAlertaActual.Nave = null;
            }
            else
            {
                for (int i = 0; i < ddlNave.Properties.Items.Count; i++)
                {
                    if (ddlNave.Properties.Items[i].ToString() == txtNave.Text)
                        ddlNave.SelectedIndex = i;
                }

                if (ddlNave.SelectedIndex == 0)
                {
                    PaperlessPreAlertaActual.Nave = new PaperlessNave() { Nombre = txtNave.Text, Id = 0, Activo = true };
                }
                else
                    PaperlessPreAlertaActual.Nave = (PaperlessNave)this.ddlNave.SelectedItem;
            }

            if (txtFechaSalida.Text.Length.Equals(0))
                PaperlessPreAlertaActual.FechaSalida = new DateTime(9999,1,1);
            else
                PaperlessPreAlertaActual.FechaSalida = Convert.ToDateTime(txtFechaSalida.Text.Trim());

            if (txtFechaLlegada.Text.Length.Equals(0))
                PaperlessPreAlertaActual.FechaLlegada = new DateTime(9999,1,1);
            else
                PaperlessPreAlertaActual.FechaLlegada = Convert.ToDateTime(txtFechaLlegada.Text.Trim());

            PaperlessPreAlertaActual.Agente = (PaperlessAgente)ddlAgente.SelectedItem;
            PaperlessPreAlertaActual.Naviera = (PaperlessNaviera)ddlNaviera.SelectedItem;

            PaperlessPreAlertaActual.PuertoOrigen = (PaperlessPuerto)ddlPuertoOrigen.SelectedItem;
            PaperlessPreAlertaActual.PuertoDestino = (PaperlessPuerto)ddlPuertoDestino.SelectedItem;

            PaperlessPreAlertaActual.FechaCreacion = DateTime.Now;
            
            PaperlessPreAlertaActual.NumMaster = txtNumMaster.Text.Trim();

            if (txtFechaCierrePreAlerta.Text.Length.Equals(0))
                PaperlessPreAlertaActual.FechaRecibimiento = new DateTime(9999,1,1);
            else
                PaperlessPreAlertaActual.FechaRecibimiento = Convert.ToDateTime(txtFechaCierrePreAlerta.Text.Trim());

            if (chkCerrarPreAlerta.Checked.Equals(true))
                PaperlessPreAlertaActual.Estado = new PaperlessEstadoPreAlerta() { id = 2, descripcion = "Cerrado", Activo = 1 };
            else
                PaperlessPreAlertaActual.Estado = new PaperlessEstadoPreAlerta() { id = 1, descripcion = "Abierto", Activo = 1 };


            ResultadoTransaccion resultado = new ResultadoTransaccion();

            resultado = LogicaNegocios.Paperless.Paperless.GuardarPreAlerta(PaperlessPreAlertaActual);
            if (resultado.Estado == Enums.EstadoTransaccion.Aceptada)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("PreAlerta ingresada correctamente.", "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (chkCerrarPreAlerta.Checked.Equals(true))
                    EnvioMail();

                if (MessageBox.Show("¿Desea ingresar una nueva PreAlerta?", "Paperless PreAlerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LimpiarFormulario();
                    FormLoad();
                }
                else
                {
                    Paperless.PreAlerta.frmListarPreAlerta form = frmListarPreAlerta.Instancia;
                    form.ObtenerPreAlertas();

                    Instancia = null;
                    this.Close();
                }
            
            
            }
            else
            {
                MessageBox.Show(resultado.Descripcion, "Paperless", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            frmListarPreAlerta form = frmListarPreAlerta.Instancia;
            form.ObtenerPreAlertas();
            Instancia = null;
            Close();
        }

      

        private void txtFechaCierrePreAlerta_EditValueChanged_1(object sender, EventArgs e)
        {
            if (txtFechaCierrePreAlerta.Text.Length > 0)
                chkCerrarPreAlerta.Checked = true;
            else
                chkCerrarPreAlerta.Checked = false;
         }

      
       
 
    }
}
