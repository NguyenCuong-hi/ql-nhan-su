using _02_NvCuong_DdAnh_HntAnh_BTLLTNET;
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
    class ChamCong
    {
        SqlConnection con = ConnectionManager.getConnection();
        public void Frm_Chamcong_Load(ComboBox cb_phong, ComboBox cbManv)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from  [Phong] ", con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            cb_phong.DataSource = dt1;
            cb_phong.DisplayMember = "Maphong";
            cb_phong.ValueMember = "Maphong";
            SqlDataAdapter da = new SqlDataAdapter("select * from  [Nhanvien] ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbManv.DataSource = dt;
            cbManv.DisplayMember = "Manv";
            cbManv.ValueMember = "Manv";

            da.Dispose();
            da1.Dispose();
            con.Close();

        }

        public void dataGridView1_CellContentClick(DataGridView dgv_bangccong, ComboBox cbManv, ComboBox cb_Thang)
        {
            int dongchon = -1;
            dongchon = dgv_bangccong.CurrentRow.Index;
            if (dongchon >= 0)
            {
                //Manv,Hoten,GT,NS,Diachi,SDT,Quequan,Maphong,Macv,Matkhau,Loainguoidung,Hesoluong
                //tb_macc_dung.Text = dgv_bangccong_dung.Rows[dongchon].Cells["Maccong"].Value.ToString();
                cbManv.SelectedIndex = cbManv.FindString(dgv_bangccong.Rows[dongchon].Cells["Manv"].Value.ToString());
                cb_Thang.Text = dgv_bangccong.Rows[dongchon].Cells["Thang"].Value.ToString();
                //tb_nam_dung.Text = dgv_bangccong_dung.Rows[dongchon].Cells["Nam"].Value.ToString();
            }
        }

        public void button1_Click(DataGridView dgv_bangccong)
        {
            int dongchon = -1;
            dongchon = dgv_bangccong.CurrentRow.Index;
            string manv = "";
            string songaylv = "";
            string maccong = "";
            if (dongchon >= 0)
            {
                manv = dgv_bangccong.Rows[dongchon].Cells["Manv"].Value.ToString();
                maccong = dgv_bangccong.Rows[dongchon].Cells["Maccong"].Value.ToString();

                songaylv = dgv_bangccong.Rows[dongchon].Cells["Songaylv"].Value.ToString();
            }
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Chamcong SET Songaylv=@songay  WHERE Manv = @Manv AND Maccong = @Maccong ", con);
                cmd.Parameters.AddWithValue("@manv", manv);
                cmd.Parameters.AddWithValue("@Maccong", maccong);
                cmd.Parameters.AddWithValue("@songay", songaylv);
                if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Sửa chấm công!");
                else MessageBox.Show("Đã có lỗi xảy ra !");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void cb_phong_SelectedIndexChanged(DataGridView dgv_bangccong, ComboBox cb_phong,
            ComboBox cbManv, ComboBox cb_Thang, ComboBox cb_nam)
        {

            DataTable table = ConnectionManager
                .getDataToTable(this.gennerateSql(cb_phong, cbManv, cb_Thang, cb_nam), con);

            dgv_bangccong.DataSource = table;
            foreach (DataGridViewColumn column in dgv_bangccong.Columns)
            {
                if (table.Columns.Contains(column.Name))
                {
                    column.DataPropertyName = table.Columns[column.Name].ColumnName;
                }
            }
            con.Close();

        }

        public void cb_Thang_SelectedIndexChanged(DataGridView dgv_bangccong, ComboBox cb_phong,
            ComboBox cbManv, ComboBox cb_Thang, ComboBox cb_nam)
        {
            DataTable table = ConnectionManager
                .getDataToTable(this.gennerateSql(cb_phong, cbManv, cb_Thang, cb_nam), con);

            dgv_bangccong.DataSource = table;
            foreach (DataGridViewColumn column in dgv_bangccong.Columns)
            {
                if (table.Columns.Contains(column.Name))
                {
                    column.DataPropertyName = table.Columns[column.Name].ColumnName;
                }
            }
            con.Close();
        }

        public void cb_nam_SelectedIndexChanged(DataGridView dgv_bangccong, ComboBox cb_phong,
            ComboBox cbManv, ComboBox cb_Thang, ComboBox cb_nam)
        {
            DataTable table = ConnectionManager
                .getDataToTable(this.gennerateSql(cb_phong, cbManv, cb_Thang, cb_nam), con);

            dgv_bangccong.DataSource = table;
            foreach (DataGridViewColumn column in dgv_bangccong.Columns)
            {
                if (table.Columns.Contains(column.Name))
                {
                    column.DataPropertyName = table.Columns[column.Name].ColumnName;
                }
            }
            con.Close();
        }

        public void cbManv_SelectedIndexChanged(DataGridView dgv_bangccong, ComboBox cb_phong,
            ComboBox cbManv, ComboBox cb_Thang, ComboBox cb_nam)
        {
            DataTable table = ConnectionManager
                .getDataToTable(this.gennerateSql(cb_phong, cbManv, cb_Thang, cb_nam), con);

            dgv_bangccong.DataSource = table;
            foreach (DataGridViewColumn column in dgv_bangccong.Columns)
            {
                if (table.Columns.Contains(column.Name))
                {
                    column.DataPropertyName = table.Columns[column.Name].ColumnName;
                }
            }

        }

        public void loadTable(DataGridView dgv_bangccong, ComboBox cb_phong, 
            ComboBox cbManv, ComboBox cb_Thang, ComboBox cb_nam)
        {
            DataTable table = ConnectionManager
                .getDataToTable(this.gennerateSql(cb_phong, cbManv, cb_Thang, cb_nam), con);

            dgv_bangccong.DataSource = table;
            foreach (DataGridViewColumn column in dgv_bangccong.Columns)
            {
                if (table.Columns.Contains(column.Name))
                {
                    column.DataPropertyName = table.Columns[column.Name].ColumnName;
                }
            }
        }

        public string gennerateSql(ComboBox cb_phong, ComboBox cbManv, ComboBox cb_Thang, ComboBox cb_nam)
        {

            string sql = "SELECT " +
            " [Chamcong].Maccong, [Nhanvien].Manv, [Nhanvien].Hoten, [Nhanvien].GT," +
            " [Phong].Tenphong, [Chamcong].Songaylv FROM [Nhanvien] " +
                " JOIN [Phong] ON [Nhanvien].Maphong = [Phong].Maphong " +
                " JOIN [Chamcong] ON [Nhanvien].Manv = [Chamcong].Manv " +
                " WHERE (1=1)  ";
            if (cb_phong.Text != null)
            {
                sql += " AND ( [Phong].Maphong = '" + cb_phong.Text + "' )";
            }
            if (cbManv.Text != null)
            {
                sql += " AND ( [Nhanvien].Manv = '" + cbManv.Text + "')";
            }
            if (cb_Thang.Text != null)
            {
                sql += " OR ( [Chamcong].Thang = '" + cb_Thang.Text + "')";
            }
            if (cb_nam.Text != null)
            {
                sql += " OR ([Chamcong].Nam = '" + cb_nam.Text + "')";
            }

            return sql;
        }

        public string GenerateAttendanceCode()
        {
            DateTime currentDate = DateTime.Now;
            string attendanceCode = currentDate.ToString("MMddHHmmss");
            return attendanceCode;
        }

        public void bt_CCong_Click(DataGridView dgv_bangccong, ComboBox cb_phong, ComboBox cbManv, 
            ComboBox cb_Thang, ComboBox cb_nam, TextBox txtSongaylv)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into Chamcong(Maccong,Manv,Thang,Nam,Songaylv) values(@macc,@manv,@thang,@nam,@songay)", con);
                cmd.Parameters.AddWithValue("@macc", this.GenerateAttendanceCode());
                cmd.Parameters.AddWithValue("@manv", cbManv.Text);
                cmd.Parameters.AddWithValue("@thang", cb_Thang.Text);
                cmd.Parameters.AddWithValue("@nam", cb_nam.Text);
                cmd.Parameters.AddWithValue("@songay", txtSongaylv.Text);
                if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Đã chấm công!");
                else MessageBox.Show("Đã có lỗi xảy ra !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.loadTable(dgv_bangccong,  cb_phong, cbManv,  cb_Thang,  cb_nam);
        }


        public void CCong_Click(DataGridView dgv_bangccong, ComboBox cb_phong, ComboBox cbManv, 
            ComboBox cb_Thang, ComboBox cb_nam, TextBox txtSongaylv)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into Chamcong(Maccong,Manv,Thang,Nam,Songaylv) values(@macc,@manv,@thang,@nam,@songay)", con);
                cmd.Parameters.AddWithValue("@macc", this.GenerateAttendanceCode());
                cmd.Parameters.AddWithValue("@manv", cbManv.Text);
                cmd.Parameters.AddWithValue("@thang", cb_Thang.Text);
                cmd.Parameters.AddWithValue("@nam", cb_nam.Text);
                cmd.Parameters.AddWithValue("@songay", txtSongaylv.Text);
                if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Đã chấm công!");
                else MessageBox.Show("Đã có lỗi xảy ra !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.loadTable(dgv_bangccong, cb_phong, cbManv, cb_Thang, cb_nam);
        }

        public void btnXoa_Click(DataGridView dgv_bangccong, ComboBox cb_phong, ComboBox cbManv,
            ComboBox cb_Thang, ComboBox cb_nam, TextBox txtSongaylv)
        {
            int dongchon = -1;
            dongchon = dgv_bangccong.CurrentRow.Index;
            string manv = "";
            string maccong = "";
            if (dongchon >= 0)
            {
                manv = dgv_bangccong.Rows[dongchon].Cells["Manv"].Value.ToString();
                maccong = dgv_bangccong.Rows[dongchon].Cells["Maccong"].Value.ToString();
            }
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Chamcong WHERE Manv = @Manv AND Maccong = @Maccong ", con);
                cmd.Parameters.AddWithValue("@manv", manv);
                cmd.Parameters.AddWithValue("@Maccong", maccong);
                if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Xóa chấm công!");
                else MessageBox.Show("Đã có lỗi xảy ra !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.loadTable(dgv_bangccong, cb_phong, cbManv, cb_Thang, cb_nam);
        }
    }
}
