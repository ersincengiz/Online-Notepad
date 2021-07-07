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
    public partial class form3 : Form
    {
        DB data = new DB();
        public int ID;
        public string islem;
        public int sahip;
        public anamenu geri;
        
        public form3()
        {
            InitializeComponent();
            textBox1.BorderStyle = 0;
            textBox1.BackColor = this.BackColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem[] items = new ListViewItem[listView2.Items.Count];
            listView2.Items.CopyTo(items, 0);
            string jsonIzin = "[";
            int i = 0;
            int total = listView2.Items.Count;
            foreach (var item in items)
            {
                jsonIzin += item.Text;
                if (++i < total) jsonIzin += ",";
            }
            jsonIzin += "]";
            bool eklendi = data.notEkle(textBox1.Text, sahip, textBox2.Text, jsonIzin);
            if (eklendi)
            {
                MessageBox.Show("Notunuz başarıyla kaydedildi.","Başarılı");
            }
            else
            {
                MessageBox.Show("Notunuz kaydedilemedi.", "Hatalı");
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            ListViewItem[] items = new ListViewItem[listView2.Items.Count];
            listView2.Items.CopyTo(items, 0);
            string jsonIzin = "[";
            int i = 0;
            int total = listView2.Items.Count;
            foreach (var item in items)
            {
                jsonIzin += item.Text;
                if (++i < total) jsonIzin += ",";
            }
            jsonIzin += "]";
            bool duzenlendi = data.notDuzenle(ID, textBox1.Text, textBox2.Text, jsonIzin);
            if (duzenlendi)
            {
                MessageBox.Show("Notunuz başarıyla güncellendi.", "Başarılı");
            }
            else
            {
                MessageBox.Show("Notunuz güncellenemedi.", "Hatalı");
            }
        }

        private void form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            geri.listBoxGuncelle();
            geri.Show();
        }

        private void form3_Load(object sender, EventArgs e)
        {

            if (islem == "yeni")
            {
                button2.Enabled = false;
                button1.Enabled = true;
            }
            if (islem == "guncelle")
            {
                button1.Enabled = false;
                button2.Enabled = true;
                String[] kayit = data.notCek(ID, listView2);
                if (kayit != null)
                {
                    textBox2.Text = kayit[0];
                    textBox1.Text = kayit[1];
                }
            }
            if (islem == "goruntule")
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                listView1.Enabled = false;
                listView2.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                String[] kayit = data.notCek(ID);
                if (kayit != null)
                {
                    textBox2.Text = kayit[0];
                    textBox1.Text = kayit[1];
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                if (listView2.Items.Find("2"+item.Name, true).Length >= 1)
                {
                    MessageBox.Show("Bu kullanıcıya zaten izin vermişsiniz.");
                    return;
                }
                ListViewItem ekle = (ListViewItem)item.Clone();
                ekle.Name = "2" + item.Name;
                listView2.Items.Add(ekle);
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Kullanıcı Adı Girin")
                textBox3.Text = "";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            data.kullaniciAra(textBox3.Text, listView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView2.SelectedItems)
            {
                listView2.Items.Remove(item);
            }
        }
    }
}
