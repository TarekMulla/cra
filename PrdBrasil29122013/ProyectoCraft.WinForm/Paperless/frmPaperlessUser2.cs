using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using ProyectoCraft.WinForm.Controles;

namespace ProyectoCraft.WinForm.Paperless
{
    public partial class frmPaperlessUser2 : Form
    {
        public frmPaperlessUser2()
        {
            InitializeComponent();
        }

        

        private void frmPaperlessUser2_Load(object sender, EventArgs e)
        {
            ProyectoCraft.WinForm.Controles.EstadoPaperless control = new EstadoPaperless();
            panel1.Controls.Add(control);

            gridView2.CustomRowCellEditForEditing += new CustomRowCellEditEventHandler(MarcarPaso);

            CargarPasos();
            RegistrarExcepciones();
            Contactarembarcador();
            RecibirAperturaEmbarcador();
        }

        private void RecibirAperturaEmbarcador()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Embarcador"));
            dt.Columns.Add(new DataColumn("Recibido"));

            DataRow dr = dt.NewRow();
            dr["Embarcador"] = "Embarcador A";
            dr["Recibido"] = "true";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Embarcador"] = "Embarcador B";
            dr["Recibido"] = "false";
            dt.Rows.Add(dr);

            grdRecibirAperturaEmb.DataSource = dt;
        }

        private void Contactarembarcador()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Embarcador"));
            dt.Columns.Add(new DataColumn("Contactado"));
            
            DataRow dr = dt.NewRow();
            dr["Embarcador"] = "Embarcador A";
            dr["Contactado"] = "true";            
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Embarcador"] = "Embarcador B";
            dr["Contactado"] = "false";
            dt.Rows.Add(dr);

            grdContactarembarcador.DataSource = dt;
        }

        private void RegistrarExcepciones()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("HBL"));
            dt.Columns.Add(new DataColumn("Cliente"));
            dt.Columns.Add(new DataColumn("TipoCliente"));
            dt.Columns.Add(new DataColumn("Freehand"));
            dt.Columns.Add(new DataColumn("RecargoCollect"));
            dt.Columns.Add(new DataColumn("Sobrevalor"));
            dt.Columns.Add(new DataColumn("Aviso"));

            DataRow dr = dt.NewRow();
            dr["HBL"] = "11111";
            dr["Cliente"] = "Cliente A";
            dr["TipoCliente"] = "Embarcador";
            dr["Freehand"] = "false";
            dr["RecargoCollect"] = "false";
            dr["Sobrevalor"] = "false";
            dr["Aviso"] = "false";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["HBL"] = "2222";
            dr["Cliente"] = "Cliente B";
            dr["TipoCliente"] = "Directo";
            dr["Freehand"] = "false";
            dr["RecargoCollect"] = "false";
            dr["Sobrevalor"] = "false";
            dr["Aviso"] = "false";
            dt.Rows.Add(dr);



            grdExcepciones.DataSource = dt;
        }

        protected void MarcarPaso(object sender, CustomRowCellEditEventArgs e)
        {
            pnlExcepciones.Visible = false;
            pnlContactarembarcador.Visible = false;
            pnlRecibirAperturaEmb.Visible = false;
            //pnlEnviarAviso.Visible = false;

            //if(e.Column.FieldName == "Estado")
            //{
            if (e.RowHandle == 0)
            {
                pnlExcepciones.Visible = true;
            }
            if (e.RowHandle == 1)
            {
                pnlContactarembarcador.Visible = true;
            }
            if (e.RowHandle == 2)
            {
                pnlRecibirAperturaEmb.Visible = true;
            }
            if (e.RowHandle == 11)
            {
                //pnlEnviarAviso.Visible = true;
            }

            //}


        }

        private void CargarPasos()
        {
            IList<PasosPaperless> pasos = new List<PasosPaperless>();
            PasosPaperless paso;

            paso = new PasosPaperless("1", "Resolver Excepciones", false);
            pasos.Add(paso);
            paso = new PasosPaperless("2", "Contactar Embarcador", false);
            pasos.Add(paso);
            paso = new PasosPaperless("3", "Recibir Apertura Embarcadores", false);
            pasos.Add(paso);
            paso = new PasosPaperless("4", "Presentar Manifiesto", false);
            pasos.Add(paso);
            
            grdPasos.DataSource = pasos;

        }

        

    }
}
