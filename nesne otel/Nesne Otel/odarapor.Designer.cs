namespace Nesne_Otel
{
    partial class odarapor
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
            this.odaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.odaTableAdapter = new Nesne_Otel.otel1DataSetTableAdapters.odaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.otel1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.odaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.odaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Nesne_Otel.Report4.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(583, 253);
            this.reportViewer1.TabIndex = 0;
            // 
            // otel1DataSet
            // 
            this.otel1DataSet.DataSetName = "otel1DataSet";
            this.otel1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // odaBindingSource
            // 
            this.odaBindingSource.DataMember = "oda";
            this.odaBindingSource.DataSource = this.otel1DataSet;
            // 
            // odaTableAdapter
            // 
            this.odaTableAdapter.ClearBeforeFill = true;
            // 
            // odarapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 253);
            this.Controls.Add(this.reportViewer1);
            this.Name = "odarapor";
            this.Text = "odarapor";
            this.Load += new System.EventHandler(this.odarapor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.otel1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.odaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource odaBindingSource;
        private otel1DataSet otel1DataSet;
        private otel1DataSetTableAdapters.odaTableAdapter odaTableAdapter;
    }
}