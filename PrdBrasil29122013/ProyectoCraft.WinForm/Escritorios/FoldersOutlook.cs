using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler.Outlook;

namespace ProyectoCraft.WinForm.Escritorios
{
    public partial class FoldersOutlook : Form
    {
        public FoldersOutlook()
        {
            InitializeComponent();
        }

        public string CalendarName { get { return this.cbCalendarFolderPaths.Text; } }


        private void FoldersOutlook_Load(object sender, EventArgs e)
        {
            FillCalendarNamesCombo();
        }

        private void FillCalendarNamesCombo()
        {
            cbCalendarFolderPaths.Properties.BeginUpdate();
            try
            {
                cbCalendarFolderPaths.Properties.Items.Clear();
                cbCalendarFolderPaths.Properties.Items.AddRange(OutlookCalendarPaths);
            }
            finally
            {
                cbCalendarFolderPaths.Properties.EndUpdate();
                //cbCalendarFolderPaths.SelectedIndex = 0;
            }
        }

        static string[] outlookCalendarPaths = null;
        public static string[] OutlookCalendarPaths
        {
            get
            {
                if (outlookCalendarPaths != null)
                    return outlookCalendarPaths;

                try
                {
                    outlookCalendarPaths = OutlookExchangeHelper.GetOutlookCalendarPaths();
                }
                catch
                {
                    //ReportOutlookError("get the list of available calendars from Microsoft Outlook");
                    outlookCalendarPaths = new string[0];
                }
                return outlookCalendarPaths;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //MiCalendario forma = new MiCalendario();
            //forma.LoadCalendar(this.cbCalendarFolderPaths.Text);
            //this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
