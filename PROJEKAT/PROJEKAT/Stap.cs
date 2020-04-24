using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BILLIARDTRAINING
{
    class Stap
    {
        private float duzina = 145;

        private float sirinaVrh = (float)1.2;

        private int x;

        private int y;

        public float Duzina
        {
            get { return duzina; }
        }
        public float SirinaVrh
        {
            get { return sirinaVrh; }
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

    }
}
