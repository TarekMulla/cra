namespace ProyectoCraft.WinForm.Ventas.Metas
{
    partial class frmCancelarSalesLead
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCancelarSalesLead));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAgente = new DevExpress.XtraEditors.LabelControl();
            this.DateCancelacion = new DevExpress.XtraEditors.DateEdit();
            this.MemoObservaciones = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.sButtonSalir = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.sButtonGrabarObs = new DevExpress.XtraEditors.SimpleButton();
            this.lblSLead = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DateCancelacion.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateCancelacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemoObservaciones.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAgente);
            this.groupBox1.Controls.Add(this.DateCancelacion);
            this.groupBox1.Controls.Add(this.MemoObservaciones);
            this.groupBox1.Controls.Add(this.labelControl3);
            this.groupBox1.Controls.Add(this.sButtonSalir);
            this.groupBox1.Controls.Add(this.labelControl5);
            this.groupBox1.Controls.Add(this.sButtonGrabarObs);
            this.groupBox1.Controls.Add(this.lblSLead);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Controls.Add(this.labelControl6);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 284);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // lblAgente
            // 
            this.lblAgente.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblAgente.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.lblAgente.Location = new System.Drawing.Point(131, 44);
            this.lblAgente.Name = "lblAgente";
            this.lblAgente.Size = new System.Drawing.Size(266, 25);
            this.lblAgente.TabIndex = 81;
            this.lblAgente.Text = "labelControl2";
            // 
            // DateCancelacion
            // 
            this.DateCancelacion.EditValue = null;
            this.DateCancelacion.Location = new System.Drawing.Point(131, 75);
            this.DateCancelacion.Name = "DateCancelacion";
            this.DateCancelacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateCancelacion.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DateCancelacion.Size = new System.Drawing.Size(99, 20);
            this.DateCancelacion.TabIndex = 1;
            // 
            // MemoObservaciones
            // 
            this.MemoObservaciones.Location = new System.Drawing.Point(9, 129);
            this.MemoObservaciones.Name = "MemoObservaciones";
            this.MemoObservaciones.Size = new System.Drawing.Size(386, 111);
            this.MemoObservaciones.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl3.Location = new System.Drawing.Point(10, 110);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 13);
            this.labelControl3.TabIndex = 75;
            this.labelControl3.Text = "Observaciones:";
            // 
            // sButtonSalir
            // 
            this.sButtonSalir.Image = ((System.Drawing.Image)(resources.GetObject("sButtonSalir.Image")));
            this.sButtonSalir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.sButtonSalir.Location = new System.Drawing.Point(321, 246);
            this.sButtonSalir.Name = "sButtonSalir";
            this.sButtonSalir.Size = new System.Drawing.Size(32, 29);
            this.sButtonSalir.TabIndex = 72;
            this.sButtonSalir.ToolTip = "Salir";
            this.sButtonSalir.Click += new System.EventHandler(this.sButtonSalir_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Options.UseTextOptions = true;
            this.labelControl5.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Location = new System.Drawing.Point(13, 50);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(97, 17);
            this.labelControl5.TabIndex = 71;
            this.labelControl5.Text = "Agente:";
            // 
            // sButtonGrabarObs
            // 
            this.sButtonGrabarObs.Image = ((System.Drawing.Image)(resources.GetObject("sButtonGrabarObs.Image")));
            this.sButtonGrabarObs.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.sButtonGrabarObs.Location = new System.Drawing.Point(363, 246);
            this.sButtonGrabarObs.Name = "sButtonGrabarObs";
            this.sButtonGrabarObs.Size = new System.Drawing.Size(32, 29);
            this.sButtonGrabarObs.TabIndex = 68;
            this.sButtonGrabarObs.ToolTip = "Grabar";
            this.sButtonGrabarObs.Click += new System.EventHandler(this.sButtonGrabarObs_Click);
            // 
            // lblSLead
            // 
            this.lblSLead.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSLead.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.lblSLead.Location = new System.Drawing.Point(131, 13);
            this.lblSLead.Name = "lblSLead";
            this.lblSLead.Size = new System.Drawing.Size(266, 25);
            this.lblSLead.TabIndex = 35;
            this.lblSLead.Text = "labelControl2";
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl1.Location = new System.Drawing.Point(13, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "Prospecto:";
            // 
            // labelControl6
            // 
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl6.Location = new System.Drawing.Point(10, 78);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(93, 13);
            this.labelControl6.TabIndex = 32;
            this.labelControl6.Text = "Fecha Cancelación:";
            // 
            // frmCancelarSalesLead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 290);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCancelarSalesLead";
            this.Text = "Cancelar Sales Lead";
            this.Load += new System.EventHandler(this.frmCancelarSalesLead_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DateCancelacion.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateCancelacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemoObservaciones.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.LabelControl lblAgente;
        private DevExpress.XtraEditors.DateEdit DateCancelacion;
        private DevExpress.XtraEditors.MemoEdit MemoObservaciones;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton sButtonSalir;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton sButtonGrabarObs;
        private DevExpress.XtraEditors.LabelControl lblSLead;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}