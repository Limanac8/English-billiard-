using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Windows;
namespace BILLIARDTRAINING
{
    public partial class FrmIgra : Form
    {

        private Kugla bela = new Kugla(Color.White);

        private Kugla crvena = new Kugla(Color.Red);

        private Kugla zuta = new Kugla(Color.Yellow);

        public FrmIgra()
        {
            InitializeComponent();
        }

       
        public void iscrtajSve()
        {
            Graphics g = pnlCrtaj.CreateGraphics();
          Image slika = Image.FromFile("C:\\Users\\DAMJANOVIC\\Desktop\\PROJEKAT KORONA\\PROJEKAT\\PROJEKAT\\table2.jpg");
            g.DrawImage(slika, 0, 0);
           /* Pen pen = new Pen(bela.Boja);
            g.DrawEllipse(pen, 100, 100, bela.R*10, bela.R*10);*/
        }
        private void FrmIgra_Load(object sender, EventArgs e)
        {
            
        }

        private void PnlCrtaj_Paint(object sender, PaintEventArgs e)
        {
            iscrtajSve();
        }
    }
}
