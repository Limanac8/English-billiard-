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
using System.Xml.Serialization;
using System.IO;

namespace BILLIARDTRAINING
{
   
    public partial class FrmIgra : Form
    {


        //private PointF pocetna;
        

        private PointF krajnja;

        private Kugla bela = new Kugla(Color.White);

        private Kugla crvena = new Kugla(Color.Red);
        private PointF belaPrava;
        private PointF crvenaPrava;

        bool igraj = false;


        private Sto sto = new Sto();

        private double trenje = 0.98;
        
        private int trenutniSkor = 0;

      

        private bool usao = false;

        private bool uPotezu = false;

        private bool usao2 = false;

        private int indeksIgraca;
     
        private List<Igrac> lista;
       
        public FrmIgra()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
           // pocetna = new PointF();
            krajnja = new PointF();
            TAJMER.Start();
            lista = new List<Igrac>();
               Random randPoX = new Random();
            Random randPoY = new Random();
            PointF zaCrvenu = new PointF(randPoX.Next(50,Convert.ToInt32(sto.Duzina) - 20 ), randPoY.Next(50, Convert.ToInt32(sto.Sirina) - 20));

            crvena.Lokacija = zaCrvenu;

            PointF zaBelu = new PointF(randPoX.Next(250, pnlSto.Width - 40), randPoY.Next(40, 230));

            bela.Lokacija = zaBelu;
            bela.Dx = 0;
            crvena.Dx = 0;
            belaPrava = new PointF(bela.Lokacija.X + bela.R, bela.Lokacija.Y + bela.R);
            crvenaPrava = new PointF(crvena.Lokacija.X + crvena.R, crvena.Lokacija.Y + crvena.R);
            

    }
        public FrmIgra(int indeks)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            // pocetna = new PointF();
            krajnja = new PointF();
            TAJMER.Start();
            lista = new List<Igrac>();
            Random randPoX = new Random();
            Random randPoY = new Random();
            PointF zaCrvenu = new PointF(randPoX.Next(50, Convert.ToInt32(sto.Duzina) - 20), randPoY.Next(50, Convert.ToInt32(sto.Sirina) - 20));

            crvena.Lokacija = zaCrvenu;

            PointF zaBelu = new PointF(randPoX.Next(250, pnlSto.Width - 40), randPoY.Next(40, 230));

            bela.Lokacija = zaBelu;
            bela.Dx = 0;
            crvena.Dx = 0;
            belaPrava = new PointF(bela.Lokacija.X + bela.R, bela.Lokacija.Y + bela.R);
            crvenaPrava = new PointF(crvena.Lokacija.X + crvena.R, crvena.Lokacija.Y + crvena.R);
            indeksIgraca = indeks;
            XmlSerializer xmlSer = new XmlSerializer(typeof(List<Igrac>));
            StreamReader streamReader = new StreamReader(Environment.CurrentDirectory + "\\igraci.xml");
            lista = (List<Igrac>)xmlSer.Deserialize(streamReader);
            streamReader.Close();
            lblIme.Text = lista[indeksIgraca].Nick;
            lblHaj.Text = lista[indeksIgraca].Highscore.ToString();
            indeksIgraca = 0;

        }

        public void iscrtajKugle()
        {
            Graphics g = pnlSto.CreateGraphics();
            //if(!bela.URupi)
           /* if (!bela.URupi)
            {*/
                g.FillEllipse(Brushes.White, belaPrava.X - bela.R , belaPrava.Y - bela.R , 2 * bela.R, 2 * bela.R);
            //}
            g.FillEllipse(Brushes.Red, crvenaPrava.X-bela.R  , crvenaPrava.Y - bela.R , 2 * crvena.R, 2 * crvena.R);
          
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
            if (uPotezu == false)
            {
                PointF DjeJeBela = new PointF(belaPrava.X, belaPrava.Y);
                PointF DjeSiStisno = new PointF(e.X, e.Y);
                // label1.Text = bela.Lokacija.X.ToString();
                //label2.Text = e.X.ToString();
                // label3.Text = Udaljenost(bela.Lokacija, DjeSiStisno).ToString();
                bela.Dx = 1;
                crvena.Dx = 1;
                bela.Dy = 0;
                crvena.Dy = 0;
                

                if (Udaljenost(DjeJeBela, DjeSiStisno) < 30)
                {
                    igraj = true;
                   
                   
                }   
            }
        }

        private void PnlSto_MouseUp(object sender, MouseEventArgs e)
        {
            if (uPotezu == false && igraj == true)
            {
                krajnja.X = e.X;
                krajnja.Y = e.Y;
                
                if (belaPrava.Y > krajnja.Y)
                {
                    if (belaPrava.X > krajnja.X)
                    { 
                        bela.Dy = (belaPrava.Y - krajnja.Y) / (belaPrava.X - krajnja.X);
                        bela.Dx = 1;
                    }

                    else
                    {
                        bela.Dy = (belaPrava.Y - krajnja.Y) / (krajnja.X - belaPrava.X);
                        bela.Dx = -1;
                    }
                }
                else
                {
                    if (belaPrava.X > krajnja.X)
                    {
                        bela.Dy = (krajnja.Y - belaPrava.Y) / (belaPrava.X - krajnja.X);
                        bela.Dx = 1;
                    }
                    else
                    {
                        bela.Dy = -1*(krajnja.Y - belaPrava.Y) / (krajnja.X - belaPrava.X);
                        bela.Dx = -1;
                    }
                }
               
                odrediJacinu(bela);
                uPotezu = true;
                igraj = false;
            }
          

        }
        private float Udaljenost(PointF a, PointF b)
        {
            return  (float)Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }
        
        private void odrediJacinu(Kugla a)
        {
            a.Jacina = (float)Math.Pow(Udaljenost(belaPrava, krajnja), 1.1);
            if (Udaljenost(belaPrava, krajnja) > 300)
            {
                a.Jacina = (float)Math.Pow(160, 1.1);
            }
            if (Udaljenost(belaPrava, krajnja) < 50)
            {
                a.Jacina = 0;
            }
          
            

        }
        private void Potez()
        {
            usao = false;
            //odrediJacinu();
            if (uPotezu)
            {
                
                /* label1.Text = Udaljenost(bela.Lokacija, krajnja).ToString();
                 label2.Text = krajnja.X.ToString();
                 label3.Text = bela.Lokacija.X.ToString();*/

                

               
                /*bela.Dy = (float)Math.Sqrt(((float)Math.Pow(Udaljenost(pocetna, krajnja), 2) / (float)Math.Pow(pocetna.X - krajnja.X, 2)) - 1);
                if(pocetna.Y > krajnja.Y)
                bela.Dy = bela.Dy * Jacina / 20;
                else
                    bela.Dy = -bela.Dy * Jacina / 20;
                if (pocetna.X > krajnja.X)
                    bela.Dx = -Jacina / 20;
                else
                    bela.Dx = Jacina / 20;
                Jacina = Convert.ToInt32(Jacina * trenje);*/

                /* else
                 {
                     bela.Dx = 5;
                     bela.Dy = 3;
                 }*/
                /*if (bela.Lokacija.X  + bela.Dx > (sirina / 2 - 30) && bela.Lokacija.X  + bela.Dx < (sirina / 2 + 30))
                {
                    if ((bela.Lokacija.Y + bela.Dy < stoY) || (bela.Lokacija.Y + bela.Dy > duzina))
                    {
                        Random randPoX = new Random();
                        Random randPoY = new Random();

                       

                        bela.URupi = true;
                        bela.Dx = 0;
                        bela.Dy = 0;
                    }

                }*/

                /*if (bela.Lokacija.Y > duzina - 10 && bela.Lokacija.X < 10)
                {
                    bela.URupi = true;
                }
                if (bela.Lokacija.Y > duzina - 10 && bela.Lokacija.X < 10)
                {
                    bela.URupi = true;
                }*/
                if ((Math.Sqrt(bela.Dx  * bela.Dx + bela.Dy  * bela.Dy) * bela.Jacina < 10 && Math.Sqrt(bela.Dx * bela.Dx + bela.Dy  * bela.Dy) * bela.Jacina > 0) && (Math.Sqrt(crvena.Dx  * crvena.Dx + crvena.Dy  * crvena.Dy) * crvena.Jacina < 10  && Math.Sqrt(crvena.Dx *  crvena.Dx + crvena.Dy  * crvena.Dy) * crvena.Jacina > 0))
                {
                    crvena.Dx = 0;
                    crvena.Dy = 0;
                    bela.Dx = 0;
                    bela.Dy = 0;
                    bela.Jacina = 0;
                    crvena.Jacina = 0;
                  
                    uPotezu = false;
 
                }
                if(Udaljenost(belaPrava, crvenaPrava) <= bela.R + crvena.R)
                {
                   /* if(Udaljenost(belaPrava, crvenaPrava) == bela.R + crvena.R)
                    {
                        crvena.Dx = bela.Dx;
                        crvena.Dy = bela.Dy;
                        bela.Dx = -1 * bela.Dx;
                        bela.Dy = -1 * bela.Dy;
                        crvena.Jacina = Convert.ToInt32(bela.Jacina * 0.4);
                        bela.Jacina = Convert.ToInt32(bela.Jacina * 0.1);

                    }*/
                    if (crvenaPrava.Y > belaPrava.Y)
                    {
                        if (crvenaPrava.X > belaPrava.X)
                        {
                            crvena.Dy = (crvenaPrava.Y - bela.Lokacija.Y) / (crvenaPrava.X - belaPrava.X);
                            crvena.Dx = 1;
                            crvena.Jacina = (float)(bela.Jacina * 0.7);
                            bela.Jacina = (float)(bela.Jacina * 0.3);
                           
                            bela.Dy = crvena.Dy * (-1);
                        }

                        else
                        {
                            crvena.Dy = (crvenaPrava.Y - belaPrava.Y) / (belaPrava.X - crvenaPrava.X);
                            crvena.Dx = -1;
                            crvena.Jacina = (float) (bela.Jacina * 0.7);
                            bela.Jacina = (float)(bela.Jacina * 0.3);
                            bela.Dy = crvena.Dy * (-1);
                        }
                       
                    }
                    else
                    {
                        if (crvenaPrava.X > belaPrava.X)
                        {
                            crvena.Dy = -1* (belaPrava.Y - crvenaPrava.X) / (crvenaPrava.X - belaPrava.X);
                            crvena.Dx = 1;
                            crvena.Jacina = (float)(bela.Jacina * 0.7);
                            bela.Jacina = (float)(bela.Jacina * 0.3);
                            bela.Dy = crvena.Dy * (-1);
                        }
                        else
                        {
                            crvena.Dy = -1* (belaPrava.Y - crvenaPrava.Y) / (belaPrava.X - crvenaPrava.X);
                            crvena.Dx = -1;
                            crvena.Jacina = Convert.ToInt32(bela.Jacina * 0.7);
                            bela.Jacina = Convert.ToInt32(bela.Jacina * 0.3);
                            bela.Dy = crvena.Dy * (-1);
                        }
                        
                    }
                }

                if ((belaPrava.X + bela.Dx > sto.SrednjaX - 20) && (belaPrava.X + bela.Dx < sto.SrednjaX + 20))
                {
                    if ((belaPrava.Y + bela.Dy + bela.R >= sto.Sirina) || (belaPrava.Y + bela.Dy - bela.R <= sto.StoY))
                    {

                        trenutniSkor--;
                        lblSkor.Text = trenutniSkor.ToString();
                        Random randPoX = new Random();
                        Random randPoY = new Random();
                        PointF zaBelu = new PointF(randPoX.Next(40, pnlSto.Width - 40), randPoY.Next(40, 230));

                        belaPrava = zaBelu;
                        bela.Dx = 0;
                        bela.Dy = 0;
                        uPotezu = false;
                    }
                    else if (belaPrava.X + bela.Dx - bela.R <= sto.StoX)
                    {
                        if (bela.Dx < 0)
                        {
                            bela.Dx *= -1;
                            bela.Jacina *= (float)0.8;
                        }
                    }
                    else if (belaPrava.X + bela.Dx + bela.R >= sto.Duzina)
                    {
                        if (bela.Dx > 0)
                        {
                            bela.Dx *= -1;
                            bela.Jacina *= (float)0.8;
                        }
                    }
                    else if (belaPrava.Y + bela.Dy - bela.R <= sto.StoY)
                    {
                        if (bela.Dy < 0)
                        {
                            bela.Dy *= -1;
                            bela.Jacina *= (float)0.8;
                        }
                    }
                    else if (belaPrava.Y + bela.Dy + bela.R >= sto.Sirina)
                    {
                        if (bela.Dy > 0)
                        {
                            bela.Dy *= -1;
                            bela.Jacina *= (float)0.8;
                        }
                    }
                    usao = true;

                }
                else if (belaPrava.X + bela.Dx - bela.R < sto.StoX + 10)
                {
                    if ((belaPrava.Y + bela.Dy + bela.R >= sto.Sirina - 10) || (belaPrava.Y + bela.Dy - bela.R <= sto.StoY + 10))
                    {

                        trenutniSkor--;
                        lblSkor.Text = trenutniSkor.ToString();
                        Random randPoX = new Random();
                        Random randPoY = new Random();
                        PointF zaBelu = new PointF(randPoX.Next(40, pnlSto.Width - 40), randPoY.Next(40, 230));
                        belaPrava = zaBelu;
                        bela.Dx = 0;
                        bela.Dy = 0;
                        uPotezu = false;
                    }
                   
                    else if (belaPrava.X + bela.Dx - bela.R <= sto.StoX)
                    {
                        if (bela.Dx < 0)
                        {
                            bela.Dx *= -1;
                            bela.Jacina *= (float)0.8;
                        }
                    }
                    else if (belaPrava.X + bela.Dx + bela.R >= sto.Duzina)
                    {
                        if (bela.Dx > 0)
                        {
                            bela.Dx *= -1;
                            bela.Jacina *= (float)0.8;
                        }
                    }
                    else if (belaPrava.Y + bela.Dy - bela.R <= sto.StoY)
                    {
                        if (bela.Dy < 0)
                        {
                            bela.Dy *= -1;
                            bela.Jacina *= (float)0.8;
                        }
                    }
                    else if (belaPrava.Y + bela.Dy + bela.R >= sto.Sirina)
                    {
                        if (bela.Dy > 0)
                        {
                            bela.Dy *= -1;
                            bela.Jacina *= (float)0.8;
                        }
                    }
                    usao = true;
                }


                else if (belaPrava.X + bela.Dx + bela.R > sto.Duzina - 10)
                {
                    if ((belaPrava.Y + bela.Dy - bela.R <= sto.StoY + 10)|| (belaPrava.Y + bela.Dy + bela.R >= sto.Sirina - 10))
                    {
                        trenutniSkor--;
                        lblSkor.Text = trenutniSkor.ToString();
                        Random randPoX = new Random();
                        Random randPoY = new Random();
                        PointF zaBelu = new PointF(randPoX.Next(40, pnlSto.Width - 40), randPoY.Next(40, 230));
                        belaPrava = zaBelu;
                        bela.Dx = 0;
                        bela.Dy = 0;
                        uPotezu = false;
                    }
                  

                    else if (belaPrava.X + bela.Dx + bela.R >= sto.Duzina)
                {
                    if (bela.Dx > 0)
                    {
                        bela.Dx *= -1;
                        bela.Jacina *= (float)0.8;
                    }
                }
                else if (belaPrava.Y + bela.Dy - bela.R <= sto.StoY)
                {
                    if (bela.Dy < 0)
                    {
                        bela.Dy *= -1;
                        bela.Jacina *= (float)0.8;
                    }
                }
                else if (belaPrava.Y + bela.Dy + bela.R >= sto.Sirina)
                {
                    if (bela.Dy > 0)
                    {
                        bela.Dy *= -1;
                        bela.Jacina *= (float)0.8;
                    }
                }
                    if (belaPrava.X + bela.Dx - bela.R <= sto.StoX)
                    {
                        if (bela.Dx < 0)
                        {
                            bela.Dx *= -1;
                            bela.Jacina *= (float)0.8;
                        }
                    }
                    usao = true;
                }
                if(!usao)
                {
                    if (belaPrava.X + bela.Dx - bela.R <= sto.StoX)
                    {
                        if (bela.Dx < 0)
                        {
                            bela.Dx *= -1;
                            bela.Jacina *= (float)0.8;
                        }
                    }
                    else if (belaPrava.Y + bela.Dy - bela.R <= sto.StoY)
                    {
                        if (bela.Dy < 0)
                        {
                            bela.Dy *= -1;
                            bela.Jacina *= (float)0.8;
                        }
                    }
                    else if (belaPrava.Y + bela.Dy + bela.R >= sto.Sirina)
                    {
                        if (bela.Dy > 0)
                        {
                            bela.Dy *= -1;
                            bela.Jacina *= (float)0.8;
                        }
                    }

                    else if (belaPrava.X + bela.Dx + bela.R >= sto.Duzina)
                    {
                        if (bela.Dx > 0)
                        {
                            bela.Dx *= -1;
                            bela.Jacina *= (float)0.8;
                        }
                    }
                }






                if ((crvenaPrava.X + crvena.Dx > sto.SrednjaX - 20) && (crvenaPrava.X + crvena.Dx < sto.SrednjaX + 20))
                {
                    if ((crvenaPrava.Y + crvena.Dy + crvena.R >= sto.Sirina) || (crvenaPrava.Y + crvena.Dy - crvena.R <= sto.StoY))
                    {

                        trenutniSkor++;
                        lblSkor.Text = trenutniSkor.ToString();
                        Random randPoX = new Random();
                        Random randPoY = new Random();
                        PointF zacrvena = new PointF(randPoX.Next(40, pnlSto.Width - 40), randPoY.Next(40, 230));
                        crvenaPrava = zacrvena;
                        crvena.Dx = 0;
                        crvena.Dy = 0;
                 
                    }
                    else if (crvenaPrava.X + crvena.Dx - crvena.R <= sto.StoX)
                    {
                        if (crvena.Dx < 0)
                        {
                            crvena.Dx *= -1;
                            crvena.Jacina *= (float)0.8;
                        }
                    }
                    else if (crvenaPrava.Y + crvena.Dy - crvena.R <= sto.StoY)
                    {
                        if (crvena.Dy < 0)
                        {
                            crvena.Dy *= -1;
                            crvena.Jacina *= (float)0.8;
                        }
                    }
                    else if (crvenaPrava.Y + crvena.Dy + crvena.R >= sto.Sirina)
                    {
                        if (crvena.Dy > 0)
                        {
                            crvena.Dy *= -1;
                            crvena.Jacina *= (float)0.8;
                        }
                    }
                    else if (crvenaPrava.X + crvena.Dx + crvena.R >= sto.Duzina)
                    {
                        if (crvena.Dx > 0)
                        {
                            crvena.Dx *= -1;
                            crvena.Jacina *= (float)0.8;
                        }
                    }
                    usao2 = true;

                }
                else if (crvenaPrava.X + crvena.Dx - crvena.R < sto.StoX + 10)
                {
                    if ((crvenaPrava.Y + crvena.Dy + crvena.R >= sto.Sirina - 10) || (crvenaPrava.Y + crvena.Dy - crvena.R <= sto.StoY + 10))
                    {

                        trenutniSkor++;
                        lblSkor.Text = trenutniSkor.ToString();
                        Random randPoX = new Random();
                        Random randPoY = new Random();
                        PointF zacrvena = new PointF(randPoX.Next(40, pnlSto.Width - 40), randPoY.Next(40, 230));
                        crvenaPrava = zacrvena;
                        crvena.Dx = 0;
                        crvena.Dy = 0;
                  
                    }

                    else if (crvenaPrava.X + crvena.Dx - crvena.R <= sto.StoX)
                    {
                        if (crvena.Dx < 0)
                        {
                            crvena.Dx *= -1;
                            crvena.Jacina *= (float)0.8;
                        }
                    }
                    else if (crvenaPrava.Y + crvena.Dy - crvena.R <= sto.StoY)
                    {
                        if (crvena.Dy < 0)
                        {
                            crvena.Dy *= -1;
                            crvena.Jacina *= (float)0.8;
                        }
                    }
                    else if (crvenaPrava.Y + crvena.Dy + bela.R >= sto.Sirina)
                    {
                        if (crvena.Dy > 0)
                        {
                            crvena.Dy *= -1;
                            bela.Jacina *= (float)0.8;
                        }
                    }
                    else if (crvenaPrava.X + crvena.Dx + crvena.R >= sto.Duzina)
                    {
                        if (crvena.Dx > 0)
                        {
                            crvena.Dx *= -1;
                            crvena.Jacina *= (float)0.8;
                        }
                    }
                    usao2 = true;
                }


                else if (crvenaPrava.X + crvena.Dx + crvena.R > sto.Duzina - 10)
                {
                    if ((crvenaPrava.Y + crvena.Dy - crvena.R <= sto.StoY + 10) || (crvenaPrava.Y + crvena.Dy + crvena.R >= sto.Sirina - 10))
                    {
                        trenutniSkor++;
                        lblSkor.Text = trenutniSkor.ToString();
                        Random randPoX = new Random();
                        Random randPoY = new Random();
                        PointF zacrvena = new PointF(randPoX.Next(40, pnlSto.Width - 40), randPoY.Next(40, 230));
                        crvenaPrava = zacrvena;
                        crvena.Dx = 0;
                        crvena.Dy = 0;
                 
                    }

                    else if (crvenaPrava.X + crvena.Dx - crvena.R <= sto.StoX)
                    {
                        if (crvena.Dx < 0)
                        {
                            crvena.Dx *= -1;
                            crvena.Jacina *= (float)0.8;
                        }
                    }
                    else if (crvenaPrava.X + crvena.Dx + crvena.R >= sto.Duzina)
                    {
                        if (crvena.Dx > 0)
                        {
                            crvena.Dx *= -1;
                            crvena.Jacina *= (float)0.8;
                        }
                    }
                    else if (crvenaPrava.Y + crvena.Dy - crvena.R <= sto.StoY)
                    {
                        if (crvena.Dy < 0)
                        {
                            crvena.Dy *= -1;
                            crvena.Jacina *= (float)0.8;
                        }
                    }
                    else if (crvenaPrava.Y + crvena.Dy + crvena.R >= sto.Sirina)
                    {
                        if (crvena.Dy > 0)
                        {
                            crvena.Dy *= -1;
                            crvena.Jacina *= (float)0.8;
                        }
                    }
                    usao2 = true;
                }
                if (!usao2)
                {
                    if (crvenaPrava.X + crvena.Dx - crvena.R <= sto.StoX)
                    {
                        if (crvena.Dx < 0)
                        {
                            crvena.Dx *= -1;
                            crvena.Jacina *= (float)0.8;
                        }
                    }
                    else if (crvenaPrava.Y + crvena.Dy - crvena.R <= sto.StoY)
                    {
                        if (crvena.Dy < 0)
                        {
                            bela.Dy *= -1;
                            bela.Jacina *= (float)0.8;
                        }
                    }
                    else if (crvenaPrava.Y + crvena.Dy + crvena.R >= sto.Sirina)
                    {
                        if (crvena.Dy > 0)
                        {
                            crvena.Dy *= -1;
                            crvena.Jacina *= (float)0.8;
                        }
                    }

                    else if (crvenaPrava.X + crvena.Dx + crvena.R >= sto.Duzina)
                    {
                        if (crvena.Dx > 0)
                        {
                            crvena.Dx *= -1;
                            crvena.Jacina *= (float)0.8;
                        }
                    }
                }
               


                PointF pom1 = new PointF(bela.Dx * bela.Jacina / 20 + belaPrava.X, bela.Dy * bela.Jacina / 20 + belaPrava.Y);
                belaPrava= pom1;
                PointF pom2 = new PointF(crvena.Dx * crvena.Jacina / 20 + crvenaPrava.X, crvena.Dy * crvena.Jacina / 20 + crvenaPrava.Y);
                crvenaPrava = pom2;
              
                crvena.Jacina *= (float)trenje;
                bela.Jacina *= (float)trenje;
                usao = false;
                usao2 = false; 

            }


            if (lista[indeksIgraca].Highscore < trenutniSkor)
            {
                lista[indeksIgraca].Highscore = trenutniSkor;
                Stream stream = File.OpenWrite(Environment.CurrentDirectory + "\\igraci.xml");
                XmlSerializer ser = new XmlSerializer(typeof(List<Igrac>));
                ser.Serialize(stream, lista);
                stream.Close();
            }
        }
        private void TAJMER_Tick(object sender, EventArgs e)
        {

            Potez();
            iscrtajKugle();
            lblSkor.Text = trenutniSkor.ToString();
            pnlSto.Invalidate();
            
            
            
        }

        private void PnlSto_DragDrop(object sender, DragEventArgs e)
        {
            

        }
    }
}
