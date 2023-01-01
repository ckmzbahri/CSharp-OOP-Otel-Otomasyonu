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
    public partial class kullanici : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=otel1.mdb");
        public kullanici()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (tbmevkul.Text == "" || tbmevsifre.Text == "" || tbyenikul.Text == "" || tbyenisifre.Text == "" || tbsiftekrar.Text == "")
            {
               
                    Form yeni = new anasayfa();
                    this.Hide();
                    yeni.ShowDialog();
                    this.Close();
                
            }
            
            if (tbmevkul.Text != "" || tbmevsifre.Text  != "" || tbyenikul.Text != "" || tbyenisifre.Text != "" || tbsiftekrar.Text!="" )
            {
                DialogResult c = MessageBox.Show("Bilgileri Kaydetmeden Çıkmak İstiyor Musunuz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {
                    Form yeni = new anasayfa();
                    this.Hide();
                    yeni.ShowDialog();
                    this.Close();
                }
                else
                {
                    baglanti.Open();
                    string komut = "SELECT * FROM kullanicigiris WHERE kullaniciadi='" + tbmevkul.Text + "' and sifre='" + tbmevsifre.Text + "'";
                    OleDbCommand cmd = new OleDbCommand(komut, baglanti);
                    OleDbDataReader dr;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (tbyenikul.Text != "" && tbyenisifre.Text != "")
                        {
                            if (tbyenisifre.Text != tbsiftekrar.Text)
                            {
                                MessageBox.Show(" Yeni Şifreler Uyuşmuyor");
                            }
                                if(tbmevsifre.Text== tbyenisifre.Text)
                                {
                                    MessageBox.Show("Şifreler Aynı");

                                }
                            else
                            {
                                string yenikayit = "update kullanicigiris set kullaniciadi='" + tbyenikul.Text + "', sifre='" + tbyenisifre.Text + "' WHERE kullaniciadi='" + tbmevkul.Text + "'";
                                OleDbCommand cd = new OleDbCommand(yenikayit, baglanti);
                                cd.ExecuteNonQuery();
                                MessageBox.Show("Başarıyla Kaydedildi");
                               
                            }

                        }
                        else
                            MessageBox.Show("Yeni Şifre Veya Kullanıcı Adı Giriniz");
                    }
                    else
                        MessageBox.Show("Mevcut Şifre Veya Kullanıcı Adı Yanlıştır");
                    baglanti.Close();
                }

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string komut = "SELECT * FROM kullanicigiris WHERE kullaniciadi='" + tbmevkul.Text + "' and sifre='" + tbmevsifre.Text + "'";
            OleDbCommand cmd = new OleDbCommand(komut, baglanti);
            OleDbDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (tbyenikul.Text != "" && tbyenisifre.Text != "")
                {
                    if (tbyenisifre.Text != tbsiftekrar.Text)
                    {
                        MessageBox.Show(" Yeni Şifreler Uyuşmuyor");
                    }
                    else
                    {
                        string yenikayit = "update kullanicigiris set kullaniciadi='" + tbyenikul.Text + "', sifre='" + tbyenisifre.Text + "' WHERE kullaniciadi='" + tbmevkul.Text + "'";
                        OleDbCommand cd = new OleDbCommand(yenikayit, baglanti);
                        cd.ExecuteNonQuery();
                        MessageBox.Show("Başarıyla Kaydedildi");
                        tbmevkul.Clear();
                        tbmevsifre.Clear();
                        tbyenikul.Clear();
                        tbyenisifre.Clear();
                        tbsiftekrar.Clear();
                    }
                }
                else
                    MessageBox.Show("Yeni Şifre Veya Kullanıcı Adı Giriniz");
            }
            else
                MessageBox.Show("Mevcut Şifre Veya Kullanıcı Adı Yanlıştır");
            baglanti.Close();
        }

        private void kullanici_Load(object sender, EventArgs e)
        {

        }
    }
}
