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
    public partial class frmHexagonFlower : Form
    {
        CHexagonFlower ObjHexaFlow = new CHexagonFlower();
        Punto center = new Punto();
        float tetha = 0.0f;
        private bool dibujado = false;
        private float pasoMovimiento = 10f;
        private float escala = 1.0f;

        private float perimetro;
        private float area;


        public frmHexagonFlower()
        {
            InitializeComponent();
            center.y = picCanvas.Size.Height / 2;
            center.x = picCanvas.Size.Width / 2;
            picCanvas.BackColor = Color.FromArgb(18, 30, 46);
            this.KeyPreview = true;
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            try
            {
                if (float.Parse(txtRadio.Text) <= 0)
                {
                    throw new Exception("El radio debe ser un valor positivo.");
                }else
                {
                    ObjHexaFlow.ReadData(float.Parse(txtRadio.Text));
                    ObjHexaFlow.PlotShape(picCanvas, center, tetha);
                    txtPerPor.Text = ObjHexaFlow.CalcularPerimetroHexagono().ToString();
                    txtAreaPor.Text = ObjHexaFlow.CalcularAreaHexagono().ToString();
                    txtRadio.Enabled = false;
                    tbEscala.Enabled = true;
                    btnRotDer.Enabled = true;
                    btnRotIzq.Enabled = true;
                    dibujado = true;
                    picCanvas.Focus();
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtRadio.Enabled = true;
            tbEscala.Enabled = false;
            btnRotDer.Enabled = false;
            btnRotIzq.Enabled = false;
            picCanvas.Refresh();
            txtRadio.Focus();
        }

        private void frmHexagonFlower_KeyDown(object sender, KeyEventArgs e)
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
                ObjHexaFlow.ReadData(float.Parse(txtRadio.Text) * escala);
                ObjHexaFlow.PlotShape(picCanvas, center, tetha);
                txtPerPor.Text = ObjHexaFlow.CalcularPerimetroHexagono().ToString();
                txtAreaPor.Text = ObjHexaFlow.CalcularAreaHexagono().ToString();
                e.Handled = true;
            }
        }

        private void tbEscala_Scroll(object sender, EventArgs e)
        {
            if (!dibujado) return;

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
            ObjHexaFlow.ReadData(float.Parse(txtRadio.Text) * escala);
            ObjHexaFlow.PlotShape(picCanvas, center, tetha);
            txtPerPor.Text = ObjHexaFlow.CalcularPerimetroHexagono().ToString();
            txtAreaPor.Text = ObjHexaFlow.CalcularAreaHexagono().ToString();
        }

        private void btnRotDer_Click(object sender, EventArgs e)
        {
            picCanvas.Refresh();
            tetha += 0.0872665f;
            ObjHexaFlow.ReadData(float.Parse(txtRadio.Text) * escala);
            ObjHexaFlow.PlotShape(picCanvas, center, tetha);

        }

        private void btnRotIzq_Click(object sender, EventArgs e)
        {
            picCanvas.Refresh();
            tetha -= 0.0872665f;
            ObjHexaFlow.ReadData(float.Parse(txtRadio.Text) * escala);
            ObjHexaFlow.PlotShape(picCanvas, center, tetha);
        }
    }
}
