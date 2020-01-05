using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using MiFare;
using MiFare.Classic;
using MiFare.Devices;
using MiFare.PcSc;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //private SmartCardReader reader;
        //private MiFareCard card;
        public static string setport;
        public static string setbuad;

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RFID rfid = new RFID();
            rfid.Portcom = comboBox1.Text;
            rfid.Buadrate = int.Parse(comboBox2.Text);
            System.IO.Ports.SerialPort serial = new System.IO.Ports.SerialPort(rfid.Portcom,
                                                                               rfid.Buadrate,
                                                                               System.IO.Ports.Parity.None,
                                                                               8,
                                                                               System.IO.Ports.StopBits.One);
            if(rfid.Buadrate == 14400)
            {
                serial.Open();
                MessageBox.Show("Connection Port: "+rfid.Portcom+" Success");
                button1.Visible = false;
                
            }
            else{
                MessageBox.Show("Connection Failed");
            }
            //MessageBox.Show("Success Connect Port : "+rfid.Portcom +" Buadrate : "+rfid.Buadrate);
            //Connect Button
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null) {
                comboBox2.SelectedIndex = 4;
                // Show Buadrate 14400
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (setport != null || setbuad !=null) {
                comboBox1.SelectedItem = setport;
                comboBox2.SelectedItem = setbuad;
            }
            else {
                string[] serialport = SerialPort.GetPortNames();
                comboBox1.SelectedItem = serialport[0];
                // Show Port COM1
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
                else {
                    comboBox4.SelectedIndex = 0;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RFID rfid = new RFID();
            rfid.Sector = comboBox3.Text;
            rfid.Block =  comboBox4.Text;
            rfid.Portcom = comboBox1.Text;
            rfid.Buadrate = int.Parse(comboBox2.Text);
            MessageBox.Show("Port : " + rfid.Portcom + " Buadrate : " + rfid.Buadrate + " Sector : " + rfid.Sector + " Block : " + rfid.Block);
            // Send data Sector Block Portcom and Buadrate to Class RFID
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ยังไม่ได้
            MessageBox.Show("Disconnect");
            button2.Visible = false;
            button1.Visible = true;
            // Disconnect button
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RFID rfid = new RFID();
            if (radioButton1.Checked == true) {
                rfid.KeyA = radioButton1.Text;
                MessageBox.Show(rfid.KeyA);
                // Send value Key A
            }
            else {
                rfid.KeyB = radioButton2.Text;
                MessageBox.Show(rfid.KeyB);
                // Send value Key B
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            WriteRFID writeRFID = new WriteRFID();
            WriteRFID.port = comboBox1.Text;
            WriteRFID.buad = comboBox2.Text;
            writeRFID.ShowDialog();
        }

        // ------------------------ Add Coding Reader RFID Card -----------Opened tags
        //private async void GetDevices() {
        //    try {
        //        reader = await CardReader.FindAsync();
        //        if (reader == null) {
        //            MessageBox.Show("No Reader Found");
        //            return;
        //        }
        //        //reader.CardAdded += CardAdded;
        //        reader.CardRemoved += CardRemoved;
        //    }
        //    catch (Exception e) {
        //        MessageBox.Show("Exception :" + e.Message);
        //    }
        //    }
        //private void CardRemoved(object sender, EventArgs e) {
        //    try
        //    {
        //        //await HandleCard(args);
        //    }
        //    catch (Exception ex) {
        //        MessageBox.Show("CardAddes Exception: "+ex.Message);
        //    }
        //}
        //private async Task HandleCard(CardEventArgs args) {
        //    try
        //    {
        //        card?.Dispose();
        //        card = args.SmartCard.CreateMiFareCard();

        //        var localCard = card;
        //        var cardIdentification = await localCard.GetCardInfo();
        //        MessageBox.Show("Connect to card device class: " + cardIdentification.PcscDeviceClass.ToString() + " card");
        //        if (cardIdentification.PcscDeviceClass == MiFare.PcSc.DeviceClass.StorageClass && (cardIdentification.PcscCardName == CardName.MifareStandard1K || cardIdentification.PcscCardName == CardName.MifareStandard4K))
        //        {
        //            // Handle MIFARE Standard/Classic 
        //            MessageBox.Show("MIFARE Standard/Classic card detected");
        //            var uid = await localCard.GetUid();
        //            MessageBox.Show("UID : " + BitConverter.ToString(uid));
        //            // 16 sectors ,print out each one 
        //            for (var sector = 0; sector < 16 && card != null; sector++)
        //            {
        //                try
        //                {
        //                    var data = await localCard.GetData(sector, 0, 48);
        //                    string hexString = "";
        //                    for (int i = 0; i < data.Length; i++)
        //                    {
        //                        hexString += data[i].ToString("X2") + " ";
        //                    }
        //                    MessageBox.Show(string.Format("Sector '{0}':{1}", sector, hexString));

        //                }
        //                catch (Exception)
        //                {
        //                    MessageBox.Show("Failed to load Sector" +sector);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e) {
        //        MessageBox.Show("HandleCard Exception : "+e.Message);
        //    }
        //}
        //--------------------------------Close Tag Reader RFID Card ---------------------------
       
    }
}
