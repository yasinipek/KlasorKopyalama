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

namespace KlasorKopyalama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int sayac = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            var dosyalar = new DirectoryInfo(textBox1.Text).GetFiles("*.*");
            foreach (FileInfo dosya in dosyalar)
            {
                dosya.CopyTo(textBox2.Text + dosya.Name, true);
            }
            label7.ForeColor = Color.Green;
            label7.Text = "ÇALIŞIYOR";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            label7.ForeColor = Color.Red;
            label7.Text = "DURDU";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            int sure = Convert.ToInt32(textBox3.Text) * 60;
            //label1.Text = sayac.ToString();
            if (sayac % sure == 0)
            {
                var dosyalar = new DirectoryInfo(textBox1.Text).GetFiles("*.*");
                foreach (FileInfo dosya in dosyalar)
                {
                    dosya.CopyTo(textBox2.Text + dosya.Name, true);
                }
            }
        }
    }
}
