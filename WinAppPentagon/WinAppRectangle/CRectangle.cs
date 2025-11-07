using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppRectangle
{
    internal class CRectangle
    {
        //Datos miembros (Atributos)
        private float mWidth;
        private float mHeight;
        private float mPerimeter;
        private float mArea;
        private Graphics mGraphic;
        private const float SF = 20;
        private Pen mPen;

        //Constructor
        public CRectangle()
        {
            mWidth = 0.0f;
            mHeight = 0.0f;
            mPerimeter = 0.0f;
            mArea = 0.0f;
        }

        // Metodos
        public void ReadData(TextBox txtWidth, TextBox txtHeight)
        {
            try
            {
                mWidth = float.Parse(txtWidth.Text);
                mHeight = float.Parse(txtHeight.Text);
            }
            catch
            {
                MessageBox.Show("Ingreso no válido", "Mensaje de error");
            }
            
        }

        public void PerimeterRectangle()
        {
            mPerimeter = (2 * mWidth + 2 * mHeight);
        }

        public void AreaRectangle() 
        {
            mArea = (mWidth * mHeight);        
        }

        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = mPerimeter.ToString();
            txtArea.Text = mArea.ToString();
        }

        public void InitializeData(TextBox txtWidth, TextBox txtHeight, TextBox txtPerimeter, TextBox txtArea, PictureBox picCanvas)
        {
            mWidth = 0.0f;
            mHeight = 0.0f;
            mPerimeter = 0.0f;
            mArea = 0.0f;

            txtWidth.Text = "";
            txtHeight.Text = "";
            txtPerimeter.Text = "";
            txtArea.Text = "";

            txtWidth.Focus();
            picCanvas.Refresh();

        }

        public void PlotShape(PictureBox picCanvas)
        {
            mGraphic = picCanvas.CreateGraphics();
            mPen = new Pen(Color.Blue, 3);
            mGraphic.DrawRectangle(mPen, 0, 0, mWidth * SF, mHeight * SF);
        }

        public void CloseForm(Form ObjForm)
        {
            ObjForm.Close();
        }
    }
}
