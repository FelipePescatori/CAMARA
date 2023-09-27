using Emgu.CV;
using Emgu.Util;
using ZXing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //para camara
        private Mat Frame;
        private VideoCapture Camra;
        //para codigo de barra
        private BarcodeReader Reader;
        private List<Articulos> Articulos { get; set; }


        private void Form1_Load(object sender, EventArgs e)
        {
            Frame = new Mat();
            Camra = new VideoCapture();
            Reader = new BarcodeReader();
            timer1.Interval = 40;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            txtContenido.Text = string.Empty;
            rdApagar.Checked = true;
            CargarArticulos();
        }
        //hacemos esto para simular la base de datos 
        //779 representa argentina despues sigue pronvincia articulo fijarce bien 
        private void CargarArticulos()
        {
            Articulos = new List<Articulos> { };
            {
                new Articulos(7790199603863, "Masitas");
                new Articulos(5901234123457, "Manzana");
            }
        }
        private string DetalleDeProducto(string CodigoDeBarra)
        {
            string Detalle = string.Empty;

            if (!string.IsNullOrEmpty(CodigoDeBarra))
            {
                var Articulo = Articulos.FirstOrDefault(art => art.Articulosid == long.Parse(CodigoDeBarra));
                if (Articulo != null)
                {
                    Detalle = Articulo.Detalle;
                }
            }
            return Detalle;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Camra.IsOpened)
            {
                Camra.Read(Frame);
                pictureBox1.Image = Frame.ToBitmap();
            }
        }

        private void rdApagar_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = false;
            Camra.Stop();
        }
        private void rdEncender_Click(object sender, EventArgs e)
        {
            Camra.Start();
            if (!timer1.Enabled)
            {
                timer1.Enabled = true;
                timer1.Start();
            }
        }

        private void btnAgegar_Click(object sender, EventArgs e)
        {
            Result Resultado;
            if (pictureBox1.Image != null)
            {
                Resultado = Reader.Decode((Bitmap)pictureBox1.Image);
                if (Resultado != null)
                {
                    txtContenido.Text = Resultado.Text;
                }
            }
        }
    }
}
