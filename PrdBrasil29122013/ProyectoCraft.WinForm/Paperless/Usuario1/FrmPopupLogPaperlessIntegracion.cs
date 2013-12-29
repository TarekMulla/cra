using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProyectoCraft.Entidades.Integracion;

namespace SCCMultimodal.Paperless.Usuario1
{
    public partial class FrmPopupLogPaperlessIntegracion : DevExpress.XtraEditors.XtraForm
    {
        public IList<PaperlessIntegracionNetShipLog>  ListaLogIntegracionNetShip;
        private static FrmPopupLogPaperlessIntegracion _instancia;
        public static FrmPopupLogPaperlessIntegracion Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new FrmPopupLogPaperlessIntegracion();

                return _instancia;
            }
            set { _instancia = value; }
        }
        public FrmPopupLogPaperlessIntegracion(IList<PaperlessIntegracionNetShipLog> list)
        {
            ListaLogIntegracionNetShip = list;
            InitializeComponent();
            Load();

        }
        public FrmPopupLogPaperlessIntegracion()
        {
            InitializeComponent();
            Load();
            
        }
        private  void Load()
        {
            GrdLog.DataSource = ListaLogIntegracionNetShip;
            GrdLog.RefreshDataSource();
            
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            FrmPopupLogPaperlessIntegracion form = Instancia;        
            Instancia = null;
            Close();
        }
    }
}