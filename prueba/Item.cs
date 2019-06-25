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
    public partial class Item : UserControl
    {
        #region

        private PictureBox pictureBox;

        [Category("Propiedades")]
        public PictureBox imagen
        {
            get { return pictureBox; }
            set { pictureBox = value; }
        }

        #endregion

        public Item()
        {
            InitializeComponent();
        }


    }
}
