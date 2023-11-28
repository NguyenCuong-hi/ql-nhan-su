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
    public partial class Frm_DoiMK_DucAnh : Form
    {

        string ma;
        public void SetMa(string maSo)
        {
            ma = maSo; // Gán giá trị vào Label của Form2
        }
        SqlConnection con;
        public Frm_DoiMK_DucAnh()
        {
            InitializeComponent();
            con = ConnectionManager.getConnection();
        }

        public FmManHinhChinh frDn;
        public void setfrm_DangNhap_DucAnh(FmManHinhChinh form)
        {
            frDn = form;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select  count(*) from Nhanvien where  Manv=N'" + ma + "' and Matkhau=N'" + textBox4.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                errorProvider1.Clear();
                if (dt.Rows[0][0].ToString() == "1")
                {
                    if (textBox3.Text == textBox2.Text)
                    {
                        SqlDataAdapter da1 = new SqlDataAdapter("update Nhanvien set Matkhau=N'" + textBox3.Text + "' where Manv=N'" + ma + "' and Matkhau=N'" + textBox4.Text + "'", con);
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);
                        MessageBox.Show("Đổi mật khẩu thành công!!!", "Thông báo");
                    }
                    else
                    {
                        errorProvider1.SetError(textBox3, "thông tin rỗng");
                        MessageBox.Show("Bạn chưa điền thông tin!!!");
                        errorProvider1.SetError(textBox2, "mật khẩu sai");
                        MessageBox.Show("Mật khẩu không khớp, mời nhập lại!!!");
                    }
                }
                else
                {
                    errorProvider1.SetError(textBox4, "Mật khẩu sai");
                    MessageBox.Show("Mật khẩu cũ không đúng!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Frm_DoiMK_Dung_Load(object sender, EventArgs e)
        {
            //label5.Text = ma();
            if (checkBox1.Checked == false)
            {
                if (textBox4.PasswordChar == '\0')
                {
                    textBox4.PasswordChar = '*';
                }
            }
            else
            {
                if (textBox4.PasswordChar == '*')
                {
                    textBox4.PasswordChar = '\0';
                }
            }
            if (checkBox2.Checked == false)
            {
                if (textBox3.PasswordChar == '\0')
                {
                    textBox3.PasswordChar = '*';
                }
            }
            else
            {
                if (textBox3.PasswordChar == '*')
                {
                    textBox3.PasswordChar = '\0';
                }
            }
            if (checkBox3.Checked == false)
            {
                if (textBox2.PasswordChar == '\0')
                {
                    textBox2.PasswordChar = '*';
                }
            }
            else
            {
                if (textBox2.PasswordChar == '*')
                {
                    textBox2.PasswordChar = '\0';
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                if (textBox4.PasswordChar == '\0')
                {
                    textBox4.PasswordChar = '*';
                }
            }
            else
            {
                if (textBox4.PasswordChar == '*')
                {
                    textBox4.PasswordChar = '\0';
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                if (textBox3.PasswordChar == '\0')
                {
                    textBox3.PasswordChar = '*';
                }
            }
            else
            {
                if (textBox3.PasswordChar == '*')
                {
                    textBox3.PasswordChar = '\0';
                }
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == false)
            {
                if (textBox3.PasswordChar == '\0')
                {
                    textBox3.PasswordChar = '*';
                }
            }
            else
            {
                if (textBox3.PasswordChar == '*')
                {
                    textBox3.PasswordChar = '\0';
                }
            }
        }
    }
}
