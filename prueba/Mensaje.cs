using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prueba
{
    public partial class Mensaje : Form
    {
        private Mensaje(string mensaje)
        {
            InitializeComponent();
            label1.Text = mensaje;
        }

        public static void mensajeError(string mensaje)
        {
            Mensaje msm = new Mensaje(mensaje);
            msm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
