namespace WinAppRectangle
{
    partial class FrmFlorCirculo
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
            this.gbTransformar = new System.Windows.Forms.GroupBox();
            this.tbEscala = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRotDer = new System.Windows.Forms.Button();
            this.btnRotIzq = new System.Windows.Forms.Button();
            this.grbCanvas = new System.Windows.Forms.GroupBox();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.grbProcess = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnResetear = new System.Windows.Forms.Button();
            this.btnGraficar = new System.Windows.Forms.Button();
            this.grbInputs = new System.Windows.Forms.GroupBox();
            this.txtRadio = new System.Windows.Forms.TextBox();
            this.lblRadio = new System.Windows.Forms.Label();
            this.gbTransformar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbEscala)).BeginInit();
            this.grbCanvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.grbProcess.SuspendLayout();
            this.grbInputs.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTransformar
            // 
            this.gbTransformar.Controls.Add(this.tbEscala);
            this.gbTransformar.Controls.Add(this.label2);
            this.gbTransformar.Controls.Add(this.label1);
            this.gbTransformar.Controls.Add(this.btnRotDer);
            this.gbTransformar.Controls.Add(this.btnRotIzq);
            this.gbTransformar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTransformar.Location = new System.Drawing.Point(19, 266);
            this.gbTransformar.Name = "gbTransformar";
            this.gbTransformar.Size = new System.Drawing.Size(284, 144);
            this.gbTransformar.TabIndex = 29;
            this.gbTransformar.TabStop = false;
            this.gbTransformar.Text = "Transformación";
            // 
            // tbEscala
            // 
            this.tbEscala.Enabled = false;
            this.tbEscala.Location = new System.Drawing.Point(88, 28);
            this.tbEscala.Maximum = 50;
            this.tbEscala.Minimum = -50;
            this.tbEscala.Name = "tbEscala";
            this.tbEscala.Size = new System.Drawing.Size(177, 56);
            this.tbEscala.TabIndex = 5;
            this.tbEscala.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbEscala.Scroll += new System.EventHandler(this.tbEscala_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Rotación";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Escala";
            // 
            // btnRotDer
            // 
            this.btnRotDer.Enabled = false;
            this.btnRotDer.Location = new System.Drawing.Point(158, 103);
            this.btnRotDer.Name = "btnRotDer";
            this.btnRotDer.Size = new System.Drawing.Size(75, 23);
            this.btnRotDer.TabIndex = 2;
            this.btnRotDer.Text = "->";
            this.btnRotDer.UseVisualStyleBackColor = true;
            this.btnRotDer.Click += new System.EventHandler(this.btnRotDer_Click);
            // 
            // btnRotIzq
            // 
            this.btnRotIzq.Enabled = false;
            this.btnRotIzq.Location = new System.Drawing.Point(56, 103);
            this.btnRotIzq.Name = "btnRotIzq";
            this.btnRotIzq.Size = new System.Drawing.Size(75, 23);
            this.btnRotIzq.TabIndex = 1;
            this.btnRotIzq.Text = "<-";
            this.btnRotIzq.UseVisualStyleBackColor = true;
            this.btnRotIzq.Click += new System.EventHandler(this.btnRotIzq_Click);
            // 
            // grbCanvas
            // 
            this.grbCanvas.Controls.Add(this.picCanvas);
            this.grbCanvas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbCanvas.Location = new System.Drawing.Point(340, 25);
            this.grbCanvas.Name = "grbCanvas";
            this.grbCanvas.Size = new System.Drawing.Size(441, 404);
            this.grbCanvas.TabIndex = 30;
            this.grbCanvas.TabStop = false;
            this.grbCanvas.Text = "Gráfico";
            // 
            // picCanvas
            // 
            this.picCanvas.Location = new System.Drawing.Point(6, 21);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(429, 364);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // grbProcess
            // 
            this.grbProcess.Controls.Add(this.btnSalir);
            this.grbProcess.Controls.Add(this.btnResetear);
            this.grbProcess.Controls.Add(this.btnGraficar);
            this.grbProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbProcess.Location = new System.Drawing.Point(19, 147);
            this.grbProcess.Name = "grbProcess";
            this.grbProcess.Size = new System.Drawing.Size(284, 100);
            this.grbProcess.TabIndex = 28;
            this.grbProcess.TabStop = false;
            this.grbProcess.Text = "Proceso";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(190, 56);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnResetear
            // 
            this.btnResetear.Location = new System.Drawing.Point(88, 56);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(96, 23);
            this.btnResetear.TabIndex = 1;
            this.btnResetear.Text = "Resetear";
            this.btnResetear.UseVisualStyleBackColor = true;
            this.btnResetear.Click += new System.EventHandler(this.btnResetear_Click);
            // 
            // btnGraficar
            // 
            this.btnGraficar.Location = new System.Drawing.Point(7, 56);
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(75, 23);
            this.btnGraficar.TabIndex = 0;
            this.btnGraficar.Text = "Graficar";
            this.btnGraficar.UseVisualStyleBackColor = true;
            this.btnGraficar.Click += new System.EventHandler(this.btnGraficar_Click);
            // 
            // grbInputs
            // 
            this.grbInputs.Controls.Add(this.txtRadio);
            this.grbInputs.Controls.Add(this.lblRadio);
            this.grbInputs.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbInputs.Location = new System.Drawing.Point(19, 22);
            this.grbInputs.Name = "grbInputs";
            this.grbInputs.Size = new System.Drawing.Size(284, 103);
            this.grbInputs.TabIndex = 27;
            this.grbInputs.TabStop = false;
            this.grbInputs.Text = "Entradas";
            // 
            // txtRadio
            // 
            this.txtRadio.Location = new System.Drawing.Point(115, 42);
            this.txtRadio.Name = "txtRadio";
            this.txtRadio.Size = new System.Drawing.Size(129, 22);
            this.txtRadio.TabIndex = 2;
            // 
            // lblRadio
            // 
            this.lblRadio.AutoSize = true;
            this.lblRadio.Location = new System.Drawing.Point(9, 45);
            this.lblRadio.Name = "lblRadio";
            this.lblRadio.Size = new System.Drawing.Size(53, 16);
            this.lblRadio.TabIndex = 0;
            this.lblRadio.Text = "Radio:";
            // 
            // FrmFlorCirculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbTransformar);
            this.Controls.Add(this.grbCanvas);
            this.Controls.Add(this.grbProcess);
            this.Controls.Add(this.grbInputs);
            this.Name = "FrmFlorCirculo";
            this.Text = "FrmFlorCirculo";
            this.gbTransformar.ResumeLayout(false);
            this.gbTransformar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbEscala)).EndInit();
            this.grbCanvas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.grbProcess.ResumeLayout(false);
            this.grbInputs.ResumeLayout(false);
            this.grbInputs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTransformar;
        private System.Windows.Forms.TrackBar tbEscala;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRotDer;
        private System.Windows.Forms.Button btnRotIzq;
        private System.Windows.Forms.GroupBox grbCanvas;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.GroupBox grbProcess;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnResetear;
        private System.Windows.Forms.Button btnGraficar;
        private System.Windows.Forms.GroupBox grbInputs;
        private System.Windows.Forms.TextBox txtRadio;
        private System.Windows.Forms.Label lblRadio;
    }
}