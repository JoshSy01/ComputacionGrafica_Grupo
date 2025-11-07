using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppRectangle
{
    internal class CCopoDeNieve
    {
        Punto[][] snowPoints = new Punto[6][];
        float radio;
        private Graphics mGraphic;
        private Pen mPen;

        public CCopoDeNieve()
        {
            radio = 0.0f;
            snowPoints[0] = new Punto[10];
            snowPoints[1] = new Punto[10];
            snowPoints[2] = new Punto[1];
            snowPoints[3] = new Punto[10];
        }

        public void ReadData(float radio1)
        {
            try
            {
                radio = radio1;
                for (int i = 0; i < snowPoints[0].Length; i++)
                {
                    snowPoints[0][i] = new Punto();
                }
                for (int i = 0; i < snowPoints[1].Length; i++)
                {
                    snowPoints[1][i] = new Punto();
                }
                for (int i = 0; i < snowPoints[2].Length; i++)
                {
                    snowPoints[2][i] = new Punto();
                }
                for (int i = 0; i < snowPoints[3].Length; i++)
                {
                    snowPoints[3][i] = new Punto();
                }

            }
            catch
            {
                MessageBox.Show("Ingreso no válido", "Mensaje de error");
            }
        }

        public void DrawLine(int a1, int a2, int b1, int b2)
        {
            mGraphic.DrawLine(mPen, (float)(snowPoints[a1][a2].x), (float)(snowPoints[a1][a2].y), (float)(snowPoints[b1][b2].x), (float)(snowPoints[b1][b2].y));
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
            mPen = new Pen(Color.Black, 2);

            float tetha = 0.0f; 
            snowPoints[2][0].x = center.x;
            snowPoints[2][0].y = center.y;

            for (int i=0; i<3; i++)
            {
                tetha = (float)((i * 0.628318) + tethaAdd);
                snowPoints[0][i].x = (center.x + radio * Math.Cos(tetha));
                snowPoints[0][i].y = (center.y + radio * Math.Sin(tetha));
                snowPoints[1][i].x = (center.x + (radio * 0.95) * Math.Cos(tetha));
                snowPoints[1][i].y = (center.y + (radio * 0.95) * Math.Sin(tetha));
            }
            for (int i = 0; i < 2; i++)
            {
                DrawLine(0, i, 0, i+1);
                DrawLine(1, i, 1, i + 1);
            }
            for (int i = 0; i < 9; i++)
            {
                tetha = (float)((i * 0.15708) + tethaAdd);
                if (i == 3 || i == 5)
                {
                    snowPoints[3][i].x = (center.x + (radio * 0.77) * Math.Cos(tetha));
                    snowPoints[3][i].y = (center.y + (radio * 0.77) * Math.Sin(tetha));
                }
                else if (i == 4)
                {
                    snowPoints[3][i].x = (center.x + (radio * 0.6) * Math.Cos(tetha));
                    snowPoints[3][i].y = (center.y + (radio * 0.6) * Math.Sin(tetha));
                } 
                else
                {
                    snowPoints[3][i].x = (center.x + (radio * 0.80) * Math.Cos(tetha));
                    snowPoints[3][i].y = (center.y + (radio * 0.80) * Math.Sin(tetha));
                }
            }
            DrawLine(0, 2, 1, 2);
            DrawLine(2, 0, 3, 2);
            DrawLine(2, 0, 3, 6);
            DrawLine(1, 1, 3, 2);
            DrawLine(1, 1, 3, 6);

            DrawLine(1, 0, 3, 3);
            DrawLine(1, 2, 3, 5);

            DrawLine(3, 3, 1, 1);
            DrawLine(3, 5, 1, 1);

            DrawLine(3, 3, 3, 4);
            DrawLine(3, 4, 3, 5);
            DrawLine(3, 4, 3, 2);
            DrawLine(3, 4, 3, 6);

        }

    }

}
