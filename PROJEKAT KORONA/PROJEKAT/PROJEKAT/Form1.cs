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
        private int igrac = 1;

        private Kugla bela = new Kugla(Color.White);

        private Kugla crvena = new Kugla(Color.Red);

        private Kugla zuta = new Kugla(Color.Yellow);

        private double dx = 2;

        
        public FrmIgra()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            TAJMER.Start();
           
            crvena.Y = pnlSto.Height / 2 - 5;
            crvena.X = pnlSto.Width - 150;
            Random randPoX = new Random();
            Random randPoY = new Random();
            bela.X = randPoX.Next(0, pnlSkor.Width - 10);
            bela.Y = randPoY.Next(0, 200);
           zuta.X = randPoX.Next(0, pnlSkor.Width - 10);
            zuta.Y = randPoY.Next(0, 200);
            
        }

        public void iscrtajKugle()
        {
            Graphics g = pnlSto.CreateGraphics();
            g.FillEllipse(Brushes.White, bela.X, bela.Y, 2 * bela.R, 2 * bela.R);
            g.FillEllipse(Brushes.Red, crvena.X, crvena.Y, 2 * crvena.R, 2 * crvena.R);
            g.FillEllipse(Brushes.Yellow, zuta.X, zuta.Y, 2 * zuta.R, 2 * zuta.R);

        }
        public void iscrtajTablu()
        {
            Graphics g = pnlSto.CreateGraphics();
          Image sto = Image.FromFile("C:\\Users\\DAMJANOVIC\\Desktop\\PROJEKAT KORONA\\PROJEKAT\\PROJEKAT\\table2.jpg");
            g.DrawImage(sto, -2, 0);
            g = pnlSkor.CreateGraphics();
            Image ram  = Image.FromFile("C:\\Users\\DAMJANOVIC\\Desktop\\PROJEKAT KORONA\\PROJEKAT\\PROJEKAT\\GotovRam.png");
            g.DrawImage(ram, -2, 0);
            g = pnlZeleno.CreateGraphics();
            Image unutrasnjost = Image.FromFile("C:\\Users\\DAMJANOVIC\\Desktop\\PROJEKAT KORONA\\PROJEKAT\\PROJEKAT\\pozadina_zelena.jpg");
            g.DrawImage(unutrasnjost, 0,0);
            /* Pen pen = new Pen(bela.Boja);
             g.DrawEllipse(pen, 100, 100, bela.R*10, bela.R*10);*/
        }
        private void FrmIgra_Load(object sender, EventArgs e)
        {
           
            iscrtajTablu();
            iscrtajKugle();
          
        }

        
        private void PnlCrtaj_Paint(object sender, PaintEventArgs e)
        {
           
            iscrtajTablu();
            iscrtajKugle();
       
        }

        private void PnlSto_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void Potez()
        {
            
        }
        private void TAJMER_Tick(object sender, EventArgs e)
        {
            
            bela.X += (int)dx;
            iscrtajKugle();
            iscrtajTablu();
            
           
        }
    }
}
