using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace Nesne_Otel
{
    public partial class eskirapor : Form
    {
        public eskirapor()
        {
            InitializeComponent();
        }

        private void eskirapor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'otel1DataSet.eski_musteriler' table. You can move, or remove it, as needed.
          //  this.eski_musterilerTableAdapter.Fill(this.otel1DataSet.eski_musteriler);
            ReportDataSource rsd = new ReportDataSource("DataSet1", eskimusteri.ds.Tables["eski_musteriler"]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rsd);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
