using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinAppFigure;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace WinAppRectangle
{
    public partial class Menu : Form
    {
        private float angle = 0f;
        private Color[] palette = new Color[] {
            Color.FromArgb(255, 99, 71),    // tomato
            Color.FromArgb(60, 179, 113),   // mediumseagreen
            Color.FromArgb(65, 105, 225),   // royalblue
            Color.FromArgb(238, 130, 238),  // violet
            Color.FromArgb(255, 215, 0)     // gold
        };

        public Menu()
        {
            InitializeComponent();
            // estilo del formulario
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.MdiChildActivate += Menu_MdiChildActivate;

        }

        public void OpenWindow(Form frm)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
            mainPanel.Visible = false;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;

            // Evento cuando esta ventana se cierre
            frm.FormClosed += (s, args) =>
            {
                if (this.ActiveMdiChild == null)
                {
                    mainPanel.Visible = true;
                    mainPanel.Invalidate();   // para redibujar el fondo
                }
            };

            frm.Show();

            frm.Show();
        }

        private void Menu_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                // No hay ventanas abiertas → mostrar el panel de presentación
                mainPanel.Visible = true;
                mainPanel.Invalidate();
            }
        }



        private void Menu_Load(object sender, EventArgs e)
        {
            // Activar doble buffer en panel1 para evitar parpadeos
            try
            {
                var pd = typeof(Control).GetProperty("DoubleBuffered",
                    BindingFlags.Instance | BindingFlags.NonPublic);
                pd?.SetValue(mainPanel, true, null);
            }
            catch { }

            mainPanel.Invalidate();
        }


        private void rectanguloToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenWindow(new frmRectangle());
        }

        private void cuadradoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenWindow(new frmSquare());
        }

        private void pentagonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWindow(new frmEstrella());
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void florToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWindow(new frmFlower());
        }

        private void pentagonosYPoligonosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWindow(new frmPentagonosYPoligonos());
        }

        private void florHexagonosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWindow(new frmHexagonFlower());
        }

        private void copoDeNieveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWindow(new frmCopoDeNieve());
        }

        private void figura4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWindow(new frmFigura4());
        }

        private void polígono16Y8PuntasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWindow(new FrmPoligono16_8());
        }

        private void florConCírculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWindow(new FrmFlorCirculo());
        }

        private void rectánguloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWindow(new frmRectangle());
        }

        private void cuadradoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenWindow(new frmSquare());
        }

        private void pentágonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWindow(new frmEstrella());
        }

        private void florToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenWindow(new frmFlower());
        }

        private void romboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWindow(new frmRombo());
        }

        // -------------------------
        // Animación y dibujo en el panel
        // -------------------------
        private void animationTimer_Tick(object sender, EventArgs e)
        {
            angle += 2.2f;
            if (angle >= 360f) angle -= 360f;
            this.mainPanel.Invalidate();
        }

        private void mainPanel_Resize(object sender, EventArgs e)
        {
            this.mainPanel.Invalidate();
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var rc = this.mainPanel.ClientRectangle;

            // fondo con gradiente radial simulado: linear + ellipse overlay
            using (var lg = new LinearGradientBrush(rc, Color.FromArgb(25, 25, 28), Color.FromArgb(70, 70, 75), LinearGradientMode.ForwardDiagonal))
            {
                g.FillRectangle(lg, rc);
            }
            // overlay suave central
            using (var br = new SolidBrush(Color.FromArgb(60, 60, 65)))
            {
                int cx = rc.Width / 2;
                int cy = rc.Height / 2;
                int rx = Math.Min(rc.Width, rc.Height) / 3;
                using (var path = new GraphicsPath())
                {
                    path.AddEllipse(cx - rx, cy - rx, rx * 2, rx * 2);
                    var m = new PathGradientBrush(path);
                    m.CenterColor = Color.FromArgb(40, 40, 44);
                    m.SurroundColors = new Color[] { Color.FromArgb(20, 20, 23) };
                    g.FillPath(m, path);
                }
            }

            // centro de dibujo
            PointF center = new PointF(rc.Width / 2f, rc.Height / 2f);
            float minSide = Math.Min(rc.Width, rc.Height);
            float scale = minSide / 300f; // factor de escala

            // figura 1: rectángulo girando en el fondo
            DrawRotatingRectangle(g, center, 160f * scale, 90f * scale, angle, palette[0], 0.18f);

            // figura 2: pentágono multicolor (frente)
            DrawRegularPolygon(g, center, 70f * scale, 5, angle * -1.2f, palette[2], palette[4], 6);

            // figura 3: flor de círculos
            DrawFlower(g, center, 110f * scale, 8, angle * 0.6f);

            // figura 4: estrella (pequeña) encima
            DrawStar(g, new PointF(center.X + 120f * scale, center.Y - 80f * scale), 30f * scale, 14f * scale, 8, angle * -1.7f, palette[3]);

            // texto decorativo
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Far })
            using (var fnt = new Font("Segoe UI", 14f, FontStyle.Bold))
            using (var brush = new SolidBrush(Color.FromArgb(220, 220, 220)))
            {
                g.DrawString("Figuras 2D — Explora y abre ejemplos", fnt, brush, new RectangleF(0, rc.Height - 40, rc.Width, 36), sf);
            }
        }

        private void DrawRotatingRectangle(Graphics g, PointF center, float w, float h, float angleDeg, Color c, float alpha)
        {
            var rect = new RectangleF(center.X - w/2, center.Y - h/2, w, h);
            using (var m = new Matrix())
            {
                m.RotateAt(angleDeg, center);
                g.Transform = m;
                Color fill = Color.FromArgb((int)(alpha * 255), c);
                using (var br = new SolidBrush(fill))
                using (var pen = new Pen(Color.FromArgb(200, Color.Black), 2f))
                {
                    g.FillRoundedRectangle(br, rect, 12f);
                    g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
                }
                g.ResetTransform();
            }
        }

        private void DrawRegularPolygon(Graphics g, PointF center, float radius, int sides, float rotationDeg, Color fill, Color stroke, float strokeWidth)
        {
            if (sides < 3) return;
            var pts = new PointF[sides];
            double ang0 = (Math.PI / 180.0) * rotationDeg;
            for (int i = 0; i < sides; i++)
            {
                double a = ang0 + i * 2.0 * Math.PI / sides;
                pts[i] = new PointF(center.X + (float)(radius * Math.Cos(a)), center.Y + (float)(radius * Math.Sin(a)));
            }
            using (var path = new GraphicsPath())
            {
                path.AddPolygon(pts);
                using (var pb = new PathGradientBrush(path))
                {
                    pb.CenterColor = Color.FromArgb(200, fill);
                    pb.SurroundColors = new Color[] { Color.FromArgb(120, Color.Black) };
                    g.FillPath(pb, path);
                }
                using (var pen = new Pen(Color.FromArgb(220, stroke), strokeWidth))
                {
                    g.DrawPolygon(pen, pts);
                }
            }
        }

        private void DrawFlower(Graphics g, PointF center, float radius, int petals, float rotationDeg)
        {
            float petalW = radius * 0.6f;
            float petalH = radius * 0.9f;
            for (int i = 0; i < petals; i++)
            {
                float a = rotationDeg + i * 360f / petals;
                var pt = PointOnCircle(center, radius * 0.6f, a);
                using (var m = new Matrix())
                {
                    m.Translate(pt.X, pt.Y);
                    m.Rotate(a);
                    g.Transform = m;
                    using (var gPath = new GraphicsPath())
                    {
                        gPath.AddEllipse(-petalW / 2, -petalH / 2, petalW, petalH);
                        using (var br = new SolidBrush(Color.FromArgb(200, palette[i % palette.Length])))
                        {
                            g.FillPath(br, gPath);
                        }
                        using (var pen = new Pen(Color.FromArgb(200, Color.FromArgb(30, 30, 30)), 2f))
                        {
                            g.DrawPath(pen, gPath);
                        }
                    }
                    g.ResetTransform();
                }
            }
            // centro
            using (var br = new SolidBrush(Color.FromArgb(230, Color.FromArgb(255, 234, 153))))
            {
                g.FillEllipse(br, center.X - radius * 0.12f, center.Y - radius * 0.12f, radius * 0.24f, radius * 0.24f);
            }
        }

        private void DrawStar(Graphics g, PointF center, float outerRadius, float innerRadius, int points, float rotationDeg, Color color)
        {
            var pts = new List<PointF>();
            double ang0 = rotationDeg * Math.PI / 180.0;
            for (int i = 0; i < points * 2; i++)
            {
                double r = (i % 2 == 0) ? outerRadius : innerRadius;
                double a = ang0 + i * Math.PI / points;
                pts.Add(new PointF(center.X + (float)(r * Math.Cos(a)), center.Y + (float)(r * Math.Sin(a))));
            }
            using (var path = new GraphicsPath())
            {
                path.AddPolygon(pts.ToArray());
                using (var br = new SolidBrush(Color.FromArgb(230, color)))
                {
                    g.FillPath(br, path);
                }
                using (var pen = new Pen(Color.FromArgb(200, Color.Black), 1.5f))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        private PointF PointOnCircle(PointF center, float radius, float angleDeg)
        {
            double a = (Math.PI / 180.0) * angleDeg;
            return new PointF(center.X + (float)(radius * Math.Cos(a)), center.Y + (float)(radius * Math.Sin(a)));
        }
    }

    // helpers de extensión para dibujo (están fuera de la clase parcial)
    static class GraphicsExtensions
    {
        public static void FillRoundedRectangle(this Graphics g, Brush b, RectangleF rect, float radius)
        {
            using (var path = RoundedRect(rect, radius))
            {
                g.FillPath(b, path);
            }
        }

        private static GraphicsPath RoundedRect(RectangleF baseRect, float radius)
        {
            float diameter = radius * 2;
            var path = new GraphicsPath();
            if (radius <= 0.0F)
            {
                path.AddRectangle(baseRect);
                return path;
            }
            if (diameter > baseRect.Width) diameter = baseRect.Width;
            if (diameter > baseRect.Height) diameter = baseRect.Height;
            var arc = new RectangleF(baseRect.Location, new SizeF(diameter, diameter));
            // top left
            path.AddArc(arc, 180, 90);
            // top right
            arc.X = baseRect.Right - diameter;
            path.AddArc(arc, 270, 90);
            // bottom right
            arc.Y = baseRect.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            // bottom left
            arc.X = baseRect.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
