using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppRectangle
{
    internal class CPentagonosYPoligonos
    {

        Punto[][] pentaPoints = new Punto[4][];

        private float radio;
        private Graphics mGraphic;
        private Pen mPen;

        public CPentagonosYPoligonos()
        {
            radio = 0.0f;
            pentaPoints[0] = new Punto[5];
            pentaPoints[1] = new Punto[5];
            pentaPoints[2] = new Punto[5];
            pentaPoints[3] = new Punto[10];
        }


        public void ReadData(float radio1)
        {
            try
            {
                radio = radio1;
                for (int i = 0; i < 5; i++)
                {
                    pentaPoints[0][i] = new Punto();
                }
                for (int i = 0; i < 5; i++)
                {
                    pentaPoints[1][i] = new Punto();
                }
                for (int i = 0; i < 5; i++)
                {
                    pentaPoints[2][i] = new Punto();
                }
                for (int i = 0; i < 10; i++)
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
            mPen = new Pen(Color.Black, 1);

            float tetha = 0.0f;


            for (int i = 0; i < 5; i++)
            {
                tetha = (float)((i * 1.25664) + tethaAdd - 0.314159);
                pentaPoints[0][i].x = (center.x + radio * Math.Cos(tetha));
                pentaPoints[0][i].y = (center.y + radio * Math.Sin(tetha));

            }

            DrawLine(0, 0, 0, 2);
            DrawLine(0, 2, 0, 4);
            DrawLine(0, 4, 0, 1);
            DrawLine(0, 1, 0, 3);
            DrawLine(0, 3, 0, 0);



            for (int i = 0; i < 5; i++)
            {
                tetha = (float)((i * 1.25664) + tethaAdd + 0.314159);
                pentaPoints[1][i].x = (center.x + (radio * 1.40) * Math.Cos(tetha));
                pentaPoints[1][i].y = (center.y + (radio * 1.40) * Math.Sin(tetha));
            }

            DrawLine(0, 0, 1, 0);
            DrawLine(0, 1, 1, 0);
            DrawLine(0, 1, 1, 1);
            DrawLine(0, 2, 1, 1);
            DrawLine(0, 2, 1, 2);
            DrawLine(0, 3, 1, 2);
            DrawLine(0, 3, 1, 3);
            DrawLine(0, 4, 1, 3);
            DrawLine(0, 4, 1, 4);
            DrawLine(0, 0, 1, 4);

            for (int i = 0; i < 5; i++)
            {
                tetha = (float)((i * 1.25664) + tethaAdd + 0.314159);
                pentaPoints[2][i].x = (center.x + (radio * 2) * Math.Cos(tetha));
                pentaPoints[2][i].y = (center.y + (radio * 2) * Math.Sin(tetha));
            }

            DrawLine(0, 0, 2, 0);
            DrawLine(0, 1, 2, 0);
            DrawLine(0, 1, 2, 1);
            DrawLine(0, 2, 2, 1);
            DrawLine(0, 2, 2, 2);
            DrawLine(0, 3, 2, 2);
            DrawLine(0, 3, 2, 3);
            DrawLine(0, 4, 2, 3);
            DrawLine(0, 4, 2, 4);
            DrawLine(0, 0, 2, 4);


            for (int i = 0; i < 5; i++)
            {
                tetha = (float)((i * 1.25664) + tethaAdd - 0.314159);
                pentaPoints[0][i].x = (center.x + (radio * 2.5) * Math.Cos(tetha));
                pentaPoints[0][i].y = (center.y + (radio * 2.5) * Math.Sin(tetha));

            }

            DrawLine(0, 0, 0, 1);
            DrawLine(0, 1, 0, 2);
            DrawLine(0, 2, 0, 3);
            DrawLine(0, 3, 0, 4);
            DrawLine(0, 4, 0, 0);

            DrawLine(0, 0, 2, 1);
            DrawLine(0, 0, 2, 3);
            DrawLine(0, 1, 2, 4);
            DrawLine(0, 1, 2, 2);
            DrawLine(0, 2, 2, 0);
            DrawLine(0, 2, 2, 3);
            DrawLine(0, 3, 2, 1);
            DrawLine(0, 3, 2, 4);
            DrawLine(0, 4, 2, 2);
            DrawLine(0, 4, 2, 0);

            int tethaIndex = 0;

            for (int i = 0; i < 10; i += 4)
            {
                tetha = (float)((tethaIndex * 1.25664) + tethaAdd - 0.314159 - 0.174533);
                pentaPoints[3][i].x = (center.x + (radio * 3.25) * Math.Cos(tetha));
                pentaPoints[3][i].y = (center.y + (radio * 3.25) * Math.Sin(tetha));
                tetha = (float)((tethaIndex * 1.25664) + tethaAdd - 0.314159 + 0.174533);
                pentaPoints[3][i + 1].x = (center.x + (radio * 3.25) * Math.Cos(tetha));
                pentaPoints[3][i + 1].y = (center.y + (radio * 3.25) * Math.Sin(tetha));
                tethaIndex++;

                if (i < 8)
                {
                    tetha = (float)((tethaIndex * 1.25664) + tethaAdd - 0.314159 - 0.174533);
                    pentaPoints[3][i + 2].x = (center.x + (radio * 3.25) * Math.Cos(tetha));
                    pentaPoints[3][i + 2].y = (center.y + (radio * 3.25) * Math.Sin(tetha));
                    tetha = (float)((tethaIndex * 1.25664) + tethaAdd - 0.314159 + 0.174533);
                    pentaPoints[3][i + 3].x = (center.x + (radio * 3.25) * Math.Cos(tetha));
                    pentaPoints[3][i + 3].y = (center.y + (radio * 3.25) * Math.Sin(tetha));
                    tethaIndex++;
                }

            }



            DrawLine(3, 0, 3, 2);
            DrawLine(3, 0, 3, 8);
            DrawLine(3, 0, 0, 4);

            DrawLine(3, 1, 3, 3);
            DrawLine(3, 1, 3, 9);
            DrawLine(3, 1, 0, 1);

            DrawLine(3, 2, 3, 4);
            DrawLine(3, 2, 0, 0);

            DrawLine(3, 3, 3, 5);
            DrawLine(3, 3, 0, 2);

            DrawLine(3, 4, 3, 6);
            DrawLine(3, 4, 0, 1);

            DrawLine(3, 5, 3, 7);
            DrawLine(3, 5, 0, 3);

            DrawLine(3, 6, 3, 8);
            DrawLine(3, 6, 0, 2);

            DrawLine(3, 7, 3, 9);
            DrawLine(3, 7, 0, 4);

            DrawLine(3, 8, 0, 3);

            DrawLine(3, 9, 0, 0);
        }
    
    public double CalcularPerimetroPoligonoGrande()
        {
            double R = radio * 3.25;  // radio del círculo donde están los 10 vértices

            double degToRad = Math.PI / 180.0;
            double angCorto = 20.0 * degToRad; // 20°
            double angLargo = 52.0 * degToRad; // 52°

            // Lados como cuerdas
            double ladoCorto = 2.0 * R * Math.Sin(angCorto / 2.0);
            double ladoLargo = 2.0 * R * Math.Sin(angLargo / 2.0);

            // 5 cortos + 5 largos
            double perimetro = 5.0 * ladoCorto + 5.0 * ladoLargo;

            return perimetro;
        }

        public double CalcularAreaPoligonoGrande()
        {
            double R = radio * 3.25;

            double degToRad = Math.PI / 180.0;
            double angCorto = 20.0 * degToRad; // 20°
            double angLargo = 52.0 * degToRad; // 52°

            // Área = suma de áreas de 10 triángulos isósceles
            double area = 0.5 * R * R * (5.0 * Math.Sin(angCorto) + 5.0 * Math.Sin(angLargo));

            return area;
        }

    } 
}
