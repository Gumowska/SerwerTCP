using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace SerwerTCP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private TcpListener serwer = null;
        private TcpClient klient = null;

        private void przycisk_start(object sender, EventArgs e)
        {
            IPAddress adresIP = null;
            try
            {
                adresIP = IPAddress.Parse(Adres.Text);
            }
            catch
            {
                MessageBox.Show("Bledny format adresu IP", "Blad");
                Adres.Text = String.Empty;
                return;
            }


            int port = System.Convert.ToInt32(port_p.Value);
            try
            {
                serwer = new TcpListener(adresIP, port);
                serwer.Start();

                klient = serwer.AcceptTcpClient();
                listBox1.Items.Add("Nawiazano polaczenia !");

                Start.Enabled = false;
                Stop.Enabled = true;

                klient.Close();
                serwer.Stop();
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("Blad inicjacji serwera !");
                MessageBox.Show(ex.ToString(), "Blad");
            }
        }
            private void przycisk_stop_Click(object sender , EventArgs e)
        {
            serwer.Stop();
            klient.Close();

            listBox1.Items.Add("Zakonczono prace serwera !");

            Start.Enabled = true;
            Stop.Enabled = false;
        }

            
    }
}
