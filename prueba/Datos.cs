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
    public partial class Datos : Form, Dar
    {
        Item item;
        Ver ver;
        Conexion conexion;
        public int numeroPedido;
        DateTime llego;
        DataGridViewRow seleccionado;

        public Datos()
        {            
            conexion = new Conexion();            
            InitializeComponent();
        }

        public void darPadre(Ver ver)
        {
            this.ver = ver;
        }

        
        

        internal void refrescarTabla()
        {
            dataGridView1.DataSource = conexion.cargarTablaPedido(numeroPedido);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;


            dataGridView1.Columns.Add("Total", "Total");

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                float precio = float.Parse(item.Cells["precio"].Value.ToString());
                int cantidad = int.Parse(item.Cells["cantidad"].Value.ToString());
                item.Cells["total"].Value = precio * cantidad;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelActual.Text = (DateTime.Now - llego).ToString(@"hh\:mm\:ss");
        }       

       


        #region botones

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void Borrar_Click(object sender, EventArgs e)
        {
            
        }

        private void hacerPedido_Click(object sender, EventArgs e)
        {
            ver.AbrirFormEnPanel<Pedido>(item, this);
        }

        private void botonOcupar(object sender, EventArgs e)
        {
            if (buttonOcupar.Text.Equals("Ocupar"))
            {
                conexion.ocuparMesa(item, ver.plantilla, true);
                buttonOcupar.Text = "Desocupar";
                buttonAgregar.Enabled = true;
                labelLLego.Text = DateTime.Now.ToLongTimeString();
                llego = DateTime.Now;
                labelActual.Text = (DateTime.Now - llego).ToString();
                timer1.Start();
                conexion.EditarIngreso(DateTime.Now, item, ver.plantilla);
            }
            else
            {
                conexion.ocuparMesa(item, ver.plantilla, false);
                buttonOcupar.Text = "Ocupar";
                conexion.guardarSalida(item, ver.plantilla);
                timer1.Stop();
                buttonAgregar.Enabled = false;
            }
        }
        #endregion

        #region heredados
        public void darPadre(Form form)
        {
            this.darPadre(form as Ver);
        }

        public void salir()
        {
            ver.recargar();
            this.Close();
        }
        public void darItem(Item item)
        {
            this.item = item;

            if (item.ocupado)
            {
                buttonOcupar.Text = "Desocupar";
                buttonAgregar.Enabled = true;
            }
            else
            {
                buttonOcupar.Text = "Ocupar";
                buttonAgregar.Enabled = false;
            }


            if (item.Llegada != null)
            {
                llego = item.Llegada;
                labelLLego.Text = llego.ToString("HH:mm:ss");

            }
            else timer1.Stop();

            numeroPedido = item.index;

            labelNumero.Text = numeroPedido.ToString();

            refrescarTabla();
        }

        #endregion

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowIndex > -1)
            {
                //Para evitar multiselección

                foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                {
                    dr.Selected = false;
                }

                //Para seleccionar
                dataGridView1.Rows[e.RowIndex].Selected = true;
                seleccionado = dataGridView1.Rows[e.RowIndex];

            }
        }
    }
}
