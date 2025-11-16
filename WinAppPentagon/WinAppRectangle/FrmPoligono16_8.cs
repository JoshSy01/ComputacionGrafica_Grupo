using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppRectangle
{
    public partial class FrmPoligono16_8 : Form
    {
        private float radio = 0;
        private float escala = 1;
        private float angulo = 0;

        private float offsetX = 0;
        private float offsetY = 0;
        private float pasoMovimiento = 10f;


        private bool dibujado = false;


        public FrmPoligono16_8()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += FrmPoligono16_8_KeyDown;

            txtPerPor.ReadOnly = true;
            txtAreaPor.ReadOnly = true;
            txtAreaTotal.ReadOnly = true;
            txtPerTotal.ReadOnly = true;

        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(txtRadio.Text, out radio) || radio <= 0)
            {
                MessageBox.Show("Ingrese un radio válido.");
                return;
            }
            offsetX = 0;
            offsetY = 0;


            escala = 1;
            angulo = 0;
            tbEscala.Value = 0;

            tbEscala.Enabled = true;
            btnRotIzq.Enabled = true;
            btnRotDer.Enabled = true;

            dibujado = true;
            picCanvas.Invalidate();

        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            offsetX = 0;
            offsetY = 0;

            dibujado = false;
            picCanvas.Invalidate();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();


        }

        private void tbEscala_Scroll(object sender, EventArgs e)
        {
            float valor = tbEscala.Value;  // -100 a 100

            float min = 0.1f;   // escala mínima (10%)
            float normal = 1.0f;
            float max = 3.0f;   // escala máxima (300%)

            if (valor < 0)
            {
                // Escala desde 1.0 hacia 0.1
                escala = normal + (valor / 100f) * (normal - min);
            }
            else
            {
                // Escala desde 1.0 hacia 3.0
                escala = normal + (valor / 100f) * (max - normal);
            }

            picCanvas.Invalidate();
        }


        private void btnRotIzq_Click(object sender, EventArgs e)
        {
            angulo -= 5;
            picCanvas.Invalidate();
        }

        private void btnRotDer_Click(object sender, EventArgs e)
        {
            angulo += 5;
            picCanvas.Invalidate();

        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (!dibujado) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            float cx = picCanvas.Width / 2f;
            float cy = picCanvas.Height / 2f;

            g.TranslateTransform(cx + offsetX, cy + offsetY);
            g.ScaleTransform(escala, escala);
            g.RotateTransform(angulo);

            for (int i = 0; i < 8; i++)
            {
                DrawSlice(g, radio);     // draw slice
                g.RotateTransform(45);
            }

            g.ResetTransform();


        }

        private void DrawSlice(Graphics g, float R)
        {
            float theta = (float)(Math.PI / 4); // 45° slice

            //real proportions observed manually
            float r0 = 0.30f * R; // inner arrow origin
            float r1 = 0.42f * R; // inner small ring
            float r2 = 0.62f * R; // yellow arrow tip
            float r3 = 0.82f * R; // green arrow tip
            float r4 = 1.00f * R; // outer ring

            // key points
            PointF P0 = Polar(r0, theta / 2);

            PointF P1 = Polar(r1, 0);
            PointF P2 = Polar(r1, theta);

            // both yellow + green arrows point same direction
            double arrowAngle = theta * 0.45;

            PointF P3 = Polar(r2, arrowAngle); // yellow tip
            PointF P4 = Polar(r3, arrowAngle); // green tip

            PointF P5 = Polar(r4, 0);
            PointF P6 = Polar(r4, theta);

            // angles for new points
            double aP0 = theta / 2;
            double aP3 = arrowAngle;

            // P7 between center and P0
            PointF P7 = Polar(r0 * 0.70f, aP0);

            // P8 between center and P3
            PointF P8 = Polar(r2 * 0.90f, aP3);

            // P9 = same direction as P4 but further outward
            PointF P9 = Polar(0.95f * R, arrowAngle);

            // --- CÁLCULO DE ÁREA Y PERÍMETRO DEL SLICE ---

            PointF O = new PointF(0, 0);

            // perímetro del slice
            double perSlice =
                Dist(O, P5) +
                Dist(P5, P9) +
                Dist(P9, P6) +
                Dist(P6, O);

            // área del slice
            double areaSlice = AreaPoligono(O, P5, P9, P6, O);

            // enviar valores al formulario
            txtPerPor.Text = perSlice.ToString("F4");
            txtAreaPor.Text = areaSlice.ToString("F4");

            txtPerTotal.Text = (perSlice * 8).ToString("F4");
            txtAreaTotal.Text = (areaSlice * 8).ToString("F4");



            // Draw all lines
            Pen p = Pens.Black;

            // blue section
            g.DrawLine(p, P0, P1);
            g.DrawLine(p, P1, P7);
            g.DrawLine(p, P2, P7);

            // reinforce inner structure
            g.DrawLine(p, P0, P2);

            // yellow fork
            g.DrawLine(p, P1, P3);
            g.DrawLine(p, P2, P3);
            g.DrawLine(p, P1, P8);
            g.DrawLine(p, P2, P8);

            // green extensions
            g.DrawLine(p, P3, P4);
            g.DrawLine(p, P4, P5);
            g.DrawLine(p, P4, P6);
            g.DrawLine(p, P3, P5);     
            g.DrawLine(p, P3, P6);     

            // border
            g.DrawLine(p, P5, P9);
            g.DrawLine(p, P6, P9);

            // middle line
            g.DrawLine(p, P9, new PointF(0, 0));
            g.DrawLine(p, P6, new PointF(0, 0));

            // === CÍRCULO DEL COLOR DEL FORM ===

            // Color del fondo del Form
            Color fondoForm = this.BackColor;

            // middle line
            g.DrawLine(p, P9, new PointF(0, 0));

            // center circle
            float centerRadius = R * 0.03f;

            using (SolidBrush b = new SolidBrush(fondoForm))
            {
                g.FillEllipse(b, -centerRadius, -centerRadius,
                              centerRadius * 2, centerRadius * 2);
            }
            // Borde negro
            using (Pen borde = new Pen(Color.Black, 2))
            {
                g.DrawEllipse(borde, -centerRadius, -centerRadius, 
                   centerRadius * 2, centerRadius * 2);
            }



        }

        private PointF Polar(float r, double a)
        {
            return new PointF(
                (float)(r * Math.Cos(a)),
                (float)(r * Math.Sin(a))
            );
        }

        private void FrmPoligono16_8_KeyDown(object sender, KeyEventArgs e)
        {
            if (!dibujado) return;

            bool moved = false;

            switch (e.KeyCode)
            {
                case Keys.Left:
                    offsetX -= pasoMovimiento;
                    moved = true;
                    break;

                case Keys.Right:
                    offsetX += pasoMovimiento;
                    moved = true;
                    break;

                case Keys.Up:
                    offsetY -= pasoMovimiento;
                    moved = true;
                    break;

                case Keys.Down:
                    offsetY += pasoMovimiento;
                    moved = true;
                    break;
            }

            if (moved)
            {
                picCanvas.Invalidate();
                e.Handled = true;
            }
        }

        // Distancia entre dos puntos
        double Dist(PointF a, PointF b)
        {
            return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
        }

        // Área de un polígono con fórmula de Shoelace
        double AreaPoligono(params PointF[] pts)
        {
            double sum = 0;
            for (int i = 0; i < pts.Length - 1; i++)
            {
                sum += (pts[i].X * pts[i + 1].Y) - (pts[i + 1].X * pts[i].Y);
            }
            return Math.Abs(sum) / 2.0;
        }


    }
}