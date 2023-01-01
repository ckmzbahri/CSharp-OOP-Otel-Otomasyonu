using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Nesne_Otel
{
    public partial class kullanicigiriş : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "//otel1.mdb");

        public kullanicigiriş()
        {
            InitializeComponent();
        }

        private void bgiris_Click(object sender, EventArgs e)
        {
             if (kullaniciadi.Text == "" && kullanicisifre.Text == "")
            {
                MessageBox.Show("Lütfen Giriş Bilgilerini Yazın!");
            }
            else if (kullaniciadi.Text == "")
            {
                MessageBox.Show("Kullanıcı Adını Giriniz.");
            }
            else if (kullanicisifre.Text == "")
            {
                MessageBox.Show("Şifrenizi Giriniz.");
            }
            else
            {


                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    OleDbCommand cmd = new OleDbCommand("select * from kullanicigiris where kullaniciadi='" + kullaniciadi.Text.ToString() + "'", baglanti);
                    OleDbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read() == true)
                {
                    if (kullaniciadi.Text.ToString() == dr["kullaniciadi"].ToString() && kullanicisifre.Text.ToString() == dr["sifre"].ToString())
                    {
                        MessageBox.Show("HOŞGELDİNİZ");
                        Form form1 = new anasayfa();
                        form1.Show();
                        this.Hide();
                    }
                    else 
                    {
                        MessageBox.Show("Kullanıcıadı veya şifre yanlıştır.");
                        kullaniciadi.Clear(); kullanicisifre.Clear();
                    }
                }
           
                else 
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre yanlıştır.");
                        kullaniciadi.Clear(); kullanicisifre.Clear();
                    }
                        
                    }
            
                }

        private void timer1_Tick(object sender, EventArgs e)
        {

            this.Text = this.Text.Substring(1) + this.Text.Substring(0, 1);

            label1.Text = label1.Text.Substring(1) + label1.Text.Substring(0, 1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        }
    }

