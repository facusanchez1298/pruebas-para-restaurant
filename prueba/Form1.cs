
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

            this.editor.panel.SendToBack();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < editor.Controls.Count; i++)
            {
                if (editor.Controls[i].GetType().Equals(typeof(PictureBox)))
                {

                    MessageBox.Show(i + "");
                    PictureBox pictureBox = (PictureBox)editor.Controls[i];

                    pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y);

                    pictureBox.MouseDown -= this.editor.itemPanel_MouseDown;
                    pictureBox.MouseUp -= this.editor.item_MouseUp;

                    if(!editor.Controls[i].Tag.Equals("Pared"))
                        pictureBox.DoubleClick += editor.item_DoubleClick;

                    padre.Controls.Add(pictureBox);
                    

                }
            }

            this.Close();
            padre.Show();
            padre.plano1.SendToBack();           
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
                    this.editor.DarEventos(padre.Controls[i] as PictureBox);                    
                    this.editor.Controls.Add(padre.Controls[i]);
                }                
            }
            editor.panel.SendToBack();
        }
    }
}
