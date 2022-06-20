
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
            this.rbaktif = new System.Windows.Forms.RadioButton();
            this.rbtidakaktif = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(749, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // summaryToolStripMenuItem
            // 
            this.summaryToolStripMenuItem.Name = "summaryToolStripMenuItem";
            this.summaryToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.summaryToolStripMenuItem.Text = "Summary";
            this.summaryToolStripMenuItem.Click += new System.EventHandler(this.summaryToolStripMenuItem_Click);
            // 
            // sepedaToolStripMenuItem
            // 
            this.sepedaToolStripMenuItem.Name = "sepedaToolStripMenuItem";
            this.sepedaToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.sepedaToolStripMenuItem.Text = "Sepeda";
            this.sepedaToolStripMenuItem.Click += new System.EventHandler(this.sepedaToolStripMenuItem_Click);
            // 
            // aksesorisToolStripMenuItem
            // 
            this.aksesorisToolStripMenuItem.Name = "aksesorisToolStripMenuItem";
            this.aksesorisToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.aksesorisToolStripMenuItem.Text = "Aksesoris";
            this.aksesorisToolStripMenuItem.Click += new System.EventHandler(this.aksesorisToolStripMenuItem_Click);
            // 
            // transaksiToolStripMenuItem
            // 
            this.transaksiToolStripMenuItem.Name = "transaksiToolStripMenuItem";
            this.transaksiToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.transaksiToolStripMenuItem.Text = "Transaksi";
            this.transaksiToolStripMenuItem.Click += new System.EventHandler(this.transaksiToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.userToolStripMenuItem.Text = "User";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.userToolStripMenuItem_Click);
            // 
            // jaminanToolStripMenuItem
            // 
            this.jaminanToolStripMenuItem.Name = "jaminanToolStripMenuItem";
            this.jaminanToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.jaminanToolStripMenuItem.Text = "Jaminan";
            this.jaminanToolStripMenuItem.Click += new System.EventHandler(this.jaminanToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // dgvsepeda
            // 
            this.dgvsepeda.AllowUserToAddRows = false;
            this.dgvsepeda.AllowUserToDeleteRows = false;
            this.dgvsepeda.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.dgvsepeda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsepeda.Location = new System.Drawing.Point(9, 116);
            this.dgvsepeda.Margin = new System.Windows.Forms.Padding(2);
            this.dgvsepeda.Name = "dgvsepeda";
            this.dgvsepeda.ReadOnly = true;
            this.dgvsepeda.RowHeadersVisible = false;
            this.dgvsepeda.RowHeadersWidth = 51;
            this.dgvsepeda.RowTemplate.Height = 24;
            this.dgvsepeda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvsepeda.Size = new System.Drawing.Size(731, 196);
            this.dgvsepeda.TabIndex = 1;
            this.dgvsepeda.DoubleClick += new System.EventHandler(this.dgvsepeda_DoubleClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sepeda";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search :";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(227, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tipe :";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(408, 77);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Brand";
            // 
            // txtsrc
            // 
            this.txtsrc.Location = new System.Drawing.Point(94, 75);
            this.txtsrc.Margin = new System.Windows.Forms.Padding(2);
            this.txtsrc.Name = "txtsrc";
            this.txtsrc.Size = new System.Drawing.Size(126, 20);
            this.txtsrc.TabIndex = 4;
            this.txtsrc.TextChanged += new System.EventHandler(this.usersearch);
            // 
            // cmbtipe
            // 
            this.cmbtipe.FormattingEnabled = true;
            this.cmbtipe.Location = new System.Drawing.Point(275, 75);
            this.cmbtipe.Margin = new System.Windows.Forms.Padding(2);
            this.cmbtipe.Name = "cmbtipe";
            this.cmbtipe.Size = new System.Drawing.Size(126, 21);
            this.cmbtipe.TabIndex = 5;
            this.cmbtipe.SelectedIndexChanged += new System.EventHandler(this.usersearch);
            // 
            // cmbbrand
            // 
            this.cmbbrand.FormattingEnabled = true;
            this.cmbbrand.Location = new System.Drawing.Point(466, 75);
            this.cmbbrand.Margin = new System.Windows.Forms.Padding(2);
            this.cmbbrand.Name = "cmbbrand";
            this.cmbbrand.Size = new System.Drawing.Size(126, 21);
            this.cmbbrand.TabIndex = 5;
            this.cmbbrand.SelectedIndexChanged += new System.EventHandler(this.usersearch);
            // 
            // BtnInsert
            // 
            this.BtnInsert.Location = new System.Drawing.Point(621, 462);
            this.BtnInsert.Margin = new System.Windows.Forms.Padding(2);
            this.BtnInsert.Name = "BtnInsert";
            this.BtnInsert.Size = new System.Drawing.Size(92, 34);
            this.BtnInsert.TabIndex = 8;
            this.BtnInsert.Text = "Insert";
            this.BtnInsert.UseVisualStyleBackColor = true;
            this.BtnInsert.Click += new System.EventHandler(this.BtnInsert_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Location = new System.Drawing.Point(525, 462);
            this.BtnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(92, 34);
            this.BtnUpdate.TabIndex = 8;
            this.BtnUpdate.Text = "Update";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(429, 462);
            this.BtnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(92, 34);
            this.BtnDelete.TabIndex = 8;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(32, 462);
            this.BtnClear.Margin = new System.Windows.Forms.Padding(2);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(92, 34);
            this.BtnClear.TabIndex = 8;
            this.BtnClear.Text = "Clear";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(117, 331);
            this.txtid.Margin = new System.Windows.Forms.Padding(2);
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            this.txtid.Size = new System.Drawing.Size(155, 20);
            this.txtid.TabIndex = 9;
            // 
            // cmbmerk
            // 
            this.cmbmerk.FormattingEnabled = true;
            this.cmbmerk.Location = new System.Drawing.Point(117, 357);
            this.cmbmerk.Margin = new System.Windows.Forms.Padding(2);
            this.cmbmerk.Name = "cmbmerk";
            this.cmbmerk.Size = new System.Drawing.Size(155, 21);
            this.cmbmerk.TabIndex = 10;
            this.cmbmerk.SelectedIndexChanged += new System.EventHandler(this.gantiisi);
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(117, 408);
            this.txtname.Margin = new System.Windows.Forms.Padding(2);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(155, 20);
            this.txtname.TabIndex = 9;
            this.txtname.TextChanged += new System.EventHandler(this.gantiisi);
            // 
            // txtperjam
            // 
            this.txtperjam.Location = new System.Drawing.Point(558, 331);
            this.txtperjam.Margin = new System.Windows.Forms.Padding(2);
            this.txtperjam.Name = "txtperjam";
            this.txtperjam.Size = new System.Drawing.Size(155, 20);
            this.txtperjam.TabIndex = 9;
            this.txtperjam.TextChanged += new System.EventHandler(this.gantiisi);
            // 
            // txtperhari
            // 
            this.txtperhari.Location = new System.Drawing.Point(558, 357);
            this.txtperhari.Margin = new System.Windows.Forms.Padding(2);
            this.txtperhari.Name = "txtperhari";
            this.txtperhari.Size = new System.Drawing.Size(155, 20);
            this.txtperhari.TabIndex = 9;
            this.txtperhari.TextChanged += new System.EventHandler(this.gantiisi);
            // 
            // cmbtipeinput
            // 
            this.cmbtipeinput.FormattingEnabled = true;
            this.cmbtipeinput.Location = new System.Drawing.Point(558, 383);
            this.cmbtipeinput.Margin = new System.Windows.Forms.Padding(2);
            this.cmbtipeinput.Name = "cmbtipeinput";
            this.cmbtipeinput.Size = new System.Drawing.Size(155, 21);
            this.cmbtipeinput.TabIndex = 10;
            this.cmbtipeinput.SelectedIndexChanged += new System.EventHandler(this.gantiisi);
            // 
            // btnclr
            // 
            this.btnclr.Location = new System.Drawing.Point(643, 70);
            this.btnclr.Margin = new System.Windows.Forms.Padding(2);
            this.btnclr.Name = "btnclr";
            this.btnclr.Size = new System.Drawing.Size(95, 28);
            this.btnclr.TabIndex = 11;
            this.btnclr.Text = "Clear";
            this.btnclr.UseVisualStyleBackColor = true;
            this.btnclr.Click += new System.EventHandler(this.btnclr_Click);
            // 
            // txtunit
            // 
            this.txtunit.Location = new System.Drawing.Point(117, 383);
            this.txtunit.Margin = new System.Windows.Forms.Padding(2);
            this.txtunit.Name = "txtunit";
            this.txtunit.Size = new System.Drawing.Size(155, 20);
            this.txtunit.TabIndex = 9;
            this.txtunit.TextChanged += new System.EventHandler(this.gantiisi);
            // 
            // rbaktif
            // 
            this.rbaktif.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbaktif.Location = new System.Drawing.Point(558, 407);
            this.rbaktif.Margin = new System.Windows.Forms.Padding(2);
            this.rbaktif.Name = "rbaktif";
            this.rbaktif.Size = new System.Drawing.Size(53, 21);
            this.rbaktif.TabIndex = 12;
            this.rbaktif.TabStop = true;
            this.rbaktif.Text = "Aktif";
            this.rbaktif.UseVisualStyleBackColor = true;
            this.rbaktif.CheckedChanged += new System.EventHandler(this.gantiisi);
            // 
            // rbtidakaktif
            // 
            this.rbtidakaktif.AutoSize = true;
            this.rbtidakaktif.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtidakaktif.Location = new System.Drawing.Point(621, 407);
            this.rbtidakaktif.Margin = new System.Windows.Forms.Padding(2);
            this.rbtidakaktif.Name = "rbtidakaktif";
            this.rbtidakaktif.Size = new System.Drawing.Size(92, 21);
            this.rbtidakaktif.TabIndex = 12;
            this.rbtidakaktif.TabStop = true;
            this.rbtidakaktif.Text = "Tidak Aktif";
            this.rbtidakaktif.UseVisualStyleBackColor = true;
            this.rbtidakaktif.CheckedChanged += new System.EventHandler(this.gantiisi);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(30, 331);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 18);
            this.label6.TabIndex = 23;
            this.label6.Text = "ID          :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(30, 358);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 18);
            this.label7.TabIndex = 24;
            this.label7.Text = "Merk      :";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(30, 384);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 18);
            this.label9.TabIndex = 26;
            this.label9.Text = "Unit       :";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(30, 409);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 18);
            this.label8.TabIndex = 44;
            this.label8.Text = "Name    :";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(424, 332);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 18);
            this.label11.TabIndex = 45;
            this.label11.Text = "Harga perjam   :";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(424, 358);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 18);
            this.label12.TabIndex = 46;
            this.label12.Text = "Harga perhari   :";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(424, 384);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(130, 18);
            this.label13.TabIndex = 47;
            this.label13.Text = "Tipe                  :";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(424, 409);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 18);
            this.label10.TabIndex = 48;
            this.label10.Text = "Status               :";
            // 
            // Sepeda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(749, 506);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
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
            this.Controls.Add(this.BtnInsert);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Sepeda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.RadioButton rbaktif;
        private System.Windows.Forms.RadioButton rbtidakaktif;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
    }
}