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
    public partial class personelkayit : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "//otel1.mdb");
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();

        bool durum;
        void tekrarekleme()
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();

            OleDbCommand komut = new OleDbCommand("select * from personel where tc='" + tbpertc.Text + "'", baglanti);
            OleDbDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }
        }
        void gorevtekrar1()
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();

            OleDbCommand cmd = new OleDbCommand("select * from gorev where gorevadi=@gorevadi", baglanti);
            cmd.Parameters.AddWithValue("@gorevadi", comboBox1.Text);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }


        }

        void veri_personel()
        {
            if (ds.Tables["personel"] != null) ds.Tables["personel"].Clear();
            OleDbDataAdapter da = new OleDbDataAdapter("SElect * from personel", baglanti);
            da.Fill(ds, "personel");
            bs.DataSource = ds.Tables["personel"];
        }
        public personelkayit()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (tbpertc.Text != "" || tbperadi.Text != "" || tbpersoyadi.Text != "" || tbperadres.Text != "" || tbperyas.Text != "")
            {
                DialogResult c = MessageBox.Show("Kaydetmeden Çıkmak İstiyor Musunuz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {
                    Form yeni = new personelbilgi();
                    this.Hide();
                    yeni.ShowDialog();
                    this.Close();
                }
                else { }
            }
            else
            {
                Form yeni1 = new personelbilgi();
                this.Hide();
                yeni1.ShowDialog();
                this.Close();
            }
        }

        private void tbpertc_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void personelkayit_Load(object sender, EventArgs e)
        {
            tbpertc.Focus();
            veri_personel();

            comboBox1.Items.Clear();
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            veri_personel();

            OleDbCommand cmd = new OleDbCommand("Select * from gorev", baglanti);
            OleDbDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                comboBox1.Items.Add(read["gorevadi"]);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            if (tbpertc.Text == "" || tbperadi.Text == "" || tbpersoyadi.Text == "" || comboBox2.SelectedIndex == -1 || tbpertel.Text == "" || tbperadres.Text == "" || comboBox1.SelectedIndex == -1 || tbperyas.Text == "")
            {
                MessageBox.Show("Lütfen Hepsini Doldurun.");
            }

            else
            {
                if (kayittarihi.Value < DateTime.Today)
                {
                    MessageBox.Show("Geçmiş Tarihe Kayıt Yapamazsınız");
                }
                else
                {
                    tekrarekleme();
                    if (durum == true)
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = baglanti;


                        cmd.CommandText = "insert into personel (tc,ad,soyad,adres,cinsiyet,yas,telefon,gorev,kayittarihi) Values (@tc,@ad,@soyad,@adres,@cinsiyet,@yas,@telefon,@gorev,@kayittarihi)";
                        cmd.Parameters.AddWithValue("@tc", tbpertc.Text);
                        cmd.Parameters.AddWithValue("@ad", tbperadi.Text);
                        cmd.Parameters.AddWithValue("@soyad", tbpersoyadi.Text);
                        cmd.Parameters.AddWithValue("@adres", tbperadres.Text);
                        cmd.Parameters.AddWithValue("@cinsiyet", comboBox2.SelectedItem);
                        cmd.Parameters.AddWithValue("@yas", tbperyas.Text);
                        cmd.Parameters.AddWithValue("@telefon", tbpertel.Text);
                        cmd.Parameters.AddWithValue("@gorev", comboBox1.SelectedItem);
                        cmd.Parameters.AddWithValue("@kayittarihi", kayittarihi.Value.ToString());


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Kayıt eklendi");
                        tbpertc.Clear(); tbperadi.Clear(); tbpersoyadi.Clear(); tbperadres.Clear(); comboBox2.Text = ""; tbperyas.Clear(); tbpertel.Clear(); comboBox1.Text = ""; kayittarihi.Value = DateTime.Now;
                    }
                    else
                        MessageBox.Show("Aynı personel mevcut");
                    tbpertc.Clear(); tbperadi.Clear(); tbpersoyadi.Clear(); tbperadres.Clear(); comboBox2.Text = ""; tbperyas.Clear(); tbpertel.Clear(); comboBox1.Text = ""; kayittarihi.Value = DateTime.Now;

                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            tbpertc.Clear(); tbperadi.Clear(); tbpersoyadi.Clear(); tbperadres.Clear(); comboBox2.Text = ""; tbperyas.Clear(); tbpertel.Clear(); comboBox1.Text = ""; kayittarihi.Value = DateTime.Now;
        }

        private void yenigorev_Click(object sender, EventArgs e)
        {
            gorevtekrar1();
            if (comboBox1.Text == "")
                MessageBox.Show("Lütfen Kayıt Etmek İstediğiniz Görevi Yazıp Tekrar Deneyin");
            else if (durum == true)
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "insert into gorev (gorevadi) Values (@gorevadi)";
                cmd.Parameters.AddWithValue("@gorevadi", comboBox1.Text);
                cmd.ExecuteNonQuery();
                comboBox1.Items.Clear();
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                veri_personel();

                OleDbCommand komut = new OleDbCommand("Select * from gorev", baglanti);
                OleDbDataReader read = komut.ExecuteReader();
                while (read.Read())
                {
                    comboBox1.Items.Add(read["gorevadi"]);
                }
                MessageBox.Show("görev eklendi");

            }
            else
            {
                MessageBox.Show("Görev Zaten Ekli");
            }
        }

        private void personelkayit_FormClosed(object sender, FormClosedEventArgs e)
        {
         
        }

        private void tbpertel_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void tbpertc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) //silme işlemiinide anlamıyordu backsapceini aplicodu 8 dir.
            {
                e.Handled = true;
            }
        }

        private void tbpertc_Leave(object sender, EventArgs e)
        {
            if (tbpertc.Text.Length > 11)
            {
                MessageBox.Show(" TC Kimlik Numarası 11 Karakterden Fazla OLMAZ!");
                tbpertc.Clear();
                tbpertc.Focus();
            }
            if (tbpertc.Text.Length < 10)
            {
                MessageBox.Show(" TC Kimlik NUmarasını Lütfen 11 Karakter Olarak Giriniz.");
                tbpertc.Clear();
                tbpertc.Focus();
            }
        }

        private void tbpertel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) //silme işlemiinide anlamıyordu backsapceini aplicodu 8 dir.
            {
                e.Handled = true;
            }
        }

        private void tbperyas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) //silme işlemiinide anlamıyordu backsapceini aplicodu 8 dir.
            {
                e.Handled = true;
            }
        }

        private void tbperyas_Leave(object sender, EventArgs e)
        {
           
        }

        private void tbpertel_Leave(object sender, EventArgs e)
        {
          
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
