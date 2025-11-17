using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppRectangle
{
    internal class CHexagonFlower
    {
        Punto[][] pentaPoints = new Punto[4][];

        private float radio;
        private Graphics mGraphic;
        private Pen mPen;

        public CHexagonFlower()
        {
            radio = 0.0f;
            pentaPoints[0] = new Punto[6];
            pentaPoints[1] = new Punto[6];
            pentaPoints[2] = new Punto[1];
            pentaPoints[3] = new Punto[6];
        }

        public void ReadData(float radio1)
        {
            try
            {
                radio = radio1;
                for (int i = 0; i < 6; i++)
                {
                    pentaPoints[0][i] = new Punto();
                }
                for (int i = 0; i < 6; i++)
                {
                    pentaPoints[1][i] = new Punto();
                }
                for (int i = 0; i < 1; i++)
                {
                    pentaPoints[2][i] = new Punto();
                }
                for (int i = 0; i < 6; i++)
                {
                    pentaPoints[3][i] = new Punto();
                }
            }
            catch
            {
                MessageBox.Show("Ingreso no válido", "Mensaje de error");
            }
        }
        public void DrawLine(int a1, int a2, int b1, int b2)
        {
            mGraphic.DrawLine(mPen, (float)(pentaPoints[a1][a2].x), (float)(pentaPoints[a1][a2].y), (float)(pentaPoints[b1][b2].x), (float)(pentaPoints[b1][b2].y));
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
            mPen = new Pen(Color.White, 1);

            float tetha = 0.0f;
            pentaPoints[2][0].x = center.x;
            pentaPoints[2][0].y = center.y;


            for (int i = 0; i < 6; i++)
            {
                tetha = (float)((i * 1.0472) + tethaAdd - 0.523599);
                pentaPoints[0][i].x = (center.x + radio * Math.Cos(tetha));
                pentaPoints[0][i].y = (center.y + radio * Math.Sin(tetha));

            }

            for (int i = 0; i < 6; i++)
            {
                DrawLine(2, 0, 0, i);
            }

            for (int j = 0; j < 6; j++)
            {
                for (int k = 0; k < 5; k++)
                {
                    mPen = new Pen(Color.White, (float)(k * 1.3));
                    for (int i = 0; i < 6; i++)
                    {
                        tetha = (float)((i * 1.0472) + tethaAdd - 1.5708 + (1.0472 * j));
                        pentaPoints[1][i].x = (pentaPoints[0][j].x + (radio * 0.2 * (k + 1)) * Math.Cos(tetha));
                        pentaPoints[1][i].y = (pentaPoints[0][j].y + (radio * 0.2 * (k + 1)) * Math.Sin(tetha));
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        DrawLine(1, i, 1, i + 1);
                    }
                }
            }
        }


        public double CalcularPerimetroHexagono()
        {
            return 6.0 * radio;
        }

        public double CalcularAreaHexagono()
        {
            return (3.0 * Math.Sqrt(3) / 2.0) * radio * radio;
        }


    }
}

