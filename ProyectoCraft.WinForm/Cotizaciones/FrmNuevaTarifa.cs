using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProyectoCraft.Entidades.Cotizaciones.Indirecta;

namespace SCCMultimodal.Cotizaciones
{
    public partial class FrmNuevaTarifa : DevExpress.XtraEditors.XtraForm
    {
        public FrmNuevaTarifa()
        {
            InitializeComponent();
        }

        private static FrmNuevaTarifa _form = null;
        public static FrmNuevaTarifa Instancia
        {
            get { return _form ?? (_form = new FrmNuevaTarifa()); }
            set
            {
                _form = value;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var cot = new CotizacionIndirectaOpcion();
            cot.FechaCreacion = Convert.ToDateTime(txtFechaTarifa.Text);
            cot.FechaValidezInicio = Convert.ToDateTime(txtFechaValidez.Text);
            cot.FechaValidezFin = Convert.ToDateTime(txtFechaValidezFin.Text);
            cot.Pol = null;// TxtPol.Text;
            cot.Pod = null;// TxtPol.Text;
            cot.Agente = txtAgente.Text;
            cot.TipoTransbordo = null; //cboTransbordo.Text;
            //no se graba el incoter en la cot indirecta opcion
            cot.Naviera = null;// TxtNaviera.Text;
            cot.TiempoTransbordo = txtTiempoTransbordo.Text;
            cot.PickUp = txtPickUp.Text;

            //var cotDetalle = new CotizacionIndirectaOpcionDetalle();
            var items = (IList<CotizacionIndirectaOpcionDetalle>) gridDetalleTarifa.DataSource;
            
            //(IList<PaperlessPasosEstado>)grdPasos.DataSource
            cot.Detalles.AddRange(items);
            //cot.Detalles.Add(cotDetalle);
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            Close();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}