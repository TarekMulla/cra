using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using SCCMultimodal.Panel_de_control;

public class SemaforoV2 : MyControl {
    private SemaforoV2Dessigner _control;

    public SemaforoV2(XmlDocument xmlDocument, Point location, Size size) {
        XmlDocument = xmlDocument;
        Location = location;
        Size = size;
        _control = new SemaforoV2Dessigner { Location = Location };
    }

    #region Overrides of MyControl
    public override void LoadData() {
        Title = XmlDocument.SelectSingleNode("control").Attributes["title"].Value;
        Datasource = XmlDocument.SelectSingleNode("control/datasource").InnerText;
        GenereteDetail = XmlDocument.SelectSingleNode("control/detail") != null;
        if (GenereteDetail)
            DatasourceDetail = XmlDocument.SelectSingleNode("control/detail/datasourse").InnerText;
    }
    public override void SetDatasource() {
      
    }

    public override Control Generete(){
        _control = new SemaforoV2Dessigner { Location = Location };
        _control.XmlDocument = XmlDocument;
        _control.Generate();
        Control = _control; //setiamos la propiedad que lee el panel de control
        return _control;

    }
    #endregion
}