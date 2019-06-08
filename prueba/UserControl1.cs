using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prueba
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        bool precionado = false;
        Point inicial;
        Point final;
        PictureBox seleccionado;
               

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            precionado = true;
            inicial = e.Location;
            seleccionado = (PictureBox)sender;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            precionado = false;
            final = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            Control control = (Control)sender;
            if (precionado)
            {
                control.Top += e.Y - inicial.Y;
                control.Left += e.X - inicial.X;
            }

            if (pictureBox1.Location != inicial)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Location = inicial;

                pictureBox.Image = pictureBox1.Image;
                pictureBox.Show();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Control control = (Control)sender;

            int ancho = seleccionado.Width;
            int alto = seleccionado.Height;

            if (precionado)
            {
                if (e.KeyCode == Keys.R)
                {
                    Image image = seleccionado.Image;

                    image.RotateFlip(RotateFlipType.Rotate90FlipY);

                    cambiarAltoPorAncho(alto, ancho);

                    seleccionado.Image = image; 


                }
            }
        }

    
        public void cambiarAltoPorAncho(int alto, int ancho)
        {
            if((seleccionado.Height == alto) && (seleccionado.Width == ancho))
            {
                seleccionado.Height = ancho;
                seleccionado.Width = alto;
            }
            else
            {
                seleccionado.Height = alto;
                seleccionado.Width = ancho;
            }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
