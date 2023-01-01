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
    public partial class personelbilgi : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "//otel1.mdb");
       public static DataSet ds = new DataSet();
        int tutindex;
        BindingSource bs = new BindingSource();
        OleDbDataAdapter da = new OleDbDataAdapter();
        string tuttc = null;

        bool durum1;
        bool durum2;

        bool durum;
        void gorevtekrar()
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
        void tekrar()
        {
            if (tbpertc.Text != tuttc)
            {
                durum2 = false;
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                OleDbCommand cmd = new OleDbCommand("select * from personel where tc=@tc", baglanti);
                cmd.Parameters.AddWithValue("@tc", tbpertc.Text);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    durum2 = false;
                }
                else durum2 = true;

            }
            else
            {
                durum1 = true;
            }


        }
        void veri_personel()
        {
            if (ds.Tables["personel"] != null) ds.Tables["personel"].Clear();
            OleDbDataAdapter da = new OleDbDataAdapter("SElect * from personel", baglanti);
            da.Fill(ds, "personel");
            bs.DataSource = ds.Tables["personel"];
            dataGridView1.DataSource = bs;
        }
        public personelbilgi()
        {
            InitializeComponent();
        }
       public void griddoldur() // Form2 den erişebilmek için public olarak oluşturduk.
        {

            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            da = new OleDbDataAdapter("SElect *from personel", baglanti);
            ds = new DataSet();

            da.Fill(ds, "personel");
            dataGridView1.DataSource = ds.Tables["personel"];

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form bilgi = new personelkayit();
            this.Hide();
            bilgi.ShowDialog();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form anamenum = new anasayfa();
            this.Hide();
            anamenum.ShowDialog();
            this.Close();
        }

        private void personelbilgi_Load(object sender, EventArgs e)
        {
            veri_personel();
            griddoldur();

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
            gorevtekrar();
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void personelara_TextChanged(object sender, EventArgs e)
        {

            if (personelara.Text == "")
            {
                veri_personel();
            }
            else
            {
                if (rbtc.Checked == false & rbgorev.Checked == false & radioButton3.Checked == false)
                {
                    MessageBox.Show("Lütfen Arama Yöntemi Seçiniz!", "uyari", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    personelara.Text = "";

                }
                else if (rbtc.Checked)
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    //OleDbDataAdapter da = new OleDbDataAdapter("Select * from personel where tc LIKE '%" + personelara.Text + "%'", baglanti);
                    //DataSet ds = new DataSet();
                    //da.Fill(ds, "personel");
                    //bs.DataSource = ds.Tables["personel"];
                    //dataGridView1.DataSource = bs;
                    string sec = "select*from personel where tc like'%" + personelara.Text + "%'";
                    //'% kısa metin olduğu için tırnağa alıyoruz yüzde isegirlenin kelimenin hangi yerinde olursa olsun verileri getirir ekrana
                    OleDbDataAdapter da = new OleDbDataAdapter(sec, baglanti);
                    ds.Clear();
                    da.Fill(ds, "personel");


                }
                else if (rbgorev.Checked)
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    //OleDbDataAdapter da = new OleDbDataAdapter("SElect * from personel where gorev LIKE '%" + personelara.Text + "%'", baglanti);
                    //DataSet ds = new DataSet();
                    //da.Fill(ds, "personel");
                    //bs.DataSource = ds.Tables["personel"];
                    //dataGridView1.DataSource = bs;
                    string sec = "select*from personel where gorev like'%" + personelara.Text + "%'";
                    //'% kısa metin olduğu için tırnağa alıyoruz yüzde isegirlenin kelimenin hangi yerinde olursa olsun verileri getirir ekrana
                    OleDbDataAdapter da = new OleDbDataAdapter(sec, baglanti);
                    ds.Clear();
                    da.Fill(ds, "personel");

                }
                else if (radioButton3.Checked)
                {
                    //if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    //OleDbDataAdapter da = new OleDbDataAdapter("SElect * from personel where ad LIKE '%" + personelara.Text + "%'", baglanti);
                    //DataSet ds = new DataSet();
                    //da.Fill(ds, "personel");
                    //bs.DataSource = ds.Tables["personel"];
                    //dataGridView1.DataSource = bs;
                    string sec = "select*from personel where ad like'%" + personelara.Text + "%'";
                    //'% kısa metin olduğu için tırnağa alıyoruz yüzde isegirlenin kelimenin hangi yerinde olursa olsun verileri getirir ekrana
                    OleDbDataAdapter da = new OleDbDataAdapter(sec, baglanti);
                    ds.Clear();
                    da.Fill(ds, "personel");

                }

            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            int secili = dataGridView1.CurrentCell.RowIndex;
            if (tbpertc.Text == "" || tbperadi.Text == "" || tbpersoyadi.Text == "" || comboBox2.Text == "" || tbpertel.Text == "" || tbperadres.Text == "" || comboBox1.Text == "" || tbperyas.Text == "")
            {
                MessageBox.Show("Lütfen Hepsini Doldurun.");
            }

            else
            {
                tekrar();
                if (durum1 == false)
                {
                    if (durum2 == true)
                    {



                        MessageBox.Show("s");
                        OleDbCommand komut = new OleDbCommand();

                        komut.Connection = baglanti;
                        komut.CommandText = "update personel set tc=@tc,ad=@ad,soyad=@soyad,cinsiyet=@cinsiyet,yas=@yas,telefon=@telefon,gorev=@gorev,kayittarihi=@kayittarihi where tc=@musteritc1";
                        komut.Parameters.AddWithValue("@tc", tbpertc.Text);
                        komut.Parameters.AddWithValue("@ad", tbperadi.Text);
                        komut.Parameters.AddWithValue("@soyad", tbpersoyadi.Text);
                        komut.Parameters.AddWithValue("@cinsiyet", comboBox2.SelectedItem);
                        komut.Parameters.AddWithValue("@yas", tbperyas.Text);
                        MessageBox.Show("htjhs");
                        komut.Parameters.AddWithValue("@telefon", tbpertel.Text);
                        komut.Parameters.AddWithValue("@gorev", comboBox1.SelectedItem);
                        komut.Parameters.AddWithValue("@kayittarihi", kayittarihi.Value.ToString());
                        komut.Parameters.AddWithValue("@musteritc1",tuttc);

                        komut.ExecuteNonQuery();
                        MessageBox.Show("Kaydınız Güncellendi");
                        griddoldur();
                        tbpertc.Clear(); tbperadi.Clear(); tbpersoyadi.Clear(); tbperadres.Clear(); comboBox2.Text = ""; tbperyas.Clear(); tbpertel.Clear(); comboBox1.Text = ""; kayittarihi.Value = DateTime.Now;
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
                    komut.CommandText = "update personel set tc=@tc,ad=@ad,soyad=@soyad,cinsiyet=@cinsiyet,yas=@yas,telefon=@telefon,gorev=@gorev,kayittarihi=@kayittarihi where tc=@musteritc1";
                    komut.Parameters.AddWithValue("@tc", tbpertc.Text);
                    komut.Parameters.AddWithValue("@ad", tbperadi.Text);
                    komut.Parameters.AddWithValue("@soyad", tbpersoyadi.Text);
                    komut.Parameters.AddWithValue("@cinsiyet", comboBox2.SelectedItem);
                    komut.Parameters.AddWithValue("@yas", tbperyas.Text);
                    komut.Parameters.AddWithValue("@telefon", tbpertel.Text);
                    komut.Parameters.AddWithValue("@gorev", comboBox1.SelectedItem);
                    komut.Parameters.AddWithValue("@kayittarihi", kayittarihi.Value.ToString());
                    komut.Parameters.AddWithValue("@musteritc1", tuttc);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kaydınız Güncellendi");
                    griddoldur();
                    tbpertc.Clear(); tbperadi.Clear(); tbpersoyadi.Clear(); tbperadres.Clear(); comboBox2.Text = ""; tbperyas.Clear(); tbpertel.Clear(); comboBox1.Text = ""; kayittarihi.Value = DateTime.Now;
                   
                }
               
            }
            dataGridView1.Rows[secili].Selected = true;
        }


        private void tbperadres_TextChanged(object sender, EventArgs e)
        {

        }

        private void kayittarihi_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (tbpertc.Text == "" || tbperadi.Text == "" || tbpersoyadi.Text == "" || comboBox2.Text == "" || tbpertel.Text == "" || tbperadres.Text == "" || comboBox1.Text == "" || tbperyas.Text == "")
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
                    cmd.CommandText = "delete from personel  where tc='" + tbpertc.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Silindi!");    //BEN BURADA DA DATAGRİDWİEWİN ÜZERİNE GELEREK SİLİYORUM..  
                    tbpertc.Clear(); tbperadi.Clear();
                    bs.Position = tutindex;
                    veri_personel();
                    tbpertc.Clear(); tbperadi.Clear(); tbpersoyadi.Clear(); tbperadres.Clear(); comboBox2.Text = ""; tbperyas.Clear(); tbpertel.Clear(); comboBox1.Text = ""; kayittarihi.Value = DateTime.Now;
                }
            }
        }
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void rbgorev_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int tut = int.Parse(e.RowIndex.ToString());
            tbpertc.Text = dataGridView1.Rows[tut].Cells[0].Value.ToString();
            tbperadi.Text = dataGridView1.Rows[tut].Cells[1].Value.ToString();
            tbpersoyadi.Text = dataGridView1.Rows[tut].Cells[2].Value.ToString();
            tbperadres.Text = dataGridView1.Rows[tut].Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[tut].Cells[4].Value.ToString();
            tbperyas.Text = dataGridView1.Rows[tut].Cells[5].Value.ToString();
            tbpertel.Text = dataGridView1.Rows[tut].Cells[6].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[tut].Cells[7].Value.ToString();
            kayittarihi.Text = dataGridView1.Rows[tut].Cells[8].Value.ToString();
            tuttc = tbpertc.Text = dataGridView1.Rows[tut].Cells[0].Value.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                veri_personel();

            }
            else
            {
                /*  if (rbtc.Checked == false & rbgorev.Checked == false & radioButton3.Checked == false)
                  {
                      MessageBox.Show("Lütfen Arama Yöntemi Seçiniz!", "uyari", MessageBoxButtons.OK, MessageBoxIcon.Question);
                      personelara.Text = "";

                  }*/
                if (rbtc.Checked)
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select * from personel where tc LIKE '%" + personelara.Text + "%'", baglanti);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "personel");
                    bs.DataSource = ds.Tables["personel"];
                    dataGridView1.DataSource = bs;


                }
                else if (rbgorev.Checked)
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("SElect * from personel where gorev LIKE '%" + personelara.Text + "%'", baglanti);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "personel");
                    bs.DataSource = ds.Tables["personel"];
                    dataGridView1.DataSource = bs;

                }
                else if (radioButton3.Checked)
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("SElect * from personel where ad LIKE '%" + personelara.Text + "%'", baglanti);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "personel");
                    bs.DataSource = ds.Tables["personel"];
                    dataGridView1.DataSource = bs;

                }

            }
        }


        private void pictureBox7_Click(object sender, EventArgs e)
        {
            bs.Position--;
            int tut = dataGridView1.CurrentCell.RowIndex;
            tbpertc.Text = dataGridView1.Rows[tut].Cells[0].Value.ToString();
            tbperadi.Text = dataGridView1.Rows[tut].Cells[1].Value.ToString();
            tbpersoyadi.Text = dataGridView1.Rows[tut].Cells[2].Value.ToString();
            tbperadres.Text = dataGridView1.Rows[tut].Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[tut].Cells[4].Value.ToString();
            tbperyas.Text = dataGridView1.Rows[tut].Cells[5].Value.ToString();
            tbpertel.Text = dataGridView1.Rows[tut].Cells[6].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[tut].Cells[7].Value.ToString();
            kayittarihi.Text = dataGridView1.Rows[tut].Cells[8].Value.ToString();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            bs.Position++;
            int tut2 = dataGridView1.CurrentCell.RowIndex;
            tbpertc.Text = dataGridView1.Rows[tut2].Cells[0].Value.ToString();
            tbperadi.Text = dataGridView1.Rows[tut2].Cells[1].Value.ToString();
            tbpersoyadi.Text = dataGridView1.Rows[tut2].Cells[2].Value.ToString();
            tbperadres.Text = dataGridView1.Rows[tut2].Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[tut2].Cells[4].Value.ToString();
            tbperyas.Text = dataGridView1.Rows[tut2].Cells[5].Value.ToString();
            tbpertel.Text = dataGridView1.Rows[tut2].Cells[6].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[tut2].Cells[7].Value.ToString();
            kayittarihi.Text = dataGridView1.Rows[tut2].Cells[8].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            tuttc = tbpertc.Text;
        }

        private void dataGridView1_RowHeaderCellChanged(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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
          
        }

        private void tbperyas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) //silme işlemiinide anlamıyordu backsapceini aplicodu 8 dir.
            {
                e.Handled = true;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            rapor rp = new rapor();
            rp.Show();
            
        }
    }
}

