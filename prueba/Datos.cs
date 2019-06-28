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
    public partial class Datos : Form
    {
        Item item;
        Ver ver;
        Conexion conexion;

        public Datos(Item item, Ver ver)
        {
            this.ver = ver;
            conexion = new Conexion();
            this.item = item;
            InitializeComponent();
            this.labelNumero.Text = item.index.ToString();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            ver.recargar();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            conexion.ocuparMesa(item,ver.plantilla);
        }
    }
}
