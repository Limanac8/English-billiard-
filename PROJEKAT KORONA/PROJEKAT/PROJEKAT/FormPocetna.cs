using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;


namespace BILLIARDTRAINING
{
    public partial class FormPocetna : Form
    {
        private List<Igrac> lista;
        private int indeksIgraca;
        private Igrac I;
        public FormPocetna()
        {
            InitializeComponent();
            lista = new List<Igrac>();
            I = new Igrac();
        }
       

        private void BtnDodaj_Click(object sender, EventArgs e)
        {
            I.Ime = textBox1.Text;
            I.Prezime = textBox2.Text;
            I.Nick = textBox3.Text;
            I.Password = textBox4.Text;
            
            lista.Add(I);
            Stream stream = File.OpenWrite(Environment.CurrentDirectory + "\\igraci.xml");
            XmlSerializer ser = new XmlSerializer(typeof(List<Igrac>));
            ser.Serialize(stream, lista);
            stream.Close();
            btnDodaj.Enabled = false;
        }

        private void FormPocetna_Load(object sender, EventArgs e)
        {

        }
    }
}
