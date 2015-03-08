using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraGauges.Core.Drawing;
using DevExpress.XtraGauges.Core.Model;
using DevExpress.XtraGauges.Win;
using DevExpress.XtraGauges.Win.Gauges.Digital;
using ProyectoCraft.LogicaNegocios.PanelDeControl;

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