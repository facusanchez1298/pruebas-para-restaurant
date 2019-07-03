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

        DateTime llego;

        public Datos( )
        {            
            conexion = new Conexion();            
            InitializeComponent();
        }

        public void darPadre(Ver ver)
        {
            this.ver = ver;
        }

        public void darItem(Item item)
        {
            this.item = item;

            if (item.ocupado)
            {
                buttonOcupar.Text = "Desocupar";
            }
            else buttonOcupar.Text = "Ocupar";


            if (item.Llegada != null)
            {
                llego = item.Llegada;
            }
            else timer1.Stop();

        
        }
        
        private void button1_Click(object sender, EventArgs e)
        {        
            salir();
        }
        
        private void botonOcupar(object sender, EventArgs e)
        {
            if (buttonOcupar.Text.Equals("Ocupar"))
            {
                conexion.ocuparMesa(item, ver.plantilla, true);
                buttonOcupar.Text = "Desocupar";

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
            }
        }
               
        private void timer1_Tick(object sender, EventArgs e)
        {
            labelActual.Text = (DateTime.Now - llego).ToString(@"hh\:mm\:ss");
        }

        public void salir()
        {
            ver.recargar();
            this.Close();
        }  

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            salir();
        }     

        private void button4_Click(object sender, EventArgs e)
        {
            ver.AbrirFormEnPanel<Pedido>(item);
        }

        public void darPadre(Form form)
        {
            this.darPadre(form as Ver);
        }
    }
}
