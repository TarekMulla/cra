namespace ProyectoCraft.WinForm.Controles
{
    partial class EstadoPaperless
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTiempoActual = new System.Windows.Forms.Label();
            this.lblEstimado = new System.Windows.Forms.Label();
            this.lblTerminandose = new System.Windows.Forms.Label();
            this.lblFueraPlazo = new System.Windows.Forms.Label();
            this.lblTiempoEstimado = new System.Windows.Forms.Label();
            this.pnlEstimado = new System.Windows.Forms.Panel();
            this.pnlTerminandose = new System.Windows.Forms.Panel();
            this.pnlFueraPlazo = new System.Windows.Forms.Panel();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.lblFechaTermino = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTiempo = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblTiempoEstimadoUnidad = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTiempoActual
            // 
            this.lblTiempoActual.AutoSize = true;
            this.lblTiempoActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempoActual.Location = new System.Drawing.Point(1, 8);
            this.lblTiempoActual.Name = "lblTiempoActual";
            this.lblTiempoActual.Size = new System.Drawing.Size(95, 13);
            this.lblTiempoActual.TabIndex = 1;
            this.lblTiempoActual.Text = "Tiempo actual: ";
            // 
            // lblEstimado
            // 
            this.lblEstimado.AutoSize = true;
            this.lblEstimado.Location = new System.Drawing.Point(1, 24);
            this.lblEstimado.Name = "lblEstimado";
            this.lblEstimado.Size = new System.Drawing.Size(99, 13);
            this.lblEstimado.TabIndex = 2;
            this.lblEstimado.Text = "En tiempo estimado";
            // 
            // lblTerminandose
            // 
            this.lblTerminandose.AutoSize = true;
            this.lblTerminandose.Location = new System.Drawing.Point(3, 24);
            this.lblTerminandose.Name = "lblTerminandose";
            this.lblTerminandose.Size = new System.Drawing.Size(108, 13);
            this.lblTerminandose.TabIndex = 2;
            this.lblTerminandose.Text = "Tiempo terminandose";
            // 
            // lblFueraPlazo
            // 
            this.lblFueraPlazo.AutoSize = true;
            this.lblFueraPlazo.Location = new System.Drawing.Point(3, 24);
            this.lblFueraPlazo.Name = "lblFueraPlazo";
            this.lblFueraPlazo.Size = new System.Drawing.Size(128, 13);
            this.lblFueraPlazo.TabIndex = 2;
            this.lblFueraPlazo.Text = "Fuera de tiempo estimado";
            // 
            // lblTiempoEstimado
            // 
            this.lblTiempoEstimado.AutoSize = true;
            this.lblTiempoEstimado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempoEstimado.Location = new System.Drawing.Point(415, 8);
            this.lblTiempoEstimado.Name = "lblTiempoEstimado";
            this.lblTiempoEstimado.Size = new System.Drawing.Size(193, 13);
            this.lblTiempoEstimado.TabIndex = 1;
            this.lblTiempoEstimado.Text = "Tiempo estimado Total: 00:10:00";
            // 
            // pnlEstimado
            // 
            this.pnlEstimado.BackColor = System.Drawing.Color.YellowGreen;
            this.pnlEstimado.Location = new System.Drawing.Point(4, 38);
            this.pnlEstimado.Name = "pnlEstimado";
            this.pnlEstimado.Size = new System.Drawing.Size(1103, 25);
            this.pnlEstimado.TabIndex = 3;
            // 
            // pnlTerminandose
            // 
            this.pnlTerminandose.BackColor = System.Drawing.Color.Goldenrod;
            this.pnlTerminandose.Location = new System.Drawing.Point(5, 39);
            this.pnlTerminandose.Name = "pnlTerminandose";
            this.pnlTerminandose.Size = new System.Drawing.Size(1102, 25);
            this.pnlTerminandose.TabIndex = 3;
            // 
            // pnlFueraPlazo
            // 
            this.pnlFueraPlazo.BackColor = System.Drawing.Color.Red;
            this.pnlFueraPlazo.Location = new System.Drawing.Point(4, 39);
            this.pnlFueraPlazo.Name = "pnlFueraPlazo";
            this.pnlFueraPlazo.Size = new System.Drawing.Size(1103, 25);
            this.pnlFueraPlazo.TabIndex = 3;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicio.Location = new System.Drawing.Point(630, 8);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(73, 13);
            this.lblFechaInicio.TabIndex = 1;
            this.lblFechaInicio.Text = "fecha inicio";
            // 
            // lblFechaTermino
            // 
            this.lblFechaTermino.AutoSize = true;
            this.lblFechaTermino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaTermino.Location = new System.Drawing.Point(871, 8);
            this.lblFechaTermino.Name = "lblFechaTermino";
            this.lblFechaTermino.Size = new System.Drawing.Size(84, 13);
            this.lblFechaTermino.TabIndex = 1;
            this.lblFechaTermino.Text = "fecha termino";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempo.Location = new System.Drawing.Point(91, 8);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(57, 13);
            this.lblTiempo.TabIndex = 1;
            this.lblTiempo.Text = "00:10:00";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(4, 66);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1103, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // lblTiempoEstimadoUnidad
            // 
            this.lblTiempoEstimadoUnidad.AutoSize = true;
            this.lblTiempoEstimadoUnidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempoEstimadoUnidad.Location = new System.Drawing.Point(168, 8);
            this.lblTiempoEstimadoUnidad.Name = "lblTiempoEstimadoUnidad";
            this.lblTiempoEstimadoUnidad.Size = new System.Drawing.Size(222, 13);
            this.lblTiempoEstimadoUnidad.TabIndex = 1;
            this.lblTiempoEstimadoUnidad.Text = "Tiempo estimado por House: 00:10:00";
            // 
            // EstadoPaperless
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTerminandose);
            this.Controls.Add(this.pnlEstimado);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pnlFueraPlazo);
            this.Controls.Add(this.lblFechaTermino);
            this.Controls.Add(this.lblFechaInicio);
            this.Controls.Add(this.lblTiempoEstimadoUnidad);
            this.Controls.Add(this.lblTiempoEstimado);
            this.Controls.Add(this.lblFueraPlazo);
            this.Controls.Add(this.lblTerminandose);
            this.Controls.Add(this.lblEstimado);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.lblTiempoActual);
            this.Name = "EstadoPaperless";
            this.Size = new System.Drawing.Size(1110, 98);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTiempoActual;
        private System.Windows.Forms.Label lblEstimado;
        private System.Windows.Forms.Label lblTerminandose;
        private System.Windows.Forms.Label lblFueraPlazo;
        private System.Windows.Forms.Label lblTiempoEstimado;
        private System.Windows.Forms.Panel pnlEstimado;
        private System.Windows.Forms.Panel pnlTerminandose;
        private System.Windows.Forms.Panel pnlFueraPlazo;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblFechaTermino;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblTiempoEstimadoUnidad;
    }
}
