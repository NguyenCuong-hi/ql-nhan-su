using _02_NvCuong_DdAnh_HntAnh_BTLLTNET.Model;
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
    public partial class FmManHinhChinh : Form
    {
        private Size oldSize;
        public string manv;
        public string gioitinh;
        TrangChu trangChu = new TrangChu();

        public frm_DangNhap_DucAnh frDn;
        public String getMa()
        {
            return this.txtmanv.Text;
        }
        public void setfrm_DangNhap_DucAnh(frm_DangNhap_DucAnh form)
        {
            frDn = form;
        }
        private void PhanQuyenTabs(string quyen)
        {        

            foreach (TabPage tabPage in tabControl.TabPages)
            {
                tabControl.TabPages.Remove(tabPage);
            }
            switch (quyen)
            {

                case "Nhanvien":
                    tabControl.TabPages.Add(tabHSNV);
                    tabControl.TabPages.Add(tabLuong);
                    tabControl.SelectedTab = tabHSNV;
                    tabControl.Show();
                    hsnv.Frm_QuanLyHoSoNV_Load(txtmanv, txthoten,
             gioitinh, txt_sdt, txtqq, txtdiachi, dtpNgaySinh, txt_hsl, cbChucvu, cbPhongBan, cb_loaiND, manv);
                    break;
                case "GiamDoc":

                    tabControl.TabPages.Add(tabTrangChu);
                    tabControl.TabPages.Add(tabPhongBan);
                    tabControl.TabPages.Add(tabLuong);
                    tabControl.TabPages.Add(tabChamCong);
                    tabControl.TabPages.Add(tabHSNV);
                    tabControl.SelectedTab = tabTrangChu;
                    
                    tabControl.Show();
                    trangChu.ViewData(dgv_dsNV_Cuong, keyword.Text);
                    break;
                default:
                    break;
            }
        }
        public FmManHinhChinh()
        {
            InitializeComponent();
            DateTime dt = DateTime.Now.Add(new TimeSpan());
            lblDate.Text = String.Format("Hà nội ," + "{0:dd/MM/yyyy}", dt);

            this.PhanQuyenTabs(Program.loaiND);
        }

        private void FmManHinhChinh_Load(object sender, EventArgs e)
        {
            OnResize(e);
        }


        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);

            foreach (Control cnt in this.Controls)
                ResizeAll(cnt, base.Size);

            oldSize = base.Size;
        }
        private void ResizeAll(Control control, Size newSize)
        {
            int width = newSize.Width - oldSize.Width;
            control.Left += (control.Left * width) / oldSize.Width;
            control.Width += (control.Width * width) / oldSize.Width;

            int height = newSize.Height - oldSize.Height;
            control.Top += (control.Top * height) / oldSize.Height;
            control.Height += (control.Height * height) / oldSize.Height;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTabName = tabControl.SelectedTab.Name;
            switch (selectedTabName)
            {
                case "tabTrangChu":
                    trangChu.ViewData(dgv_dsNV_Cuong, keyword.Text);
                    break;
                case "tabChamCong":
                    chamCong.Frm_Chamcong_Load(cb_phong, cbManv);
                    break;
                case "tabLuong":
                    luong.FrmTienLuong_Load(cb_luong_phong);
                    luong.load_data_luong(dgv_Tienluong, cb_luong_phong, cb_luong_thang, cb_luong_nam);
                    break;
                case "tabPhongBan":
                    phong.Frm_QLPhong_Load(dgv_dsphong);
                    break;
                case "tabChucVu":
                    chucvu.Frm_QuanlyChucVu_Load(dgv_dsCV);
                    break;
                case "tabHSNV":
                    hsnv.Frm_QuanLyHoSoNV_Load(txtmanv, txthoten,
             gioitinh, txt_sdt, txtqq, txtdiachi, dtpNgaySinh, txt_hsl, cbChucvu, cbPhongBan,cb_loaiND, manv);
                    break;


            }
        }

        //Chấm công
        ChamCong chamCong = new ChamCong();
        private void bt_CCong_Cuong_Click(object sender, EventArgs e)
        {
            chamCong.CCong_Click(dgv_bangccong, cbPhongBan, cbManv, cb_Thang, cb_nam, txtSongaylv);
        }

        private void cb_phong_SelectedIndexChanged(object sender, EventArgs e)
        {
            chamCong.cb_phong_SelectedIndexChanged(dgv_bangccong, cbPhongBan, cbManv, cb_Thang, cb_nam);
        }

        private void cb_Thang_SelectedIndexChanged(object sender, EventArgs e)
        {
            chamCong.cb_Thang_SelectedIndexChanged(dgv_bangccong, cbPhongBan, cbManv, cb_Thang, cb_nam);
        }

        private void cbManv_SelectedIndexChanged(object sender, EventArgs e)
        {
            chamCong.cbManv_SelectedIndexChanged(dgv_bangccong, cbPhongBan, cbManv, cb_Thang, cb_nam);
        }

        private void cb_nam_SelectedIndexChanged(object sender, EventArgs e)
        {
            chamCong.cb_nam_SelectedIndexChanged(dgv_bangccong, cbPhongBan, cbManv, cb_Thang, cb_nam);
        }

        private void dgv_bangccong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            chamCong.dataGridView1_CellContentClick(dgv_bangccong, cbManv, cb_Thang);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            chamCong.button1_Click(dgv_bangccong);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            chamCong.btnXoa_Click(dgv_bangccong, cbPhongBan, cbManv, cb_Thang, cb_nam, txtSongaylv);
        }


        //Lương
        Luong luong = new Luong();
        private void btn_LuongNVtheoPhong_Click(object sender, EventArgs e)
        {
            luong.TongLuongTheoPhong(cb_luong_phong, cb_luong_thang, cb_luong_nam, txt_kq);
        }

        private void btn_Thue_Click(object sender, EventArgs e)
        {
            luong.btn_Thue_Click(dgv_Tienluong, cb_luong_phong, cb_luong_thang, cb_luong_nam, txt_kq);
        }

        private void btn_TongluongcaCTy_Click(object sender, EventArgs e)
        {
            luong.btn_TongluongcaCTy_Click(cb_luong_phong, cb_luong_thang, cb_luong_nam, txt_kq);
        }

        private void btn_TongluongcuaPhong_Click(object sender, EventArgs e)
        {
            luong.TongLuongTheoPhong(cb_luong_phong, cb_luong_thang, cb_luong_nam, txt_kq);
        }

        private void btnXuatBangLuong_Click(object sender, EventArgs e)
        {
            luong.ExportExcelLuong(dgv_Tienluong, cb_luong_phong, cb_luong_thang, cb_luong_nam, txt_kq);
        }

        private void btnXuatThue_Click(object sender, EventArgs e)
        {
            luong.ExportExcelThue(dgv_Tienluong, cb_luong_phong, cb_luong_thang, cb_luong_nam);
        }
        private void cb_luong_thang_SelectedIndexChanged(object sender, EventArgs e)
        {
            luong.load_data_luong(dgv_Tienluong, cb_luong_phong, cb_luong_thang, cb_luong_nam);
        }
        private void cb_luong_nam_SelectedIndexChanged(object sender, EventArgs e)
        {
            luong.load_data_luong(dgv_Tienluong, cb_luong_phong, cb_luong_thang, cb_luong_nam);
        }

        //Chức vụ
        ChucVu chucvu = new ChucVu();
        private void btn_CV_them_Click(object sender, EventArgs e)
        {
            chucvu.createBy(dgv_dsCV, tb_macv, tb_tencv, tb_hsopc);
        }

        private void btn_CV_sua_Click(object sender, EventArgs e)
        {
            chucvu.updateBy(dgv_dsCV, tb_tencv, tb_hsopc);
        }

        private void btn_CV_xoa_Click(object sender, EventArgs e)
        {
            chucvu.deleteBy(dgv_dsCV);
        }

        private void dgv_dsCV_SelectionChanged(object sender, EventArgs e)
        {
            chucvu.dataGridView1_SelectionChanged(dgv_dsCV, tb_macv, tb_tencv, tb_hsopc);
        }

        //Phòng ban
        PhongBan phong = new PhongBan();
        private void btn_phong_them_Click(object sender, EventArgs e)
        {
            phong.createBy(dgv_dsphong, tb_maphong, tb_tenphong, tb_diachiphong, tb_sdt);
        }

        private void btn_phong_sua_Click(object sender, EventArgs e)
        {
            phong.updateBy(dgv_dsphong, tb_maphong, tb_tenphong, tb_diachiphong, tb_sdt);
        }

        private void btn_phong_xoa_Click(object sender, EventArgs e)
        {
            phong.deleteBy(dgv_dsphong);
        }

        private void dgv_dsphong_SelectionChanged(object sender, EventArgs e)
        {
            phong.dataGridView1_SelectionChanged(dgv_dsphong, tb_maphong, tb_tenphong, tb_diachiphong, tb_sdt);
        }

        // Chi tiết hồ sơ
        Hsnv hsnv = new Hsnv();
        private void cbChucvu_DropDown(object sender, EventArgs e)
        {
            hsnv.cb_maCV_DropDown(cbChucvu);
        }

        private void cbPhongBan_DropDown(object sender, EventArgs e)
        {
            hsnv.cbPhongBan_DropDown(cbPhongBan);
        }

        private void dgv_dsNV_Cuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            trangChu.selected_data(dgv_dsNV_Cuong);
        }

        private void btn_trangchu_them_Click(object sender, EventArgs e)
        {
            Frm_QuanLyHoSoNV_Cuong fm = new Frm_QuanLyHoSoNV_Cuong();
            fm.iscreate = true;
            DialogResult dialog = fm.ShowDialog();

        }

        private void btnToolStripSignOut_Click(object sender, EventArgs e)
        {
            this.Close();

            if (Application.OpenForms["FmManHinhChinh"] == null)
            {
                frm_DangNhap_DucAnh loginForm = new frm_DangNhap_DucAnh();
                loginForm.Show();
            }
        }

        private void btn_canhan_sua_Click(object sender, EventArgs e)
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
                gioitinh = "Nữ";
                // Thực hiện công việc khác tương ứng với giới tính Nữ
            }
            hsnv.saveOrUpdateHSNV(txthoten, gioitinh, ngay,
             txtdiachi, txtqq, false, txtmanv, cbChucvu, cbPhongBan, cb_loaiND, txt_hsl);
            MessageBox.Show("Sửa thành công !");
        }

        private void btn_hsnv_huy_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabTrangChu;
        }

        private void btnToolStripResetPass_Click(object sender, EventArgs e)
        {
            Frm_DoiMK_DucAnh fm = new Frm_DoiMK_DucAnh();
            fm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            trangChu.ViewData(dgv_dsNV_Cuong, keyword.Text);
        }
    }
}
