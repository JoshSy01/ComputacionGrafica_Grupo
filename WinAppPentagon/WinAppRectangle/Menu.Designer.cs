namespace WinAppRectangle
{
    partial class Menu
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nivelFácilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectánguloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuadradoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.romboToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nivelMedioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pentágonoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.florToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.figurasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polígono16Y8PuntasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pentagonosYPoligonosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copoDeNieveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figura4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.florHexagonosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.florConCírculosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nivelFácilToolStripMenuItem,
            this.nivelMedioToolStripMenuItem,
            this.figurasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.figurasToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(802, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nivelFácilToolStripMenuItem
            // 
            this.nivelFácilToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rectánguloToolStripMenuItem,
            this.cuadradoToolStripMenuItem1,
            this.romboToolStripMenuItem});
            this.nivelFácilToolStripMenuItem.Name = "nivelFácilToolStripMenuItem";
            this.nivelFácilToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.nivelFácilToolStripMenuItem.Text = "Nivel Fácil";
            // 
            // rectánguloToolStripMenuItem
            // 
            this.rectánguloToolStripMenuItem.Name = "rectánguloToolStripMenuItem";
            this.rectánguloToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.rectánguloToolStripMenuItem.Text = "Rectángulo";
            this.rectánguloToolStripMenuItem.Click += new System.EventHandler(this.rectánguloToolStripMenuItem_Click);
            // 
            // cuadradoToolStripMenuItem1
            // 
            this.cuadradoToolStripMenuItem1.Name = "cuadradoToolStripMenuItem1";
            this.cuadradoToolStripMenuItem1.Size = new System.Drawing.Size(167, 26);
            this.cuadradoToolStripMenuItem1.Text = "Cuadrado";
            this.cuadradoToolStripMenuItem1.Click += new System.EventHandler(this.cuadradoToolStripMenuItem1_Click);
            // 
            // romboToolStripMenuItem
            // 
            this.romboToolStripMenuItem.Name = "romboToolStripMenuItem";
            this.romboToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.romboToolStripMenuItem.Text = "Rombo";
            this.romboToolStripMenuItem.Click += new System.EventHandler(this.romboToolStripMenuItem_Click);
            // 
            // nivelMedioToolStripMenuItem
            // 
            this.nivelMedioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pentágonoToolStripMenuItem,
            this.florToolStripMenuItem1});
            this.nivelMedioToolStripMenuItem.Name = "nivelMedioToolStripMenuItem";
            this.nivelMedioToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.nivelMedioToolStripMenuItem.Text = "Nivel Medio";
            // 
            // pentágonoToolStripMenuItem
            // 
            this.pentágonoToolStripMenuItem.Name = "pentágonoToolStripMenuItem";
            this.pentágonoToolStripMenuItem.Size = new System.Drawing.Size(140, 26);
            this.pentágonoToolStripMenuItem.Text = "Estrella";
            this.pentágonoToolStripMenuItem.Click += new System.EventHandler(this.pentágonoToolStripMenuItem_Click);
            // 
            // florToolStripMenuItem1
            // 
            this.florToolStripMenuItem1.Name = "florToolStripMenuItem1";
            this.florToolStripMenuItem1.Size = new System.Drawing.Size(140, 26);
            this.florToolStripMenuItem1.Text = "Flor";
            this.florToolStripMenuItem1.Click += new System.EventHandler(this.florToolStripMenuItem1_Click);
            // 
            // figurasToolStripMenuItem
            // 
            this.figurasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.polígono16Y8PuntasToolStripMenuItem,
            this.pentagonosYPoligonosToolStripMenuItem,
            this.copoDeNieveToolStripMenuItem,
            this.figura4ToolStripMenuItem,
            this.florHexagonosToolStripMenuItem,
            this.florConCírculosToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.figurasToolStripMenuItem.Name = "figurasToolStripMenuItem";
            this.figurasToolStripMenuItem.Size = new System.Drawing.Size(100, 24);
            this.figurasToolStripMenuItem.Text = "Nivel Difícil";
            // 
            // polígono16Y8PuntasToolStripMenuItem
            // 
            this.polígono16Y8PuntasToolStripMenuItem.Name = "polígono16Y8PuntasToolStripMenuItem";
            this.polígono16Y8PuntasToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
            this.polígono16Y8PuntasToolStripMenuItem.Text = "Fig1: Polígono 16 y 8 puntas";
            this.polígono16Y8PuntasToolStripMenuItem.Click += new System.EventHandler(this.polígono16Y8PuntasToolStripMenuItem_Click);
            // 
            // pentagonosYPoligonosToolStripMenuItem
            // 
            this.pentagonosYPoligonosToolStripMenuItem.Name = "pentagonosYPoligonosToolStripMenuItem";
            this.pentagonosYPoligonosToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
            this.pentagonosYPoligonosToolStripMenuItem.Text = "Fig2. Pentágonos y Polígonos";
            this.pentagonosYPoligonosToolStripMenuItem.Click += new System.EventHandler(this.pentagonosYPoligonosToolStripMenuItem_Click);
            // 
            // copoDeNieveToolStripMenuItem
            // 
            this.copoDeNieveToolStripMenuItem.Name = "copoDeNieveToolStripMenuItem";
            this.copoDeNieveToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
            this.copoDeNieveToolStripMenuItem.Text = "Fig3. Gema de 10 lados";
            this.copoDeNieveToolStripMenuItem.Click += new System.EventHandler(this.copoDeNieveToolStripMenuItem_Click);
            // 
            // figura4ToolStripMenuItem
            // 
            this.figura4ToolStripMenuItem.Name = "figura4ToolStripMenuItem";
            this.figura4ToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
            this.figura4ToolStripMenuItem.Text = "Fig4. Estrella 8 puntas";
            this.figura4ToolStripMenuItem.Click += new System.EventHandler(this.figura4ToolStripMenuItem_Click);
            // 
            // florHexagonosToolStripMenuItem
            // 
            this.florHexagonosToolStripMenuItem.Name = "florHexagonosToolStripMenuItem";
            this.florHexagonosToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
            this.florHexagonosToolStripMenuItem.Text = "Fig5. Flor Hexagonos";
            this.florHexagonosToolStripMenuItem.Click += new System.EventHandler(this.florHexagonosToolStripMenuItem_Click);
            // 
            // florConCírculosToolStripMenuItem
            // 
            this.florConCírculosToolStripMenuItem.Name = "florConCírculosToolStripMenuItem";
            this.florConCírculosToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
            this.florConCírculosToolStripMenuItem.Text = "Fig6. Flor con Círculos";
            this.florConCírculosToolStripMenuItem.Click += new System.EventHandler(this.florConCírculosToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.SystemColors.Info;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 28);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(802, 463);
            this.mainPanel.TabIndex = 2;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // animationTimer
            // 
            this.animationTimer.Enabled = true;
            this.animationTimer.Interval = 40;
            this.animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 491);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem figurasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pentagonosYPoligonosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem florHexagonosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copoDeNieveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figura4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polígono16Y8PuntasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem florConCírculosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nivelMedioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nivelFácilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectánguloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuadradoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pentágonoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem florToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem romboToolStripMenuItem;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Timer animationTimer;
    }
}