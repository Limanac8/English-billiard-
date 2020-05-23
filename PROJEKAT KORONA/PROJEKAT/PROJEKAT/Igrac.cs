using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BILLIARDTRAINING
{
    public class Igrac
    {
        private string ime;

        private string prezime;

        private string nick;

        private int highscore;

        private int trenutniSkor = 0;

        private string password;
        

        public int Highscore
        {
            get { return highscore; }
            set { highscore = value; }
        }
        public int TrenutniSkor
        {
            get { return trenutniSkor; }
            set { trenutniSkor = value; }
        }
        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }
       
        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }
        public string Nick
        {
            get { return nick; }
            set { nick = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }




    }
}
