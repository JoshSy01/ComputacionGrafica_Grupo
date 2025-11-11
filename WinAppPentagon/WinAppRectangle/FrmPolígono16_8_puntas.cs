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
    public partial class FrmPolígono16_8_puntas : Form
    {
        float escala = 1.0f;
        float rotacion = 0.0f;
        float radio = 0.0f;
        bool graficado = false;

        public FrmPolígono16_8_puntas()
        {
            InitializeComponent();
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(txtRadio.Text, out radio) || radio <= 0)
            {
                MessageBox.Show("Ingrese un valor válido para el radio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // opcional: limitar el radio para que quepa en el picturebox
            float maxAllowed = Math.Min(picCanvas.Width, picCanvas.Height) * 0.45f;
            if (radio > maxAllowed)
            {
                var r = MessageBox.Show($"El radio es grande y puede salirse del área. ¿Usar {maxAllowed:F0} en su lugar?", "Radio grande", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes) radio = maxAllowed;
            }

            graficado = true;
            picCanvas.Invalidate();

            tbEscala.Enabled = true;
            btnRotDer.Enabled = true;
            btnRotIzq.Enabled = true;
            btnResetear.Enabled = true;
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (!graficado) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            // centro del canvas
            float cx = picCanvas.Width / 2f;
            float cy = picCanvas.Height / 2f;

            // aplicar transformaciones
            g.TranslateTransform(cx, cy);
            g.ScaleTransform(escala, escala);
            g.RotateTransform(rotacion);

            Pen pen = new Pen(Color.Black, 1f);
            // para líneas más prominentes, duplicar o usar diferentes grosores en capas:
            Pen thick = new Pen(Color.Black, 1.6f);

            int n = 16;
            double ang = 2 * Math.PI / n;

            // Ajusta estos factores para afinar la apariencia:
            float rInner = radio * 0.18f;  // innermost "estrella"
            float rMid = radio * 0.45f;  // capa media
            float rOuter = radio;          // capa exterior (puntas)

            // Calculamos puntos en cada anillo
            PointF[] inner = new PointF[n];
            PointF[] mid = new PointF[n];
            PointF[] outer = new PointF[n];

            for (int i = 0; i < n; i++)
            {
                double a = i * ang;
                inner[i] = new PointF(rInner * (float)Math.Cos(a), rInner * (float)Math.Sin(a));
                mid[i] = new PointF(rMid * (float)Math.Cos(a), rMid * (float)Math.Sin(a));
                outer[i] = new PointF(rOuter * (float)Math.Cos(a), rOuter * (float)Math.Sin(a));
            }

            // 1) Conexiones radiales (desde centro a puntas exteriores) - base de la estrella
            for (int i = 0; i < n; i++)
                g.DrawLine(pen, 0f, 0f, outer[i].X, outer[i].Y);

            // 2) Dibujar varios polígonos tipo "estrella" conectando con salto (step)
            // Ajusta stepOuter/stepMid/stepInner para cambiar el patrón estrellado
            int stepOuter = 3; // conexión entre outer[i] y outer[i+stepOuter]
            int stepMid = 5; // conexión entre mid[i]   y mid[i+stepMid]
            int stepInner = 2; // conexión entre inner[i] y inner[i+stepInner]

            // Outer star (genera la silueta estrellada)
            for (int i = 0; i < n; i++)
            {
                int j = (i + stepOuter) % n;
                g.DrawLine(thick, outer[i], outer[j]);
            }

            // Mid star (otra estrella interna)
            for (int i = 0; i < n; i++)
            {
                int j = (i + stepMid) % n;
                g.DrawLine(pen, mid[i], mid[j]);
            }

            // Inner star (más definida)
            for (int i = 0; i < n; i++)
            {
                int j = (i + stepInner) % n;
                g.DrawLine(pen, inner[i], inner[j]);
            }

            // 3) Conexiones diagonales entre anillos para formar las puntas internas y polígonos
            for (int i = 0; i < n; i++)
            {
                int next = (i + 1) % n;

                // conexiones tipo "triángulo" entre niveles (genera aristas internas)
                g.DrawLine(pen, inner[i], mid[i]);
                g.DrawLine(pen, mid[i], outer[i]);

                // conexiones cruzadas con vecinos (afina la forma de estrella interna)
                g.DrawLine(pen, outer[i], mid[next]);
                g.DrawLine(pen, mid[i], inner[next]);

                // también puedes dibujar las "aristas" circulares (conectar con el siguiente)
                g.DrawLine(pen, outer[i], outer[next]);
                g.DrawLine(pen, mid[i], mid[next]);
                g.DrawLine(pen, inner[i], inner[next]);
            }

            // 4) (Opcional) marcar el centro con un pequeño círculo
            float centerMarkRadius = Math.Max(2f, radio * 0.01f);
            g.FillEllipse(Brushes.Black, -centerMarkRadius, -centerMarkRadius, centerMarkRadius * 2f, centerMarkRadius * 2f);

            // Liberar recursos de pens si deseas (no estrictamente necesario aquí)
            pen.Dispose();
            thick.Dispose();
        }

        private void tbEscala_Scroll(object sender, EventArgs e)
        {
            if (!graficado) return;
            escala = 1.0f + (tbEscala.Value / 100f);
            picCanvas.Invalidate();
        }

        private void btnRotIzq_Click(object sender, EventArgs e)
        {
            if (!graficado) return;
            rotacion -= 10f;
            picCanvas.Invalidate();
        }

        private void btnRotDer_Click(object sender, EventArgs e)
        {
            if (!graficado) return;
            rotacion += 10f;
            picCanvas.Invalidate();
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            txtRadio.Clear();
            tbEscala.Value = 0;
            escala = 1.0f;
            rotacion = 0.0f;
            radio = 0.0f;
            graficado = false;
            picCanvas.Invalidate();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}