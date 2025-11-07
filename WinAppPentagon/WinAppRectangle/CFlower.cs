using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinAppRectangle
{
    
    internal class CFlower
    {
        private float radio;
        private Graphics mGraphic;
        private Pen mPen;
        private Punto[] flowerPoints = new Punto[9];
        private Punto[] conexions = new Punto[8];


        public CFlower()
        {
            radio = 0.0f;
        }
        

        public void ReadData(float radio1)
        {
            try
            {
                radio = radio1;
                for (int i = 0; i < flowerPoints.Length; i++)
                {
                    flowerPoints[i] = new Punto();
                }
                for (int i = 0; i < conexions.Length; i++)
                {
                    conexions[i] = new Punto();
                }
            }
            catch
            {
                MessageBox.Show("Ingreso no válido", "Mensaje de error");
            }

        }

        public void DrawLine(int a, int b)
        {
            mGraphic.DrawLine(mPen, (float)(flowerPoints[a].x), (float)(flowerPoints[a].y), (float)(flowerPoints[b].x), (float)(flowerPoints[b].y));
        }

        public void DrawLineT(int a, int b)
        {
            mGraphic.DrawLine(mPen, (float)(flowerPoints[a].x), (float)(flowerPoints[a].y), (float)(conexions[b].x), (float)(conexions[b].y));
        }

       

        

        public void initializeData(TextBox txtRadio, PictureBox picCanvas)
        {
            radio = 0.0f;

            txtRadio.Text = "";
            txtRadio.Focus();
            picCanvas.Refresh();
        }

        public void PlotShape(PictureBox picCanvas, Punto center, float tethaAdd)
        {
            mGraphic = picCanvas.CreateGraphics();
            mPen = new Pen(Color.Black, 3);

            float tetha = 0.0f;

            flowerPoints[0].x = center.x;
            flowerPoints[0].y = center.y;

            for (int i = 0; i<8; i++)
            {
                tetha = (float)((i * 0.25 * Math.PI) + tethaAdd);
                flowerPoints[i+1].x = (center.x + radio * Math.Cos(tetha));
                flowerPoints[i+1].y = (center.y + radio * Math.Sin(tetha));
                
            }

            for (int i = 1; i <= 8; i++)
            {
                DrawLine(0, i);
            }

            for(int i = 0; i < 8; i++)
            {
                tetha = (float)((i * 0.25 * Math.PI) + tethaAdd);
                conexions[i].x = (center.x + (radio * 0.7071) * Math.Cos(tetha));
                conexions[i].y = (center.y + (radio * 0.7071) * Math.Sin(tetha));
            }

            for (int i = 0; i < 8; i++)
            {
                if(i == 7)
                    DrawLineT(1, 7);
                else
                    DrawLineT(i+2, i);
            }

            for (int i = 0; i < 8; i++)
            {
                PointF[] petalo = new PointF[3];
                petalo[0] = new PointF((float)flowerPoints[0].x, (float)flowerPoints[0].y);
                petalo[1] = new PointF((float)conexions[i].x, (float)conexions[i].y);
                if (i == 7)
                    petalo[2] = new PointF((float)flowerPoints[1].x, (float)flowerPoints[1].y);  
                else
                    petalo[2] = new PointF((float)flowerPoints[i + 2].x, (float)flowerPoints[i + 2].y);

                using (SolidBrush brocha = new SolidBrush(Color.FromArgb(100, 0, 150, 255))) 
                {
                    mGraphic.FillPolygon(brocha, petalo);
                }
            }




        }
    }
}
