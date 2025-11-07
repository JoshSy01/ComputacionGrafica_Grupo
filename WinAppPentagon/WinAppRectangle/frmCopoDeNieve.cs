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
    public partial class frmCopoDeNieve : Form
    {
        Punto center = new Punto();
        float tethaAdd = 0.0f;
        CCopoDeNieve copoDeNieve = new CCopoDeNieve();
        public frmCopoDeNieve()
        {
            InitializeComponent();
            center.x = picCanvas.Width / 2;
            center.y = picCanvas.Height / 2;
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            picCanvas.Refresh();
            copoDeNieve.ReadData(float.Parse(txtRadio.Text));
            copoDeNieve.PlotShape(picCanvas, center, tethaAdd);
        }
    }
}
