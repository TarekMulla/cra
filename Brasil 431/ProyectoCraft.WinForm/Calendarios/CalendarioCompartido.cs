using System;
using System.Collections.Generic;
//using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using ProyectoCraft.Entidades.Calendario;
using ProyectoCraft.Entidades.Enums;

namespace ProyectoCraft.WinForm.Calendarios
{
    public partial class CalendarioCompartido : Form
    {
        public CalendarioCompartido()
        {
            InitializeComponent();
        }

        public string[] Usuarios = new string[100];
                
        private static CalendarioCompartido _form = null;
        public static CalendarioCompartido Instancia
        {
            get
            {
                if (_form == null)
                    _form = new CalendarioCompartido();

                return _form;
            }
            set
            {
                _form = value;
            }
        }

        private void CalendarioCompartido_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            LoadResources();
            PrepareMeetings();

            this.schedulerControl1.Start = DateTime.Now;

            
        }

        void LoadResources()
        {
            IList<Entidades.Usuarios.clsUsuario> usuarios = null;
            Entidades.GlobalObject.ResultadoTransaccion res =
                LogicaNegocios.Usuarios.clsUsuarios.ListarUsuarios(Entidades.Enums.Enums.Estado.Habilitado,
                                                                   Entidades.Enums.Enums.CargosUsuarios.Todos);
            if (res.Estado == Entidades.Enums.Enums.EstadoTransaccion.Aceptada)
            {
                usuarios = (IList<Entidades.Usuarios.clsUsuario>)res.ObjetoTransaccion;
            }

            ResourceCollection collection = schedulerStorage.Resources.Items;

            foreach (var usuario in usuarios)
            {
                collection.Add(new Resource(usuario.Id, usuario.NombreCompleto));
            }



            //SchedulerStorage storage = this.schedulerStorage;
            //ResourceCollection resources = storage.Resources.Items;

            //IList<clsUsuario> usuarios = new List<clsUsuario>();

            //ResultadoTransaccion res = LogicaNegocios.Usuarios.clsUsuarios.ListarUsuarios(Enums.Estado.Todos,
            //                                                              Enums.CargosUsuarios.Todos);

            //if (res.Estado == Enums.EstadoTransaccion.Aceptada)
            //    usuarios = (IList<clsUsuario>) res.ObjetoTransaccion;

            //Int16 count = 0;
            //foreach (var user in usuarios)
            //{                                
            //    Usuarios.SetValue(user.NombreCompleto,count);
            //    count++;
            //}

            //storage.BeginUpdate();
            //try
            //{
            //    int cnt = Math.Min(int.MaxValue, Usuarios.Length);
            //    for (int i = 0; i < cnt; i++)
            //    {
            //        if(Usuarios[i] != null )
            //            resources.Add(new Resource(i, Usuarios[i]));
            //    }                    
            //}
            //finally
            //{
            //    storage.EndUpdate();
            //}

            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem list in resourcesCheckedListBoxControl1.Items)
            {
                list.CheckState = CheckState.Unchecked;
            }

        }

        void PrepareMeetings()
        {
            IList<clsVisita> visitas = LogicaNegocios.Calendarios.clsCalendarios.ListarVisitas(DateTime.Now,
                                                                                               DateTime.Now, -1, -1, -1);

            try
            {
                schedulerStorage.Appointments.Clear();
                schedulerStorage.RefreshData();

                schedulerStorage.Appointments.DataSource = visitas;
                MapearCalendario();
                
                //foreach (var visita in visitas)
                //{
                //    int[] asistentes = new int[50];
                //    int conteo = 0;
                //    asistentes = new int[visita.Asistentes.Count];

                //    Appointment apt = new Appointment(AppointmentType.Normal);
                    
                //    //apt.CustomFields["IdVisita"] = visita.Id.ToString();
                                          
                //    apt.Subject = visita.Asunto;
                //    apt.Description = visita.Descripcion;
                //    apt.Location = visita.Ubicacion;
                //    apt.Start = visita.FechaHoraComienzo;
                //    apt.End = visita.FechaHoraTermino;
                //    apt.LabelId = visita.EstadoVista;
                    
                //    apt.ResourceIds.Clear();
                //    foreach (var asisCraft in visita.AsistentesCraft)
                //    {
                //        apt.ResourceIds.Add(asisCraft.Usuario.Id);
                //    }
                //    apt.ResourceIds.Add(visita.UsuarioOrganizador.Id);

                //    schedulerStorage.Appointments.Add(apt);
                    

                //    //foreach (var asistente in visita.Asistentes)
                //    //{
                        


                //    //    //for (int i = 0; i <= Usuarios.Length - 1; i++)
                //    //    //{
                //    //    //    if (Usuarios[i] != null)
                //    //    //    {
                //    //    //        if (asistente.TipoAsistente == Enums.VisitaTipoAsistente.Usuario &&
                //    //    //            Usuarios[i].ToString() == asistente.Usuario.NombreCompleto)
                //    //    //        {
                //    //    //            resource = schedulerStorage.Resources[i];

                //    //    //            apt.ResourceIds.Add(resource.Id);

                //    //    //            asistentes.SetValue(i, conteo);
                //    //    //            break;
                //    //    //        }
                //    //    //    }
                //    //    //}
                //    //    //conteo++;
                //    //}                  
                             

                   
                //}
                

                
                //MapearCalendario();
            }
            catch (Exception ex)
            {
                
                Base.Log.Log.EscribirLog(ex.Message);
            }                       
        }

        private void MapearCalendario()
        {
            schedulerStorage.Appointments.Mappings.Subject = "Cliente"; //"Asunto";
            schedulerStorage.Appointments.Mappings.Location = "Ubicacion";
            schedulerStorage.Appointments.Mappings.Description = "Descripcion";
            schedulerStorage.Appointments.Mappings.Start = "FechaHoraComienzo";
            schedulerStorage.Appointments.Mappings.End = "FechaHoraTermino";
            schedulerStorage.Appointments.Mappings.Label = "EstadoVista";
            schedulerStorage.Appointments.Mappings.Status = "StatusUsuario";

            schedulerStorage.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping("IdVisita", "Id"));

            //AppointmentCustomFieldMapping custom = new AppointmentCustomFieldMapping("IdVisita", "Id", FieldValueType.String);
            //schedulerStorage.Appointments.CustomFieldMappings.Add(custom);



            schedulerControl1.GroupType = SchedulerGroupType.Resource;


            //schedulerStorage.Appointments.Mappings.Subject = "Asunto";
            //schedulerStorage.Appointments.Mappings.Location = "Ubicacion";
            //schedulerStorage.Appointments.Mappings.Description = "Descripcion";
            //schedulerStorage.Appointments.Mappings.Start = "FechaHoraComienzo";
            //schedulerStorage.Appointments.Mappings.End = "FechaHoraTermino";
            //schedulerStorage.Appointments.Mappings.Label = "EstadoVista";
            //schedulerStorage.Appointments.Mappings.ResourceId = "AsistentesCraft";
            ////schedulerStorage.Appointments.Mappings.Status = "StatusUsuario";

            
            ////schedulerStorage.Resources.Mappings.Caption = "Usuario.NombreCompleto";
            ////schedulerStorage.Resources.Mappings.Id = "Usuario.Id";

            //AppointmentCustomFieldMapping custom = new AppointmentCustomFieldMapping("IdVisita", "Id", FieldValueType.String);
            //schedulerStorage.Appointments.CustomFieldMappings.Add(custom);

            //schedulerControl.GroupType = SchedulerGroupType.Date;

        }
    
        public  void FillResources(SchedulerStorage storage, int count)
        {
            ResourceCollection resources = storage.Resources.Items;
            storage.BeginUpdate();
            try
            {
                int cnt = Math.Min(count,  Usuarios.Length);
                for (int i = 1; i <= cnt; i++)
                    resources.Add(new Resource(i, Usuarios[i - 1]));
            }
            finally
            {
                storage.EndUpdate();
            }
        }

        private void MenuCalendario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.popupControlContainer1.Visible = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.popupControlContainer1.Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }

        private void schedulerControl_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            Appointment app = e.Appointment;

            //if (app.Description == "") app.StatusId = 0;
            if (app.Description == "") app.CustomFields["IdVisita"] = "0";

            FrmNuevaVisita myForm = FrmNuevaVisita.Instancia;

            if (schedulerStorage.Appointments.IsNewAppointment(app))
                myForm.Accion = Enums.TipoAccionFormulario.Nuevo;
            else
                myForm.Accion = Enums.TipoAccionFormulario.Editar;


            myForm.ControlParam = (SchedulerControl)sender;
            myForm.AppointmentCalendario = app;

            //myForm.frmLoad();

            //if(!schedulerControl1.Storage.Appointments.IsNewAppointment(app))
            //myForm.CargarFormulario();

            e.DialogResult = myForm.ShowDialog();
            
            schedulerControl1.Refresh();
            e.Handled = true;
        }

        private void resourcesCheckedListBoxControl1_SelectedIndexChanged(object sender, EventArgs e) {
            var foo = "";
            foo = "hola";
        }

        private void resourcesCheckedListBoxControl1_SelectedValueChanged(object sender, EventArgs e) {
            var foo = "";
            foo = "hola";
        }

       
    
    }

    
}
