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
    public partial class mrapor : Form
    {
        public mrapor()
        {
            InitializeComponent();
        }

        private void mrapor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'otel1DataSet.musteri' table. You can move, or remove it, as needed.
          //  this.musteriTableAdapter.Fill(this.otel1DataSet.musteri);
            ReportDataSource rsd = new ReportDataSource("DataSet1", musteribilgi.ds.Tables["musteri"]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rsd);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
