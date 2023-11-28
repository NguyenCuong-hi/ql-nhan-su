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
    class Hsnv
    {
        SqlConnection con = ConnectionManager.getConnection();
        string Manv = "", Loainguoidung = "", Matkhau = "";

        public String getMaNV(TextBox txtmanv)
        {
            return txtmanv.Text;
        }



        public void validPermision()
        {
            if (Program.loaiND.Equals("CaNhan"))
            {
                
            }
            if (Program.loaiND.Equals("GiamDoc"))
            {
                
            }
        }

        public void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đăng xuất thành công....");
            frm_DangNhap_DucAnh f = new frm_DangNhap_DucAnh();

            f.ShowDialog();
            //this.Show();
        }

        public void toolStripMenuItem1_Click(TextBox txtmanv, TextBox txthoten, 
            string txtgt, TextBox txt_sdt, TextBox txtqq,
            ComboBox cb_maphong_dung, ComboBox cbChucvu, ComboBox cb_loaiND, 
            TextBox txt_hsl, TextBox txtdiachi, DateTimePicker dob, ComboBox cbPhongBan, string manv)
        {
            try
            {
                if (Program.loaiND == "CaNhan")
                {
                    MessageBox.Show("Bạn không có quyền truy cập");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("insert into Nhanvien(Manv,Hoten,GT,NS,Diachi,SDT,Quequan,Maphong,Macv,Matkhau,Loainguoidung,Hesoluong) " +
                         "values(@maNV,@hoten,@GT,@NS,@Dc,@SDT,@qq,@Maphong,@Macv,@MK,@LoaiND,@HSL)", con);
                    cmd.Parameters.AddWithValue("@maNV", txtmanv.Text);
                    cmd.Parameters.AddWithValue("@hoten", txthoten.Text);
                    cmd.Parameters.AddWithValue("@GT", txtgt);

                    //cmd.Parameters.AddWithValue("@Dc", this.tb_dc_dung.Text);
                    cmd.Parameters.AddWithValue("@SDT", txt_sdt.Text);
                    cmd.Parameters.AddWithValue("@qq", txtqq.Text);
                    cmd.Parameters.AddWithValue("@Maphong", cb_maphong_dung.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Macv", cbChucvu.SelectedValue.ToString());
                    //cmd.Parameters.AddWithValue("@MK", this.tb_mk_dung.Text);
                    cmd.Parameters.AddWithValue("@LoaiND", cb_loaiND.Text);
                    cmd.Parameters.AddWithValue("@HSL", Convert.ToDouble(txt_hsl.Text));
                    if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Thêm thành công!!!!");
                    else MessageBox.Show("Thêm thất bại");
                    Frm_QuanLyHoSoNV_Load(txtmanv, txthoten, txtgt, txt_sdt, txtqq,
                        txtdiachi, dob, txt_hsl, cbChucvu, cbPhongBan, cb_loaiND ,manv);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        public void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.loaiND == "Nhanvien")
                {
                    MessageBox.Show("Bạn không có quyền truy cập");
                }
                else
                {
                    int dongchon = -1;
                    //dongchon = dgv_dsNV_Dung.CurrentCell.RowIndex;
                    if (dongchon >= 0)
                    {
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.loaiND == "Nhanvien")
            {
                MessageBox.Show("Bạn không có quyền truy cập");
                //tb_manv_dung.Enabled = false;
                //tb_hoten_dung.Enabled = false;
                //tb_gt_dung.Enabled = false;
                //tb_sdt_dung.Enabled = false;
                //tb_dc_dung.Enabled = false;
                //tb_qq_dung.Enabled = false;
                //tb_hsl_dung.Enabled = false;
                //tb_mk_dung.Enabled = false;
                //dateTimePicker1.Enabled = false;
                //cb_loaiND_dung.Enabled = false;
                //cb_maCV_dung.Enabled = false;
                //cb_maphong_dung.Enabled = false;
            }
            else
            {

            }
        }

        public void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox1.Checked == false)
            //{
            //    if (tb_mk_dung.PasswordChar == '\0')
            //    {
            //        tb_mk_dung.PasswordChar = '*';
            //    }
            //}
            //else
            //{
            //    if (tb_mk_dung.PasswordChar == '*')
            //    {
            //        tb_mk_dung.PasswordChar = '\0';
            //    }
            //}
        }

        
        public void cbPhongBan_SelectedIndexChanged(ComboBox cbPhongBan, string manv)
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

        public void cbPhongBan_DropDown(ComboBox cbPhongBan)
        {
            string sql = "SELECT * FROM [Phong] ";
            SqlCommand cmdPhong = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmdPhong);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbPhongBan.DataSource = dt;
            cbPhongBan.DisplayMember = "Tenphong";
            cbPhongBan.ValueMember = "Tenphong";
            cmdPhong.Dispose();
            da.Dispose();
        }

        public void cb_maCV_DropDown(ComboBox cbChucvu)
        {
            string sqlChucvu = "SELECT * FROM [Chucvu] ";
            SqlCommand cmdChucvu = new SqlCommand(sqlChucvu, con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmdChucvu);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            cbChucvu.DataSource = dt2;
            cbChucvu.DisplayMember = "Tencv";
            cbChucvu.ValueMember = "Tencv";
            cmdChucvu.Dispose();
            da2.Dispose();
        }

        public void updateBy(TextBox txtmanv, TextBox txthoten,
            TextBox txtgt, TextBox txtdiachi, TextBox txtqq, TextBox dob)
        {
            try
            {
                string sql = " UPDATE Nhanvien SET " +
                    " Hoten = N'" + txthoten.Text + "'," +
                    " GT =N'" + txtgt.Text + "'," +
                    " NS= '" + dob.Text + "', " +
                    " Diachi = N'" + txtdiachi.Text + "'," +
                    " Quequan = N'" + txtqq.Text + "' WHERE " +
                    " Manv = N'" + txtmanv.Text + "' ";
                ConnectionManager.excuteSQL(sql, con);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        


        public void Frm_QuanLyHoSoNV_Load(TextBox txtmanv, TextBox txthoten,
            string txtgt, TextBox txt_sdt, TextBox txtqq, TextBox txtdiachi, 
            DateTimePicker dob, TextBox txt_hsl, ComboBox cbChucvu, ComboBox cbPhongBan, ComboBox cb_loaiND, string manv)
        {
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
                txtgt = sdr.GetString(sdr.GetOrdinal("GT")).Trim();
                if (txtgt == "Nam")
                {
                    FmManHinhChinh form = (FmManHinhChinh)Application.OpenForms["FmManHinhChinh"];
                    form.radioButton1.Checked = true; // Chọn RadioButton "Nam" trong Form1
                }
                else if (txtgt == "Nữ")
                {
                    FmManHinhChinh form = (FmManHinhChinh)Application.OpenForms["FmManHinhChinh"];
                    form.radioButton2.Checked = true; // Chọn RadioButton "Nữ" trong Form1
                }
                dob.Text = sdr.GetString(sdr.GetOrdinal("NS")).ToString().Trim();
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
            cbChucvu.ValueMember = "Tencv";
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
            cbPhongBan.ValueMember = "Tenphong";

        }

        public void saveOrUpdateHSNV(TextBox txthoten, string txtgt, string dob,
            TextBox txtdiachi, TextBox txtqq, bool iscreate, TextBox txtmanv, 
            ComboBox cbChucvu, ComboBox cbPhongBan, ComboBox cb_loaiND, TextBox hesoluong )
        {
            string selectedCV = cbChucvu.SelectedValue?.ToString();
            string selectedPhong = cbPhongBan.SelectedValue?.ToString();
            try
            {
                string sql = " UPDATE Nhanvien SET " +
                    " Hoten = N'" + txthoten.Text + "'," +
                    " GT =N'" + txtgt + "'," +
                    " NS= '" + dob + "', " +
                    " Diachi = N'" + txtdiachi.Text + "'," +
                    " Quequan = N'" + txtqq.Text + "', " +
                    " Maphong = '" + selectedPhong + "', " +
                    " Macv = '" + selectedCV + "', " +
                    " Loainguoidung = '" + cb_loaiND.Text + "', " +
                    " Hesoluong = '"+ hesoluong.Text + "' " +
                    "  WHERE " +
                    " Manv = N'" + txtmanv.Text + "' ";

                ConnectionManager.excuteSQL(sql, con);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void deleteHSNV( TextBox txtmanv, SqlConnection conn)
        {
            
            try
            {
                
                string sql = " DELETE FROM Nhanvien " +
                    "  WHERE " +
                    " Manv = N'" + txtmanv.Text + "' ";

                ConnectionManager.excuteSQL(sql, conn);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

