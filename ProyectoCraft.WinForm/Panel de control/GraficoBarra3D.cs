using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraCharts;
using ProyectoCraft.LogicaNegocios.PanelDeControl;

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
        var title = new ChartTitle { Text = this.Title };
        grafico.Titles.Add(title);
        title = new ChartTitle { Text = this.DatasourceDetail, Visible = false };
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
