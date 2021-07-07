using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace onlinenotdefteri1
{

    class DB
    {
        MySqlConnection baglanti = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=notepad;");
        //Baglanti adında bir bağlantı oluşturdum

        public bool kullanici_ekle()
        {
            // blablablbabalbalba
            return true;
        }
        public int kullaniciID(String kullaniciAdi, String sifre)
        {
            try
            {
                baglanti.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT ID FROM kullanicilar WHERE kullanici_adi='" + kullaniciAdi + "' AND sifre='" + sifre + "'", baglanti);
                var reader = cmd.ExecuteReader();
                reader.Read();
                int id = -1;
                id = reader.GetInt32("ID");
                baglanti.Close();
                if (id > 0)
                {
                    return id;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception e)
            {
                return -1;
            }
        }


        public string sifree(int IDd)
        {
            try
            {
                baglanti.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT sifre FROM kullanicilar WHERE ID='" + IDd +"'", baglanti);
                var reader = cmd.ExecuteReader();
                reader.Read();
                string say = reader.GetString("sifre");
                baglanti.Close();
                if (say !=null)
                {
                    Console.WriteLine(say);
                    return say;

                }
                else
                {
                    return say;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool girisYap(String kullaniciAdi, String sifre)
        {
            try
            {
                baglanti.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(ID) AS kontrol FROM kullanicilar WHERE kullanici_adi='" + kullaniciAdi + "' AND sifre='" + sifre + "'", baglanti);
                var reader = cmd.ExecuteReader();
                reader.Read();
                int say = reader.GetInt32("kontrol");
                baglanti.Close();
                if (say > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public void izinVerilmisNotlarim(int ID, System.Windows.Forms.ListBox lbToAdd)
        {
            try
            {
                baglanti.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM defterler", baglanti);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string json = "[]";
                    if (reader.GetString("izin") != "")
                        json = reader.GetString("izin");
                    dynamic array = JsonConvert.DeserializeObject(json);
                    foreach (int item in array)
                    {
                        if (item == ID)
                        {
                            lbToAdd.Items.Add(reader.GetString("ID") + " - " + reader.GetString("baslik"));
                            break;
                        }
                    }
                }
                baglanti.Close();
            }
            catch (Exception e)
            {

            }
        }
        public void notlarim(int ID, System.Windows.Forms.ListBox lbToAdd)
        {
            try
            {
                baglanti.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM defterler WHERE sahip='" + ID + "'", baglanti);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lbToAdd.Items.Add(reader.GetString("ID") + " - " + reader.GetString("baslik"));
                }
                baglanti.Close();
            }
            catch (Exception e)
            {

            }
        }

        public bool kullanıcıekle(string adı, string kullanıcıadı, string eposta, string sifre)
        {
            bool geri;
            try
            {
                baglanti.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO kullanicilar(ad_soyad,kullanici_adi,eposta,sifre) VALUES('" + adı + "','" + kullanıcıadı + "','" + eposta + "','" + sifre + "')", baglanti);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    geri = true;
                }
                else
                {
                    geri = false;
                }
                baglanti.Close();

            }
            catch (Exception e)
            {
                geri = false;
            }
            return geri;
        }


        public bool notEkle(string not, int sahip, string baslik,string jsonIzin)
        {
            bool geri;
            try
            {
                baglanti.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO defterler(baslik,icerik,sahip,izin) VALUES('" + baslik + "','" + not + "','" + sahip + "','"+jsonIzin+"')", baglanti);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    geri = true;
                }
                else
                {
                    geri = false;
                }
                baglanti.Close();

            }
            catch (Exception e)
            {
                geri = false;
            }
            return geri;
        }



        public bool kullanıcıguncelle(int ID,  string sifre)
        {
            bool geri;
            try
            {
                baglanti.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE kullanicilar  SET sifre='" + sifre + "' WHERE ID='" + ID + "'", baglanti);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    geri = true;
                }
                else
                {
                    geri = false;
                }
                baglanti.Close();

            }
            catch (Exception e)
            {
                geri = false;
            }
            return geri;
        }
        public bool notDuzenle(int ID, string not, string baslik, string jsonIzin)
        {
            bool geri;
            try
            {
                baglanti.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE defterler SET baslik='" + baslik + "',icerik='" + not + "',izin='"+jsonIzin+"' WHERE ID='"+ID+"'", baglanti);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    geri = true;
                }
                else
                {
                    geri = false;
                }
                baglanti.Close();

            }
            catch (Exception e)
            {
                geri = false;
            }
            return geri;
        }
        public bool notSil(int ID)
        {
            bool geri;
            try
            {
                baglanti.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM defterler WHERE ID='"+ID+"'", baglanti);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    geri = true;
                }
                else
                {
                    geri = false;
                }
                baglanti.Close();

            }
            catch (Exception e)
            {
                geri = false;
            }
            return geri;
        }
        public String[] notCek(int ID, System.Windows.Forms.ListView lvToAdd)
        {
            string izinJson = "[]";
            String[] kayit = new String[2];
            try
            {
                baglanti.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM defterler WHERE ID='" + ID + "'", baglanti);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    kayit[0] = reader.GetString("baslik");
                    kayit[1] = reader.GetString("icerik");
                    if (reader.GetString("izin") != "")
                        izinJson = reader.GetString("izin");
                }
                baglanti.Close();
            }
            catch (Exception e)
            {
                kayit = null;
            }
            try
            {
                dynamic array = JsonConvert.DeserializeObject(izinJson);
                foreach (int item in array)
                {
                    baglanti.Open();
                    MySqlCommand c2 = new MySqlCommand("SELECT * FROM kullanicilar WHERE ID='" + item.ToString() + "'", baglanti);
                    var r2 = c2.ExecuteReader();
                    while (r2.Read())
                    {
                        System.Windows.Forms.ListViewItem lvi = new System.Windows.Forms.ListViewItem();
                        lvi.Name = "2lvi-" + item;
                        lvi.Text = item + "";
                        lvi.SubItems.Add(r2.GetString("ad_soyad"));
                        lvi.SubItems.Add(r2.GetString("kullanici_adi"));
                        lvToAdd.Items.Add(lvi);
                    }
                    baglanti.Close();
                }
            }
            catch (Exception e)
            {

            }
            return kayit;
        }
        public String[] notCek(int ID)
        {
            String[] kayit = new String[2];
            try
            {
                baglanti.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM defterler WHERE ID='" + ID + "'", baglanti);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    kayit[0] = reader.GetString("baslik");
                    kayit[1] = reader.GetString("icerik");
                }
                baglanti.Close();
            }
            catch (Exception e)
            {
                kayit = null;
            }
            return kayit;
        }
        public void kullaniciAra(string ara, System.Windows.Forms.ListView lvToAdd)
        {
            try
            {
                baglanti.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM kullanicilar WHERE kullanici_adi LIKE '%" + ara + "%'", baglanti);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    System.Windows.Forms.ListViewItem lvi = new System.Windows.Forms.ListViewItem();
                    lvi.Name = "lvi-"+reader.GetString("ID");
                    lvi.Text = reader.GetString("ID");
                    lvi.SubItems.Add(reader.GetString("ad_soyad"));
                    lvi.SubItems.Add(reader.GetString("kullanici_adi"));
                    lvToAdd.Items.Add(lvi);
                    //lvToAdd.Items.Add(reader.GetString("ID") + " - " + reader.GetString("ad_soyad"));
                }
                baglanti.Close();
            }
            catch (Exception e)
            {

            }
        }
        public string blah()
        {
            string rt = "";
            string json = "[5,1,3,6,21,51]";
            dynamic array = JsonConvert.DeserializeObject(json);
            foreach (var item in array)
            {
                rt += item;
            }
            return rt;
        }
    }
}
