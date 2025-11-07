using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppRectangle
{
    internal class CSquare
    {
        private float mSide;
        private float mPerimeter;
        private float mArea;
        private Graphics mGraphic;
        private const float SF = 20;
        private Pen mPen;

        public CSquare()
        {
            mSide = 0.0f;
            mPerimeter = 0.0f;
            mArea = 0.0f;
        }

        public void ReadData(float side)
        {
            try
            {
                mSide = side;
            }
            catch
            {
                MessageBox.Show("Ingreso no válido", "Mensaje de error");
            }

        }

        public void PerimeterSquare()
        {
            mPerimeter = 4 * mSide;
        }

        public void AreaSquare()
        {
            mArea = mSide * mSide;
        }

        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = mPerimeter.ToString();
            txtArea.Text = mArea.ToString();
        }

        public void initializeData(TextBox txtSide, TextBox txtPerimeter, TextBox txtArea, PictureBox picCanvas)
        {
            mSide = 0.0f;
            mPerimeter = 0.0f;
            mArea = 0.0f;

            txtSide.Text = "";
            txtPerimeter.Text = "";
            txtArea.Text = "";
            txtSide.Focus();
            picCanvas.Refresh();
        }

        public void PlotShape(PictureBox picCanvas)
        {
            mGraphic = picCanvas.CreateGraphics();
            mPen = new Pen(Color.Blue, 3);
            mGraphic.DrawRectangle(mPen, 0, 0, mSide * SF, mSide * SF);
        }

        public void CloseForm(Form frm)
        {
            frm.Close();
        }


        }
    }
