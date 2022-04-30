using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ProjectPCS
{
    static class Koneksi
    {
        public static MySqlConnection conn = new MySqlConnection();
        public static string dbname = "db_project";
        public static string server = "localhost";
        public static string username = "root";
        public static string password = "";
        public static bool test = true;

        public static void tryOpen()
        {
            conn.ConnectionString = string.Format("server={0}; user id={1}; password={2}; database={3}", server, username, password, dbname);

            test = true;
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Gagal terhubung ke database!");
                test = false;
            }
        }

        public static void openConn()
        {
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
        }

        public static void closeConn()
        {
            conn.Close();
        }

        public static MySqlConnection getConn()
        {
            return conn;
        }


    }
}
