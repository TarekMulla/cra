using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using Microsoft.Office.Interop.Outlook;
using ProyectoCraft.Entidades.Calendario;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.LogicaNegocios.Calendarios;
using System.Collections;
using SCCMultimodal.Utils;

namespace ProyectoCraft.WinForm.Calendarios
{
    public partial class frmCalendarioCompartido : Form
    {
        public frmCalendarioCompartido()
        {
            InitializeComponent();
        }

        private static frmCalendarioCompartido _form = null;
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

        public IList<Int64> ListResourcesSelected
        {           
            get
            {
                IList<Int64> lista = new List<long>();
                foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem list in resourcesCheckedListBoxControl1.Items)
                {
                    if(list.CheckState == CheckState.Checked)
                    {
                        var a = list.Value.GetType();
                        DevExpress.XtraScheduler.UI.ResourceCheckedListBoxItem b = (DevExpress.XtraScheduler.UI.ResourceCheckedListBoxItem)list.Value;

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
            set {  _visitaslista = value; }
        }

        private void frmCalendarioCompartido_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            FormLoad();

            //Verificar si Outlook esta abierto, si no abrir en 2do plano
            bool resultado = Utils.Outlook.VerificarOutlookAbierto();
            if (!resultado)
            {
                MessageBox.Show(
                    "Microsoft Outlook no está abierto y ocurrio un problema al intentar abrirlo, intente abrirlo manualmente antes de utilizar el Modulo Calendario Compartido","Calendario Compartido",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }




            //this.schedulerControl1.Start = DateTime.Now;

            //CargarVisitas();
            //CargarAsistentes();
            //MapearAsistentesVisita();

            //schedulerControl1.GroupType = SchedulerGroupType.Resource;

            //foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem list in resourcesCheckedListBoxControl1.Items)
            //{
            //    list.CheckState = CheckState.Unchecked;
            //}
            
        }

        public void FormLoad()
        {
            this.Dock = DockStyle.Fill;
            this.schedulerControl1.Start = DateTime.Now;

            
            //CargarScheduler();
            DateTime desde = new DateTime(2011, 07, 01, 0, 0, 1);
            DateTime hasta = new DateTime(2011, 07, 30, 0, 0, 1);

            desde = schedulerControl1.Start;

            IList<clsVisita> visitas = clsCalendarios.ListarVisitas(desde, hasta, Convert.ToInt16(Entidades.Enums.Enums.VisitaEstado.Todas),
                                                                    -1, -1);
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

            
        }

        public void CargarScheduler()
        {
            Cursor.Current = Cursors.WaitCursor;

            IList<Int64> listaseleccionados = ListResourcesSelected;

            DateTime desde = new DateTime(9999, 07, 01, 0, 0, 1);
            DateTime hasta = new DateTime(2011, 07, 30, 0, 0, 1);

            //desde = schedulerControl1.Start;

            IList<clsVisita> visitas = clsCalendarios.ListarVisitas(desde, hasta, Convert.ToInt16(Entidades.Enums.Enums.VisitaEstado.Todas),
                                                                    -1, -1);

            VisitasCargadas = visitas;
            ListaVisitas = new List<clsVisita>(visitas);

            schedulerStorage1.Appointments.Clear();
            //schedulerStorage1.Resources.Clear();
            schedulerStorage1.Appointments.DataSource = visitas;
            //schedulerStorage1.RefreshData();
            

            MapearCalendario(); //1
            //CargarAsistentes(); //2
            MapearAsistentesVisita(true); //3

            //schedulerControl1.GroupType = SchedulerGroupType.Resource;

            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem list in resourcesCheckedListBoxControl1.Items)
            {
                list.CheckState = CheckState.Unchecked;
            }

            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem list in resourcesCheckedListBoxControl1.Items)
            {
                foreach (var list2 in listaseleccionados)
                {
                    DevExpress.XtraScheduler.UI.ResourceCheckedListBoxItem b = (DevExpress.XtraScheduler.UI.ResourceCheckedListBoxItem)list.Value;
                    if(Convert.ToInt64(b.Resource.Id) == list2)
                    {
                        list.CheckState = CheckState.Checked;
                        break;
                    }
                }
            }

            Cursor.Current = Cursors.Default;

        }

        //public void CargarVisitas()
        //{
        //    DateTime desde = new DateTime(2011, 07, 01, 0, 0, 1);
        //    DateTime hasta = new DateTime(2011, 07, 30, 0, 0, 1);
        //    IList<clsVisita> visitas = clsCalendarios.ListarVisitas(desde, hasta, Convert.ToInt16(Entidades.Enums.Enums.VisitaEstado.Todas),
        //                                                            Base.Usuario.UsuarioConectado.Usuario.Id, -1);

        //    schedulerStorage1.Appointments.Clear();
        //    schedulerStorage1.RefreshData();
        //    schedulerStorage1.Appointments.DataSource = visitas;

        //    MapearCalendario();

            
        //}

        private void CargarAsistentes()
        {
            IList<Entidades.Usuarios.clsUsuario> usuarios = null;
            Entidades.GlobalObject.ResultadoTransaccion res =             
                LogicaNegocios.Usuarios.clsUsuarios.ListarUsuarios(Entidades.Enums.Enums.Estado.Habilitado,
                                                                   Entidades.Enums.Enums.CargosUsuarios.Todos);
            if(res.Estado == Entidades.Enums.Enums.EstadoTransaccion.Aceptada)
            {
                usuarios = (IList<Entidades.Usuarios.clsUsuario>)res.ObjetoTransaccion;
            }

            ResourceCollection collection = schedulerStorage1.Resources.Items;

            foreach (var usuario in usuarios)
            {
                collection.Add(new Resource(usuario.Id, usuario.NombreCompleto));                
            }
        }

        private void MapearAsistentesVisita(bool formload)
        {
            AppointmentCollection appointments = schedulerStorage1.Appointments.Items;
            Int64 IdVisita = 0;

            
            if(formload)
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

                        if(visita == null) break;
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
            myForm.TipoCalendario = Entidades.Enums.Enums.TipoCalendario.CalendarioCompartido;
            e.DialogResult = myForm.ShowDialog();

            schedulerControl1.Refresh();
            e.Handled = true;
        }

        private void MenuCalendario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.popupControlContainer1.Visible = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.popupControlContainer1.Visible = false;
        }

        private void schedulerControl1_PreparePopupMenu(object sender, PreparePopupMenuEventArgs e)
        {
            if (e.Menu.Id == SchedulerMenuItemId.DefaultMenu)
            {                
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewAllDayEvent);


                //Image image = Image.FromFile("AgendarActividad.png");                
                //e.Menu.Items.Add(new DXMenuItem("Nueva Reunion Interna", new EventHandler(NuevaReunionInterna_Click),image));
            }
        }

        //protected void NuevaReunionInterna_Click(object sender, EventArgs e)
        //{
        //    var a = 0;
        //}

        private void frmCalendarioCompartido_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void schedulerStorage1_AppointmentInserting(object sender, PersistentObjectCancelEventArgs e)
        {
            var a = 0;
        }

        private void schedulerStorage1_AppointmentDeleting(object sender, PersistentObjectCancelEventArgs e)
        {
            Appointment app = (Appointment)e.Object;

            clsVisita visita = LogicaNegocios.Calendarios.clsCalendarios.ObtenerVisitaPorId(Convert.ToInt64(app.CustomFields["IdVisita"]));

            if (visita == null) return;

            if(visita.UsuarioOrganizador.Id != Base.Usuario.UsuarioConectado.Usuario.Id && 
               visita.Vendedor.Id != Base.Usuario.UsuarioConectado.Usuario.Id )
            {
                MessageBox.Show("Solo el Organizador o Vendedor pueden eliminar esta visita.", "Calendario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }


            if (visita.EstadoBD == Entidades.Enums.Enums.VisitaEstado.Realizada_Con_Informe || visita.EstadoBD == Entidades.Enums.Enums.VisitaEstado.Realizada_Informe_Pendiente)
            {
                MessageBox.Show("La visita esta marcada como realizada, no es posible eliminarla", "Calendario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }

            if (visita.EstadoBD == Entidades.Enums.Enums.VisitaEstado.No_Realizada)
            {
                MessageBox.Show("La Visita no fue realizada y se encuentra bloqueada, no es posible eliminarla", "Calendario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }

            DialogResult resdialogo = MessageBox.Show("¿Está seguro de eliminar la Visita", "Calendario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resdialogo == DialogResult.Yes)
            {
                ResultadoTransaccion resultado = LogicaNegocios.Calendarios.clsCalendarios.EliminarVisita(visita);

                if (resultado.Estado == Entidades.Enums.Enums.EstadoTransaccion.Rechazada)
                {
                    MessageBox.Show(resultado.Descripcion, "Calendario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }

                // LoadDataCalendar();

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
                    visita.Vendedor.Id != Base.Usuario.UsuarioConectado.Usuario.Id )
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
            //Utils.EnvioEmail.ModificarVisitaOutlook(visita, e.SourceAppointment.Start, e.SourceAppointment.End);            
        }                                
    }
}
