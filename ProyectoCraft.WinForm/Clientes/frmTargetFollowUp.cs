using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using ProyectoCraft.Entidades.Clientes;
using ProyectoCraft.Entidades.Direccion.Metas;
using ProyectoCraft.Entidades.Ventas.Actividades;
using ProyectoCraft.LogicaNegocios.Direccion.Metas;

namespace ProyectoCraft.WinForm.Clientes {
    public partial class frmtargetFollowUP : Form {
        private static frmtargetFollowUP _instancia = null;
        public static frmtargetFollowUP Instancia {
            get {
                if (_instancia == null)
                    _instancia = new frmtargetFollowUP();

                return _instancia;
            }
            set {
                _instancia = value;
            }
        }

        private clsMeta _Meta;
        public clsMeta Meta {
            get {
                return _Meta;
            }
            set {
                _Meta = value;
            }
        }

        public frmtargetFollowUP() {
            InitializeComponent();
        }


        private void ListarTiposActividad() {
            var Tipos = LogicaNegocios.Ventas.Actividades.clsAsuntoTipoActividad.ListarTipoActividad();

            ComboBoxItemCollection coll = cboActividadFollowUp.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in Tipos) {
                coll.Add(list);
            }
            cboActividadFollowUp.SelectedIndex = 0;

        }

        private void frmClienteFollowUp_Load(object sender, EventArgs e) {
            CargarFollowUp();
            ListarTiposActividad();
            LimpiaFormFollowUp();
            //this.Text = "Historial Follow Up Cliente " + Cliente.NombreCompañia + "(" + Cliente.NombreFantasia + ")";
        }

        private void CargarFollowUp() {
            var listado = LogicaNegocios.Clientes.clsClientesMaster.ObtenerFollowUpActivosClientePorTarget(Meta.Id);
            gridFollowUp.DataSource = listado;
        }

        private void MenuSalir_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void frmClienteFollowUp_FormClosed(object sender, FormClosedEventArgs e) {
            Instancia = null;
        }

        private void sButtonEliminarTrafico_Click(object sender, EventArgs e) {
            foreach (var i in gridView3.GetSelectedRows()) {
                var followUp = gridView3.GetRow(i) as clsClienteFollowUp;
                if (followUp.FechaFollowUp.Value.Date < DateTime.Now.Date) {
                    MessageBox.Show("No se puede Eliminar un follow up ya vencido", "Eliminacion", MessageBoxButtons.OK);
                } else {
                    if (MessageBox.Show("¿Esta seguro de eliminar?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        gridView3.DeleteRow(i);
                }
            }
        }

        private Boolean ValidarFollowup() {
            var retorno = true;
            if (cboActividadFollowUp.SelectedItem == null || cboActividadFollowUp.SelectedIndex <= 0) {
                ctrldxError.SetError(cboActividadFollowUp, "Debe ingresar la actividad", ErrorType.Critical);
                retorno = false;
            } else {
                ctrldxError.SetError(cboActividadFollowUp, "", ErrorType.None);
            }
            if (String.IsNullOrEmpty(dtFechaFollowUp.DateTime.ToString())) {
                ctrldxError.SetError(dtFechaFollowUp, "Debe ingresar la fecha", ErrorType.Critical);
                retorno = false;
            } else {
                ctrldxError.SetError(dtFechaFollowUp, "", ErrorType.None);
            }

            if (String.IsNullOrEmpty(txtDescripcionFollowUp.Text.Trim())) {
                ctrldxError.SetError(txtDescripcionFollowUp, "Debe ingresar la descripcion", ErrorType.Critical);
                retorno = false;
            } else {
                ctrldxError.SetError(txtDescripcionFollowUp, "", ErrorType.None);
            }
            return retorno;
        }

        private IList<clsClienteFollowUp> ObtieneFollowUpsDesdeGrilla() {
            var list = gridFollowUp.DataSource as List<clsClienteFollowUp>;
            var retorno = new List<clsClienteFollowUp>();
            if (list != null)
                retorno = list.FindAll(foo => foo.FechaFollowUp.HasValue);
            return retorno;
        }

        private void AgregarFollowUpGrilla(clsClienteFollowUp followup) {
            var list = ObtieneFollowUpsDesdeGrilla();
            list.Add(followup);
            gridFollowUp.DataSource = list;
        }

        private void sButtonAgregarTrafico_Click(object sender, EventArgs e) {
            if (ValidarFollowup()) {
                var followup = new clsClienteFollowUp
                {
                    FechaFollowUp = dtFechaFollowUp.DateTime,
                    Descripcion = txtDescripcionFollowUp.Text,
                    TipoActividad =
                        (clsTipoActividad)cboActividadFollowUp.SelectedItem
                };
                AgregarFollowUpGrilla(followup);
                LimpiaFormFollowUp();
            }
        }
        private void LimpiaFormFollowUp() {
            dtFechaFollowUp.DateTime = DateTime.Now;
            txtDescripcionFollowUp.Text = String.Empty;
            cboActividadFollowUp.SelectedIndex = 0;
        }

        private void MenuGuardar_Click(object sender, EventArgs e) {
            Meta.FollowUps = ObtieneFollowUpsDesdeGrilla();
            foreach (var clsClienteFollowUp in Meta.FollowUps) {
                clsClienteFollowUp.IdTarget = Meta.Id32;
                clsClienteFollowUp.Usuario = Base.Usuario.UsuarioConectado.Usuario;
                clsClienteFollowUp.Cliente = Meta.ObjClienteMaster;
            }

            var res  = clsMetaNegocio.GuardarFollowUps(Meta);
            MessageBox.Show(res.Descripcion, "Sistema Comercial Craft", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
        }
    }
}
