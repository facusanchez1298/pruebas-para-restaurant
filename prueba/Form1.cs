
using System.Drawing;
using System.Windows.Forms;

namespace prueba
{
    public partial class Form1 : Form
    {       
        Ver padre;
        Conexion conexion;
        

        public Form1( Ver padre, int numero)
        {
            conexion = new Conexion();
            this.padre = padre;
            InitializeComponent();
            editor.plantilla = numero;
            editor.recargar();
            editor.AutoSize = false;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            this.Close();
            padre.Show();
            padre.recargar();
        }

        private void editor_Click(object sender, System.EventArgs e)
        {
            editor.Focus();
        }


    }
}
