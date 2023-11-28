using _02_NvCuong_DdAnh_HntAnh_BTLLTNET.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _02_NvCuong_DdAnh_HntAnh_BTLLTNET
{
    public partial class Frm_QuanLyHoSoNV_Cuong : Form
    {
        SqlConnection con = ConnectionManager.getConnection();
        string Manv = "", Loainguoidung = "", Matkhau = "";
        public bool iscreate;
        public string manv;
        private static int employeeCount = 10;
        String gioitinh;
        public String getMaNV()
        {
            return this.txtmanv.Text;
        }

        public Frm_QuanLyHoSoNV_Cuong()
        {

            InitializeComponent();
            if (Program.loaiND.Equals("Nhanvien"))
            {
                btn_hsnv_xoa.Visible = false;
            }

        }

        public Frm_QuanLyHoSoNV_Cuong(string Manv, string Loainguoidung, string Matkhau)
        {
            InitializeComponent();
            this.Manv = Manv;
            this.Loainguoidung = Loainguoidung;
            this.Matkhau = Matkhau;
        }


        private void cbPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = " ";
            if (cbPhongBan.SelectedIndex != -1)
            {
                sql = "SELECT * FROM [Phong] " +
                   " JOIN [Nhanvien] ON [Nhanvien].Maphong = [Phong].Maphong " +
                   " WHERE  [Nhanvien].Manv = '" + manv + "'";

            }
            else
            {
                sql = "SELECT * FROM [Phong] ";
            }
        }

        private void cbPhongBan_DropDown(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM [Phong] ";
            SqlCommand cmdPhong = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmdPhong);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbPhongBan.DataSource = dt;
            cbPhongBan.DisplayMember = "Tenphong";
            cbPhongBan.ValueMember = "Maphong";
            if (cbPhongBan.Items.Count > 0)
            {
                cbPhongBan.SelectedIndex = 0;
                cbPhongBan.Text = cbPhongBan.GetItemText(cbPhongBan.Items[0]);
            }
            cmdPhong.Dispose();
            da.Dispose();
        }

        private void cb_maCV_DropDown(object sender, EventArgs e)
        {
            string sqlChucvu = "SELECT * FROM [Chucvu] ";
            SqlCommand cmdChucvu = new SqlCommand(sqlChucvu, con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmdChucvu);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            cbChucvu.DataSource = dt2;
            cbChucvu.DisplayMember = "Tencv";
            cbChucvu.ValueMember = "Macv";
            if (cbChucvu.Items.Count > 0)
            {
                cbChucvu.SelectedIndex = 0;
                cbChucvu.Text = cbChucvu.GetItemText(cbChucvu.Items[0]);
            }
            cmdChucvu.Dispose();
            da2.Dispose();
        }

       
        private void btn_hsnv_luu(object sender, EventArgs e)
        {
            string ngay = String.Format("{0:MM/dd/yyyy}", dtpNgaySinh.Value);
            if (radioButton1.Checked)
            {
                // Xử lý khi chọn giới tính là Nam
                gioitinh = "Nam";
                // Thực hiện công việc khác tương ứng với giới tính Nam
            }
            if (radioButton2.Checked)
            {
                // Xử lý khi chọn giới tính là Nữ
                gioitinh = "Nu";
                // Thực hiện công việc khác tương ứng với giới tính Nữ
            }
            try
            {
                string selectedCV = cbChucvu.SelectedValue?.ToString();
                string selectedPhong = cbPhongBan.SelectedValue?.ToString();
                string sql = "";
                if (iscreate == true)
                {
                    sql = " INSERT INTO Nhanvien (Manv, Hoten, GT, NS, Diachi, Quequan, Maphong, Macv, Matkhau, Loainguoidung, Hesoluong ) VALUES ( " +
                        " '" + this.GenerateEmployeeCode() + "', " +
                      " N'" + txthoten.Text + "'," +
                   " N'" + gioitinh + "'," +
                   " '" + ngay + "', " +
                   " N'" + txtdiachi.Text + "'," +
                   " N'" + txtqq.Text + "', " +
                   " '" + selectedPhong + "' ," +
                   " '" + selectedCV + "', " +
                   " '1111', " +
                   " '" + cb_loaiND.Text + "', " +
                   " '" + txt_hsl.Text + "' "+
                   " )" ;
                    MessageBox.Show("Thêm thành công");

                }
                else
                {
                    sql = " UPDATE Nhanvien SET " +
                    " Hoten = N'" + txthoten.Text + "'," +
                    " GT =N'" + gioitinh + "'," +
                    " NS= '" + ngay + "', " +
                    " Diachi = N'" + txtdiachi.Text + "'," +
                    " Quequan = N'" + txtqq.Text + "' WHERE " +
                    " Manv = N'" + txtmanv.Text + "' ";
                    MessageBox.Show("Sửa thành công");

                }

                ConnectionManager.excuteSQL(sql, con);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        public string GenerateEmployeeCode()
        {
            employeeCount++;
            string employeeCode = $"UNET{employeeCount:D3}";

            return employeeCode;
        }

        private void btn_hsnv_huy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                radioButton2.Checked = false; // Vô hiệu hóa RadioButton 2
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                radioButton1.Checked = false; // Vô hiệu hóa RadioButton 1
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_hsnv_xoa_Click(object sender, EventArgs e)
        {

            Hsnv hsnv = new Hsnv();
            hsnv.deleteHSNV(txtmanv, con);
            MessageBox.Show("Xóa nhân viên thành công !");
            this.Close();
        }


        private void Frm_QuanLyHoSoNV_Dung_Load(object sender, EventArgs e)
        {
            string ngay = String.Format("{0:MM/dd/yyyy}", dtpNgaySinh.Value);

            if (con.State == ConnectionState.Closed)
                con.Open();

            string sql = "SELECT * FROM [Nhanvien] " +
                " JOIN [Phong] ON [Nhanvien].Maphong = [Phong].Maphong " +
                " JOIN [Chucvu] ON [Nhanvien].Macv = [Chucvu].Macv " +
                " WHERE  [Nhanvien].Manv = '" + manv + "'";
            SqlCommand scmd = new SqlCommand(sql, con);
            SqlDataReader sdr = scmd.ExecuteReader();
            if (sdr.Read())
            {
                txtmanv.Text = sdr.GetString(sdr.GetOrdinal("Manv")).Trim();
                txthoten.Text = sdr.GetString(sdr.GetOrdinal("Hoten")).Trim();
                gioitinh = sdr.GetString(sdr.GetOrdinal("GT")).Trim();
                if (gioitinh == "Nam")
                {
                    radioButton1.Checked = true; // Chọn RadioButton "Nam"
                }
                else if (gioitinh == "Nu")
                {
                    radioButton2.Checked = true; // Chọn RadioButton "Nữ"
                }
                dtpNgaySinh.Text = sdr.GetString(sdr.GetOrdinal("NS")).ToString().Trim();
                txtqq.Text = sdr.GetString(sdr.GetOrdinal("Quequan")).Trim();
                txtdiachi.Text = sdr.GetString(sdr.GetOrdinal("Diachi")).Trim();
                txt_sdt.Text = sdr.GetInt32(sdr.GetOrdinal("SDT")).ToString().Trim();
                txt_hsl.Text = sdr.GetDouble(sdr.GetOrdinal("Hesoluong")).ToString().Trim();
                cb_loaiND.Text = sdr.GetString(sdr.GetOrdinal("Loainguoidung")).ToString().Trim();
            }
            sdr.Close();


            string sqlChucvu = "SELECT * FROM [Chucvu] " +
                   " JOIN [Nhanvien] ON [Nhanvien].Macv = [Chucvu].Macv " +
                   " WHERE  [Nhanvien].Manv = '" + manv + "'";
            SqlCommand cmd2 = new SqlCommand(sqlChucvu, con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            cbChucvu.DataSource = dt2;
            cbChucvu.DisplayMember = "Tencv";
            cbChucvu.ValueMember = "Macv";
            cmd2.Dispose();

            string sqlPhong = "SELECT * FROM [Phong] " +
                   " JOIN [Nhanvien] ON [Nhanvien].Maphong = [Phong].Maphong " +
                   " WHERE  [Nhanvien].Manv = '" + manv + "'";


            SqlCommand cmd3 = new SqlCommand(sqlPhong, con);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            cbPhongBan.DataSource = dt3;
            cbPhongBan.DisplayMember = "Tenphong";
            cbPhongBan.ValueMember = "Maphong";

        }
    }
}
