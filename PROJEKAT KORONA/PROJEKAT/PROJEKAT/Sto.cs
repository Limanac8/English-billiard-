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
        private float sirinaUnutra = 198;

        private float visinaUnutra = 99;

        private float visinaSpolja = 137;

        private float sirinaSpolja = 236;

        private float srednjaRupaPrecnik = 13;

        private float cosakRupaPrecnik = (float)11.6;

        private Stap stap;

        private Kugla bela;

        private Kugla crvena; 

        private Kugla zuta;

        

        public Sto()
        {
            stap = new Stap();
            bela = new Kugla();
            bela.Boja = Color.White;
            //bela.x = ?
            //bela.y = ?
            zuta = new Kugla();
            zuta.Boja = Color.Yellow;
            //crna.x = ?
            //crna.y = ?
            crvena = new Kugla();
            crvena.Boja = Color.Red;
            //crvena.x = ?
            //crvena.y = ?
        }
        public float SirinaUnutra
        {
            get { return sirinaUnutra; }
        }
        public float VisinaUnutra
        {
            get { return visinaUnutra; }
        }
        public float VisinaSpolja
        {
            get { return visinaSpolja; }
        }
        public float SirinaSpolja
        {
            get { return sirinaSpolja; }
        }
        public float SrednjaRupaPrecnik
        {
            get { return srednjaRupaPrecnik; }
        }
        public float CosakRupaPrecnik
        {
            get { return cosakRupaPrecnik; }
        }

        public Stap Stap
        {
            get { return stap; }
        }

        public Kugla Bela
        {
            get { return bela; }
        }
        public Kugla Crvena
        {
            get { return crvena; }
        }

        public Kugla Zuta
        {
            get { return zuta; }
        }


    }

}
