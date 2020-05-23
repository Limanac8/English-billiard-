using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BILLIARDTRAINING
{

    
    class Sto
    {
        private int stoX ;

        private int stoY ;

        private int duzina ;

        private int sirina ;

        private int srednjaX;

        

        

        public Sto()
        {
            stoX = 30;
            stoY = 30;
            duzina = 684;

             sirina = 354;

            srednjaX = 360;

    }
    public float StoX
        {
            get { return stoX; }
        }
        public float StoY
        {
            get { return stoY; }
        }
       
        public float Duzina
        {
            get { return duzina; }
        }
        public float Sirina
        {
            get { return sirina; }
        }
        public float SrednjaX
        {
            get { return srednjaX; }
        }
       






    }

}
