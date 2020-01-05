using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiFare;
using MiFare.PcSc;
using MiFare.Classic;
using MiFare.Devices;

namespace WindowsFormsApp1
{
    class WriteRFIDcardcs : RFID
    {
        private string datablock;
        private string valueblock;
        private string valuedata;
        // Variable zone

        public string Datablock {
            get { return datablock; }
            set { datablock = value; }
        }
        public string Valueblock {
            get { return valueblock; }
            set { valueblock = value; }
        }
        public string Value {
            get { return valuedata; }
            set { valuedata = value; }
        }
        
    }
}
