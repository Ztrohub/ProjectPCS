
namespace ProjectPCS.Jonathan
{
    partial class Jaminan
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
            this.dgvjaminan = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtsrc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnsudahambil = new System.Windows.Forms.RadioButton();
            this.btnbelumambil = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.btnclr = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvjaminan)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(674, 24);
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
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // dgvjaminan
            // 
            this.dgvjaminan.AllowUserToAddRows = false;
            this.dgvjaminan.AllowUserToDeleteRows = false;
            this.dgvjaminan.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.dgvjaminan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvjaminan.Location = new System.Drawing.Point(9, 115);
            this.dgvjaminan.Margin = new System.Windows.Forms.Padding(2);
            this.dgvjaminan.Name = "dgvjaminan";
            this.dgvjaminan.ReadOnly = true;
            this.dgvjaminan.RowHeadersVisible = false;
            this.dgvjaminan.RowHeadersWidth = 51;
            this.dgvjaminan.RowTemplate.Height = 24;
            this.dgvjaminan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvjaminan.Size = new System.Drawing.Size(656, 241);
            this.dgvjaminan.TabIndex = 1;
            this.dgvjaminan.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvjaminan_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "Jaminan";
            // 
            // txtsrc
            // 
            this.txtsrc.Location = new System.Drawing.Point(63, 75);
            this.txtsrc.Margin = new System.Windows.Forms.Padding(2);
            this.txtsrc.Name = "txtsrc";
            this.txtsrc.Size = new System.Drawing.Size(138, 20);
            this.txtsrc.TabIndex = 14;
            this.txtsrc.TextChanged += new System.EventHandler(this.usersearch);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Search :";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Location = new System.Drawing.Point(279, 78);
            this.dateTimePicker3.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(151, 20);
            this.dateTimePicker3.TabIndex = 17;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(279, 55);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(151, 20);
            this.dateTimePicker2.TabIndex = 18;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(279, 55);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(151, 20);
            this.dateTimePicker1.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "End Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 55);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Start Date :";
            // 
            // btnsudahambil
            // 
            this.btnsudahambil.AutoSize = true;
            this.btnsudahambil.Location = new System.Drawing.Point(488, 81);
            this.btnsudahambil.Margin = new System.Windows.Forms.Padding(2);
            this.btnsudahambil.Name = "btnsudahambil";
            this.btnsudahambil.Size = new System.Drawing.Size(97, 17);
            this.btnsudahambil.TabIndex = 22;
            this.btnsudahambil.TabStop = true;
            this.btnsudahambil.Text = "Sudah Di Ambil";
            this.btnsudahambil.UseVisualStyleBackColor = true;
            // 
            // btnbelumambil
            // 
            this.btnbelumambil.AutoSize = true;
            this.btnbelumambil.Location = new System.Drawing.Point(488, 59);
            this.btnbelumambil.Margin = new System.Windows.Forms.Padding(2);
            this.btnbelumambil.Name = "btnbelumambil";
            this.btnbelumambil.Size = new System.Drawing.Size(95, 17);
            this.btnbelumambil.TabIndex = 21;
            this.btnbelumambil.TabStop = true;
            this.btnbelumambil.Text = "Belum Di Ambil";
            this.btnbelumambil.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(441, 64);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Status :";
            // 
            // btnclr
            // 
            this.btnclr.Location = new System.Drawing.Point(599, 62);
            this.btnclr.Margin = new System.Windows.Forms.Padding(2);
            this.btnclr.Name = "btnclr";
            this.btnclr.Size = new System.Drawing.Size(66, 39);
            this.btnclr.TabIndex = 23;
            this.btnclr.Text = "Clear";
            this.btnclr.UseVisualStyleBackColor = true;
            this.btnclr.Click += new System.EventHandler(this.btnclr_Click);
            // 
            // Jaminan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(674, 366);
            this.Controls.Add(this.btnclr);
            this.Controls.Add(this.btnsudahambil);
            this.Controls.Add(this.btnbelumambil);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker3);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtsrc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvjaminan);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Jaminan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jaminan";
            this.Load += new System.EventHandler(this.Jaminan_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvjaminan)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvjaminan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtsrc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton btnsudahambil;
        private System.Windows.Forms.RadioButton btnbelumambil;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnclr;
    }
}