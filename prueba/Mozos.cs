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
    public partial class Mozos : Form
    {
        Conexion Conexion;

        public Mozos()
        {
            InitializeComponent();
            Conexion = new Conexion();

            recargarTabla();
        }

        public void recargarTabla()
        {
            string filtro = textBoxNombre.Text;
            bool estaALaMañana = checkBoxMañana.Checked;
            bool estaALaTarde = checkBoxTarde.Checked;
            bool estaALaNoche = checkBoxNoche.Checked;

            dataGridView1.DataSource = Conexion.cargarTablaMozos(filtro, estaALaMañana, estaALaTarde, estaALaNoche);
            dataGridView1.Columns["id"].Visible = false;
        }
        
        private bool TieneTurno()
        {
            bool estaALaMañana = checkBoxMañana.Checked;
            bool estaALaTarde = checkBoxTarde.Checked;
            bool estaALaNoche = checkBoxNoche.Checked;

            if (!estaALaMañana && !estaALaTarde && !estaALaNoche) return false;
            else return true;
        }

        public void vaciarCampos()
        {
            textBoxNombre.Text = "";
            checkBoxMañana.Checked = false;
            checkBoxTarde.Checked = false;
            checkBoxNoche.Checked = false;
        }

        #region botones
        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNombre.Text;
            bool estaALaMañana = checkBoxMañana.Checked;
            bool estaALaTarde = checkBoxTarde.Checked;
            bool estaALaNoche = checkBoxNoche.Checked;

            if (nombre.Any())
            {
                if (TieneTurno())
                {
                    Conexion.agregarMozo(nombre, estaALaMañana, estaALaTarde, estaALaNoche);
                    vaciarCampos(); 
                    recargarTabla();
                }
                else Mensaje.mensajeError("El mozo no tiene un turno asignado");
            }
            else Mensaje.mensajeError("El mozo no tiene nombre");
        }
        #endregion

        private void buttonFiltrar_Click(object sender, EventArgs e)
        {
            recargarTabla();
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
            recargarTabla();
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            recargarTabla();
        }
    }
}
