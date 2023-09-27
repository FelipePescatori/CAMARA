using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace WindowsFormsApp5
{
    public partial class FormGenerar : Form
    {
        public FormGenerar()
        {
            InitializeComponent();
        }

        public string fath { get; } = @"D:\VIOLETA\WindowsFormsApp5\Guardar QR\";
        private void LimpiarPantalla()
        {
            txtContenido.Text = string.Empty;
            pictureBox1.Image = null;
        }

        private void FormGenerar_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtContenido.Text))
            {
                var barcode = new BarcodeWriter();
                barcode.Format = BarcodeFormat.QR_CODE;    
                barcode.Options.Width = 250;
                barcode.Options.Height = 250;
                pictureBox1.Image = barcode.Write(txtContenido.Text);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Save(fath + $"QR{txtContenido.Text}" + ".png");
                MessageBox.Show("SE GUARDO CORRECTAMENTE");
            }
            else
            {
                MessageBox.Show("CREE UN QR ANTES DE GUARDARLO");
            }
        }
    }
}
