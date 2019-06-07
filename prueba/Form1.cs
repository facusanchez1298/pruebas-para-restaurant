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
    public partial class Form1 : Form
    {
        bool precionado = false;
        Point inicial;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            precionado = true;
            inicial = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            precionado = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            Control control = (Control) sender;
            if (precionado)
            {
                control.Top += e.Y - inicial.Y;
                control.Left += e.X - inicial.X;
            }
        }
    }
}
