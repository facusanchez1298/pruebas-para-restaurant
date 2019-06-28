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
    public partial class Ver : Form
    {
        public int plantilla = 1;
        Conexion Conexion;
        public Ver()
        {
            Conexion = new Conexion();
            InitializeComponent();
            Conexion.crearBaseDeDatos();

            recargar();
            
            
        }

        public void recargar()
        {

            Controls.Cast<Control>().Where(q => q.GetType().Equals(typeof(Item))).ToList().ForEach(q =>
            {
                this.Controls.Remove(q);
            });
            Conexion.cargarMesas(this, plantilla);
            plano1.SendToBack();
            actualizarTabla();

            
        }

        public void actualizarTabla()
        {
            Conexion.cargarTablaMesas(dataGridView1, plantilla);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelHora.Text = DateTime.Now.ToLongTimeString();
            labelFecha.Text = DateTime.Now.ToShortDateString();
            labelDia.Text = DateTime.Now.ToString("dddd");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(this, plantilla);            
            form1.Show();
            this.Hide();
        }

        public void item_DoubleClick(object sender, EventArgs e)
        {
            
            Datos datos = new Datos(sender as Item, this);
            datos.ShowDialog();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            recargar();
        }


        #region cambio de plantilla
        private void button3_Click(object sender, EventArgs e)
        {
            plantilla = 1;
            recargar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            plantilla = 2;
            recargar();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            plantilla = 3;
            recargar();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            plantilla = 4;
            recargar();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            plantilla = 5;
            recargar();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            plantilla = 6;
            recargar();
        }
        #endregion
    }
}
