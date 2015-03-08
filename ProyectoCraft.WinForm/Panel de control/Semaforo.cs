using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraGauges.Win;
using DevExpress.XtraGauges.Win.Base;
using DevExpress.XtraGauges.Win.Gauges.State;
using ProyectoCraft.LogicaNegocios.PanelDeControl;

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