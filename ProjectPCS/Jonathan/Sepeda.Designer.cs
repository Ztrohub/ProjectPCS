
namespace ProjectPCS.Jonathan
{
    partial class Sepeda
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.summaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sepedaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aksesorisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transaksiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jaminanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvsepeda = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtsrc = new System.Windows.Forms.TextBox();
            this.cmbtipe = new System.Windows.Forms.ComboBox();
            this.cmbbrand = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.BtnInsert = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnClear = new System.Windows.Forms.Button();
            this.txtid = new System.Windows.Forms.TextBox();
            this.cmbmerk = new System.Windows.Forms.ComboBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtperjam = new System.Windows.Forms.TextBox();
            this.txtperhari = new System.Windows.Forms.TextBox();
            this.cmbtipeinput = new System.Windows.Forms.ComboBox();
            this.btnclr = new System.Windows.Forms.Button();
            this.txtunit = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.rbaktif = new System.Windows.Forms.RadioButton();
            this.rbtidakaktif = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsepeda)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.summaryToolStripMenuItem,
            this.sepedaToolStripMenuItem,
            this.aksesorisToolStripMenuItem,
            this.transaksiToolStripMenuItem,
            this.userToolStripMenuItem,
            this.jaminanToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(900, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // summaryToolStripMenuItem
            // 
            this.summaryToolStripMenuItem.Name = "summaryToolStripMenuItem";
            this.summaryToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.summaryToolStripMenuItem.Text = "Summary";
            this.summaryToolStripMenuItem.Click += new System.EventHandler(this.summaryToolStripMenuItem_Click);
            // 
            // sepedaToolStripMenuItem
            // 
            this.sepedaToolStripMenuItem.Name = "sepedaToolStripMenuItem";
            this.sepedaToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.sepedaToolStripMenuItem.Text = "Sepeda";
            this.sepedaToolStripMenuItem.Click += new System.EventHandler(this.sepedaToolStripMenuItem_Click);
            // 
            // aksesorisToolStripMenuItem
            // 
            this.aksesorisToolStripMenuItem.Name = "aksesorisToolStripMenuItem";
            this.aksesorisToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.aksesorisToolStripMenuItem.Text = "Aksesoris";
            this.aksesorisToolStripMenuItem.Click += new System.EventHandler(this.aksesorisToolStripMenuItem_Click);
            // 
            // transaksiToolStripMenuItem
            // 
            this.transaksiToolStripMenuItem.Name = "transaksiToolStripMenuItem";
            this.transaksiToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.transaksiToolStripMenuItem.Text = "Transaksi";
            this.transaksiToolStripMenuItem.Click += new System.EventHandler(this.transaksiToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.userToolStripMenuItem.Text = "User";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.userToolStripMenuItem_Click);
            // 
            // jaminanToolStripMenuItem
            // 
            this.jaminanToolStripMenuItem.Name = "jaminanToolStripMenuItem";
            this.jaminanToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.jaminanToolStripMenuItem.Text = "Jaminan";
            this.jaminanToolStripMenuItem.Click += new System.EventHandler(this.jaminanToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // dgvsepeda
            // 
            this.dgvsepeda.AllowUserToAddRows = false;
            this.dgvsepeda.AllowUserToDeleteRows = false;
            this.dgvsepeda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsepeda.Location = new System.Drawing.Point(12, 130);
            this.dgvsepeda.Name = "dgvsepeda";
            this.dgvsepeda.ReadOnly = true;
            this.dgvsepeda.RowHeadersVisible = false;
            this.dgvsepeda.RowHeadersWidth = 51;
            this.dgvsepeda.RowTemplate.Height = 24;
            this.dgvsepeda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvsepeda.Size = new System.Drawing.Size(876, 241);
            this.dgvsepeda.TabIndex = 1;
            this.dgvsepeda.DoubleClick += new System.EventHandler(this.dgvsepeda_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sepeda";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tipe :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(441, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Brand";
            // 
            // txtsrc
            // 
            this.txtsrc.Location = new System.Drawing.Point(79, 71);
            this.txtsrc.Name = "txtsrc";
            this.txtsrc.Size = new System.Drawing.Size(150, 22);
            this.txtsrc.TabIndex = 4;
            this.txtsrc.TextChanged += new System.EventHandler(this.usersearch);
            // 
            // cmbtipe
            // 
            this.cmbtipe.FormattingEnabled = true;
            this.cmbtipe.Location = new System.Drawing.Point(285, 68);
            this.cmbtipe.Name = "cmbtipe";
            this.cmbtipe.Size = new System.Drawing.Size(146, 24);
            this.cmbtipe.TabIndex = 5;
            this.cmbtipe.SelectedIndexChanged += new System.EventHandler(this.usersearch);
            // 
            // cmbbrand
            // 
            this.cmbbrand.FormattingEnabled = true;
            this.cmbbrand.Location = new System.Drawing.Point(493, 71);
            this.cmbbrand.Name = "cmbbrand";
            this.cmbbrand.Size = new System.Drawing.Size(104, 24);
            this.cmbbrand.TabIndex = 5;
            this.cmbbrand.SelectedIndexChanged += new System.EventHandler(this.usersearch);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 394);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "ID :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 425);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "Merk :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 457);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 17);
            this.label9.TabIndex = 7;
            this.label9.Text = "Unit :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(570, 391);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 17);
            this.label11.TabIndex = 7;
            this.label11.Text = "Harga perjam :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(568, 422);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 17);
            this.label12.TabIndex = 7;
            this.label12.Text = "Harga perhari :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(628, 449);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 17);
            this.label13.TabIndex = 7;
            this.label13.Text = "Tipe :";
            // 
            // BtnInsert
            // 
            this.BtnInsert.Location = new System.Drawing.Point(224, 563);
            this.BtnInsert.Name = "BtnInsert";
            this.BtnInsert.Size = new System.Drawing.Size(95, 29);
            this.BtnInsert.TabIndex = 8;
            this.BtnInsert.Text = "Insert";
            this.BtnInsert.UseVisualStyleBackColor = true;
            this.BtnInsert.Click += new System.EventHandler(this.BtnInsert_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Location = new System.Drawing.Point(325, 563);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(95, 29);
            this.BtnUpdate.TabIndex = 8;
            this.BtnUpdate.Text = "Update";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(426, 563);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(95, 29);
            this.BtnDelete.TabIndex = 8;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(527, 563);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(95, 29);
            this.BtnClear.TabIndex = 8;
            this.BtnClear.Text = "Clear";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(79, 391);
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            this.txtid.Size = new System.Drawing.Size(168, 22);
            this.txtid.TabIndex = 9;
            // 
            // cmbmerk
            // 
            this.cmbmerk.FormattingEnabled = true;
            this.cmbmerk.Location = new System.Drawing.Point(79, 425);
            this.cmbmerk.Name = "cmbmerk";
            this.cmbmerk.Size = new System.Drawing.Size(168, 24);
            this.cmbmerk.TabIndex = 10;
            this.cmbmerk.SelectedIndexChanged += new System.EventHandler(this.gantiisi);
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(79, 492);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(168, 22);
            this.txtname.TabIndex = 9;
            this.txtname.TextChanged += new System.EventHandler(this.gantiisi);
            // 
            // txtperjam
            // 
            this.txtperjam.Location = new System.Drawing.Point(678, 389);
            this.txtperjam.Name = "txtperjam";
            this.txtperjam.Size = new System.Drawing.Size(168, 22);
            this.txtperjam.TabIndex = 9;
            this.txtperjam.TextChanged += new System.EventHandler(this.gantiisi);
            // 
            // txtperhari
            // 
            this.txtperhari.Location = new System.Drawing.Point(678, 422);
            this.txtperhari.Name = "txtperhari";
            this.txtperhari.Size = new System.Drawing.Size(168, 22);
            this.txtperhari.TabIndex = 9;
            this.txtperhari.TextChanged += new System.EventHandler(this.gantiisi);
            // 
            // cmbtipeinput
            // 
            this.cmbtipeinput.FormattingEnabled = true;
            this.cmbtipeinput.Location = new System.Drawing.Point(678, 450);
            this.cmbtipeinput.Name = "cmbtipeinput";
            this.cmbtipeinput.Size = new System.Drawing.Size(168, 24);
            this.cmbtipeinput.TabIndex = 10;
            this.cmbtipeinput.SelectedIndexChanged += new System.EventHandler(this.gantiisi);
            // 
            // btnclr
            // 
            this.btnclr.Location = new System.Drawing.Point(805, 54);
            this.btnclr.Name = "btnclr";
            this.btnclr.Size = new System.Drawing.Size(70, 57);
            this.btnclr.TabIndex = 11;
            this.btnclr.Text = "Clear";
            this.btnclr.UseVisualStyleBackColor = true;
            this.btnclr.Click += new System.EventHandler(this.btnclr_Click);
            // 
            // txtunit
            // 
            this.txtunit.Location = new System.Drawing.Point(79, 457);
            this.txtunit.Name = "txtunit";
            this.txtunit.Size = new System.Drawing.Size(168, 22);
            this.txtunit.TabIndex = 9;
            this.txtunit.TextChanged += new System.EventHandler(this.gantiisi);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 492);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Name :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(616, 483);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 7;
            this.label10.Text = "Status :";
            // 
            // rbaktif
            // 
            this.rbaktif.AutoSize = true;
            this.rbaktif.Location = new System.Drawing.Point(679, 483);
            this.rbaktif.Name = "rbaktif";
            this.rbaktif.Size = new System.Drawing.Size(56, 21);
            this.rbaktif.TabIndex = 12;
            this.rbaktif.TabStop = true;
            this.rbaktif.Text = "Aktif";
            this.rbaktif.UseVisualStyleBackColor = true;
            this.rbaktif.CheckedChanged += new System.EventHandler(this.gantiisi);
            // 
            // rbtidakaktif
            // 
            this.rbtidakaktif.AutoSize = true;
            this.rbtidakaktif.Location = new System.Drawing.Point(679, 510);
            this.rbtidakaktif.Name = "rbtidakaktif";
            this.rbtidakaktif.Size = new System.Drawing.Size(95, 21);
            this.rbtidakaktif.TabIndex = 12;
            this.rbtidakaktif.TabStop = true;
            this.rbtidakaktif.Text = "Tidak Aktif";
            this.rbtidakaktif.UseVisualStyleBackColor = true;
            this.rbtidakaktif.CheckedChanged += new System.EventHandler(this.gantiisi);
            // 
            // Sepeda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 604);
            this.Controls.Add(this.rbtidakaktif);
            this.Controls.Add(this.rbaktif);
            this.Controls.Add(this.btnclr);
            this.Controls.Add(this.cmbtipeinput);
            this.Controls.Add(this.cmbmerk);
            this.Controls.Add(this.txtunit);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.txtperhari);
            this.Controls.Add(this.txtperjam);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.BtnInsert);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbbrand);
            this.Controls.Add(this.cmbtipe);
            this.Controls.Add(this.txtsrc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvsepeda);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Sepeda";
            this.Text = "Sepeda";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsepeda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem summaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sepedaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aksesorisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transaksiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jaminanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvsepeda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtsrc;
        private System.Windows.Forms.ComboBox cmbtipe;
        private System.Windows.Forms.ComboBox cmbbrand;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button BtnInsert;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.ComboBox cmbmerk;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtperjam;
        private System.Windows.Forms.TextBox txtperhari;
        private System.Windows.Forms.ComboBox cmbtipeinput;
        private System.Windows.Forms.Button btnclr;
        private System.Windows.Forms.TextBox txtunit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rbaktif;
        private System.Windows.Forms.RadioButton rbtidakaktif;
    }
}