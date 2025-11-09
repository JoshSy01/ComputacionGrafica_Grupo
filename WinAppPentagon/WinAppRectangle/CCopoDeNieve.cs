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
        Punto[][] snowPoints = new Punto[9][];
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
            snowPoints[4] = new Punto[10];
            snowPoints[5] = new Punto[10];
            snowPoints[6] = new Punto[4];
            snowPoints[7] = new Punto[4];
            snowPoints[8] = new Punto[4];
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
                for (int i = 0; i < snowPoints[4].Length; i++)
                {
                    snowPoints[4][i] = new Punto();
                }
                for (int i = 0; i < snowPoints[5].Length; i++)
                {
                    snowPoints[5][i] = new Punto();
                }
                for (int i = 0; i < snowPoints[6].Length; i++)
                {
                    snowPoints[6][i] = new Punto();
                    snowPoints[7][i] = new Punto();
                    snowPoints[8][i] = new Punto();
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
            mPen = new Pen(Color.Black, 1);

            float tetha = 0.0f;
            snowPoints[2][0].x = center.x;
            snowPoints[2][0].y = center.y;
            for (int j = 0; j<5; j++) { 
                for (int i = 0; i < 3; i++)
                {
                    tetha = (float)((i * 0.628318) + tethaAdd + (1.25664*j) + 0.261799);
                    snowPoints[0][i].x = (center.x + radio * Math.Cos(tetha));
                    snowPoints[0][i].y = (center.y + radio * Math.Sin(tetha));
                    snowPoints[1][i].x = (center.x + (radio * 0.95) * Math.Cos(tetha));
                    snowPoints[1][i].y = (center.y + (radio * 0.95) * Math.Sin(tetha));
                    snowPoints[6][i].x = (center.x + (radio * 0.3) * Math.Cos(tetha));
                    snowPoints[6][i].y = (center.y + (radio * 0.3) * Math.Sin(tetha));

                }
                for (int i = 0; i < 2; i++)
                {
                    DrawLine(0, i, 0, i + 1);
                    DrawLine(1, i, 1, i + 1);
                }
                for (int i = 0; i < 9; i++)
                {
                    tetha = (float)((i * 0.15708) + tethaAdd + (1.25664 * j) + 0.261799);
                    snowPoints[4][i].x = (center.x + (radio * 0.1) * Math.Cos(tetha));
                    snowPoints[4][i].y = (center.y + (radio * 0.1) * Math.Sin(tetha));
                    if (i == 3 || i == 5)
                    {
                        snowPoints[3][i].x = (center.x + (radio * 0.77) * Math.Cos(tetha));
                        snowPoints[3][i].y = (center.y + (radio * 0.77) * Math.Sin(tetha));
                        snowPoints[5][i].x = (center.x + (radio * 0.68) * Math.Cos(tetha));
                        snowPoints[5][i].y = (center.y + (radio * 0.68) * Math.Sin(tetha));

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

                    if (i == 2 || i == 6)
                    {
                        snowPoints[7][i / 2].x = (center.x + (radio * 0.45) * Math.Cos(tetha));
                        snowPoints[7][i / 2].y = (center.y + (radio * 0.45) * Math.Sin(tetha));
                        snowPoints[8][i / 2].x = (center.x + (radio * 0.67) * Math.Cos(tetha));
                        snowPoints[8][i / 2].y = (center.y + (radio * 0.67) * Math.Sin(tetha));
                    }
                }

                //Figura Externa
                DrawLine(0, 2, 1, 2);
                DrawLine(4, 2, 3, 2);
                DrawLine(4, 6, 3, 6);
                DrawLine(1, 1, 3, 2);
                DrawLine(1, 1, 3, 6);
                DrawLine(1, 1, 0, 1);

                //Union
                DrawLine(1, 0, 3, 3);
                DrawLine(1, 2, 3, 5);

                //Parte superior de Rombo
                DrawLine(3, 3, 1, 1);
                DrawLine(3, 5, 1, 1);

                //Parte inferior del Rombo
                DrawLine(3, 3, 3, 4);
                DrawLine(3, 4, 3, 5);
                DrawLine(3, 4, 3, 2);
                DrawLine(3, 4, 3, 6);
                DrawLine(4, 4, 3, 4);
                DrawLine(5, 3, 4, 3);
                DrawLine(5, 5, 4, 5);

                //Curva Interna
                PointF[] curvePoints = new PointF[9];
                for (int i = 0; i < 9; i++)
                {
                    curvePoints[i] = new PointF((float)snowPoints[4][i].x, (float)snowPoints[4][i].y);
                }
                mGraphic.DrawCurve(mPen, curvePoints);

                //Union Laterales
                DrawLine(6, 0, 4, 0);
                DrawLine(6, 2, 4, 8);
                DrawLine(7, 1, 6, 0);
                DrawLine(7, 3, 6, 2);
                DrawLine(8, 1, 1, 0);
                DrawLine(8, 3, 1, 2);
                DrawLine(7, 1, 1, 0);
                DrawLine(7, 3, 1, 2);
            }
        }

    }

}
