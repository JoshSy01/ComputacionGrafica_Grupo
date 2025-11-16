using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        private float offsetX = 0;
        private float offsetY = 0;
        private float pasoMovimiento = 10f; // velocidad del movimiento



        public FrmFlorCirculo()
        {
            InitializeComponent();
            // Estado inicial
            tbEscala.Enabled = false;
            btnRotIzq.Enabled = false;
            btnRotDer.Enabled = false;

            picCanvas.TabStop = true;

            txtAreaCirc.ReadOnly = true;
            txtAreaCont.ReadOnly = true;
            txtAreaPet.ReadOnly = true;
            txtPerContenedor.ReadOnly = true;

            picCanvas.Focus();

            this.KeyPreview = true;
            this.KeyDown += FrmFlorCirculo_KeyDown;
            picCanvas.MouseClick += picCanvas_MouseClick;


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

            txtPerContenedor.Text = PerimetroContenedor(radio).ToString("F4");
            txtAreaCont.Text = AreaContenedor(radio).ToString("F4");
            txtAreaPet.Text = AreaPetalo(radio).ToString("F4");
            txtAreaCirc.Text = Area19Circulos(radio).ToString("F4");

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
            g.TranslateTransform(offsetX, offsetY);

            g.ScaleTransform(escala, escala);
            g.RotateTransform(rotacion);

            // ==== 🔵 CLIP CIRCULAR ====
            float bordeRadio = 2 * radio; // radio del círculo punteado
            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddEllipse(-bordeRadio, -bordeRadio, bordeRadio * 2, bordeRadio * 2);
                g.SetClip(path); // solo se dibuja dentro de este círculo
            }

            // ==== DIBUJO DE LA FLOR ====
            using (Pen pen = new Pen(Color.White, 1.2f))
            {
                DibujarFlorDeLaVida(g, pen, radio);
            }

            // ==== QUITAR CLIP PARA DIBUJAR EL BORDE ====
            g.ResetClip();

            // ==== DIBUJAR BORDE EXTERIOR PUNTEADO ====
            using (Pen borde = new Pen(Color.White, 3f))
            {
                borde.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawEllipse(borde, -bordeRadio, -bordeRadio, bordeRadio * 2, bordeRadio * 2);
            }
        }

        // --- DIBUJAR FLOR ---
        private void DibujarFlorDeLaVida(Graphics g, Pen pen, float r)
        {
            var centros = GenerarCentros(r);

            // 1) --- DIBUJAR LA FLOR COMPLETA (1 + 6 + 12 = 19 círculos) ---
            for (int i = 0; i < 19; i++)
            {
                PointF p = centros[i];
                g.DrawEllipse(pen, p.X - r, p.Y - r, 2 * r, 2 * r);
            }

            // 2) --- TERCER ANILLO: DIBUJAR SOLO LOS 3 PÉTALOS INTERNOS ---
            for (int i = 19; i < centros.Count; i++)
            {
                PointF p = centros[i];

                // calcular ángulo hacia el centro
                float angCentro = (float)(Math.Atan2(-p.Y, -p.X) * 180f / Math.PI);

                // tres pétalos de 60° cada uno
                float[] offsets = { -60f, 0f, 60f };

                foreach (float off in offsets)
                {
                    using (GraphicsPath arco = new GraphicsPath())
                    {
                        RectangleF rect = new RectangleF(p.X - r, p.Y - r, 2 * r, 2 * r);

                        float inicio = angCentro + off;
                        float sweep = 60f;   // pétalo real de la Flor de la Vida

                        arco.AddArc(rect, inicio + rotacion, sweep);
                        g.DrawPath(pen, arco);
                    }
                }
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

            // Anillo 3 (18 círculos)
            for (int i = 0; i < 6; i++)
            {
                // 3*v_i
                puntos.Add(new PointF(3 * v[i].X, 3 * v[i].Y));
                // 2*v_i + v_{i+1}
                PointF w1 = new PointF(
                    2 * v[i].X + v[(i + 1) % 6].X,
                    2 * v[i].Y + v[(i + 1) % 6].Y
                );
                puntos.Add(w1);
                // v_i + 2*v_{i+1}
                PointF w2 = new PointF(
                    v[i].X + 2 * v[(i + 1) % 6].X,
                    v[i].Y + 2 * v[(i + 1) % 6].Y
                );
                puntos.Add(w2);
            }

            return puntos;
        }

        // --- ESCALA ---
        private void tbEscala_Scroll(object sender, EventArgs e)
        {
            if (!graficado) return;

            float valor = tbEscala.Value; // -100 a 100

            float min = 0.1f;
            float normal = 1.0f;
            float max = 3.0f;

            if (valor < 0)
            {
                // Escala de 1.0 hacia abajo hasta 0.1
                escala = normal + (valor / 100f) * (normal - min);
            }
            else
            {
                // Escala de 1.0 hacia arriba hasta 3.0
                escala = normal + (valor / 100f) * (max - normal);
            }

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

        private void FrmFlorCirculo_KeyDown(object sender, KeyEventArgs e)
        {
            if (!graficado) return;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    offsetY -= pasoMovimiento;
                    break;

                case Keys.Down:
                    offsetY += pasoMovimiento;
                    break;

                case Keys.Left:
                    offsetX -= pasoMovimiento;
                    break;

                case Keys.Right:
                    offsetX += pasoMovimiento;
                    break;

                default:
                    return;
            }

            e.Handled = true;
            picCanvas.Invalidate();
        }

        private void picCanvas_MouseClick(object sender, EventArgs e)
        {
            picCanvas.Focus();
        }

        // --- PERÍMETRO DEL CÍRCULO EXTERIOR ---
        double PerimetroContenedor(float r)
        {
            return 4 * Math.PI * r;
        }

        // --- ÁREA DEL CÍRCULO EXTERIOR ---
        double AreaContenedor(float r)
        {
            return 4 * Math.PI * r * r;
        }

        // --- ÁREA DE UN PÉTALO (Vesica Piscis) ---
        double AreaPetalo(float r)
        {
            return ((2 * Math.PI / 3.0) - (Math.Sqrt(3) / 2.0)) * r * r;
        }

        // --- ÁREA DE LOS 19 CÍRCULOS SUMADOS ---
        double Area19Circulos(float r)
        {
            return 19 * Math.PI * r * r;
        }

    }
}

