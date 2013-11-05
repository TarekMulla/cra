using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProyectoCraft.LogicaNegocios;

namespace ProyectoCraft.WinForm.Paperless.GestionAsignacion
{
    public partial class frmGestionAsignaciones : Form
    {

        private static frmGestionAsignaciones _instancia = null;

        public static frmGestionAsignaciones Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmGestionAsignaciones();

                return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        public frmGestionAsignaciones()
        {
            InitializeComponent();
        }

        private void frmGestionAsignaciones_Load(object sender, EventArgs e)
        {
            ddlAgrupadoPor.Properties.Items.Add("Usuario1");
            ddlAgrupadoPor.Properties.Items.Add("Usuario2");           
            ddlEstadoPaperless.Properties.Items.Add("Nuevo");
            ddlEstadoPaperless.Properties.Items.Add("En Asignacion");
            ddlEstadoPaperless.Properties.Items.Add("Asignado Usuario 1ra Etapa");
            ddlEstadoPaperless.Properties.Items.Add("Aceptado Por Usuario 1ra Etapa");
            ddlEstadoPaperless.Properties.Items.Add("En Proceso Usuario 1ra Etapa");
            ddlEstadoPaperless.Properties.Items.Add("Enviado Usuario 2da Etapa");
            ddlEstadoPaperless.Properties.Items.Add("En Proceso Usuario 2da Etapa");
            ddlEstadoPaperless.Properties.Items.Add("Proceso Terminado");
            ddlEstadoPaperless.Properties.Items.Add("Rechazada Usuario 1ra Etapa");
            ddlTipoCarga.Properties.Items.Add("FCL");
            ddlTipoCarga.Properties.Items.Add("FAK");
            ddlTipoCarga.Properties.Items.Add("LCL");

            DataTable resUsuario2 = LogicaNegocios.Paperless.Paperless.ObtenerCantidadAsignacionesGrafico("Usuario2", DateTime.Now.AddDays(-30), DateTime.Now);
            Chartusuario2.Series.Clear();
            Chartusuario2.SeriesDataMember = "Estado";
            Chartusuario2.SeriesTemplate.ArgumentDataMember = "Vendedor";
            Chartusuario2.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Value" });
            Chartusuario2.DataSource = (DataTable)resUsuario2;


            string nummaster = "-1";
            string numconsolidado = "-1";
            DateTime desde = new DateTime(9999, 1, 1);
            DateTime hasta = new DateTime(9999, 1, 1);
            DateTime desdeNavieras = new DateTime(9999, 1, 1);
            DateTime hastaNavieras = new DateTime(9999, 1, 1);
            DateTime desdeEmbarcadores = new DateTime(9999, 1, 1);
            DateTime hastaEmbarcadores = new DateTime(9999, 1, 1);

            Int64 usuario1 = -1;
            Int64 usuario2 = -1;
            string nave = "";
            IList<Entidades.Paperless.PaperlessFlujo> asignaciones =
                LogicaNegocios.Paperless.Paperless.ConsultarGestionPaperless(nummaster, numconsolidado, DateTime.Now.AddDays(-90),//desde,
                                                                                 DateTime.Now,
                                                                             usuario1, usuario2, nave
                                                                             , desdeEmbarcadores, hastaEmbarcadores, desdeNavieras, hastaNavieras);

            //IList<Entidades.Paperless.PaperlessFlujo> asignaciones =
            //    LogicaNegocios.Paperless.Paperless.ConsultarGestionPaperless("",//nummaster,
            //                                                                 "",//numconsolidado,
            //                                                                 DateTime.Now.AddDays(-90),//desde,
            //                                                                 DateTime.Now,
            //                                                                 0,//usuario1,
            //                                                                 0,//usuario2, 
            //                                                                 "",//nave, 
            //                                                                 new DateTime(9999, 1, 1),//desdeEmbarcadores, 
            //                                                                 new DateTime(9999, 1, 1),//hastaEmbarcadores, 
            //                                                                 new DateTime(9999, 1, 1),//desdeNavieras, 
            //                                                                 new DateTime(9999, 1, 1)//hastaNavieras
            //                                                                 );


            grdAsignaciones.DataSource = asignaciones;
            grdAsignaciones.RefreshDataSource();
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}