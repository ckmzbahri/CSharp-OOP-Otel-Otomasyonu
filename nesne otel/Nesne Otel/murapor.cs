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
    public partial class murapor : Form
    {
        public murapor()
        {
            InitializeComponent();
        }

        private void murapor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'otel1DataSet.mutfak' table. You can move, or remove it, as needed.
            //this.mutfakTableAdapter.Fill(this.otel1DataSet.mutfak);
            ReportDataSource rsd = new ReportDataSource("DataSet1", Form1.ds.Tables["mutfak"]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rsd);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
