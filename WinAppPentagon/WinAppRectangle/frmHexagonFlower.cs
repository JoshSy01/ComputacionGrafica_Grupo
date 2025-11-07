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
    public partial class frmHexagonFlower : Form
    {
        CHexagonFlower ObjHexaFlow = new CHexagonFlower();
        Punto center = new Punto();
        float tetha = 0.0f;


        
        public frmHexagonFlower()
        {
            InitializeComponent();
            center.y = picCanvas.Size.Height / 2;
            center.x = picCanvas.Size.Width / 2;
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            try
            {
                ObjHexaFlow.ReadData(float.Parse(txtRadio.Text));
                ObjHexaFlow.PlotShape(picCanvas, center, tetha);
                txtRadio.Enabled = false;
                tbEscala.Enabled = true;
                btnRotDer.Enabled = true;
                btnRotIzq.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }
    }
}
