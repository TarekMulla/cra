using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.UI;
using ProyectoCraft.Entidades.Calendario;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Log;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.LogicaNegocios.Calendarios;
using ProyectoCraft.LogicaNegocios.Log;
using SCCMultimodal.Utils;

namespace ProyectoCraft.WinForm.Calendarios
{
    public partial class frmCalendarioCompartido : Form
    {
        public frmCalendarioCompartido()
        {
            InitializeComponent();
        }

        private static frmCalendarioCompartido _form;
        public static frmCalendarioCompartido Instancia
        {
            get
            {
                if (_form == null)
                    _form = new frmCalendarioCompartido();

                return _form;
            }
            set
            {
                _form = value;
            }
        }

        private List<clsUsuario> Usuarios { set; get; }
        private Hashtable HtUsuarios { set; get; }
        private Hashtable HtUsuariosCalendariosCargados { set; get; }


        public IList<Int64> ListResourcesSelected
        {
            get
            {
                IList<Int64> lista = new List<long>();
                foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem list in resourcesCheckedListBoxControl1.Items)
                {
                    if (list.CheckState == CheckState.Checked)
                    {
                        var b = (ResourceCheckedListBoxItem)list.Value;

                        var c = b.Resource.Id;

                        lista.Add(Convert.ToInt64(c));
                    }
                }

                return lista;
            }
        }

        private IList<clsVisita> _visitasCargadas;
        public IList<clsVisita> VisitasCargadas
        {
            get { return _visitasCargadas; }
            set { _visitasCargadas = value; }
        }

        private List<clsVisita> _visitaslista;
        public List<clsVisita> ListaVisitas
        {
            get { return _visitaslista; }
            set { _visitaslista = value; }
        }

        private void frmCalendarioCompartido_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;

            FormLoad();

            //Verificar si Outlook esta abierto, si no abrir en 2do plano
            bool resultado = Utils.Outlook.VerificarOutlookAbierto();
            if (!resultado)
            {
                MessageBox.Show(
                    "Microsoft Outlook no está abierto y ocurrio un problema al intentar abrirlo, intente abrirlo manualmente antes de utilizar el Modulo Calendario Compartido", "Calendario Compartido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FormLoad()
        {
            //vhspiceros
            var timer = System.Diagnostics.Stopwatch.StartNew();
            Dock = DockStyle.Fill;
            schedulerControl1.Start = DateTime.Now;


            //CargarScheduler();
            DateTime desde = new DateTime(2011, 07, 01, 0, 0, 1);
            DateTime hasta = new DateTime(2011, 07, 30, 0, 0, 1);

            desde = schedulerControl1.Start;

            Usuarios = ObtenerUsuarios();
            HtUsuarios = GenerateHashtableUsuarios(Usuarios);

            /*IList<clsVisita> visitas = clsCalendarios.ListarVisitas(desde, hasta, Convert.ToInt16(Enums.VisitaEstado.Todas),
                                                                    -1, -1, HtUsuarios);*/

            IList<clsVisita> visitas = new List<clsVisita>();

            //visitas[0].Cliente.ToString()
            schedulerStorage1.Appointments.Clear();
            schedulerStorage1.Resources.Clear();
            schedulerStorage1.RefreshData();
            schedulerStorage1.Appointments.DataSource = visitas;

            VisitasCargadas = visitas;
            ListaVisitas = new List<clsVisita>(visitas);


            MapearCalendario(); //1
            CargarAsistentes(); //2
            MapearAsistentesVisita(true); //3

            schedulerControl1.GroupType = SchedulerGroupType.Resource;

            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem list in resourcesCheckedListBoxControl1.Items)
            {
                list.CheckState = CheckState.Unchecked;
            }

            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        public void CargarScheduler()
        {
        }


        private static List<clsUsuario> ObtenerUsuarios()
        {
            List<clsUsuario> usuarios = null;
            ResultadoTransaccion res =
                LogicaNegocios.Usuarios.clsUsuarios.ListarUsuarios(Enums.Estado.Habilitado,
                                                                   Enums.CargosUsuarios.Todos);
            if (res.Estado == Enums.EstadoTransaccion.Aceptada)
            {
                usuarios = (List<clsUsuario>)res.ObjetoTransaccion;
            }
            return usuarios;
        }

        private Hashtable GenerateHashtableUsuarios(IEnumerable<clsUsuario> usuarios)
        {
            var ht = new Hashtable();
            foreach (var u in usuarios)
            {
                ht.Add(u.Id.ToString(), u);
            }
            return ht;
        }

        private void CargarAsistentes()
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();

            ResourceCollection collection = schedulerStorage1.Resources.Items;

            foreach (var usuario in Usuarios)
            {
                collection.Add(new Resource(usuario.Id, usuario.NombreCompleto));
            }
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        private void MapearAsistentesVisita(bool formload)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            AppointmentCollection appointments = schedulerStorage1.Appointments.Items;
            Int64 IdVisita = 0;


            if (formload)
            {
                foreach (var appointment in appointments)
                {
                    IdVisita = Convert.ToInt64(appointment.CustomFields["IdVisita"].ToString());

                    if (IdVisita > 0)
                    {
                        clsVisita visita = new clsVisita(); // clsCalendarios.ObtenerVisitaPorId(IdVisita);

                        visita = ListaVisitas.Find(delegate(clsVisita var1)
                        {
                            return var1.Id == IdVisita;
                        });

                        if (visita == null) break;
                        appointment.ResourceIds.Clear();
                        foreach (var asisCraft in visita.AsistentesCraft)
                        {
                            appointment.ResourceIds.Add(asisCraft.Usuario.Id);
                        }
                        appointment.ResourceIds.Add(visita.UsuarioOrganizador.Id);
                    }
                }
            }
            else
            {
                Appointment appointment = appointments[appointments.Count - 1];
                IdVisita = Convert.ToInt64(appointment.CustomFields["IdVisita"].ToString());
                if (IdVisita > 0)
                {
                    clsVisita visita = clsCalendarios.ObtenerVisitaPorId(IdVisita);

                    appointment.ResourceIds.Clear();
                    foreach (var asisCraft in visita.AsistentesCraft)
                    {
                        appointment.ResourceIds.Add(asisCraft.Usuario.Id);
                    }
                }
            }


            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));

        }

        private void MapearCalendario()
        {

            schedulerStorage1.Appointments.Mappings.Subject = "Asunto";
            schedulerStorage1.Appointments.Mappings.Location = "Ubicacion";
            schedulerStorage1.Appointments.Mappings.Description = "Descripcion";
            schedulerStorage1.Appointments.Mappings.Start = "FechaHoraComienzo";
            schedulerStorage1.Appointments.Mappings.End = "FechaHoraTermino";
            schedulerStorage1.Appointments.Mappings.Label = "EstadoVista";
            schedulerStorage1.Appointments.Mappings.Status = "StatusUsuario";
            //schedulerStorage1.Appointments.Mappings.Status = "Id";

            AppointmentCustomFieldMapping custom = new AppointmentCustomFieldMapping("IdVisita", "Id", FieldValueType.String);
            schedulerStorage1.Appointments.CustomFieldMappings.Add(custom);
        }

        private void schedulerControl1_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            Appointment app = e.Appointment;

            if (app.Description == "") app.CustomFields["IdVisita"] = "0";

            FrmNuevaVisita myForm = FrmNuevaVisita.Instancia;

            if (schedulerStorage1.Appointments.IsNewAppointment(app))
                myForm.Accion = Enums.TipoAccionFormulario.Nuevo;
            else
                myForm.Accion = Enums.TipoAccionFormulario.Editar;

            myForm.ControlParam = (SchedulerControl)sender;
            myForm.AppointmentCalendario = app;
            myForm.TipoCalendario = Enums.TipoCalendario.CalendarioCompartido;
            e.DialogResult = myForm.ShowDialog();

            schedulerControl1.Refresh();
            e.Handled = true;
        }

        private void MenuCalendario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            popupControlContainer1.Visible = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            popupControlContainer1.Visible = false;
        }

        private void schedulerControl1_PreparePopupMenu(object sender, PreparePopupMenuEventArgs e)
        {
            if (e.Menu.Id == SchedulerMenuItemId.DefaultMenu)
            {
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewAllDayEvent);
            }
        }


        private void frmCalendarioCompartido_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void schedulerStorage1_AppointmentInserting(object sender, PersistentObjectCancelEventArgs e)
        {
        }

        private void schedulerStorage1_AppointmentDeleting(object sender, PersistentObjectCancelEventArgs e)
        {
            Appointment app = (Appointment)e.Object;

            clsVisita visita = clsCalendarios.ObtenerVisitaPorId(Convert.ToInt64(app.CustomFields["IdVisita"]));

            if (visita == null) return;

            if (visita.UsuarioOrganizador.Id != Base.Usuario.UsuarioConectado.Usuario.Id &&
               visita.Vendedor.Id != Base.Usuario.UsuarioConectado.Usuario.Id)
            {
                MessageBox.Show("Solo el Organizador o Vendedor pueden eliminar esta visita.", "Calendario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }


            if (visita.EstadoBD == Enums.VisitaEstado.Realizada_Con_Informe || visita.EstadoBD == Enums.VisitaEstado.Realizada_Informe_Pendiente)
            {
                MessageBox.Show("La visita esta marcada como realizada, no es posible eliminarla", "Calendario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }

            if (visita.EstadoBD == Enums.VisitaEstado.No_Realizada)
            {
                MessageBox.Show("La Visita no fue realizada y se encuentra bloqueada, no es posible eliminarla", "Calendario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }

            DialogResult resdialogo = MessageBox.Show("¿Está seguro de eliminar la Visita", "Calendario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resdialogo == DialogResult.Yes)
            {
                ResultadoTransaccion resultado = clsCalendarios.EliminarVisita(visita);

                if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                {
                    MessageBox.Show(resultado.Descripcion, "Calendario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private bool PermitirModificarVisita(Appointment app)
        {
            clsVisita visita = clsCalendarios.ObtenerVisitaPorId(
                                Convert.ToInt64(app.CustomFields["IdVisita"]));


            if (visita != null)
            {
                if (visita.EstadoBD == Enums.VisitaEstado.Cancelada || visita.EstadoBD == Enums.VisitaEstado.Realizada_Informe_Pendiente ||
                    visita.EstadoBD == Enums.VisitaEstado.Realizada_Con_Informe || visita.EstadoBD == Enums.VisitaEstado.Confirmada || visita.EstadoBD == Enums.VisitaEstado.No_Realizada)
                {
                    MessageBox.Show("Visita en estado " + Convert.ToString(visita.EstadoBD).Replace("_", " ") + "\n No es posible modificarla", "Visitas", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);

                    return false;
                }

                if (visita.UsuarioOrganizador.Id != Base.Usuario.UsuarioConectado.Usuario.Id &&
                    visita.Vendedor.Id != Base.Usuario.UsuarioConectado.Usuario.Id)
                {
                    MessageBox.Show("Solo el usuario organizador puede modificar una Visita.", "Visitas", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                    return false;
                }
            }

            return true;
        }

        private void schedulerControl1_AppointmentResized(object sender, AppointmentResizeEventArgs e)
        {
            var mail = new EnvioMailObject();
            if (!PermitirModificarVisita(e.SourceAppointment))
            {
                e.Allow = false;
                e.Handled = true;
                return;
            }

            string moveEventMsg = "Actualizar el evento en horario {0} - {1}  a las {2} - {3} .";

            string msg = string.Format(moveEventMsg, e.SourceAppointment.Start.ToShortTimeString(),
                                e.SourceAppointment.End.ToShortTimeString(),
                                e.EditedAppointment.Start.ToShortTimeString(),
                                e.EditedAppointment.End.ToShortTimeString());


            if (XtraMessageBox.Show(msg + "\r\nProceder?", "Mi Calendario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Allow = false;
                e.Handled = true;
                return;
            }

            clsVisita visita = clsCalendarios.ObtenerVisitaPorId(Convert.ToInt64(e.SourceAppointment.CustomFields["IdVisita"]));
            visita.FechaHoraComienzo = e.EditedAppointment.Start;
            visita.FechaHoraTermino = e.EditedAppointment.End;
            visita.UsuarioOrganizador = Base.Usuario.UsuarioConectado.Usuario;
            visita.Vendedor = Base.Usuario.UsuarioConectado.Usuario;

            ResultadoTransaccion res = clsCalendarios.GuardarVisita(visita);

            if (res.Estado == Enums.EstadoTransaccion.Rechazada)
            {
                MessageBox.Show(res.Descripcion, "Calendario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Allow = false;
                e.Handled = true;
                return;
            }
            mail.ModificarVisitaOutlook(visita, e.SourceAppointment.Start, e.SourceAppointment.End);
        }

        private void resourcesCheckedListBoxControl1_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (HtUsuariosCalendariosCargados == null)
                HtUsuariosCalendariosCargados = new Hashtable();


            if (e.State.Equals(CheckState.Checked))
            {

                var item = resourcesCheckedListBoxControl1.Items[e.Index];
                var resource = (ResourceCheckedListBoxItem)item.Value;
                var idUsuario = Convert.ToInt64(resource.Resource.Id);
                if (HtUsuariosCalendariosCargados.ContainsKey(idUsuario.ToString()))
                {
                    return;
                }
                else
                {
                    HtUsuariosCalendariosCargados.Add(idUsuario.ToString(), "1");
                }

                IList<clsVisita> visitas = clsCalendarios.ListarVisitas(DateTime.Now, DateTime.Now,
                                                                        Convert.ToInt16(Enums.VisitaEstado.Todas),
                                                                        idUsuario, -1, HtUsuarios);
                ListaVisitas.AddRange(visitas);
                schedulerStorage1.Appointments.Items.BeginUpdate();
                foreach (var v in visitas)
                {
                    var foo = schedulerStorage1.CreateAppointment(AppointmentType.Normal);
                    foo.ResourceId = v.Id;
                    foo.Subject = v.Asunto;
                    foo.Location = v.Ubicacion;
                    foo.Description = v.Descripcion;
                    foo.Start = v.FechaHoraComienzo;
                    foo.Start = v.FechaHoraTermino;
                    foo.StatusId = v.StatusUsuario;
                    foo.CustomFields["IdVisita"] = v.Id;
                    schedulerStorage1.Appointments.Items.Add(foo);
                }

                Int64 IdVisita = 0;
                AppointmentCollection appointments = schedulerStorage1.Appointments.Items;
                foreach (var appointment in appointments)
                {
                    IdVisita = Convert.ToInt64(appointment.CustomFields["IdVisita"].ToString());

                    if (IdVisita > 0)
                    {
                        clsVisita visita;

                        visita = ListaVisitas.Find(delegate(clsVisita var1)
                                                       {
                                                           return var1.Id == IdVisita;
                                                       });

                        if (visita == null) break;
                        appointment.ResourceIds.Clear();
                        foreach (var asisCraft in visita.AsistentesCraft)
                        {
                            appointment.ResourceIds.Add(asisCraft.Usuario.Id);
                        }
                        appointment.ResourceIds.Add(visita.UsuarioOrganizador.Id);
                    }
                }
                schedulerStorage1.Appointments.Items.EndUpdate();
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
