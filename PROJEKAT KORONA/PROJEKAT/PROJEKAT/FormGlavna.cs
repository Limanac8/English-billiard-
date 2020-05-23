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
    public partial class FormGlavna : Form
    {
        private List<Igrac> lista;

        private int indeksIgraca;

        bool upo; 
        public FormGlavna()
        {
            InitializeComponent();
            lista = new List<Igrac>();
           
           
           
            XmlSerializer xmlSer = new XmlSerializer(typeof(List<Igrac>));
            StreamReader streamReader = new StreamReader(Environment.CurrentDirectory + "\\igraci.xml");
            lista = (List<Igrac>)xmlSer.Deserialize(streamReader);
            streamReader.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
          
                FormPocetna f = new FormPocetna();
                
                f.ShowDialog();
            
        }

        private void FormGlavna_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < lista.Count; ++i)
            {
                if(lista[i].Nick == tbNadimak.Text)
                {
                    if((lista[i].Password == tbSifra.Text))
                    {
                        indeksIgraca = i;
                        upo = true;
                    }
                }
            }
            if (upo)
            {
                FrmIgra f = new FrmIgra(indeksIgraca);

                f.ShowDialog();
            }
        }
    }
}
