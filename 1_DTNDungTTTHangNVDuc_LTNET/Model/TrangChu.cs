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
    class TrangChu
    {
        public void genWhereClause(string sql, string keyword)
        {
            if(keyword != null)
            {
                sql += " WHERE (1=1) AND ( "
                    + " [Nhanvien].Manv =  N'" + keyword + "' " 
                    +" OR [Nhanvien].Hoten =  N'" + keyword + "' " 
                    + " OR [Nhanvien].Diachi =  N'" + keyword + "' " 
                    + " OR [Nhanvien].Quequan =  N'" + keyword + "' " 
                    + " OR Phong.Tenphong  N'" + keyword + "' ) "; 
            }
        }
        public void ViewData(DataGridView dgv_dsNV_Cuong, string keyword)
        {

            SqlConnection con = ConnectionManager.getConnection();
            string sql = "SELECT [Nhanvien].Manv, Nhanvien.Hoten, Nhanvien.GT,  Nhanvien.Diachi, Nhanvien.NS," +
                " Nhanvien.Quequan, Chucvu.Tencv, Phong.Tenphong FROM [Nhanvien] " +
                " JOIN [Chucvu] ON [Chucvu].Macv = [Nhanvien].Macv " +
                " JOIN [Phong] ON [Phong].Maphong = [Nhanvien].Maphong ";
            this.genWhereClause(sql, keyword);
            DataTable dataTable = ConnectionManager.getDataToTable(sql, con);
            dgv_dsNV_Cuong.DataSource = dataTable;
            dgv_dsNV_Cuong.Columns[0].HeaderText = "Mã Nhân viên";
            dgv_dsNV_Cuong.Columns[1].HeaderText = "Họ Và Tên";
            dgv_dsNV_Cuong.Columns[2].HeaderText = "Giới tính";
            dgv_dsNV_Cuong.Columns[3].HeaderText = "Địa chỉ";
            dgv_dsNV_Cuong.Columns[4].HeaderText = "Năm sinh ";
            dgv_dsNV_Cuong.Columns[5].HeaderText = "Quê quán";
            dgv_dsNV_Cuong.Columns[6].HeaderText = "Chức vụ";
            dgv_dsNV_Cuong.Columns[7].HeaderText = "Phòng ban";

            dgv_dsNV_Cuong.Columns[0].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgv_dsNV_Cuong.Columns[1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgv_dsNV_Cuong.Columns[2].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgv_dsNV_Cuong.Columns[3].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            dgv_dsNV_Cuong.Columns[4].AutoSizeMode =
                 DataGridViewAutoSizeColumnMode.Fill;
            dgv_dsNV_Cuong.Columns[5].AutoSizeMode =
                  DataGridViewAutoSizeColumnMode.Fill;
            dgv_dsNV_Cuong.Columns[6].AutoSizeMode =
                   DataGridViewAutoSizeColumnMode.Fill;
            dgv_dsNV_Cuong.Columns[7].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;

        }

        public void selected_data(DataGridView dgv_dsNV_Cuong)
        {
            try
            {
                int dongchon = -1;
                dongchon = dgv_dsNV_Cuong.CurrentRow.Index;
                if (dongchon >= 0)
                {
                    string manv = dgv_dsNV_Cuong.Rows[dongchon].Cells["manv"].Value.ToString();
                    Frm_QuanLyHoSoNV_Cuong fm = new Frm_QuanLyHoSoNV_Cuong();
                    fm.manv = manv;
                    fm.iscreate = false;
                   DialogResult result = fm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
