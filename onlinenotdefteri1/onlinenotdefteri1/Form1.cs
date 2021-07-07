using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace onlinenotdefteri1
{
    public partial class Form1 : Form
    {
        DB data = new DB();
        public Form1()
        { 
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool kullanici = data.girisYap(textBox1.Text, textBox2.Text);
            if (kullanici == true)
            {
                anamenu a = new anamenu();
                a.ID = data.kullaniciID(textBox1.Text, textBox2.Text);
                a.geri = this;
                a.Show();
                this.Hide();   
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre, lütfen tekrar deneyiniz.","Uyarı!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kayıtol b = new kayıtol();
            b.geri = this;
            b.Show();
            this.Hide();
        }
    }
}
