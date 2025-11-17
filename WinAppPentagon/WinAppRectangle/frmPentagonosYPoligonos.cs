using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppRectangle
{
    public partial class frmPentagonosYPoligonos : Form
    {
        CPentagonosYPoligonos ObjPentyPoli = new CPentagonosYPoligonos();
        Punto center = new Punto();
        float tetha = 0.0f;

        public frmPentagonosYPoligonos()
        {
            InitializeComponent();
            center.y = picCanvas.Size.Height / 2;
            center.x = picCanvas.Size.Width / 2;
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            try
            {
                ObjPentyPoli.ReadData(float.Parse(txtRadio.Text));
                ObjPentyPoli.PlotShape(picCanvas, center, tetha);
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
            ObjPentyPoli.initializeData(txtRadio, picCanvas);
            txtRadio.Enabled = true;
        }

        private void frmPentagonosYPoligonos_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) 
            { 
                case Keys.W:
                    center.x += 5;
                    break;
                    case Keys.S:
                    center.x -= 5;
                    break;
                    case Keys.A:
                    center.y -= 5;
                    break;
                    case Keys.D:
                    center.y += 5;
                    break;
            }
            picCanvas.Refresh();
            ObjPentyPoli.PlotShape(picCanvas, center, tetha);
        }

        private void tbEscala_Scroll(object sender, EventArgs e)
        {
            try
            {
                picCanvas.Refresh();
                Transformacion transformacion = new Transformacion();
                ObjPentyPoli.ReadData(transformacion.Scale(float.Parse(txtRadio.Text), tbEscala.Value));
                ObjPentyPoli.PlotShape(picCanvas, center, tetha);
                txtRadio.Enabled = false;
                picCanvas.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }

        private void tbEscala_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.W:
                    center.x += 5;
                    break;
                case Keys.S:
                    center.x -= 5;
                    break;
                case Keys.A:
                    center.y -= 5;
                    break;
                case Keys.D:
                    center.y += 5;
                    break;
            }
            picCanvas.Refresh();
            ObjPentyPoli.PlotShape(picCanvas, center, tetha);
        }

        private void picCanvas_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.D:
                    center.x += 5;
                    break;
                case Keys.A:
                    center.x -= 5;
                    break;
                case Keys.W:
                    center.y -= 5;
                    break;
                case Keys.S:
                    center.y += 5;
                    break;
            }
            picCanvas.Refresh();
            ObjPentyPoli.PlotShape(picCanvas, center, tetha);
        }

        private void btnRotDer_Click(object sender, EventArgs e)
        {
            picCanvas.Refresh();
            tetha += 0.0872665f;
            ObjPentyPoli.PlotShape(picCanvas, center, tetha);
        }

        private void btnRotIzq_Click(object sender, EventArgs e)
        {
            picCanvas.Refresh();
            tetha -= 0.0872665f;
            ObjPentyPoli.PlotShape(picCanvas, center, tetha);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
