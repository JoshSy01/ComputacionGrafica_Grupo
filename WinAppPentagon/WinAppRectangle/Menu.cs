using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinAppFigure;

namespace WinAppRectangle
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        public void OpenWindow(Form frm)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void rectanguloToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void cuadradoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void rectanguloToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenWindow(new frmRectangle());
        }

        private void cuadradoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenWindow(new frmSquare());
        }

        private void pentagonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWindow(new frmPentagon());
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();   
        }

        private void florToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWindow(new frmFlower());
        }

        private void pentagonosYPoligonosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWindow(new frmPentagonosYPoligonos());
        }

        private void florHexagonosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWindow(new frmHexagonFlower());
        }

        private void copoDeNieveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWindow(new frmCopoDeNieve());
        }

        private void figura4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWindow(new frmFigura4());
        }

        private void polígono16Y8PuntasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWindow(new FrmPoligono16_8());
        }

        private void florConCírculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWindow(new FrmFlorCirculo());
        }
    }
}
