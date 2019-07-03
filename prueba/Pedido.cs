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
    public partial class Pedido : Form, Dar
    {
        Ver padre;
        Item item;
        Conexion conexion;

        public Pedido()
        {

            conexion = new Conexion();
            InitializeComponent();
            RecargarTabla();
            
        }

        public void RecargarTabla()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = conexion.CargarTablaComida();

            dataGridView1.Columns[0].Visible = false;
        }


        public void darItem(Item item)
        {
            this.item = item;
        }

        public void darPadre(Form form)
        {
            padre = form as Ver;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            while (this.Size.Width <= 0)
            {
                this.Width -= 1;
            }
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
