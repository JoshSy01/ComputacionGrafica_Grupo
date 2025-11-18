using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinAppRectangle
{
    internal class CRombo
    {
        private float lado = 0f;           // longitud del lado en px
        private float anguloGrados = 60f;  // ángulo interior (grados). valor por defecto 60°

        public CRombo() { }

        // Leer datos: lado (px) y opcionalmente ángulo interior en grados
        public void ReadData(float ladoPx, float anguloInteriorDeg = 60f)
        {
            lado = Math.Max(0f, ladoPx);
            anguloGrados = anguloInteriorDeg;
        }

        // Dibuja el rombo centrado en el picturebox, aplica escala desde tbValue (trackbar)
        // y escribe perímetro/área en los textbox provistos (formato con 2 decimales).
        public void PlotShape(PictureBox pic, TextBox txtPerimeter = null, TextBox txtArea = null, int tbValue = 0, float rotationDeg = 0f)
        {
            if (pic == null || lado <= 0f) return;

            // Mapear tbValue a escala. Uso la convención: escala = 1 + tb/50 (tb: -50..50)
            float scale = 1.0f + tbValue / 50.0f;
            const float MIN_SCALE = 0.05f;
            if (float.IsNaN(scale) || float.IsInfinity(scale) || scale < MIN_SCALE) scale = MIN_SCALE;

            // calcular diagonales en función del lado y del ángulo interior
            double alpha = anguloGrados * Math.PI / 180.0;
            // p = 2 * s * cos(alpha/2), q = 2 * s * sin(alpha/2)  (diagonales)
            float p = (float)(2.0 * lado * Math.Cos(alpha / 2.0));
            float q = (float)(2.0 * lado * Math.Sin(alpha / 2.0));
            float halfP = p / 2f;
            float halfQ = q / 2f;

            // puntos del rombo (centrado en el origen antes de transformar)
            PointF[] pts = new PointF[4]
            {
                new PointF(0f, -halfQ),    // arriba
                new PointF(halfP, 0f),     // derecha
                new PointF(0f, halfQ),     // abajo
                new PointF(-halfP, 0f)     // izquierda
            };

            // preparar bitmap y graphics
            Bitmap bmp = new Bitmap(pic.Width, pic.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.White);

                // transformación: escalar, rotar y trasladar al centro del picturebox
                Matrix m = new Matrix();
                m.Scale(scale, scale, MatrixOrder.Append);
                m.Rotate(rotationDeg, MatrixOrder.Append);
                m.Translate(pic.Width / 2f, pic.Height / 2f, MatrixOrder.Append);

                // aplicar transform protegida
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

                // dibujar rombo
                using (Pen pen = new Pen(Color.Blue, 3f))
                {
                    g.DrawPolygon(pen, pts);

                    // rellenar ligeramente transparente (opcional)
                    using (SolidBrush br = new SolidBrush(Color.FromArgb(60, Color.LightBlue)))
                    {
                        g.FillPolygon(br, pts);
                    }
                }

                // restaurar transform
                g.Restore(gs);
            }

            // asignar imagen al picturebox (liberar anterior)
            Image old = pic.Image;
            pic.Image = bmp;
            old?.Dispose();

            // calcular perímetro y área (antes de la transformación; luego aplicar escala)
            double perRaw = 4.0 * lado;                 // perímetro sin escala (px)
            double areaRaw = lado * lado * Math.Sin(alpha); // área = s^2 * sin(alpha)

            double perScaled = perRaw * scale;
            double areaScaled = areaRaw * scale * scale;

            // escribir en textboxes en formato con 2 decimales
            if (txtPerimeter != null)
                txtPerimeter.Text = perScaled.ToString("F2");
            if (txtArea != null)
                txtArea.Text = areaScaled.ToString("F2");
        }

        // Reiniciar datos y limpiar picturebox si es necesario
        public void initializeData(TextBox txtLado, PictureBox pic)
        {
            if (txtLado != null) txtLado.Text = "";
            lado = 0f;
            if (pic?.Image != null)
            {
                pic.Image.Dispose();
                pic.Image = null;
            }
        }
    }
}
