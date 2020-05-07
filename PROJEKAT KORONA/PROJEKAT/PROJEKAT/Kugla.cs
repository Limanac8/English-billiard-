using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BILLIARDTRAINING
{
    class Kugla
    {
        private float r = (float)10;

        private int x;

        private int y;

        private Color boja;

        public float R
        {
            get { return r; }
        }
        public Color Boja
        {
            get { return boja; }
            set { boja = value; }
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        
        public Kugla(Color c)
        {
            Boja = c;
        }
        public Kugla()
        {

        }

    }
}
