using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;


namespace ProyectoCraft.WinForm.Ventas.Actividades.Visita
{
    public partial class FrmNuevaVisita : Form
    {
        public FrmNuevaVisita():base()
        {
            InitializeComponent();
        }


        private  SchedulerControl _controlparam;
        public  SchedulerControl ControlParam
        {
            get { return _controlparam; }
            set { _controlparam = value; }
        }

        private  Appointment _appparam;
        public  Appointment AppointmentParam
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

        
        private void FrmNuevaVisita_Load(object sender, EventArgs e)
        {
            LimpiarForm();
            CargarInformacionAppointment(AppointmentParam);
        }

        private void LimpiarForm()
        {
            txtAsunto.Text = "";
            txtUbicacion.Text = "";
            txtDescripcion.Text = "";
        }

        private void CargarInformacionAppointment(Appointment app)
        {            
            txtAsunto.Text = app.Subject;
            txtUbicacion.Text = app.Location;
            txtFechaComienzo.Text = app.Start.ToShortDateString();
            txtHoraComienzo.Time = app.Start;
            txtFechaTermino.Text = app.End.ToShortDateString();
            txtHoraTermino.Time = app.End;
            txtDescripcion.Text = app.Description;
        }

        private void FrmNuevaVisita_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
        }

        private void MenuGuardar_Click(object sender, EventArgs e)
        {
            this.AppointmentParam.Subject = this.txtAsunto.Text;
            this.AppointmentParam.Location = this.txtUbicacion.Text;
            this.AppointmentParam.Description = this.txtDescripcion.Text;

            if(ControlParam.Storage.Appointments.IsNewAppointment(this.AppointmentParam))
                this.ControlParam.Storage.Appointments.Add(this.AppointmentParam);

            this.Close();
        }

        
    }
}
