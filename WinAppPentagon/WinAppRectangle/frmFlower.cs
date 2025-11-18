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
        private float originalRadio = 0f;
        private bool dibujado = false;
        private const float pasoMovimiento = 5f;

        public frmFlower()
        {
            InitializeComponent();
            this.KeyPreview = true;
            // inicializar centro cuando el control ya tenga tamaño
            center.y = picCanvas.ClientSize.Height / 2f;
            center.x = picCanvas.ClientSize.Width / 2f;

            tbEscala.Enabled = false;
            btnRotDer.Enabled = false;
            btnRotIzq.Enabled = false;

            this.KeyDown += frmFlower_KeyDown;
            picCanvas.PreviewKeyDown += picCanvas_PreviewKeyDown;
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!float.TryParse(txtRadio.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out float r) || r <= 0f)
                {
                    MessageBox.Show("Ingrese un radio válido (>0).");
                    return;
                }

                originalRadio = r;
                dibujado = true;
                tbEscala.Enabled = true;
                btnRotDer.Enabled = true;
                btnRotIzq.Enabled = true;
                txtRadio.Enabled = false;

                RefreshPlot();
                picCanvas.Focus();
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
            dibujado = false;
            originalRadio = 0f;
            // limpiar dibujo y métricas
            if (picCanvas.Image != null) { picCanvas.Image.Dispose(); picCanvas.Image = null; }
            txtAreaPor.Text = "";
            txtPerPor.Text = "";
            picCanvas.Refresh();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbEscala_Scroll(object sender, EventArgs e)
        {
            try
            {
                if (!dibujado) return;

                // actualizar plot con nueva escala
                RefreshPlot();
                picCanvas.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void frmFlower_KeyDown(object sender, KeyEventArgs e)
        {
            if (!dibujado) return;

            bool moved = false;
            switch (e.KeyCode)
            {
                case Keys.W:
                case Keys.Up:
                    center.y -= pasoMovimiento; moved = true; break;
                case Keys.S:
                case Keys.Down:
                    center.y += pasoMovimiento; moved = true; break;
                case Keys.A:
                case Keys.Left:
                    center.x -= pasoMovimiento; moved = true; break;
                case Keys.D:
                case Keys.Right:
                    center.x += pasoMovimiento; moved = true; break;
            }

            if (moved)
            {
                RefreshPlot();
                e.Handled = true;
            }
        }

        private void picCanvas_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // manejar las mismas teclas que en KeyDown (asegura captura en PictureBox)
            frmFlower_KeyDown(sender, new KeyEventArgs(e.KeyCode));
        }

        private void btnRotDer_Click(object sender, EventArgs e)
        {
            if (!dibujado) return;
            tetha += 0.0872665f; // +5 grados en radianes
            RefreshPlot();
        }

        private void btnRotIzq_Click(object sender, EventArgs e)
        {
            if (!dibujado) return;
            tetha -= 0.0872665f; // -5 grados en radianes
            RefreshPlot();
        }

        // Helper: obtiene el radio actual aplicando la escala del trackbar
        private float GetCurrentRadius()
        {
            if (originalRadio <= 0f) return 0f;
            float scale = 1.0f + tbEscala.Value / 50.0f;
            const float MIN_SCALE = 0.05f;
            if (float.IsNaN(scale) || float.IsInfinity(scale) || scale < MIN_SCALE) scale = MIN_SCALE;
            return originalRadio * scale;
        }

        // Refresca dibujo y actualiza txtAreaPor / txtPerPor
        private void RefreshPlot()
        {
            float currentRadius = GetCurrentRadius();
            if (currentRadius <= 0f) return;

            // asegurar que el objeto tenga el radio actualizado
            ObjFlower.ReadData(currentRadius);

            // repintar
            picCanvas.Refresh();
            ObjFlower.PlotShape(picCanvas, center, tetha);

            // calcular área y perímetro totales de los 8 pétalos (triángulos) y mostrar
            try
            {
                int petals = 8;
                double r = currentRadius;
                double rConn = r * 0.7071;
                double totalArea = 0.0;
                double totalPer = 0.0;
                for (int i = 0; i < petals; i++)
                {
                    double ai = i * 2.0 * Math.PI / petals + tetha;
                    double aNext = ((i + 1) % petals) * 2.0 * Math.PI / petals + tetha;

                    // puntos relativos al centro (origin)
                    double cx = 0.0, cy = 0.0;
                    double connX = rConn * Math.Cos(ai), connY = rConn * Math.Sin(ai);
                    double outerX = r * Math.Cos(aNext), outerY = r * Math.Sin(aNext);

                    // área triángulo por shoelace (centro, conn, outer)
                    double area = Math.Abs(connX * outerY - outerX * connY) / 2.0;
                    totalArea += area;

                    // perímetro triángulo
                    double d0 = Math.Sqrt(connX * connX + connY * connY); // center->conn = rConn
                    double d1 = Math.Sqrt((outerX - connX) * (outerX - connX) + (outerY - connY) * (outerY - connY)); // conn->outer
                    double d2 = Math.Sqrt(outerX * outerX + outerY * outerY); // outer->center = r
                    totalPer += d0 + d1 + d2;
                }

                txtAreaPor.Text = totalArea.ToString("F2");
                txtPerPor.Text = totalPer.ToString("F2");
            }
            catch
            {
                // no bloquear la UI si falla el cálculo
                txtAreaPor.Text = "";
                txtPerPor.Text = "";
            }
        }
    }
}
