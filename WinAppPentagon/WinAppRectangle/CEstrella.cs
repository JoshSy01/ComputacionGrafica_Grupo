using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinAppRectangle
{
    internal class CEstrella
    {
        private float radio = 0f;     // radio base (en píxeles)
        private int n = 8;           // número de vértices en circunferencia
        private int step = 3;        // salto para formar la estrella {8/3}

        public CEstrella() { }

        // Leer radio (px)
        public void ReadData(float r)
        {
            radio = Math.Max(0f, r);
        }

        // Inicializar / limpiar
        public void initializeData(TextBox txtRadio, PictureBox pic)
        {
            if (txtRadio != null) txtRadio.Text = "";
            radio = 0f;
            if (pic?.Image != null)
            {
                pic.Image.Dispose();
                pic.Image = null;
            }
        }

        // Dibuja la estrella en el PictureBox y actualiza los textboxes de área y perímetro.
        // center: coordenadas en píxeles del centro final en el picturebox
        // theta: rotación en radianes
        // tbValue: valor del trackbar (se mapea a escala: scale = 1 + tbValue/50)
        // txtArea/ txtPer: TextBox donde se escriben los resultados (opcional)
        public void PlotShape(PictureBox pic, Punto center, float theta, int tbValue = 0, TextBox txtArea = null, TextBox txtPer = null)
        {
            if (radio <= 0f || pic == null) return;

            // Mapear trackbar a escala
            float scale = 1.0f + tbValue / 50.0f;
            const float MIN_SCALE = 0.05f;
            if (float.IsNaN(scale) || float.IsInfinity(scale) || scale < MIN_SCALE) scale = MIN_SCALE;

            // preparar bitmap
            Bitmap bmp = new Bitmap(pic.Width, pic.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                // usar color de fondo del control si existe
                g.Clear(pic.BackColor == Color.Empty ? Color.White : pic.BackColor);

                // configurar transformación: escalar, rotar (deg), trasladar al centro
                Matrix m = new Matrix();
                m.Scale(scale, scale, MatrixOrder.Append);
                float thetaDeg = theta * 180f / (float)Math.PI;
                m.Rotate(thetaDeg, MatrixOrder.Append);
                // convertir explícitamente a float para evitar CS1503 si Punto usa double
                m.Translate((float)center.x, (float)center.y, MatrixOrder.Append);

                // proteger asignación de transform
                GraphicsState gs = g.Save();
                try
                {
                    float[] el = m.Elements;
                    bool ok = true;
                    foreach (float v in el)
                    {
                        if (float.IsNaN(v) || float.IsInfinity(v)) { ok = false; break; }
                    }
                    if (ok) g.Transform = m;
                    else g.ResetTransform();
                }
                catch
                {
                    g.ResetTransform();
                }

                
                // calcular puntos en la circunferencia
                PointF[] circPts = new PointF[n];
                for (int i = 0; i < n; i++)
                {
                    double ang = -Math.PI / 2 + i * 2 * Math.PI / n;
                    circPts[i] = new PointF(
                        (float)(radio * Math.Cos(ang)),
                        (float)(radio * Math.Sin(ang))
                    );
                }

                // dibujar la estrella conectando con salto 'step'
                using (Pen pen = new Pen(Color.Blue, 3.5f))
                {
                    pen.LineJoin = LineJoin.Round;
                    for (int i = 0; i < n; i++)
                    {
                        int next = (i + step) % n;
                        g.DrawLine(pen, circPts[i], circPts[next]);
                    }
                }

                // calcular perímetro y área de la estrella (en coordenadas sin transformar)
                try
                {
                    List<PointF> order = new List<PointF>(n);
                    int idx = 0;
                    for (int k = 0; k < n; k++)
                    {
                        order.Add(circPts[idx]);
                        idx = (idx + step) % n;
                    }
                    PointF[] starPts = order.ToArray();
                    double periRaw = PolygonPerimeter(starPts); // px
                    double areaRaw = Math.Abs(PolygonArea(starPts)); // px^2

                    double periScaled = periRaw * scale;
                    double areaScaled = areaRaw * scale * scale;

                    if (txtPer != null) txtPer.Text = periScaled.ToString("F2");
                    if (txtArea != null) txtArea.Text = areaScaled.ToString("F2");
                }
                catch
                {
                    // no bloquear dibujo si falla cálculo
                }

                // restaurar y terminar
                g.Restore(gs);
            }

            // asignar imagen y liberar anterior
            Image old = pic.Image;
            pic.Image = bmp;
            old?.Dispose();
        }

        private double PolygonPerimeter(PointF[] pts)
        {
            double sum = 0.0;
            for (int i = 0; i < pts.Length; i++)
            {
                PointF a = pts[i];
                PointF b = pts[(i + 1) % pts.Length];
                double dx = b.X - a.X; double dy = b.Y - a.Y;
                sum += Math.Sqrt(dx * dx + dy * dy);
            }
            return sum;
        }

        // Shoelace
        private double PolygonArea(PointF[] pts)
        {
            double s = 0.0;
            int m = pts.Length;
            for (int i = 0; i < m; i++)
            {
                int j = (i + 1) % m;
                s += pts[i].X * pts[j].Y - pts[j].X * pts[i].Y;
            }
            return 0.5 * s;
        }
    }
}
