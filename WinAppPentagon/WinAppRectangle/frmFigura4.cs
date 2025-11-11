using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinAppFigure
{
    public partial class frmFigura4 : Form
    {
        private CFigura4 ObjFigura = new CFigura4();
        private Punto center = new Punto();
        private float tetha = 0.0f; // en radianes

        public frmFigura4()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Figura Estrella - frmFigura4";

            // inicializar centro según tamaño del picturebox
            if (picCanvas != null)
            {
                center.x = picCanvas.Width / 2f;
                center.y = picCanvas.Height / 2f;
            }
        }

        private void BtnGraficar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!float.TryParse(txtRadio.Text, out float r) || r <= 0f)
                {
                    MessageBox.Show("Ingrese un radio válido (>0).");
                    return;
                }
                
                // aquí asumimos que el radio que introduces es en píxeles.
                ObjFigura.ReadData(r);
                tbEscala.Enabled = true;
                btnRotDer.Enabled = true;
                btnRotIzq.Enabled = true;
                txtRadio.Enabled = false;

                // actualizar centro por si el picturebox cambió
                center.x = picCanvas.Width / 2f;
                center.y = picCanvas.Height / 2f;

                ObjFigura.PlotShape(picCanvas, center, tetha, tbEscala.Value);
                picCanvas.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ObjFigura.initializeData(txtRadio, picCanvas);
            txtRadio.Enabled = true;
            tbEscala.Enabled = false;
            btnRotDer.Enabled = false;
            btnRotIzq.Enabled = false;
            tetha = 0f;
            // limpiar imagen
            if (picCanvas.Image != null) { picCanvas.Image.Dispose(); picCanvas.Image = null; }
        }

        private void FrmFigura4_KeyDown(object sender, KeyEventArgs e)
        {
            HandleMovementKeys(e.KeyCode);
        }

        private void PicCanvas_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            HandleMovementKeys(e.KeyCode);
        }

        private void TbEscala_Scroll(object sender, EventArgs e)
        {
            if (!txtRadio.Enabled)
            {
                ObjFigura.PlotShape(picCanvas, center, tetha, tbEscala.Value);
                picCanvas.Focus();
            }
        }

        private void TbEscala_KeyDown(object sender, KeyEventArgs e)
        {
            HandleMovementKeys(e.KeyCode);
        }

        private void HandleMovementKeys(Keys k)
        {
            switch (k)
            {
                case Keys.W:
                case Keys.Up:
                    center.y -= 5;
                    break;
                case Keys.S:
                case Keys.Down:
                    center.y += 5;
                    break;
                case Keys.A:
                case Keys.Left:
                    center.x -= 5;
                    break;
                case Keys.D:
                case Keys.Right:
                    center.x += 5;
                    break;
            }
            if (!txtRadio.Enabled)
            {
                ObjFigura.PlotShape(picCanvas, center, tetha, tbEscala.Value);
            }
        }

        private void BtnRotDer_Click(object sender, EventArgs e)
        {
            tetha += 5.0f * (float)Math.PI / 180.0f; // +5 grados
            ObjFigura.PlotShape(picCanvas, center, tetha, tbEscala.Value);
        }

        private void BtnRotIzq_Click(object sender, EventArgs e)
        {
            tetha -= 5.0f * (float)Math.PI / 180.0f; // -5 grados
            ObjFigura.PlotShape(picCanvas, center, tetha, tbEscala.Value);
        }

    }
}
