using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinAppRectangle
{
    public partial class frmEstrella : Form
    {
        private CEstrella ObjEstrella = new CEstrella();
        private Punto center = new Punto();
        private float tetha = 0.0f; // radianes
        private bool dibujado = false;

        public frmEstrella()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += FrmEstrella_KeyDown;
            picCanvas.PreviewKeyDown += PicCanvas_PreviewKeyDown;

            // suscribir control de escala y botones de rotación
            tbEscala.Scroll += TbEscala_Scroll;
            btnRotDer.Click += BtnRotDer_Click;
            btnRotIzq.Click += BtnRotIzq_Click;
            btnGraficar.Click += btnGraficar_Click;
            btnReset.Click += btnReset_Click;
            btnExit.Click += btnExit_Click;

            // centrar por defecto
            center.x = picCanvas.Width / 2f;
            center.y = picCanvas.Height / 2f;
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!float.TryParse(txtRadio.Text, out float r) || r <= 0f)
                {
                    MessageBox.Show("Ingrese un radio válido (>0).");
                    return;
                }

                ObjEstrella.ReadData(r);
                dibujado = true;

                // habilitar transformaciones
                tbEscala.Enabled = true;
                btnRotDer.Enabled = true;
                btnRotIzq.Enabled = true;
                txtRadio.Enabled = false;

                // actualizar centro (por si cambió tamaño)
                center.x = picCanvas.Width / 2f;
                center.y = picCanvas.Height / 2f;

                ObjEstrella.PlotShape(picCanvas, center, tetha, tbEscala.Value, txtAreaPor, txtPerPor);
                picCanvas.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ObjEstrella.initializeData(txtRadio, picCanvas);
            txtRadio.Enabled = true;
            tbEscala.Enabled = false;
            btnRotDer.Enabled = false;
            btnRotIzq.Enabled = false;
            tetha = 0f;
            dibujado = false;
            txtAreaPor.Text = "";
            txtPerPor.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TbEscala_Scroll(object sender, EventArgs e)
        {
            if (!dibujado) return;
            ObjEstrella.PlotShape(picCanvas, center, tetha, tbEscala.Value, txtAreaPor, txtPerPor);
        }

        private void BtnRotDer_Click(object sender, EventArgs e)
        {
            if (!dibujado) return;
            tetha += 5.0f * (float)Math.PI / 180.0f; // +5 grados
            ObjEstrella.PlotShape(picCanvas, center, tetha, tbEscala.Value, txtAreaPor, txtPerPor);
        }

        private void BtnRotIzq_Click(object sender, EventArgs e)
        {
            if (!dibujado) return;
            tetha -= 5.0f * (float)Math.PI / 180.0f; // -5 grados
            ObjEstrella.PlotShape(picCanvas, center, tetha, tbEscala.Value, txtAreaPor, txtPerPor);
        }

        // manejo de teclas en el formulario
        private void FrmEstrella_KeyDown(object sender, KeyEventArgs e)
        {
            HandleMovementKeys(e.KeyCode);
        }

        // permitir captura de flechas en PictureBox
        private void PicCanvas_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            HandleMovementKeys(e.KeyCode);
        }

        private void HandleMovementKeys(Keys k)
        {
            if (!dibujado) return;

            float paso = 10f;
            bool moved = false;
            switch (k)
            {
                case Keys.Left:
                case Keys.A:
                    center.x -= paso; moved = true; break;
                case Keys.Right:
                case Keys.D:
                    center.x += paso; moved = true; break;
                case Keys.Up:
                case Keys.W:
                    center.y -= paso; moved = true; break;
                case Keys.Down:
                case Keys.S:
                    center.y += paso; moved = true; break;
            }
            if (moved)
            {
                ObjEstrella.PlotShape(picCanvas, center, tetha, tbEscala.Value, txtAreaPor, txtPerPor);
            }
        }

        // mantenimiento del evento Load existente (si el diseñador lo llama)
        private void frmPentagon_Load(object sender, EventArgs e)
        {
            ObjEstrella.initializeData(txtRadio, picCanvas);
        }
    }
}
