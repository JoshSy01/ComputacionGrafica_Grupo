using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace WinAppRectangle
{
    internal class CPentagon
    {
        private float radio;
        private Graphics mGraphic;
        private Pen mPen;
        private const float SF = 20;
        private Punto[] pentagonPoints = new Punto[5];


        public CPentagon()
        {
            radio = 0.0f;
        }
        class Punto
        {
            public double x;
            public double y;
        }

        public void ReadData(float radio1)
        {
            try
            {
                radio = radio1;
                for (int i = 0; i < pentagonPoints.Length; i++)
                {
                    pentagonPoints[i] = new Punto();
                }
            }catch
            {
                MessageBox.Show("Ingreso no válido", "Mensaje de error");
            }

        }

        public void DrawLine(int a, int b)
        {
            mGraphic.DrawLine(mPen, (float)(pentagonPoints[a].x), (float)(pentagonPoints[a].y), (float)(pentagonPoints[b].x), (float)(pentagonPoints[b].y));
        }

        public void initializeData(TextBox txtRadio, PictureBox picCanvas)
        {
            radio = 0.0f;

            txtRadio.Text = "";
            txtRadio.Focus();
            picCanvas.Refresh();
        }

        public void PlotShape(PictureBox picCanvas)
        {
            mGraphic = picCanvas.CreateGraphics();
            mPen = new Pen(Color.Blue, 3);
            Punto center = new Punto();
            center.y = picCanvas.Size.Height/2;
            center.x = picCanvas.Size.Width/2;



            pentagonPoints[1].x = (center.x + radio  * Math.Cos(0.314));
            pentagonPoints[1].y = (center.y - radio  * Math.Sin(0.314));


            pentagonPoints[2].x = (center.x - radio * Math.Cos(0.314));
            pentagonPoints[2].y = (center.y - radio * Math.Sin(0.314));

            
 
            pentagonPoints[3].x = (center.x + radio  * Math.Cos(0.942));
            pentagonPoints[3].y = (center.y + radio  * Math.Sin(0.942));


            pentagonPoints[4].x = (center.x - radio * Math.Cos(0.942));
            pentagonPoints[4].y = (center.y + radio * Math.Sin(0.942));



            pentagonPoints[0].x = center.x;
            pentagonPoints[0].y = (center.y - radio);

            DrawLine(0,3);
            DrawLine(3,2);
            DrawLine(2,1);
            DrawLine(1,4);
            DrawLine(4,0);


        }

    }
}
