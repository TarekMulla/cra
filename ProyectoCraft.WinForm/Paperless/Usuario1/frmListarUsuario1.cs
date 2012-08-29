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
using SCCMultimodal.Paperless.Usuario1;

namespace ProyectoCraft.WinForm.Paperless.Usuario1
{
    public partial class frmListarUsuario1 : Form
    {
        public frmListarUsuario1()
        {
            InitializeComponent();
        }

        private static frmListarUsuario1 _instancia;
        public static frmListarUsuario1 Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new frmListarUsuario1();

                return _instancia;
            }
            set { _instancia = value; }
        }


        private void frmListarUsuario1_Load(object sender, EventArgs e)
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
            string[] filtrousuario1 = System.Configuration.ConfigurationSettings.AppSettings.Get("FiltroUsuario1").Split(',');
            IList<Entidades.Paperless.PaperlessEstado> estados =
                LogicaNegocios.Paperless.Paperless.ObtenerEstadosPaperless(Enums.Estado.Habilitado);

            //ComboBoxItemCollection coll = ddlEstado.Properties.Items;
            //coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in estados)
            {
                //coll.Add(list);            
                if (filtrousuario1.Contains(list.Nombre))
                    checkedComboBoxEstados.Properties.Items.Add(list, CheckState.Checked, true);
                else
                    checkedComboBoxEstados.Properties.Items.Add(list, CheckState.Unchecked, true);
            }

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

            usuario1 = Base.Usuario.UsuarioConectado.Usuario.Id;
            usuario2 = -1;

            for (int i = 0; i < checkedComboBoxEstados.Properties.Items.Count; i++)
            {
                if (checkedComboBoxEstados.Properties.Items[i].CheckState.Equals(CheckState.Checked))
                {
                    tieneEstadoChecked = true;
                    estados += (i + 1).ToString() + ",";
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
            //    estado = ((Entidades.Paperless.PaperlessEstado)ddlEstado.SelectedItem).Id;

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


            IList<Entidades.Paperless.PaperlessFlujo> asignaciones =
                LogicaNegocios.Paperless.Paperless.ObtenerAsignaciones(desde, hasta, usuario1, usuario2, estados, numconsolidado, nave
                , desdeEmbarcadores, hastaEmbarcadores, desdeNavieras, hastaNavieras, nummaster);

            gridAsignaciones.DataSource = asignaciones;
            //asignaciones[0].Asignacion.Usuario1.NombreCompleto

            gridAsignaciones.RefreshDataSource();
            gridAsignaciones.Refresh();

            DeshabilitarOPciones();
        }

        private void DeshabilitarOPciones()
        {
            MenuAceptar.Enabled = false;
            MenuComenzar.Enabled = false;
            MenuRechazar.Enabled = false;
            MenuVer.Enabled = false;
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

        private void MenuComenzar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Entidades.Paperless.PaperlessFlujo asignacion = ObtenerAsignacion();

            IFrmPaperlessUser1 form = null;

            //Paperless.Usuario1.frmPaperlessUser1 form = frmPaperlessUser1.Instancia;

            if (asignacion != null)
            {
                if (asignacion.Asignacion.VersionUsuario1 == 1)
                    form = FrmPaperlessUser1.Instancia;
                if (asignacion.Asignacion.VersionUsuario1 == 2)
                    form = frmPaperlessUser1v2.Instancia;

                form.PaperlessAsignacionActual = asignacion.Asignacion;

                if (asignacion.EstadoFlujo == Enums.EstadoPaperless.AceptadoUsuario1)
                {
                    Entidades.GlobalObject.ResultadoTransaccion resultado = form.PrepararPasos();
                    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Ocurrio un problema al preparar los Pasos del Usuario 1. \n " +
                                        resultado.Descripcion);
                        return;
                    }
                }
                form.LimpiarFormulario();
                form.CargarInformacionAsignacionInicial();

                if (MenuComenzar.Text == "Ver Proceso")
                    form.Accion = Enums.TipoAccionFormulario.Consultar;
                else
                    form.Accion = Enums.TipoAccionFormulario.Nuevo;

                //form.CargarFormulario();
                //form.Accion = Enums.TipoAccionFormulario.Editar;
                Cursor.Current = Cursors.Default;
                form.MyShowDialog();

            }
            else
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Debe seleccionar una asignacion", "Paperless - Asignacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void MenuAceptar_Click(object sender, EventArgs e)
        {
            Entidades.Paperless.PaperlessFlujo asignacion = ObtenerAsignacion();

            if (MessageBox.Show("Esta seguro de aceptar esta asignación?", "Paperless", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                asignacion.Asignacion.Estado = Enums.EstadoPaperless.AceptadoUsuario1;

                Entidades.GlobalObject.ResultadoTransaccion resultado = LogicaNegocios.Paperless.Paperless.CambiaEstadoAsignacion(asignacion.Asignacion);
                if (resultado.Estado == Enums.EstadoTransaccion.Aceptada)
                {
                    MessageBox.Show("Asignación fue aceptada exitosamente", "Paperless", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    ObtenerAsignaciones();

                }
            }

        }

        private void gridAsignaciones_Click(object sender, EventArgs e)
        {
            Entidades.Paperless.PaperlessFlujo asignacion = ObtenerAsignacion();
            MenuComenzar.Text = "Comenzar";

            if (asignacion != null)
            {

                if (asignacion.EstadoFlujo == Enums.EstadoPaperless.AsignadoUsuario1)
                {
                    MenuAceptar.Enabled = true;
                    MenuRechazar.Enabled = true;
                    MenuVer.Enabled = true;
                    MenuComenzar.Enabled = false;
                }

                if (asignacion.EstadoFlujo == Enums.EstadoPaperless.AceptadoUsuario1)
                {
                    MenuAceptar.Enabled = false;
                    MenuRechazar.Enabled = false;
                    MenuVer.Enabled = true;
                    MenuComenzar.Enabled = true;
                }

                if (asignacion.EstadoFlujo == Enums.EstadoPaperless.EnProcesoUsuario1)
                {
                    MenuAceptar.Enabled = false;
                    MenuRechazar.Enabled = false;
                    MenuVer.Enabled = true;
                    MenuComenzar.Enabled = true;
                    MenuComenzar.Text = "En Proceso";
                }
                if (asignacion.EstadoFlujo == Enums.EstadoPaperless.EnviadoUsuario2 ||
                    asignacion.EstadoFlujo == Enums.EstadoPaperless.EnProcesoUsuario2 ||
                    asignacion.EstadoFlujo == Enums.EstadoPaperless.ProcesoTerminado)
                {
                    MenuAceptar.Enabled = false;
                    MenuRechazar.Enabled = false;
                    MenuVer.Enabled = true;
                    MenuComenzar.Enabled = true;
                    MenuComenzar.Text = "Ver Proceso";
                }

                if (asignacion.EstadoFlujo == Enums.EstadoPaperless.RechazadaUsuario1)
                {
                    MenuAceptar.Enabled = false;
                    MenuRechazar.Enabled = false;
                    MenuVer.Enabled = false;
                    MenuComenzar.Enabled = false;
                    MenuComenzar.Text = "Ver Proceso";
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ObtenerAsignaciones();
        }

        private void MenuRechazar_Click(object sender, EventArgs e)
        {
            Usuario1.frmRechazarAsignacion form = frmRechazarAsignacion.Instancia;
            Entidades.Paperless.PaperlessFlujo asignacion = ObtenerAsignacion();
            form.Asignacion = asignacion.Asignacion;
            form.ShowDialog();
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
