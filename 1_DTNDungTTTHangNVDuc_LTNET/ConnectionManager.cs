using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_NvCuong_DdAnh_HntAnh_BTLLTNET
{
    class ConnectionManager
    {
        public static string url = @"Data Source=DUCANH\MSSQLSERVER02;Initial Catalog=qlns;Integrated Security=True";

        public static SqlConnection getConnection()
        {

                return new SqlConnection(url);
        }

        public static string getRole(string username , string password)
        {
            SqlConnection con = ConnectionManager.getConnection();
            SqlCommand scmd = new SqlCommand(
                   "select * from [user] " +
                   " join role on [role].Id = [user].id_role " +
                   "where  " +
                   " username = '" + username + "' and " +
                   " password = '" + username + "' ", con);
            SqlDataReader sdr =
                scmd.ExecuteReader();
            if (sdr.Read())
            {
                return sdr.GetString(2).Trim();
            }
            return null;
        }


        public static DataTable getDataToTable(string sql, SqlConnection con)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static void excuteSQL(string sql, SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand(sql, connection);
            sqlCommand.ExecuteNonQuery();

        }

        public static void LoadDataToCombobox(ComboBox cmb, string sql, int col, SqlConnection con)
        {
            con.Open();
            SqlDataReader sqlDataReader = null;
            SqlCommand scmd = new SqlCommand(sql, con);
            sqlDataReader = scmd.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    
                    //cmbi.Text = sqlDataReader.GetValue(col).ToString();
                    //cmb.Items.Add(cmbi);
                }
            }
            else
            {

            }
            con.Close();
        }

    }
}
