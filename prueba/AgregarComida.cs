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
    public partial class AgregarComida : Form
    {

        Conexion Conexion;
        EditarMenu Pedido;

        public AgregarComida(EditarMenu pedido)
        {
            this.Pedido = pedido;
            Conexion = new Conexion();
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Pedido.RecargarTabla();
        }

        private void buttonOcupar_Click(object sender, EventArgs e)
        {
            if (!hayCamposVacios())
            {
                if (esFloat(textBoxPrecio.Text))
                {
                    string nombre = textBoxNombre.Text;
                    bool vegetariano = checkBoxVegetariano.Checked;
                    bool sinTACC = checkBoxSinTACC.Checked;
                    float precio = float.Parse(textBoxPrecio.Text);

                    Conexion.AgregarComida(nombre, vegetariano, sinTACC, precio);
                    Mensaje.mensajeError("se agrego con exito");
                    vaciarCampos();
                }
                else Mensaje.mensajeError("El precio ingresado debe ser flotante");
            }
            else Mensaje.mensajeError("hay campos vacios");
        }

        public bool hayCamposVacios()
        {
            if ((textBoxNombre.Text != "") && (textBoxPrecio.Text != ""))
            {
                return false;
            }
            else return true;
        }

        public bool esFloat(string numero)
        {
            float x;

            if(float.TryParse(numero, out x))
            {
                return true;
            }
            else return false;
        }

        public void vaciarCampos()
        {
            textBoxNombre.Text = "";
            textBoxPrecio.Text = "";
            checkBoxSinTACC.Checked = false;
            checkBoxVegetariano.Checked = false;
        }
    }
}
