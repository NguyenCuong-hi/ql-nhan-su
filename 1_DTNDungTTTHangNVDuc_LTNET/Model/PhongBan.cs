using _02_NvCuong_DdAnh_HntAnh_BTLLTNET;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_NvCuong_DdAnh_HntAnh_BTLLTNET.Model
{
    class PhongBan
    {
        SqlConnection con = ConnectionManager.getConnection();


        public void Frm_QLPhong_Load(DataGridView dgv_dsphong)
        {

            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlCommand cmd = new SqlCommand("select * from Phong", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_dsphong.DataSource = dt;

            dgv_dsphong.Columns[0].HeaderText = "Mã Phòng Ban";
            dgv_dsphong.Columns[1].HeaderText = "Tên Phòng Ban";
            dgv_dsphong.Columns[2].HeaderText = "Địa chỉ phòng";
            dgv_dsphong.Columns[3].HeaderText = "Số điện thoại";

            dgv_dsphong.Columns[0].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgv_dsphong.Columns[1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            dgv_dsphong.Columns[2].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            dgv_dsphong.Columns[3].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
        }



        public void deleteBy(DataGridView dgv_dsphong)
        {
            int dongchon = -1;
            dongchon = dgv_dsphong.CurrentRow.Index;
            if (dongchon >= 0)
            {
                SqlCommand cmd = new SqlCommand("delete from Phong where Maphong=@map", con);
                cmd.Parameters.AddWithValue("@map", dgv_dsphong.Rows[dongchon].Cells["Maphong"].Value.ToString());
                if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Xóa thành công!!!");
                else MessageBox.Show("Xóa thất bại!!!");
                Frm_QLPhong_Load( dgv_dsphong);
            }
        }

        public void createBy(DataGridView dgv_dsphong, TextBox tb_maphong, 
            TextBox tb_tenphong, TextBox tb_diachiphong, TextBox tb_sdt)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("insert into Phong(Maphong,Tenphong,Diachi,SDT) " +
                    "values(@Map,@tenp,@dc,@sdt)", con);
                cmd.Parameters.AddWithValue("@Map", tb_maphong.Text);
                cmd.Parameters.AddWithValue("@tenp", tb_tenphong.Text);
                cmd.Parameters.AddWithValue("@dc", tb_diachiphong.Text);
                cmd.Parameters.AddWithValue("@sdt", Convert.ToInt32(tb_sdt.Text));
                if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Thêm thành công!!!!");
                else MessageBox.Show("Thêm thất bại");
                Frm_QLPhong_Load(dgv_dsphong);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public void updateBy(DataGridView dgv_dsphong, TextBox tb_maphong,
            TextBox tb_tenphong, TextBox tb_diachiphong, TextBox tb_sdt)
        {

            try
            {
                int dongchon = -1;
                dongchon = dgv_dsphong.CurrentCell.RowIndex;
                if (dongchon >= 0)
                {
                    SqlCommand cmd = new SqlCommand("update Phong set Tenphong=@tenp,Diachi=@dc, SDT=@sdt where Maphong=@mapcu", con);
                    cmd.Parameters.AddWithValue("@mapcu", dgv_dsphong.Rows[dongchon].Cells["Maphong"].Value.ToString());
                    cmd.Parameters.AddWithValue("@tenp", tb_tenphong.Text);
                    cmd.Parameters.AddWithValue("@dc", tb_diachiphong.Text);
                    cmd.Parameters.AddWithValue("@sdt", Convert.ToDouble(tb_sdt.Text));
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("sua thanh cong");
                    }
                    else
                    {
                        MessageBox.Show("sua that bai");
                    }
                    Frm_QLPhong_Load(dgv_dsphong);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void dataGridView1_SelectionChanged(DataGridView dgv_dsphong, TextBox tb_maphong,
            TextBox tb_tenphong, TextBox tb_diachiphong, TextBox tb_sdt)
        {
            int dongchon = -1;
            dongchon = dgv_dsphong.CurrentRow.Index;
            if (dongchon >= 0)
            {
                //Manv,Hoten,GT,NS,Diachi,SDT,Quequan,Maphong,Macv,Matkhau,Loainguoidung,Hesoluong
                tb_maphong.Text = dgv_dsphong.Rows[dongchon].Cells["Maphong"].Value.ToString();
                tb_tenphong.Text = dgv_dsphong.Rows[dongchon].Cells["Tenphong"].Value.ToString();
                tb_diachiphong.Text = dgv_dsphong.Rows[dongchon].Cells["Diachi"].Value.ToString();
                tb_sdt.Text = dgv_dsphong.Rows[dongchon].Cells["SDT"].Value.ToString();
            }
        }
    }
}
