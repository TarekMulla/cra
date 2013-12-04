using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Paperless;
using ProyectoCraft.LogicaNegocios;

namespace ProyectoCraft.WinForm.Paperless.GestionAsignacion
{
    public partial class frmGestionAsignaciones : Form
    {
        private IList<PaperlessTipoCarga> Cargas { get; set; }
        private IList<PaperlessTipoCarga> CargasDesclarga { get; set; }

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

            ddlEstadoPaperless.Properties.Items.Add(Enums.EstadoPaperless.Nuevo);
            ddlEstadoPaperless.Properties.Items.Add(Enums.EstadoPaperless.EnAsignacion);
            ddlEstadoPaperless.Properties.Items.Add(Enums.EstadoPaperless.AsignadoUsuario1);
            ddlEstadoPaperless.Properties.Items.Add(Enums.EstadoPaperless.AceptadoUsuario1);
            ddlEstadoPaperless.Properties.Items.Add(Enums.EstadoPaperless.EnProcesoUsuario1);
            ddlEstadoPaperless.Properties.Items.Add(Enums.EstadoPaperless.EnviadoUsuario2);
            ddlEstadoPaperless.Properties.Items.Add(Enums.EstadoPaperless.EnProcesoUsuario2);
            ddlEstadoPaperless.Properties.Items.Add(Enums.EstadoPaperless.ProcesoTerminado);
            ddlEstadoPaperless.Properties.Items.Add(Enums.EstadoPaperless.RechazadaUsuario1);
                       
            //Cargas = LogicaNegocios.Paperless.Paperless.ListarTipoCarga(Enums.Estado.Habilitado);
            //foreach (var c in Cargas)
            //{
            //    ddlTipoCarga.Properties.Items.Add(c.Nombre);
            //}
           
            //ddlTipoCarga.Properties.Items.Add("FCL");
            //ddlTipoCarga.Properties.Items.Add("FAK");
            //ddlTipoCarga.Properties.Items.Add("LCL");

            DdlEmpresa.Properties.Items.Add("Craft");
            DdlEmpresa.Properties.Items.Add("Contact");
            DdlEmpresa.Properties.Items.Add("Slotlog");
            DdlEmpresa.Properties.Items.Add("Neutral");

            CargaProductos();        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
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
            //IList<Entidades.Paperless.PaperlessFlujo> asignaciones =
            //    LogicaNegocios.Paperless.Paperless.ConsultarGestionPaperless(nummaster, numconsolidado, DateTime.Now.AddDays(-90),//desde,
            //                                                                     DateTime.Now,
            //                                                                 usuario1, usuario2, nave
            //                                                                 , desdeEmbarcadores, hastaEmbarcadores, desdeNavieras, hastaNavieras);

            //grdAsignaciones.DataSource = asignaciones;
            //grdAsignaciones.RefreshDataSource();

            DataTable resUsuario2 = LogicaNegocios.Paperless.Paperless.ObtenerCantidadAsignacionesGraficoGestionPaperless(
               DateTime.Now.AddDays(-90), DateTime.Now, ddlAgrupadoPor.Text,ddlTipoCarga.SelectedIndex.ToString(), "8", "");
            Chartusuario2.Series.Clear();
            Chartusuario2.SeriesDataMember = "Estado";
            Chartusuario2.SeriesTemplate.ArgumentDataMember = "Vendedor";
            Chartusuario2.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Value" });
            Chartusuario2.DataSource = (DataTable)resUsuario2;
        }
        private void CargaProductos()
        {
            bool cargofcl = false;
            Cargas = LogicaNegocios.Paperless.Paperless.ListarTipoCarga(Enums.Estado.Habilitado);
            CargasDesclarga = LogicaNegocios.Paperless.Paperless.ListarTipoCargaDescripcionLarga(Enums.Estado.Habilitado);

            ComboBoxItemCollection coll = ddlTipoCarga.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in Cargas)
            {
                if (cargofcl.Equals(false))
                {
                    if (list.Nombre.Equals("FCL"))
                        cargofcl = true;
                    coll.Add(list);
                }
                else if (!list.Nombre.Equals("FCL"))
                    coll.Add(list);
            }
            ddlTipoCarga.SelectedIndex = 0;

            ComboBoxItemCollection collTipoDescLarga = ddlTipoCargaDescLarga.Properties.Items;
            collTipoDescLarga.Add(Utils.Utils.ObtenerPrimerItem());
            if (CargasDesclarga != null)
                foreach (var list in CargasDesclarga)
                {
                    if (list.EsFCL)
                    {
                        list.Nombre = list.DescripcionLarga;
                        collTipoDescLarga.Add(list);
                    }

                }
            ddlTipoCargaDescLarga.SelectedIndex = 0;
        }

        private void ddlTipoCarga_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTipoCargaDescLarga.Visible = ddlTipoCarga.SelectedItem.ToString().Equals("FCL");
        }

        private void frmGestionAsignaciones_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;
            Close();
        }
    }
}