
using System.Drawing;
using System.Windows.Forms;

namespace prueba
{
    public partial class Form1 : Form
    {
        Plano Plano;
        Ver padre;

        public Form1( Ver padre)
        {
            this.padre = padre;
            this.Plano = padre.plano1;
            InitializeComponent();
            actualizarControles();
            
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < editor.Controls.Count; i++)
            {
                if (editor.Controls[i].GetType() == typeof(PictureBox))
                {
                    PictureBox pictureBox = (PictureBox)editor.Controls[i];

                    pictureBox.Location = new Point(pictureBox.Location.X - editor.panel.Left, pictureBox.Location.Y - editor.panel.Top);

                    pictureBox.Show();
                    padre.plano1.Controls.Add(pictureBox);                    
                }
            }

            this.Close();
            padre.Show();
            padre.Refresh();
            padre.plano1.Refresh();
        }

        private void editor_Click(object sender, System.EventArgs e)
        {
            editor.Focus();
        }

        public void actualizarControles()
        {
            for (int i = 0; i < padre.Controls.Count; i++)
            {
                if (padre.Controls[i].GetType() == typeof(PictureBox))
                {
                    this.editor.Controls.Add(padre.Controls[i]);
                }
                
            }
        }
    }
}
