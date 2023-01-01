namespace Nesne_Otel
{
    partial class murapor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.otel1DataSet = new Nesne_Otel.otel1DataSet();
            this.mutfakBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mutfakTableAdapter = new Nesne_Otel.otel1DataSetTableAdapters.mutfakTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.otel1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutfakBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.mutfakBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Nesne_Otel.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(746, 383);
            this.reportViewer1.TabIndex = 0;
            // 
            // otel1DataSet
            // 
            this.otel1DataSet.DataSetName = "otel1DataSet";
            this.otel1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mutfakBindingSource
            // 
            this.mutfakBindingSource.DataMember = "mutfak";
            this.mutfakBindingSource.DataSource = this.otel1DataSet;
            // 
            // mutfakTableAdapter
            // 
            this.mutfakTableAdapter.ClearBeforeFill = true;
            // 
            // murapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 383);
            this.Controls.Add(this.reportViewer1);
            this.Name = "murapor";
            this.Text = "murapor";
            this.Load += new System.EventHandler(this.murapor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.otel1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutfakBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource mutfakBindingSource;
        private otel1DataSet otel1DataSet;
        private otel1DataSetTableAdapters.mutfakTableAdapter mutfakTableAdapter;
    }
}