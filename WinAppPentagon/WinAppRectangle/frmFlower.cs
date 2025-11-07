using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppRectangle
{
    public partial class frmFlower : Form
    {
        CFlower ObjFlower = new CFlower();
        Punto center = new Punto();
        float tetha = 0.0f;

        public frmFlower()
        {
            InitializeComponent();
            center.y = picCanvas.Size.Height / 2;
            center.x = picCanvas.Size.Width / 2;
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            try
            {
                ObjFlower.ReadData(float.Parse(txtRadio.Text));
                ObjFlower.PlotShape(picCanvas, center, tetha);
                txtRadio.Enabled = false;
                tbEscala.Enabled = true;
                btnRotDer.Enabled = true;
                btnRotIzq.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ObjFlower.initializeData(txtRadio, picCanvas);
            txtRadio.Enabled = true;
            tbEscala.Enabled = false;
            btnRotDer.Enabled = false;
            btnRotIzq.Enabled = false;
            tbEscala.Value = 0;
            txtRadio.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tbEscala_Scroll(object sender, EventArgs e)
        {
            try
            {
                picCanvas.Refresh();
                Transformacion transformacion = new Transformacion();
                ObjFlower.ReadData(transformacion.Scale(float.Parse(txtRadio.Text), tbEscala.Value));
                ObjFlower.PlotShape(picCanvas, center, tetha);
                txtRadio.Enabled = false;
                picCanvas.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }

        private void frmFlower_Load(object sender, EventArgs e)
        {

        }

        private void frmFlower_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) {
                center.x += 5;
            }
            if (e.KeyCode == Keys.S)
            {
                center.x -= 5;
            }
            if (e.KeyCode == Keys.A)
            {
                center.y -= 5;
            }
            if (e.KeyCode == Keys.D)
            {
                center.y += 5;
            }
            picCanvas.Refresh();
            ObjFlower.PlotShape(picCanvas, center, tetha);


        }

        private void picCanvas_Click(object sender, EventArgs e)
        {

        }

        private void picCanvas_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            picCanvas.Refresh();
            if (e.KeyCode == Keys.D)
            {
                center.x += 5;
            }
            if (e.KeyCode == Keys.A)
            {
                center.x -= 5;
            }
            if (e.KeyCode == Keys.W)
            {
                center.y -= 5;
            }
            if (e.KeyCode == Keys.S)
            {
                center.y += 5;
            }

            ObjFlower.PlotShape(picCanvas, center, tetha);


        }

        private void btnRotDer_Click(object sender, EventArgs e)
        {
            picCanvas.Refresh();
            tetha += 0.0872665f;
            ObjFlower.PlotShape(picCanvas, center, tetha);
        }

        private void btnRotIzq_Click(object sender, EventArgs e)
        {
            picCanvas.Refresh();
            tetha -= 0.0872665f;
            ObjFlower.PlotShape(picCanvas, center, tetha);
        }
    }
}
