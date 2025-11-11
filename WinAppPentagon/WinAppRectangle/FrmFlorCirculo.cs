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
    public partial class FrmFlorCirculo : Form
    {
        private float radio = 0;
        private float escala = 1;
        private float rotacion = 0;
        private bool graficado = false;

        public FrmFlorCirculo()
        {
            InitializeComponent();

            // Estado inicial
            tbEscala.Enabled = false;
            btnRotIzq.Enabled = false;
            btnRotDer.Enabled = false;

            // Configuración visual
            picCanvas.BackColor = Color.Black;
        }

        // --- BOTÓN GRAFICAR ---
        private void btnGraficar_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(txtRadio.Text, out radio) || radio <= 0)
            {
                MessageBox.Show("Ingrese un valor válido para el radio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            escala = 1;
            rotacion = 0;
            graficado = true;

            tbEscala.Enabled = true;
            btnRotIzq.Enabled = true;
            btnRotDer.Enabled = true;

            picCanvas.Invalidate();
        }

        // --- EVENTO PAINT ---
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (!graficado || radio <= 0)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.Black);

            float cx = picCanvas.Width / 2f;
            float cy = picCanvas.Height / 2f;

            g.TranslateTransform(cx, cy);
            g.ScaleTransform(escala, escala);
            g.RotateTransform(rotacion);

            using (Pen pen = new Pen(Color.White, 1.2f))
            {
                DibujarFlorDeLaVida(g, pen, radio);
            }

            // Dibujar borde exterior punteado
            using (Pen borde = new Pen(Color.White, 1.2f))
            {
                borde.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                float bordeRadio = 3 * radio; // cubre toda la flor
                g.DrawEllipse(borde, -bordeRadio, -bordeRadio, bordeRadio * 2, bordeRadio * 2);
            }
        }

        // --- DIBUJAR FLOR ---
        private void DibujarFlorDeLaVida(Graphics g, Pen pen, float r)
        {
            // Base: 19 círculos (1 central + 6 primera capa + 12 segunda capa)
            var centros = GenerarCentros(r);

            foreach (var p in centros)
            {
                g.DrawEllipse(pen, p.X - r, p.Y - r, 2 * r, 2 * r);
            }
        }

        // --- GENERAR CENTROS HEXAGONALES ---
        private List<PointF> GenerarCentros(float r)
        {
            var puntos = new List<PointF>();

            // 6 direcciones separadas por 60°
            PointF[] v = new PointF[6];
            for (int i = 0; i < 6; i++)
            {
                double ang = i * Math.PI / 3;
                v[i] = new PointF(
                    r * (float)Math.Cos(ang),
                    r * (float)Math.Sin(ang)
                );
            }

            // Centro
            puntos.Add(new PointF(0, 0));

            // Anillo 1 (6 círculos)
            for (int i = 0; i < 6; i++)
                puntos.Add(v[i]);

            // Anillo 2 (12 círculos)
            for (int i = 0; i < 6; i++)
            {
                // 2*v_i
                puntos.Add(new PointF(2 * v[i].X, 2 * v[i].Y));

                // v_i + v_{i+1}
                PointF w = new PointF(
                    v[i].X + v[(i + 1) % 6].X,
                    v[i].Y + v[(i + 1) % 6].Y
                );
                puntos.Add(w);
            }

            return puntos;
        }

        // --- ESCALA ---
        private void tbEscala_Scroll(object sender, EventArgs e)
        {
            if (!graficado) return;
            escala = 1 + tbEscala.Value / 50f;
            picCanvas.Invalidate();
        }

        // --- ROTACIÓN ---
        private void btnRotIzq_Click(object sender, EventArgs e)
        {
            if (!graficado) return;
            rotacion -= 5;
            picCanvas.Invalidate();
        }

        private void btnRotDer_Click(object sender, EventArgs e)
        {
            if (!graficado) return;
            rotacion += 5;
            picCanvas.Invalidate();
        }

        // --- RESET ---
        private void btnResetear_Click(object sender, EventArgs e)
        {
            txtRadio.Clear();
            radio = 0;
            escala = 1;
            rotacion = 0;
            graficado = false;
            tbEscala.Value = 0;
            tbEscala.Enabled = false;
            btnRotIzq.Enabled = false;
            btnRotDer.Enabled = false;
            picCanvas.Invalidate();
        }

        // --- SALIR ---
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}