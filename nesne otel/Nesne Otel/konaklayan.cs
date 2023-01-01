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
    public partial class konaklayan : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\otel1.mdb");
        OleDbDataAdapter da = new OleDbDataAdapter();
        OleDbCommand komut = new OleDbCommand();
        DataSet ds = new DataSet();
        private void vericek()
        {
            ds.Clear();
            komut.Connection = baglanti;
            komut.CommandText = "select tc,ad,soyad,cinsiyet,telefon,email,girist,katno,odano,odatipi,kat,birim_ucret from musteri where odano=@odano";
            komut.Parameters.AddWithValue("@odano", Convert.ToString(odaduzen.tiklanan.adi));       
            da.SelectCommand = komut;
          
            da.Fill(ds, "musteri");
        }
        public konaklayan()
        {
            InitializeComponent();
        }

        private void konaklayan_Load(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            vericek();
            dataGridView1.DataSource = ds.Tables["musteri"];
            baglanti.Close();

        }
    }
}
