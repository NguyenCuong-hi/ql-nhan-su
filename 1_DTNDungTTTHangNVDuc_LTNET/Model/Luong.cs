using _02_NvCuong_DdAnh_HntAnh_BTLLTNET;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_NvCuong_DdAnh_HntAnh_BTLLTNET.Model
{
    class Luong
    {
        SqlConnection con = ConnectionManager.getConnection();
        public void FrmTienLuong_Load(ComboBox cb_phong)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from  Phong", con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            cb_phong.DataSource = dt1;
            cb_phong.DisplayMember = "Maphong";
            cb_phong.ValueMember = "Maphong";
        }

        public void genWhereClause(StringBuilder sql, ComboBox cb_Thang, ComboBox cb_nam)
        {
            if (cb_Thang.Text != "" )
            {
                sql.Append(" AND Chamcong.Thang=@thang AND Chamcong.Nam=@nam ");
            }
            if(cb_nam.Text != "")
            {
                sql.Append(" AND Chamcong.Nam=@nam ");
            }
        }

        public void load_data_luong(DataGridView dgv_Tienluong, ComboBox cb_luong_phong, ComboBox cb_luong_thang, ComboBox cb_luong_nam)
        {
            try
            {
                string maPhong = cb_luong_phong.Text;
                string Thang = cb_luong_thang.Text;
                string Nam = cb_luong_nam.Text;
                StringBuilder sql = new StringBuilder("select Nhanvien.Manv , Hoten,Phong.Tenphong, Chamcong.Songaylv,Chucvu.Hesophucap,(Nhanvien.Hesoluong*1500000+Chucvu.Hesophucap*Chamcong.Songaylv*200000) AS Luong " +
                    " from Nhanvien, Phong, Chamcong,Chucvu " +
                    " where (1=1) AND Nhanvien.Manv=Chamcong.Manv AND  Nhanvien.Maphong=Phong.Maphong AND Nhanvien.Macv=Chucvu.Macv And Chamcong.Songaylv>=20 " +
                    " And Nhanvien.Maphong=@MP ");
                this.genWhereClause(sql, cb_luong_thang, cb_luong_nam);

                sql.Append(" UNION select Nhanvien.Manv , Hoten,Phong.Tenphong, Chamcong.Songaylv,Chucvu.Hesophucap,(Nhanvien.Hesoluong*1500000+Chucvu.Hesophucap*Chamcong.Songaylv*200000-(29-Chamcong.Songaylv)*500000) " +
                 " AS Luong from Nhanvien, Phong, Chamcong,Chucvu where Nhanvien.Manv=Chamcong.Manv AND  Nhanvien.Maphong=Phong.Maphong AND Nhanvien.Macv=Chucvu.Macv And Chamcong.Songaylv<20 " +
                 " And Nhanvien.Maphong=@MP ");
                this.genWhereClause(sql, cb_luong_thang, cb_luong_nam);
                
                SqlCommand cmd = new SqlCommand(sql.ToString(), con);
               
                cmd.Parameters.AddWithValue("@MP", maPhong);
                cmd.Parameters.AddWithValue("@thang", Thang);
                cmd.Parameters.AddWithValue("@nam", Nam);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                // Hiển thị dữ liệu lên DataGridView
                dgv_Tienluong.DataSource = dt1;
                dgv_Tienluong.Columns[0].HeaderText = "Mã Nhân viên";
                dgv_Tienluong.Columns[1].HeaderText = "Họ Tên";
                dgv_Tienluong.Columns[2].HeaderText = "Tên Phòng";
                dgv_Tienluong.Columns[3].HeaderText = "Số ngày làm việc";
                dgv_Tienluong.Columns[4].HeaderText = "Hệ số phụ cấp";
                dgv_Tienluong.Columns[5].HeaderText = "Lương";


                dgv_Tienluong.Columns[0].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
                dgv_Tienluong.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgv_Tienluong.Columns[2].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                dgv_Tienluong.Columns[3].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                dgv_Tienluong.Columns[4].AutoSizeMode =
                     DataGridViewAutoSizeColumnMode.Fill;
                dgv_Tienluong.Columns[5].AutoSizeMode =
                     DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void TongLuongTheoPhong(ComboBox cb_phong, ComboBox cb_Thang, ComboBox cb_nam, TextBox txt_kq)
        {
            try
            {
                double Tonglg = 0;
                string maPhong = cb_phong.Text;
                string Thang = cb_Thang.Text;
                string Nam = cb_nam.Text;
                SqlCommand cmd = new SqlCommand("select (Nhanvien.Hesoluong*1500000+Chucvu.Hesophucap*Chamcong.Songaylv*200000) AS Luong from Nhanvien, Phong, Chamcong,Chucvu where Nhanvien.Manv=Chamcong.Manv AND  Nhanvien.Maphong=Phong.Maphong AND Nhanvien.Macv=Chucvu.Macv And Chamcong.Songaylv>=20 And Nhanvien.Maphong=@MP " +
                    "UNION select (Nhanvien.Hesoluong*1500000+Chucvu.Hesophucap*Chamcong.Songaylv*200000-(29-Chamcong.Songaylv)*500000) AS Luong from Nhanvien, Phong, Chamcong,Chucvu where Nhanvien.Manv=Chamcong.Manv AND  Nhanvien.Maphong=Phong.Maphong AND Nhanvien.Macv=Chucvu.Macv And Chamcong.Songaylv<20 And Nhanvien.Maphong=@MP", con);
                cmd.Parameters.AddWithValue("@MP", maPhong);
                cmd.Parameters.AddWithValue("@thang", Thang);
                cmd.Parameters.AddWithValue("@nam", Nam);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                // Hiển thị dữ liệu lên DataGridView
                //object result = cmd.ExecuteScalar();
                //if (result != DBNull.Value)
                //{
                //    Tonglg = Convert.ToDouble(result);
                //}
                Tonglg = Convert.ToDouble(dataTable.Compute("SUM(Luong)", string.Empty));
                txt_kq.Text = "Tổng lương theo Phòng:" + Tonglg.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void btn_TongluongcaCTy_Click(ComboBox cb_phong, ComboBox cb_Thang, ComboBox cb_nam, TextBox txt_kq)
        {
            try
            {
                double Tonglg = 0;
                string maPhong = cb_phong.Text;
                string Thang = cb_Thang.Text;
                string Nam = cb_nam.Text;
                SqlCommand cmd = new SqlCommand("select (Nhanvien.Hesoluong*1500000+Chucvu.Hesophucap*Chamcong.Songaylv*200000) AS Luong from Nhanvien, Phong, Chamcong,Chucvu where Nhanvien.Manv=Chamcong.Manv AND  Nhanvien.Maphong=Phong.Maphong AND Nhanvien.Macv=Chucvu.Macv And Chamcong.Songaylv>=20  " +
                    "UNION select (Nhanvien.Hesoluong*1500000+Chucvu.Hesophucap*Chamcong.Songaylv*200000-(29-Chamcong.Songaylv)*500000) AS Luong from Nhanvien, Phong, Chamcong,Chucvu where Nhanvien.Manv=Chamcong.Manv AND  Nhanvien.Maphong=Phong.Maphong AND Nhanvien.Macv=Chucvu.Macv And Chamcong.Songaylv<20 ", con);
                cmd.Parameters.AddWithValue("@MP", maPhong);
                cmd.Parameters.AddWithValue("@thang", Thang);
                cmd.Parameters.AddWithValue("@nam", Nam);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                // Hiển thị dữ liệu lên DataGridView
                //object result = cmd.ExecuteScalar();
                //if (result != DBNull.Value)
                //{
                //    Tonglg = Convert.ToDouble(result);
                //}
                Tonglg = Convert.ToDouble(dataTable.Compute("SUM(Luong)", string.Empty));
                txt_kq.Text = "Tổng lương công ty:" + Tonglg.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void btn_Thue_Click(DataGridView dgv_Tienluong, ComboBox cb_phong, ComboBox cb_Thang, ComboBox cb_nam, TextBox txt_kq)
        {
            try
            {
                string maPhong = cb_phong.Text;
                string Thang = cb_Thang.Text;
                string Nam = cb_nam.Text;
                SqlCommand cmd = new SqlCommand("select Nhanvien.Manv , Hoten,Phong.Tenphong, Chamcong.Songaylv,Chucvu.Hesophucap,(Nhanvien.Hesoluong*1500000+Chucvu.Hesophucap*Chamcong.Songaylv*200000)*0.01 AS Thue from Nhanvien, Phong, Chamcong,Chucvu where Nhanvien.Manv=Chamcong.Manv AND  Nhanvien.Maphong=Phong.Maphong AND Nhanvien.Macv=Chucvu.Macv AND Chamcong.Thang=@thang AND Chamcong.Nam =@nam And Chamcong.Songaylv>=20 And Nhanvien.Hesoluong*1500000+Chucvu.Hesophucap*Chamcong.Songaylv*200000>10000000 " +
                    " UNION select Nhanvien.Manv , Hoten,Phong.Tenphong, Chamcong.Songaylv,Chucvu.Hesophucap,(Nhanvien.Hesoluong*1500000+Chucvu.Hesophucap*Chamcong.Songaylv*200000-(29-Chamcong.Songaylv)*500000)*0.01 AS Thue from Nhanvien, Phong, Chamcong,Chucvu where Nhanvien.Manv=Chamcong.Manv AND  Nhanvien.Maphong=Phong.Maphong AND Nhanvien.Macv=Chucvu.Macv AND Chamcong.Thang=@thang AND Chamcong.Nam =@nam And Chamcong.Songaylv<20 And Nhanvien.Hesoluong*1500000+Chucvu.Hesophucap*Chamcong.Songaylv*200000-(29-Chamcong.Songaylv)*500000*0.01>10000000 " +
                    " UNION select Nhanvien.Manv , Hoten,Phong.Tenphong, Chamcong.Songaylv,Chucvu.Hesophucap, 0 AS Thue from Nhanvien, Phong, Chamcong,Chucvu where Nhanvien.Manv=Chamcong.Manv AND  Nhanvien.Maphong=Phong.Maphong AND Nhanvien.Macv=Chucvu.Macv AND Chamcong.Thang=@thang AND Chamcong.Nam =@nam And Chamcong.Songaylv>=20 And Nhanvien.Hesoluong*1500000+Chucvu.Hesophucap*Chamcong.Songaylv*200000<10000000 " +
                    " UNION select Nhanvien.Manv , Hoten,Phong.Tenphong, Chamcong.Songaylv,Chucvu.Hesophucap, 0 AS Thue from Nhanvien, Phong, Chamcong,Chucvu where Nhanvien.Manv=Chamcong.Manv AND  Nhanvien.Maphong=Phong.Maphong AND Nhanvien.Macv=Chucvu.Macv AND Chamcong.Thang=@thang AND Chamcong.Nam =@nam AND Chamcong.Songaylv<20 And Nhanvien.Hesoluong*1500000+Chucvu.Hesophucap*Chamcong.Songaylv*200000-(29-Chamcong.Songaylv)*500000*0.01<10000000;", con);
                cmd.Parameters.AddWithValue("@MP", maPhong);
                cmd.Parameters.AddWithValue("@thang", Thang);
                cmd.Parameters.AddWithValue("@nam", Nam);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                // Hiển thị dữ liệu lên DataGridView
                dgv_Tienluong.DataSource = dataTable;
                dgv_Tienluong.Columns[0].HeaderText = "Mã Nhân viên";
                dgv_Tienluong.Columns[1].HeaderText = "Họ Tên";
                dgv_Tienluong.Columns[2].HeaderText = "Tên Phòng";
                dgv_Tienluong.Columns[3].HeaderText = "Số ngày làm việc";
                dgv_Tienluong.Columns[4].HeaderText = "Hệ số phụ cấp";
                dgv_Tienluong.Columns[5].HeaderText = "Thuế";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ExportExcelLuong (DataGridView dgv_Tienluong, ComboBox cb_phong, ComboBox cb_Thang, ComboBox cb_nam, TextBox txt_kq)
        {
            string maPhong = cb_phong.Text;
            string Thang = cb_Thang.Text;
            string Nam = cb_nam.Text;
            SqlCommand cmd = new SqlCommand("select Nhanvien.Manv , Hoten,Phong.Tenphong, Chamcong.Songaylv,Chucvu.Hesophucap,(Nhanvien.Hesoluong*1500000+Chucvu.Hesophucap*Chamcong.Songaylv*200000) AS Luong from Nhanvien, Phong, Chamcong,Chucvu where Nhanvien.Manv=Chamcong.Manv AND  Nhanvien.Maphong=Phong.Maphong AND Nhanvien.Macv=Chucvu.Macv And Chamcong.Songaylv>=20 And Nhanvien.Maphong=@MP AND Chamcong.Thang=@thang AND Chamcong.Nam=@nam " +
                "UNION select Nhanvien.Manv , Hoten,Phong.Tenphong, Chamcong.Songaylv,Chucvu.Hesophucap,(Nhanvien.Hesoluong*1500000+Chucvu.Hesophucap*Chamcong.Songaylv*200000-(29-Chamcong.Songaylv)*500000) AS Luong from Nhanvien, Phong, Chamcong,Chucvu where Nhanvien.Manv=Chamcong.Manv AND  Nhanvien.Maphong=Phong.Maphong AND Nhanvien.Macv=Chucvu.Macv And Chamcong.Songaylv<20 And Nhanvien.Maphong=@MP AND Chamcong.Thang=@thang AND Chamcong.Nam=@nam", con);
            cmd.Parameters.AddWithValue("@MP", maPhong);
            cmd.Parameters.AddWithValue("@thang", Thang);
            cmd.Parameters.AddWithValue("@nam", Nam);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            // Hiển thị dữ liệu lên DataGridView
            dgv_Tienluong.DataSource = dt1;

            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    // Đặt các thuộc tính cho SaveFileDialog
                    saveFileDialog.Filter = "Excel Workbook|*.xlsx";
                    saveFileDialog.ValidateNames = true;

                    // Mở SaveFileDialog
                    DialogResult result = saveFileDialog.ShowDialog();

                    // Kiểm tra xem người dùng đã chọn OK chưa
                    if (result == DialogResult.OK)
                    {
                        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                        using (ExcelPackage excelPackage = new ExcelPackage())
                        {
                            // Tạo một Sheet trong ExcelPackage
                            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                            // Đổ dữ liệu từ DataGridView vào Sheet
                            int rowStart = 1;
                            int colStart = 1;

                            // Đổ tiêu đề cột
                            for (int i = 0; i < dgv_Tienluong.Columns.Count; i++)
                            {
                                worksheet.Cells[rowStart, colStart + i].Value = dgv_Tienluong.Columns[i].HeaderText;
                            }

                            // Đổ dữ liệu từ DataGridView
                            for (int i = 0; i < dgv_Tienluong.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgv_Tienluong.Columns.Count; j++)
                                {
                                    worksheet.Cells[rowStart + 1 + i, colStart + j].Value = dgv_Tienluong.Rows[i].Cells[j].Value;
                                }
                            }

                            // Lưu gói Excel vào file
                            excelPackage.SaveAs(new FileInfo(saveFileDialog.FileName));
                        }

                        MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void ExportExcelThue(DataGridView dgv_Tienluong, ComboBox cb_phong, ComboBox cb_Thang, ComboBox cb_nam)
        {
            string maPhong = cb_phong.Text;
            string Thang = cb_Thang.Text;
            string Nam = cb_nam.Text;
            SqlCommand cmd = new SqlCommand("select Nhanvien.Manv , Hoten,Phong.Tenphong, Chamcong.Songaylv,Chucvu.Hesophucap,(Nhanvien.Hesoluong*1500000+Chucvu.Hesophucap*Chamcong.Songaylv*200000)*0.01 AS Thue from Nhanvien, Phong, Chamcong,Chucvu where Nhanvien.Manv=Chamcong.Manv AND  Nhanvien.Maphong=Phong.Maphong AND Nhanvien.Macv=Chucvu.Macv AND Chamcong.Thang=@thang AND Chamcong.Nam =@nam And Chamcong.Songaylv>=20 And Nhanvien.Hesoluong*1500000+Chucvu.Hesophucap*Chamcong.Songaylv*200000>10000000 " +
                   "UNION select Nhanvien.Manv , Hoten,Phong.Tenphong, Chamcong.Songaylv,Chucvu.Hesophucap,(Nhanvien.Hesoluong*1500000+Chucvu.Hesophucap*Chamcong.Songaylv*200000-(29-Chamcong.Songaylv)*500000)*0.01 AS Thue from Nhanvien, Phong, Chamcong,Chucvu where Nhanvien.Manv=Chamcong.Manv AND  Nhanvien.Maphong=Phong.Maphong AND Nhanvien.Macv=Chucvu.Macv AND Chamcong.Thang=@thang AND Chamcong.Nam =@nam And Chamcong.Songaylv<20 And Nhanvien.Hesoluong*1500000+Chucvu.Hesophucap*Chamcong.Songaylv*200000-(29-Chamcong.Songaylv)*500000*0.01>10000000 " +
                   "UNION select Nhanvien.Manv , Hoten,Phong.Tenphong, Chamcong.Songaylv,Chucvu.Hesophucap, 0 AS Thue from Nhanvien, Phong, Chamcong,Chucvu where Nhanvien.Manv=Chamcong.Manv AND  Nhanvien.Maphong=Phong.Maphong AND Nhanvien.Macv=Chucvu.Macv AND Chamcong.Thang=@thang AND Chamcong.Nam =@nam And Chamcong.Songaylv>=20 And Nhanvien.Hesoluong*1500000+Chucvu.Hesophucap*Chamcong.Songaylv*200000<10000000 " +
                   "UNION select Nhanvien.Manv , Hoten,Phong.Tenphong, Chamcong.Songaylv,Chucvu.Hesophucap, 0 AS Thue from Nhanvien, Phong, Chamcong,Chucvu where Nhanvien.Manv=Chamcong.Manv AND  Nhanvien.Maphong=Phong.Maphong AND Nhanvien.Macv=Chucvu.Macv AND Chamcong.Thang=@thang AND Chamcong.Nam =@nam AND Chamcong.Songaylv<20 And Nhanvien.Hesoluong*1500000+Chucvu.Hesophucap*Chamcong.Songaylv*200000-(29-Chamcong.Songaylv)*500000*0.01<10000000;", con);
            cmd.Parameters.AddWithValue("@MP", maPhong);
            cmd.Parameters.AddWithValue("@thang", Thang);
            cmd.Parameters.AddWithValue("@nam", Nam);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            // Hiển thị dữ liệu lên DataGridView
            dgv_Tienluong.DataSource = dt1;
            dgv_Tienluong.Columns[0].HeaderText = "Mã Nhân viên";
            dgv_Tienluong.Columns[1].HeaderText = "Họ Tên";
            dgv_Tienluong.Columns[2].HeaderText = "Tên Phòng";
            dgv_Tienluong.Columns[3].HeaderText = "Số ngày làm việc";
            dgv_Tienluong.Columns[4].HeaderText = "Hệ số phụ cấp";
            dgv_Tienluong.Columns[5].HeaderText = "Thuế";

            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    // Đặt các thuộc tính cho SaveFileDialog
                    saveFileDialog.Filter = "Excel Workbook|*.xlsx";
                    saveFileDialog.ValidateNames = true;

                    // Mở SaveFileDialog
                    DialogResult result = saveFileDialog.ShowDialog();

                    // Kiểm tra xem người dùng đã chọn OK chưa
                    if (result == DialogResult.OK)
                    {
                        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                        using (ExcelPackage excelPackage = new ExcelPackage())
                        {
                            // Tạo một Sheet trong ExcelPackage
                            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                            // Đổ dữ liệu từ DataGridView vào Sheet
                            int rowStart = 1;
                            int colStart = 1;

                            // Đổ tiêu đề cột
                            for (int i = 0; i < dgv_Tienluong.Columns.Count; i++)
                            {
                                worksheet.Cells[rowStart, colStart + i].Value = dgv_Tienluong.Columns[i].HeaderText;
                            }

                            // Đổ dữ liệu từ DataGridView
                            for (int i = 0; i < dgv_Tienluong.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgv_Tienluong.Columns.Count; j++)
                                {
                                    worksheet.Cells[rowStart + 1 + i, colStart + j].Value = dgv_Tienluong.Rows[i].Cells[j].Value;
                                }
                            }

                            // Lưu gói Excel vào file
                            excelPackage.SaveAs(new FileInfo(saveFileDialog.FileName));
                        }

                        MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

