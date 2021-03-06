﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProyectoCraft.Entidades.Enums;
using ProyectoCraft.Entidades.Paperless;
using SCCMultimodal.Utils;

namespace ProyectoCraft.WinForm.Paperless.Usuario2
{
    public partial class frmRechazarAsignacionU2 : Form
    {
        public frmRechazarAsignacionU2()
        {
            InitializeComponent();
        }

        private static frmRechazarAsignacionU2 _instancia;
        public static frmRechazarAsignacionU2 Instancia
        {
            get
            {
                if(_instancia == null)
                    _instancia = new frmRechazarAsignacionU2();

                return _instancia;
            }
            set { _instancia = value; }
        }

        private Entidades.Paperless.PaperlessAsignacion _asignacion;
        public Entidades.Paperless.PaperlessAsignacion Asignacion
        {
            get { return _asignacion; }
            set { _asignacion = value; }
        }

        private Enums.TipoAccionFormulario _accion;
        public Enums.TipoAccionFormulario Accion
        {
            get { return _accion; }
            set { _accion = value; }
        }

        private void frmRechazarAsignacion_Load(object sender, EventArgs e)
        {

            txtNumMaster.Text = Asignacion.NumMaster;
            txtFechaMaster.Text = Asignacion.FechaMaster.ToShortDateString();
            txtFechaRechazo.Text = DateTime.Now.ToShortDateString();
            txtUsuario.Text = Base.Usuario.UsuarioConectado.Usuario.NombreCompleto;
            txtMotivo.Text = "";


            txtNumMaster.Enabled = false;
            txtFechaMaster.Enabled = false;
            txtFechaRechazo.Enabled = false;
            txtUsuario.Enabled = false;

            if(Accion == Enums.TipoAccionFormulario.Consultar)
                CargaRechazoAsignacion();

        }
        private void CargaRechazoAsignacion()
        {
            PaperlessUsuario1Rechaza rechazo = LogicaNegocios.Paperless.Paperless.ObtenerRechazoAsignacion(Asignacion.Id);

            if(rechazo != null)
            {
                txtFechaRechazo.Text = rechazo.FechaRechazo.ToShortDateString();
                txtUsuario.Text = rechazo.Usuario.NombreCompleto;
                txtMotivo.Text = rechazo.Motivo;
                txtMotivo.Enabled = false;
                btnRechazar.Visible = false;
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Instancia = null;
            Close();
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            var mail = new EnvioMailObject();
            if (txtMotivo.Text.Length.Equals(0)) return;
            
            Entidades.Paperless.PaperlessUsuario1Rechaza rechazo = new PaperlessUsuario1Rechaza();
            rechazo.IdAsignacion = Asignacion.Id;
            rechazo.Usuario = Base.Usuario.UsuarioConectado.Usuario;
            rechazo.Motivo = txtMotivo.Text;
            rechazo.tipoUsuario = Convert.ToInt16(Enums.TipoUsuario.Usuario2); 


            Entidades.GlobalObject.ResultadoTransaccion resultado = LogicaNegocios.Paperless.Paperless.Usuario1RechazaAsignacion(rechazo); 

            if(resultado.Estado == Enums.EstadoTransaccion.Aceptada)
            {
                Asignacion.Estado = Enums.EstadoPaperless.RechazadaUsuario2;
                resultado = LogicaNegocios.Paperless.Paperless.CambiaEstadoAsignacion(Asignacion);

                if (Asignacion.IdResultado.Equals(1))
                    MessageBox.Show(Asignacion.GlosaResultado, "Paperless Usuario 2da Etapa", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if(resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                {
                    MessageBox.Show(resultado.Descripcion, "Paperless Usuario 2da Etapa", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    resultado = mail.EnviarMailPaperlessRechazoAsignacionU2(Asignacion);
                    //resultado = Utils.EnvioEmail.EnviarMailPaperlessRechazoAsignacion(Asignacion);
                    
                    if (resultado.Estado == Enums.EstadoTransaccion.Rechazada)
                    {
                        MessageBox.Show(resultado.Descripcion, "Paperless Usuario 2da Etapa", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                    }

                    frmListarUsuario2 form = frmListarUsuario2.Instancia;
                    form.ObtenerAsignaciones();
                    
                    MessageBox.Show("Se ha enviado el rechazo con éxito.", "Paperless Usuario 2da Etapa", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    this.Close();
                }

                
            }
            else
            {
                MessageBox.Show(resultado.Descripcion, "Paperless", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

        }


    }
}
