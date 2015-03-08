using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using ProyectoCraft.LogicaNegocios.PanelDeControl;
using ProyectoCraft.WinForm;


namespace SCCMultimodal.Panel_de_control {
    public partial class SemaforoV2Dessigner : UserControl {

        public SemaforoV2Dessigner() {
            InitializeComponent();
        }

        public String Title {
            set { TitleLbl.Text = value; }
            get { return TitleLbl.Text; }
        }

        public Boolean MostrarRojo {
            set {
                rojo.Visible = value;
                if (value) {
                    rojo.DoubleClick += delegate{
                        var form = formDetailPanelDeControl.Instancia;
                        form.WindowState = FormWindowState.Normal;
                        form.MdiParent = MDICraft.Instancia;
                        form.query = XmlDocument.SelectSingleNode("control/details/red").InnerText;
                        form.Show();
                    };
                    var toolTip1 = new ToolTip();
                    toolTip1.SetToolTip(rojo, "Presione doble click para ver información detallada");
                }
            }
            get { return rojo.Visible; }

        }


        public Boolean MostrarNaranjo {
            set {
                naranjo.Visible = value;
                if (value) {
                    naranjo.DoubleClick += delegate {
                        var form = formDetailPanelDeControl.Instancia;
                        form.WindowState = FormWindowState.Normal;
                        form.MdiParent = MDICraft.Instancia;
                        form.query = XmlDocument.SelectSingleNode("control/details/orange").InnerText;
                        form.Show();
                    };
                    var toolTip1 = new ToolTip();
                    toolTip1.SetToolTip(naranjo, "Presione doble click para ver información detallada");
                }
            }
            get { return naranjo.Visible; }

        }
        public Boolean MostrarVerde {
            set {
                verde.Visible = value;
                if (value) {
                    verde.DoubleClick += delegate {
                        var form = formDetailPanelDeControl.Instancia;
                        form.WindowState = FormWindowState.Normal;
                        form.MdiParent = MDICraft.Instancia;
                        form.query = XmlDocument.SelectSingleNode("control/details/green").InnerText;
                        form.Show();
                    };
                    var toolTip1 = new ToolTip();
                    toolTip1.SetToolTip(verde, "Presione doble click para ver información detallada");
                }
            }
            get { return verde.Visible; }
        }

        public XmlDocument XmlDocument { get; set; }

        public void Generate() {
            var _ht = GenerateData();
            var _control = this;
            TitleLbl.Text = XmlDocument.SelectSingleNode("control").Attributes["title"].Value;
            _control.MostrarRojo = _control.MostrarNaranjo = _control.MostrarVerde = false;

            if (_ht.Contains("RED") && _ht["RED"].ToString() != "0")
                _control.MostrarRojo = true;
            if (_ht.Contains("ORANGE") && _ht["ORANGE"].ToString() != "0")
                _control.MostrarNaranjo = true;
            if (_ht.Contains("GREEN") && _ht["GREEN"].ToString() != "0")
                _control.MostrarVerde = true;
        }

        private Hashtable GenerateData() {
            var resultado = ClsPanelDeControl.ExecuteGenericquery(XmlDocument.SelectSingleNode("control/datasource").InnerText);
            var Datareader = resultado.ObjetoTransaccion as IDataReader;
            var _ht = new Hashtable();
            if (Datareader != null) {
                while (Datareader.Read()) {
                    _ht.Add(Datareader["color"].ToString(), Datareader["cantidad"].ToString());
                }
            }
            return _ht;
        }

        private void AddDobleCick(Control control, string datasourse) {
            var form = formDetailPanelDeControl.Instancia;
            form.WindowState = FormWindowState.Normal;
            form.MdiParent = MDICraft.Instancia;
            form.query = "";

            form.Show();
        }

        private void showDetails(object sender, EventArgs eventArgs) {

        }
    }

}
