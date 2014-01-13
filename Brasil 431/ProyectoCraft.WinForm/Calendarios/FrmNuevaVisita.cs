using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraScheduler;
using ProyectoCraft.Entidades.Calendario;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Clientes.Contacto;
using ProyectoCraft.Entidades.Clientes.Cuenta;
using ProyectoCraft.Entidades.Clientes.Target;
using ProyectoCraft.Entidades.Clientes.TargetAccount;
using ProyectoCraft.Entidades.Emails;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.LogicaNegocios.Parametros;
using ProyectoCraft.Entidades.GlobalObject;
using SCCMultimodal.Utils;

namespace ProyectoCraft.WinForm.Calendarios
{
    public partial class FrmNuevaVisita : Form
    {
        public FrmNuevaVisita()
            : base()
        {
            InitializeComponent();
        }


        private SchedulerControl _controlparam;
        public SchedulerControl ControlParam
        {
            get { return _controlparam; }
            set { _controlparam = value; }
        }

        private Appointment _appparam;
        public Appointment AppointmentCalendario
        {
            get { return _appparam; }
            set { _appparam = value; }
        }

        private static FrmNuevaVisita _form = null;
        public static FrmNuevaVisita Instancia
        {
            get
            {
                if (_form == null)
                    _form = new FrmNuevaVisita();

                return _form;
            }
            set
            {
                _form = value;
            }
        }

        private clsClienteMaster _clientemaster;
        private clsClienteMaster ClienteMaster
        {
            get { return _clientemaster; }
            set { _clientemaster = value; }
        }

        private Enums.TipoAccionFormulario _accion;
        public Enums.TipoAccionFormulario Accion
        {
            get { return _accion; }
            set { _accion = value; }
        }

        private clsVisita _visitaactual;
        public clsVisita VisitaActual
        {
            get
            {
                if (_visitaactual == null)
                    _visitaactual = new clsVisita();

                return _visitaactual;
            }
            set { _visitaactual = value; }
        }

        private Int64 _idvisita;
        public Int64 IdVisitaConsulta
        {
            get { return _idvisita; }
            set { _idvisita = value; }
        }

        private bool _esInforme;
        public bool EsInforme
        {
            get { return _esInforme; }
            set { _esInforme = value; }
        }

        private Enums.TipoCalendario _tipocalendario;
        public Enums.TipoCalendario TipoCalendario
        {
            get { return _tipocalendario; }
            set { _tipocalendario = value; }
        }

        public void frmLoad()
        {
            CargarClientes();
            CargarImportancia();
            CargarUsuariosAsistentes();
            CargarVendedores();
        }


        private void FrmNuevaVisita_Load(object sender, EventArgs e)
        {
            TabConfirmacion.Enabled = false;
            CalendarioADominio();
            frmLoad();
            LimpiarForm();
            //CalendarioADominio();


            if (Accion == Enums.TipoAccionFormulario.Editar)
            {
                CargarFormulario();
            }
            else if (Accion == Enums.TipoAccionFormulario.Nuevo)
            {
                VisitaActual.EstadoBD = Enums.VisitaEstado.Incompleta;
                txtOrganizador.Text = Base.Usuario.UsuarioConectado.Usuario.NombreCompleto;
                CargarAsistenteUsuario();
            }
            else if (Accion == Enums.TipoAccionFormulario.Consultar)
            {
                CargarFormulario();
                ConsultarVisita();
            }

            if (Accion != Enums.TipoAccionFormulario.Consultar)
            {
                ValidarEstadoVisita();
                ValidarAccionesUsuario();
                txtFechaCancelacion.Text = DateTime.Now.ToShortDateString();
            }

            ValidarParaOpcionReunionesInternas();

            txtOrganizador.Properties.ReadOnly = true;

        }

        private void ValidarParaOpcionReunionesInternas()
        {
            if (TipoCalendario == Enums.TipoCalendario.CalendarioCompartido)
            {
                if (VisitaActual.IsNew)
                    chkReunionInterna.Enabled = true;
                else
                    chkReunionInterna.Enabled = false;
            }
            else
            {
                chkReunionInterna.Visible = false;
            }


        }

        private void ValidarAccionesUsuario()
        {
            bool permite = false;

            if (!chkReunionInterna.Checked)
                permite = !VisitaActual.IsNew &&
                          VisitaActual.Vendedor.Id != Base.Usuario.UsuarioConectado.Usuario.Id &&
                          VisitaActual.UsuarioOrganizador.Id != Base.Usuario.UsuarioConectado.Usuario.Id;
            else
                permite = !VisitaActual.IsNew &&
                          VisitaActual.UsuarioOrganizador.Id != Base.Usuario.UsuarioConectado.Usuario.Id;

            if (permite)
            {
                MenuGuardar.Visible = false;
                MenuConfirmar.Visible = false;

                MenuInformVisita.Visible = false;
                if (VisitaActual.EstadoBD == Enums.VisitaEstado.Confirmada || VisitaActual.EstadoBD == Enums.VisitaEstado.Realizada_Informe_Pendiente || VisitaActual.EstadoBD == Enums.VisitaEstado.Realizada_Con_Informe)
                    if (VisitaActual.Informvisita != null && !VisitaActual.Informvisita.IsNew)
                        MenuInformVisita.Visible = true;

                MenuVisitado.Visible = false;
                MenuCancelar.Visible = false;
                MenuEliminar.Visible = false;
                MenuReplanificar.Visible = false;
                TabConfirmacion.PageEnabled = true;
                tabCancelar.PageVisible = false;
                btnConfirmar.Visible = false;
                labelControl14.Visible = false;
                //labelControl16.Visible = false;
                //grdAsistentesTopeHorario.Visible = false;

                TabConfirmacion.PageVisible = false;
                if (VisitaActual.EstadoBD == Enums.VisitaEstado.Confirmada)
                    TabConfirmacion.PageVisible = true;

                FormularioSoloLectura();
            }
        }

        private void ValidarEstadoVisita()
        {
            MenuGuardar.Visible = false;
            MenuConfirmar.Visible = false;
            MenuInformVisita.Visible = false;
            MenuVisitado.Visible = false;
            MenuCancelar.Visible = false;
            MenuEliminar.Visible = false;
            MenuReplanificar.Visible = false;
            TabConfirmacion.PageEnabled = false;
            tabCancelar.PageVisible = false;


            if (VisitaActual.EstadoBD == Enums.VisitaEstado.Incompleta)
            {
                MenuGuardar.Visible = true;
                MenuConfirmar.Visible = true;
                MenuEliminar.Visible = true;
            }

            if (VisitaActual.EstadoBD == Enums.VisitaEstado.Planificada_Por_confirmar)
            {
                MenuGuardar.Visible = true;
                MenuConfirmar.Visible = true;
                MenuCancelar.Visible = true;
            }

            if (VisitaActual.EstadoBD == Enums.VisitaEstado.Confirmada)
            {
                MenuInformVisita.Visible = true;
                MenuVisitado.Visible = true;
                MenuCancelar.Visible = true;
                MenuReplanificar.Visible = true;
                TabConfirmacion.PageEnabled = true;
                FormularioSoloLectura();
                MenuGuardar.Enabled = false;

            }

            if (VisitaActual.EstadoBD == Enums.VisitaEstado.Realizada_Informe_Pendiente)
            {
                MenuInformVisita.Visible = true;
                TabConfirmacion.PageEnabled = true;
                FormularioSoloLectura();
                MenuGuardar.Enabled = false;
            }

            if (VisitaActual.EstadoBD == Enums.VisitaEstado.Realizada_Con_Informe)
            {
                MenuInformVisita.Visible = true;
                TabConfirmacion.PageEnabled = true;
                FormularioSoloLectura();
                MenuGuardar.Enabled = false;
            }

            if (VisitaActual.EstadoBD == Enums.VisitaEstado.Cancelada)
            {
                MenuReplanificar.Visible = true;
                FormularioSoloLectura();
                tabCancelar.PageVisible = true;
                txtMotivoCancelacion.Properties.ReadOnly = true;
                btnCancelarVisita.Enabled = false;
            }

            if (VisitaActual.EstadoBD == Enums.VisitaEstado.No_Realizada)
            {
                FormularioSoloLectura();
                MenuInformVisita.Visible = true;
            }

            if (VisitaActual.EstadoBD == Enums.VisitaEstado.Realizada_Con_Informe_Fuera_De_Plazo)
            {
                FormularioSoloLectura();
                MenuInformVisita.Visible = true;
            }

            if (VisitaActual.EsReplanificada)
            {
                chkReplanificada.Visible = true;
            }
        }

        private void CargarAsistenteUsuario()
        {
            Int16 count = 0;

            if (TipoCalendario == Enums.TipoCalendario.CalendarioCompartido)
            {
                try
                {
                    Int64 IdResource = Convert.ToInt64(this.AppointmentCalendario.ResourceIds[0]);

                    foreach (AsistentesCraft asistente in (IList<AsistentesCraft>) grdAsistentesCraft.DataSource)
                    {
                        if (asistente.Usuario.Id == IdResource)
                            asistente.Asiste = true;
                    }
                    grdAsistentesCraft.RefreshDataSource();
                }catch(Exception e){
                    Console.Write(e.Message);
                    Console.Write(e.InnerException);
                    Instancia = null;
                    this.Close();
                }


                //for (int i = 0; i <= lstAsistentesCraft.Items.Count - 1; i++)
                //{
                //    clsUsuario usuario = (clsUsuario)lstAsistentesCraft.Items[i];
                //    if (usuario.Id == IdResource)
                //    {
                //        lstAsistentesCraft.SetItemChecked(i, true);
                //        break;
                //    }
                //}    
            }
            else
            {
                foreach (AsistentesCraft asistente in (IList<AsistentesCraft>)grdAsistentesCraft.DataSource)
                {
                    if (asistente.Usuario.Id == Base.Usuario.UsuarioConectado.Usuario.Id)
                        asistente.Asiste = true;
                }



                //for (int i = 0; i <= lstAsistentesCraft.Items.Count - 1; i++)
                //{
                //    clsUsuario usuario = (clsUsuario)lstAsistentesCraft.Items[i];

                //    if (usuario.Id == Base.Usuario.UsuarioConectado.Usuario.Id)
                //    {
                //        lstAsistentesCraft.SetItemChecked(i, true);
                //        break;
                //    }
                //}


            }
        }

        private void CalendarioADominio()
        {
            if (AppointmentCalendario != null)
            {
                VisitaActual.Asunto = AppointmentCalendario.Subject;
                VisitaActual.Ubicacion = AppointmentCalendario.Location;
                VisitaActual.Descripcion = AppointmentCalendario.Description;
                VisitaActual.FechaHoraComienzo = AppointmentCalendario.Start;
                VisitaActual.FechaHoraTermino = AppointmentCalendario.End;
                VisitaActual.Id = Convert.ToInt64(AppointmentCalendario.CustomFields["IdVisita"]);
            }
        }

        public void CargarFormulario()
        {
            Int64 IdVisita = 0;

            if (Accion == Enums.TipoAccionFormulario.Consultar)
                IdVisita = IdVisitaConsulta;
            else
                IdVisita = Convert.ToInt64(AppointmentCalendario.CustomFields["IdVisita"]);

            clsVisita visita =
                LogicaNegocios.Calendarios.clsCalendarios.ObtenerVisitaPorId(IdVisita);

            //obtener produtos del cliente
            //visita.Cliente.ProductosPreferidos =
            //    LogicaNegocios.Clientes.clsClientesMaster.ObtenerProductosPreferidos(visita.Cliente.Id);


            if (visita == null) return;

            VisitaActual = visita;


            txtAsunto.Text = VisitaActual.Asunto;
            txtUbicacion.Text = VisitaActual.Ubicacion;

            if (Accion != Enums.TipoAccionFormulario.Nuevo)
            {
                txtFechaComienzo.Text = VisitaActual.FechaHoraComienzo.ToShortDateString();
                txtHoraComienzo.Time = VisitaActual.FechaHoraComienzo;
                txtFechaTermino.Text = VisitaActual.FechaHoraTermino.ToShortDateString();
                txtHoraTermino.Time = VisitaActual.FechaHoraTermino;
            }
            else
            {
                txtFechaComienzo.Text = AppointmentCalendario.Start.ToShortDateString();
                txtHoraComienzo.Time = AppointmentCalendario.Start;
                txtFechaTermino.Text = AppointmentCalendario.End.ToShortDateString();
                txtHoraTermino.Time = AppointmentCalendario.End;
            }

            txtDescripcion.Text = VisitaActual.Descripcion;

            if (VisitaActual.Cliente != null)
            {
                txtCliente.Text = VisitaActual.Cliente.ToString();
                cboCliente.SelectedItem = visita.Cliente;
                ClienteMaster = VisitaActual.Cliente;
            }

            CargarContactos();

            cboNivelImportancia.SelectedItem = VisitaActual.NivelImportancia;


            for (int i = 0; i <= lstAsistentesCliente.Items.Count - 1; i++)
            {
                clsContacto contacto = (clsContacto)lstAsistentesCliente.Items[i];
                foreach (clsVisitaAsistente asistente in VisitaActual.Asistentes)
                {
                    if (asistente.TipoAsistente == Enums.VisitaTipoAsistente.Contacto)
                    {
                        if (contacto.Id == asistente.Contacto.Id)
                        {
                            lstAsistentesCliente.SetItemChecked(i, true);

                            break;
                        }
                    }
                }
            }

            //grdAsistentesConfirmacion.DataSource = VisitaActual.AsistentesCraft;
            IList<AsistentesCraft> asistentes = (IList<AsistentesCraft>)grdAsistentesCraft.DataSource;
            foreach (var usuario in asistentes)
            {
                foreach (clsVisitaAsistente asistente in VisitaActual.Asistentes)
                {
                    if (asistente.TipoAsistente == Enums.VisitaTipoAsistente.Usuario)
                    {
                        if (usuario.Usuario.Id == asistente.Usuario.Id)
                        {
                            usuario.Asiste = true;

                            //if (asistente.Confirmo == Enums.VisitaEstadoAsistente.ConfirmoAsistencia)
                            //    usuario.Asiste = true;
                            //else
                            //    usuario.Asiste = false;
                        }

                    }
                }
            }
            grdAsistentesCraft.DataSource = asistentes;
            grdAsistentesCraft.RefreshDataSource();

            //Confirmados
            asistentes = new List<AsistentesCraft>();
            foreach (clsVisitaAsistente asistente in VisitaActual.AsistentesCraft)
            {
                AsistentesCraft asistio = new AsistentesCraft();
                if (asistente.Confirmo == Enums.VisitaEstadoAsistente.ConfirmoAsistencia)
                    asistio.Asiste = true;
                else
                    asistio.Asiste = false;

                asistio.Usuario = asistente.Usuario;
                asistio.TieneTopeHorario = false;

                asistentes.Add(asistio);
            }

            grdAsistentesConfirmacion.DataSource = asistentes;
            grdAsistentesConfirmacion.RefreshDataSource();


            //for (int i = 0; i <= lstAsistentesCraft.Items.Count - 1; i++)
            //{
            //    clsUsuario usuario = (clsUsuario)lstAsistentesCraft.Items[i];
            //    foreach (clsVisitaAsistente asistente in VisitaActual.Asistentes)
            //    {

            //        if (asistente.TipoAsistente == Enums.VisitaTipoAsistente.Usuario)
            //        {
            //            if (usuario.Id == asistente.Usuario.Id)
            //            {
            //                lstAsistentesCraft.SetItemChecked(i, true);

            //                if (asistente.Confirmo == Enums.VisitaEstadoAsistente.ConfirmoAsistencia)
            //                    lstAsistentesConfirmacion.Items.Add(asistente.Usuario, true);
            //                else
            //                    lstAsistentesConfirmacion.Items.Add(asistente.Usuario, false);

            //                break;
            //            }
            //        }
            //    }
            //}

            txtEstado.Text = Convert.ToString(VisitaActual.EstadoBD).Replace("_", " ");

            txtMotivoCancelacion.Text = VisitaActual.DescripcionCancelacion;
            txtFechaCancelacion.Text = VisitaActual.FechaCancelacion.ToShortDateString();

            chkReplanificada.Checked = VisitaActual.EsReplanificada;
            txtOrganizador.Text = visita.UsuarioOrganizador.NombreCompleto;


            if (VisitaActual.Vendedor != null)
            {
                for (int i = 0; i < cboVendedor.Properties.Items.Count; i++)
                {
                    if (cboVendedor.Properties.Items[i].ToString().Trim() == VisitaActual.Vendedor.NombreCompleto.Trim())
                        cboVendedor.SelectedIndex = i;

                }
                //cboVendedor.SelectedItem = VisitaActual.Vendedor;

                txtVendedor.Text = VisitaActual.Vendedor.NombreCompleto;
            }

            chkReunionInterna.Checked = visita.EsReunionInterna;

            //if (VisitaActual.EstadoBD == Enums.VisitaEstado.Incompleta)
            //    txtEstado.Text = "Visita Incompleta";

            //if (VisitaActual.EstadoBD == Enums.VisitaEstado.Planificada_Por_confirmar)
            //    txtEstado.Text = "Planificada";

            //if (VisitaActual.EstadoBD == Enums.VisitaEstadoBD.PendienteRegistro)
            //    txtEstado.Text = "Visita realizada, Informe Pendiente";

            //if (VisitaActual.EstadoBD == Enums.VisitaEstadoBD.Realizada)
            //    txtEstado.Text = "Visita Realizada";

            //if (VisitaActual.EstadoBD == Enums.VisitaEstadoBD.NoRealizada)
            //    txtEstado.Text = "Visita no Realizada";

            //if (VisitaActual.EstadoBD == Enums.VisitaEstadoBD.Cancelada)
            //    txtEstado.Text = "Visita Cancelada";



        }

        private void BloquearFormulario()
        {
            this.txtAsunto.Enabled = false;
            this.txtCliente.Enabled = false;
            this.txtDescripcion.Enabled = false;
            this.txtFechaComienzo.Enabled = false;
            this.txtFechaTermino.Enabled = false;
            this.txtHoraComienzo.Enabled = false;
            this.txtHoraTermino.Enabled = false;
            this.txtUbicacion.Enabled = false;
            this.txtVendedor.Enabled = false;
            this.cboNivelImportancia.Enabled = false;
            //this.lstAsistentesCraft.Enabled = false;
            this.grdAsistentesCraft.Enabled = false;
            this.lstAsistentesCliente.Enabled = false;
            this.txtEstado.Enabled = false;
            //lstAsistentesConfirmacion.Enabled = false;
            grdAsistentesConfirmacion.Enabled = false;
            btnConfirmar.Enabled = false;
            MenuGuardar.Enabled = false;
        }

        private void FormularioSoloLectura()
        {
            this.txtAsunto.Properties.ReadOnly = true;
            this.txtCliente.Properties.ReadOnly = true;
            this.txtDescripcion.Properties.ReadOnly = true;
            this.txtFechaComienzo.Properties.ReadOnly = true;
            this.txtFechaTermino.Properties.ReadOnly = true;
            this.txtHoraComienzo.Properties.ReadOnly = true;
            this.txtHoraTermino.Properties.ReadOnly = true;
            this.txtUbicacion.Properties.ReadOnly = true;
            this.txtVendedor.Properties.ReadOnly = true;
            this.cboNivelImportancia.Properties.ReadOnly = true;
            //this.lstAsistentesCraft.Enabled = false;
            //gridView3.Columns[0].OptionsColumn.ReadOnly = true;
            //gridView3.Columns[1].OptionsColumn.ReadOnly = true;
            grdAsistentesCraft.Enabled = false;
            this.lstAsistentesCliente.Enabled = false;
            this.txtEstado.Properties.ReadOnly = true;
            //gridView1.Columns[0].OptionsColumn.ReadOnly = true;
            //gridView1.Columns[1].OptionsColumn.ReadOnly = true;
            grdAsistentesConfirmacion.Enabled = false;
            //lstAsistentesConfirmacion.Enabled = false;
            btnConfirmar.Enabled = false;
            MenuGuardar.Enabled = false;
        }

        private void HabilitarFormulario()
        {
            this.txtAsunto.Properties.ReadOnly = false;
            this.txtCliente.Properties.ReadOnly = false;
            this.txtDescripcion.Properties.ReadOnly = false;
            this.txtFechaComienzo.Properties.ReadOnly = false;
            this.txtFechaTermino.Properties.ReadOnly = false;
            this.txtHoraComienzo.Properties.ReadOnly = false;
            this.txtHoraTermino.Properties.ReadOnly = false;
            this.txtUbicacion.Properties.ReadOnly = false;
            this.txtVendedor.Properties.ReadOnly = false;
            this.cboNivelImportancia.Properties.ReadOnly = false;
            //this.lstAsistentesCraft.Enabled = true;
            grdAsistentesCraft.Enabled = true;
            //gridView3.Columns[0].OptionsColumn.ReadOnly = false;
            //gridView3.Columns[1].OptionsColumn.ReadOnly = false;
            this.lstAsistentesCliente.Enabled = true;
            this.txtEstado.Properties.ReadOnly = true;
            grdAsistentesConfirmacion.Enabled = true;
            //gridView1.Columns[0].OptionsColumn.ReadOnly = false;
            //gridView1.Columns[1].OptionsColumn.ReadOnly = false;
            //lstAsistentesConfirmacion.Enabled = true;
            btnConfirmar.Enabled = true;
            MenuGuardar.Enabled = true;
        }

        public void ConsultarVisita()
        {
            FormularioSoloLectura();
            MenuGuardar.Visible = false;
            MenuConfirmar.Visible = false;
            MenuVisitado.Visible = false;
            MenuCancelar.Visible = false;
            MenuEliminar.Visible = false;
            MenuReplanificar.Visible = false;
            MenuInformVisita.Visible = false;
            btnConfirmar.Visible = false;
            btnCancelarVisita.Visible = false;
            tabCancelar.PageVisible = false;
            TabConfirmacion.PageVisible = false;

            if (VisitaActual.EstadoBD == Enums.VisitaEstado.Cancelada)
                tabCancelar.PageVisible = true;

            if (VisitaActual.EstadoBD == Enums.VisitaEstado.Confirmada ||
                VisitaActual.EstadoBD == Enums.VisitaEstado.Realizada_Con_Informe ||
                VisitaActual.EstadoBD == Enums.VisitaEstado.Realizada_Informe_Pendiente)
                TabConfirmacion.PageVisible = true;


            if (VisitaActual.EstadoBD == Enums.VisitaEstado.Realizada_Con_Informe)
                MenuInformVisita.Visible = true;
        }

        private void CargarImportancia()
        {
            clsParametrosInfo lstImportancias = clsParametros.ListarParametrosPorTipo(Enums.TipoParametro.ImportanciaVisita);
            Utils.Utils.CargaComboBoxParametros(lstImportancias, this.cboNivelImportancia);
        }

        private void CargarClientes()
        {
            IList<clsClienteMaster> listclientes =
                LogicaNegocios.Clientes.clsClientesMaster.ListarClienteMaster(this.cboCliente.Text,
                                                                              Enums.TipoPersona.Comercial, Enums.Estado.Habilitado, true);

            ComboBoxItemCollection coll = cboCliente.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listclientes)
            {
                coll.Add(list);
            }
            cboCliente.SelectedIndex = 0;
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Add(txtCliente.Text);

            foreach (var list in listclientes)
            {
                auto.Add(list.ToString());
            }

            txtCliente.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCliente.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCliente.MaskBox.AutoCompleteCustomSource = auto;
        }

        private void CargarVendedores()
        {
            Entidades.GlobalObject.ResultadoTransaccion resultado = LogicaNegocios.Usuarios.clsUsuarios.ListarUsuarios(Enums.Estado.Habilitado,
                                                                                            Enums.CargosUsuarios.Vendedor);

            IList<clsUsuario> vendedores = new List<clsUsuario>();
            if (resultado.Estado == Enums.EstadoTransaccion.Aceptada)
                vendedores = (IList<clsUsuario>)resultado.ObjetoTransaccion;

            ComboBoxItemCollection coll = cboVendedor.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in vendedores)
            {
                coll.Add(list);
            }
            cboVendedor.SelectedIndex = 0;
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Add(txtVendedor.Text);

            foreach (var list in vendedores)
            {
                auto.Add(list.ToString());
            }

            txtVendedor.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtVendedor.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtVendedor.MaskBox.AutoCompleteCustomSource = auto;
        }

        private void CargarContactos()
        {
            if (ClienteMaster == null) return;

            IList<clsContacto> contactos = new List<clsContacto>();
            contactos = LogicaNegocios.Clientes.clsClientesMaster.ListrContactos(ClienteMaster);

            lstAsistentesCliente.DataSource = contactos;
            lstAsistentesCliente.Refresh();
        }

        private void CargarUsuariosAsistentes()
        {
            IList<clsUsuario> usuarios = new List<clsUsuario>();
            ResultadoTransaccion res = LogicaNegocios.Usuarios.clsUsuarios.ListarUsuarios(Enums.Estado.Habilitado, Enums.CargosUsuarios.Todos);

            if (res.Estado == Enums.EstadoTransaccion.Aceptada)
            {
                usuarios = (IList<clsUsuario>)res.ObjetoTransaccion;
            }

            //asistentes con tope de horario
            res =
                LogicaNegocios.Calendarios.clsCalendarios.ListarAsistentesConTopeDeHorario(
                    Base.Usuario.UsuarioConectado.Usuario, VisitaActual.FechaHoraComienzo.AddSeconds(1), VisitaActual.FechaHoraTermino,
                    VisitaActual.Id);

            IList<clsUsuario> asistentesTope = new List<clsUsuario>();
            if (res.Estado == Enums.EstadoTransaccion.Aceptada)
            {
                asistentesTope = (IList<clsUsuario>)res.ObjetoTransaccion;
            }

            IList<AsistentesCraft> listAsistentesCraft = new List<AsistentesCraft>();
            foreach (var user in usuarios)
            {
                AsistentesCraft asis = new AsistentesCraft();
                asis.Usuario = user;
                asis.Asiste = false;
                asis.TieneTopeHorario = false;

                foreach (var tope in asistentesTope)
                {
                    if (user.Id == tope.Id)
                        asis.TieneTopeHorario = true;
                }
                listAsistentesCraft.Add(asis);
            }

            //lstAsistentesCraft.DataSource = usuarios;
            //lstAsistentesCraft.Refresh();
            grdAsistentesCraft.DataSource = listAsistentesCraft;


        }


        private void LimpiarForm()
        {
            txtAsunto.Text = "";
            txtUbicacion.Text = "";
            txtDescripcion.Text = "";
            //cboVendedor.SelectedItem = Base.Usuario.UsuarioConectado.Usuario;
            //txtVendedor.Text = Base.Usuario.UsuarioConectado.Usuario.NombreCompleto;
            if (AppointmentCalendario != null)
            {
                txtFechaComienzo.Text = AppointmentCalendario.Start.ToShortDateString();
                txtHoraComienzo.Time = AppointmentCalendario.Start;
                txtFechaTermino.Text = AppointmentCalendario.End.ToShortDateString();
                txtHoraTermino.Time = AppointmentCalendario.End;
            }
        }

        private void FrmNuevaVisita_FormClosed(object sender, FormClosedEventArgs e)
        {
            CargarFormularioCentral();
            Instancia = null;
        }

        private void CargarObjetoVisita()
        {
            VisitaActual.Asunto = txtAsunto.Text.Trim();
            VisitaActual.Ubicacion = txtUbicacion.Text.Trim();
            VisitaActual.Descripcion = txtDescripcion.Text.Trim();

            int dia;
            int mes;
            int anio;
            int hora;
            int minuto;
            int segundo;
            dia = txtFechaComienzo.DateTime.Day;
            mes = txtFechaComienzo.DateTime.Month;
            anio = txtFechaComienzo.DateTime.Year;
            hora = txtHoraComienzo.Time.Hour;
            minuto = txtHoraComienzo.Time.Minute;
            segundo = txtHoraComienzo.Time.Second;

            VisitaActual.FechaHoraComienzo = new DateTime(anio, mes, dia, hora, minuto, segundo);

            dia = txtFechaTermino.DateTime.Day;
            mes = txtFechaTermino.DateTime.Month;
            anio = txtFechaTermino.DateTime.Year;
            hora = txtHoraTermino.Time.Hour;
            minuto = txtHoraTermino.Time.Minute;
            segundo = txtHoraTermino.Time.Second;

            VisitaActual.FechaHoraTermino = new DateTime(anio, mes, dia, hora, minuto, segundo);

            if (VisitaActual.EstadoBD == Enums.VisitaEstado.Incompleta)
                VisitaActual.EstadoBD = Enums.VisitaEstado.Planificada_Por_confirmar;

            VisitaActual.EsRecurrente = false;

            VisitaActual.NivelImportancia = (clsItemParametro)cboNivelImportancia.SelectedItem;

            VisitaActual.UsuarioOrganizador = Base.Usuario.UsuarioConectado.Usuario;

            VisitaActual.EsReplanificada = chkReplanificada.Checked;
            if (VisitaActual.EsReplanificada)
            {
                VisitaActual.FechaReplanificacion = DateTime.Now;
                VisitaActual.EstadoBD = Enums.VisitaEstado.Planificada_Por_confirmar;
            }

            VisitaActual.EsReunionInterna = chkReunionInterna.Checked;

            VisitaActual.Asistentes = new List<clsVisitaAsistente>();
            if (chkReunionInterna.Checked)
            {
                VisitaActual.Cliente = null;
                VisitaActual.Vendedor = null;
            }
            else
            {
                VisitaActual.Cliente = (clsClienteMaster)cboCliente.SelectedItem;
                VisitaActual.Vendedor = null;

                for (int i = 0; i < cboVendedor.Properties.Items.Count; i++)
                {
                    if (cboVendedor.Properties.Items[i].ToString().Trim().ToUpper() == txtVendedor.Text.Trim().ToUpper())
                        cboVendedor.SelectedIndex = i;
                }

                if (cboVendedor.SelectedIndex != 0)
                {
                    VisitaActual.Vendedor = (clsUsuario)this.cboVendedor.SelectedItem;
                }


                foreach (clsContacto usuario in lstAsistentesCliente.CheckedItems)
                {
                    clsVisitaAsistente asistente = new clsVisitaAsistente();
                    asistente.Contacto = usuario;
                    asistente.TipoAsistente = Enums.VisitaTipoAsistente.Contacto;
                    asistente.Confirmo = Enums.VisitaEstadoAsistente.Pendiente;
                    VisitaActual.Asistentes.Add(asistente);
                }
            }



            foreach (var asiste in ((IList<AsistentesCraft>)grdAsistentesCraft.DataSource))
            {
                if (asiste.Asiste)
                {
                    clsVisitaAsistente asistente = new clsVisitaAsistente();
                    asistente.Usuario = asiste.Usuario;
                    asistente.TipoAsistente = Enums.VisitaTipoAsistente.Usuario;
                    asistente.Confirmo = Enums.VisitaEstadoAsistente.Pendiente;
                    VisitaActual.Asistentes.Add(asistente);
                }
            }


        }

        private void MenuGuardar_Click(object sender, EventArgs e)
        {
            var mail = new EnvioMailObject();
            DateTime inicioOld = new DateTime();
            DateTime terminoOld = new DateTime();

            bool EsPrimeraPlanificacion = false;

            if (!ValidarFormulario()) return;

            Cursor.Current = Cursors.WaitCursor;

            if (VisitaActual.EstadoBD == Enums.VisitaEstado.Incompleta)
                EsPrimeraPlanificacion = true;

            inicioOld = VisitaActual.FechaHoraComienzo;
            terminoOld = VisitaActual.FechaHoraTermino;


            CargarObjetoVisita();

            ResultadoTransaccion res = LogicaNegocios.Calendarios.clsCalendarios.GuardarVisita(VisitaActual);
            if (res.Estado == Enums.EstadoTransaccion.Rechazada)
            {
                MessageBox.Show(res.Descripcion, "Calendario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                return;
            }
            else
            {
                if (!VisitaActual.EsReplanificada)
                {
                    if (EsPrimeraPlanificacion)
                    {
                        ResultadoTransaccion resEmail = mail.EnviarEmailVisitaPlanificacion(VisitaActual, false, TipoCalendario == Enums.TipoCalendario.CalendarioCompartido); //EnviarEmailPlanificacion(EsPrimeraPlanificacion);
                        //ResultadoTransaccion resEmail = Utils.EnvioEmail.EnviarEmailVisitaPlanificacion(VisitaActual,false,TipoCalendario == Enums.TipoCalendario.CalendarioCompartido); //EnviarEmailPlanificacion(EsPrimeraPlanificacion);                    
                        if (resEmail.Estado == Enums.EstadoTransaccion.Rechazada)
                        {
                            MessageBox.Show(resEmail.Descripcion, "Visitas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        ResultadoTransaccion resEmail = mail.ModificarVisitaOutlook(VisitaActual, inicioOld, terminoOld);
                        //ResultadoTransaccion resEmail = Utils.EnvioEmail.ModificarVisitaOutlook(VisitaActual, inicioOld, terminoOld);
                        if (resEmail.Estado == Enums.EstadoTransaccion.Rechazada)
                        {
                            MessageBox.Show(resEmail.Descripcion, "Visitas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
                else
                {
                    res = new ResultadoTransaccion();
                    res = mail.ModificarVisitaOutlook(VisitaActual, inicioOld, terminoOld);
                    //res = Utils.EnvioEmail.ModificarVisitaOutlook(VisitaActual, inicioOld, terminoOld);
                    if (res.Estado == Enums.EstadoTransaccion.Rechazada)
                    {
                        MessageBox.Show(res.Descripcion, "Visita", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }

            Cursor.Current = Cursors.Default;

            MessageBox.Show("La Visita fue planificada exitosamente", "Visita", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            //frmCalendario form = frmCalendario.Instancia;
            //if(VisitaActual.Cliente.Tipo == Enums.TipoPersona.Cuenta)
            //    form.CargarCalendario(true,false,false);
            //if(VisitaActual.Cliente.Tipo == Enums.TipoPersona.Target)
            //    form.CargarCalendario(false, true, false);
            this.Close();
        }
        
        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
            {
                txtVendedor.Text = "";
                cboVendedor.SelectedIndex = 0;
                return;
            }


            int contador = 0;
            foreach (object item in cboCliente.Properties.Items)
            {
                if (item is clsClienteMaster)
                {
                    if (item.ToString().Trim().ToUpper() == txtCliente.Text.Trim().ToUpper())
                    {
                        cboCliente.SelectedIndex = contador;
                        ClienteMaster = (clsClienteMaster)cboCliente.SelectedItem;
                        break;
                    }
                }
                contador++;
            }

            //Int64 idCliente = ((clsClienteMaster)cboCliente.SelectedItem).Id;

            CargarContactos();
            CargarVendedorClienteSeleccionado();
        }

        private void CargarVendedorClienteSeleccionado()
        {
            if (ClienteMaster == null) return;

            ResultadoTransaccion res = new ResultadoTransaccion();
            clsUsuario vendedor = null;

            if (ClienteMaster.Tipo == Enums.TipoPersona.Cuenta)
            {
                clsCuenta cuenta = new clsCuenta();
                res = LogicaNegocios.Clientes.clsCuentas.ObtenerCuentaPorIdMaster(ClienteMaster.Id);
                if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                {
                    cuenta = (clsCuenta)res.ObjetoTransaccion;
                    vendedor = cuenta.VendedorAsignado;
                }

            }
            if (ClienteMaster.Tipo == Enums.TipoPersona.Target)
            {
                clsTarget target = new clsTarget();
                res = LogicaNegocios.Clientes.clsTarget.ObtenerTargetPorIdMaster(ClienteMaster.Id);
                if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                {
                    target = (clsTarget)res.ObjetoTransaccion;
                    vendedor = target.VendedorAsignado;
                }

                //clsTargetAccount taccount = new clsTargetAccount();
                //res = LogicaNegocios.Clientes.clsTargetAccount.ObtenerTargetAccountPorIdMaster(ClienteMaster.Id);
                //if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                //{
                //    taccount = (clsTargetAccount)res.ObjetoTransaccion;
                //    //vendedor = taccount.VendedorAsignado;
                //}

            }

            txtVendedor.Text = "";
            cboVendedor.SelectedIndex = 0;

            if (vendedor != null)
            {
                txtVendedor.Text = vendedor.NombreCompleto;
                cboVendedor.SelectedItem = vendedor;
            }

        }

        private bool ValidarFormulario()
        {
            bool valida = true;

            dxErrorProvider1.ClearErrors();
            lblAsistenteCliente.Visible = false;
            lblAsistenteCraft.Visible = false;

            if (txtAsunto.Text == "")
            {
                dxErrorProvider1.SetError(txtAsunto, "Debe ingresar Asunto", ErrorType.Critical);
                valida = false;
            }

            if (txtUbicacion.Text == "")
            {
                dxErrorProvider1.SetError(txtUbicacion, "Debe ingresar ubicacion", ErrorType.Critical);
                valida = false;
            }

            //si no es reunion interna validar campos de cliente y vendedor
            if (!chkReunionInterna.Checked)
            {
                if (txtCliente.Text == "")
                {
                    dxErrorProvider1.SetError(txtCliente, "Debe ingresar un Cliente", ErrorType.Critical);
                    valida = false;
                }

                if (txtVendedor.Text == "")
                {
                    dxErrorProvider1.SetError(txtVendedor, "Debe ingresar un Vendedor", ErrorType.Critical);
                    valida = false;
                }

                if (lstAsistentesCliente.CheckedItems.Count == 0)
                {
                    lblAsistenteCliente.Visible = true;
                    valida = false;
                }
            }


            bool asisten = false;
            foreach (var asistente in (IList<AsistentesCraft>)grdAsistentesCraft.DataSource)
            {
                if (asistente.Asiste) asisten = true;
            }
            if (!asisten)
            {
                lblAsistenteCraft.Visible = true;
                dxErrorProvider1.SetError(labelControl7, "Debe seleccionar al menos una persona asistente de Craft", ErrorType.Critical);
                valida = false;
            }

            if (txtDescripcion.Text == "")
            {
                dxErrorProvider1.SetError(txtDescripcion, "Debe ingresar una descripcion de la visita", ErrorType.Critical);
                valida = false;
            }

            return valida;
        }

        private void CargarFormularioCentral()
        {
            if (TipoCalendario == Enums.TipoCalendario.CalendarioCompartido)
            {
                frmCalendarioCompartido form = frmCalendarioCompartido.Instancia;
                form.CargarScheduler();

            }
            else
            {
                if (!EsInforme)
                {
                    frmCalendario form = frmCalendario.Instancia;

                    if (VisitaActual.EsReunionInterna)
                    {
                        form.TipoPersonaFiltro = Enums.TipoPersona.Todos;
                        form.CargarCalendario(false, false, false);
                    }

                    if (VisitaActual.Cliente != null)
                    {
                        if (VisitaActual.Cliente.Tipo == Enums.TipoPersona.Cuenta)
                            form.CargarCalendario(true, false, false);
                        if (VisitaActual.Cliente.Tipo == Enums.TipoPersona.Target)
                            form.CargarCalendario(false, true, false);
                    }
                }
            }
        }

        private void Salir()
        {
            CargarFormularioCentral();
            Instancia = null;
            this.Close();
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuInformVisita_Click(object sender, EventArgs e)
        {
            frmInformeVisita form = frmInformeVisita.Instancia;

            if (Accion == Enums.TipoAccionFormulario.Consultar)
                form.Accion = Enums.TipoAccionFormulario.Consultar;

            if (VisitaActual.EstadoBD == Enums.VisitaEstado.Realizada_Con_Informe || VisitaActual.EstadoBD == Enums.VisitaEstado.Realizada_Con_Informe_Fuera_De_Plazo)
                form.Accion = Enums.TipoAccionFormulario.Consultar;

            form.Visita = VisitaActual;
            form.ShowDialog();
        }

        private void MenuVisitado_Click(object sender, EventArgs e)
        {
            DialogResult resdialogo = MessageBox.Show("Marcara esta Visita como realizada, pero el Informe de Visita quedara pendiente. \n Desea seguir? ", "Visitas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resdialogo == DialogResult.Yes)
            {
                VisitaActual.EstadoBD = Enums.VisitaEstado.Realizada_Informe_Pendiente;

                ResultadoTransaccion res = LogicaNegocios.Calendarios.clsCalendarios.GuardarVisita(VisitaActual);
                if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                {
                    frmCalendario form = frmCalendario.Instancia;
                    if (VisitaActual.Cliente.Tipo == Enums.TipoPersona.Cuenta)
                        form.CargarCalendario(true, false, false);
                    if (VisitaActual.Cliente.Tipo == Enums.TipoPersona.Target)
                        form.CargarCalendario(false, true, false);

                    Instancia = null;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(res.Descripcion, "Visitas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MenuConfirmar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            TabConfirmacion.PageEnabled = true;
            TabVisita.SelectedTabPage = TabConfirmacion;

            //CargarInfoParaConformacion();
        }

        private void CargarInfoParaConformacion()
        {
            if (!ValidarFormulario())
                return;

            if (VisitaActual.EstadoBD == Enums.VisitaEstado.Incompleta)
                VisitaActual.ConfirmadaSinPlanificar = true;

            CargarObjetoVisita();

            if (VisitaActual.EstadoBD != Enums.VisitaEstado.Confirmada)
                CargarAsistentesParaConfirmacion();

            chkEnviaACliente.Text = "Enviar confirmación al Cliente " + this.VisitaActual.Cliente.NombreFantasia;


            //CargarAsistentesConTopeHorario();

        }

        private void CargarAsistentesParaConfirmacion()
        {
            ResultadoTransaccion res =
                LogicaNegocios.Calendarios.clsCalendarios.ListarAsistentesConTopeDeHorario(
                    Base.Usuario.UsuarioConectado.Usuario, VisitaActual.FechaHoraComienzo, VisitaActual.FechaHoraTermino,
                    VisitaActual.Id);

            IList<clsUsuario> asistentesTope = new List<clsUsuario>();
            if (res.Estado == Enums.EstadoTransaccion.Aceptada)
            {
                asistentesTope = (IList<clsUsuario>)res.ObjetoTransaccion;
            }


            //lstAsistentesConfirmacion.Items.Clear();

            if (VisitaActual.EstadoBD == Enums.VisitaEstado.Confirmada)
            {
                foreach (var asistente in VisitaActual.AsistentesCraft)
                {
                    AsistentesCraft asisCraft = new AsistentesCraft();
                    asisCraft.Usuario = asistente.Usuario;
                    asisCraft.TieneTopeHorario = false;
                    if (asistente.Confirmo == Enums.VisitaEstadoAsistente.ConfirmoAsistencia)
                        asisCraft.Asiste = true;
                    else
                        asisCraft.Asiste = false;
                }
            }
            else
            {
                IList<AsistentesCraft> listaasistentes = new List<AsistentesCraft>();
                foreach (var asistente in VisitaActual.AsistentesCraft)
                {
                    AsistentesCraft asisCraft = new AsistentesCraft();
                    asisCraft.Usuario = asistente.Usuario;
                    asisCraft.Asiste = true;

                    foreach (var tope in asistentesTope)
                    {
                        if (asistente.Usuario.Id == tope.Id)
                            asisCraft.TieneTopeHorario = true;
                    }
                    listaasistentes.Add(asisCraft);
                }
                grdAsistentesConfirmacion.DataSource = listaasistentes;
                grdAsistentesConfirmacion.RefreshDataSource();

                //foreach (var asistente in VisitaActual.AsistentesCraft)
                //{
                //    lstAsistentesConfirmacion.Items.Add(asistente.Usuario, true);
                //}    
            }

        }

        private void CargarAsistentesConTopeHorario()
        {
            ResultadoTransaccion res =
                LogicaNegocios.Calendarios.clsCalendarios.ListarAsistentesConTopeDeHorario(
                    Base.Usuario.UsuarioConectado.Usuario, VisitaActual.FechaHoraComienzo, VisitaActual.FechaHoraTermino,
                    VisitaActual.Id);

            if (res.Estado == Enums.EstadoTransaccion.Aceptada)
            {
                IList<clsUsuario> asistentes = (IList<clsUsuario>)res.ObjetoTransaccion;
                IList<clsUsuario> listout = new List<clsUsuario>();


                foreach (var AsisTope in asistentes)
                {
                    foreach (var AsisConf in VisitaActual.AsistentesCraft)
                    {
                        if (AsisTope.Id == AsisConf.Usuario.Id)
                            listout.Add(AsisTope);
                    }
                }

                //grdAsistentesTopeHorario.DataSource = listout;

            }

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            var mail = new EnvioMailObject();
            bool EsConfirmadaSinPlanificar = false;

            if (VisitaActual.EstadoBD == Enums.VisitaEstado.Incompleta)
                EsConfirmadaSinPlanificar = true;

            VisitaActual.EstadoBD = Enums.VisitaEstado.Confirmada;
            VisitaActual.Descripcion = txtDescripcion.Text.Trim();
            VisitaActual.FechaConfirmacion = DateTime.Now;
            VisitaActual.EnviarConfirmacionACliente = (bool)chkEnviaACliente.Checked;

            bool confirmados = false;
            foreach (var confirmado in (IList<AsistentesCraft>)grdAsistentesConfirmacion.DataSource)
            {
                if (confirmado.Asiste) confirmados = true;
            }

            if (!confirmados)
            {
                MessageBox.Show("Debe existir al menos un asistente para confirmar la Visita", "Visita", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            foreach (var asistente in VisitaActual.AsistentesCraft)
            {
                foreach (AsistentesCraft item in (IList<AsistentesCraft>)grdAsistentesConfirmacion.DataSource)
                {
                    if (item.Usuario.Id == asistente.Usuario.Id)
                    {
                        if (item.Asiste)
                            asistente.Confirmo = Enums.VisitaEstadoAsistente.ConfirmoAsistencia;
                        else
                            asistente.Confirmo = Enums.VisitaEstadoAsistente.ConfirmoNoAsistencia;

                        break;
                    }
                }
            }

            ResultadoTransaccion res = LogicaNegocios.Calendarios.clsCalendarios.GuardarVisita(VisitaActual);

            if (res.Estado == Enums.EstadoTransaccion.Rechazada)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(res.Descripcion, "Visita", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            res = new ResultadoTransaccion();

            //Vhspiceros, se saca solo para poder crear la visita
            /*if (VisitaActual.ConfirmadaSinPlanificar)
                res = mail.EnviarEmailVisitaPlanificacion(VisitaActual, true, TipoCalendario == Enums.TipoCalendario.CalendarioCompartido); 
            //res = Utils.EnvioEmail.EnviarEmailVisitaPlanificacion(VisitaActual, true,TipoCalendario == Enums.TipoCalendario.CalendarioCompartido); 
            else
            {
                if (!VisitaActual.EsReunionInterna)
                {
                    res = mail.EnviarEmailVisitaConfirmada(VisitaActual);
                    //res = Utils.EnvioEmail.EnviarEmailVisitaConfirmada(VisitaActual);
                }
                else
                {
                    res = mail.EnviarEmailVisitaConfirmadaReunionInterna(VisitaActual);
                    //res = Utils.EnvioEmail.EnviarEmailVisitaConfirmadaReunionInterna(VisitaActual);
                }
            }*/

            if (res.Estado == Enums.EstadoTransaccion.Rechazada)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(res.Descripcion, "Visita", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

            if (!VisitaActual.EsReunionInterna)
            {
                if (VisitaActual.EnviarConfirmacionACliente)
                {
                    res = new ResultadoTransaccion();
                    res = mail.EnviarEmailVisitaConfirmadaCliente(VisitaActual);
                    //res = Utils.EnvioEmail.EnviarEmailVisitaConfirmadaCliente(VisitaActual);
                    if (res.Estado == Enums.EstadoTransaccion.Rechazada)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show(res.Descripcion, "Visita", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //return;
                    }                    
                }
            }

            Cursor.Current = Cursors.Default;
            MessageBox.Show("Visita Confirmada exitosamente", "Visita", MessageBoxButtons.OK, MessageBoxIcon.Information);

            frmCalendario form = frmCalendario.Instancia;


            if (VisitaActual.EsReunionInterna)
            {
                form.TipoPersonaFiltro = Enums.TipoPersona.Todos;
                form.CargarCalendario(false, false, false);
            }
            if (VisitaActual.Cliente != null)
            {
                if (VisitaActual.Cliente.Tipo == Enums.TipoPersona.Cuenta)
                    form.CargarCalendario(true, false, false);
                if (VisitaActual.Cliente.Tipo == Enums.TipoPersona.Target)
                    form.CargarCalendario(false, true, false);
            }

            Instancia = null;
            this.Close();


        }        

        private void TabConfirmacion_Click(object sender, EventArgs e)
        {
            //CargarInfoParaConformacion();
        }

        private void TabConfirmacion_Enter(object sender, EventArgs e)
        {
            //CargarInfoParaConformacion();
        }

        private void TabVisita_Selecting(object sender, DevExpress.XtraTab.TabPageCancelEventArgs e)
        {
            if (e.PageIndex == 1) CargarInfoParaConformacion();
        }

        private void MenuCancelar_Click(object sender, EventArgs e)
        {
            tabCancelar.PageVisible = true;
            TabVisita.SelectedTabPage = tabCancelar;
        }      

        private void btnCancelarVisita_Click(object sender, EventArgs e)
        {
            var mail = new EnvioMailObject();
            if (txtMotivoCancelacion.Text == "")
            {
                dxErrorProvider1.SetError(txtMotivoCancelacion, "Debe ingresar el motivo de la cancelación", ErrorType.Critical);
                return;
            }

            DialogResult resdialogo = MessageBox.Show("Esta seguro de Cancelar la visita?", "Visitas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resdialogo == DialogResult.Yes)
            {
                VisitaActual.EstadoBD = Enums.VisitaEstado.Cancelada;
                VisitaActual.DescripcionCancelacion = txtMotivoCancelacion.Text;
                VisitaActual.FechaCancelacion = DateTime.Now;
                //VisitaActual.Asunto = VisitaActual.Asunto + " ";
                VisitaActual.Descripcion = VisitaActual.Descripcion + "\n" + "Motivo de Cancelación: " +
                                           VisitaActual.DescripcionCancelacion;

                ResultadoTransaccion res = LogicaNegocios.Calendarios.clsCalendarios.GuardarVisita(VisitaActual);

                if (res.Estado == Enums.EstadoTransaccion.Aceptada)
                {
                    mail.EnviarEmailVisitaCancelada(VisitaActual);                    
                    //Utils.EnvioEmail.EnviarEmailVisitaCancelada(VisitaActual);                    
                    //EnviarEmailCancelacion();

                    MessageBox.Show("Visita fue Cancelada exitosamente", "Visitas", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    frmCalendario form = frmCalendario.Instancia;

                    if (VisitaActual.Cliente.Tipo == Enums.TipoPersona.Cuenta)
                        form.CargarCalendario(true, false, false);
                    if (VisitaActual.Cliente.Tipo == Enums.TipoPersona.Target)
                        form.CargarCalendario(false, true, false);

                    Instancia = null;
                    this.Close();

                }
                else
                {
                    MessageBox.Show(res.Descripcion, "Visitas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resdialogo = MessageBox.Show("¿Está seguro de eliminar la Visita", "Calendario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resdialogo == DialogResult.Yes)
            {
                ResultadoTransaccion resultado = LogicaNegocios.Calendarios.clsCalendarios.EliminarVisita(VisitaActual);

                if (resultado.Estado == Entidades.Enums.Enums.EstadoTransaccion.Rechazada)
                {
                    MessageBox.Show(resultado.Descripcion, "Calendario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                //resultado = new ResultadoTransaccion();
                //resultado = Utils.EnvioEmail.EliminarVisita(VisitaActual);
                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                {
                    MessageBox.Show(resultado.Descripcion, "Visitas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                frmCalendario form = frmCalendario.Instancia;
                if (VisitaActual.Cliente.Tipo == Enums.TipoPersona.Cuenta)
                    form.CargarCalendario(true, false, false);
                if (VisitaActual.Cliente.Tipo == Enums.TipoPersona.Target)
                    form.CargarCalendario(false, true, false);

                Instancia = null;
                this.Close();

            }
        }

        private void MenuReplanificar_Click(object sender, EventArgs e)
        {
            chkReplanificada.Checked = true;
            chkReplanificada.Visible = true;

            HabilitarFormulario();

            VisitaActual.EstadoBD = Enums.VisitaEstado.Incompleta;
            ValidarEstadoVisita();

            //MenuGuardar.Visible = true;
            //MenuConfirmar.Visible = true;

        }

        private void lstAsistentesCraft_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
        {
            if (sender is ListControl)
            {
                ListControl lc = sender as ListControl;


                clsUsuario usuario = (clsUsuario)lc.SelectedValue;

                if (usuario != null)
                {
                    if (usuario.Id == VisitaActual.Vendedor.Id)
                    {
                        if (e.NewValue == CheckState.Unchecked)
                            e.NewValue = CheckState.Checked;
                    }
                }
            }



            //var a = e.CurrentValue;
            //var b = e.Index;
            //var c = e.NewValue;
        }

        private void gridView3_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView currentView = sender as GridView;

            if (e.Column.FieldName == "TieneTopeHorario")
            {
                if (currentView.GetRowCellValue(e.RowHandle, currentView.Columns["TieneTopeHorario"]) != null)
                {
                    bool tope = (bool)currentView.GetRowCellValue(e.RowHandle, currentView.Columns["TieneTopeHorario"]);
                    if (tope)
                    {
                        e.Appearance.BackColor = Color.Red;



                    }
                }
            }
        }

        private void gridView3_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string Tope = View.GetRowCellDisplayText(e.RowHandle, View.Columns["TieneTopeHorario"]);


                if (Tope == "Seleccionado")
                {
                    e.Appearance.BackColor = Color.Salmon;
                    e.Appearance.BackColor2 = Color.SeaShell;
                }
            }
        }

        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string Tope = View.GetRowCellDisplayText(e.RowHandle, View.Columns["TieneTopeHorario"]);


                if (Tope == "Seleccionado")
                {
                    e.Appearance.BackColor = Color.Salmon;
                    e.Appearance.BackColor2 = Color.SeaShell;
                }
            }
        }

        private void chkReunionInterna_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReunionInterna.Checked)
            {
                txtCliente.Text = "";
                txtVendedor.Text = "";
                txtCliente.Enabled = false;
                txtVendedor.Enabled = false;
                lstAsistentesCliente.DataSource = null;
                lstAsistentesCliente.Refresh();
                lstAsistentesCliente.Enabled = false;
                cboCliente.SelectedIndex = 0;
                cboVendedor.SelectedIndex = 0;
            }
            else
            {
                txtCliente.Enabled = true;
                txtVendedor.Enabled = true;
                lstAsistentesCliente.Enabled = true;
            }
        }



    }

    public class AsistentesCraft
    {
        public AsistentesCraft() { }

        public clsUsuario Usuario { get; set; }
        public bool Asiste { get; set; }
        public bool TieneTopeHorario { get; set; }
    }
}
