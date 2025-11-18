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
    public partial class frmCopoDeNieve : Form
    {
        Punto center = new Punto();
        float tethaAdd = 0.0f;
        CCopoDeNieve copoDeNieve = new CCopoDeNieve();
        private bool dibujado = false;
        private float pasoMovimiento = 10f;
        private float escala = 1.0f;


        public frmCopoDeNieve()
        {
            InitializeComponent();
            center.x = picCanvas.Width / 2;
            center.y = picCanvas.Height / 2;
            this.KeyPreview = true;
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            try { 
                if (float.Parse(txtRadio.Text) <= 0)
                {
                    throw new Exception("El radio debe ser un valor positivo.");
                }
                else
                {
                    picCanvas.Refresh();
                    copoDeNieve.ReadData(float.Parse(txtRadio.Text));
                    copoDeNieve.PlotShape(picCanvas, center, tethaAdd);
                    txtPerPor.Text = copoDeNieve.CalcularPerimetroDecagono().ToString();
                    txtAreaPor.Text = copoDeNieve.CalcularAreaDecagono().ToString();
                    picCanvas.Focus();
                    dibujado = true;
                    tbEscala.Enabled = true;
                    btnRotDer.Enabled = true;
                    btnRotIzq.Enabled = true;
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
}

        private void frmCopoDeNieve_Load(object sender, EventArgs e)
        {

        }

        private void frmCopoDeNieve_KeyDown(object sender, KeyEventArgs e)
        {
            if (!dibujado) return;

            bool moved = false;

            switch (e.KeyCode)
            {
                case Keys.Left:
                    center.x -= pasoMovimiento;
                    moved = true;
                    break;

                case Keys.Right:
                    center.x += pasoMovimiento;
                    moved = true;
                    break;

                case Keys.Up:
                    center.y -= pasoMovimiento;
                    moved = true;
                    break;

                case Keys.Down:
                    center.y += pasoMovimiento;
                    moved = true;
                    break;
            }

            if (moved)
            {
                picCanvas.Refresh();
                copoDeNieve.ReadData(float.Parse(txtRadio.Text) * escala);
                copoDeNieve.PlotShape(picCanvas, center, tethaAdd);
                e.Handled = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dibujado = false;
            picCanvas.Invalidate();
        }

        private void tbEscala_Scroll(object sender, EventArgs e)
        {
            float valor = tbEscala.Value;  // -100 a 100

            float min = 0.1f;   // escala mínima (10%)
            float normal = 1.0f;
            float max = 3.0f;   // escala máxima (300%)

            if (valor < 0)
            {
                escala = normal + (valor / 100f) * (normal - min);
            }
            else
            {
                escala = normal + (valor / 100f) * (max - normal);
            }

            picCanvas.Refresh();
            copoDeNieve.ReadData(float.Parse(txtRadio.Text) * escala);
            copoDeNieve.PlotShape(picCanvas, center, tethaAdd);
            txtAreaPor.Text = copoDeNieve.CalcularAreaDecagono().ToString();
            txtPerPor.Text = copoDeNieve.CalcularPerimetroDecagono().ToString();
        }

        private void btnRotDer_Click(object sender, EventArgs e)
        {
            picCanvas.Refresh();
            tethaAdd += 0.0872665f;
            copoDeNieve.PlotShape(picCanvas, center, tethaAdd);
        }

        private void btnRotIzq_Click(object sender, EventArgs e)
        {
            picCanvas.Refresh();
            tethaAdd -= 0.0872665f;
            copoDeNieve.PlotShape(picCanvas, center, tethaAdd);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
