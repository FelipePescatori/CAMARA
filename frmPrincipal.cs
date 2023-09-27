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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void leerQRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Ventana = new Form1();
            Ventana.ShowDialog();
        }

        private void generarQRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var VentanaGenerar = new FormGenerar();
            VentanaGenerar.ShowDialog();
        }
    }
}
