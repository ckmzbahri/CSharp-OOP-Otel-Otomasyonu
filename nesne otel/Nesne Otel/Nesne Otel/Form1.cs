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
    public partial class Form1 : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "//otel1.mdb");
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        int tutindex;
        bool durum;
        void kategoritekrar()
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();

            OleDbCommand komut = new OleDbCommand("select * from kategorimutfak where kategorimutfak='" + kategori.Text + "'", baglanti);
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
        void odatekrar()
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();

            OleDbCommand komut = new OleDbCommand("select * from kategorioda where kategorioda='" + kategori.Text + "'", baglanti);
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
        void tekrarekleme()
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();

            OleDbCommand komut = new OleDbCommand("select * from mutfak where urunadi='" + urunadi.Text + "' and kategori='"+kategori.Text+"'", baglanti);
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
        void silme()
        {
 
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();

            OleDbCommand komut = new OleDbCommand("select * from mutfak where urunadi='" + urunadi.Text + "' and kategori='"+kategori.Text+"'", baglanti);
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
        void veri_mutfak()
        {
            if (ds.Tables["mutfak"] != null) ds.Tables["mutfak"].Clear();
            OleDbDataAdapter da = new OleDbDataAdapter("SElect * from mutfak", baglanti);
            da.Fill(ds, "mutfak");
            bs.DataSource = ds.Tables["mutfak"];
            dataGridView1.DataSource = bs;
        }
        void veri_oda()
        {
            if (ds.Tables["oda"] != null) ds.Tables["oda"].Clear();//verileri üstüste gelmesin diye temizliyor
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from oda", baglanti);//bağlantı yoluyla veri çekiyor
            da.Fill(ds, "oda");//doldurma işlemi yapılıyor
            bs.DataSource = ds.Tables["oda"];
            dataGridView1.DataSource = bs;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            urunadi.Focus();
            /*  if (baglanti.State == ConnectionState.Closed) baglanti.Open();


              veri_mutfak();
              bs.DataSource = ds.Tables["mutfak"];
              dataGridView1.DataSource = bs;
              urunadi.DataBindings.Add("Text", bs, "urunadi");
              kategori.DataBindings.Add("SelectedItem", bs, "kategori");
              adet.DataBindings.Add("Text", bs, "adet");
              fiyat.DataBindings.Add("Text", bs, "fiyat");
              firma.DataBindings.Add("Text", bs, "firma");
              // gelistarihi.DataBindings.Add("SelectedItem", bs, "gelistarihi");*/


        }


        private void rbmutfak_CheckedChanged(object sender, EventArgs e)
        {
            if (rbmutfak.Checked == true)
            {
                kategori.Items.Clear();
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                veri_mutfak();

                OleDbCommand cmd = new OleDbCommand("Select * from kategorimutfak", baglanti);
                OleDbDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    kategori.Items.Add(read["kategorimutfak"]);
                }


            }

        }

        private void rboda_CheckedChanged(object sender, EventArgs e)
        {
            if (rboda.Checked == true)
            {
                kategori.Items.Clear();
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                veri_oda();

                OleDbCommand cmd = new OleDbCommand("Select * from kategorioda", baglanti);
                OleDbDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    kategori.Items.Add(read["kategorioda"]);
                }


            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (rbmutfak.Checked == true)
            {
                if (urunadi.Text == "" || kategori.Text == "" || adet.Text == "" || fiyat.Text == "" || firma.Text == "")
                {
                    MessageBox.Show("Lütfen Hepsini Doldurun.");
                }

                else
                {
                    tekrarekleme();
                    if (durum == true)
                    {
                        OleDbCommand komut = new OleDbCommand();

                        komut.Connection = baglanti;
                        komut.CommandText = "insert into mutfak (urunadi,kategori,adet,fiyat,firma,gelistarihi) Values (@urunadi,@kategori,@adet,@fiyat,@firma,@gelistarihi)";
                        komut.Parameters.AddWithValue("@urunadi", urunadi.Text);
                        komut.Parameters.AddWithValue("@kategori", kategori.SelectedItem);
                        komut.Parameters.AddWithValue("@adet", adet.Text);
                        komut.Parameters.AddWithValue("@fiyat", fiyat.Text);
                        komut.Parameters.AddWithValue("@firma", firma.Text);
                        komut.Parameters.AddWithValue("@gelistarihi", gelistarihi.Value.ToString());

                        komut.ExecuteNonQuery();
                        MessageBox.Show("Kaydınız Yapıldı");
                        urunadi.Clear(); adet.Clear(); fiyat.Clear(); firma.Clear(); kategori.Text = ""; firma.Clear(); gelistarihi.Text="";
                        veri_mutfak();
                    }
                    else
                        MessageBox.Show("Aynı Ürün Mevcuttur");
                }
            }
            if (rboda.Checked == true)
            {
                if (urunadi.Text == "" || kategori.Text == "" || adet.Text == "" || fiyat.Text == "" || firma.Text == "")
                {
                    MessageBox.Show("Lütfen Hepsini Doldurun.");
                }

                else
                {



                    OleDbCommand komut = new OleDbCommand();

                    komut.Connection = baglanti;
                    komut.CommandText = "insert into oda (urunadi,kategori,adet,fiyat,firma,gelistarihi) Values (@urunadi,@kategori,@adet,@fiyat,@firma,@gelistarihi)";
                    komut.Parameters.AddWithValue("@urunadi", urunadi.Text);
                    komut.Parameters.AddWithValue("@kategori", kategori.SelectedItem);
                    komut.Parameters.AddWithValue("@adet", adet.Text);
                    komut.Parameters.AddWithValue("@fiyat", fiyat.Text);
                    komut.Parameters.AddWithValue("@firma", firma.Text);
                    komut.Parameters.AddWithValue("@gelistarihi", gelistarihi.Value.ToString());

                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kaydınız Yapıldı");
                    urunadi.Clear(); adet.Clear(); fiyat.Clear(); firma.Clear(); kategori.Text = ""; firma.Clear(); gelistarihi.Value.ToString("");
                    veri_oda();

                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            urunadi.Clear(); adet.Clear(); fiyat.Clear(); firma.Clear(); kategori.Text = ""; firma.Text=""; gelistarihi.Value = DateTime.Now;

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (rbmutfak.Checked == true)
            {
                if (urunadi.Text == "" || kategori.Text == "" || adet.Text == "" || fiyat.Text == "" || firma.Text == "")
                {
                    MessageBox.Show("Lütfen Hepsini Doldurun.");
                }

                else
                {



                    OleDbCommand komut = new OleDbCommand();

                    komut.Connection = baglanti;
                    komut.CommandText = "update mutfak set urunadi=@urunadi,kategori=@kategori,adet=@adet,fiyat=@fiyat,firma=@firma,gelistarihi=@gelistarihi where urunadi=@urunadi";
                    komut.Parameters.AddWithValue("@urunadi", urunadi.Text);
                    komut.Parameters.AddWithValue("@kategori", kategori.SelectedItem);
                    komut.Parameters.AddWithValue("@adet", adet.Text);
                    komut.Parameters.AddWithValue("@fiyat", fiyat.Text);
                    komut.Parameters.AddWithValue("@firma", firma.Text);
                    komut.Parameters.AddWithValue("@gelistarihi", gelistarihi.Value.ToString());

                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kaydınız Güncellendi");
                    urunadi.Clear(); adet.Clear(); fiyat.Clear(); firma.Clear(); kategori.Text = ""; firma.Clear(); gelistarihi.Text="";
                    veri_mutfak();

                }
            }
            if (rboda.Checked == true)
            {
                if (urunadi.Text == "" || kategori.Text == "" || adet.Text == "" || fiyat.Text == "" || firma.Text == "")
                {
                    MessageBox.Show("Lütfen Hepsini Doldurun.");
                }

                else
                {



                    OleDbCommand komut = new OleDbCommand();

                    komut.Connection = baglanti;
                    komut.CommandText = "update oda set urunadi=@urunadi,kategori=@kategori,adet=@adet,fiyat=@fiyat,firma=@firma,gelistarihi=@gelistarihi where urunadi=@urunadi";
                    komut.Parameters.AddWithValue("@urunadi", urunadi.Text);
                    komut.Parameters.AddWithValue("@kategori", kategori.SelectedItem);
                    komut.Parameters.AddWithValue("@adet", adet.Text);
                    komut.Parameters.AddWithValue("@fiyat", fiyat.Text);
                    komut.Parameters.AddWithValue("@firma", firma.Text);
                    komut.Parameters.AddWithValue("@gelistarihi", gelistarihi.Value.ToString());

                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kaydınız Güncellendi");
                    urunadi.Clear(); adet.Clear(); fiyat.Clear(); firma.Clear(); kategori.Text = ""; firma.Clear(); gelistarihi.Value.ToString("");
                    veri_oda();

                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (rbmutfak.Checked == true)
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                tutindex = bs.Position;
                DialogResult c = MessageBox.Show("Kayıtı Silmek İstiyor Musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {

                    string urunn= dataGridView1.CurrentRow.Cells["urunadi"].Value.ToString();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "delete from mutfak  where urunadi='"+urunadi.Text+"' and kategori='"+kategori.Text+"'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Silindi!");    //BEN BURADA DA DATAGRİDWİEWİN ÜZERİNE GELEREK SİLİYORUM..  
                    adet.Clear(); fiyat.Clear();
                    bs.Position = tutindex;
                    veri_mutfak();
                }
            }
            if (rboda.Checked == true)
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                tutindex = bs.Position;
                DialogResult c = MessageBox.Show("Kayıtı Silmek İstiyor Musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {

                    string urunadi = dataGridView1.CurrentRow.Cells["urunadi"].Value.ToString();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "delete from oda  where urunadi=@urunadi";
                    cmd.Parameters.AddWithValue("@urunadi", urunadi);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Silindi!");    //BEN BURADA DA DATAGRİDWİEWİN ÜZERİNE GELEREK SİLİYORUM..  
                    adet.Clear(); fiyat.Clear();
                    bs.Position = tutindex;
                    veri_oda();
                }
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form anasayfa = new anasayfa();
            this.Hide();
            anasayfa.ShowDialog();
            this.Close();
        }

        private void adet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) //silme işlemiinide anlamıyordu backsapceini aplicodu 8 dir.
            {
                e.Handled = true;
            }
        }

        private void fiyat_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) //silme işlemiinide anlamıyordu backsapceini aplicodu 8 dir.
            {
                e.Handled = true;
            }
        }

        private void aranan_TextChanged(object sender, EventArgs e)
        {
            if (rbmutfak.Checked == true)
            {
                if (aranan.Text == "")
                {
                    veri_mutfak();
                }
                else
                {

                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from mutfak where urunadi LIKE '%" + aranan.Text + "%'", baglanti);
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset, "mutfak");
                    bs.DataSource = dataset.Tables["mutfak"];
                    dataGridView1.DataSource = bs;
                }
            }
            if (rboda.Checked == true)
            {

                if (aranan.Text == "")
                {
                    veri_oda();
                }
                else
                {

                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from oda where urunadi LIKE '%" + aranan.Text + "%'", baglanti);
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset, "oda");
                    bs.DataSource = dataset.Tables["oda"];
                    dataGridView1.DataSource = bs;

                }
            }
        }

        private void yenigorev_Click(object sender, EventArgs e)
        {
            
            if (rbmutfak.Checked == true)
            {
                kategoritekrar();
                if (durum==true)
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "insert into kategorimutfak (kategorimutfak) Values (@kategorimutfak)";
                    cmd.Parameters.AddWithValue("@kategorimutfak", kategori.Text);
                    cmd.ExecuteNonQuery();
                    kategori.Items.Clear();
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    veri_mutfak();
                    OleDbCommand komut = new OleDbCommand("Select * from kategorimutfak", baglanti);
                    OleDbDataReader read = komut.ExecuteReader();
                    while (read.Read())
                    {
                        kategori.Items.Add(read["kategorimutfak"]);
                    }
                    MessageBox.Show("Kayıt Alındı!!");
                }
                else
                {
                    MessageBox.Show("Görev Zaten Ekli");
                }
            }
            if(rboda.Checked==true)
            {
                odatekrar();
                if (durum == true)
                {

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "insert into kategorioda (kategorioda) Values (@kategorioda)";
                    cmd.Parameters.AddWithValue("@kategorioda", kategori.Text);
                    cmd.ExecuteNonQuery();
                    kategori.Items.Clear();
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    veri_mutfak();
                    OleDbCommand komut = new OleDbCommand("Select * from kategorioda", baglanti);
                    OleDbDataReader read = komut.ExecuteReader();
                    while (read.Read())
                    {
                        kategori.Items.Add(read["kategorioda"]);
                    }
                    MessageBox.Show("Kayıt Alındı!!");
                }
                else
                {
                    MessageBox.Show("Görev Zaten Ekli");
                }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int tut = int.Parse(e.RowIndex.ToString());
            urunadi.Text = dataGridView1.Rows[tut].Cells[1].Value.ToString();
            kategori.Text = dataGridView1.Rows[tut].Cells[2].Value.ToString();
            adet.Text = dataGridView1.Rows[tut].Cells[3].Value.ToString();
            fiyat.Text = dataGridView1.Rows[tut].Cells[4].Value.ToString();
            firma.Text = dataGridView1.Rows[tut].Cells[5].Value.ToString();
            gelistarihi.Text = dataGridView1.Rows[tut].Cells[6].Value.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}


