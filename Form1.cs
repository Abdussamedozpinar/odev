using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ödev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string sitelink = "https://www.cnnturk.com/feed/rss/all/news";
        private int sayac;



        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            timer1.Start();
            timer1.Interval = 1000;
            if (sayac == 5)
            {
                sayac = 0;
                MessageBox.Show("5 dakikanız doldu tekrar analiz yapıyorum.", "Uyar!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Keşke kodlarını hatırlaya bilseydim veya bulabilseydim çok yakındı 
            }
            label1.Text = sayac.ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            XmlDocument doc1 = new XmlDocument();
            doc1.Load(sitelink);
            XmlElement root = doc1.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("channel/item");


            foreach (XmlNode node in nodes)
            {



                string baslik = node["title"].InnerText;
                string haber = node["description"].InnerText;




                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = baslik;
                row.Cells[1].Value = haber;
                dataGridView1.Rows.Add(row);


                string fileName = @"C:\deneme\deneme.txt";
                FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                fs.Close();
                File.AppendAllText(fileName, Environment.NewLine + "Haber Başlığı::" + baslik + Environment.NewLine + "Haber içeriği::" + haber + Environment.NewLine);




                


            }





        }

        
    }
}
