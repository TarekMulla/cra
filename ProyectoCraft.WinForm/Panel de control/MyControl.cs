using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

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