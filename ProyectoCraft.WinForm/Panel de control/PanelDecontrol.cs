using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraCharts;
using DevExpress.XtraGauges.Core.Drawing;
using DevExpress.XtraGauges.Core.Model;
using DevExpress.XtraGauges.Win;
using DevExpress.XtraGauges.Win.Base;
using DevExpress.XtraGauges.Win.Gauges.Digital;
using DevExpress.XtraGauges.Win.Gauges.State;
using ProyectoCraft.LogicaNegocios.PanelDeControl;
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
        public void LoadControls(String panelName) {
            var pathxml = Path.Combine(Application.StartupPath, string.Format(
                                                 @"panel de control/panel de control/{0}", panelName));
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
                        xmldocControles.Load(Path.Combine(Application.StartupPath, string.Format(
                            @"panel de control/controles/{0}", xmlnode.InnerText.Trim())));
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
        var label = new Label
        {
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

public abstract class MyControl {
    public string Name { set; get; }
    public string Title { set; get; }
    public Point Location { set; get; }
    public Size Size { set; get; }
    public XmlDocument XmlDocument { set; get; }
    public abstract void LoadData();
    public IDataReader Datareader { set; get; }
    public abstract Control Generete();
    public Control Control;
    public String Datasource { set; get; }
    public string DatasourceDetail { set; get; }
    public Boolean GenereteDetail { set; get; }

    public abstract void SetDatasource();
}

public class LinearGauge : MyControl {
    private float min = 0;
    private float max = 0;
    private float overmax = 0;
    private float value = 0;

    public LinearGauge(XmlDocument xmldocument, Point location, Size size) {
        XmlDocument = xmldocument;
        Location = location;
        Size = size;
    }

    public override void LoadData() {
        Title = XmlDocument.SelectSingleNode("control").Attributes["title"].Value;
        Datasource = XmlDocument.SelectSingleNode("control/datasource").InnerText;
        GenereteDetail = XmlDocument.SelectSingleNode("control/detail") != null;
        if (GenereteDetail)
            DatasourceDetail = XmlDocument.SelectSingleNode("control/detail/datasourse").InnerText;
    }

    public override Control Generete() {
        GaugeControl gc = new GaugeControl();

        gc.BackColor = Color.Transparent;

        var pathbaseControlXml = string.Format(
            @"panel de control/basecontrol/{0}",
            XmlDocument.SelectSingleNode("control").Attributes["baseControl"].Value);
        gc.RestoreLayoutFromXml(Path.Combine(Application.StartupPath, pathbaseControlXml));
        gc.Location = Location;
        gc.Size = Size;
        // Add the gauge control to the form.
        Control = gc;

        gc.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
        gc.Text = DatasourceDetail;
        return gc;
    }

    public override void SetDatasource() {
        var resultado = ClsPanelDeControl.ExecuteGenericquery(Datasource);
        Datareader = resultado.ObjetoTransaccion as IDataReader;
        if (Datareader != null) {

            while (Datareader.Read()) {
                if (!String.IsNullOrEmpty(Datareader["min"].ToString()))
                    min = Convert.ToSingle(Datareader["min"]);

                if (!String.IsNullOrEmpty(Datareader["max"].ToString()))
                    max = Convert.ToSingle(Datareader["max"]);

                if (!String.IsNullOrEmpty(Datareader["value"].ToString()))
                    value = Convert.ToSingle(Datareader["value"]);

                if (!String.IsNullOrEmpty(Datareader["overmax"].ToString()))
                    overmax = Convert.ToSingle(Datareader["overmax"]);
            }

            var gc = Control as GaugeControl;
            if (gc != null) {
                var foo = gc.Gauges[0] as DevExpress.XtraGauges.Win.Gauges.Linear.LinearGauge;
                if (foo != null) {
                    var scale = foo.Scales[0];
                    scale.MinValue = min;
                    scale.MaxValue = max + overmax;
                    scale.Value = value;
                    var color = Color.Black;
                    if (value >= max)
                        color = Color.Red;
                    if (value < max)
                        color = Color.Orange;
                    if (value < max / 2)
                        color = Color.Green;

                    foo.Levels[0].ShapeType = LevelShapeSetType.Style11;

                    StyleShader shader = new StyleShader();
                    shader.StyleColor1 = color;
                    shader.StyleColor2 = Color.Transparent;
                    foo.Levels[0].Shader = shader;
                }
            }
        }
    }
}

public class DigitalGauge : MyControl {
    private String Value { set; get; }

    public DigitalGauge(XmlDocument xmlDocument, Point location, Size size) {
        XmlDocument = xmlDocument;
        Location = location;
        Size = size;
    }

    public override void LoadData() {
        Title = XmlDocument.SelectSingleNode("control").Attributes["title"].Value;
        Datasource = XmlDocument.SelectSingleNode("control/datasource").InnerText;
    }

    public override Control Generete() {
        GaugeControl gc = new GaugeControl();
        gc.BackColor = Color.Transparent;
        gc.Size = Size;
        gc.Location = Location;
        var digitalGauge = gc.AddDigitalGauge();
        // The text to be displayed.
        digitalGauge.Text = "Gauge Control";
        // The number of digits.
        digitalGauge.DigitCount = 14;
        // Use 14 segment display mode.
        digitalGauge.DisplayMode = DigitalGaugeDisplayMode.FourteenSegment;
        // Add a background layer and set its painting style.
        DigitalBackgroundLayerComponent background2 = digitalGauge.AddBackgroundLayer();
        background2.ShapeType = DigitalBackgroundShapeSetType.Style2;
        // Set the color of digits.
        digitalGauge.AppearanceOn.ContentBrush = new SolidBrushObject(Color.Red);
        // Add the gauge control to the form.
        Control = gc;
        return gc;
    }

    public override void SetDatasource() {
        var resultado = ClsPanelDeControl.ExecuteGenericquery(Datasource);
        Datareader = resultado.ObjetoTransaccion as IDataReader;
        if (Datareader != null) {

            while (Datareader.Read()) {
                if (!String.IsNullOrEmpty(Datareader["value"].ToString()))
                    Value = Datareader["value"].ToString();

            }
            var gc = Control as GaugeControl;
            if (gc != null) {
                var foo = gc.Gauges[0] as DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge;
                if (foo != null) {
                    foo.Text = Value;
                    foo.DigitCount = foo.Text.Length;
                }
            }
        }
    }
}

public class Semaforo : MyControl {
    private LabelComponent _labelNumero;

    public Semaforo(XmlDocument xmlDocument, Point location, Size size) {
        XmlDocument = xmlDocument;
        Location = location;
        Size = size;
    }

    public override void LoadData() {
        Title = XmlDocument.SelectSingleNode("control").Attributes["title"].Value;
        Datasource = XmlDocument.SelectSingleNode("control/datasource").InnerText;
        GenereteDetail = XmlDocument.SelectSingleNode("control/detail") != null;
        if (GenereteDetail)
            DatasourceDetail = XmlDocument.SelectSingleNode("control/detail/datasourse").InnerText;
    }

    public override Control Generete() {
        GaugeControl gc = new GaugeControl();

        gc.BackColor = Color.Transparent;

        var pathbaseControlXml = string.Format(
            @"panel de control/basecontrol/{0}",
            XmlDocument.SelectSingleNode("control").Attributes["baseControl"].Value);
        gc.RestoreLayoutFromXml(Path.Combine(Application.StartupPath, pathbaseControlXml));
        gc.Location = Location;
        gc.Size = Size;
        gc.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
        gc.Text = DatasourceDetail;

        var stateIndicador = gc.Gauges[0] as StateIndicatorGauge;
        foreach (LabelComponent label in stateIndicador.Labels) {
            if (label.Name.Equals("LabelTitulo"))
                label.Text = "<b>" + Title + "</b>";
            if (label.Name.Equals("LabelNumero"))
                _labelNumero = label;
        }

        // Add the gauge control to the form.
        Control = gc;
        return gc;
    }

    public override void SetDatasource() {
        var cantidad = 0;
        var color = String.Empty;
        _labelNumero.Text = 24.ToString();

        var resultado = ClsPanelDeControl.ExecuteGenericquery(Datasource);
        Datareader = resultado.ObjetoTransaccion as IDataReader;
        if (Datareader != null) {

            while (Datareader.Read()) {
                if (!String.IsNullOrEmpty(Datareader["cantidad"].ToString()))
                    cantidad = Convert.ToInt16(Datareader["cantidad"].ToString());
                color = Datareader["color"].ToString();

            }
            var gc = Control as GaugeControl;
            if (gc != null) {
                var foo = gc.Gauges[0] as StateIndicatorGauge;
                if (foo != null) {
                    foo.BeginUpdate();
                    switch (color.Trim().ToUpper()) {
                        case "RED":
                            foo.Indicators[0].StateIndex = 1;
                            break;
                        case "ORANGE":
                            foo.Indicators[0].StateIndex = 2;
                            break;
                        case "GREEN":
                            foo.Indicators[0].StateIndex = 3;
                            break;
                        default:
                            foo.Indicators[0].StateIndex = 0;
                            break;
                    }
                    _labelNumero.Text = String.Format("<b>{0}</b>", cantidad);
                    foo.EndUpdate();
                }
            }
        }
    }

}

public class GraficoBarra3D : MyControl {
    public GraficoBarra3D(XmlDocument xmlDocument, Point location, Size size) {
        XmlDocument = xmlDocument;
        Location = location;
        Size = size;
    }

    public override void LoadData() {
        Title = XmlDocument.SelectSingleNode("control").Attributes["title"].Value;
        Datasource = XmlDocument.SelectSingleNode("control/datasource").InnerText;
        GenereteDetail = XmlDocument.SelectSingleNode("control/detail") != null;
        if (GenereteDetail)
            DatasourceDetail = XmlDocument.SelectSingleNode("control/detail/datasourse").InnerText;
    }

    public override Control Generete() {
        var grafico = new ChartControl();
        var pathbaseControlXml = string.Format(
       @"panel de control/basecontrol/{0}",
       XmlDocument.SelectSingleNode("control").Attributes["baseControl"].Value);
        grafico.LoadFromFile(Path.Combine(Application.StartupPath, pathbaseControlXml));

        grafico.Location = Location;
        grafico.Size = Size;
        //grafico.BackColor = Color.Transparent;

        grafico.Text = DatasourceDetail;
        var title = new ChartTitle {Text = this.Title};
        grafico.Titles.Add(title);
        title = new ChartTitle { Text = this.DatasourceDetail,Visible = false};
        grafico.Titles.Add(title);

        Control = grafico;
        return grafico;
    }

    public override void SetDatasource() {
        var c = this.Control as ChartControl;
        if (c == null)
            return;

        var resultado = ClsPanelDeControl.ExecuteGenericqueryDataset(Datasource);
        var ds = resultado.ObjetoTransaccion as DataSet;

        c.BorderOptions.Visible = true;

        // Specify data members to bind the chart's series template.

        c.SeriesDataMember = ds.Tables[0].Columns[0].ColumnName;
        c.SeriesTemplate.ArgumentDataMember = ds.Tables[0].Columns[1].ColumnName;
        c.SeriesTemplate.ValueDataMembers.AddRange(new string[] { ds.Tables[0].Columns[2].ColumnName });

      
        c.DataSource = ds.Tables[0];
    }
}