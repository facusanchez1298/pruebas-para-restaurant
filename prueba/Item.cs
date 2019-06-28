using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prueba
{

    
    class Item  : PictureBox
    {

        public int index;

        public void darIndex(int index)
        {
            this.index = index;
        }
    }
}
