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
        private float r;

        private PointF lokacija;
       

        private float dx ;

        private float dy;

        private bool uRupi ;

        private float jacina ;

        private Color boja;

        public bool URupi
        {
            get { return uRupi; }
            set { uRupi = value; }
        }
        public PointF Lokacija
        {
            get { return lokacija; }
            set { lokacija = value; }
        }

        public float R
        {
            get { return r; }
        }
        public Color Boja
        {
            get { return boja; }
            set { boja = value; }
        }
        public float Jacina
        {
            get { return jacina; }
            set { jacina = value; }
        }
        public float Dx
        {
            get { return dx; }
            set { dx = value; }
        }
        public float Dy
        {
            get { return dy; }
            set { dy = value; }
        }


        public Kugla(Color c)
        {
            Boja = c;
             r = (float)8;

   


         dx = 1;
      
      uRupi = false;

      jacina = 1;

        
    }
        public Kugla()
        {
            
        }

    }
}
