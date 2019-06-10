using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prueba
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        bool precionado = false;
        Point inicial;
        Point final;
        PictureBox seleccionado;
        
               

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;

            precionado = true;
            inicial = control.Location;
            seleccionado = (PictureBox)sender;
            
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;

            precionado = false;
            final = control.Location;

            if (sePuedeColocar()) seleccionado.Location = inicial;
        }

        public bool sePuedeColocar()
        {
            return (!estaEnArea(userControl21, seleccionado)) || existeElemento();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            
            Control control = (Control)sender;
            if (precionado)
            { 
                control.Top  +=  e.Y - (control.Width / 2);
                control.Left +=  e.X - (control.Height / 2);

                if (!estaEnArea(userControl21, control))
                {
                        label.Text = "no se puede fuera del area";
                }
                else
                {
                    if (existeElemento())
                    {
                       
                        labelBool.Text = "no se puede superposicion";
                    }
                    else
                    {
                        label.Text = "si se puede dentro del area";
                        labelBool.Text = "si se puede espacio libre";
                    }
                }
            }

           
        }

        /// <summary>
        /// hace que la imagen rote con la tecla 'R'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Control control = (Control)sender;

            int ancho = seleccionado.Width;
            int alto = seleccionado.Height;

            if (precionado)
            {
                if (e.KeyCode == Keys.R)
                {
                    Image image = seleccionado.Image;

                    image.RotateFlip(RotateFlipType.Rotate90FlipY);

                    cambiarAltoPorAncho(alto, ancho);

                    seleccionado.Image = image; 


                }
            }
        }

        /// <summary>
        /// invierte las proporciones del elemento seleccionado
        /// </summary>
        /// <param name="alto"></param>
        /// <param name="ancho"></param>
        public void cambiarAltoPorAncho(int alto, int ancho)
        {
            if((seleccionado.Height == alto) && (seleccionado.Width == ancho))
            {
                seleccionado.Height = ancho;
                seleccionado.Width = alto;
            }
            else
            {
                seleccionado.Height = alto;
                seleccionado.Width = ancho;
            }
        }

        /// <summary>
        /// verifica si un control esta sobre otro o no
        /// </summary>
        /// <param name="control"></param>
        /// <param name="imagen"></param>
        /// <returns>retorna true si estan superpuestas y false en caso contrario</returns>
        public bool estaEnArea(Control control, Control imagen)
        {
            if((control == null) || (imagen == null)) return false;
            //marco
            int CampoYMinima = control.Location.Y;
            int CampoXMinima = control.Location.X;
            int CampoYMaxima = control.Location.Y + control.Height;
            int CampoXMaxima = control.Location.X + control.Width;

            int imagenXMinima = imagen.Location.X;
            int imagenYMinima = imagen.Location.Y;
            int imagenXMaxima = imagen.Location.X + imagen.Width;
            int imagenYMaxima = imagen.Location.Y + imagen.Height;

            //esta adentro si el minimo es mayor o igual y si el maximo es menor o igual
            if ((CampoXMinima <= imagenXMinima) && (CampoYMinima <= imagenYMinima) && (CampoXMaxima >= imagenXMaxima) && (CampoYMaxima >= imagenYMaxima)) return true;
            else return false;
        }


        /// <summary>
        /// verifica que no se pisen entre elementos
        /// </summary>
        /// <returns></returns>
        public bool existeElemento()
        {
            List<Control> controles = 
                this.Controls.OfType<Control>().ToList<Control>().FindAll(q => q.GetType().Equals(typeof(PictureBox)));
            controles.Remove(seleccionado);

            foreach (Control control in controles)
            {
                if (estaEnRango(control))
                {                    
                     return true;                   
                }
            }
            return false;
        }

        /// <summary>
        /// verifica que no vayas a colocar una pieza sobre otra
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
       private bool estaEnRango(Control control)
        {
            if (seleccionado == null) return false;


            int CampoYMinima = control.Location.Y;
            int CampoXMinima = control.Location.X;
            int CampoYMaxima = control.Location.Y + control.Height;
            int CampoXMaxima = control.Location.X + control.Width;

            int imagenXMinima = seleccionado.Location.X;
            int imagenYMinima = seleccionado.Location.Y;
            int imagenXMaxima = seleccionado.Location.X + seleccionado.Width;
            int imagenYMaxima = seleccionado.Location.Y + seleccionado.Height;            

            if ((CampoXMinima <= imagenXMinima) && (CampoXMaxima >= imagenXMaxima) && (CampoYMinima <= imagenYMinima) && (CampoYMaxima >= imagenYMaxima)) return true;
           
            else if ((CampoYMinima <= imagenYMinima) && (CampoYMaxima >= imagenYMinima) && (CampoXMinima <= imagenXMinima) && (CampoXMaxima >= imagenXMinima)) return true;
            else if ((CampoXMinima <= imagenXMaxima) && (CampoXMaxima >= imagenXMaxima) && (CampoYMinima <= imagenYMaxima) && (CampoYMaxima >= imagenYMaxima)) return true;            
            else if ((CampoXMinima <= imagenXMinima) && (CampoXMaxima >= imagenXMinima) && (CampoYMinima <= imagenYMaxima) && (CampoYMaxima >= imagenYMaxima)) return true;
            else if ((CampoXMinima <= imagenXMaxima) && (CampoXMaxima >= imagenXMaxima) && (CampoYMinima <= imagenYMinima) && (CampoYMaxima >= imagenYMinima)) return true;
            else return false;
        }

       
    }
}
