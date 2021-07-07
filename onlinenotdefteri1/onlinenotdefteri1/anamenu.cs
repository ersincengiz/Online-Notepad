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
    public partial class anamenu : Form
    {
        DB data = new DB();
        public int ID;
        public Form1 geri;
        public anamenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form3 f = new form3();
            f.sahip = ID;
            f.islem = "yeni";
            f.geri = this;
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form3 f = new form3(); 
            f.ID = Convert.ToInt32(listBox1.Items[listBox1.SelectedIndex].ToString().Split(' ')[0]);;
            f.sahip = ID;
            f.islem = "guncelle";
            f.geri = this;
            f.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int notID = Convert.ToInt32(listBox1.Items[listBox1.SelectedIndex].ToString().Split(' ')[0]);
            bool cevap = data.notSil(notID);
            if (cevap)
            {
                MessageBox.Show("Notunuz başarıyla silindi.", "Başarılı");
            }
            else
            {
                MessageBox.Show("Notunuz silinemedi.", "Hatalı");
            }
            listBoxGuncelle();
        }

        private void anamenu_Load(object sender, EventArgs e)
        {
            data.notlarim(ID, listBox1);
            data.izinVerilmisNotlarim(ID, listBox2);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        public void listBoxGuncelle()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            data.notlarim(ID, listBox1);
            data.izinVerilmisNotlarim(ID, listBox2);
        }

        private void anamenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            geri.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            form3 f = new form3();
            f.ID = Convert.ToInt32(listBox2.Items[listBox2.SelectedIndex].ToString().Split(' ')[0]);
            f.islem = "goruntule";
            f.geri = this;
            f.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sfıreguncelle s = new sfıreguncelle();
            s.ID = ID;
            s.geri = this;
            s.Show();
            this.Hide();
        }
    }
}
