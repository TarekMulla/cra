using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using ProyectoCraft.Entidades.Ventas.Pricing;

namespace SCCMultimodal.Ventas.Pricing
{
    public partial class FrmIngresarTarifa : Form
    {
        public FrmIngresarTarifa()
        {
            InitializeComponent();
        }

        private static FrmIngresarTarifa _form = null;

        public static FrmIngresarTarifa Instancia
        {
            get
            {
                if (_form == null)
                    _form = new FrmIngresarTarifa();

                return _form;
            }
            set { _form = value; }
        }

        public ClsSolicitudCotizacionIndirecta SolicitudCotizacionIndirecta { get; set; }
        private List<ClsMonedas> ListaMonedas { get; set; }

        private void LimpiaGrilla()
        {
            txtAgente.Text = "";
            txtComInt.Text = "";
            txtComenIncCot.Text = "";
            txtFechaValidez.Text = "";
        }

        private void SolicitarTarifa_Load(object sender, EventArgs e)
        {
            LimpiaGrilla();
            ListaMonedas = ObtieneMonedas();
            var bar = new List<ClsDetalleTarifa>();
            var item = new ClsDetalleTarifa { Item = new ClsItem(), Moneda = new ClsMonedas() };
            txtFecha.DateTime = DateTime.Now;

            item.Costo = 0;
            item.Venta = 0;

            var itemsTarifas = ObtieneItems();

            

            foreach (var itemTarifa in itemsTarifas)
            {
                PrecargarValores(itemTarifa, SolicitudCotizacionIndirecta.IncoTerm.Codigo, item);
                if (ListaMonedas != null)
                {
                    item.Moneda.Nombre = ListaMonedas[0].Nombre;
                    item.Moneda.Id = ListaMonedas[0].Id;
                }
                if (!string.IsNullOrEmpty(item.Item.Descripcion))
                    bar.Add(item);
                item = new ClsDetalleTarifa { Item = new ClsItem(), Moneda = new ClsMonedas() };
            }

            gridDetalle.DataSource = bar;

        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }
        private List<ClsItem> ObtieneItems()
        {
            return (List<ClsItem>)ProyectoCraft.LogicaNegocios.Ventas.pricing.ClsTarifas.ListarItemsTarifas().ObjetoTransaccion;
        }

        private List<ClsMonedas> ObtieneMonedas()
        {
            return (List<ClsMonedas>)ProyectoCraft.LogicaNegocios.Ventas.pricing.ClsTarifas.ListarMonedasTarifas().ObjetoTransaccion;
        }
        private void PrecargarValores(ClsItem item, string codigo, ClsDetalleTarifa detalle)
        {
            if (codigo.Equals("FOB"))
            {
                if (item.Nombre.Equals("Transporte Maritimo") || item.Nombre.Equals("THC Destino") || item.Nombre.Equals("Agente"))
                {
                    detalle.Item.Descripcion = item.Descripcion;
                    detalle.Item.Id = item.Id;
                    detalle.Item.Nombre = item.Nombre;
                }
            }
            if (codigo.Equals("FCA"))
            {
                if (item.Nombre.Equals("Drayage") || item.Nombre.Equals("Gasto de Consolidacion") || item.Nombre.Equals("Transporte Maritimo") || item.Nombre.Equals("THC Destino") || item.Nombre.Equals("Agente"))
                {
                    detalle.Item.Descripcion = item.Descripcion;
                    detalle.Item.Id = item.Id;
                    detalle.Item.Nombre = item.Nombre;
                }
            }
            if (codigo.Equals("EXW"))
            {
                if (item.Nombre.Equals("Transporte Maritimo") || item.Nombre.Equals("Transporte Terrestre") || item.Nombre.Equals("THC Destino") || item.Nombre.Equals("Agente"))
                {
                    detalle.Item.Descripcion = item.Descripcion;
                    detalle.Item.Id = item.Id;
                    detalle.Item.Nombre = item.Nombre;
                }
            }
        }

        private void sButtonAgregarObservacion_Click(object sender, EventArgs e)
        {
            var foo = gridDetalle.DataSource as List<ClsDetalleTarifa>;
            var item = new ClsDetalleTarifa { Item = new ClsItem(), Moneda = new ClsMonedas() };

            var itemsTarifas = ObtieneItems();
            if (itemsTarifas != null)
            {
                item.Item.Descripcion = itemsTarifas[0].Descripcion;
                item.Item.Id = itemsTarifas[0].Id;
            }

            var monedasTarifas = ObtieneMonedas();
            if (monedasTarifas != null)
            {
                item.Moneda.Nombre = monedasTarifas[0].Nombre;
                item.Moneda.Id = monedasTarifas[0].Id;
            }

            if (foo != null)
            {
                foo.Add(item);
                gridDetalle.DataSource = foo;
            }
            gridDetalle.RefreshDataSource();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            GuardaDatos();
        }
        private bool Validar()
        {
            if (String.IsNullOrEmpty(txtFecha.Text))
            {
                MessageBox.Show("Error en Fecha", this.Name, MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                return false;
            }
            
            if (String.IsNullOrEmpty(txtFechaValidez.Text))
            {
                MessageBox.Show("Error en Fecha Validez", this.Name, MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return false;
            }            
            return true;
        }

        private void GuardaDatos(){
            var tar = new ClsSolicitudCotizacionInDirectaOpciones();
            if (Validar())
            {
                if (!String.IsNullOrEmpty(txtFecha.Text))
                    tar.Fecha = Convert.ToDateTime(txtFecha.Text);
                if (!String.IsNullOrEmpty(txtFechaValidez.Text))
                    tar.FechaValidezInicio = Convert.ToDateTime(txtFechaValidez.Text);

                if (!String.IsNullOrEmpty(txtFechaValidezFin.Text))
                    tar.FechaValidezFin = Convert.ToDateTime(txtFechaValidezFin.Text);

                tar.Agente = !String.IsNullOrEmpty(txtAgente.Text) ? txtAgente.Text : "";

                tar.Comentario = txtComenIncCot.Text;
                tar.ComentarioInterno = txtComInt.Text;
                tar.FechaCreacion = DateTime.Now;
                tar.Estado = ClsEstado.Estado.Ingresado;
                //tar.Detalle = GetDetalleTarifa();

                if (SolicitudCotizacionIndirecta.Estado.Equals(ClsEstado.Estado.Enproceso))
                    SolicitudCotizacionIndirecta.Estado = ClsEstado.Estado.Tarifadisponible;

                SolicitudCotizacionIndirecta.AddTarifa(tar);
                var res = ProyectoCraft.LogicaNegocios.Ventas.pricing.ClsTarifas.GuardarTarifa(SolicitudCotizacionIndirecta, tar);
                MessageBox.Show(res.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                Close();
            }
        }
        private List<ClsDetalleTarifa> GetDetalleTarifa()
        {
            var lista = new List<ClsDetalleTarifa>();
            ClsDetalleTarifa item;


            for (int i = 0; i < gridDetalle.DefaultView.RowCount; i++)
            {
                var filaSelected = gridDetalle.DefaultView.GetRow(i);
                var row = (ClsDetalleTarifa)filaSelected;
                foreach (var listaMoneda in ListaMonedas)
                {
                    if (row.Moneda.Nombre != null && row.Moneda.Nombre.Equals(listaMoneda.Nombre))
                        row.Moneda.Id = listaMoneda.Id;
                }

                //item.Cantidad = row.Cantidad;
                //item.Costo = row.Costo;
                //item.Id = row.Id;
                //item.Moneda = row.Moneda;
                //item.Venta = row.Venta;
                //item.Item.Descripcion = row.Item.Descripcion;                
                //item.Item.Id = row.Item.Id;
                //item.Item.Nombre = row.Item.Nombre;
                item = row;
                lista.Add(item);
                new ClsDetalleTarifa { Item = new ClsItem(), Moneda = new ClsMonedas() };
            }


            return lista;
        }


        private void grpOportunidad_Enter(object sender, EventArgs e)
        {

        }

        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            var foo = sender as GridView;

            if (foo.FocusedColumn.FieldName.Equals("Moneda.Nombre"))
            {
                DevExpress.XtraEditors.ComboBoxEdit cbo = (sender as DevExpress.XtraGrid.Views.Base.BaseView).ActiveEditor as DevExpress.XtraEditors.ComboBoxEdit;
                ComboBoxItemCollection coll = cbo.Properties.Items;
                foreach (var tipo in ListaMonedas)
                {
                    coll.Add(tipo.Nombre);
                }
            }
        }
    }
}
