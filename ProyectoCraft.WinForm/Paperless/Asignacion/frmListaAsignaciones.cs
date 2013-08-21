using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using ProyectoCraft.Entidades.Clientes.Cuenta;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Paperless;
using ProyectoCraft.Entidades.Parametros;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.LogicaNegocios.Parametros;
using ProyectoCraft.WinForm.Clientes.Cuenta;
using ProyectoCraft.WinForm.Paperless.Usuario1;

namespace ProyectoCraft.WinForm.Paperless.Asignacion
{
    public partial class frmListaAsignaciones : Form
    {
        private static frmListaAsignaciones _instancia;
        public static frmListaAsignaciones Instancia
        {
            get
            {
                if(_instancia == null)
                    return new frmListaAsignaciones();

                return _instancia;
            }
            set { _instancia = value; }
        }


        public frmListaAsignaciones()
        {
            InitializeComponent();
        }

        private void frmListaAsignaciones_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            CargarEstados();
            CargarUsuarios();
            ListarAsignaciones();
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
        private void CargarUsuarios()
        {
            ComboBoxItemCollection coll = ddlUsuario1.Properties.Items;
            ComboBoxItemCollection coll2 = ddlUsuario2.Properties.Items;
            IList<Entidades.Usuarios.clsUsuario> listusuarios = new List<clsUsuario>();
            Entidades.GlobalObject.ResultadoTransaccion resultado = new ResultadoTransaccion();

            resultado = LogicaNegocios.Usuarios.clsUsuarios.ListarUsuarios(Enums.Estado.Habilitado,
                                                                              Enums.CargosUsuarios.Todos);
            if (resultado.Estado == Enums.EstadoTransaccion.Aceptada)
                listusuarios = (IList<clsUsuario>) resultado.ObjetoTransaccion;



            coll = ddlUsuario1.Properties.Items;
            coll2 = ddlUsuario2.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            coll2.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listusuarios)
            {
                coll.Add(list);
                coll2.Add(list);
            }
            ddlUsuario1.SelectedIndex = 0;
            ddlUsuario1.Properties.AutoComplete = true;

            ddlUsuario2.SelectedIndex = 0;
            ddlUsuario2.Properties.AutoComplete = true;


            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Add(txtUsuario1.Text);
            txtUsuario1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtUsuario1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (var list in listusuarios)
            {
                auto.Add(list.ToString());
            }
            txtUsuario1.AutoCompleteCustomSource = auto;

            auto = new AutoCompleteStringCollection();
            auto.Add(txtUsuario2.Text);
            txtUsuario2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtUsuario2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (var list in listusuarios)
            {
                auto.Add(list.ToString());
            }
            txtUsuario2.AutoCompleteCustomSource = auto;
        }

        private void CargarEstados()
        {
            IList<Entidades.Paperless.PaperlessEstado> estados =
                LogicaNegocios.Paperless.Paperless.ObtenerEstadosPaperless(Enums.Estado.Habilitado);

            ComboBoxItemCollection coll = ddlEstado.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in estados)
            {
                coll.Add(list);
            }
            ddlEstado.SelectedIndex = 0;            
        }

        public void ListarAsignaciones()
        {
            string nummaster = "-1";
            DateTime desde = new DateTime(9999,1,1);
            DateTime hasta = new DateTime(9999,1,1);
            Int64 usuario1 = -1;
            Int64 usuario2 = -1;
            Int64 estado = -1;
            string nave = "";
            string numconsolidado = "";
            DateTime desdeNavieras = new DateTime(9999, 1, 1);
            DateTime hastaNavieras = new DateTime(9999, 1, 1);
            DateTime desdeEmbarcadores = new DateTime(9999, 1, 1);
            DateTime hastaEmbarcadores = new DateTime(9999, 1, 1);

            if (txtNumMaster.Text.Length > 0)
                nummaster = txtNumMaster.Text;

            if(txtDesde.Text == "")
                desde = new DateTime(9999,1,1);
            else
                desde = Convert.ToDateTime(txtDesde.Text);

            desde = new DateTime(desde.Year,desde.Month,desde.Day,0,0,1);

            if(txtHasta.Text == "")
                hasta = new DateTime(9999,1,1);
            else
                hasta = Convert.ToDateTime(txtHasta.Text);

            hasta = new DateTime(hasta.Year,hasta.Month,hasta.Day, 23,59,59);

            if (txtdesdeEmbarcador.Enabled.Equals(true) && txtdesdeEmbarcador.Text.Length > 0)
                desdeEmbarcadores = new DateTime(txtdesdeEmbarcador.DateTime.Year, txtdesdeEmbarcador.DateTime.Month, txtdesdeEmbarcador.DateTime.Day, 0, 0, 1);

            if (txtHastaEmbarcador.Enabled.Equals(true) && txtHastaEmbarcador.Text.Length > 0)
                hastaEmbarcadores = new DateTime(txtHastaEmbarcador.DateTime.Year, txtHastaEmbarcador.DateTime.Month, txtHastaEmbarcador.DateTime.Day, 23, 59, 59);

            if (txtdesdeNavieras.Enabled.Equals(true) && txtdesdeNavieras.Text.Length > 0)
                desdeNavieras = new DateTime(txtdesdeNavieras.DateTime.Year, txtdesdeNavieras.DateTime.Month, txtdesdeNavieras.DateTime.Day, 0, 0, 1);

            if (txthastaNavieras.Enabled.Equals(true) && txthastaNavieras.Text.Length > 0)
                hastaNavieras = new DateTime(txthastaNavieras.DateTime.Year, txthastaNavieras.DateTime.Month, txthastaNavieras.DateTime.Day, 23, 59, 59);


            if (!string.IsNullOrEmpty(txtNave.Text))
                nave = txtNave.Text;
            
            if (txtUsuario1.Text.Trim() == "")
            {
                usuario1 = -1;
            }
            else
            {
                for (int i = 0; i < ddlUsuario1.Properties.Items.Count; i++)
                {
                    if (ddlUsuario1.Properties.Items[i].ToString().ToUpper() == txtUsuario1.Text.ToUpper())
                        ddlUsuario1.SelectedIndex = i;
                }

                if (ddlUsuario1.SelectedIndex == 0)                
                    usuario1 = -1;
                else
                    usuario1 = ((clsUsuario) ddlUsuario1.SelectedItem).Id;
            }


            if (txtUsuario2.Text.Trim() == "")
            {
                usuario2 = -1;
            }
            else
            {
                for (int i = 0; i < ddlUsuario2.Properties.Items.Count; i++)
                {
                    if (ddlUsuario2.Properties.Items[i].ToString().ToUpper() == txtUsuario2.Text.ToUpper())
                        ddlUsuario2.SelectedIndex = i;
                }

                if (ddlUsuario2.SelectedIndex == 0)
                    usuario2 = -1;
                else
                    usuario2 = ((clsUsuario)ddlUsuario2.SelectedItem).Id;
            }

            if (ddlEstado.SelectedIndex <= 0)
                estado = -1;
            else
                estado = ((Entidades.Paperless.PaperlessEstado) ddlEstado.SelectedItem).Id;

            numconsolidado = !string.IsNullOrEmpty(txtNumConsolidado.Text) ? txtNumConsolidado.Text : "-1";
            
            IList<Entidades.Paperless.PaperlessFlujo> asignaciones =
                LogicaNegocios.Paperless.Paperless.ObtenerAsignaciones(desde, hasta, usuario1, usuario2,estado.ToString(), numconsolidado,nave
                , desdeEmbarcadores, hastaEmbarcadores, desdeNavieras, hastaNavieras, nummaster);
            gridAsignaciones.DataSource = asignaciones;
            //asignaciones[0].Asignacion.ImportanciaUsuario1.Nombre

            gridAsignaciones.RefreshDataSource();
            
        }


        private void Menu_Nuevo_Click(object sender, EventArgs e)
        {
            frmPaperlessAsignacion form = new frmPaperlessAsignacion();
            form.Accion = Enums.TipoAccionFormulario.Nuevo;
            form.ShowDialog();
        }

        private void Menu_Salir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarAsignaciones();
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

        private void Menu_Ver_Click(object sender, EventArgs e)
        {
            Entidades.Paperless.PaperlessFlujo asignacion = ObtenerAsignacion();
            frmPaperlessAsignacion form = frmPaperlessAsignacion.Instancia;

            if (asignacion != null)
            {
                form.PaperlessAsignacionActual = asignacion.Asignacion;
                form.CargarFormulario();
                form.Accion = Enums.TipoAccionFormulario.Editar;
                form.ShowDialog();
                
            }
            else
                MessageBox.Show("Debe seleccionar una asignacion", "Paperless - Asignacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);       
        }

        private void MenuRefrescar_Click(object sender, EventArgs e)
        {
            ListarAsignaciones();
        }

        private void MenuVerRechazo_Click(object sender, EventArgs e)
        {
            Entidades.Paperless.PaperlessFlujo asignacion = ObtenerAsignacion();

            if(asignacion != null)
            {
                Usuario1.frmRechazarAsignacion form = frmRechazarAsignacion.Instancia;
                form.Asignacion = asignacion.Asignacion;
                form.Accion = Enums.TipoAccionFormulario.Consultar;
                form.ShowDialog();    
            }
            
        }

        private void gridAsignaciones_Click(object sender, EventArgs e)
        {
            Entidades.Paperless.PaperlessFlujo asignacion = ObtenerAsignacion();

            MenuVerRechazo.Enabled = false;

            if(asignacion.EstadoFlujo == Enums.EstadoPaperless.RechazadaUsuario1)
            {
                MenuVerRechazo.Enabled = true;
            }
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

        private void btnBuscarAsignaciones_Click(object sender, EventArgs e)
        {
            var tabla = "";

            if (ValidaTabAsignaciones())
            {
                DateTime desdeasignacion = Convert.ToDateTime(txtFechaDesdeAsignacion.Text);
                DateTime hastaasignacion = Convert.ToDateTime(txtFechahastaAsignacion.Text);
                tabla = rdUsuario1.Checked ? "USUARIO1" : "USUARIO2";
                var listaHts = LogicaNegocios.Paperless.Paperless.ObtenerCantidadAsignaciones(tabla, desdeasignacion, hastaasignacion);
                GrdCantAsignaciones.DataSource = listaHts;
                GrdCantAsignaciones.RefreshDataSource();
            }
        }
        private bool ValidaTabAsignaciones()
        {
            const bool valido = true;
            if (string.IsNullOrEmpty(txtFechaDesdeAsignacion.Text))
            {
                MessageBox.Show(@"Debe seleccionar fecha desde ", @"Paperless - Asignacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtFechahastaAsignacion.Text))
            {
                MessageBox.Show(@"Debe seleccionar fecha hasta ", @"Paperless - Asignacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (rdUsuario1.Checked.Equals(false) && rdUsuario2.Checked.Equals(false))
            {
                MessageBox.Show(@"Debe seleccionar Usuario ", @"Paperless - Asignacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return valido;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPuertoSI.Text) || !string.IsNullOrEmpty(txtShippingSI.Text))
            {
                IList<PaperlessUsuario1HousesBL> houses =
                LogicaNegocios.Paperless.Paperless.ObtenerHousesBLporShippingInstruction(txtShippingSI.Text, txtPuertoSI.Text);
                //houses[0].IdAsignacion
                //IList<PaperlessAsignacion> asignaciones = LogicaNegocios.Paperless.Paperless.ObtenerAsignacionPorId()

                grdHbls.DataSource = houses;
                grdHbls.RefreshDataSource();
            } 
        }
      
      
    }
}
