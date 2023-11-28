using _02_NvCuong_DdAnh_HntAnh_BTLLTNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_NvCuong_DdAnh_HntAnh_BTLLTNET
{
   
    public partial class frm_DangNhap_DucAnh : Form
    {
        SqlConnection con = ConnectionManager.getConnection();
        public static string manv = "";
        public frm_DangNhap_DucAnh()
        {
            InitializeComponent();
           
        }



        private string getRole(string username, string password)
        {
            con.Open();
            SqlCommand scmd = new SqlCommand("select * from Nhanvien where Manv=N'" + username + "' and Matkhau=N'" + password + "'", con);
            SqlDataReader sdr = scmd.ExecuteReader();
            if (sdr.Read())
            {
                manv = sdr.GetString(0).Trim();
                return sdr.GetString(9).Trim();
            }
            con.Close();
            return null;
        }
        public String getMaNV()
        {
            return this.tb_Manv_dung.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Program.loaiND = this.getRole(tb_Manv_dung.Text, tb_mk_dung.Text);

                if (!string.IsNullOrEmpty(Program.loaiND))
                {
                    FmManHinhChinh fmManHinh = new FmManHinhChinh();
                    fmManHinh.Show();
                    fmManHinh.manv = manv;
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Mời nhập đúng thông tin đăng nhập...!!!", "Tài khoản hoặc mật khẩu không khả dụng!");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void frm_DangNhap_Dung_Load(object sender, EventArgs e)
        {
            if (chb_htmk_dung.Checked == false)
            {
                if (tb_mk_dung.PasswordChar == '\0')
                {
                   tb_mk_dung.PasswordChar = '*';
                 }
            }else{
                if (tb_mk_dung.PasswordChar == '*')
                {
                    tb_mk_dung.PasswordChar = '\0';
                }
            }
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chb_htmk_dung.Checked == false)
            {
                if (tb_mk_dung.PasswordChar == '\0')
                {
                    tb_mk_dung.PasswordChar = '*';
                }
            }
            else
            {
                if (tb_mk_dung.PasswordChar == '*')
                {
                    tb_mk_dung.PasswordChar = '\0';
                }
            }
        }
    }
}
