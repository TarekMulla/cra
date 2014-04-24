using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using ProyectoCraft.Entidades.Enums;
using SCCMultimodal.Paperless.Usuario2;

namespace ProyectoCraft.WinForm.Paperless.Usuario2
{
    public partial class frmListarUsuario2 : Form
    {
        public frmListarUsuario2()
        {
            InitializeComponent();
        }

        private static frmListarUsuario2 _instancia;
        public static frmListarUsuario2 Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmListarUsuario2();

                return _instancia;
            }
            set { _instancia = value; }
        }

        private void frmListarUsuario2_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            CargarEstados();
            ObtenerAsignaciones();
            CargarNavesExistentes();
        }
        private void CargarNavesExistentes()
        {
            ComboBoxItemCollection coll = ddlNave.Properties.Items;
            IList<Entidades.Paperless.PaperlessNave> listNaves = new List<Entidades.Paperless.PaperlessNave>();

            listNaves = LogicaNegocios.Paperless.Paperless.ObtenerNaves(Entidades.Enums.Enums.Estado.Habilitado);

            coll = ddlNave.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listNaves)
            {
                coll.Add(list);
            }
            ddlNave.SelectedIndex = 0;
            ddlNave.Properties.AutoComplete = true;

            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Add(txtNave.Text);
            txtNave.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtNave.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (var list in listNaves)
            {
                auto.Add(list.Nombre);
            }
            txtNave.AutoCompleteCustomSource = auto;
        }
        private void CargarEstados()
        {
            string[] filtrousuario2 = System.Configuration.ConfigurationSettings.AppSettings.Get("FiltroUsuario2").Split(',');
            IList<ProyectoCraft.Entidades.Paperless.PaperlessEstado> estados =
                ProyectoCraft.LogicaNegocios.Paperless.Paperless.ObtenerEstadosPaperless(Enums.Estado.Habilitado);

            foreach (var list in estados)
            {
                //coll.Add(list);            
                if (filtrousuario2.Contains(list.Nombre))
                //if (list.Nombre.Equals("Enviado Usuario 2da Etapa") || list.Nombre.Equals("En Proceso Usuario 2da Etapa"))
                    checkedComboBoxEstados.Properties.Items.Add(list, CheckState.Checked, true);
                else
                    checkedComboBoxEstados.Properties.Items.Add(list, CheckState.Unchecked, true);
            }
            
            //ComboBoxItemCollection coll = ddlEstado.Properties.Items;
            //coll.Add(ProyectoCraft.WinForm.Utils.Utils.ObtenerPrimerItem());
            //foreach (var list in estados)
            //{
            //    coll.Add(list);
            //}
            //ddlEstado.SelectedIndex = 0;
        }

        public void ObtenerAsignaciones()
        {
            string nummaster = "-1";
            DateTime desde = new DateTime(9999, 1, 1);
            DateTime hasta = new DateTime(9999, 1, 1);
            Int64 usuario1 = -1;
            Int64 usuario2 = -1;
            Int64 estado = -1;
            string estados = "";
            string numconsolidado = "";
            string nave = "";
            DateTime desdeNavieras = new DateTime(9999, 1, 1);
            DateTime hastaNavieras = new DateTime(9999, 1, 1);
            DateTime desdeEmbarcadores = new DateTime(9999, 1, 1);
            DateTime hastaEmbarcadores = new DateTime(9999, 1, 1);
            Boolean tieneEstadoChecked = false;

            if (txtDesde.Text == "")
                desde = new DateTime(9999, 1, 1);
            else
                desde = Convert.ToDateTime(txtDesde.Text);

            desde = new DateTime(desde.Year, desde.Month, desde.Day, 0, 0, 1);

            if (txtHasta.Text == "")
                hasta = new DateTime(9999, 1, 1);
            else
                hasta = Convert.ToDateTime(txtHasta.Text);

            hasta = new DateTime(hasta.Year, hasta.Month, hasta.Day, 23, 59, 59);

            usuario1 = -1;
            usuario2 = ProyectoCraft.Base.Usuario.UsuarioConectado.Usuario.Id;

            for (int i = 0; i < checkedComboBoxEstados.Properties.Items.Count; i++)
            {
                if (checkedComboBoxEstados.Properties.Items[i].CheckState.Equals(CheckState.Checked))
                {
                    tieneEstadoChecked = true;
                    estados += (i+1).ToString() + ",";
                }
            }
            if (tieneEstadoChecked)
            {
                //le quito la ultima coma siempre para poder agregarla en el IN de la consulta
                estados = estados.Remove(estados.Length - 1); //+ "''" "''" +;    
            }
            else
                estados = "-1";

            //if (ddlEstado.SelectedIndex <= 0)
            //    estado = -1;
            //else
            //    estado = ((ProyectoCraft.Entidades.Paperless.PaperlessEstado)ddlEstado.SelectedItem).Id;

            if (txtNumConsolidado.Text.Length.Equals(0))
                numconsolidado = "-1";
            else
                numconsolidado = txtNumConsolidado.Text.Trim();
            
            if (!string.IsNullOrEmpty(txtNave.Text))
                nave = txtNave.Text;

            if (txtdesdeEmbarcador.Enabled.Equals(true) && txtdesdeEmbarcador.Text.Length > 0)
                desdeEmbarcadores = new DateTime(txtdesdeEmbarcador.DateTime.Year, txtdesdeEmbarcador.DateTime.Month, txtdesdeEmbarcador.DateTime.Day, 0, 0, 1);

            if (txtHastaEmbarcador.Enabled.Equals(true) && txtHastaEmbarcador.Text.Length > 0)
                hastaEmbarcadores = new DateTime(txtHastaEmbarcador.DateTime.Year, txtHastaEmbarcador.DateTime.Month, txtHastaEmbarcador.DateTime.Day, 23, 59, 59);

            if (txtdesdeNavieras.Enabled.Equals(true) && txtdesdeNavieras.Text.Length > 0)
                desdeNavieras = new DateTime(txtdesdeNavieras.DateTime.Year, txtdesdeNavieras.DateTime.Month, txtdesdeNavieras.DateTime.Day, 0, 0, 1);

            if (txthastaNavieras.Enabled.Equals(true) && txthastaNavieras.Text.Length > 0)
                hastaNavieras = new DateTime(txthastaNavieras.DateTime.Year, txthastaNavieras.DateTime.Month, txthastaNavieras.DateTime.Day, 23, 59, 59);


            gridAsignaciones.DataSource = null;

            IList<ProyectoCraft.Entidades.Paperless.PaperlessFlujo> asignaciones =
                ProyectoCraft.LogicaNegocios.Paperless.Paperless.ObtenerAsignaciones(desde, hasta, usuario1, usuario2, estados, numconsolidado,nave
                , desdeEmbarcadores, hastaEmbarcadores, desdeNavieras, hastaNavieras, nummaster);
            gridAsignaciones.DataSource = asignaciones;
            //asignaciones[0].Asignacion.Usuario1.NombreCompleto
            
            gridAsignaciones.RefreshDataSource();
            gridAsignaciones.Refresh();
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            Close();
        }

        private void MenuVer_Click(object sender, EventArgs e)
        {
            Entidades.Paperless.PaperlessFlujo asignacion = ObtenerAsignacion();
            Paperless.Asignacion.frmPaperlessAsignacion form = Paperless.Asignacion.frmPaperlessAsignacion.Instancia;

            if (asignacion != null)
            {
                form.PaperlessAsignacionActual = asignacion.Asignacion;
                form.CargarFormulario();
                form.Accion = Enums.TipoAccionFormulario.Consultar;
                form.ShowDialog();

            }
            else
                MessageBox.Show("Debe seleccionar una asignacion", "Paperless - Asignacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);       
        }

        private Entidades.Paperless.PaperlessFlujo ObtenerAsignacion()
        {
            var filaSelected = gridAsignaciones.DefaultView.GetRow(gridView1.FocusedRowHandle);

            if (filaSelected == null)
            {
                return null;
            }

            Entidades.Paperless.PaperlessFlujo asignacion = (Entidades.Paperless.PaperlessFlujo)filaSelected;

            return asignacion;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ObtenerAsignaciones();
        }

        private void gridAsignaciones_Click(object sender, EventArgs e)
        {
            Entidades.Paperless.PaperlessFlujo asignacion = ObtenerAsignacion();
            MenuComenzar.Text = "Comenzar";
            MenuVer.Enabled = false;
            MenuComenzar.Enabled = false;
            
            if (asignacion != null && asignacion.EstadoFlujo == Enums.EstadoPaperless.EnviadoUsuario2)
            {                
                MenuVer.Enabled = true;
                MenuComenzar.Enabled = true;
                MenuComenzar.Text = "En Proceso";
            }

            if(asignacion != null && asignacion.EstadoFlujo == Enums.EstadoPaperless.EnProcesoUsuario2)
            {
                MenuVer.Enabled = true;
                MenuComenzar.Enabled = true;
                MenuComenzar.Text = "En Proceso";
            }

            if (asignacion != null && asignacion.EstadoFlujo == Enums.EstadoPaperless.ProcesoTerminado)
            {
                MenuVer.Enabled = true;
                MenuComenzar.Enabled = true;
                MenuComenzar.Text = "Ver Proceso";
            }

            if (asignacion != null && asignacion.EstadoFlujo == Enums.EstadoPaperless.EnviadoMercante) {
                MenuVer.Enabled = true;
                MenuComenzar.Enabled = true;
                MenuComenzar.Text = "Ver Proceso";
            }
        }

        private void MenuComenzar_Click(object sender, EventArgs e)
        {
            IFrmPaperlessUser2 form = null;
            Entidades.Paperless.PaperlessFlujo asignacion = ObtenerAsignacion();
            if (asignacion.Asignacion.VersionUsuario1 == 1)
                form = frmPaperlessUser2.Instancia;
            if (asignacion.Asignacion.VersionUsuario1 == 2)
                form = frmPaperlessUser2v2.Instancia;

            if(asignacion != null)
            {
                form.PaperlessAsignacionActual = asignacion.Asignacion;
                if(asignacion.EstadoFlujo == Enums.EstadoPaperless.EnviadoUsuario2)
                {
                    Entidades.GlobalObject.ResultadoTransaccion resultado = form.PrepararPasos();
                    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                    {
                        MessageBox.Show("Ocurrio un problema al preparar los Pasos del Usuario 2. \n " +
                                        resultado.Descripcion);
                        return;
                    }
                }
            }

            if (MenuComenzar.Text == "Ver Proceso")
                form.Accion = Enums.TipoAccionFormulario.Consultar;
            else
                form.Accion = Enums.TipoAccionFormulario.Nuevo;

            this.ObtenerAsignaciones();
            form.MyShowDialog();
            
        }

        private void chkPlazoEmbarcador_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPlazoEmbarcador.Checked.Equals(true))
            {
                txtdesdeEmbarcador.Enabled = true;
                txtHastaEmbarcador.Enabled = true;
            }
            else
            {
                txtdesdeEmbarcador.Enabled = false;
                txtHastaEmbarcador.Enabled = false;
            }
        }

        private void chkAperturaNaviera_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAperturaNaviera.Checked.Equals(true))
            {
                txtdesdeNavieras.Enabled = true;
                txthastaNavieras.Enabled = true;
            }
            else
            {
                txtdesdeNavieras.Enabled = false;
                txthastaNavieras.Enabled = false;
            }
        }

        private void chkCreacionPaperless_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCreacionPaperless.Checked.Equals(true))
            {
                txtDesde.Enabled = true;
                txtHasta.Enabled = true;
            }
            else
            {
                txtDesde.Enabled = false;
                txtHasta.Enabled = false;
            }
        }

    }
}
