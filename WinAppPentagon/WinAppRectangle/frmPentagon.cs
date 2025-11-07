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
    public partial class frmPentagon : Form
    {
        CPentagon ObjPentagon = new CPentagon();

        public frmPentagon()
        {
            InitializeComponent();
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            try
            {
                ObjPentagon.ReadData(float.Parse(txtRadio.Text) * 5);
                ObjPentagon.PlotShape(picCanvas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }

        private void frmPentagon_Load(object sender, EventArgs e)
        {
            ObjPentagon.initializeData(txtRadio, picCanvas);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ObjPentagon.initializeData(txtRadio, picCanvas);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
