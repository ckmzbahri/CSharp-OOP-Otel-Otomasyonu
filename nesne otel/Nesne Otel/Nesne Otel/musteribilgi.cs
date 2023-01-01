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
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "//otel1.mdb");
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        void musteriveri()
        {
            if (ds.Tables["musteri"] != null) ds.Tables["musteri"].Clear();
            OleDbDataAdapter da = new OleDbDataAdapter("SElect * from musteri", baglanti);
            da.Fill(ds, "musteri");
            bs.DataSource = ds.Tables["musteri"];
            dataGridView1.DataSource = bs;
        }
        public musteribilgi()
        {
            InitializeComponent();
        }

        private void tbpertc_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true) dateTimePicker2.Visible = true;
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
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                musteriveri();

            }
            else
            {
                if (rboda.Checked == false & rbad.Checked == false & rboda.Checked == false)
                {
                    MessageBox.Show("Lütfen Arama Yöntemi Seçiniz!", "uyari", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    aranan.Text = "";

                }
                else if (rbtc.Checked)
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
                if (rboda.Checked == false & rbad.Checked == false & rboda.Checked == false)
                {
                    MessageBox.Show("Lütfen Arama Yöntemi Seçiniz!", "uyari", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    aranan.Text = "";

                }
                else if (rbtc.Checked)
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

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ileri_Click(object sender, EventArgs e)
        {
            geri.Enabled = true;
            if (++bs.Position == ds.Tables["musteri"].Rows.Count - 1)
                ileri.Enabled = false;
        }

        private void geri_Click(object sender, EventArgs e)
        {
            ileri.Enabled = true;
            if (--bs.Position == 0)
                geri.Enabled = false;
        }
    }
}
