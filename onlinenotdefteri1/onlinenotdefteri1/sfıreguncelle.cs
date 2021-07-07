using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace onlinenotdefteri1
{
    public partial class sfıreguncelle : Form
    {
        DB vt = new DB();
        public anamenu geri;
        public int ID;
        public sfıreguncelle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (vt.sifree(ID) == textBox2.Text)
            {

              bool eklendi=  vt.kullanıcıguncelle(ID, textBox1.Text);
                if (eklendi)
                {
                    MessageBox.Show("Sifre degisimi başarılı.", "Başarılı");
                }
                else
                {
                    MessageBox.Show("Sifre Degisimi başarısız.", "Hatalı");
                }

            }
            else {
                MessageBox.Show("Eski Sifre yanlıs.", "Hatalı");
            
            }
        }

        private void sfıreguncelle_FormClosing(object sender, FormClosingEventArgs e)
        {
            geri.Show();
        }
    }
}
