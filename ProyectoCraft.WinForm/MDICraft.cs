using System;
using System.Collections.Generic;
//using System.Linq;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraNavBar;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Log;
using ProyectoCraft.Entidades.Perfiles;
using ProyectoCraft.Entidades.Usuarios;
using ProyectoCraft.LogicaNegocios.Log;
using ProyectoCraft.LogicaNegocios.Usuarios;
using ProyectoCraft.WinForm.Clientes;
using ProyectoCraft.WinForm.Direccion.Administracion;
using ProyectoCraft.WinForm.Paperless.Asignacion;
using ProyectoCraft.WinForm.Paperless.Usuario1;
using ProyectoCraft.WinForm.Paperless.Usuario2;
using SCCMultimodal;
using SCCMultimodal.Cotizaciones;
using SCCMultimodal.Mantenedores;
using SCCMultimodal.Panel_de_control;


namespace ProyectoCraft.WinForm
{

    public partial class MDICraft : Form
    {
        public bool? MostrarPanel = null;
        private int childFormNumber = 0;
        private List<ClsPanelDeControl> panelDecontrols;
        private ClsPanelDeControl panelDeControlSeleccionado;

        public MDICraft()
        {
            InitializeComponent();
            panelDecontrols = new List<ClsPanelDeControl>();
        }

        private static MDICraft _form = null;
        public static MDICraft Instancia
        {
            get
            {
                if (_form == null)
                    _form = new MDICraft();

                return _form;
            }
            set
            {
                _form = value;
            }
        }


        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDICraft_Load(object sender, EventArgs e)
        {
            // #1
            foreach (Control control in this.Controls)
            {
                // #2
                MdiClient client = control as MdiClient;
                if (!(client == null))
                {
                    // #3
                    client.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                    // 4#
                    break;
                }
            }
            Text = "Sistema Comercial Craft V." + SCCMultimodal.SCCVersion.CurrentVersion;

            ValidarUsuarioConectado();

            //HABILITAR PARA VALIDAR FUNCIONALIDADES
            HabilitarFuncionalidades();
            navBarControl1.Groups[0].Expanded = true;

            //mostrando el panel de control
            if (Base.Usuario.UsuarioConectado.Usuario.Perfiles != null && Base.Usuario.UsuarioConectado.Usuario.Perfiles.Count > 0)
                //if (Base.Usuario.UsuarioConectado.Usuario.Perfiles[0].PanelDeControl != null) 
                //{
                foreach (var clsPerfil in Base.Usuario.UsuarioConectado.Usuario.Perfiles)
                {
                    if (clsPerfil.PanelDeControl != null && !String.IsNullOrEmpty(clsPerfil.PanelDeControl.XmlFile))
                    {
                        panelDecontrols.Add(clsPerfil.PanelDeControl);
                    }
                }
            //}

            foreach (var clsPanelDeControl in panelDecontrols)
            {
                ToolStripMenuItem item1 = new ToolStripMenuItem(clsPanelDeControl.Nombre);
                item1.Name = "panel_" + clsPanelDeControl.Id.ToString();
                //item1.Click += changePanelDeControl(item1,new EventHandler());
                item1.Click += new EventHandler(ChangePanelDeControl);
                toolStripDropDownButton1.DropDown.Items.Add(item1);
            }


            timer2.Interval = 90;
            timer2.Start();

            toolStripSplitButton2.Alignment = ToolStripItemAlignment.Right;
            toolStripSplitButton1.Alignment = ToolStripItemAlignment.Right;
            toolStripDropDownButton1.Alignment = ToolStripItemAlignment.Right;

            if (panelDecontrols.Count == 0)
            {
                toolStripSplitButton2.Visible =
                    toolStripSplitButton1.Visible =
                    toolStripDropDownButton1.Visible = false;
                timer2.Stop();
            }

            if (panelDecontrols.Count == 1)
                toolStripDropDownButton1.Visible = false;

            if (panelDecontrols.Count > 0)
            {
                try
                {
                    panelDeControlSeleccionado = panelDecontrols[0];
                    GenerarPanelDeControl();
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }

            //Cargamos la configuracion
            var configuracion = Base.Configuracion.Configuracion.Instance();
        }

        public void ChangePanelDeControl(object sender, EventArgs e)
        {
            var idPanel = ((ToolStripMenuItem)sender).Name;
            idPanel = idPanel.Replace("panel_", "");
            var panel = panelDecontrols.Find(delegate(ClsPanelDeControl foo) { return foo.Id.ToString() == idPanel; });
            if (panel != null)
            {
                panelDeControlSeleccionado = panel;
                DestruirPanelDeControl();
                GenerarPanelDeControl(panel);
            }
        }

        private void GenerarPanelDeControl()
        {
            GenerarPanelDeControl(panelDeControlSeleccionado);
        }

        private void GenerarPanelDeControl(ClsPanelDeControl panelDeControl)
        {
            if (panelDecontrols != null)
            {
                PanelDecontrol foo = new PanelDecontrol();
                foo.LoadControls(panelDeControl.XmlFile);
                foo.Generate();
                foo.Dispose(this);
            }
        }

        private void DestruirPanelDeControl()
        {
            foreach (Control control in Controls)
                if (control is Panel)
                    Controls.Remove(control);
        }

        private void OcultaControlesPanel()
        {
            foreach (Control control in Controls)
            {
                if (control is Panel)
                {
                    control.Visible = false;
                }
            }
        }
        private void MostrarControlesPanel()
        {
            foreach (Control control in Controls)
            {
                if (control is Panel)
                {
                    control.Visible = true;
                }
            }
        }

        private void Client_gotfocus(object sender, EventArgs e)
        {
        }

        private void Client_lostfocus(object sender, EventArgs e)
        {
        }

        private void DeshabilitarFuncionalidads()
        {
            MenuPaperlessAsignacion.Visible = false;
            MenuPaperlessAsignar.Visible = false;
            MenuPaperlessUsuario1.Visible = false;
            MenuPaperlessUsuario2.Visible = false;
            MenuPaperlessGestion.Visible = false;
            MenuCotizaciones.Visible = false;
            menuAdministracion.Visible = false;
        }

        private void HabilitarFuncionalidades()
        {
            string[] l = null;
            if (System.Configuration.ConfigurationSettings.AppSettings.Get("SupervisorDocumental") != null)
                l = System.Configuration.ConfigurationSettings.AppSettings.Get("SupervisorDocumental").Split(',');
            if (l != null)
            {
                var super = l.Select(s => Convert.ToInt64(s)).ToList();

                if (super.Contains(Base.Usuario.UsuarioConectado.Usuario.Id))
                {
                    var c = new clsUsuarioCargo(15, "SupervisorDocumental");
                    Base.Usuario.UsuarioConectado.Usuario.Cargos.Add(c);
                    var p = new clsPerfil();
                    p.Id = 15;
                    p.Nombre = "SupervisorDocumental";
                    p.PanelDeControl = new ClsPanelDeControl();
                    p.PanelDeControl.Id = 1;
                    p.PanelDeControl.Nombre = "panel Papperless";
                    p.PanelDeControl.XmlFile = "panel1.xml";
                    Base.Usuario.UsuarioConectado.Usuario.Perfiles.Add(p);
                }
            }

            DeshabilitarFuncionalidads();

            foreach (var clsPerfil in Base.Usuario.UsuarioConectado.Usuario.Perfiles)
            {
                if (clsPerfil.Id == (int)Enums.UsuariosCargo.Supervisor_Documental)
                {
                    MenuPaperlessAsignacion.Visible = true;
                    MenuPaperlessAsignar.Visible = true;
                }
                if (clsPerfil.Id == (int)Enums.UsuariosCargo.Encargado_Documental_1ra_Etapa)
                {
                    MenuPaperlessUsuario1.Visible = true;
                    MenuPaperlessUsuario1.Caption = "Primera Etapa - Mis Asignaciones";
                }
                if (clsPerfil.Id == (int)Enums.UsuariosCargo.Encargado_Documental_2da_Etapa)
                {
                    MenuPaperlessUsuario2.Visible = true;
                    MenuPaperlessUsuario2.Caption = "Segunda Etapa - Mis Asignaciones";
                }
                if (clsPerfil.Id != (int)Enums.UsuariosCargo.Customer_Service && clsPerfil.Id != (int)Enums.UsuariosCargo.Vendedor)
                {
                    MenuPaperlessGestion.Visible = true;
                }

                if (clsPerfil.Id != (int)Enums.UsuariosCargo.Customer_Service && clsPerfil.Id != (int)Enums.UsuariosCargo.Vendedor)
                {
                    MenuPaperlessGestion.Visible = true;
                }

                if (clsPerfil.Id == (int)Enums.UsuariosCargo.Vendedor)
                {
                    MenuCotizaciones.Visible = true;
                }



                if (clsPerfil.Nombre.ToString().Equals(Enums.UsuariosCargo.AdministradorDatosMaestros.ToString()))
                {
                    menuAdministracion.Visible = true;
                }


            }

            /*foreach (var cargo in Base.Usuario.UsuarioConectado.Usuario.Cargos) {
                if (cargo.CargoEnum == Enums.UsuariosCargo.Supervisor_Documental) {
                    MenuPaperlessAsignacion.Visible = true;
                    MenuPaperlessAsignar.Visible = true;
                }

                if (cargo.CargoEnum == Enums.UsuariosCargo.Encargado_Documental_1ra_Etapa) {
                    MenuPaperlessUsuario1.Visible = true;
                    MenuPaperlessUsuario1.Caption = "Primera Etapa - Mis Asignaciones";
                }

                if (cargo.CargoEnum == Enums.UsuariosCargo.Encargado_Documental_2da_Etapa) {
                    MenuPaperlessUsuario2.Visible = true;
                    MenuPaperlessUsuario2.Caption = "Segunda Etapa - Mis Asignaciones";
                }

                if (cargo.CargoEnum != Enums.UsuariosCargo.Customer_Service &&
                    cargo.CargoEnum != Enums.UsuariosCargo.Vendedor
                    ) {
                    MenuPaperlessGestion.Visible = true;
                }
            }*/
        }


        private void ValidarUsuarioConectado()
        {
            string username = WindowsIdentity.GetCurrent().Name;
            string[] dominiousuario = username.Split('\\');

            if (dominiousuario.Length == 2)
                username = dominiousuario[1];
            else
            {
                MessageBox.Show("No se pudo obtener el nombre de usuario o el dominio", "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            string UsuarioConectado = System.Configuration.ConfigurationSettings.AppSettings.Get("UsuarioConectado");
            if (UsuarioConectado.Trim() != "")
                username = UsuarioConectado;

            Entidades.GlobalObject.ResultadoTransaccion resultado =
                LogicaNegocios.Usuarios.clsUsuarios.ValidaUsuarioAutorizado(username);

            if (resultado.Estado == Entidades.Enums.Enums.EstadoTransaccion.Rechazada)
            {
                MessageBox.Show(resultado.Descripcion, "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            else
            {
                if (resultado.ObjetoTransaccion == null)
                {
                    MessageBox.Show(resultado.Descripcion, "Autorización SCC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
                else
                {
                    Base.Usuario.UsuarioConectado.Usuario = (clsUsuario)resultado.ObjetoTransaccion;
                    Base.Usuario.UsuarioConectado.HoraInicioConexion = DateTime.Now;

                    string usuarioConectado = "Usuario Conectado: ";
                    usuarioConectado += Base.Usuario.UsuarioConectado.Usuario.NombreCompleto;
                    usuarioConectado += ":" + Base.Usuario.UsuarioConectado.BasedeDatos;

                    //usuarioConectado += " Cargo: ";
                    //usuarioConectado += Base.Usuario.UsuarioConectado.Usuario.Cargo.Nombre;

                    IList<clsUsuarioCargo> cargos = LogicaNegocios.Usuarios.clsUsuarios.ObtenerCargosUsuario(username);
                    Base.Usuario.UsuarioConectado.Usuario.Cargos = cargos;

                    var perfiles = clsUsuarios.ObtenerPerfilesUsuarios(Base.Usuario.UsuarioConectado.Usuario.Id32).ObjetoTransaccion as List<clsPerfil>;
                    if (perfiles == null || perfiles.Count == 0)
                    {
                        MessageBox.Show("No Tiene ningun perfil Asignado.", "Autorización SCC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Application.Exit();
                    }
                    else
                    {
                        Base.Usuario.UsuarioConectado.Usuario.Perfiles = perfiles;
                    }

                    UsuarioConectadoBar.Text = usuarioConectado;
                    UsuarioConectadoBar.Alignment = ToolStripItemAlignment.Right;
                }
            }
        }

        private void MenuTarget_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            Clientes.Target.frmListarTarget form = Clientes.Target.frmListarTarget.Instancia;
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        private void MenuCalendario_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            Calendarios.frmCalendario form = Calendarios.frmCalendario.Instancia;
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }



        public void MensajeAccion(Entidades.Enums.Enums.TipoAccionFormulario accion)
        {
            timer1.Enabled = true;
            timer1.Interval = 5000;
            timer1.Start();


            statusMensaje.Visible = true;
            if (accion == Entidades.Enums.Enums.TipoAccionFormulario.Nuevo)
                this.statusMensaje.Text = "Registro fue Guardado exitosamente";
            if (accion == Entidades.Enums.Enums.TipoAccionFormulario.Editar)
                this.statusMensaje.Text = "Registro fue Actualizado exitosamente";
            if (accion == Entidades.Enums.Enums.TipoAccionFormulario.Eliminar)
                this.statusMensaje.Text = "Registro fue Eliminado exitosamente";
            if (accion == Entidades.Enums.Enums.TipoAccionFormulario.CambiarEstado)
                this.statusMensaje.Text = "Registro fue cambiado de estado exitosamente";
        }

        private void MenuCalendarioCompartido_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            //Calendarios.CalendarioCompartido form = Calendarios.CalendarioCompartido.Instancia;
            Calendarios.frmCalendarioCompartido form = Calendarios.frmCalendarioCompartido.Instancia;
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        private void MenuCambiarCuenta_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            Clientes.Cuenta.frmListarCuenta form = Clientes.Cuenta.frmListarCuenta.Instancia;
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        private void MenuListarContacto_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            Clientes.Contacto.frmListarContacto form = Clientes.Contacto.frmListarContacto.Instancia;
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        private void MenuEnviareMailCliente_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            Ventas.Actividades.EMail.FrmNuevoMail form = Ventas.Actividades.EMail.FrmNuevoMail.Instancia;
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        private void MenuRegistrarLlamada_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            //Ventas.Actividades.Llamadas_Telefonicas.FrmLlamadaTelefonica form = Ventas.Actividades.Llamadas_Telefonicas.FrmLlamadaTelefonica.Instancia;
            //form.MdiParent = this;
            //form.Show();
            Ventas.Actividades.Llamadas_Telefonicas.FrmListarLlamadas form = Ventas.Actividades.Llamadas_Telefonicas.FrmListarLlamadas.Instancia;
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        private void MenuConsultarDueda_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            frmConsultarDEuda form = Direccion.Administracion.frmConsultarDEuda.Instancia;
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            statusMensaje.Visible = false;
        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {

        }

        private void MenuDefinirLineaCredito_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            frmDefinirLineaCredito form = Direccion.Administracion.frmDefinirLineaCredito.Instancia;
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        private void MenuConsultarLineaCredito_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            frmLineaCreditoClientes form = Direccion.Administracion.frmLineaCreditoClientes.Instancia;
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        private void MenuConsultarVisitas_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            Calendarios.frmConsultarVisitas form = Calendarios.frmConsultarVisitas.Instancia;
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        private void MenuTargetAccount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            Clientes.TargetAccount.frmTargetAccount form = Clientes.TargetAccount.frmTargetAccount.Instancia;
            form.MdiParent = this;
            form.IdTargetSource = 15;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }
        private void MantenedorNavieras_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            Clientes.frmNavieras form = Clientes.frmNavieras.Instancia;
            //Clientes.TargetAccount.frmTargetAccount form = Clientes.TargetAccount.frmTargetAccount.Instancia;
            form.MdiParent = this;
            //form.IdTargetSource = 15;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        private void MenuDefinirTarget_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            Direccion.Metas.frmDefinirMeta form = Direccion.Metas.frmDefinirMeta.Instancia;
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        private void MenuTargets_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            Ventas.Metas.frmRevisarAsigMetas form = Ventas.Metas.frmRevisarAsigMetas.Instancia;
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        private void MenuGestionTarger_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            Direccion.Metas.frmGestionarMetas form = Direccion.Metas.frmGestionarMetas.Instancia;
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        private void MenuListarAsignaciones_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            var form = new frmListaAsignaciones();
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        private void MenuListarUsuario1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            frmListarUsuario1 form = frmListarUsuario1.Instancia;
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        private void MenuListarUsuario2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            frmListarUsuario2 form = new frmListarUsuario2();
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        private void MenuPaperlessAsignar_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            frmPaperlessAsignacion form = Paperless.Asignacion.frmPaperlessAsignacion.Instancia;
            form.Accion = Enums.TipoAccionFormulario.Nuevo;
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
            form.ShowDialog();
        }

        private void MenuPaperlessGestion_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            Paperless.Gestion.frmGestionPaperless form = Paperless.Gestion.frmGestionPaperless.Instancia;
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }


        private void MenuDefinirSLead_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            Direccion.Metas.frmDefinirSLead form = Direccion.Metas.frmDefinirSLead.Instancia;
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        private void MenuGestionSLead_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            Direccion.Metas.frmGestionarSLead form = Direccion.Metas.frmGestionarSLead.Instancia;
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        private void MenuAsignacionSLead_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            Ventas.Metas.frmRevisarAsigSalesLead form = Ventas.Metas.frmRevisarAsigSalesLead.Instancia;
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        private void MenuDefinirAgentes_click(object sender, NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            var form = frmDefinirAgente.Instancia;
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        private void timer2_tick(object sender, EventArgs e)
        {
            if (MostrarPanel == null || MostrarPanel == true)
            {
                if (MdiChildren.Length > 0)
                {
                    OcultaControlesPanel();
                }
                else
                {
                    if (MostrarPanel == null || MostrarPanel == true)
                    {
                        MostrarControlesPanel();
                    }
                }
            }

        }


        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                if (control is Panel)
                {
                    control.Visible = !control.Visible;
                    MostrarPanel = control.Visible;
                    if (MostrarPanel == false)
                        timer2.Stop();
                    else
                        timer2.Start();
                }
            }
        }

        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {
            DestruirPanelDeControl();
            GenerarPanelDeControl();
        }

        private void MantenedorComunas_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            Clientes.frmComunas form = Clientes.frmComunas.Instancia;
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }
        private void CotizacionesLinkClicked(object sender, NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            Cotizaciones.FrmListarCotizaciones form = Cotizaciones.FrmListarCotizaciones.Instancia;
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        private void MantPuertos_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            var form = frmPuertos.Instancia;
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        private void manCotDirectas_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            var form = FrmCotizacionesDirectasParametros.Instancia;
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }

        private void MantAgen_Link(object sender, NavBarLinkEventArgs e)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            var form = frmAgentes.Instancia;
            form.MdiParent = this;
            form.Show();
            ClsLogPerformance.Save(new LogPerformance(Base.Usuario.UsuarioConectado.Usuario, timer.Elapsed.TotalSeconds));
        }
    }
}
