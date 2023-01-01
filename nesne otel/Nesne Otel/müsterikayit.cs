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
using Microsoft.VisualBasic;

namespace Nesne_Otel
{
    public partial class müsterikayit : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "//otel1.mdb");
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        int tutindex;
        bool durum;
        public static int gelenkisi;
        public static int kackisilik;
        public static int kisisayisistatik;
        public static int yataksayisiistatistik;
        public static int sayacValue;
        public static int labelValue=1;
        void tctekrar()
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();

            OleDbCommand cmd = new OleDbCommand("select * from musteri where tc=@tc", baglanti);
            cmd.Parameters.AddWithValue("@tc", tbmustc.Text);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }

            baglanti.Close();
        }
        void verileri_cek()
        {

            if (ds.Tables["musteri"] != null) ds.Tables["musteri"].Clear();
            string seckomutu = "select * from musteri";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglanti);
            da.Fill(ds, "musteri");
        }
        void veri_grid()
        {

            if (ds.Tables["odalar"] != null) ds.Tables["odalar"].Clear();

            //string sec = "select oda_hangikat,oda_tipi,oda_durum,oda_numarası  from odalar where oda_durum like 'Boş' "; //VERİ TABANINDAN BOŞ OLAN ODA BİLGİLERİNİ ÇEKİYOR
            string sec = "select * from odalar";
            OleDbDataAdapter da = new OleDbDataAdapter(sec, baglanti);
            da.Fill(ds, "odalar");
        }

        public müsterikayit()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            int kayitSayac = 0;
            tutindex = bs.Position;
            if (tbmustc.Text == "" || tbmusadi.Text == "" || tbmussoyadi.Text == "" || tbmustel.Text == "" || tbmusmail.Text == "" || tbmusfiyat.Text == "")
            {
                MessageBox.Show("Lütfen Hepsini Doldurun.");
            }
            else if (tbmustc.Text.Length > 11 && tbmustc.Text.Length < 10)
            {

                MessageBox.Show(" TC Kimlik Numarası 11 Karakterden Oluşmalı");
                tbmustc.Clear();
                tbmustc.Focus();
            }


            else
            {
                tctekrar();
                if (durum == true)
                {

           
                 
                    baglanti.Open();
                    kayitDurumu.Text = (labelValue+1).ToString() + " / " + (kackisilik - sayacValue).ToString();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "insert into musteri (tc,ad,soyad,cinsiyet,telefon,email,girist,katno,odano,odatipi,kat,birim_ucret) Values (@tc,@ad,@soyad,@cinsiyet,@telefon,@email,@girist,@katno,@odano,@odatipi,@kat,@birim_ucret)";
                    cmd.Parameters.AddWithValue("@tc", tbmustc.Text);
                    cmd.Parameters.AddWithValue("@ad", tbmusadi.Text);
                    cmd.Parameters.AddWithValue("@soyad", tbmussoyadi.Text);
                    cmd.Parameters.AddWithValue("@cinsiyet", cbcinsiyet.Text);
                    cmd.Parameters.AddWithValue("@telefon", tbmustel.Text);
                    cmd.Parameters.AddWithValue("@email", tbmusmail.Text);
                    cmd.Parameters.AddWithValue("@girist", dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@katno", katno.Text);
                    cmd.Parameters.AddWithValue("@odano", tbmusoda.Text);
                    cmd.Parameters.AddWithValue("@odatipi", odatipi.Text);
                    cmd.Parameters.AddWithValue("@kat", katno.Text);
                    cmd.Parameters.AddWithValue("@birim_ucret", tbmusfiyat.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kaydınız Yapıldı");
                    baglanti.Close();
                   tbmustc.Clear(); tbmusadi.Clear(); tbmussoyadi.Clear(); tbmustel.Clear(); cbcinsiyet.Text = ""; tbmusmail.Clear(); dateTimePicker1.Value = DateTime.Now;
                   
                    labelValue = 0;
                    baglanti.Open();
                    OleDbCommand kaydetKisi = new OleDbCommand("insert into gunceltutar (odano,kisi,oda_tipi) Values (@odano,@kisi,@oda_tipi)",baglanti);
                    kaydetKisi.Parameters.AddWithValue("@odano",tbmusoda.Text);
                    kaydetKisi.Parameters.AddWithValue("@kisi", gelenkisi.ToString());
                    kaydetKisi.Parameters.AddWithValue("@oda_tipi", gelenkisi.ToString());
                    kaydetKisi.ExecuteNonQuery();
                    baglanti.Close();
                    bs.Position = tutindex;
                    if (baglanti.State == ConnectionState.Closed)
                        baglanti.Open();
                    OleDbCommand komut1 = new OleDbCommand();
                    komut1.Connection = baglanti;
                    komut1.CommandText = "update odalar set oda_durum=@durum where oda_numarası=@numarası";
                    komut1.Parameters.AddWithValue("@durum", "Dolu");
                    komut1.Parameters.AddWithValue("@numarası", tbmusoda.Text);
                    MessageBox.Show("İşlem Sonlandırıldı");
                    komut1.ExecuteNonQuery();
                    baglanti.Close();
                    veri_grid();

                    if (kayitSayac < (kackisilik - sayacValue))
                    {
                        pictureBox6.Click += new EventHandler(pictureBox6_Click);
                    }
                }

                else
                {

                    MessageBox.Show("Bu TC Kimlik Numarası Bulunmaktadır.");
                    tbmusfiyat.Clear(); odatipi.Clear(); tbmusoda.Clear(); katno.Clear(); katno.Clear(); tbmusoda.Clear(); tbmusfiyat.Clear(); tbmustc.Clear(); tbmusadi.Clear(); tbmussoyadi.Clear(); tbmustel.Clear(); cbcinsiyet.Text = ""; tbmusmail.Clear(); dateTimePicker1.Value = DateTime.Now;

                }

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

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

        private void müsterikayit_Load(object sender, EventArgs e)
        {
            tbmustc.Focus();
            veri_grid();
            dataGridView1.DataSource = ds.Tables["odalar"];
            kisisayisistatik = 0;
        }

        private void tbmustc_Leave(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (tbmustc.Text != "" || tbmusadi.Text != "" || tbmussoyadi.Text != "" || tbmusmail.Text != "")
            {
                DialogResult c = MessageBox.Show("Kaydetmeden Çıkmak İstiyor Musunuz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {
                    Form yeni = new musteribilgi();
                    this.Hide();
                    yeni.ShowDialog();
                    this.Close();
                }


            }
            else
            {
                Form yeni1 = new musteribilgi();
                this.Hide();
                yeni1.ShowDialog();
                this.Close();
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void tbmustel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) //silme işlemiinide anlamıyordu backsapceini aplicodu 8 dir.
            {
                e.Handled = true;
            }
        }

        private void tbmusfiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) //silme işlemiinide anlamıyordu backsapceini aplicodu 8 dir.
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            tbmusoda.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            odatipi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            katno.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void tbmusfiyat_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void odatipi_TextChanged(object sender, EventArgs e)
        {
            if (odatipi.Text == "Tek Kişilik")
            {
                tbmusfiyat.Text = "100";
            }
            if (odatipi.Text == "Çift Kişilik")
            {
                tbmusfiyat.Text = "150";
            }
            if (odatipi.Text == "ÜÇ Kişilik")
            {
                tbmusfiyat.Text = "250";

            }
            if (odatipi.Text == "Dört Kişilik")
            {
                tbmusfiyat.Text = "300";
            }
            if (odatipi.Text == "Suit")
            {
                tbmusfiyat.Text = "500";
            }


        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            kackisilik = 0;
            if (odatipi.Text == "Tek Kişilik") kackisilik = 1;
            if (odatipi.Text == "Çift Kişilik") kackisilik = 2;
            if (odatipi.Text == "ÜÇ Kişilik") kackisilik = 3;
            if (odatipi.Text == "Dört Kişilik") kackisilik = 4;
            if (odatipi.Text == "Suit") kackisilik = 4;
            int sayac = 0;
            baglanti.Open();
            DataTable odaSinirTable = new DataTable();
            odaSinirTable.Rows.Clear();
            OleDbCommand odaSinirCommand = new OleDbCommand("select *from musteri", baglanti);
            OleDbDataReader odaSinirReader = odaSinirCommand.ExecuteReader();
            odaSinirTable.Load(odaSinirReader);
            for (int i = 0; i < odaSinirTable.Rows.Count; i++)
            {
                if (odaSinirTable.Rows[i][8].ToString() == dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString())
                {
                    sayac++;
                }
            }
            baglanti.Close();
            sayacValue = sayac;

            if (sayac == kackisilik)
            {
                MessageBox.Show("Bu oda dolu!");
            }
            else if (sayac < kackisilik && sayac != 0)
            {
                DialogResult mesaj = MessageBox.Show("Bu odada kalan misafirlerimiz var,Devam etmek istiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo);
                if (mesaj == DialogResult.Yes)
                {
                    if (tbmusfiyat.Text != "" && tbmusoda.Text != "" && katno.Text != "" && odatipi.Text != "")
                    {
                        try
                        {
                            gelenkisi = Convert.ToInt32(Interaction.InputBox("Kişi Sayısını Giriniz", "Bilgi"));

                            if ((gelenkisi + sayac) > kackisilik)
                            {
                                MessageBox.Show("Bu odada " + (kackisilik - sayac) + " kişilik yer var..");
                            }
                            else
                            {
                                kisisayisistatik = gelenkisi;
                                yataksayisiistatistik = kackisilik;
                            }

                        }
                        catch (FormatException) { }
                        if (kisisayisistatik > 0 && kisisayisistatik <= yataksayisiistatistik)
                        {
                            /* dataGridView1.Enabled = false;
                             groupBox1.Enabled = true;
                             buttononayla.Enabled = true;
                             kscbkat.Enabled = false;
                             kscbodatipi.Enabled = false;
                             kstboda.Enabled = false;
                             buttonkayital.Enabled = false; */
                            DialogResult cevap = MessageBox.Show("Kayıt Başlasın mı ?", "Onay Kutusu", MessageBoxButtons.OKCancel);
                            if (cevap == DialogResult.OK)
                            {
                                kayitDurumu.Text = labelValue.ToString() + " / " + (kackisilik - sayacValue).ToString();
                                pictureBox6.Visible = true;
                                label10.Visible = true;
                                tbmustc.Focus();
                            }
                            else
                            {
                                MessageBox.Show("İşlem İptal Edildi");
                                this.Close();
                            }
                        }
                        else if (kisisayisistatik == 0 || kisisayisistatik < 0 || kisisayisistatik > yataksayisiistatistik) MessageBox.Show("Kişi Sayısı Hatalı");
                    }
                    else MessageBox.Show("lütfen oda seçin");
                }
            }
            else
            {
                if (tbmusfiyat.Text != "" && tbmusoda.Text != "" && katno.Text != "" && odatipi.Text != "")
                {
                    try
                    {
                        gelenkisi = Convert.ToInt32(Interaction.InputBox("Kişi Sayısını Giriniz", "Bilgi"));
                        kisisayisistatik = gelenkisi;
                        yataksayisiistatistik = kackisilik;
                    }
                    catch (FormatException) { }
                    if (kisisayisistatik > 0 && kisisayisistatik <= yataksayisiistatistik)
                    {
                        /* dataGridView1.Enabled = false;
                         groupBox1.Enabled = true;
                         buttononayla.Enabled = true;
                         kscbkat.Enabled = false;
                         kscbodatipi.Enabled = false;
                         kstboda.Enabled = false;
                         buttonkayital.Enabled = false; */
                        DialogResult cevap = MessageBox.Show("Kayıt Başlasın mı ?", "Onay Kutusu", MessageBoxButtons.OKCancel);
                        if (cevap == DialogResult.OK)
                        {
                            kayitDurumu.Text = labelValue.ToString() + " / " + (kackisilik - sayacValue).ToString();
                            pictureBox6.Visible = true;
                            label10.Visible = true;
                            tbmustc.Focus();
                        }
                        else
                        {
                            MessageBox.Show("İşlem İptal Edildi");
                            this.Close();
                        }
                    }
                    else if (kisisayisistatik == 0 || kisisayisistatik < 0 || kisisayisistatik > yataksayisiistatistik) MessageBox.Show("Kişi Sayısı Hatalı");
                }
                else MessageBox.Show("lütfen oda seçin");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
