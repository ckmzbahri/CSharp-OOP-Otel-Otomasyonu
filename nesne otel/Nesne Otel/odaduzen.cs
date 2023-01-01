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
    public partial class odaduzen : Form
    {
        int sayac = 1;
        int sayac1 = 1;
        int sayac2 = 1;
        int x = 28;
        int y = 20;
        int lx = 40;
        int ly = 65;
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "//otel1.mdb");
         
        public static class tiklanan
        {
            public static string adi;                                           //global bir değişken tanımlayarak formlar arası veri aktarma olayı
        }
       
        private void butontiklamasi(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            tiklanan.adi = ((Button)sender).Name;
            konaklayan konak = new konaklayan();
            konak.ShowDialog();
        }
        
       
        void odaLabel(int seciliIndex, int sayac2, Label lb)
        {
            if (sayac2 < 10)
            {
                lb.Text = (seciliIndex + 1).ToString() + "0" + sayac2;
            }
            else if (sayac2 > 9 && sayac2 < 100)
            {
                lb.Text = (seciliIndex + 1).ToString() + sayac2;
            }
            else
            {
                lb.Text = "A-" + (seciliIndex + 1).ToString() + "0" + (sayac2 - 99);
            }
        }
       
        void odabuton(int seciliIndex, int sayac2, Button btn)
        {
            if (sayac2 < 10)
            {
                btn.Name = (seciliIndex + 1).ToString() + "0" + sayac2;
            }
            else if (sayac2 > 9 && sayac2 < 100)
            {
                btn.Name = (seciliIndex + 1).ToString() + sayac2;
               
            }
              
            else
            {
                btn.Name = "A-" + (seciliIndex + 1).ToString() + "0" + (sayac2 - 99);
            }
        }
        void oda()
        {
            if (tbkat.Text == "") MessageBox.Show("Kat Sayısı Girin.");
            else
            {
                int kat = int.Parse(tbkat.Text);
                if (sayac == 1)
                {
                    sayac += 1;
                    for (int i = 1; i <= kat; i++)
                    {
                        cbkat.Items.Add(i);
                        if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                        OleDbCommand komut = new OleDbCommand();

                        komut.Connection = baglanti;
                        komut.CommandText = "insert into katsayisi (kat) Values (@kat)";
                        komut.Parameters.AddWithValue("@kat", i);
                        komut.ExecuteNonQuery();
                    }
                    MessageBox.Show("katlar oluştu!");
                }
            }
        }
        public odaduzen()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (tbtek.Text != "" || tbcift.Text != "" || tbuc.Text != "" || tbdort.Text != "" || tbsuit.Text != "" || tbkat.Text != "")
            {

                DialogResult c = MessageBox.Show("Kaydetmeden Çıkmak İstiyor Musunuz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {
                    Form anamenu = new anasayfa();
                    this.Hide();
                    anamenu.ShowDialog();
                    this.Close();
                }
                else { }
            }
            else
            {
                Form anamenu = new anasayfa();
                this.Hide();
                anamenu.ShowDialog();
                this.Close();
            }
        }

        private void odaduzen_Load(object sender, EventArgs e)
        {

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();

            OleDbCommand cmd = new OleDbCommand("Select * from katsayisi", baglanti);
            OleDbDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                cbkat.Items.Add(read["kat"]);
            }
            cbkat.SelectedIndex = 0;

        }



        private void pictureBox3_Click(object sender, EventArgs e)
        {
            tbtek.Clear(); tbcift.Clear(); tbuc.Clear(); tbdort.Clear(); tbsuit.Clear(); tbkat.Clear();
            label1.Visible = false; label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false; label9.Visible = false;
            tbtek.Visible = false; tbcift.Visible = false; tbuc.Visible = false; tbdort.Visible = false; tbsuit.Visible = false; tbkat.Visible = false;
            pictureBox3.Visible = false;
            label7.Visible = false;
            btnkat.Visible = false; btntek.Visible = false; btncift.Visible = false; btnuc.Visible = false; btndort.Visible = false; btnsuit.Visible = false;
            // cbkat.Items.Clear();


        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            label1.Visible = true; label2.Visible = true; label3.Visible = true; label4.Visible = true; label5.Visible = true; label9.Visible = true;
            tbtek.Visible = true; tbcift.Visible = true; tbuc.Visible = true; tbdort.Visible = true; tbsuit.Visible = true; tbkat.Visible = true;
            pictureBox3.Visible = true;
            label7.Visible = true;
            btnkat.Visible = true; btntek.Visible = true; btncift.Visible = true; btnuc.Visible = true; btndort.Visible = true; btnsuit.Visible = true;
            sayac = 1;
            
        }

        private void tbuc_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnkat_Click(object sender, EventArgs e)
        {
            if (tbkat.Text == "")
            {
                MessageBox.Show("lütfen katsayısını girin");
            }
            else
            {
                DialogResult c = MessageBox.Show("Bütün Veriler Silinecektir Oluşturmak İstiyor Musunuz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {

                    OleDbCommand komut = new OleDbCommand("Delete * from katsayisi", baglanti);
                    OleDbCommand katSil = new OleDbCommand("Delete *from odalar", baglanti);
                    OleDbCommand musterisil = new OleDbCommand("Delete *from musteri", baglanti);
                    OleDbCommand eskimusterisil = new OleDbCommand("Delete *from eski_musteriler", baglanti);
                    OleDbCommand odarenk = new OleDbCommand("Delete *from odarenk", baglanti);
                    OleDbCommand personeller = new OleDbCommand("Delete * from personel", baglanti);
                    OleDbCommand odadolu = new OleDbCommand("Delete * from gunceltutar", baglanti);
                    musterisil.ExecuteNonQuery();
                    katSil.ExecuteNonQuery();
                    komut.ExecuteNonQuery();
                    eskimusterisil.ExecuteNonQuery();
                    odarenk.ExecuteNonQuery();
                    personeller.ExecuteNonQuery();
                    odadolu.ExecuteNonQuery();
                    sayac = 1;
                    sayac1 = 1;
                    sayac2 = 1;
                    x = 28;
                    y = 20;
                    lx = 40;
                    ly = 65;
                    this.odalar.Controls.Clear();
                    cbkat.Items.Clear();


                }

                oda();
                cbkat.SelectedIndex = 0;

            }
        }

        private void btntek_Click(object sender, EventArgs e)
        {

            if (cbkat.SelectedItem == null)
            {
                MessageBox.Show("lütfen kat seçin");
            }

            else
            {
                if (tbtek.Text == "")
                {
                    MessageBox.Show("lütfen oluşturmak istediğiniz oda sayısını girin");
                }
                else
                {

                    for (int i = 1; i <= int.Parse(tbtek.Text); i++)
                    {

                        if (sayac2 > 104)
                        {
                            MessageBox.Show("Bir Kattaki Max Oda Sayısına ULAŞTINIZ");

                            break;
                        }
                        else
                        {

                            if (baglanti.State == ConnectionState.Closed) baglanti.Open();


                            Button btn = new Button();
                            btn.BackColor = Color.Green;
                            btn.Location = new System.Drawing.Point(x, y);
                            x = x + 72;
                            odabuton(cbkat.SelectedIndex, sayac2, btn);
                      
                            btn.Size = new System.Drawing.Size(65, 45);
                            btn.Text = "";
                            btn.BackgroundImage = Properties.Resources.icons8_empty_bed_filled_100;
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                            odalar.Controls.Add(btn);
                            if (sayac1 % 13 == 0)
                            {
                                x = 28;
                                y += 70;

                            }

                            Label lb = new Label();
                            lb.Name = "odano" + i.ToString();
                            lb.Size = new Size(60, 17);
                            lb.BackColor = Color.Transparent;
                            lb.ForeColor = Color.Black;
                            lb.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                            lb.Location = new System.Drawing.Point(lx, ly);
                            lx = lx + 72;

                            odaLabel(cbkat.SelectedIndex, sayac2, lb);
                            btn.Click += new EventHandler(butontiklamasi);
                            odalar.Controls.Add(lb);

                            if (sayac1 % 13 == 0)
                            {
                                lx = 40;
                                ly += 70;
                            }

                            sayac1 += 1;
                            sayac2 += 1;
                            OleDbCommand komut = new OleDbCommand();

                            komut.Connection = baglanti;
                            komut.CommandText = "insert into odalar (oda_hangikat,oda_tipi,oda_durum,oda_numarası) Values (@oda_hangikat,@oda_tipi,@oda_durum,@oda_numarası)";
                            komut.Parameters.AddWithValue("@oda_hangikat", cbkat.SelectedItem);
                            komut.Parameters.AddWithValue("@oda_tipi", "Tek Kişilik");
                            komut.Parameters.AddWithValue("@oda_durum", "Boş");
                            komut.Parameters.AddWithValue("@oda_numarası", lb.Text);
                          
                            komut.ExecuteNonQuery();
                           


                        }

                    }

                }
                tbtek.Clear();
                MessageBox.Show("Tek Kişilik Odalar Oluşturuldu.");
            }
        }
      

        private void btncift_Click(object sender, EventArgs e)
        {

            if (cbkat.SelectedItem == null)
            {
                MessageBox.Show("lütfen kat seçin");
            }
            else
            {
                if (tbcift.Text == "")
                {
                    MessageBox.Show("lütfen oluşturmak istediğiniz oda sayısını girin");
                }
                else
                {
                    for (int i = 1; i <= int.Parse(tbcift.Text); i++)
                    {
                        if (sayac2 > 104)
                        {
                            MessageBox.Show("Bir Kattaki Max Oda Sayısına ULAŞTINIZ");

                            break;
                        }
                        else
                        {
                            if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                            /*   OleDbCommand komut = new OleDbCommand();

                               komut.Connection = baglanti;
                               komut.CommandText = "insert into odalar (oda_hangikat,oda_tipi,oda_durum) Values (@oda_hangikat,@oda_tipi,@oda_durum)";
                               komut.Parameters.AddWithValue("@oda_hangikat", cbkat.SelectedItem);
                               komut.Parameters.AddWithValue("@oda_tipi", "Çift Kişilik");
                               komut.Parameters.AddWithValue("@oda_durum", "Boş");
                               komut.ExecuteNonQuery();*/
                            Button btn = new Button();
                            btn.BackColor = Color.Green;
                            btn.Location = new System.Drawing.Point(x, y);
                            x = x + 72;
                            odabuton(cbkat.SelectedIndex, sayac2, btn);
                            btn.Size = new System.Drawing.Size(65, 45);
                            btn.Text = "";
                            btn.BackgroundImage = Properties.Resources.icons8_two_beds_filled_100;
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                            odalar.Controls.Add(btn);
                            if (sayac1 % 13 == 0)
                            {
                                x = 28;
                                y += 70;
                            }




                            Label lb = new Label();
                            lb.Name = "odano" + i.ToString();
                            // lb.AutoSize = false;
                            lb.Size = new Size(60, 17);
                            lb.BackColor = Color.Transparent;
                            lb.ForeColor = Color.Black;
                            lb.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                            lb.Location = new System.Drawing.Point(lx, ly);
                            // MessageBox.Show("oluştu");
                            lx = lx + 72;
                            odaLabel(cbkat.SelectedIndex, sayac2, lb);
                            btn.Click += new EventHandler(butontiklamasi);
                            odalar.Controls.Add(lb);

                            //tüm butonlara for döngüsüyle aynı olayı tanımlıyoruz

                            if (sayac1 % 13 == 0)
                            {
                                lx = 40;
                                ly += 70;
                            }


                            sayac1 += 1;
                            sayac2 += 1;

                            OleDbCommand kmt1 = new OleDbCommand();

                            kmt1.Connection = baglanti;
                            kmt1.CommandText = "insert into odalar (oda_hangikat,oda_tipi,oda_durum,oda_numarası) Values (@oda_hangikat,@oda_tipi,@oda_durum,@oda_numarası)";
                            kmt1.Parameters.AddWithValue("@oda_hangikat", cbkat.SelectedItem);
                            kmt1.Parameters.AddWithValue("@oda_tipi", "Çift Kişilik");
                            kmt1.Parameters.AddWithValue("@oda_durum", "Boş");
                            kmt1.Parameters.AddWithValue("@oda_numarası", lb.Text);
                            kmt1.ExecuteNonQuery();

                        }
                    }
                }
                tbcift.Clear();
                MessageBox.Show("Çift Kişilik Odalar Oluşturuldu.");

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void cbkat_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbtek.Clear(); tbcift.Clear(); tbuc.Clear(); tbdort.Clear(); tbsuit.Clear(); tbkat.Clear();
            sayac = 1;
            sayac1 = 1;
            sayac2 = 1;
            x = 28;
            y = 20;
            lx = 40;
            ly = 65;
         /*   kackisilik = 0;
            if (odatipi.Text == "Tek Kişilik") kackisilik = 1;
            if (odatipi.Text == "Çift Kişilik") kackisilik = 2;
            if (odatipi.Text == "ÜÇ Kişilik") kackisilik = 3;
            if (odatipi.Text == "Dört Kişilik") kackisilik = 4;
            if (odatipi.Text == "Suit") kackisilik = 4;*/

            string odagoster = "SELECT * FROM odalar WHERE  oda_tipi='Tek Kişilik' AND oda_hangikat=" + cbkat.Text;
            OleDbCommand olecmd = new OleDbCommand(odagoster, baglanti);
            OleDbCommand odaOku = new OleDbCommand("select * from gunceltutar");
            OleDbDataReader dataread = olecmd.ExecuteReader();
            int i = 1;
            this.odalar.Controls.Clear();

            while (dataread.Read())
            {
                Button btn = new Button();
              //  MessageBox.Show(müsterikayit.gelenkisi.ToString());
           /*     if (müsterikayit.gelenkisi == 0)
                {
                    btn.BackColor = Color.Green;
                }
                if (müsterikayit.gelenkisi == müsterikayit.kackisilik)
                {
                    btn.BackColor = Color.Red;
                }
                if (müsterikayit.gelenkisi < müsterikayit.kackisilik)
                {
                    btn.BackColor = Color.Yellow;
                }*/
                string secilen = "select oda_durum from odalar";
                   OleDbDataAdapter da = new OleDbDataAdapter(secilen, baglanti);
                   btn.BackColor = Color.Transparent;

             //    btn.BackColor = Color.Transparent;
                btn.Location = new System.Drawing.Point(x, y);
                x = x + 72;
                odabuton(cbkat.SelectedIndex, sayac2, btn);
                btn.Size = new System.Drawing.Size(65, 45);
                btn.Text = "";
                btn.BackgroundImage = Properties.Resources.icons8_empty_bed_filled_100;
                btn.BackgroundImageLayout = ImageLayout.Stretch;

                odalar.Controls.Add(btn);
                if (sayac1 % 13 == 0)
                {
                    x = 28;
                    y += 70;
                    // locsayacy += 50;
                }
                /*   locsayacx += 72;
                   locsayacy+=*/
                Label lb = new Label();
                lb.Name = "odano" + i.ToString();
                // lb.AutoSize = false;
                lb.Size = new Size(60, 17);
                lb.BackColor = Color.Transparent;
                lb.ForeColor = Color.Black;
                lb.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                lb.Location = new System.Drawing.Point(lx, ly);
                // MessageBox.Show("oluştu");
                lx = lx + 72;
                odaLabel(cbkat.SelectedIndex, sayac2, lb);
                btn.Click += new EventHandler(butontiklamasi);
                odalar.Controls.Add(lb);

                //tüm butonlara for döngüsüyle aynı olayı tanımlıyoruz

                if (sayac1 % 13 == 0)
                {
                    lx = 40;
                    ly += 70;
                }

                sayac1 += 1;
                sayac2 += 1;
                i += 1;

            }
            dataread.Close();
            string odagoster1 = "SELECT * FROM odalar WHERE  oda_tipi='Çift Kişilik' AND oda_hangikat=" + cbkat.Text;// "AND oda_tipi= 'Tek Kişilik'";
            OleDbCommand olecmd1 = new OleDbCommand(odagoster1, baglanti);
            OleDbDataReader dataread1 = olecmd1.ExecuteReader();
            int i1 = 1;
            while (dataread1.Read())
            {
                Button btn = new Button();
                btn.BackColor = Color.Transparent;
                btn.Location = new System.Drawing.Point(x, y);
                x = x + 72;
                odabuton(cbkat.SelectedIndex, sayac2, btn);
                btn.Size = new System.Drawing.Size(65, 45);
                btn.Text = "";
                btn.BackgroundImage = Properties.Resources.icons8_two_beds_filled_100;
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                odalar.Controls.Add(btn);
                if (sayac1 % 13 == 0)
                {
                    x = 28;
                    y += 70;
                    // locsayacy += 50;
                }
                /*   locsayacx += 72;
                   locsayacy+=*/
                Label lb = new Label();
                lb.Name = "odano" + i1.ToString();
                // lb.AutoSize = false;
                lb.Size = new Size(60, 17);
                lb.BackColor = Color.Transparent;
                lb.ForeColor = Color.Black;
                lb.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                lb.Location = new System.Drawing.Point(lx, ly);
                // MessageBox.Show("oluştu");
                lx = lx + 72;
                odaLabel(cbkat.SelectedIndex, sayac2, lb);
                btn.Click += new EventHandler(butontiklamasi);
                 odalar.Controls.Add(lb);

                //tüm butonlara for döngüsüyle aynı olayı tanımlıyoruz

                if (sayac1 % 13 == 0)
                {
                    lx = 40;
                    ly += 70;
                }

                sayac1 += 1;
                sayac2 += 1;
                i1 += 1;
            }


            dataread1.Close();
            string odagoster2 = "SELECT * FROM odalar WHERE  oda_tipi='Üç Kişilik' AND oda_hangikat=" + cbkat.Text;// "AND oda_tipi= 'Tek Kişilik'";
            OleDbCommand olecmd2 = new OleDbCommand(odagoster2, baglanti);
            OleDbDataReader dataread2 = olecmd2.ExecuteReader();
            int i2 = 1;
            while (dataread2.Read())
            {
                Button btn = new Button();
                btn.BackColor = Color.Transparent;
                btn.Location = new System.Drawing.Point(x, y);
                x = x + 72;
                odabuton(cbkat.SelectedIndex, sayac2, btn);
                btn.Size = new System.Drawing.Size(65, 45);
                btn.Text = "";
                btn.BackgroundImage = Properties.Resources.icons8_three_beds_filled_100;
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                odalar.Controls.Add(btn);
                if (sayac1 % 13 == 0)
                {
                    x = 28;
                    y += 70;
                    // locsayacy += 50;
                }
                /*   locsayacx += 72;
                   locsayacy+=*/
                Label lb = new Label();
                lb.Name = "odano" + i2.ToString();
                // lb.AutoSize = false;
                lb.Size = new Size(60, 17);
                lb.BackColor = Color.Transparent;
                lb.ForeColor = Color.Black;
                lb.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                lb.Location = new System.Drawing.Point(lx, ly);
                // MessageBox.Show("oluştu");
                lx = lx + 72;
                odaLabel(cbkat.SelectedIndex, sayac2, lb);
                btn.Click += new EventHandler(butontiklamasi);
                odalar.Controls.Add(lb);

                //tüm butonlara for döngüsüyle aynı olayı tanımlıyoruz

                if (sayac1 % 13 == 0)
                {
                    lx = 40;
                    ly += 70;
                }

                sayac1 += 1;
                sayac2 += 1;
                i2 += 1;
            }


            dataread2.Close();
            string odagoster3 = "SELECT * FROM odalar WHERE  oda_tipi='Dört Kişilik' AND oda_hangikat=" + cbkat.Text;
            OleDbCommand olecmd3 = new OleDbCommand(odagoster3, baglanti);
            OleDbDataReader dataread3 = olecmd3.ExecuteReader();
            int i3 = 1;
            while (dataread3.Read())
            {
                Button btn = new Button();
                btn.BackColor = Color.Transparent;
                btn.Location = new System.Drawing.Point(x, y);
                x = x + 72;
                odabuton(cbkat.SelectedIndex, sayac2, btn);
                btn.Size = new System.Drawing.Size(65, 45);
                btn.Text = "";
                btn.BackgroundImage = Properties.Resources.icons8_four_beds_filled_100;
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                odalar.Controls.Add(btn);
                if (sayac1 % 13 == 0)
                {
                    x = 28;
                    y += 70;
                }
                Label lb = new Label();
                lb.Name = "odano" + i3.ToString();
                lb.Size = new Size(60, 17);
                lb.BackColor = Color.Transparent;
                lb.ForeColor = Color.Black;
                lb.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                lb.Location = new System.Drawing.Point(lx, ly);
                lx = lx + 72;
                odaLabel(cbkat.SelectedIndex, sayac2, lb);

                btn.Click += new EventHandler(butontiklamasi);
                odalar.Controls.Add(lb);

                if (sayac1 % 13 == 0)
                {
                    lx = 40;
                    ly += 70;
                }

                sayac1 += 1;
                sayac2 += 1;
                i3 += 1;
            }


            dataread3.Close();
            string odagoster4 = "SELECT * FROM odalar WHERE  oda_tipi='Suit' AND oda_hangikat=" + cbkat.Text;
            OleDbCommand olecmd4 = new OleDbCommand(odagoster4, baglanti);
            OleDbDataReader dataread4 = olecmd4.ExecuteReader();
            int i4 = 1;
            while (dataread4.Read())
            {
                Button btn = new Button();
                btn.BackColor = Color.Transparent;
                btn.Location = new System.Drawing.Point(x, y);
                x = x + 72;
                odabuton(cbkat.SelectedIndex, sayac2, btn);
                btn.Size = new System.Drawing.Size(65, 45);
                btn.Text = "";
                btn.BackgroundImage = Properties.Resources.icons8_fairytale_filled_100;
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                odalar.Controls.Add(btn);
                if (sayac1 % 13 == 0)
                {
                    x = 28;
                    y += 70;
                    // locsayacy += 50;
                }
                /*   locsayacx += 72;
                   locsayacy+=*/
                Label lb = new Label();
                lb.Name = "odano" + i4.ToString();
                // lb.AutoSize = false;
                lb.Size = new Size(60, 17);
                lb.BackColor = Color.Transparent;
                lb.ForeColor = Color.Black;
                lb.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                lb.Location = new System.Drawing.Point(lx, ly);
                // MessageBox.Show("oluştu");
                lx = lx + 72;
                odaLabel(cbkat.SelectedIndex, sayac2, lb);
                btn.Click += new EventHandler(butontiklamasi);
                odalar.Controls.Add(lb);

                if (sayac1 % 13 == 0)
                {
                    lx = 40;
                    ly += 70;
                }

                sayac1 += 1;
                sayac2 += 1;
                i4 += 1;
            }

        }

        private void btnuc_Click(object sender, EventArgs e)
        {
            if (cbkat.SelectedItem == null)
            {
                MessageBox.Show("lütfen kat seçin");
            }
            else
            {
                if (tbuc.Text == "")
                {
                    MessageBox.Show("lütfen oluşturmak istediğiniz oda sayısını girin");
                }
                else
                {
                    for (int i = 1; i <= int.Parse(tbuc.Text); i++)
                    {
                        if (sayac2 > 104)
                        {
                            MessageBox.Show("Bir Kattaki Max Oda Sayısına ULAŞTINIZ");

                            break;
                        }
                        else
                        {
                            if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                            /*   OleDbCommand komut = new OleDbCommand();

                               komut.Connection = baglanti;
                               komut.CommandText = "insert into odalar (oda_hangikat,oda_tipi,oda_durum) Values (@oda_hangikat,@oda_tipi,@oda_durum)";
                               komut.Parameters.AddWithValue("@oda_hangikat", cbkat.SelectedItem);
                               komut.Parameters.AddWithValue("@oda_tipi", "Üç Kişilik");
                               komut.Parameters.AddWithValue("@oda_durum", "Boş");
                               komut.ExecuteNonQuery();*/
                            Button btn = new Button();
                            btn.BackColor = Color.Green;
                            btn.Location = new System.Drawing.Point(x, y);
                            x = x + 72;
                            odabuton(cbkat.SelectedIndex, sayac2, btn);
                            btn.Size = new System.Drawing.Size(65, 45);
                            btn.Text = "";
                            btn.BackgroundImage = Properties.Resources.icons8_three_beds_filled_100;
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                            odalar.Controls.Add(btn);
                            if (sayac1 % 13 == 0)
                            {
                                x = 28;
                                y += 70;
                            }




                            Label lb = new Label();
                            lb.Name = "odano" + i.ToString();
                            // lb.AutoSize = false;
                            lb.Size = new Size(60, 17);
                            lb.BackColor = Color.Transparent;
                            lb.ForeColor = Color.Black;
                            lb.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                            lb.Location = new System.Drawing.Point(lx, ly);
                            // MessageBox.Show("oluştu");
                            lx = lx + 72;
                            odaLabel(cbkat.SelectedIndex, sayac2, lb);
                            btn.Click += new EventHandler(butontiklamasi);
                            odalar.Controls.Add(lb);

                            //tüm butonlara for döngüsüyle aynı olayı tanımlıyoruz

                            if (sayac1 % 13 == 0)
                            {
                                lx = 40;
                                ly += 70;
                            }


                            sayac1 += 1;
                            sayac2 += 1;

                            OleDbCommand kmt2 = new OleDbCommand();

                            kmt2.Connection = baglanti;
                            kmt2.CommandText = "insert into odalar (oda_hangikat,oda_tipi,oda_durum,oda_numarası) Values (@oda_hangikat,@oda_tipi,@oda_durum,@oda_numarası)";
                            kmt2.Parameters.AddWithValue("@oda_hangikat", cbkat.SelectedItem);
                            kmt2.Parameters.AddWithValue("@oda_tipi", "ÜÇ Kişilik");
                            kmt2.Parameters.AddWithValue("@oda_durum", "Boş");
                            kmt2.Parameters.AddWithValue("@oda_numarası", lb.Text);
                            kmt2.ExecuteNonQuery();

                        }
                    }
                }
                tbuc.Clear();
                MessageBox.Show("Üç Kişilik Odalar Oluşturuldu.");

            }
        }

        private void btndort_Click(object sender, EventArgs e)
        {
            if (cbkat.SelectedItem == null)
            {
                MessageBox.Show("lütfen kat seçin");
            }
            else
            {
                if (tbdort.Text == "")
                {
                    MessageBox.Show("lütfen oluşturmak istediğiniz oda sayısını girin");
                }
                else
                {
                    for (int i = 1; i <= int.Parse(tbdort.Text); i++)
                    {
                        if (sayac2 > 104)
                        {
                            MessageBox.Show("Bir Kattaki Max Oda Sayısına ULAŞTINIZ");

                            break;
                        }
                        else
                        {
                            if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                            /*   OleDbCommand komut = new OleDbCommand();

                               komut.Connection = baglanti;
                               komut.CommandText = "insert into odalar (oda_hangikat,oda_tipi,oda_durum) Values (@oda_hangikat,@oda_tipi,@oda_durum)";
                               komut.Parameters.AddWithValue("@oda_hangikat", cbkat.SelectedItem);
                               komut.Parameters.AddWithValue("@oda_tipi", "Dört Kişilik");
                               komut.Parameters.AddWithValue("@oda_durum", "Boş");
                               komut.ExecuteNonQuery();*/
                            Button btn = new Button();
                            btn.BackColor = Color.Green;
                            btn.Location = new System.Drawing.Point(x, y);
                            x = x + 72;
                            odabuton(cbkat.SelectedIndex, sayac2, btn);
                            btn.Size = new System.Drawing.Size(65, 45);
                            btn.Text = "";
                            btn.BackgroundImage = Properties.Resources.icons8_four_beds_filled_100;
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                            odalar.Controls.Add(btn);
                            if (sayac1 % 13 == 0)
                            {
                                x = 28;
                                y += 70;
                            }




                            Label lb = new Label();
                            lb.Name = "odano" + i.ToString();
                            // lb.AutoSize = false;
                            lb.Size = new Size(60, 17);
                            lb.BackColor = Color.Transparent;
                            lb.ForeColor = Color.Black;
                            lb.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                            lb.Location = new System.Drawing.Point(lx, ly);
                            // MessageBox.Show("oluştu");
                            lx = lx + 72;
                            odaLabel(cbkat.SelectedIndex, sayac2, lb);
                            btn.Click += new EventHandler(butontiklamasi);
                            odalar.Controls.Add(lb);

                            //tüm butonlara for döngüsüyle aynı olayı tanımlıyoruz

                            if (sayac1 % 13 == 0)
                            {
                                lx = 40;
                                ly += 70;
                            }


                            sayac1 += 1;
                            sayac2 += 1;

                            OleDbCommand kmt3 = new OleDbCommand();

                            kmt3.Connection = baglanti;
                            kmt3.CommandText = "insert into odalar (oda_hangikat,oda_tipi,oda_durum,oda_numarası) Values (@oda_hangikat,@oda_tipi,@oda_durum,@oda_numarası)";
                            kmt3.Parameters.AddWithValue("@oda_hangikat", cbkat.SelectedItem);
                            kmt3.Parameters.AddWithValue("@oda_tipi", "Dört Kişilik");
                            kmt3.Parameters.AddWithValue("@oda_durum", "Boş");
                            kmt3.Parameters.AddWithValue("@oda_numarası", lb.Text);
                            kmt3.ExecuteNonQuery();
                        }
                    }
                }
                tbdort.Clear();
                MessageBox.Show("Dört Kişilik Odalar Oluşturuldu.");

            }
        }
        private void btnsuit_Click(object sender, EventArgs e)
        {
            if (cbkat.SelectedItem == null)
            {
                MessageBox.Show("lütfen kat seçin");
            }
            else
            {
                if (tbsuit.Text == "")
                {
                    MessageBox.Show("lütfen oluşturmak istediğiniz oda sayısını girin");
                }
                else
                {
                    for (int i = 1; i <= int.Parse(tbsuit.Text); i++)
                    {
                        if (sayac2 > 104)
                        {
                            MessageBox.Show("Bir Kattaki Max Oda Sayısına ULAŞTINIZ");

                            break;
                        }
                        else
                        {
                            if (baglanti.State == ConnectionState.Closed) baglanti.Open();


                            Button btn = new Button();
                            btn.BackColor = Color.Green;
                            btn.Location = new System.Drawing.Point(x, y);
                            x = x + 72;
                            odabuton(cbkat.SelectedIndex, sayac2, btn);
                            btn.Size = new System.Drawing.Size(65, 45);
                            btn.Text = "";
                            btn.BackgroundImage = Properties.Resources.icons8_fairytale_filled_100;
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                            btn.Click += new EventHandler(butontiklamasi);
                            odalar.Controls.Add(btn);
                            if (sayac1 % 13 == 0)
                            {
                                x = 28;
                                y += 70;
                            }




                            Label lb = new Label();
                            lb.Name = "odano" + i.ToString();
                            // lb.AutoSize = false;
                            lb.Size = new Size(60, 17);
                            lb.BackColor = Color.Transparent;
                            lb.ForeColor = Color.Black;
                            lb.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                            lb.Location = new System.Drawing.Point(lx, ly);
                            // MessageBox.Show("oluştu");
                            lx = lx + 72;
                            odaLabel(cbkat.SelectedIndex, sayac2, lb);
                            btn.Click += new EventHandler(butontiklamasi);
                            odalar.Controls.Add(lb);

                            //tüm butonlara for döngüsüyle aynı olayı tanımlıyoruz

                            if (sayac1 % 13 == 0)
                            {
                                lx = 40;
                                ly += 70;
                            }


                            sayac1 += 1;
                            sayac2 += 1;

                            OleDbCommand kmt4 = new OleDbCommand();

                            kmt4.Connection = baglanti;
                            kmt4.CommandText = "insert into odalar (oda_hangikat,oda_tipi,oda_durum,oda_numarası) Values (@oda_hangikat,@oda_tipi,@oda_durum,@oda_numarası)";
                            kmt4.Parameters.AddWithValue("@oda_hangikat", cbkat.SelectedItem);
                            kmt4.Parameters.AddWithValue("@oda_tipi", "Suit");
                            kmt4.Parameters.AddWithValue("@oda_durum", "Boş");
                            kmt4.Parameters.AddWithValue("@oda_numarası", lb.Text);
                            kmt4.ExecuteNonQuery();

                        }
                    }
                }
                tbsuit.Clear();
                MessageBox.Show("Suit Odalar Oluşturuldu.");
            }

        }

        private void odalar_Enter(object sender, EventArgs e)
        {

        }

        private void tbtek_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) //silme işlemiinide anlamıyordu backsapceini aplicodu 8 dir.
            {
                e.Handled = true;
            }
        }

        private void tbcift_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) //silme işlemiinide anlamıyordu backsapceini aplicodu 8 dir.
            {
                e.Handled = true;
            }
        }

        private void tbuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) //silme işlemiinide anlamıyordu backsapceini aplicodu 8 dir.
            {
                e.Handled = true;
            }
        }

        private void tbdort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) //silme işlemiinide anlamıyordu backsapceini aplicodu 8 dir.
            {
                e.Handled = true;
            }
        }

        private void tbsuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) //silme işlemiinide anlamıyordu backsapceini aplicodu 8 dir.
            {
                e.Handled = true;
            }
        }

        private void tbkat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) //silme işlemiinide anlamıyordu backsapceini aplicodu 8 dir.
            {
                e.Handled = true;
            }
        }
    }
}
