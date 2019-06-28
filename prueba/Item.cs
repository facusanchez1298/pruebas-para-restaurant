using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prueba
{

    
    public class Item  : PictureBox
    {

        public int index;
        public bool ocupado;

        public void estaOcupado(bool ocupado)
        {
            this.ocupado = ocupado;
        }

        public void darIndex(int index)
        {
            this.index = index;
        }
    }
}
