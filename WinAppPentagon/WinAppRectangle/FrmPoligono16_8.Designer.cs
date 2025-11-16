namespace WinAppRectangle
{
    partial class FrmPoligono16_8
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnResetear = new System.Windows.Forms.Button();
            this.btnGraficar = new System.Windows.Forms.Button();
            this.grbInputs = new System.Windows.Forms.GroupBox();
            this.txtRadio = new System.Windows.Forms.TextBox();
            this.lblRadio = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPerTotal = new System.Windows.Forms.TextBox();
            this.txtAreaTotal = new System.Windows.Forms.TextBox();
            this.txtAreaPor = new System.Windows.Forms.TextBox();
            this.txtPerPor = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.gbTransformar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbEscala)).BeginInit();
            this.grbCanvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.grbProcess.SuspendLayout();
            this.grbInputs.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTransformar
            // 
            this.gbTransformar.Controls.Add(this.label4);
            this.gbTransformar.Controls.Add(this.label3);
            this.gbTransformar.Controls.Add(this.tbEscala);
            this.gbTransformar.Controls.Add(this.label2);
            this.gbTransformar.Controls.Add(this.label1);
            this.gbTransformar.Controls.Add(this.btnRotDer);
            this.gbTransformar.Controls.Add(this.btnRotIzq);
            this.gbTransformar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTransformar.Location = new System.Drawing.Point(19, 166);
            this.gbTransformar.Name = "gbTransformar";
            this.gbTransformar.Size = new System.Drawing.Size(315, 178);
            this.gbTransformar.TabIndex = 29;
            this.gbTransformar.TabStop = false;
            this.gbTransformar.Text = "Transformación";
            // 
            // tbEscala
            // 
            this.tbEscala.Enabled = false;
            this.tbEscala.Location = new System.Drawing.Point(88, 28);
            this.tbEscala.Maximum = 100;
            this.tbEscala.Minimum = -100;
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
            this.grbCanvas.Location = new System.Drawing.Point(340, 34);
            this.grbCanvas.Name = "grbCanvas";
            this.grbCanvas.Size = new System.Drawing.Size(441, 432);
            this.grbCanvas.TabIndex = 30;
            this.grbCanvas.TabStop = false;
            this.grbCanvas.Text = "Gráfico";
            // 
            // picCanvas
            // 
            this.picCanvas.Location = new System.Drawing.Point(6, 21);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(435, 420);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // grbProcess
            // 
            this.grbProcess.Controls.Add(this.btnExit);
            this.grbProcess.Controls.Add(this.btnResetear);
            this.grbProcess.Controls.Add(this.btnGraficar);
            this.grbProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbProcess.Location = new System.Drawing.Point(19, 107);
            this.grbProcess.Name = "grbProcess";
            this.grbProcess.Size = new System.Drawing.Size(315, 53);
            this.grbProcess.TabIndex = 28;
            this.grbProcess.TabStop = false;
            this.grbProcess.Text = "Proceso";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(214, 21);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(95, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnResetear
            // 
            this.btnResetear.Location = new System.Drawing.Point(114, 21);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(94, 23);
            this.btnResetear.TabIndex = 1;
            this.btnResetear.Text = "Resetear";
            this.btnResetear.UseVisualStyleBackColor = true;
            this.btnResetear.Click += new System.EventHandler(this.btnResetear_Click);
            // 
            // btnGraficar
            // 
            this.btnGraficar.Location = new System.Drawing.Point(6, 21);
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(102, 23);
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
            this.grbInputs.Location = new System.Drawing.Point(19, 31);
            this.grbInputs.Name = "grbInputs";
            this.grbInputs.Size = new System.Drawing.Size(315, 59);
            this.grbInputs.TabIndex = 27;
            this.grbInputs.TabStop = false;
            this.grbInputs.Text = "Entradas";
            // 
            // txtRadio
            // 
            this.txtRadio.Location = new System.Drawing.Point(136, 24);
            this.txtRadio.Name = "txtRadio";
            this.txtRadio.Size = new System.Drawing.Size(129, 22);
            this.txtRadio.TabIndex = 2;
            // 
            // lblRadio
            // 
            this.lblRadio.AutoSize = true;
            this.lblRadio.Location = new System.Drawing.Point(30, 27);
            this.lblRadio.Name = "lblRadio";
            this.lblRadio.Size = new System.Drawing.Size(53, 16);
            this.lblRadio.TabIndex = 0;
            this.lblRadio.Text = "Radio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(133, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Usar flechas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Traslación";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPerTotal);
            this.groupBox2.Controls.Add(this.txtAreaTotal);
            this.groupBox2.Controls.Add(this.txtAreaPor);
            this.groupBox2.Controls.Add(this.txtPerPor);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(19, 350);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 116);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Salidas";
            // 
            // txtPerTotal
            // 
            this.txtPerTotal.Location = new System.Drawing.Point(173, 88);
            this.txtPerTotal.Name = "txtPerTotal";
            this.txtPerTotal.Size = new System.Drawing.Size(129, 22);
            this.txtPerTotal.TabIndex = 9;
            // 
            // txtAreaTotal
            // 
            this.txtAreaTotal.Location = new System.Drawing.Point(173, 67);
            this.txtAreaTotal.Name = "txtAreaTotal";
            this.txtAreaTotal.Size = new System.Drawing.Size(129, 22);
            this.txtAreaTotal.TabIndex = 8;
            // 
            // txtAreaPor
            // 
            this.txtAreaPor.Location = new System.Drawing.Point(173, 47);
            this.txtAreaPor.Name = "txtAreaPor";
            this.txtAreaPor.Size = new System.Drawing.Size(129, 22);
            this.txtAreaPor.TabIndex = 7;
            // 
            // txtPerPor
            // 
            this.txtPerPor.Location = new System.Drawing.Point(173, 27);
            this.txtPerPor.Name = "txtPerPor";
            this.txtPerPor.Size = new System.Drawing.Size(129, 22);
            this.txtPerPor.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 16);
            this.label9.TabIndex = 5;
            this.label9.Text = "Perímetro Total";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 16);
            this.label10.TabIndex = 4;
            this.label10.Text = "Área Total";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 16);
            this.label11.TabIndex = 3;
            this.label11.Text = "Área Porción";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(131, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Perímetro Porción";
            // 
            // FrmPoligono16_8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 494);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbTransformar);
            this.Controls.Add(this.grbCanvas);
            this.Controls.Add(this.grbProcess);
            this.Controls.Add(this.grbInputs);
            this.Name = "FrmPoligono16_8";
            this.Text = "FrmPoligono16_8";
            this.gbTransformar.ResumeLayout(false);
            this.gbTransformar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbEscala)).EndInit();
            this.grbCanvas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.grbProcess.ResumeLayout(false);
            this.grbInputs.ResumeLayout(false);
            this.grbInputs.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnResetear;
        private System.Windows.Forms.Button btnGraficar;
        private System.Windows.Forms.GroupBox grbInputs;
        private System.Windows.Forms.TextBox txtRadio;
        private System.Windows.Forms.Label lblRadio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPerTotal;
        private System.Windows.Forms.TextBox txtAreaTotal;
        private System.Windows.Forms.TextBox txtAreaPor;
        private System.Windows.Forms.TextBox txtPerPor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}