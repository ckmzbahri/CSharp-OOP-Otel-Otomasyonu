namespace Nesne_Otel
{
    partial class eskirapor
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
            this.eski_musterilerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eski_musterilerTableAdapter = new Nesne_Otel.otel1DataSetTableAdapters.eski_musterilerTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.otel1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eski_musterilerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.eski_musterilerBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Nesne_Otel.Report5.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(853, 417);
            this.reportViewer1.TabIndex = 0;
            // 
            // otel1DataSet
            // 
            this.otel1DataSet.DataSetName = "otel1DataSet";
            this.otel1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eski_musterilerBindingSource
            // 
            this.eski_musterilerBindingSource.DataMember = "eski_musteriler";
            this.eski_musterilerBindingSource.DataSource = this.otel1DataSet;
            // 
            // eski_musterilerTableAdapter
            // 
            this.eski_musterilerTableAdapter.ClearBeforeFill = true;
            // 
            // eskirapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 417);
            this.Controls.Add(this.reportViewer1);
            this.Name = "eskirapor";
            this.Text = "eskirapor";
            this.Load += new System.EventHandler(this.eskirapor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.otel1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eski_musterilerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource eski_musterilerBindingSource;
        private otel1DataSet otel1DataSet;
        private otel1DataSetTableAdapters.eski_musterilerTableAdapter eski_musterilerTableAdapter;
    }
}