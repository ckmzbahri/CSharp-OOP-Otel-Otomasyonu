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
    public partial class eskimusteri : Form
    {
        int tutindex;
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "//otel1.mdb");
    public static    DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        void eskimusteriveri()
        {
            if (ds.Tables["eski_musteriler"] != null) ds.Tables["eski_musteriler"].Clear();
            OleDbDataAdapter da = new OleDbDataAdapter("SElect * from eski_musteriler", baglanti);
            da.Fill(ds, "eski_musteriler");
            bs.DataSource = ds.Tables["eski_musteriler"];
            dataGridView1.DataSource = bs;
        }
        public eskimusteri()
        {
            InitializeComponent();
        }

        private void eskimusteri_Load(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();

            eskimusteriveri();
            bs.DataSource = ds.Tables["eski_musteriler"];
            dataGridView1.DataSource = bs;
        }

        private void geri_Click(object sender, EventArgs e)
        {
            bs.Position--;
            int tut = dataGridView1.CurrentCell.RowIndex;
            tbmustc.Text = dataGridView1.Rows[tut].Cells[0].Value.ToString();
            tbmusadi.Text = dataGridView1.Rows[tut].Cells[1].Value.ToString();
            tbmussoyadi.Text = dataGridView1.Rows[tut].Cells[2].Value.ToString();
            cbcinsiyet.Text = dataGridView1.Rows[tut].Cells[3].Value.ToString();
            tbmustel.Text = dataGridView1.Rows[tut].Cells[4].Value.ToString();
            tbmusmail.Text = dataGridView1.Rows[tut].Cells[5].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[tut].Cells[6].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[tut].Cells[7].Value.ToString();
            tbmusoda.Text = dataGridView1.Rows[tut].Cells[9].Value.ToString();
            odatipi.Text = dataGridView1.Rows[tut].Cells[10].Value.ToString();
            katno.Text = dataGridView1.Rows[tut].Cells[8].Value.ToString();

          
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void ileri_Click(object sender, EventArgs e)
        {
            bs.Position++;
            int tut = dataGridView1.CurrentCell.RowIndex;
            tbmustc.Text = dataGridView1.Rows[tut].Cells[0].Value.ToString();
            tbmusadi.Text = dataGridView1.Rows[tut].Cells[1].Value.ToString();
            tbmussoyadi.Text = dataGridView1.Rows[tut].Cells[2].Value.ToString();
            cbcinsiyet.Text = dataGridView1.Rows[tut].Cells[3].Value.ToString();
            tbmustel.Text = dataGridView1.Rows[tut].Cells[4].Value.ToString();
            tbmusmail.Text = dataGridView1.Rows[tut].Cells[5].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[tut].Cells[6].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[tut].Cells[7].Value.ToString();
            tbmusoda.Text = dataGridView1.Rows[tut].Cells[9].Value.ToString();
            odatipi.Text = dataGridView1.Rows[tut].Cells[10].Value.ToString();
            katno.Text = dataGridView1.Rows[tut].Cells[8].Value.ToString();

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int tut = int.Parse(e.RowIndex.ToString());
            tbmustc.Text = dataGridView1.Rows[tut].Cells[0].Value.ToString();
            tbmusadi.Text = dataGridView1.Rows[tut].Cells[1].Value.ToString();
            tbmussoyadi.Text = dataGridView1.Rows[tut].Cells[2].Value.ToString();
            cbcinsiyet.Text = dataGridView1.Rows[tut].Cells[3].Value.ToString();
            tbmustel.Text = dataGridView1.Rows[tut].Cells[4].Value.ToString();
            tbmusmail.Text = dataGridView1.Rows[tut].Cells[5].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[tut].Cells[6].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[tut].Cells[7].Value.ToString();
            tbmusoda.Text = dataGridView1.Rows[tut].Cells[9].Value.ToString();
            odatipi.Text = dataGridView1.Rows[tut].Cells[10].Value.ToString();
            katno.Text = dataGridView1.Rows[tut].Cells[8].Value.ToString();


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                eskimusteriveri();

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
                    OleDbDataAdapter da = new OleDbDataAdapter("Select * from eski_musteriler where tc LIKE '%" + aranan.Text + "%'", baglanti);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "eski_musteriler");
                    bs.DataSource = ds.Tables["eski_musteriler"];
                    dataGridView1.DataSource = bs;


                }
                else if (rbad.Checked)
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("SElect * from eski_musteriler where ad LIKE '%" + aranan.Text + "%'", baglanti);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "eski_musteriler");
                    bs.DataSource = ds.Tables["eski_musteriler"];
                    dataGridView1.DataSource = bs;

                }
                else if (rboda.Checked)
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("SElect * from eski_musteriler where odano LIKE '%" + aranan.Text + "%'", baglanti);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "eski_musteriler");
                    bs.DataSource = ds.Tables["eski_musteriler"];
                    dataGridView1.DataSource = bs;

                }

            }
        }

        private void aranan_TextChanged(object sender, EventArgs e)
        {
            if (aranan.Text == "")
            {
                eskimusteriveri();
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
                    //OleDbDataAdapter da = new OleDbDataAdapter("Select * from eski_musteriler where tc LIKE '%" + aranan.Text + "%'", baglanti);
                    //DataSet ds = new DataSet();
                    //da.Fill(ds, "eskimusteriler");
                    //bs.DataSource = ds.Tables["eskimusteriler"];
                    //dataGridView1.DataSource = bs;
                    string sec = "select*from eski_musteriler where tc like'%" + aranan.Text + "%'";
                    //'% kısa metin olduğu için tırnağa alıyoruz yüzde isegirlenin kelimenin hangi yerinde olursa olsun verileri getirir ekrana
                    OleDbDataAdapter da = new OleDbDataAdapter(sec, baglanti);
                    ds.Clear();
                    da.Fill(ds, "eski_musteriler");

                }
                else if (rbad.Checked)
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    //OleDbDataAdapter da = new OleDbDataAdapter("SElect * from eski_musteriler where ad LIKE '%" + aranan.Text + "%'", baglanti);
                    //DataSet ds = new DataSet();
                    //da.Fill(ds, "eskimusteriler");
                    //bs.DataSource = ds.Tables["eskimusteriler"];
                    //dataGridView1.DataSource = bs;
                    string sec = "select*from eski_musteriler where ad like'%" + aranan.Text + "%'";
                    //'% kısa metin olduğu için tırnağa alıyoruz yüzde isegirlenin kelimenin hangi yerinde olursa olsun verileri getirir ekrana
                    OleDbDataAdapter da = new OleDbDataAdapter(sec, baglanti);
                    ds.Clear();
                    da.Fill(ds, "eski_musteriler");

                }
                else if (rboda.Checked)
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    //OleDbDataAdapter da = new OleDbDataAdapter("SElect * from eski_musteriler where odano LIKE '%" + aranan.Text + "%'", baglanti);
                    //DataSet ds = new DataSet();
                    //da.Fill(ds, "eskimusteriler");
                    //bs.DataSource = ds.Tables["eskimusteriler"];
                    //dataGridView1.DataSource = bs;
                    string sec = "select*from eski_musteriler where odano like'%" + aranan.Text + "%'";
                    //'% kısa metin olduğu için tırnağa alıyoruz yüzde isegirlenin kelimenin hangi yerinde olursa olsun verileri getirir ekrana
                    OleDbDataAdapter da = new OleDbDataAdapter(sec, baglanti);
                    ds.Clear();
                    da.Fill(ds, "eski_musteriler");

                }

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form geri = new musteribilgi();
            this.Hide();
            geri.ShowDialog();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (tbmustc.Text == "" || tbmusadi.Text == "" || tbmussoyadi.Text == "" || cbcinsiyet.Text == "" || tbmustel.Text == "" || katno.Text == "" || odatipi.Text == "" || tbmusoda.Text == "" )
            {
                MessageBox.Show("Silinecek Kayıt Bulunamadı");
            }
            else
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                tutindex = bs.Position;
                DialogResult c = MessageBox.Show("Kayıtı Kalıcı Olarak Silmek İstiyor Musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {

                    string personel = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "delete from eski_musteriler  where tc='" + tbmustc.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Silindi!");    //BEN BURADA DA DATAGRİDWİEWİN ÜZERİNE GELEREK SİLİYORUM..  
                    tbmustc.Clear(); tbmusadi.Clear();
                    bs.Position = tutindex;
                    eskimusteriveri();
                    odatipi.Clear(); tbmusoda.Clear(); katno.Clear(); tbmustc.Clear(); tbmusadi.Clear(); tbmussoyadi.Clear(); tbmustel.Clear(); cbcinsiyet.Text = ""; tbmusmail.Clear(); dateTimePicker1.Value = DateTime.Now; dateTimePicker2.Value = DateTime.Now;
                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            eskirapor es = new eskirapor();
            es.Show();
        }
    }
}
