using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraCharts;
using DevExpress.XtraGauges.Win;
using ProyectoCraft.WinForm;
using Label = System.Windows.Forms.Label;

namespace SCCMultimodal.Panel_de_control {

    public class PanelDecontrol {
        public PanelDecontrol() {
            PanelContainers = new List<PanelContainer>();
        }
        public String Name { set; get; }
        public String Description { set; get; }
        public IList<PanelContainer> PanelContainers { set; get; }
        public string Path { get; set; }

        public void LoadControls(String panelName) {

            //Cargamos la configuracion
            var configuracion = ProyectoCraft.Base.Configuracion.Configuracion.Instance();
            var opcion = configuracion.GetValue("Semaforos_Brasil_Enabled"); //puede retornar un true, false o null

            var pathxml = "";

            Path = opcion.HasValue && opcion.Value.Equals(true) ? @"panel de control/Brasil" : @"panel de control/Chile";

            pathxml = System.IO.Path.Combine(Application.StartupPath, string.Format(
                                                 @Path + "/panel de control/{0}", panelName));

            var xmldoc = new XmlDocument();
            xmldoc.Load(pathxml);

            var panelNodes = xmldoc.SelectNodes("/panel/panel");
            foreach (XmlNode panelNode in panelNodes) {

                var size = new Size(Convert.ToInt16(panelNode.Attributes["width"].Value),
                                            Convert.ToInt16(panelNode.Attributes["heigth"].Value));
                var location = new Point(Convert.ToInt16(panelNode.Attributes["x"].Value),
                                         Convert.ToInt16(panelNode.Attributes["y"].Value));

                var panelContainer = new PanelContainer(panelNode.Attributes["title"].Value, location, size);

                var xmlnodes = panelNode.SelectNodes("control");
                foreach (XmlNode xmlnode in xmlnodes) {
                    if (!String.IsNullOrEmpty(xmlnode.InnerText.Trim())) {
                        MyControl myControl = null;
                        var xmldocControles = new XmlDocument();
                        xmldocControles.Load(System.IO.Path.Combine(Application.StartupPath, string.Format(
                            @Path + "/controles/{0}", xmlnode.InnerText.Trim())));
                        var TypeOfControl = xmldocControles.SelectSingleNode("/control").Attributes["type"].Value;
                        size = new Size(Convert.ToInt16(xmlnode.Attributes["width"].Value),
                                            Convert.ToInt16(xmlnode.Attributes["heigth"].Value));
                        location = new Point(Convert.ToInt16(xmlnode.Attributes["x"].Value),
                                                 Convert.ToInt16(xmlnode.Attributes["y"].Value));
                        switch (TypeOfControl.ToUpper()) {
                            case "DIGITALGAUGE":
                                myControl = new DigitalGauge(xmldocControles, location, size);
                                break;
                            case "LINEARGAUGE":
                                myControl = new LinearGauge(xmldocControles, location, size);
                                break;
                            case "SEMAFORO":
                                myControl = new Semaforo(xmldocControles, location, size);
                                break;
                            case "GRAFICOBARRA3D":
                                myControl = new GraficoBarra3D(xmldocControles, location, size);
                                break;
                            case "SEMAFORO_V2":
                                myControl = new SemaforoV2(xmldocControles, location, size);
                                break;
                        }
                        if (myControl != null)
                            panelContainer.Controles.Add(myControl);
                    }
                }
                PanelContainers.Add(panelContainer);
            }
        }
        public void Generate() {
            foreach (var panelContainer in PanelContainers) {
                //se carga la informacion de los archivos Xmls
                foreach (var myControl in panelContainer.Controles) {
                    myControl.LoadData();
                }

                //set generan los controls
                foreach (var myControl in panelContainer.Controles) {
                    myControl.Generete();
                }

                //se ejecutan los datasource
                foreach (var myControl in panelContainer.Controles) {
                    myControl.SetDatasource();
                }
            }
        }

        public void Dispose(Control mdiCraft) {
            foreach (var panelContainer in PanelContainers) {
                panelContainer.GroupBox.Parent = mdiCraft;
                mdiCraft.Controls.Add(panelContainer.GroupBox);
                foreach (var myControl in panelContainer.Controles) {
                    //myControl.Control.SendToBack();
                    myControl.Control.Parent = panelContainer.GroupBox;
                    panelContainer.GroupBox.Controls.Add(myControl.Control);
                    if (myControl.GenereteDetail) {
                        myControl.Control.DoubleClick += showDetails;
                        var toolTip1 = new ToolTip();
                        toolTip1.SetToolTip(myControl.Control, "Presione doble click para ver información detallada");
                    }
                }
            }
        }

        private void showDetails(object sender, EventArgs eventArgs) {
            var form = formDetailPanelDeControl.Instancia;
            form.WindowState = FormWindowState.Normal;
            form.MdiParent = MDICraft.Instancia;
            if (sender is GaugeControl)
                form.query = ((GaugeControl)sender).Text;
            if (sender is ChartControl)
                form.query = ((ChartControl)sender).Titles[1].Text;
            form.Show();
        }
    }
}

public class PanelContainer {
    public IList<MyControl> Controles { set; get; }
    public Panel GroupBox { set; get; }
    public String Title { set; get; }
    public Point Location { set; get; }
    public Size Size { set; get; }
    public PanelContainer(String title, Point location, Size size) {
        Title = title;
        Location = location;
        Size = size;
        GroupBox = new Panel();
        GroupBox.Size = size;
        GroupBox.Location = location;
        GroupBox.Text = title;
        GroupBox.BorderStyle = BorderStyle.FixedSingle;
        GroupBox.BackColor = SystemColors.ActiveCaption;
        var label = new Label {
            Text = title,
            Width = 400,
            Parent = GroupBox,
            Font =
                new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold,
                         GraphicsUnit.Point,
                         ((byte)(0)))
        };
        GroupBox.Controls.Add(label);

        Controles = new List<MyControl>();
    }
}