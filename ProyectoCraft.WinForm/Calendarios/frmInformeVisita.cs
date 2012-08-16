using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using ProyectoCraft.Entidades.Calendario;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.Entidades.Ventas.Productos;
using ProyectoCraft.Entidades.GlobalObject;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.LogicaNegocios.Parametros;
using SCCMultimodal.Utils;

namespace ProyectoCraft.WinForm.Calendarios
{
    public partial class frmInformeVisita : Form
    {

        private static frmInformeVisita _form = null;
        public static frmInformeVisita Instancia
        {
            get
            {
                if (_form == null)
                    _form = new frmInformeVisita();

                return _form;
            }
            set
            {
                _form = value;
            }
        }


        private clsVisita _visita;
        public clsVisita Visita
        {
            get { return _visita; }
            set
            {
            	_visita = value;
            }
        }

        //private clsVisitaInforme _informevisita;
        //public clsVisitaInforme InformeVisita
        //{
        //    get { return _informevisita; }
        //    set { _informevisita = value; }
        //}

        private Enums.TipoAccionFormulario _accion;
        public Enums.TipoAccionFormulario Accion
        {
            get { return _accion; }
            set { _accion = value; }
        }


        public frmInformeVisita()
        {
            InitializeComponent();
        }

        private void frmInformeVisita_Load(object sender, EventArgs e)
        {
            CargarProductos();
            CargarInformacioVisita();
            ListarTiposActividad();
            CargarInformVisita();
            ValidarAccionesUsuario();
            CargarVendedores();

            CargarUsuariosParaRespuesta();
            
            if(Accion == Enums.TipoAccionFormulario.Consultar)
            {                
                ConsultarInforme();
            }
                
        }

        private void ListarTiposActividad()
        {
            IList<Entidades.Ventas.Actividades.clsTipoActividad> Tipos =
                LogicaNegocios.Ventas.Actividades.clsAsuntoTipoActividad.ListarTipoActividad();

            ComboBoxItemCollection coll = cboTipoActividad.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in Tipos)
            {
                coll.Add(list);
            }
            cboTipoActividad.SelectedIndex = 0;

        }

        private void CargarUsuariosParaRespuesta()
        {
            IList<clsInformeRespuestaUsuario> lista =
                LogicaNegocios.Calendarios.clsCalendarios.ListarUsuariosParaRespuestaInforme(Visita.Informvisita);

            IList<clsUsuario> usuarios = new List<clsUsuario>();

            foreach (var list in lista)
            {
                usuarios.Add(list.Usuario);
            }

            lstUsuariosRespuesta.DataSource = usuarios;
            
            if(this.Visita.Informvisita != null)
            {
                if(Visita.Informvisita.EsBorrador)
                {                    
                    chkRequiereRespuesta.Checked = true;
                    txtUsuarioRespuesta.Enabled = true;
                    btnAgregar.Enabled = true;
                    btnEliminar.Enabled = true;
                    lstUsuariosRespuesta.Enabled = true;                    
                }
            }            
        }

        private void CargarVendedores()
        {
            ResultadoTransaccion res = LogicaNegocios.Usuarios.clsUsuarios.ListarUsuarios(Enums.Estado.Habilitado, Enums.CargosUsuarios.Todos);
            IList<clsUsuario> listVendedores = (IList<clsUsuario>)res.ObjetoTransaccion;

            ComboBoxItemCollection coll = cboUsuariosRespuesta.Properties.Items;
            coll.Add(Utils.Utils.ObtenerPrimerItem());
            foreach (var list in listVendedores)
            {
                coll.Add(list);
            }
            cboUsuariosRespuesta.SelectedIndex = 0;
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Add(txtUsuarioRespuesta.Text);

            foreach (var list in listVendedores)
            {
                auto.Add(list.Nombre + " " + list.ApellidoPaterno + " " + list.ApellidoMaterno);
            }

            txtUsuarioRespuesta.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtUsuarioRespuesta.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtUsuarioRespuesta.MaskBox.AutoCompleteCustomSource = auto;

        }

        private void ConsultarInforme()
        {
            MenuGuardar.Visible = false;
            MenuGuardarBorrador.Visible = false;
            txtExpectativaCierre.Properties.ReadOnly = true;
            txtFollowUp.Properties.ReadOnly = true;
            txtResumen.Properties.ReadOnly = true;
            lstProductos.Enabled = false;
            lstTraficos.Enabled = false;
            chkRequiereRespuesta.Enabled = false;
            btnAgregar.Visible = false;
            btnEliminar.Visible = false;
        }

        private void ValidarAccionesUsuario()
        {
            bool bloquear = false;


            if (!Visita.EsReunionInterna)
                bloquear = Visita.Vendedor.Id != Base.Usuario.UsuarioConectado.Usuario.Id &&
                           Visita.UsuarioOrganizador.Id != Base.Usuario.UsuarioConectado.Usuario.Id;
            else
                bloquear = Visita.UsuarioOrganizador.Id != Base.Usuario.UsuarioConectado.Usuario.Id;

            if (bloquear)
            {
                MenuGuardar.Visible = false;
                MenuGuardarBorrador.Visible = false;
                MenuReenviarInforme.Visible = false;
                return;
            }

            if (Visita.Informvisita == null || Visita.Informvisita.EsBorrador)
            {
                MenuListarComentarios.Visible = false;
                MenuComentar.Visible = false;
                MenuReenviarInforme.Visible = false;
                MenuBitacora.Visible = false;
            }
            else
            {                
                if (Visita.EstadoBD == Enums.VisitaEstado.Realizada_Con_Informe || Visita.EstadoBD == Enums.VisitaEstado.Realizada_Con_Informe_Fuera_De_Plazo)                
                    MenuReenviarInforme.Visible = true;                
                else
                    MenuReenviarInforme.Visible = false;
            }

            if (Visita.Cliente == null)
                MenuBitacora.Visible = false;
            else
                MenuBitacora.Visible = true;

        }


        private void CargarInformacioVisita()
        {
            txtAsunto.Text = Visita.Asunto;
            if(Visita.Cliente != null)
                txtCliente.Text = Visita.Cliente.NombreCliente + " (" + Visita.Cliente.NombreFantasia + ")";

            txtFechaINicio.Text = Visita.FechaHoraComienzo.ToString();
            txtFechaTermino.Text = Visita.FechaHoraTermino.ToString();            
        }

        private void CargarProductos()
        {            
            IList<clsTipoProducto> productos =
                  clsParametros.ListarProductos("S");

            lstProductos.DataSource = productos;


            Entidades.GlobalObject.ResultadoTransaccion res = LogicaNegocios.Ventas.Productos.clsTipoProducto.ListarTiposTraficos();
            if(res.Estado == Enums.EstadoTransaccion.Aceptada)
            {
                IList<Entidades.Ventas.Traficos.clsTrafico> traficos = (IList<Entidades.Ventas.Traficos.clsTrafico>)res.ObjetoTransaccion;

                lstTraficos.DataSource = traficos;

            }
                           
        }

        private ResultadoTransaccion GuardarInformeVisita(bool borrador)
        {
            Visita.Informvisita = LlenarObjetoInforme();

            if (borrador)
                Visita.Informvisita.EsBorrador = true;
            else
                Visita.Informvisita.EsBorrador = false;

            ResultadoTransaccion resultado = LogicaNegocios.Calendarios.clsCalendarios.GuardarInformeVisita(Visita.Informvisita);

            if(resultado.Estado == Enums.EstadoTransaccion.Aceptada)
            {
                Visita.Informvisita = (clsVisitaInforme)resultado.ObjetoTransaccion;
            }


            return resultado;
        }


        /// <summary>
        /// Guarda Borrador
        /// </summary>        
        private void MenuGuardar_Click(object sender, EventArgs e)
        {
            var mail = new EnvioMailObject();
            if(!ValidarFormulario())return;

            ResultadoTransaccion resultado = GuardarInformeVisita(false);

            if(resultado.Estado == Enums.EstadoTransaccion.Aceptada)
            {
                clsVisitaInforme informe = (clsVisitaInforme)resultado.ObjetoTransaccion;

                if (Visita.EstadoBD == Enums.VisitaEstado.No_Realizada)
                    Visita.EstadoBD = Enums.VisitaEstado.Realizada_Con_Informe_Fuera_De_Plazo;
                else 
                    Visita.EstadoBD = Enums.VisitaEstado.Realizada_Con_Informe;

                LogicaNegocios.Calendarios.clsCalendarios.GuardarVisita(Visita);

                Visita.Informvisita = new clsVisitaInforme();
                Visita.Informvisita = informe;
                mail.EnviarEmailInformeVisita(informe, Visita);
                //Utils.EnvioEmail.EnviarEmailInformeVisita(informe, Visita);

                EnviarEmailRequiereRespuesta();

                MessageBox.Show("El Informe a sido guardado exitosamente", "Informe de visita", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);


                Instancia = null;
                this.Close();
            }
            else
            {
                MessageBox.Show(resultado.Descripcion, "Calendario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void EnviarEmailRequiereRespuesta()
        {
            var mail = new EnvioMailObject();
            if(!chkRequiereRespuesta.Checked) return;

            IList<clsUsuario> lista = (IList<clsUsuario>) lstUsuariosRespuesta.DataSource;

            if (lista == null) return;

            mail.EnviarAvisoInformeRequiereRespuesta(lista, Visita);
            //Utils.EnvioEmail.EnviarAvisoInformeRequiereRespuesta(lista, Visita);            
        }

        //private void EnviarEmailInformeVisita(clsVisitaInforme informe)
        //{
        //    Entidades.Emails.PlantillaEmail plantilla =
        //        LogicaNegocios.Emails.clsEmails.ObtenerPlantillaPorTipo(Enums.EmailTipoPlantilla.InformeVisita);

        //    if(plantilla != null)
        //    {
        //        string body = plantilla.TextoPlantilla;
        //        string productos = "";
        //        string traficos = "";

        //        foreach (var producto in informe.Productos)
        //        {
        //            productos += producto.Producto.Nombre + " / ";
        //        }

        //        foreach (var trafico in informe.Traficos)
        //        {
        //            traficos += trafico.Trafico.Nombre + " / ";
        //        }

        //        body = string.Format(body, Visita.Vendedor.NombreCompleto, Visita.Cliente.NombreCompañia, productos,
        //                             traficos, informe.EspectativaCierre, informe.FollowUp, informe.ResumenVisita);

        //        ResultadoTransaccion res = new ResultadoTransaccion();
        //        foreach (var asistentes in Visita.AsistentesCraft)
        //        {
        //            if (asistentes.Confirmo == Enums.VisitaEstadoAsistente.ConfirmoAsistencia)
        //            {
        //               res = Utils.EnvioEmail.EnviarEmail(asistentes.Usuario.Email, "Informe Visita: " + Visita.Asunto, body);
        //               if(res.Estado == Enums.EstadoTransaccion.Rechazada)
        //                   res.Errores.Add(res.Descripcion);
        //            }
                        
        //        }
        //    }
        //}

        private clsVisitaInforme LlenarObjetoInforme()
        {
            if(Visita.Informvisita == null) Visita.Informvisita = new clsVisitaInforme();

            Visita.Informvisita.Visita = Visita;
            Visita.Informvisita.TieneEspectativaCierre = chkTieneEspectativa.Checked;
            if (!Visita.Informvisita.TieneEspectativaCierre)
                Visita.Informvisita.EspectativaCierre = -1;
            else
                Visita.Informvisita.EspectativaCierre = Convert.ToInt16(txtExpectativaCierre.Text);


            Visita.Informvisita.OtroTema = chkOtroTema.Checked;

            //if(txtFollowUp.Text != "")
            //    Visita.Informvisita.FollowUp = txtFollowUp.DateTime;
            //else
            //    Visita.Informvisita.FollowUp = new DateTime(9999, 1, 1);

            Visita.Informvisita.IdUsuario = Base.Usuario.UsuarioConectado.Usuario.Id;
            Visita.Informvisita.ResumenVisita = txtResumen.Text;

            foreach (clsTipoProducto producto in lstProductos.CheckedItems)
            {
                Visita.Informvisita.Productos.Add(new clsVisitaInformeProductos(producto));
            }

            foreach (Entidades.Ventas.Traficos.clsTrafico trafico in lstTraficos.CheckedItems)
            {
                Visita.Informvisita.Traficos.Add(new clsVisitaInformeTrafico(trafico));
            }

            Visita.Informvisita.RequiereRespuesta = chkRequiereRespuesta.Checked;
            if (Visita.Informvisita.RequiereRespuesta)
            {
                foreach (var user in (IList<clsUsuario>)lstUsuariosRespuesta.DataSource)
                {
                    clsInformeRespuestaUsuario u = new clsInformeRespuestaUsuario();
                    u.Usuario = user;
                    Visita.Informvisita.UsuariosParaRespuesta.Add(u);
                }    
            }



            if (txtFollowUp.Text != "")
                Visita.Informvisita.FollowUp.FechaFollowUp = txtFollowUp.DateTime;
            else
                Visita.Informvisita.FollowUp.FechaFollowUp = new DateTime(9999, 1, 1);

            if (Visita.EsReunionInterna)
                Visita.Informvisita.FollowUp.Cliente.Id = -1;
            else 
                Visita.Informvisita.FollowUp.Cliente = Visita.Cliente;

            Visita.Informvisita.FollowUp.Descripcion = txtDescripcionFollowUp.Text.Trim();
            if (cboTipoActividad.SelectedIndex > 0)
                Visita.Informvisita.FollowUp.TipoActividad = (Entidades.Ventas.Actividades.clsTipoActividad)cboTipoActividad.SelectedItem;
            else
                Visita.Informvisita.FollowUp.TipoActividad = null;
            Visita.Informvisita.FollowUp.IdInformeVisita = Visita.Informvisita.Id;
            Visita.Informvisita.FollowUp.IdLlamadaTelefonica = -1;
            Visita.Informvisita.FollowUp.FechaCreacion = DateTime.Now;
            Visita.Informvisita.FollowUp.Usuario = Base.Usuario.UsuarioConectado.Usuario;

            return Visita.Informvisita;
        }

        private bool ValidarFormulario()
        {
            bool valida = true;

            dxErrorProvider1.ClearErrors();
          
            if(chkTieneEspectativa.Checked && Convert.ToInt16(txtExpectativaCierre.Text) == 0 )
            {
                valida = false;
                dxErrorProvider1.SetError(txtExpectativaCierre, "Debe ingresar Espectativa de Cierre", ErrorType.Critical);
            }


            if(txtFollowUp.Text == "")
            {
                valida = false;
                dxErrorProvider1.SetError(txtFollowUp, "Debe ingresar Follow Up", ErrorType.Critical);
            }

            if(txtResumen.Text == "")
            {
                valida = false;
                dxErrorProvider1.SetError(txtResumen, "Debe ingresar un resumen de la visita", ErrorType.Critical);
            }

            return valida;
        }

        private void CargarInformVisita()
        {            
            if (Visita.Informvisita == null)
            {
                ResultadoTransaccion resInforme = LogicaNegocios.Calendarios.clsCalendarios.ObtenerInformeVisitaPor(-1,
                                                                                                             Visita.Id);
                if (resInforme.Estado == Enums.EstadoTransaccion.Aceptada)
                {
                    Visita.Informvisita = (clsVisitaInforme)resInforme.ObjetoTransaccion;
                }
                else
                {
                    MessageBox.Show(resInforme.Descripcion, "Informe de Visita", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
                  
            if(Visita.Informvisita != null)
                DominioAVista(Visita.Informvisita);
            
        }

        private void DominioAVista(clsVisitaInforme informe)
        {
            if (informe.EspectativaCierre == -1)
                txtExpectativaCierre.Text = "";
            else 
                txtExpectativaCierre.Text = informe.EspectativaCierre.ToString();
            
            txtResumen.Text = informe.ResumenVisita;
            chkOtroTema.Checked = informe.OtroTema;
            chkTieneEspectativa.Checked = informe.TieneEspectativaCierre;

            for (int i = 0; i <= lstProductos.Items.Count - 1; i++)
            {
                clsTipoProducto producto = (clsTipoProducto)lstProductos.Items[i];
                foreach (clsVisitaInformeProductos productoInforme in informe.Productos)
                {                    
                    if (producto.Id == productoInforme.Producto.Id)
                    {
                        lstProductos.SetItemChecked(i, true);
                        break;
                    }                    
                }
            }


            for (int i = 0; i <= lstTraficos.Items.Count - 1; i++)
            {
                Entidades.Ventas.Traficos.clsTrafico trafico = (Entidades.Ventas.Traficos.clsTrafico)lstTraficos.Items[i];
                foreach (clsVisitaInformeTrafico traficoInforme in informe.Traficos)
                {
                    if (trafico.Id == traficoInforme.Trafico.Id)
                    {
                        lstTraficos.SetItemChecked(i, true);
                        break;
                    }
                }
            }

            if(informe.FollowUp != null)
            {
                if (informe.FollowUp.FechaFollowUp.HasValue)
                    txtFollowUp.Text = informe.FollowUp.FechaFollowUp.Value.ToShortDateString();

                if (informe.FollowUp.TipoActividad == null)
                    cboTipoActividad.SelectedIndex = 0;
                else                
                    cboTipoActividad.SelectedItem = informe.FollowUp.TipoActividad;
                                    
                txtDescripcionFollowUp.Text = informe.FollowUp.Descripcion;
            }


            //for (int i = 0; i <= lstTraficos.Items.Count - 1; i++)
            //{
            //    clsTipoProducto producto = (clsTipoProducto)lstProductos.Items[i];
            //    foreach (clsVisitaInformeProductos productoInforme in informe.Productos)
            //    {
            //        if (producto.Id == productoInforme.Id)
            //        {
            //            lstProductos.SetItemChecked(i, true);
            //            break;
            //        }
            //    }
            //} 

        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Instancia = null;
            this.Close();
        }

        private void chkTieneEspectativa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTieneEspectativa.Checked) txtExpectativaCierre.Enabled = true;
            else txtExpectativaCierre.Enabled = false;
               
        }

        private void chkRequiereRespuesta_CheckedChanged(object sender, EventArgs e)
        {
            if(chkRequiereRespuesta.Checked)
            {
                labelControl10.Enabled = true;
                txtUsuarioRespuesta.Enabled = true;
                btnAgregar.Enabled = true;
                btnEliminar.Enabled = true;
                lstUsuariosRespuesta.Enabled = true;
            }
            else
            {
                labelControl10.Enabled = false;
                txtUsuarioRespuesta.Enabled = false;
                btnAgregar.Enabled = false;
                btnEliminar.Enabled = false;
                lstUsuariosRespuesta.Enabled = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtUsuarioRespuesta.Text == "")return;
            clsUsuario usuariorespuesta = null;

            for (int i = 0; i < cboUsuariosRespuesta.Properties.Items.Count; i++)
            {
                if (cboUsuariosRespuesta.Properties.Items[i].ToString() == txtUsuarioRespuesta.Text)
                    cboUsuariosRespuesta.SelectedIndex = i;
            }

            if (cboUsuariosRespuesta.SelectedIndex != 0)
            {
                usuariorespuesta = (clsUsuario)this.cboUsuariosRespuesta.SelectedItem;
            }else
            {
                MessageBox.Show("El usuario no se encuentra.", "Informe de visita", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }

            IList<clsUsuario> listusuarios = (IList<clsUsuario>)lstUsuariosRespuesta.DataSource;
            if(listusuarios == null) listusuarios = new List<clsUsuario>();

            if (usuariorespuesta != null)
            {
                listusuarios.Add(usuariorespuesta);
                lstUsuariosRespuesta.DataSource = listusuarios;
            }            

            txtUsuarioRespuesta.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(lstUsuariosRespuesta.SelectedItem== null) return;
            clsUsuario selected = (clsUsuario)lstUsuariosRespuesta.SelectedItem;


            IList<clsUsuario> listaorigen = (IList<clsUsuario>)lstUsuariosRespuesta.DataSource;
            IList<clsUsuario> listanueva = new List<clsUsuario>(); 
            foreach (var list in listaorigen)
            {
                if(list.Id != selected.Id)
                    listanueva.Add(list);
            }

            lstUsuariosRespuesta.DataSource = listanueva;

        }

        private void MenuGuardarBorrador_Click(object sender, EventArgs e)
        {            
            ResultadoTransaccion resultado = GuardarInformeVisita(true);

            if (resultado.Estado == Enums.EstadoTransaccion.Aceptada)
            {                                
                MessageBox.Show("El Borrador del Informe a sido guardado exitosamente", "Informe de visita", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                Instancia = null;
                this.Close();
            }
            else
            {
                MessageBox.Show(resultado.Descripcion, "Calendario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void MenuListarComentarios_Click(object sender, EventArgs e)
        {
            frmListarComentarios form = frmListarComentarios.Instancia;
            form.Visita = this.Visita;
            form.ShowDialog();
        }

        private void MenuComentar_Click(object sender, EventArgs e)
        {
            frmComentarioVisita form = frmComentarioVisita.Instancia;
            form.Visita = this.Visita;
            form.DesdeListado = false;
            form.ShowDialog();
        }

        private void MenuReenviarInforme_Click(object sender, EventArgs e)
        {
            var mail = new EnvioMailObject();
            DialogResult resdialogo = MessageBox.Show("Reenviara el Informe a todos los destinatarios, ¿Desea continuar?", "Informe de Visita", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resdialogo == DialogResult.Yes)
            {
                mail.EnviarEmailInformeVisita(Visita.Informvisita, Visita);
                //Utils.EnvioEmail.EnviarEmailInformeVisita(Visita.Informvisita, Visita);

                MessageBox.Show("El Informe a sido Reenviado.", "Informe de visita", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }            
        }

        private void MenuBitacora_Click(object sender, EventArgs e)
        {
            Clientes.frmClienteFollowUp form = Clientes.frmClienteFollowUp.Instancia;

            form.Cliente = Visita.Cliente;
            form.ShowDialog();


        }
    }
}
