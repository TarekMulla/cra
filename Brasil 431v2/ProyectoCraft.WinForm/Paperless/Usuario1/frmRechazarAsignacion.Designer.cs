namespace ProyectoCraft.WinForm.Paperless.Usuario1
{
    partial class frmRechazarAsignacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRechazarAsignacion));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtNumMaster = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtFechaMaster = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtMotivo = new DevExpress.XtraEditors.MemoEdit();
            this.btnRechazar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtFechaRechazo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtUsuario = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumMaster.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaMaster.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMotivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaRechazo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "N° Master";
            // 
            // txtNumMaster
            // 
            this.txtNumMaster.Location = new System.Drawing.Point(111, 9);
            this.txtNumMaster.Name = "txtNumMaster";
            this.txtNumMaster.Size = new System.Drawing.Size(163, 20);
            this.txtNumMaster.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 34);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Fecha Master";
            // 
            // txtFechaMaster
            // 
            this.txtFechaMaster.Location = new System.Drawing.Point(111, 31);
            this.txtFechaMaster.Name = "txtFechaMaster";
            this.txtFechaMaster.Size = new System.Drawing.Size(163, 20);
            this.txtFechaMaster.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 103);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(93, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Motivo del Rechazo";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(111, 100);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(553, 120);
            this.txtMotivo.TabIndex = 2;
            // 
            // btnRechazar
            // 
            this.btnRechazar.Image = ((System.Drawing.Image)(resources.GetObject("btnRechazar.Image")));
            this.btnRechazar.Location = new System.Drawing.Point(424, 227);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(138, 23);
            this.btnRechazar.TabIndex = 3;
            this.btnRechazar.Text = "Enviar Rechazo";
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(568, 227);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(95, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 56);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(73, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Fecha Rechazo";
            // 
            // txtFechaRechazo
            // 
            this.txtFechaRechazo.Location = new System.Drawing.Point(111, 53);
            this.txtFechaRechazo.Name = "txtFechaRechazo";
            this.txtFechaRechazo.Size = new System.Drawing.Size(163, 20);
            this.txtFechaRechazo.TabIndex = 1;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 77);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(111, 74);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(261, 20);
            this.txtUsuario.TabIndex = 1;
            // 
            // frmRechazarAsignacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 271);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRechazar);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtFechaRechazo);
            this.Controls.Add(this.txtFechaMaster);
            this.Controls.Add(this.txtNumMaster);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmRechazarAsignacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rechazar Asignacion";
            this.Load += new System.EventHandler(this.frmRechazarAsignacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNumMaster.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaMaster.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMotivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaRechazo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtNumMaster;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtFechaMaster;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.MemoEdit txtMotivo;
        private DevExpress.XtraEditors.SimpleButton btnRechazar;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtFechaRechazo;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtUsuario;
    }
}