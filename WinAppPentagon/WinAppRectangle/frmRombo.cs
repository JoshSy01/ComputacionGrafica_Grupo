using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinAppRectangle
{
    public partial class frmRombo : Form
    {
        private CRombo objRombo = new CRombo();

        public frmRombo()
        {
            InitializeComponent();

            // suscribir al evento del trackbar para que redibuje al cambiar escala
            tbEscala.Scroll += TbEscala_Scroll;
            btnReset.Click += BtnReset_Click;
            btnExit.Click += BtnExit_Click;
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!float.TryParse(txtLado.Text, out float lado) || lado <= 0f)
                {
                    MessageBox.Show("Ingrese un valor válido para el lado (mayor que 0).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // leer lado (px). opcional: puedes pasar un ángulo distinto como segundo parámetro
                objRombo.ReadData(lado /*, 60f */);

                // habilitar controles de transformación
                tbEscala.Enabled = true;
                btnRotDer.Enabled = true;
                btnRotIzq.Enabled = true;

                // dibujar (se pasa tbEscala.Value para la escala)
                objRombo.PlotShape(picCanvas, txtPerimeter, txtArea, tbEscala.Value, 0f);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void TbEscala_Scroll(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLado.Text)) return;
            // redibujar con la escala actual
            objRombo.PlotShape(picCanvas, txtPerimeter, txtArea, tbEscala.Value, 0f);
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            objRombo.initializeData(txtLado, picCanvas);
            txtPerimeter.Text = "";
            txtArea.Text = "";
            tbEscala.Enabled = false;
            btnRotDer.Enabled = false;
            btnRotIzq.Enabled = false;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
