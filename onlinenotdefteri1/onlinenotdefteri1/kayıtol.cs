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
    public partial class kayıtol : Form
    {
        DB vt = new DB();
        public Form1 geri;
        public kayıtol()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {

                bool eklendi = vt.kullanıcıekle(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                if (eklendi)
                {
                    MessageBox.Show("Üye Kayıdınız başarılı.", "Başarılı");
                }
                else
                {
                    MessageBox.Show("Üye Kayıdınız başarısız.", "Hatalı");
                }
            }
            else {
                MessageBox.Show("Bos alan bırakmayınız.","Hatalı");
            }
           
        }

        private void kayıtol_FormClosing(object sender, FormClosingEventArgs e)
        {
            geri.Show();
        }
    }
}
