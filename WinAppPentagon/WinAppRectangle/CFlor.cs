using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinAppRectangle
{
    // Lógica de la "flor" separada del formulario:
    internal class CFlor
    {
        private float radio = 0f;
        private readonly int petals = 8;
        private Punto[] flowerPoints;
        private Punto[] conexions;

        // Transformaciones acumuladas
        private float offsetX = 0f;
        private float offsetY = 0f;
        private float scale = 1f;
        private float rotationDeg = 0f; // grados

        public CFlor()
        {
            flowerPoints = new Punto[petals + 1]; // [0]=centro, 1..8 pétalos
            conexions = new Punto[petals];
            for (int i = 0; i < flowerPoints.Length; i++) flowerPoints[i] = new Punto();
            for (int i = 0; i < conexions.Length; i++) conexions[i] = new Punto();
        }

        // Leer radio (px)
        public void ReadData(float r)
        {
            radio = Math.Max(0f, r);
        }

        // Reiniciar / limpiar
        public void initializeData(TextBox txtRadio, PictureBox pic)
        {
            if (txtRadio != null) txtRadio.Text = "";
            radio = 0f;
            offsetX = offsetY = 0f;
            scale = 1f;
            rotationDeg = 0f;
            if (pic?.Image != null)
            {
                pic.Image.Dispose();
                pic.Image = null;
            }
        }

        // MOVIMIENTOS / TRANSFORMACIONES (API para el formulario)
        public void Move(float dx, float dy) { offsetX += dx; offsetY += dy; }
        public void SetOffset(float x, float y) { offsetX = x; offsetY = y; }
        public void SetScaleFromTrackBar(int tbValue) // tbValue típico: -100..100 ó 0..100; se mapea como 1 + tb/50
        {
            float s = 1.0f + tbValue / 50.0f;
            const float MIN_SCALE = 0.05f;
            if (float.IsNaN(s) || float.IsInfinity(s) || s < MIN_SCALE) s = MIN_SCALE;
            scale = s;
        }
        public void SetScale(float s) { scale = Math.Max(0.0001f, s); }
        public void ScaleBy(float factor) { SetScale(scale * factor); }
        public void RotateDeg(float d) { rotationDeg += d; }
        public void SetRotationDeg(float d) { rotationDeg = d; }
        public void ResetTransforms() { offsetX = offsetY = 0f; scale = 1f; rotationDeg = 0f; }

        // Calcula área y perímetro (una vez con la geometría básica, sin transformaciones de pantalla)
        // Área de un pétalo (triángulo entre centro, conexión y punto exterior)
        public double CalculatePetalArea()
        {
            if (radio <= 0f) return 0.0;
            // puntos relativos al origen (centro = (0,0))
            float rCon = radio * 0.7071f; // misma proporción usada por el dibujo original
            // tomar el primer pétalo como ejemplo (ángulo 0)
            PointF c = new PointF(0f, 0f);
            PointF pConn = new PointF(rCon, 0f);
            PointF pOuter = new PointF(radio * (float)Math.Cos(0), radio * (float)Math.Sin(0));
            // área triángulo por shoelace
            return Math.Abs((c.X * pConn.Y + pConn.X * pOuter.Y + pOuter.X * c.Y
                           - pConn.X * c.Y - pOuter.X * pConn.Y - c.X * pOuter.Y) / 2.0);
        }
        public double CalculateTotalPetalsArea() => 8 * CalculatePetalArea();

        // Perímetro de un pétalo (triángulo) y total (suma de 8 triángulos)
        public double CalculatePetalPerimeter()
        {
            if (radio <= 0f) return 0.0;
            float rCon = radio * 0.7071f;
            PointF c = new PointF(0f, 0f);
            PointF pConn = new PointF(rCon, 0f);
            PointF pOuter = new PointF(radio, 0f);
            return Dist(c, pConn) + Dist(pConn, pOuter) + Dist(pOuter, c);
        }
        public double CalculateTotalPetalsPerimeter() => 8 * CalculatePetalPerimeter();

        // Dibuja la flor en el PictureBox; theta en radianes, tbValue mapea escala (si se quiere usar)
        public void PlotShape(PictureBox pic, Punto center, float theta, int tbValue = 0, TextBox txtArea = null, TextBox txtPer = null)
        {
            if (radio <= 0f || pic == null) return;

            // si se pasa tbValue lo usamos para calcular escala efectiva (alternativa al SetScale)
            float scaleEffective = scale;
            if (tbValue != 0) scaleEffective = 1.0f + tbValue / 50.0f;
            const float MIN_SCALE = 0.05f;
            if (float.IsNaN(scaleEffective) || float.IsInfinity(scaleEffective) || scaleEffective < MIN_SCALE) scaleEffective = MIN_SCALE;

            // preparar bitmap
            Bitmap bmp = new Bitmap(pic.Width, pic.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(pic.BackColor == Color.Empty ? Color.White : pic.BackColor);

                // transformación: primero escala y rotación alrededor del origen, luego trasladar al centro + offset
                Matrix m = new Matrix();
                m.Scale(scaleEffective, scaleEffective, MatrixOrder.Append);
                float thetaDeg = theta * 180f / (float)Math.PI;
                m.Rotate(thetaDeg + rotationDeg, MatrixOrder.Append);
                // Translate expects floats; Punto puede ser double en otras clases -> convertir
                m.Translate((float)center.x + offsetX, (float)center.y + offsetY, MatrixOrder.Append);

                // validar matriz antes de aplicar
                GraphicsState gs = g.Save();
                try
                {
                    float[] el = m.Elements;
                    bool ok = true;
                    foreach (float v in el) { if (float.IsNaN(v) || float.IsInfinity(v)) { ok = false; break; } }
                    if (ok) g.Transform = m; else g.ResetTransform();
                }
                catch { g.ResetTransform(); }

                // Dibujar líneas desde el origen (centro transformado)
                using (Pen pen = new Pen(Color.Black, 3f))
                {
                    // centro en (0,0)
                    PointF centro = new PointF(0f, 0f);
                    flowerPoints[0].x = centro.X; flowerPoints[0].y = centro.Y;
                    // calcular puntos exteriores y conexions relativos al origen
                    for (int i = 0; i < petals; i++)
                    {
                        double ang = i * 2.0 * Math.PI / petals;
                        float t = (float)ang;
                        // exterior
                        float px = (float)(radio * Math.Cos(ang));
                        float py = (float)(radio * Math.Sin(ang));
                        flowerPoints[i + 1].x = px;
                        flowerPoints[i + 1].y = py;
                    }
                    for (int i = 0; i < petals; i++)
                    {
                        double ang = i * 2.0 * Math.PI / petals;
                        float px = (float)(radio * 0.7071 * Math.Cos(ang));
                        float py = (float)(radio * 0.7071 * Math.Sin(ang));
                        conexions[i].x = px;
                        conexions[i].y = py;
                    }

                    // dibujar radios hacia exteriores
                    for (int i = 1; i <= petals; i++)
                    {
                        g.DrawLine(pen, centro, new PointF((float)flowerPoints[i].x, (float)flowerPoints[i].y));
                    }

                    // dibujar conexiones y pétalos rellenos
                    using (SolidBrush brocha = new SolidBrush(Color.FromArgb(100, 0, 150, 255)))
                    {
                        for (int i = 0; i < petals; i++)
                        {
                            int next = (i + 1) % petals;
                            // líneas entre conexions y puntos exteriores
                            g.DrawLine(pen, new PointF((float)conexions[i].x, (float)conexions[i].y),
                                          new PointF((float)flowerPoints[next + 1].x, (float)flowerPoints[next + 1].y));
                            // pétalo como triángulo (centro, conexion_i, outer_{i+1})
                            PointF[] petalo = new PointF[3];
                            petalo[0] = new PointF(0f, 0f);
                            petalo[1] = new PointF((float)conexions[i].x, (float)conexions[i].y);
                            petalo[2] = new PointF((float)flowerPoints[next + 1].x, (float)flowerPoints[next + 1].y);
                            g.FillPolygon(brocha, petalo);
                        }
                    }
                }

                // calcular perímetro / área aplicando escalaEffective
                try
                {
                    double petalArea = CalculatePetalArea();
                    double areaScaled = petalArea * petals * scaleEffective * scaleEffective;
                    double petalPer = CalculatePetalPerimeter();
                    double perScaled = petalPer * petals * scaleEffective;

                    if (txtArea != null) txtArea.Text = areaScaled.ToString("F2");
                    if (txtPer != null) txtPer.Text = perScaled.ToString("F2");
                }
                catch
                {
                    // no bloquear dibujo
                }

                g.Restore(gs);
            }

            // asignar imagen y liberar anterior
            Image old = pic.Image;
            pic.Image = bmp;
            old?.Dispose();
        }

        // utilidades
        private double Dist(PointF a, PointF b)
        {
            double dx = b.X - a.X;
            double dy = b.Y - a.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
