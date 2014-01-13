using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ProyectoCraft.LogicaNegocios.PanelDeControl;

namespace SCCMultimodal.Panel_de_control {
    public partial class formDetailPanelDeControl : Form {
        private static formDetailPanelDeControl _form = null;
        public String query { set; get; }

        public formDetailPanelDeControl() {
            InitializeComponent();
        }

        public static formDetailPanelDeControl Instancia {
            get {
                if (_form == null)
                    _form = new formDetailPanelDeControl();

                return _form;
            }
            set {
                _form = value;
            }
        }

        private void formDetailPanelDeControl_Load(object sender, EventArgs e) {
            var resultado = ClsPanelDeControl.ExecuteGenericqueryDataset(query);

            var colorsGreen = new List<int>();
            var colorsRed = new List<int>();
            var dt = resultado.ObjetoTransaccion as DataSet;

            var i = 0;
            foreach (DataColumn column in dt.Tables[0].Columns) {
                if (column.ColumnName.Trim().ToUpper().Contains("_GREEN")) {
                    colorsGreen.Add(i);
                    column.ColumnName = column.ColumnName.Replace("_GREEN", "");
                    column.ColumnName = column.ColumnName.Replace("_green", "");
                }
                if (column.ColumnName.Trim().ToUpper().Contains("_RED")) {
                    colorsRed.Add(i);
                    column.ColumnName = column.ColumnName.Replace("_RED", "");
                    column.ColumnName = column.ColumnName.Replace("_red", "");
                }
                i++;
            }

            gridControl1.DataSource = dt.Tables[0];

            foreach (var i1 in colorsGreen) {
                gridView1.Columns[i1].AppearanceCell.BackColor = System.Drawing.Color.Green;
                gridView1.Columns[i1].AppearanceCell.ForeColor= System.Drawing.Color.White;
            }

            foreach (var i1 in colorsRed) {
                gridView1.Columns[i1].AppearanceCell.BackColor = System.Drawing.Color.Red;
                gridView1.Columns[i1].AppearanceCell.ForeColor = System.Drawing.Color.White;
            }
        }

        private void formDetailPanelDeControl_closed(object sender, FormClosedEventArgs e) {
            Instancia = null;
        }
    }
}
