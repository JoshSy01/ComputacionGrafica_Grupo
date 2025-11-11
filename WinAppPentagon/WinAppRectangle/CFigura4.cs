using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinAppFigure
{
    // Clase auxiliar de punto (si ya la tienes, puedes usar la tuya)
    public class Punto
    {
        public float x;
        public float y;
    }

    // Clase que encapsula el dibujo de la "Figura 4"
    public class CFigura4
    {
        private float radio = 0f;     // radio base (en píxeles)
        private int n = 8;           // número de vértices en circunferencia (8)
        private int step = 3;        // salto para formar la estrella {8/3}

        public CFigura4() { }

        // Lee el radio (en píxeles). Llamar antes de PlotShape
        public void ReadData(float r)
        {
            radio = Math.Max(0f, r);
        }

        // Dibuja la figura aplicada en el PictureBox
        // center: centro en coordenadas del picturebox
        // theta: rotación en radianes
        // tbScaleValue: valor del trackbar (10 => escala 1.0)
        public void PlotShape(PictureBox pic, Punto center, float theta, int tbScaleValue = 10)
        {
            if (radio <= 0 || pic == null) return;

            float scale = tbScaleValue / 10.0f;

            Bitmap bmp = new Bitmap(pic.Width, pic.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                // Fondo oscuro semejante a la imagen original
                g.Clear(Color.FromArgb(18, 30, 46));

                // Configurar transformación: Escalar, luego Rotar, LUEGO trasladar
                Matrix m = new Matrix();

                // 1) aplicar escala (uniforme) - relativo al origen (0,0)
                m.Scale(scale, scale, MatrixOrder.Append);

                // 2) rotación - relativo al origen (0,0)
                float thetaDeg = theta * 180f / (float)Math.PI;
                m.Rotate(thetaDeg, MatrixOrder.Append);

                // 3) trasladar el resultado al centro (ESTE PASO VA AL FINAL)
                m.Translate(center.x, center.y, MatrixOrder.Append);

                // Guardar estado original y aplicar transform
                GraphicsState gs = g.Save();
                g.Transform = m;

                // Dibujar guías entrecortadas (se dibujan alrededor del origen (0,0) ya transformado)
                using (Pen guidePen = new Pen(Color.FromArgb(160, Color.LightGray), 1f))
                {
                    guidePen.DashStyle = DashStyle.Dash;

                    // círculos concéntricos
                    float rr = radio;
                    DrawCircle(g, guidePen, rr);
                    DrawCircle(g, guidePen, rr - rr / 10f);      // radio - h (h = radio/10)
                    DrawCircle(g, guidePen, rr - (4 * rr / 10f));// radio - 4h
                    DrawCircle(g, guidePen, rr - (7 * rr / 10f));// radio - 7h

                    // ejes principales (líneas radiales)
                    for (int i = 0; i < 8; i++)
                    {
                        double ang = -Math.PI / 2 + i * 2 * Math.PI / 8.0; // desde arriba
                        float x = (float)(rr * Math.Cos(ang));
                        float y = (float)(rr * Math.Sin(ang));
                        g.DrawLine(guidePen, 0f, 0f, x, y);
                    }
                }

                // Ahora dibujamos las líneas blancas gruesas (la "malla" y la estrella)
                using (Pen whitePen = new Pen(Color.White, 6f))
                using (Pen innerPen = new Pen(Color.White, 3.5f))
                {
                    whitePen.LineJoin = LineJoin.Round;
                    innerPen.LineJoin = LineJoin.Round;

                    // puntos cardinales en coordenadas relativas al origen
                    PointF A = new PointF(0f, -radio);
                    PointF B = new PointF(radio, 0f);
                    PointF C = new PointF(0f, radio);
                    PointF D = new PointF(-radio, 0f);

                    float h = radio / 10.0f;
                    float r_cos45 = (float)(radio * Math.Cos(Math.PI / 4));
                    float r_sin45 = (float)(radio * Math.Sin(Math.PI / 4));

                    PointF A_prime = new PointF(-r_sin45, -r_cos45);
                    PointF B_prime = new PointF(r_cos45, -r_sin45);
                    PointF C_prime = new PointF(r_sin45, r_cos45);
                    PointF D_prime = new PointF(-r_cos45, r_sin45);

                    // dibujar la malla blanca exterior (cuadrado en los puntos A,B,C,D)
                    g.DrawLine(whitePen, A, B);
                    g.DrawLine(whitePen, B, C);
                    g.DrawLine(whitePen, C, D);
                    g.DrawLine(whitePen, D, A);

                    // cuadrado interno (rotado 45°)
                    g.DrawLine(whitePen, A_prime, B_prime);
                    g.DrawLine(whitePen, B_prime, C_prime);
                    g.DrawLine(whitePen, C_prime, D_prime);
                    g.DrawLine(whitePen, D_prime, A_prime);

                    // líneas diagonales y entrecruzadas (para formar la "estrella" y malla interior)
                    // replicando las líneas del ejemplo que diste
                    g.DrawLine(innerPen, A, C_prime);
                    g.DrawLine(innerPen, A, D_prime);
                    g.DrawLine(innerPen, B_prime, D);
                    g.DrawLine(innerPen, B_prime, C);
                    g.DrawLine(innerPen, B, A_prime);
                    g.DrawLine(innerPen, B, D_prime);
                    g.DrawLine(innerPen, C_prime, D);
                    g.DrawLine(innerPen, C, A_prime);

                    // Además, para acercarnos más a la imagen, dibujamos una estrella poligonal
                    // conectando 8 puntos en la circunferencia con salto 'step'
                    PointF[] circPts = new PointF[n];
                    for (int i = 0; i < n; i++)
                    {
                        double ang = -Math.PI / 2 + i * 2 * Math.PI / n;
                        circPts[i] = new PointF(
                            (float)(radio * Math.Cos(ang)),
                            (float)(radio * Math.Sin(ang))
                        );
                    }

                    // dibujar líneas conectando con salto 'step' (estrella)
                    for (int i = 0; i < n; i++)
                    {
                        int next = (i + step) % n;
                        g.DrawLine(innerPen, circPts[i], circPts[next]);
                    }
                }

                // Restaurar estado gráfico original (quitar transform)
                g.Restore(gs);
            }

            // asignar la imagen al picturebox (liberar antigua)
            Image old = pic.Image;
            pic.Image = bmp;
            old?.Dispose();
        }

        private void DrawCircle(Graphics g, Pen p, float radius)
        {
            if (radius <= 0f) return;
            g.DrawEllipse(p, -radius, -radius, 2 * radius, 2 * radius);
        }

        // reiniciar (limpiar)
        public void initializeData(TextBox txtRadio, PictureBox pic)
        {
            txtRadio.Text = "";
            radio = 0f;
            if (pic.Image != null)
            {
                pic.Image.Dispose();
                pic.Image = null;
            }
        }
    }
}
