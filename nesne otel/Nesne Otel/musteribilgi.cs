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
    public partial class musteribilgi : Form
    {
        string tuttc = null;
        string konrtoltc;
        bool durum;
        bool durum1;
        bool b1;
        bool b2;
        int tutindex;
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "//otel1.mdb");
      public static  DataSet ds = new DataSet();
        OleDbDataAdapter da = new OleDbDataAdapter();
        BindingSource bs = new BindingSource();
        void musteriveri()
        {
            if (ds.Tables["musteri"] != null) ds.Tables["musteri"].Clear();
            OleDbDataAdapter da = new OleDbDataAdapter("SElect * from musteri", baglanti);
            da.Fill(ds, "musteri");
            bs.DataSource = ds.Tables["musteri"];
            dataGridView1.DataSource = bs;
        }
        void tekrar()
        {
            if (tbpertc.Text != tuttc)
            {
                durum1 = false;
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                OleDbCommand cmd1 = new OleDbCommand("select * from musteri where tc=@tc", baglanti);
                cmd1.Parameters.AddWithValue("@tc", tbpertc.Text);
                OleDbDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    durum = false;
                }
                else durum = true;

            }
            else
            {
                durum1 = true;
            }


        }
        void tctekrar()
        {

        }
        public musteribilgi()
        {
            InitializeComponent();
        }
        public void griddoldur() // Form2 den erişebilmek için public olarak oluşturduk.
        {

            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            da = new OleDbDataAdapter("SElect *from musteri", baglanti);
            ds = new DataSet();

            da.Fill(ds, "musteri");
            dataGridView1.DataSource = ds.Tables["musteri"];
            baglanti.Close();

        }

        private void tbpertc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                OleDbCommand kommut = new OleDbCommand("select * from musteri", baglanti);
                OleDbDataReader dr = kommut.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["tc"].ToString() == tbpertc.Text)
                    {
                        if (konrtoltc == tbpertc.Text)
                        {
                        }
                        else
                        {
                            MessageBox.Show("Kİmlik kullanılmaktadır");
                            tbpertc.Text = konrtoltc;
                        }
                    }
                    }
                    baglanti.Close();
                }
                catch{ }
            
        }
    
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            /*  if (checkBox2.Checked == true) dateTimePicker2.Visible = true;
              else dateTimePicker2.Visible = false;*/

        }

        private void musteribilgi_Load(object sender, EventArgs e)
        {

            if (baglanti.State == ConnectionState.Closed) baglanti.Open();

            musteriveri();
            bs.DataSource = ds.Tables["musteri"];
            dataGridView1.DataSource = bs;
            /* tbpertc.DataBindings.Add("Text", bs, "tc");
             tbperadi.DataBindings.Add("Text", bs, "ad");
             tbpersoyadi.DataBindings.Add("Text", bs, "soyad");
             cbcinsiyet.DataBindings.Add("SelectedItem", bs, "cinsiyet");
             tbpertel.DataBindings.Add("Text", bs, "telefon");
             tbpermail.DataBindings.Add("Text", bs, "email");
             pictureBox1.DataBindings.Add("ImageLocation", bs, "resim");*/
            baglanti.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                musteriveri();

            }
            else
            {
                /* if (rboda.Checked == false & rbad.Checked == false & rboda.Checked == false)
                 {
                     MessageBox.Show("Lütfen Arama Yöntemi Seçiniz!", "uyari", MessageBoxButtons.OK, MessageBoxIcon.Question);
                     aranan.Text = "";

                 }*/
                if (rbtc.Checked)
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select * from musteri where tc LIKE '%" + aranan.Text + "%'", baglanti);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "musteri");
                    bs.DataSource = ds.Tables["musteri"];
                    dataGridView1.DataSource = bs;
               



                }
                else if (rbad.Checked)
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("SElect * from musteri where ad LIKE '%" + aranan.Text + "%'", baglanti);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "musteri");
                    bs.DataSource = ds.Tables["musteri"];
                    dataGridView1.DataSource = bs;

                }
                else if (rboda.Checked)
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("SElect * from musteri where odano LIKE '%" + aranan.Text + "%'", baglanti);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "musteri");
                    bs.DataSource = ds.Tables["musteri"];
                    dataGridView1.DataSource = bs;

                }

            }
        }

        private void aranan_TextChanged(object sender, EventArgs e)
        {
            if (aranan.Text == "")
            {
                musteriveri();
            }
            else
            {
                if (rbtc.Checked == false & rbad.Checked == false && rboda.Checked == false)
                {

                    MessageBox.Show("Lütfen Arama Yöntemi Seçiniz!", "uyari", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    aranan.Text = "";

                }
                else if (rbtc.Checked)
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    //OleDbDataAdapter da = new OleDbDataAdapter("Select * from musteri where tc LIKE '%" + aranan.Text + "%'", baglanti);
                    //DataSet ds = new DataSet();
                    //da.Fill(ds, "musteri");
                    //bs.DataSource = ds.Tables["musteri"];
                    //dataGridView1.DataSource = bs;
                    string sec = "select*from musteri where tc like'%" + aranan.Text + "%'";
                    //'% kısa metin olduğu için tırnağa alıyoruz yüzde isegirlenin kelimenin hangi yerinde olursa olsun verileri getirir ekrana
                    OleDbDataAdapter da = new OleDbDataAdapter(sec, baglanti);
                    ds.Clear();
                    da.Fill(ds, "musteri");

                }
                else if (rbad.Checked)
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    //OleDbDataAdapter da = new OleDbDataAdapter("SElect * from musteri where ad LIKE '%" + aranan.Text + "%'", baglanti);
                    //DataSet ds = new DataSet();
                    //da.Fill(ds, "musteri");
                    //bs.DataSource = ds.Tables["musteri"];
                    //dataGridView1.DataSource = bs;
                    string sec = "select*from musteri where ad like'%" + aranan.Text + "%'";
                    //'% kısa metin olduğu için tırnağa alıyoruz yüzde isegirlenin kelimenin hangi yerinde olursa olsun verileri getirir ekrana
                    OleDbDataAdapter da = new OleDbDataAdapter(sec, baglanti);
                    ds.Clear();
                    da.Fill(ds, "musteri");


                }
                else if (rboda.Checked)
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    //OleDbDataAdapter da = new OleDbDataAdapter("SElect * from musteri where odano LIKE '%" + aranan.Text + "%'", baglanti);
                    //DataSet ds = new DataSet();
                    //da.Fill(ds, "musteri");
                    //bs.DataSource = ds.Tables["musteri"];
                    //dataGridView1.DataSource = bs;
                    string sec = "select*from musteri where odano like'%" + aranan.Text + "%'";
                    //'% kısa metin olduğu için tırnağa alıyoruz yüzde isegirlenin kelimenin hangi yerinde olursa olsun verileri getirir ekrana
                    OleDbDataAdapter da = new OleDbDataAdapter(sec, baglanti);
                    ds.Clear();
                    da.Fill(ds, "musteri");

                }

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form anamenum = new anasayfa();
            this.Hide();
            anamenum.ShowDialog();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form bilgi = new müsterikayit();
            this.Hide();
            bilgi.ShowDialog();
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (tbpertc.Text == "" || tbperadi.Text == "" || tbpersoyadi.Text == "" || tbpertel.Text == "" || tbpermail.Text == "" || tbmusfiyat.Text == "")
            {
                MessageBox.Show("Lütfen Hepsini Doldurun.");
            }

            else
            {
                 tekrar();
                 if (durum1 == false)
                 {
                     //MessageBox.Show(durum1.ToString());
                     if (durum == true)
                     {
                         MessageBox.Show("s");
                         OleDbCommand komut = new OleDbCommand();

                         komut.Connection = baglanti;
                         komut.CommandText = "update musteri set tc=@tc,ad=@ad,soyad=@soyad,cinsiyet=@cinsiyet,telefon=@telefon,email=@email,girist=@girist,katno=@katno,odano=@odano,odatipi=@odatipi,kat=@kat,birim_ucret=@birim_ucret where tc=@tc1";
                         komut.Parameters.AddWithValue("@tc", tbpertc.Text);
                         komut.Parameters.AddWithValue("@ad", tbperadi.Text);
                         komut.Parameters.AddWithValue("@soyad", tbpersoyadi.Text);
                         komut.Parameters.AddWithValue("@cinsiyet", cbcinsiyet.SelectedItem);
                         komut.Parameters.AddWithValue("@telefon", tbpertel.Text);
                         komut.Parameters.AddWithValue("@email", tbpermail.Text);
                         komut.Parameters.AddWithValue("@girist", dateTimePicker1.Value.ToString());
                         komut.Parameters.AddWithValue("@katno", katno.Text);
                         MessageBox.Show("htjhs");
                         komut.Parameters.AddWithValue("@odano", tbmusoda.Text);
                         komut.Parameters.AddWithValue("@odatipi", odatipi.Text);
                         komut.Parameters.AddWithValue("@kat", katno.Text);
                         komut.Parameters.AddWithValue("@birim_ucret", tbmusfiyat.Text);
                         komut.Parameters.AddWithValue("@tc1", tuttc);
                         komut.ExecuteNonQuery();
                         MessageBox.Show("Kaydınız Güncellendi");
                         griddoldur();
                         tbpertc.Clear(); tbperadi.Clear(); tbpersoyadi.Clear(); tbpertel.Clear(); tbmusoda.Clear(); odatipi.Clear(); katno.Clear(); tbpermail.Clear(); dateTimePicker1.Value = DateTime.Now; katno.Clear();
                     }
                     else
                     {
                         MessageBox.Show("Aynı Tc Numarası Bulunmaktadır");
                         tbpertc.Clear();
                     }
                 }
                 else
                 {
                     OleDbCommand komut = new OleDbCommand();

                     komut.Connection = baglanti;
                     komut.CommandText = "update musteri set tc=@tc,ad=@ad,soyad=@soyad,cinsiyet=@cinsiyet,telefon=@telefon,email=@email,girist=@girist,katno=@katno,odano=@odano,odatipi=@odatipi,kat=@kat,birim_ucret=@birim_ucret where tc=@tc1";
                     komut.Parameters.AddWithValue("@tc", tbpertc.Text);
                     komut.Parameters.AddWithValue("@ad", tbperadi.Text);
                     komut.Parameters.AddWithValue("@soyad", tbpersoyadi.Text);
                     komut.Parameters.AddWithValue("@cinsiyet", cbcinsiyet.SelectedItem);
                     komut.Parameters.AddWithValue("@telefon", tbpertel.Text);
                     komut.Parameters.AddWithValue("@email", tbpermail.Text);
                     komut.Parameters.AddWithValue("@girist", dateTimePicker1.Value.ToString());
                     komut.Parameters.AddWithValue("@katno", katno.Text);
                     komut.Parameters.AddWithValue("@odano", tbmusoda.Text);
                     komut.Parameters.AddWithValue("@odatipi", odatipi.Text);
                     komut.Parameters.AddWithValue("@kat", katno.Text);
                     komut.Parameters.AddWithValue("@birim_ucret", tbmusfiyat.Text);
                     komut.Parameters.AddWithValue("@tc1", tbpertc.Text);
                     komut.ExecuteNonQuery();
                     MessageBox.Show("Kaydınız Güncellendi");
                     griddoldur();
                     tbpertc.Clear(); tbperadi.Clear(); tbpersoyadi.Clear(); tbpertel.Clear(); dateTimePicker1.Value = DateTime.Now;
                 }
             }
                
               /* baglanti.Open();
                OleDbCommand deleteCommand = new OleDbCommand("delete *from musteri where tc='" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'", baglanti);
                deleteCommand.ExecuteNonQuery();
                OleDbCommand komut = new OleDbCommand("insert into musteri (tc,ad,soyad,cinsiyet,telefon,email,girist,katno,odano,odatipi,kat,birim_ucret) Values (@tc,@ad,@soyad,@cinsiyet,@telefon,@email,@girist,@katno,@odano,@odatipi,@kat,@birim_ucret)", baglanti);
                komut.Parameters.AddWithValue("@tc", tbpertc.Text);
                komut.Parameters.AddWithValue("@ad", tbperadi.Text);
                komut.Parameters.AddWithValue("@soyad", tbpersoyadi.Text);
                komut.Parameters.AddWithValue("@cinsiyet", cbcinsiyet.SelectedItem);
                komut.Parameters.AddWithValue("@telefon", tbpertel.Text);
                komut.Parameters.AddWithValue("@email", tbpermail.Text);
                komut.Parameters.AddWithValue("@girist", dateTimePicker1.Value.ToString());
                komut.Parameters.AddWithValue("@katno", katno.Text);
                komut.Parameters.AddWithValue("@odano", tbmusoda.Text);
                komut.Parameters.AddWithValue("@odatipi", odatipi.Text);
                komut.Parameters.AddWithValue("@kat", katno.Text);
                komut.Parameters.AddWithValue("@birim_ucret", tbmusfiyat.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                musteriveri();
                griddoldur();
                dataGridView1.ClearSelection();
              //  int tut = dataGridView1.Rows.Count - 2;
               // dataGridView1.Rows[tut].Selected = true;
                MessageBox.Show("güncellendi");*/
            }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (tbpertc.Text == "" || tbperadi.Text == "" || tbpersoyadi.Text == "" || cbcinsiyet.Text == "" || tbpertel.Text == "" || katno.Text == "" || odatipi.Text == "" || tbmusoda.Text == "" || tbmusfiyat.Text == "")
            {
                MessageBox.Show("Silinecek Kayıt Bulunamadı");
            }
            else
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                tutindex = bs.Position;
                DialogResult c = MessageBox.Show("Kayıtı Silmek İstiyor Musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {

                    string personel = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "delete from musteri  where tc='" + tbpertc.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Silindi!");    //BEN BURADA DA DATAGRİDWİEWİN ÜZERİNE GELEREK SİLİYORUM..  
                    tbpertc.Clear(); tbperadi.Clear();
                    bs.Position = tutindex;
                    musteriveri();
                    tbmusfiyat.Clear(); odatipi.Clear(); tbmusoda.Clear(); katno.Clear(); tbpertc.Clear(); tbperadi.Clear(); tbpersoyadi.Clear(); tbpertel.Clear(); cbcinsiyet.Text = ""; tbpermail.Clear(); dateTimePicker1.Value = DateTime.Now;
                }
            }
        }

        private void ileri_Click(object sender, EventArgs e)
        {
            bs.Position++;
            int tut = dataGridView1.CurrentCell.RowIndex;
            tbpertc.Text = dataGridView1.Rows[tut].Cells[0].Value.ToString();
            tbperadi.Text = dataGridView1.Rows[tut].Cells[1].Value.ToString();
            tbpersoyadi.Text = dataGridView1.Rows[tut].Cells[2].Value.ToString();
            cbcinsiyet.Text = dataGridView1.Rows[tut].Cells[3].Value.ToString();
            tbpertel.Text = dataGridView1.Rows[tut].Cells[4].Value.ToString();
            tbpermail.Text = dataGridView1.Rows[tut].Cells[5].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[tut].Cells[6].Value.ToString();
            //dateTimePicker2.Text = dataGridView1.Rows[tut].Cells[7].Value.ToString();
            tbmusoda.Text = dataGridView1.Rows[tut].Cells[8].Value.ToString();
            odatipi.Text = dataGridView1.Rows[tut].Cells[9].Value.ToString();
            katno.Text = dataGridView1.Rows[tut].Cells[10].Value.ToString();
            //    tbmusfiyat.Text = dataGridView1.Rows[tut].Cells[12].Value.ToString();
        }

        private void geri_Click(object sender, EventArgs e)
        {
            bs.Position--;
            int tut = dataGridView1.CurrentCell.RowIndex;
            tbpertc.Text = dataGridView1.Rows[tut].Cells[0].Value.ToString();
            tbperadi.Text = dataGridView1.Rows[tut].Cells[1].Value.ToString();
            tbpersoyadi.Text = dataGridView1.Rows[tut].Cells[2].Value.ToString();
            cbcinsiyet.Text = dataGridView1.Rows[tut].Cells[3].Value.ToString();
            tbpertel.Text = dataGridView1.Rows[tut].Cells[4].Value.ToString();
            tbpermail.Text = dataGridView1.Rows[tut].Cells[5].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[tut].Cells[6].Value.ToString();
            // dateTimePicker2.Text = dataGridView1.Rows[tut].Cells[7].Value.ToString();
            tbmusoda.Text = dataGridView1.Rows[tut].Cells[8].Value.ToString();
            odatipi.Text = dataGridView1.Rows[tut].Cells[9].Value.ToString();
            katno.Text = dataGridView1.Rows[tut].Cells[10].Value.ToString();
            //   tbmusfiyat.Text = dataGridView1.Rows[tut].Cells[12].Value.ToString();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form oda = new odaduzen();
            this.Hide();
            oda.ShowDialog();
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbpertc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) //silme işlemiinide anlamıyordu backsapceini aplicodu 8 dir.
            {
                e.Handled = true;
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int tut = int.Parse(e.RowIndex.ToString());
            konrtoltc = dataGridView1.Rows[tut].Cells[0].Value.ToString();
            tbpertc.Text = dataGridView1.Rows[tut].Cells[0].Value.ToString();
            tbperadi.Text = dataGridView1.Rows[tut].Cells[1].Value.ToString();
            tbpersoyadi.Text = dataGridView1.Rows[tut].Cells[2].Value.ToString();
            cbcinsiyet.Text = dataGridView1.Rows[tut].Cells[3].Value.ToString();
            tbpertel.Text = dataGridView1.Rows[tut].Cells[4].Value.ToString();
            tbpermail.Text = dataGridView1.Rows[tut].Cells[5].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[tut].Cells[6].Value.ToString();
            //   dateTimePicker2.Text = dataGridView1.Rows[tut].Cells[7].Value.ToString();
            tbmusoda.Text = dataGridView1.Rows[tut].Cells[8].Value.ToString();
            odatipi.Text = dataGridView1.Rows[tut].Cells[9].Value.ToString();
            katno.Text = dataGridView1.Rows[tut].Cells[10].Value.ToString();


            tbmusfiyat.Text = dataGridView1.Rows[tut].Cells[11].Value.ToString();
            // kayittarihi.Text = dataGridView1.Rows[tut].Cells[8].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            if (tbpertc.Text == "" || tbperadi.Text == "" || tbpersoyadi.Text == "" || cbcinsiyet.Text == "" || tbpertel.Text == "" || katno.Text == "" || odatipi.Text == "" || tbmusoda.Text == "" || tbmusfiyat.Text == "")
            {
                MessageBox.Show("Çıkış Yapılacak Müşterinin Bilgilerini Seçiniz");
            }
            else
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                tutindex = bs.Position;
                DialogResult c = MessageBox.Show("Çıkış Vermek  İstiyor Musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                    OleDbCommand cm = new OleDbCommand();
                    cm.Connection = baglanti;
                    cm.CommandText = "insert into eski_musteriler (tc,ad,soyad,cinsiyet,telefon,email,girist,cikist,katno,odano,odatipi,birim_ucret) Values (@tc,@ad,@soyad,@cinsiyet,@telefon,@email,@girist,@cikist,@katno,@odano,@odatipi,@birim_ucret)";
                    cm.Parameters.AddWithValue("@tc", tbpertc.Text);
                    cm.Parameters.AddWithValue("@ad", tbperadi.Text);
                    cm.Parameters.AddWithValue("@soyad", tbpersoyadi.Text);
                    cm.Parameters.AddWithValue("@cinsiyet", cbcinsiyet.SelectedItem);
                    cm.Parameters.AddWithValue("@telefon", tbpertel.Text);
                    cm.Parameters.AddWithValue("@email", tbpermail.Text);
                    cm.Parameters.AddWithValue("@girist", dateTimePicker1.Value.ToString());
                    cm.Parameters.AddWithValue("@cikist", DateTime.Now);
                    cm.Parameters.AddWithValue("@katno", katno.Text);
                    cm.Parameters.AddWithValue("@odano", tbmusoda.Text);
                    cm.Parameters.AddWithValue("@odatipi", odatipi.Text);
                    cm.Parameters.AddWithValue("@birim_ucret", tbmusfiyat.Text);
                    cm.ExecuteNonQuery();
                    bs.Position = tutindex;
                    if (baglanti.State == ConnectionState.Closed)
                        baglanti.Open();
                    OleDbCommand komut2 = new OleDbCommand();
                    komut2.Connection = baglanti;
                    komut2.CommandText = "update odalar set oda_durum=@durum where oda_numarası=@numarası";
                    komut2.Parameters.AddWithValue("@durum", "Boş");
                    komut2.Parameters.AddWithValue("@numarası", tbmusoda.Text);
                    komut2.ExecuteNonQuery();
                    baglanti.Close();

                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                    string musteri = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
                    OleDbCommand komut1 = new OleDbCommand();
                    komut1.Connection = baglanti;
                    komut1.CommandText = "delete from musteri where tc='" + tbpertc.Text + "'";
                    komut1.ExecuteNonQuery();
                    baglanti.Close();
                    DateTime giris = DateTime.Parse(dataGridView1.CurrentRow.Cells[6].Value.ToString());
                    DateTime cikis = DateTime.UtcNow;
                    TimeSpan kalinangun = cikis - giris;
                    int odafiyati = int.Parse(tbmusfiyat.Text);
                    double aktifodafiyati = odafiyati * kalinangun.TotalDays;
                    aktifodafiyati = Math.Round(aktifodafiyati, 2);
                    int durum = DateTime.Compare(cikis, giris);
                    if (durum <= 1)
                    {
                        aktifodafiyati = odafiyati;
                    }

                    MessageBox.Show("Ödenecek Toplam Tutar=" + aktifodafiyati);

                    MessageBox.Show("Çıkış Yapıldı!");    //BEN BURADA DA DATAGRİDWİEWİN ÜZERİNE GELEREK SİLİYORUM..  
                    tbpertc.Clear(); tbperadi.Clear();
                    bs.Position = tutindex;
                    musteriveri();
                    tbmusfiyat.Clear(); odatipi.Clear(); tbmusoda.Clear(); katno.Clear(); tbpertc.Clear(); tbperadi.Clear(); tbpersoyadi.Clear(); tbpertel.Clear(); cbcinsiyet.Text = ""; tbpermail.Clear(); dateTimePicker1.Value = DateTime.Now;
                }

            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form eski = new eskimusteri();
            this.Hide();
            eski.ShowDialog();
            this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            tuttc = tbpertc.Text;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            mrapor mrp = new mrapor();
            mrp.Show();
        }

    }
}
