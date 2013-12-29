using System;
using System.Collections.Generic;
using System.Drawing;
//using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Exchange;
using ProyectoCraft.Entidades.Calendario;
using ProyectoCraft.Entidades.Clientes.Cuenta;
using ProyectoCraft.Entidades.Clientes.Target;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Enums;
using SCCMultimodal.Utils;

namespace ProyectoCraft.WinForm.Calendarios {
    public partial class frmCalendario : Form {
        GridHitInfo downHitInfo;
        public frmCalendario() {
            InitializeComponent();
        }

        private string PropuestaCuentas = System.Configuration.ConfigurationSettings.AppSettings.Get("CuentasPropuesta");
        private string PropuestaTargets = System.Configuration.ConfigurationSettings.AppSettings.Get("TargetPropuesta");
        private Int16 CountPropuestas = 0;

        private static frmCalendario _form = null;
        public static frmCalendario Instancia {
            get {
                if (_form == null)
                    _form = new frmCalendario();

                return _form;
            }
            set {
                _form = value;
            }
        }


        private Int64 _idclientedraw;
        private Int64 IdClienteDraw {
            get { return _idclientedraw; }
            set { _idclientedraw = value; }
        }

        private DateTime _iniciodraw;
        private DateTime InicioDraw {
            get {
                return _iniciodraw;
            }
            set {
                _iniciodraw = value;
            }
        }

        private DateTime _terminodraw;
        public DateTime TerminoDraw {
            get {
                return _terminodraw;
            }
            set {
                _terminodraw = value;
            }
        }

        private Int16 _idcategoria;
        public Int16 IdCategoriaFiltro {
            get {
                return _idcategoria;
            }
            set {
                _idcategoria = value;
            }
        }

        private DateTime _iniciocalendario;
        public DateTime InicioCalendario {
            get { return _iniciocalendario; }
            set { _iniciocalendario = value; }
        }

        private DateTime _terminocalendario;
        public DateTime TerminoCalendario {
            get { return _terminocalendario; }
            set { _terminocalendario = value; }
        }

        private Entidades.Enums.Enums.VisitaEstado _estadoFiltro;
        public Entidades.Enums.Enums.VisitaEstado EstadoFiltro {
            get { return _estadoFiltro; }
            set { _estadoFiltro = value; }
        }

        private Enums.TipoPersona _tipopersonafiltro;
        public Entidades.Enums.Enums.TipoPersona TipoPersonaFiltro {
            get { return _tipopersonafiltro; }
            set { _tipopersonafiltro = value; }
        }

        private Enums.TipoPersona _tipopropuesta;
        public Enums.TipoPersona TipoPropuesta {
            get { return _tipopropuesta; }
            set { _tipopropuesta = value; }
        }


        private void frmCalendario_Load(object sender, EventArgs e) {
            formularioLoad();
        }

        public void formularioLoad() {
            this.Dock = DockStyle.Fill;
            this.schedulerControl1.Start = DateTime.Now;

            ProcesarEstadoVisitas();

            EstadoFiltro = Entidades.Enums.Enums.VisitaEstado.Todas;
            IdCategoriaFiltro = -1;
            TipoPersonaFiltro = Enums.TipoPersona.Todos;

            CargarCalendarioCuentas(EstadoFiltro, IdCategoriaFiltro);

            schedulerControl1.Storage.EnableReminders = true;
            CargarCantidadSemanas();

            //Verificar si Outlook esta abierto, si no abrir en 2do plano
            bool resultado = Utils.Outlook.VerificarOutlookAbierto();
            if (!resultado) {
                MessageBox.Show(
                    "Microsoft Outlook no está abierto y ocurrio un problema al intentar abrirlo, intente abrirlo manualmente antes de utilizar el Modulo Mi Calendario", "Mi Calendario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CargarCantidadSemanas() {
            repositoryItemComboBox2.Items.Clear();
            for (var i = 1; i < 51; i++)
                repositoryItemComboBox2.Items.Add(i.ToString());

            ListSemanas.EditValue = Base.Usuario.UsuarioConectado.Usuario.CantidadSemanasCalentarioCompartido.ToString();
        }


        private void ProcesarEstadoVisitas() {
            ResultadoTransaccion res = LogicaNegocios.Calendarios.clsCalendarios.ProcesoActualizarEstados();
            if (res.Estado == Enums.EstadoTransaccion.Rechazada) {

            }
        }

        private void ListarCuentasPorPlanificar(Int16 categoria) {
            IList<Entidades.Clientes.clsClienteMaster> lista =
                LogicaNegocios.Calendarios.clsCalendarios.ListarCuentasPorPlanificar(categoria, Base.Usuario.UsuarioConectado.Usuario.Id);

            colNomCliente.Visible = true;
            colContacto.Caption = "Cuenta";

            grdCuentas.DataSource = lista;
            grdCuentas.RefreshDataSource();

        }

        private void ListarTargetPorPlanificar() {
            IList<Entidades.Clientes.clsClienteMaster> lista =
                LogicaNegocios.Calendarios.clsCalendarios.ListarTargetsPorPlanificar(Base.Usuario.UsuarioConectado.Usuario.Id);

            colNomCliente.Visible = false;
            colContacto.Caption = "Target";

            grdCuentas.DataSource = lista;
            grdCuentas.RefreshDataSource();

        }

        private void btnSalir_Click(object sender, EventArgs e) {
            Instancia = null;
            this.Close();
        }

        private void MenuCalendario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            this.popupControlContainer1.Visible = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            this.popupControlContainer1.Visible = false;
        }

        private void btnCerrarPopupClientes_Click(object sender, EventArgs e) {
            this.PopupClientes.Visible = false;
        }

        private void grdTasks_MouseDown(object sender, MouseEventArgs e) {
            GridView view = sender as GridView;
            downHitInfo = null;

            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None)
                return;
            if (e.Button == MouseButtons.Left && hitInfo.InRow && hitInfo.HitTest != GridHitTest.RowIndicator)
                downHitInfo = hitInfo;
        }

        private void grdTasks_MouseMove(object sender, MouseEventArgs e) {
            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && downHitInfo != null) {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2,
                    downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

                if (!dragRect.Contains(new Point(e.X, e.Y))) {
                    view.GridControl.DoDragDrop(GetDragData(view), DragDropEffects.All);
                    downHitInfo = null;
                }
            }
        }

        SchedulerDragData GetDragData(GridView view) {
            int[] selection = view.GetSelectedRows();
            if (selection == null)
                return null;

            AppointmentBaseCollection appointments = new AppointmentBaseCollection();
            int count = selection.Length;
            for (int i = 0; i < count; i++) {
                int rowIndex = selection[i];
                Appointment apt = schedulerStorage1.CreateAppointment(AppointmentType.Normal);
                apt.Subject = "Programación de Visita Cliente " + (string)view.GetRowCellValue(rowIndex, "NombreCliente");
                apt.LabelId = (int)Entidades.Enums.Enums.VisitaEstadoVista.Pendiente; // (int)view.GetRowCellValue(rowIndex, "Severity");
                apt.StatusId = 0; // (int)view.GetRowCellValue(rowIndex, "Priority");
                apt.Duration = new TimeSpan(0, 1, 0, 0); // TimeSpan.FromHours((int)view.GetRowCellValue(rowIndex, "Duration"));
                apt.Description = "Visita Cliente " + (string)view.GetRowCellValue(rowIndex, "NombreCliente");
                IdClienteDraw = (Int64)view.GetRowCellValue(rowIndex, "Id");
                appointments.Add(apt);
            }

            return new SchedulerDragData(appointments, 0);
        }

        private void schedulerControl1_AppointmentDrop(object sender, AppointmentDragEventArgs e) {
            string createEventMsg = "Crear el evento a las {0} el dia {1}.";
            string moveEventMsg = "Mover el evento desde {0} el dia {1} a las {2} el dia {3}.";

            bool Crear = false;
            bool Mover = false;


            DateTime srcStart = e.SourceAppointment.Start;
            DateTime newStart = e.EditedAppointment.Start;

            string msg = (srcStart == DateTime.MinValue) ? String.Format(createEventMsg, newStart.ToShortTimeString(), newStart.ToShortDateString()) :
                String.Format(moveEventMsg, srcStart.ToShortTimeString(), srcStart.ToShortDateString(), newStart.ToShortTimeString(), newStart.ToShortDateString());


            if (msg.Contains("Crear"))
                Crear = true;

            if (msg.Contains("Mover"))
                Mover = true;

            clsVisita visita = new clsVisita();

            if (Mover) {
                if (!PermitirModificarVisita(e.SourceAppointment)) {
                    e.Allow = false;
                    e.Handled = true;
                    return;
                }
            }


            if (XtraMessageBox.Show(msg + "\r\nProceder?", "Mi Calendario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                e.Allow = false;
                e.Handled = true;
                return;
            }




            if (Convert.ToInt64(e.SourceAppointment.CustomFields["IdVisita"]) > 0) {
                if (Mover) {
                    visita =
                        LogicaNegocios.Calendarios.clsCalendarios.ObtenerVisitaPorId(
                            Convert.ToInt64(e.SourceAppointment.CustomFields["IdVisita"]));


                }

                //visita.Id = Convert.ToInt64(e.SourceAppointment.CustomFields["IdVisita"]);
                //visita.Asunto = e.SourceAppointment.Subject;
                //visita.Descripcion = e.SourceAppointment.Description;
                //visita.Ubicacion = e.SourceAppointment.Location;
                visita.FechaHoraComienzo = e.EditedAppointment.Start;
                visita.FechaHoraTermino = e.EditedAppointment.End;
            } else {
                visita.Id = Convert.ToInt64(e.SourceAppointment.CustomFields["IdVisita"]);
                visita.Asunto = e.SourceAppointment.Subject;
                visita.Descripcion = e.SourceAppointment.Description;
                visita.Ubicacion = e.SourceAppointment.Location;
                visita.FechaHoraComienzo = e.EditedAppointment.Start;
                visita.FechaHoraTermino = e.EditedAppointment.End;
            }

            if (Crear) {
                visita.Cliente = LogicaNegocios.Clientes.clsClientesMaster.ObtenerClienteMasterPorId(IdClienteDraw);
                visita.EstadoBD = Entidades.Enums.Enums.VisitaEstado.Incompleta;

                if (visita.Cliente.Tipo == Enums.TipoPersona.Cuenta) {
                    ResultadoTransaccion resCuenta = LogicaNegocios.Clientes.clsCuentas.ObtenerCuentaPorIdMaster(visita.Cliente.Id);
                    clsCuenta cuenta = new clsCuenta();
                    if (resCuenta.Estado == Enums.EstadoTransaccion.Aceptada)
                        cuenta = (clsCuenta)resCuenta.ObjetoTransaccion;

                    if (cuenta != null)
                        visita.Vendedor = cuenta.VendedorAsignado;
                } else if (visita.Cliente.Tipo == Enums.TipoPersona.Target) {
                    ResultadoTransaccion resCuenta =
                        LogicaNegocios.Clientes.clsTarget.ObtenerTargetPorIdMaster(visita.Cliente.Id);

                    clsTarget target = new clsTarget();
                    if (resCuenta.Estado == Enums.EstadoTransaccion.Aceptada)
                        target = (clsTarget)resCuenta.ObjetoTransaccion;

                    if (target != null)
                        visita.Vendedor = target.VendedorAsignado;
                }


                clsVisitaAsistente asistente = new clsVisitaAsistente();
                asistente.Usuario = Base.Usuario.UsuarioConectado.Usuario;
                asistente.TipoAsistente = Entidades.Enums.Enums.VisitaTipoAsistente.Usuario;
                visita.Asistentes.Add(asistente);

                clsParametrosInfo paraminfo = LogicaNegocios.Parametros.clsParametros.ListarParametrosPorTipo(Entidades.Enums.Enums.TipoParametro.ImportanciaVisita);
                visita.NivelImportancia = paraminfo.Items[0];  // Entidades.Enums.Enums.VisitaNivelImportancia.Baja;    
            }


            //visita.Vendedor = Base.Usuario.UsuarioConectado.Usuario;

            visita.UsuarioOrganizador = Base.Usuario.UsuarioConectado.Usuario;
            Entidades.GlobalObject.ResultadoTransaccion res = LogicaNegocios.Calendarios.clsCalendarios.GuardarVisita(visita);

            if (res.Estado == Entidades.Enums.Enums.EstadoTransaccion.Aceptada) {

            } else {

                MessageBox.Show(res.Descripcion, "Calendario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Allow = false;
                e.Handled = true;
                return;
            }

            PopupClientes.Visible = false;

            //if(schedulerStorage1.Appointments.IsNewAppointment(e.EditedAppointment))
            //{
            //    schedulerStorage1.Appointments.Add(e.EditedAppointment);
            //}

            //SincronizarOutlook();
        }

        private void SincronizarOutlook() {
            try {
                AppointmentExportSynchronizer synchronizerExport = this.schedulerStorage1.CreateOutlookExportSynchronizer();
                synchronizerExport.ForeignIdFieldName = "EntryID";
                synchronizerExport.Synchronize();
            } catch (Exception ex) {
                MessageBox.Show("No se pudo sincronizar con Microsoft Outlook, verifique que esta aplicacion este abierta.", "Outlook", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void OutlookToCalendar() {
            AppointmentImportSynchronizer importer = this.schedulerStorage1.CreateOutlookImportSynchronizer();
            importer.ForeignIdFieldName = "EntryID";
            importer.Synchronize();

        }

        private void schedulerControl1_InitNewAppointment(object sender, AppointmentEventArgs e) {

            //FrmNuevaVisita form = new FrmNuevaVisita();
            //form.ShowDialog();
            //schedulerControl1.CancelUpdate();

        }

        private void contextMenuStrip1_Click(object sender, EventArgs e) {
            FrmNuevaVisita form = new FrmNuevaVisita();
            form.ShowDialog();

        }

        private void schedulerControl1_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                SchedulerControl aaa = (SchedulerControl)sender;


                //frmAppointment form = new frmAppointment();
                //form.ShowDialog();
            }
        }

        private void schedulerControl1_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e) {
            Appointment app = e.Appointment;

            //if (app.Description == "") app.StatusId = 0;
            if (app.Description == "") app.CustomFields["IdVisita"] = "0";

            FrmNuevaVisita myForm = FrmNuevaVisita.Instancia;

            if (schedulerStorage1.Appointments.IsNewAppointment(app))
                myForm.Accion = Entidades.Enums.Enums.TipoAccionFormulario.Nuevo;
            else
                myForm.Accion = Entidades.Enums.Enums.TipoAccionFormulario.Editar;


            myForm.ControlParam = (SchedulerControl)sender;
            myForm.AppointmentCalendario = app;

            //myForm.frmLoad();

            //if(!schedulerControl1.Storage.Appointments.IsNewAppointment(app))
            //myForm.CargarFormulario();

            e.DialogResult = myForm.ShowDialog();

            schedulerControl1.Refresh();
            e.Handled = true;

            //SincronizarOutlook();

        }

        //public void RefreshCalendar()
        //{
        //    LoadDataCalendar(Entidades.Enums.Enums.VisitaEstadoBD.Todas,IdCategoria);

        //}

        private void schedulerStorage1_AppointmentsInserted(object sender, PersistentObjectsEventArgs e) {
            CargarCalendarioCuentas(EstadoFiltro, IdCategoriaFiltro);
            //CargarCalendario(Entidades.Enums.Enums.VisitaEstadoBD.Todas);

            //var a = e.Objects;

            //Appointment app = (Appointment)e.Objects[0];


            //Entidades.Calendario.clsVisita visita = new clsVisita();
            //visita.Descripcion = app.Description;



            //SincronizarOutlook();
        }

        private void schedulerStorage1_AppointmentsChanged(object sender, PersistentObjectsEventArgs e) {
            //SincronizarOutlook();
        }

        private void MenuCuentasVIPPorPlanificar_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            CountPropuestas = 0;
            TipoPropuesta = Enums.TipoPersona.Cuenta;
            //IdCategoriaFiltro = 39;
            ListarCuentasPorPlanificar(39);
            this.PopupClientes.Visible = true;

        }

        private void MenuCuentasCPPorPlanificar_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            //IdCategoria = 40;
            ListarCuentasPorPlanificar(40);
            this.PopupClientes.Visible = true;
        }

        private void MenuCuentasPeqPorPlanificar_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            //IdCategoria = 41;
            ListarCuentasPorPlanificar(41);
            this.PopupClientes.Visible = true;
        }

        private void CargarCalendarioCuentas(Enums.VisitaEstado estado, Int16 idCategoria) {
            var semanas = Base.Usuario.UsuarioConectado.Usuario.CantidadSemanasCalentarioCompartido;
            DateTime desde = DateTime.Now.AddDays((semanas * 7) * -1);
            DateTime hasta = DateTime.Now.AddDays(Convert.ToInt32(semanas * 7));

            IList<clsVisita> visitas =
                LogicaNegocios.Calendarios.clsCalendarios.ListarVisitas(desde, hasta, Convert.ToInt16(estado), Base.Usuario.UsuarioConectado.Usuario.Id, idCategoria);

            schedulerStorage1.Appointments.Clear();
            schedulerStorage1.RefreshData();

            schedulerStorage1.Appointments.DataSource = visitas;

            MapearCalendario();
        }

        private void CargarCalendarioTarget(Enums.VisitaEstado estado) {
            var semanas = Base.Usuario.UsuarioConectado.Usuario.CantidadSemanasCalentarioCompartido;
            DateTime desde = DateTime.Now.AddDays((semanas * 7) * -1);
            DateTime hasta = DateTime.Now.AddMonths(Convert.ToInt32(semanas * 7));

            IList<clsVisita> visitas =
                LogicaNegocios.Calendarios.clsCalendarios.ListarVisitasTarget(desde, hasta, Convert.ToInt16(estado), Base.Usuario.UsuarioConectado.Usuario.Id);

            schedulerStorage1.Appointments.Clear();
            schedulerStorage1.RefreshData();

            schedulerStorage1.Appointments.DataSource = visitas;

            MapearCalendario();

        }


        private void MapearCalendario() {
            schedulerStorage1.Appointments.Mappings.Subject = "Cliente"; //"Asunto";
            schedulerStorage1.Appointments.Mappings.Location = "Ubicacion";
            schedulerStorage1.Appointments.Mappings.Description = "Descripcion";
            schedulerStorage1.Appointments.Mappings.Start = "FechaHoraComienzo";
            schedulerStorage1.Appointments.Mappings.End = "FechaHoraTermino";
            schedulerStorage1.Appointments.Mappings.Label = "EstadoVista";
            schedulerStorage1.Appointments.Mappings.Status = "StatusUsuario";

            AppointmentCustomFieldMapping custom = new AppointmentCustomFieldMapping("IdVisita", "Id", FieldValueType.String);
            schedulerStorage1.Appointments.CustomFieldMappings.Add(custom);
        }

        private void schedulerControl1_InplaceEditorShowing(object sender, InplaceEditorEventArgs e) {

        }

        private void MenuCuentasVIPNoRealizadas_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            EstadoFiltro = Entidades.Enums.Enums.VisitaEstado.No_Realizada;
            IdCategoriaFiltro = 39;
            TipoPersonaFiltro = Enums.TipoPersona.Cuenta;
            CargarCalendarioCuentas(EstadoFiltro, IdCategoriaFiltro);
        }

        private void MenuCuentasVIPPlanificadas_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            EstadoFiltro = Entidades.Enums.Enums.VisitaEstado.Planificada_Por_confirmar;
            IdCategoriaFiltro = 39;
            TipoPersonaFiltro = Enums.TipoPersona.Cuenta;
            CargarCalendarioCuentas(EstadoFiltro, IdCategoriaFiltro);
        }

        private void MenuCuentasVIPTodas_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            EstadoFiltro = Entidades.Enums.Enums.VisitaEstado.Todas;
            IdCategoriaFiltro = 39;
            TipoPersonaFiltro = Enums.TipoPersona.Cuenta;
            CargarCalendarioCuentas(EstadoFiltro, IdCategoriaFiltro);
        }

        private void MenuCuentasCPPlanificadas_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            EstadoFiltro = Entidades.Enums.Enums.VisitaEstado.Planificada_Por_confirmar;
            IdCategoriaFiltro = 40;
            TipoPersonaFiltro = Enums.TipoPersona.Cuenta;
            CargarCalendarioCuentas(EstadoFiltro, IdCategoriaFiltro);
        }

        private void MenuCuentasCPNoRealizadas_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            EstadoFiltro = Entidades.Enums.Enums.VisitaEstado.No_Realizada;
            IdCategoriaFiltro = 40;
            TipoPersonaFiltro = Enums.TipoPersona.Cuenta;
            CargarCalendarioCuentas(EstadoFiltro, IdCategoriaFiltro);
        }

        private void MenuCuentasCPTodas_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            EstadoFiltro = Entidades.Enums.Enums.VisitaEstado.Todas;
            IdCategoriaFiltro = 40;
            TipoPersonaFiltro = Enums.TipoPersona.Cuenta;
            CargarCalendarioCuentas(EstadoFiltro, IdCategoriaFiltro);
        }

        private void MenuCuentasPeqPlanificadas_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            EstadoFiltro = Entidades.Enums.Enums.VisitaEstado.Planificada_Por_confirmar;
            IdCategoriaFiltro = 41;
            TipoPersonaFiltro = Enums.TipoPersona.Cuenta;
            CargarCalendarioCuentas(EstadoFiltro, IdCategoriaFiltro);
        }

        private void MenuCuentasPeqNoRealizadas_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            EstadoFiltro = Entidades.Enums.Enums.VisitaEstado.No_Realizada;
            IdCategoriaFiltro = 41;
            TipoPersonaFiltro = Enums.TipoPersona.Cuenta;
            CargarCalendarioCuentas(EstadoFiltro, IdCategoriaFiltro);
        }

        private void MenuCuentasPeqTodas_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            EstadoFiltro = Entidades.Enums.Enums.VisitaEstado.Todas;
            IdCategoriaFiltro = 41;
            TipoPersonaFiltro = Enums.TipoPersona.Cuenta;
            CargarCalendarioCuentas(EstadoFiltro, IdCategoriaFiltro);
        }

        private void schedulerControl1_ActiveViewChanged(object sender, EventArgs e) {
            InicioCalendario = schedulerControl1.Start;
            var view = schedulerControl1.ActiveView;
        }

        private void schedulerControl1_StorageChanged(object sender, EventArgs e) {
            var a = 0;
        }

        private void MenuGeneralTodos_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            EstadoFiltro = Entidades.Enums.Enums.VisitaEstado.Todas;
            IdCategoriaFiltro = -1;
            TipoPersonaFiltro = Enums.TipoPersona.Cuenta;
            CargarCalendarioCuentas(EstadoFiltro, IdCategoriaFiltro);
        }

        private void schedulerStorage1_AppointmentDeleting(object sender, PersistentObjectCancelEventArgs e) {
            Appointment app = (Appointment)e.Object;

            clsVisita visita = LogicaNegocios.Calendarios.clsCalendarios.ObtenerVisitaPorId(Convert.ToInt64(app.CustomFields["IdVisita"]));

            if (visita == null) return;

            if (visita.EstadoBD == Entidades.Enums.Enums.VisitaEstado.Realizada_Con_Informe || visita.EstadoBD == Entidades.Enums.Enums.VisitaEstado.Realizada_Informe_Pendiente) {
                MessageBox.Show("La visita esta marcada como realizada, no es posible eliminarla", "Calendario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }

            if (visita.EstadoBD == Entidades.Enums.Enums.VisitaEstado.No_Realizada) {
                MessageBox.Show("La Visita no fue realizada y se encuentra bloqueada, no es posible eliminarla", "Calendario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }

            DialogResult resdialogo = MessageBox.Show("¿Está seguro de eliminar la Visita", "Calendario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resdialogo == DialogResult.Yes) {
                ResultadoTransaccion resultado = LogicaNegocios.Calendarios.clsCalendarios.EliminarVisita(visita);

                if (resultado.Estado == Entidades.Enums.Enums.EstadoTransaccion.Rechazada) {
                    MessageBox.Show(resultado.Descripcion, "Calendario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }

                // LoadDataCalendar();

            } else {
                e.Cancel = true;
            }

        }

        private void MenuTargetPorPlanificar_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            CountPropuestas = 0;
            TipoPropuesta = Enums.TipoPersona.Target;
            ListarTargetPorPlanificar();
            PopupClientes.Visible = true;
        }


        private bool PermitirModificarVisita(Appointment app) {
            clsVisita visita =
                LogicaNegocios.Calendarios.clsCalendarios.ObtenerVisitaPorId(
                    Convert.ToInt64(app.CustomFields["IdVisita"]));


            if (visita != null) {
                if (visita.EstadoBD == Enums.VisitaEstado.Cancelada || visita.EstadoBD == Enums.VisitaEstado.Realizada_Informe_Pendiente ||
                    visita.EstadoBD == Enums.VisitaEstado.Realizada_Con_Informe || visita.EstadoBD == Enums.VisitaEstado.Confirmada || visita.EstadoBD == Enums.VisitaEstado.No_Realizada) {
                    MessageBox.Show("Visita en estado " + Convert.ToString(visita.EstadoBD).Replace("_", " ") + "\n No es posible modificarla", "Visitas", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);

                    return false;
                }

                if (visita.UsuarioOrganizador.Id != Base.Usuario.UsuarioConectado.Usuario.Id) {
                    MessageBox.Show("Solo el usuario organizador puede modificar una Visita.", "Visitas", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                    return false;
                }
            }


            //if(visita.LabelId == 3 || visita.LabelId == 6 || visita.LabelId == 2 || visita.LabelId == 0)
            //{
            //    MessageBox.Show("No es poible modificar la visita.", "Visitas", MessageBoxButtons.OK,
            //                    MessageBoxIcon.Error);

            //    return false;
            //}
            return true;
        }

        private void schedulerControl1_AppointmentResized(object sender, AppointmentResizeEventArgs e) {
            var mail = new EnvioMailObject();
            if (!PermitirModificarVisita(e.SourceAppointment)) {
                e.Allow = false;
                e.Handled = true;
                return;
            }

            string moveEventMsg = "Actualizar el evento en horario {0} - {1}  a las {2} - {3} .";

            string msg = string.Format(moveEventMsg, e.SourceAppointment.Start.ToShortTimeString(),
                                e.SourceAppointment.End.ToShortTimeString(),
                                e.EditedAppointment.Start.ToShortTimeString(),
                                e.EditedAppointment.End.ToShortTimeString());


            if (XtraMessageBox.Show(msg + "\r\nProceder?", "Mi Calendario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                e.Allow = false;
                e.Handled = true;
                return;
            }

            clsVisita visita = LogicaNegocios.Calendarios.clsCalendarios.ObtenerVisitaPorId(Convert.ToInt64(e.SourceAppointment.CustomFields["IdVisita"]));
            visita.FechaHoraComienzo = e.EditedAppointment.Start;
            visita.FechaHoraTermino = e.EditedAppointment.End;
            visita.UsuarioOrganizador = Base.Usuario.UsuarioConectado.Usuario;
            visita.Vendedor = Base.Usuario.UsuarioConectado.Usuario;

            ResultadoTransaccion res = LogicaNegocios.Calendarios.clsCalendarios.GuardarVisita(visita);

            if (res.Estado == Entidades.Enums.Enums.EstadoTransaccion.Rechazada) {
                MessageBox.Show(res.Descripcion, "Calendario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Allow = false;
                e.Handled = true;
                return;
            }
            mail.ModificarVisitaOutlook(visita, e.SourceAppointment.Start, e.SourceAppointment.End);
            //Utils.EnvioEmail.ModificarVisitaOutlook(visita,e.SourceAppointment.Start,e.SourceAppointment.End);

            // LoadDataCalendar();
        }

        private void schedulerControl1_PreparePopupMenu(object sender, PreparePopupMenuEventArgs e) {
            if (e.Menu.Id == SchedulerMenuItemId.DefaultMenu) {
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewAppointment);
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewAllDayEvent);

            }

            //foreach (SchedulerMenuItem item in e.Menu.Items)
            //{
            //    //item.Visible = false;
            //} 
        }

        private void MenuCuentasVIPConfirmadas_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            EstadoFiltro = Entidades.Enums.Enums.VisitaEstado.Confirmada;
            IdCategoriaFiltro = 39;
            TipoPersonaFiltro = Enums.TipoPersona.Cuenta;
            CargarCalendarioCuentas(EstadoFiltro, IdCategoriaFiltro);
        }

        private void MenuCuentasCPConfirmadas_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            EstadoFiltro = Entidades.Enums.Enums.VisitaEstado.Confirmada;
            IdCategoriaFiltro = 40;
            TipoPersonaFiltro = Enums.TipoPersona.Cuenta;
            CargarCalendarioCuentas(EstadoFiltro, IdCategoriaFiltro);
        }

        private void MenuCuentasPeqConfirmadas_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            EstadoFiltro = Entidades.Enums.Enums.VisitaEstado.Confirmada;
            IdCategoriaFiltro = 41;
            TipoPersonaFiltro = Enums.TipoPersona.Cuenta;
            CargarCalendarioCuentas(EstadoFiltro, IdCategoriaFiltro);
        }

        private void MenuTargetPlanificados_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            EstadoFiltro = Entidades.Enums.Enums.VisitaEstado.Planificada_Por_confirmar;
            TipoPersonaFiltro = Enums.TipoPersona.Target;
            CargarCalendarioTarget(EstadoFiltro);
        }

        public void CargarCalendario(bool EsCuenta, bool EsTarget, bool EsCaso) {
            if (TipoPersonaFiltro == Enums.TipoPersona.Cuenta || TipoPersonaFiltro == Enums.TipoPersona.Todos)
                CargarCalendarioCuentas(EstadoFiltro, IdCategoriaFiltro);

            if (TipoPersonaFiltro == Enums.TipoPersona.Target)
                CargarCalendarioTarget(EstadoFiltro);

        }

        private void MenuTargetConfirmadas_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            EstadoFiltro = Entidades.Enums.Enums.VisitaEstado.Confirmada;
            TipoPersonaFiltro = Enums.TipoPersona.Target;
            CargarCalendarioTarget(EstadoFiltro);
        }

        private void MenuTargetNoRealizadas_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            EstadoFiltro = Entidades.Enums.Enums.VisitaEstado.No_Realizada;
            TipoPersonaFiltro = Enums.TipoPersona.Target;
            CargarCalendarioTarget(EstadoFiltro);
        }

        private void MenuTargetTodas_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            EstadoFiltro = Entidades.Enums.Enums.VisitaEstado.Todas;
            TipoPersonaFiltro = Enums.TipoPersona.Target;
            CargarCalendarioTarget(EstadoFiltro);
        }


        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e) {
            if (TipoPropuesta == Enums.TipoPersona.Cuenta) {
                if (CountPropuestas < (Convert.ToInt16(PropuestaCuentas) * 2)) {
                    Color oBgcolor;

                    oBgcolor = Color.AntiqueWhite;
                    e.Appearance.BackColor = oBgcolor;
                    e.Appearance.ForeColor = Color.Black;
                    CountPropuestas++;
                }
            }

            if (TipoPropuesta == Enums.TipoPersona.Target) {
                if (CountPropuestas < Convert.ToInt16(PropuestaTargets)) {
                    Color oBgcolor;

                    oBgcolor = Color.AntiqueWhite;
                    e.Appearance.BackColor = oBgcolor;
                    e.Appearance.ForeColor = Color.Black;
                    CountPropuestas++;
                }
            }

        }

        private void ListSemanas_EditValueChanged(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
            Base.Usuario.UsuarioConectado.Usuario.CantidadSemanasCalentarioCompartido = Convert.ToInt64(ListSemanas.EditValue);
            formularioLoad();
            Cursor.Current = Cursors.Default;
        }

        private void ListSemanas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {

        }
    }
}