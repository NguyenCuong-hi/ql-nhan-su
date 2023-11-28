
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
    class ChucVu
    {
        SqlConnection con = ConnectionManager.getConnection();
        public void Frm_QuanlyChucVu_Load(DataGridView dgv_dsCV)
        {

            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlCommand cmd = new SqlCommand("select * from Chucvu", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_dsCV.DataSource = dt;

            dgv_dsCV.Columns[0].HeaderText = "Mã chức vụ";
            dgv_dsCV.Columns[1].HeaderText = "Tên chức vụ";
            dgv_dsCV.Columns[2].HeaderText = "Hệ số phụ cấp";

            dgv_dsCV.Columns[0].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            dgv_dsCV.Columns[1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            dgv_dsCV.Columns[2].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
        }



        public void createBy(DataGridView dgv_dsCV, TextBox tb_macv, TextBox tb_tencv, TextBox tb_hsopc)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into Chucvu(Macv,Tencv,Hesophucap) " +
                    "values(@Macv,@tencv,@HSPC)", con);
                cmd.Parameters.AddWithValue("@Macv", tb_macv.Text);
                cmd.Parameters.AddWithValue("@tencv", tb_tencv.Text);
                cmd.Parameters.AddWithValue("@HSPC", Convert.ToDouble(tb_hsopc.Text));
                if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Thêm thành công!!!!");
                else MessageBox.Show("Thêm thất bại");
                Frm_QuanlyChucVu_Load(dgv_dsCV);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void updateBy(DataGridView dgv_dsCV, TextBox tb_tencv, TextBox tb_hsopc)
        {
            try
            {
                int dongchon = -1;
                dongchon = dgv_dsCV.CurrentCell.RowIndex;
                if (dongchon >= 0)
                {
                    SqlCommand cmd = new SqlCommand("update Chucvu set Tencv=@tencv,Hesophucap=@hspc where Macv=@macvcu", con);
                    cmd.Parameters.AddWithValue("@macvcu", dgv_dsCV.Rows[dongchon].Cells["Macv"].Value.ToString());
                    cmd.Parameters.AddWithValue("@tencv", tb_tencv.Text);
                    cmd.Parameters.AddWithValue("@hspc", Convert.ToDouble(tb_hsopc.Text));
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("sua thanh cong");
                    }
                    else
                    {
                        MessageBox.Show("sua that bai");
                    }
                    Frm_QuanlyChucVu_Load(dgv_dsCV);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void dataGridView1_SelectionChanged(DataGridView dgv_dsCV, TextBox tb_macv, TextBox tb_tencv, TextBox tb_hsopc)
        {
            int dongchon = -1;
            dongchon = dgv_dsCV.CurrentRow.Index;
            if (dongchon >= 0)
            {
                tb_macv.Text = dgv_dsCV.Rows[dongchon].Cells["Macv"].Value.ToString();
                tb_tencv.Text = dgv_dsCV.Rows[dongchon].Cells["Tencv"].Value.ToString();
                tb_hsopc.Text = dgv_dsCV.Rows[dongchon].Cells["Hesophucap"].Value.ToString();
            }
        }

        public void deleteBy(DataGridView dgv_dsCV)
        {

            int dongchon = -1;
            dongchon = dgv_dsCV.CurrentRow.Index;
            if (dongchon >= 0)
            {
                SqlCommand cmd = new SqlCommand("delete from Chucvu where Macv=@macv", con);
                cmd.Parameters.AddWithValue("@macv", dgv_dsCV.Rows[dongchon].Cells["Macv"].Value.ToString());
                if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Xóa thành công!!!");
                else MessageBox.Show("Xóa thất bại!!!");
                Frm_QuanlyChucVu_Load(dgv_dsCV);
            }

        }

    }
}
