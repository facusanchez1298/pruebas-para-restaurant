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

        /// <summary>
        /// actualiza todos los datos de la ventana
        /// </summary>
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

        /// <summary>
        /// actualiza los datos de la tabla
        /// </summary>
        public void actualizarTabla()
        {
            Conexion.cargarTablaMesas(dataGridView1, plantilla);
        }

        /// <summary>
        /// un temporizador para el relog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            labelHora.Text = DateTime.Now.ToLongTimeString();
            labelFecha.Text = DateTime.Now.ToShortDateString();
            labelDia.Text = DateTime.Now.ToString("dddd");
        }

        /// <summary>
        /// abre la ventana del editor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Editar_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(this, plantilla);
            form1.Show();
            this.Hide();
        }

        /// <summary>
        /// abre la ventana para cargar las ordenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void item_DoubleClick(object sender, EventArgs e)
        {
            Datos datos = new Datos(sender as Item, this);
            datos.ShowDialog();
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

        internal void Mouse_hover(object sender, EventArgs e)
        {            
            (sender as Item).BackColor = (sender as Item).ocupado ? Color.Red : Color.Green;
        }

        internal void Mouse_Leave(object sender, EventArgs e)
        {
            (sender as Item).BackColor = SystemColors.ActiveCaption;
        }

       
    }
}

