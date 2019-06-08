
using System.Drawing;
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

            if(pictureBox1.Location != inicial)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Location = inicial;
                
                pictureBox.Image = pictureBox1.Image;
                pictureBox.Show();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (precionado)
            {

                if (e.KeyCode == Keys.R)
                {
                    Image image = pictureBox1.Image;

                    image.RotateFlip(RotateFlipType.Rotate90FlipY);                   

                    pictureBox1.Image = image;
                }
            }
        }

      
    }
}
