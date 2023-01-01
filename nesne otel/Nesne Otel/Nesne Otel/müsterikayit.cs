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
    public partial class müsterikayit : Form
    {
         OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "//otel1.mdb");
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        int tutindex;
        bool durum;
          void tctekrar()
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open(); 
        
            OleDbCommand cmd = new OleDbCommand("select * from musteri where tc=@tc",baglanti);
            cmd.Parameters.AddWithValue("@tc",tbmustc.Text);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                durum = false;
            }
            else 
            {
                durum =true;
            }
         
            
            }
          void verileri_cek()
        {
            if (ds.Tables["musteri"] != null) ds.Tables["musteri"].Clear();
            string seckomutu = "select * from musteri";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglanti);
            da.Fill(ds, "musteri");
        }
        public müsterikayit()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            tutindex = bs.Position;
            if (tbmustc.Text == "" || tbmusadi.Text == "" || tbmussoyadi.Text == "" || tbmustel.Text == "" || tbmusmail.Text == "" || tbmusfiyat.Text == "")
            {
                MessageBox.Show("Lütfen Hepsini Doldurun.");
            }

            else
            {
                tctekrar();
                if (durum == true)
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baglanti;


                    cmd.CommandText = "insert into musteri (tc,ad,soyad,cinsiyet,telefon,email,girist,cikist,odano,ücret) Values (@tc,@ad,@soyad,@cinsiyet,@telefon,@email,@girist,@cikist,@odano,@ücret)";
                    cmd.Parameters.AddWithValue("@tc", tbmustc.Text);
                    cmd.Parameters.AddWithValue("@ad", tbmusadi.Text);
                    cmd.Parameters.AddWithValue("@soyad", tbmussoyadi.Text);
                    cmd.Parameters.AddWithValue("@cinsiyet", cbcinsiyet.SelectedItem);
                    cmd.Parameters.AddWithValue("@telefon", tbmustel.Text);
                    cmd.Parameters.AddWithValue("@email", tbmusmail.Text);
                    cmd.Parameters.AddWithValue("@girist", dateTimePicker1.Value.ToString());
                    cmd.Parameters.AddWithValue("@cikist", dateTimePicker2.Value.ToString() );
                    cmd.Parameters.AddWithValue("@odano", tbmusoda.Text);
                    cmd.Parameters.AddWithValue("@ücret", tbmusfiyat.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kaydınız Yapıldı");
                    verileri_cek();
                    tbmustc.Clear(); tbmusadi.Clear(); tbmussoyadi.Clear(); tbmustel.Clear(); cbcinsiyet.SelectedIndex = 0; tbmusmail.Clear(); dateTimePicker1.Value = DateTime.Now; dateTimePicker2.Value = DateTime.Now;
                    bs.Position = tutindex;

                }
                else
                {

                    MessageBox.Show("Bu TC Kimlik Numarası Bulunmaktadır.");
                    tbmusoda.Clear(); tbmusfiyat.Clear(); tbmustc.Clear(); tbmusadi.Clear(); tbmussoyadi.Clear(); tbmustel.Clear(); cbcinsiyet.SelectedIndex = 0; tbmusmail.Clear(); dateTimePicker1.Value = DateTime.Now; dateTimePicker2.Value = DateTime.Now;

                }

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                dateTimePicker2.Visible = true;
            }
        }

        private void tbmustc_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbmustc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) //silme işlemiinide anlamıyordu backsapceini aplicodu 8 dir.
            {
                e.Handled = true;
            }

        }

        private void tbmustel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) //silme işlemiinide anlamıyordu backsapceini aplicodu 8 dir.
            {
                e.Handled = true;
            }

        }

        private void müsterikayit_Load(object sender, EventArgs e)
        {
            tbmustc.Focus();

        }

        private void tbmustc_Leave(object sender, EventArgs e)
        {
            if (tbmustc.Text.Length > 11)
            {
                MessageBox.Show(" TC Kimlik Numarası 11 Karakterden Fazla OLMAZ!");
                tbmustc.Clear();
                tbmustc.Focus();
            }
            if (tbmustc.Text.Length < 10)
            {
                MessageBox.Show(" TC Kimlik NUmarasını Lütfen 11 Karakter Olarak Giriniz.");
                tbmustc.Clear();
                tbmustc.Focus();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (tbmustc.Text != "" || tbmusadi.Text != "" || tbmussoyadi.Text != "" || cbcinsiyet.SelectedIndex != -1 || tbmustel.Text != "" || tbmusmail.Text != "")
            {
                DialogResult c = MessageBox.Show("Kaydetmeden Çıkmak İstiyor Musunuz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {
                    Form yeni = new musteribilgi();
                    this.Hide();
                    yeni.ShowDialog();
                    this.Close();
                }
              /*  else
                {
                    //kaydetme işlemeninin kodlarını yapıştır
                }*/
            }
            Form yeni1 = new musteribilgi();
            this.Hide();
            yeni1.ShowDialog();
            this.Close();
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
