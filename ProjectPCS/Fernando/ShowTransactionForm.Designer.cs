
namespace ProjectPCS.Fernando
{
    partial class ShowTransactionForm
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTanggalAwal = new System.Windows.Forms.DateTimePicker();
            this.dtpTanggalAkhir = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTampilkan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(12, 47);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(840, 402);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tanggal Awal :";
            // 
            // dtpTanggalAwal
            // 
            this.dtpTanggalAwal.Location = new System.Drawing.Point(96, 13);
            this.dtpTanggalAwal.Name = "dtpTanggalAwal";
            this.dtpTanggalAwal.Size = new System.Drawing.Size(200, 20);
            this.dtpTanggalAwal.TabIndex = 2;
            // 
            // dtpTanggalAkhir
            // 
            this.dtpTanggalAkhir.Location = new System.Drawing.Point(407, 14);
            this.dtpTanggalAkhir.Name = "dtpTanggalAkhir";
            this.dtpTanggalAkhir.Size = new System.Drawing.Size(200, 20);
            this.dtpTanggalAkhir.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(323, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tanggal Akhir :";
            // 
            // btnTampilkan
            // 
            this.btnTampilkan.Location = new System.Drawing.Point(753, 12);
            this.btnTampilkan.Name = "btnTampilkan";
            this.btnTampilkan.Size = new System.Drawing.Size(99, 26);
            this.btnTampilkan.TabIndex = 5;
            this.btnTampilkan.Text = "Tampilkan";
            this.btnTampilkan.UseVisualStyleBackColor = true;
            this.btnTampilkan.Click += new System.EventHandler(this.btnTampilkan_Click);
            // 
            // ShowTransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 461);
            this.Controls.Add(this.btnTampilkan);
            this.Controls.Add(this.dtpTanggalAkhir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpTanggalAwal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "ShowTransactionForm";
            this.Text = "ShowTransactionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTanggalAwal;
        private System.Windows.Forms.DateTimePicker dtpTanggalAkhir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTampilkan;
    }
}