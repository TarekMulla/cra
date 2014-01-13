using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProyectoCraft.WinForm.Ventas.Actividades.EMail
{
    public partial class FrmNuevoMail : Form
    {
        public FrmNuevoMail()
        : base()
        {
            InitializeComponent();
        }

        private static FrmNuevoMail  _form = null;
        public static  FrmNuevoMail  Instancia
        {
            get
            {
                if (_form == null)
                    _form = new FrmNuevoMail();
                
                 return _form;
            }
            set
            {
            	_form = value;
            }
        }

        private void FrmNuevoMail_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            

        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }

        private void FrmNuevoMail_Load_1(object sender, EventArgs e)
        {
             
        }

        private void MenuSalir_Click_1(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();

        }

        private void FrmNuevoMail_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instancia = null;

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Ventas.Oportunidades.FrmOportunidad form = Ventas.Oportunidades.FrmOportunidad.Instancia;
            form.Show();

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Tipo");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Categoria");
            DataRow dr = dt.NewRow();
            dr["Tipo"] = "Target";
            dr["Nombre"] = "Textiles Flores S.A.";
            dr["Categoria"] = "VIP";
            dt.Rows.Add(dr);

            this.gridMailOportunidad1.DataSource = dt;

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Oportunidad");
            dt2.Columns.Add("Cliente");
            dt2.Columns.Add("Estado");
            dt2.Columns.Add("Asignar");
            DataRow dr2 = dt2.NewRow();
            dr2["Oportunidad"] = "Oportunidad FCL";
            dr2["Cliente"] = "Textiles Flores S.A.";
            dr2["Estado"] = "Abierta";
            dr2["Asignar"] = "";
            dt2.Rows.Add(dr2);

            this.gridMailOportunidad2.DataSource = dt2;
        }

     
      

            
    }
}
