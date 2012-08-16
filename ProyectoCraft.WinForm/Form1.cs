using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.XtraGauges.Win.Gauges.State;

namespace SCCMultimodal {
    public partial class Form1 : Form {
        private static Form1 _form = null;
        public Form1() {
            InitializeComponent();
        }

        public static Form1 Instancia {
            get {
                if (_form == null)
                    _form = new Form1();

                return _form;
            }
            set {
                _form = value;
            }
        }

        private void Form1_Load(object sender, EventArgs e) {


            // Specify data members to bind the chart's series template.
            chartControl1.SeriesDataMember = "Month";
            chartControl1.SeriesTemplate.ArgumentDataMember = "Section";
            chartControl1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Value" });

            // Specify the template's series view.
            //chartControl1.SeriesTemplate.View = new StackedBarSeriesView();

            // Specify the template's name prefix.
            chartControl1.SeriesNameTemplate.BeginText = "Month: ";

            // Dock the chart into its parent, and add it to the current form.
            chartControl1.Dock = DockStyle.Fill;

            // Create an empty table.
            DataTable table = new DataTable("Table1");

            // Add three columns to the table.
            table.Columns.Add("Month", typeof(String));
            table.Columns.Add("Section", typeof(String));
            table.Columns.Add("Value", typeof(Int32));

            // Add data rows to the table.
            table.Rows.Add(new object[] { "Jan", "Section1", 10 });
            table.Rows.Add(new object[] { "Jan", "Section2", 20 });
            table.Rows.Add(new object[] { "Feb", "Section1", 20 });
            table.Rows.Add(new object[] { "Feb", "Section2", 30 });
            table.Rows.Add(new object[] { "March", "Section1", 15 });
            table.Rows.Add(new object[] { "March", "Section2", 25 });

            chartControl1.DataSource = table;

        }

        private void gaugeControl2_Click(object sender, EventArgs e) {
            MessageBox.Show("hola");
        }
    }
}
