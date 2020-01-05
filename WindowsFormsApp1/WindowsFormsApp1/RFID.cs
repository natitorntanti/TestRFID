using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class RFID
    {
        private string portcom;
        private int buadrate;
        private string sector;
        private string block;
        private string keyA;
        private string keyB;

        // Variable zone

        public string Portcom
        {
            get { return portcom; }
            set { portcom = value; }
        }
        public int Buadrate
        {
            get { return buadrate; }
            set { buadrate = value; }
        }
        public string Sector
        {
            get { return sector; }
            set { sector = value; }
        }
        public string Block
        {
            get { return block; }
            set { block = value; }
        }
       // Key A & Key B perproties
        public string KeyA {
            get { return keyA; }
            set { keyA = value; }
        }
        public string KeyB {
            get { return keyB; }
            set { keyB = value;}
        }
    }

}
