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
    public partial class Editor : UserControl
    {
        #region Propiedades
        Conexion conexion;
        int cantidad;
        bool precionado = false;
        Point inicial;
        Point final;
        Item seleccionado;

        public int plantilla { get; internal set; }
        #endregion


        public Editor()
        {
            conexion = new Conexion();
            InitializeComponent();
            cantidad = 0;
            recargar();
            actualizarEventos();
        }


       
        /// <summary>
        /// recorre los controles y a todos los item le da sus eventos
        /// </summary>
        public void actualizarEventos()
        {
            this.Controls.Cast<Control>().Where(q => q.GetType().Equals(typeof(Item))).ToList().ForEach(q =>
            {
                this.DarEventos(q as Item);
            }
            );
        }



        public void mostrar()
        {
            this.Controls.Cast<Control>().Where(q => q.GetType().Equals(typeof(Item))).ToList().ForEach(q =>
            {
                q.Show();
            });

        }


        /// <summary>
        /// actualiza los elementos
        /// </summary>
        public void recargar()
        {
            conexion.cargarMesas(this, plantilla);
            this.panel.SendToBack();
            label.Text = this.Controls.Count + "";
            actualizarEventos();
        }


        public void itemPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;
            precionado = true;
            inicial = control.Location;
            seleccionado = (Item)control;
            seleccionado.BringToFront();
        }

        private void item_MouseDown(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;
            precionado = true;
            inicial = control.Location;


            seleccionado = new Item();
            DarEventos(seleccionado);
            seleccionado.BackColor = Color.Transparent;
            seleccionado.Image = (sender as PictureBox).Image;
            seleccionado.Location = control.Location;
            seleccionado.SizeMode = PictureBoxSizeMode.Zoom;

            #region tamaños
            Size mesaNormal = new Size(40, 40);
            Size MesaGrande = new Size(80, 80);
            Size MesaRectangular = new Size(60, 40);
            Size silla = new Size(20, 20);
            Size pared = new Size(180, 30);
            Size mesita = new Size(30, 30);
            Size TablaBar = new Size(180, 20);
            #endregion


            switch (control.Tag)
            {
                case "Mesa Redonda":
                    seleccionado.Size = mesaNormal;
                    seleccionado.Tag = "Mesa Redonda";
                    break;

                case "Tabla Bar":
                    seleccionado.Size = TablaBar;
                    seleccionado.Tag = "Tabla Bar";
                    break;

                case "Tabla Cocina":
                    seleccionado.Size = pared;
                    seleccionado.Tag = "Tabla Cocina";
                    break;

                case "Mesita":
                    seleccionado.Size = mesita;
                    seleccionado.Tag = "Mesita";
                    break;

                case "Mesa Redonda Transparente":
                    seleccionado.Size = mesaNormal;
                    seleccionado.Tag = "Mesa Redonda Transparente";
                    break;

                case "Mesa Redonda Negra":
                    seleccionado.Size = MesaRectangular;
                    seleccionado.Tag = "Mesa Redonda Negra";
                    break;

                case "Mesa Redonda Madera":
                    seleccionado.Size = mesaNormal;
                    seleccionado.Tag = "Mesa Redonda Madera";
                    break;

                case "Mesa Cuadrada":
                    seleccionado.Size = mesaNormal;
                    seleccionado.Tag = "Mesa Cuadrada";
                    break;

                case "Mesa cuadrada 4 sillas":
                    seleccionado.Size = mesaNormal;
                    seleccionado.Tag = "Mesa cuadrada 4 sillas";
                    break;

                case "Mesa Rectangular":
                    seleccionado.Size = MesaRectangular;
                    seleccionado.Tag = "Mesa Rectangular";
                    break;

                case "Mesa Redonda 8 sillas":
                    seleccionado.Size = MesaRectangular;
                    seleccionado.Tag = "Mesa Redonda 8 sillas";
                    break;

                case "Mesa Redonda 6 sillas":
                    seleccionado.Size = MesaGrande;
                    seleccionado.Tag = "Mesa Redonda 6 sillas";
                    break;

                case "Pared":
                    seleccionado.Size = pared;
                    seleccionado.Tag = "Pared";
                    seleccionado.SizeMode = seleccionado.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;

                case "Mesa Grande":
                    seleccionado.Size = MesaGrande;
                    seleccionado.Tag = "Mesa Grande";
                    break;

                case "Silla":
                    seleccionado.Size = silla;
                    seleccionado.Tag = "Silla";
                    break;

                case "Silla Roja":
                    seleccionado.Size = silla;
                    seleccionado.Tag = "Silla Roja";
                    break;
            }

            seleccionado.Show();
            this.Controls.Add(seleccionado);
            seleccionado.BringToFront();
        }

        public void item_MouseMove(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;
            if (precionado)
            {
                seleccionado.Top = e.Y + control.Top - (seleccionado.Height / 2);
                seleccionado.Left = e.X + control.Left - (seleccionado.Width / 2);

                if (!sePuedeColocar())
                {
                    seleccionado.BackColor = Color.Red;
                }
                else seleccionado.BackColor = Color.Green;
            }
        }

        public void item_MouseUp(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;

            precionado = false;
            final = control.Location;
            if (seleccionado != null)
            {
                seleccionado.BackColor = SystemColors.ActiveCaption;
                if (!sePuedeColocar())
                {
                    seleccionado.Location = inicial;

                    if (!estaEnArea(panel, seleccionado))
                    {
                        borrarControl(seleccionado);
                    }
                }

                else
                {

                    //guardamos en base de datos


                    if (seleccionado.index == 0)
                    {
                        //si no tiene index le colocamos uno y lo guardamos
                        seleccionado.darIndex(cantidad);
                        cantidad += 1;
                        conexion.guardarMesa(seleccionado, plantilla);
                    }
                    else
                    {
                        //en caso que si tenga lo modificamos nomas
                        conexion.editarMesa(seleccionado, plantilla);
                    }

                }
            }
        }

        /// <summary>
        /// verifica si se puede colocar el control
        /// </summary>
        /// <returns></returns>
        public bool sePuedeColocar()
        {
            return ((estaEnArea(panel, seleccionado)) && !existeElemento());
        }

        /// <summary>
        /// elimina un elemento de la lista de controles
        /// </summary>
        /// <param name="control"></param>
        public void borrarControl(Control control)
        {
            this.Controls.Remove(control);
        }

        /// <summary>
        /// entrega los eventos para mover un item
        /// </summary>
        /// <param name="pictureBox"></param>
        public void DarEventos(PictureBox pictureBox)
        {
            pictureBox.MouseDown += itemPanel_MouseDown;
            pictureBox.MouseUp += item_MouseUp;
            pictureBox.MouseMove += item_MouseMove;

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
                    if (seleccionado.Image != null)
                    {
                        Image image = seleccionado.Image;

                        image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                        cambiarAltoPorAncho(alto, ancho);

                        seleccionado.Image = image;

                        if (seleccionado.Tag.Equals("Pared")) seleccionado.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        borrarControl(seleccionado);
                        conexion.borrarMesa(seleccionado, plantilla);
                    }
                }
                else if (e.KeyCode == Keys.D)
                {
                    if (seleccionado != null)
                        borrarControl(seleccionado);

                    //MessageBox.Show(seleccionado.index.ToString());
                    conexion.borrarMesa(seleccionado, plantilla);

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
            if ((seleccionado.Height == alto) && (seleccionado.Width == ancho))
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
            if ((control == null) || (imagen == null)) return false;
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
                this.Controls.OfType<Control>().ToList<Control>().FindAll(q => q.GetType().Equals(typeof(Item)));
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
