using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.XtraScheduler.Exchange;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Outlook;


namespace ProyectoCraft.WinForm.Calendarios
{
    public partial class MiCalendario : Form
    {
        public MiCalendario():base()
        {
            InitializeComponent();
        }
        public static string[] Users = new string[] { "Usuario 1", "Usuario 2", "Usuario 3", "Usuario 4",
                                                        "Usuario 5", "Usuario 6", "Usuario 7" };



        private static MiCalendario _form = null;
        public static MiCalendario Instancia
        {
            get
            {
                if (_form == null)
                    _form = new MiCalendario();

                return _form;
            }
            set
            {
                _form = value;
            }
        }
        
        public void LoadCalendar(string calendario)
        {
            FillCalendarNamesCombo();
            //LeerCalendario(calendario);
        }


        private void FillCalendarNamesCombo()
        {
            //cbCalendarFolderPaths.Properties.BeginUpdate();
            //try
            //{
            //    cbCalendarFolderPaths.Properties.Items.Clear();
            //    cbCalendarFolderPaths.Properties.Items.AddRange(OutlookCalendarPaths);
            //}
            //finally
            //{
            //    cbCalendarFolderPaths.Properties.EndUpdate();
            //    //cbCalendarFolderPaths.SelectedIndex = 0;
            //}
        }

        static string[] outlookCalendarPaths = null;
        public string[] OutlookCalendarPaths
        {
            get
            {
                if (outlookCalendarPaths != null)
                    return outlookCalendarPaths;

                try
                {
                    outlookCalendarPaths = OutlookExchangeHelper.GetOutlookCalendarPaths();
                    //var folders = OutlookExchangeHelper.GetOutlookCalendarFolders();
                    //var folders2 = OutlookExchangeHelper.GetOutlookCalendarNames();
                    
                }
                catch
                {
                    //ReportOutlookError("get the list of available calendars from Microsoft Outlook");
                    outlookCalendarPaths = new string[0];
                }
                return outlookCalendarPaths;
            }
        }


        void LeerCalendario(string calendarioname)
        {
            //string CalendarName = "\\\\Buzón: Bravo Gabriel (UGAS GROUP)\\Calendario";
            //string CalendarName = "\\\\Carpetas personales\\Calendario";

           string CalendarName = calendarioname;

            

            AppointmentImporter importer = schedulerStorage.CreateOutlookImporter();
            ((ISupportCalendarFolders)importer).CalendarFolderName = CalendarName;

            importer.AppointmentImporting += new AppointmentImportingEventHandler(importer_AppointmentImporting);
            importer.AppointmentImported += new AppointmentImportedEventHandler(importer_AppointmentImported);

            Cursor oldCur = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;            
            try
            {
                importer.Import(System.IO.Stream.Null);
            }
            finally
            {                
                Cursor.Current = oldCur;
            }


        }

        void importer_AppointmentImporting(object sender, AppointmentImportingEventArgs e)
        {
            OutlookAppointmentImportingEventArgs args = (OutlookAppointmentImportingEventArgs)e;         
        }

        void importer_AppointmentImported(object sender, AppointmentImportedEventArgs e)
        {            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            schedulerControl1.Storage.Appointments.Clear();
            //LeerCalendario(cbCalendarFolderPaths.Text);
        }

        private void schedulerStorage_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            //AppointmentImportSynchronizer synchronizer = schedulerStorage.CreateOutlookImportSynchronizer();
            AppointmentExportSynchronizer synchronizerExport = schedulerStorage.CreateOutlookExportSynchronizer();

            //((ISupportCalendarFolders)synchronizerExport).CalendarFolderName = cbCalendarFolderPaths.Text;
            synchronizerExport.ForeignIdFieldName = "EntryID";
            synchronizerExport.Synchronize();



            //foreach (Appointment apt in e.Objects)
            //{
            //    var a = apt.StatusId;
            //    var b = apt.LabelId;
            //    var c = apt.ResourceId;
            //    var d = apt.ResourceIds;

            //    XPBaseObject o = apt.GetSourceObject(schedulerStorage) as XPBaseObject;
            //    if (o != null)
            //        o.Save();
            //}
        }

        private void schedulerStorage_AppointmentsDeleted(object sender, PersistentObjectsEventArgs e)
        {
            //AppointmentImportSynchronizer synchronizer = schedulerStorage.CreateOutlookImportSynchronizer();
            AppointmentExportSynchronizer synchronizerExport = schedulerStorage.CreateOutlookExportSynchronizer();

            //((ISupportCalendarFolders)synchronizerExport).CalendarFolderName = cbCalendarFolderPaths.Text;
            synchronizerExport.ForeignIdFieldName = "EntryID";
            synchronizerExport.Synchronize();

        }

        private void schedulerStorage_AppointmentsInserted(object sender, PersistentObjectsEventArgs e)
        {
            AppointmentExportSynchronizer synchronizerExport = schedulerStorage.CreateOutlookExportSynchronizer();

            //((ISupportCalendarFolders)synchronizerExport).CalendarFolderName = cbCalendarFolderPaths.Text;
            synchronizerExport.ForeignIdFieldName = "EntryID";
            synchronizerExport.Synchronize();

        }

        private void MiCalendario_Load_1(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            //LoadResources();
            // string[] a =  OutlookCalendarPaths;
            //LeerCalendario("\\\\Carpetas personales\\Calendario");

            //FoldersOutlook form = new FoldersOutlook();
            //form.ShowDialog();

            //FillCalendarNamesCombo();
        }

        void LoadResources()
        {
            SchedulerStorage storage = this.schedulerStorage; 
            ResourceCollection resources = storage.Resources.Items;
            storage.BeginUpdate();
            try
            {
                int cnt = Math.Min(int.MaxValue, Users.Length);
                for (int i = 1; i <= cnt; i++)
                    resources.Add(new Resource(i, Users[i - 1]));
            }
            finally
            {
                storage.EndUpdate();
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Instancia = null;
            this.Close();
        }

   

        
    }
}
