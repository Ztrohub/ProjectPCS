using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectPCS.Lukas;
using MySql.Data.MySqlClient;

namespace ProjectPCS
{
    public partial class Loading : Form
    {
        List<Tuple<Action, string>> mylist = new List<Tuple<Action, string>>();

        //      Masukkan Trigger, Proc, Function disini...

        public Loading()
        {
            InitializeComponent();

            // Buat sebuah method dibawah lalu add disini
            // Bentuknya mylist.Add(new Tuple<Action, string>(nama_method, pesan));
            mylist.Add(new Tuple<Action, string>(cobaConnect, "Try contacting database..."));
            mylist.Add(new Tuple<Action, string>(insertProcedure, "Inserting procedure..."));
            mylist.Add(new Tuple<Action, string>(insertTrigger, "Inserting trigger..."));
        }

        private async void Loading_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = mylist.Count;
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            foreach (var list in mylist)
            {
                label2.Text = list.Item2;
                await Task.Delay(1000);
                list.Item1();
                progressBar1.Value += 1;
            }

            label2.Text = "Finishing...";
            await Task.Delay(2000);
            using (Login l = new Login())
            {
                this.Hide();
                l.ShowDialog();
                this.Close();
            }
        }

        // Disini untuk menambahkan method
        void cobaConnect()
        {
            Koneksi.tryOpen();
            if (!Koneksi.test) this.Close();
        }

        private void insertTrigger()
        {
            try
            {
                MySqlScript script = new MySqlScript();
                script.Connection = Koneksi.getConn();
                script.Query = @"DELIMITER $$

                            CREATE OR REPLACE
                                TRIGGER `db_project`.`UpdateHtrans` AFTER UPDATE
                                ON `db_project`.Htrans
                                FOR EACH ROW BEGIN
                             IF new.ht_status = 1 THEN
                              CALL updateStock(old.ht_invoice_number);
                             END IF;
 
                                END$$

                            DELIMITER ;";
                Koneksi.openConn();
                script.Execute();
                Koneksi.closeConn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.Close();
            }
        }

        private void insertProcedure()
        {
            try
            {
                MySqlScript script = new MySqlScript();
                script.Connection = Koneksi.getConn();
                script.Query = @"DELIMITER $$

                            CREATE OR REPLACE
                                PROCEDURE `db_project`.`updateStock`(
	                            IN invoice TEXT
	                            )
	                            BEGIN
		                            DECLARE done BOOLEAN DEFAULT FALSE;
		                            DECLARE id INT(11);
		                            DECLARE amount INT(11);
		
		                            DECLARE curDtransSPD CURSOR FOR
		                            SELECT dtsp_sp_id, dtsp_amount
		                            FROM dtrans_sepeda
		                            JOIN htrans ON dtsp_ht_id = ht_id
		                            WHERE ht_invoice_number = invoice;
		
		                            DECLARE curDtransAKS CURSOR FOR
		                            SELECT dtak_ak_id, dtak_amount
		                            FROM dtrans_aksesoris
		                            JOIN htrans ON dtak_ht_id = ht_id
		                            WHERE ht_invoice_number = invoice;
		                            DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
		
		                            OPEN curDtransSPD;
		
		                            ulangi : LOOP
			                            FETCH curDtransSPD INTO id, amount;
			                            IF done = TRUE THEN
				                            LEAVE ulangi;
			                            END IF;
			
			                            UPDATE sepeda
			                            SET sp_amount = sp_amount + amount
			                            WHERE sp_id = id;
			
		                            END LOOP;
		
		                            OPEN curDtransAKS;
		                            SET done = FALSE;
		
		                            ulangi : LOOP
			                            FETCH curDtransAKS INTO id, amount;
			                            IF done = TRUE THEN
				                            LEAVE ulangi;
			                            END IF;
			
			                            UPDATE aksesoris
			                            SET ak_amount = ak_amount + amount
			                            WHERE ak_id = id;
			
		                            END LOOP;

	                            END$$

                            DELIMITER ;";
                Koneksi.openConn();
                script.Execute();
                Koneksi.closeConn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.Close();
            }
        }
    }
}
