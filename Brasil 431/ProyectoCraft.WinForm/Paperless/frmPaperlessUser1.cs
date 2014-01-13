using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using ProyectoCraft.WinForm.Controles;
using System.Data;

namespace ProyectoCraft.WinForm.Paperless
{
    public partial class frmPaperlessUser1 : Form
    {
        public frmPaperlessUser1()
        {
            InitializeComponent();
        }

        private void frmPaperlessUser1_Load(object sender, EventArgs e)
        {
            ProyectoCraft.WinForm.Controles.EstadoPaperless control = new EstadoPaperless();
            panel1.Controls.Add(control);

            CargarPasos();

            gridView4.CustomRowCellEditForEditing += new CustomRowCellEditEventHandler(MarcarPaso);

            IngresarHousesBL();
            MarcarHouseRuteado();
            RegistrarExcepciones();
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

        private void MarcarHouseRuteado()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Num"));
            dt.Columns.Add(new DataColumn("House"));
            dt.Columns.Add(new DataColumn("Ruteado"));

            DataRow dr = dt.NewRow();
            dr["Num"] = "1";
            dr["House"] = "111111";
            dr["Ruteado"] = "false";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Num"] = "2";
            dr["House"] = "22222";
            dr["Ruteado"] = "false";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Num"] = "3";
            dr["House"] = "333333";
            dr["Ruteado"] = "true";
            dt.Rows.Add(dr);

            grdHousesRuteados.DataSource = dt;
        }

        private void IngresarHousesBL()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Num"));
            dt.Columns.Add(new DataColumn("House"));
            dt.Columns.Add(new DataColumn("Freehand"));

            DataRow dr = dt.NewRow();
            dr["Num"] = "1";
            dr["House"] = "";
            dr["Freehand"] = "";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Num"] = "2";
            dr["House"] = "";
            dr["Freehand"] = "";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Num"] = "3";
            dr["House"] = "";
            dr["Freehand"] = "";
            dt.Rows.Add(dr);

            grdDigitarHousesBL.DataSource = dt;

        }
        
        protected void MarcarPaso(object sender, CustomRowCellEditEventArgs e)
        {
            pnlPaso1.Visible = false;
            pnlPaso3.Visible = false;
            pnlExcepciones.Visible = false;
            pnlEnviarAviso.Visible = false;

            //if(e.Column.FieldName == "Estado")
            //{
                if (e.RowHandle == 0)
                {
                    pnlPaso1.Visible = true;
                }
                if (e.RowHandle == 2)
                {
                    pnlPaso3.Visible = true;
                }
                if(e.RowHandle==10)
                {
                    pnlExcepciones.Visible = true;
                }
                if(e.RowHandle == 11)
                {
                    pnlEnviarAviso.Visible = true;
                }

            //}

            
        }

        private void CargarPasos()
        {
            IList<PasosPaperless> pasos = new List<PasosPaperless>();
            PasosPaperless paso;

            paso = new PasosPaperless("1", "Digitar Houses BL", false);
            pasos.Add(paso);
            paso = new PasosPaperless("2", "Revisar Houses Ruteados", false);
            pasos.Add(paso);
            paso = new PasosPaperless("3", "Ingresar Houses Ruteados", false);
            pasos.Add(paso);
            paso = new PasosPaperless("4", "Cuadrar MBL-HBL", false);
            pasos.Add(paso);
            paso = new PasosPaperless("5", "Crear Manifiesto", false);
            pasos.Add(paso);
            paso = new PasosPaperless("6", "Generar Avisos", false);
            pasos.Add(paso);
            paso = new PasosPaperless("7", "Enviar Avisis", false);
            pasos.Add(paso);
            paso = new PasosPaperless("8", "Generar Facturas", false);
            pasos.Add(paso);
            paso = new PasosPaperless("9", "Cargar Copia BL", false);
            pasos.Add(paso);
            paso = new PasosPaperless("10", "Imprimir BL's", false);
            pasos.Add(paso);
            paso = new PasosPaperless("11", "Registrar Excepciones", false);
            pasos.Add(paso);
            paso = new PasosPaperless("12", "Enviar Aviso a Usuario 2", false);
            pasos.Add(paso);
                                                                    
            grdPasos.DataSource = pasos;
                        
        }
        

        private void simpleButton17_Click(object sender, EventArgs e)
        {
            
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            frmPaperlessUser2 form = new frmPaperlessUser2();
            form.Show();
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        
    }

    public class PasosPaperless
    {
        public PasosPaperless(){}
        public PasosPaperless(string num, string descripcion,bool estado)
        {
            NumPaso = num;
            Descripcion = descripcion;
            Estado = estado;
        }

        public string NumPaso { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

    }

}
