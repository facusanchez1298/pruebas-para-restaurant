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
    public partial class Base : UserControl
    {
        public Base()
        {
            InitializeComponent();
            
        }

        bool precionado = false;
        Point inicial;
        Point final;
        PictureBox seleccionado;
        Image ImageInicial = Properties.Resources._5f6acd2ede815a125e954977821f8ed3;

        private void item_borrar(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {

                borrarControl((sender as Control));
                
            }
        }
        
        private void itemPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;
            precionado = true;
            inicial = control.Location;
            seleccionado = (PictureBox)control;
        }

        private void item_MouseDown(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;
            precionado = true;
            inicial = control.Location;

            seleccionado = new PictureBox();
            DarEventos(seleccionado);    
            seleccionado.Image = (sender as PictureBox).Image;
            seleccionado.Location = control.Location;
            seleccionado.SizeMode = PictureBoxSizeMode.AutoSize;            
            seleccionado.Show();           

           
            insertarElemento(seleccionado);
            seleccionado.BringToFront();
        }

        private void item_MouseMove(object sender, MouseEventArgs e)
        {
            
            Control control = (Control)sender;
            if (precionado)
            {
                labelBool.Text = "ubicacion imagen = " + seleccionado.Location.ToString();
                seleccionado.Top = e.Y + control.Location.Y  - (control.Width / 2);
                seleccionado.Left = e.X + control.Location.X - (control.Height / 2);
            }           
        }

        private void item_MouseUp(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;

            precionado = false;
            final = control.Location;

            if (!sePuedeColocar())
            {
                seleccionado.Location = inicial;
                if(!estaEnArea(panel, seleccionado))
                {
                    borrarControl(seleccionado);
                }
            }
            else
            {
                Control nuevo = new Control();
                nuevo.Location = inicial;

                //if (!estaEnArea(panel, nuevo))
                //{
                //    PictureBox pictureBox = new PictureBox();
                //    pictureBox.Image = Properties.Resources._5f6acd2ede815a125e954977821f8ed3;
                //    pictureBox.Location = inicial;
                //    pictureBox.Size = new Size(71, 50);
                //    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                //    pictureBox.TabIndex = 0;
                //    pictureBox.TabStop = false;

                //    DarEventos(seleccionado);
                //    insertarElemento(pictureBox);
                //}

            }
        }

        public bool sePuedeColocar()
        {
            return !((!estaEnArea(panel, seleccionado)) || existeElemento());
        }       

        private void insertarElemento(PictureBox pictureBox)
        {
            Plano userControl2 = panel;

            //this.Controls.Remove(userControl21);
            this.Controls.Add(pictureBox);
            this.Controls.Add(userControl2);
        }

        public void borrarControl(Control control)
        {
            this.Controls.Remove(control);
            control.Hide();
        }

        private void DarEventos(PictureBox pictureBox)
        {
            pictureBox.MouseDown += itemPanel_MouseDown;
            pictureBox.MouseUp += item_MouseUp;
            pictureBox.MouseMove += item_MouseMove;
            pictureBox.DoubleClick += item_DoubleClick;
        }

        private void item_DoubleClick(object sender, EventArgs e)
        {
            Datos datos = new Datos();
            datos.ShowDialog();
        }





        /// <summary>
        /// hace que la imagen rote con la tecla 'R'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rotar(object sender, KeyEventArgs e)
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
                else if(e.KeyCode == Keys.D)
                {
                    if(seleccionado != null)
                    borrarControl(seleccionado);
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
            int CampoXMedia = CampoXMaxima - control.Location.X / 2;
            int CampoYMedia = CampoYMaxima - control.Location.Y / 2;

            int imagenXMinima = seleccionado.Location.X;
            int imagenYMinima = seleccionado.Location.Y;
            int imagenXMaxima = seleccionado.Location.X + seleccionado.Width;
            int imagenYMaxima = seleccionado.Location.Y + seleccionado.Height;
            int imagenXMedia = imagenXMaxima - seleccionado.Width / 2;
            int imagenYMedia = imagenYMaxima - seleccionado.Height / 2;

            if ((CampoXMinima <= imagenXMinima) && (CampoXMaxima >= imagenXMaxima) && (CampoYMinima <= imagenYMinima) && (CampoYMaxima >= imagenYMaxima)) return true;

            else if ((CampoYMinima <= imagenYMinima) && (CampoYMaxima >= imagenYMinima) && (CampoXMinima <= imagenXMinima) && (CampoXMaxima >= imagenXMinima)) return true;
            else if ((CampoXMinima <= imagenXMaxima) && (CampoXMaxima >= imagenXMaxima) && (CampoYMinima <= imagenYMaxima) && (CampoYMaxima >= imagenYMaxima)) return true;
            else if ((CampoXMinima <= imagenXMinima) && (CampoXMaxima >= imagenXMinima) && (CampoYMinima <= imagenYMaxima) && (CampoYMaxima >= imagenYMaxima)) return true;
            else if ((CampoXMinima <= imagenXMaxima) && (CampoXMaxima >= imagenXMaxima) && (CampoYMinima <= imagenYMinima) && (CampoYMaxima >= imagenYMinima)) return true;

            else if ((CampoXMinima <= imagenXMinima) && (CampoXMaxima >= imagenXMaxima) && (CampoYMinima >= imagenYMinima) && (CampoYMaxima <= imagenYMaxima)) return true;
            else if ((imagenXMinima <= CampoXMinima) && (imagenXMaxima >= CampoXMaxima) && (imagenYMinima >= CampoYMinima) && (imagenYMaxima <= CampoYMaxima)) return true;


            else if ((CampoXMinima >= imagenXMinima) && (CampoXMinima <= imagenXMaxima) && (CampoYMinima >= imagenYMinima) && (CampoYMaxima <= imagenYMaxima)) return true;
            else if ((CampoXMaxima >= imagenXMinima) && (CampoXMaxima <= imagenXMaxima) && (CampoYMinima >= imagenYMinima) && (CampoYMaxima <= imagenYMaxima)) return true;

            else if ((imagenXMinima >= CampoXMinima) && (imagenXMinima <= CampoXMaxima) && (imagenYMinima >= CampoYMinima) && (imagenYMaxima <= CampoYMaxima)) return true;
            else if ((imagenXMaxima >= CampoXMinima) && (imagenXMaxima <= CampoXMaxima) && (imagenYMinima >= CampoYMinima) && (imagenYMaxima <= CampoYMaxima)) return true;

            else if ((CampoXMinima >= imagenXMinima) && (CampoXMaxima <= imagenXMaxima) && (CampoYMinima >= imagenYMinima) && (CampoYMinima <= imagenYMaxima)) return true;
            else if ((CampoXMinima >= imagenXMinima) && (CampoXMaxima <= imagenXMaxima) && (CampoYMaxima >= imagenYMinima) && (CampoYMaxima <= imagenYMaxima)) return true;

            else return false;
        }

       
    }
}
