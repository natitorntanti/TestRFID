using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiFare;
using MiFare.PcSc;
using MiFare.PcSc.MiFareStandard;
using MiFare.PcSc.Iso7816;
using ApduResponse = MiFare.PcSc.Iso7816.ApduResponse;
using GeneralAuthenticate = MiFare.PcSc.GeneralAuthenticate;
using GetUid = MiFare.PcSc.MiFareStandard.GetUid;

namespace WindowsFormsApp1
{
    public partial class WriteRFID : Form
    {

        public static string port;
        public static string buad;
        public WriteRFID()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            Form1.setport = comboBox1.Text;
            Form1.setbuad = comboBox2.Text;
            form1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WriteRFIDcardcs writeRF = new WriteRFIDcardcs();
            writeRF.Portcom = comboBox1.Text;
            writeRF.Buadrate = int.Parse(comboBox2.Text);
            System.IO.Ports.SerialPort spot = new System.IO.Ports.SerialPort(writeRF.Portcom, writeRF.Buadrate, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);

            try
            {
                spot.Open();
                spot.Write("Connection Success Port: " + writeRF.Portcom + " Buadrate: " + writeRF.Buadrate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Failed " + ex.ToString());
            }
            //MessageBox.Show("Port :" + writeRF.Portcom + " Buad : " + writeRF.Buadrate);
            // Check Connection Port and Buad 
        }

        private void WriteRFID_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = port;
            comboBox2.SelectedItem = buad;
            // Show PortCom and Buadrate from From1 windows form application
        }

        private void button7_Click(object sender, EventArgs e)
        {
            WriteRFIDcardcs writeRFI = new WriteRFIDcardcs();
            if (radioButton1.Checked == true)
            {
                writeRFI.KeyA = radioButton1.Text;
                MessageBox.Show(writeRFI.KeyA);
                // Check Selected radiobutton KeyA
            }
            else{
                writeRFI.KeyB = radioButton2.Text;
                MessageBox.Show(writeRFI.KeyB);
                // Check Selected radiobutton KeyB
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            WriteRFIDcardcs writeRFI = new WriteRFIDcardcs();
            if (radioButton3.Checked == true)
            {
                writeRFI.Datablock = radioButton3.Text;
                writeRFI.Value = textBox1.Text;
                writeRFI.Sector = comboBox3.Text;
                writeRFI.Block = comboBox4.Text;
                MessageBox.Show(writeRFI.Datablock + " Value " + writeRFI.Value ,"Writting Sector "+writeRFI.Sector+" Block "+writeRFI.Block);
                // Check Value, Sector, Block,write DatablockMode checked
            }
            else {
                writeRFI.Valueblock = radioButton4.Text;
                writeRFI.Value = textBox1.Text;
                writeRFI.Sector = comboBox3.Text;
                writeRFI.Block = comboBox4.Text;
                MessageBox.Show(writeRFI.Valueblock+" Value "+writeRFI.Value, "Writting Sector " + writeRFI.Sector + " Block " + writeRFI.Block);
                // Check Value, Sector, Block,write valueblockMode  checked
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Remove("3");
            if (comboBox3.Text == "0")
            {
                comboBox4.Items.Remove("0");
                comboBox4.SelectedIndex = 0;
                // if selected sector 0. Choice have to 1 and 2 block
            }
            else
            {
                if (comboBox4.Items.Count <= 2)
                {
                    comboBox4.Items.Insert(0, "0");
                    comboBox4.SelectedIndex = 0;
                    // if select another sector.Choice have to  0, 1 and 2 block
                }
                else
                {
                    comboBox4.SelectedIndex = 0;
                }
            }
        }
        

    }
}
