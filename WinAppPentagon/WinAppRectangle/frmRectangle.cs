using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppRectangle
{
    public partial class frmRectangle : Form
    {
        private CRectangle ObjRectangle = new CRectangle();
        public frmRectangle()
        {
            InitializeComponent();
        }

        private void frmRectangle_Load(object sender, EventArgs e)
        {
            ObjRectangle.InitializeData(txtWidth, txtHeight, txtPerimeter, txtArea, picCanvas);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            ObjRectangle.ReadData(txtWidth, txtHeight);
            ObjRectangle.PerimeterRectangle();
            ObjRectangle.AreaRectangle();
            ObjRectangle.PrintData(txtPerimeter, txtArea);
            ObjRectangle.PlotShape(picCanvas);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ObjRectangle.InitializeData(txtWidth, txtHeight,txtPerimeter, txtArea, picCanvas);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ObjRectangle.CloseForm(this);
        }
    }
}
