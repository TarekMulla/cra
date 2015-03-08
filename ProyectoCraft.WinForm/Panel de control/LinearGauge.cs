using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraGauges.Core.Drawing;
using DevExpress.XtraGauges.Core.Model;
using DevExpress.XtraGauges.Win;
using ProyectoCraft.LogicaNegocios.PanelDeControl;

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