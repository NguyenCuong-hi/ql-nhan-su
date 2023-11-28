using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_NvCuong_DdAnh_HntAnh_BTLLTNET
{
    public partial class Frm_GTNhom1_TuanAnh : Form
    {
        public Frm_GTNhom1_TuanAnh()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frm_DangNhap_DucAnh f = new frm_DangNhap_DucAnh();
            f.ShowDialog();
            //this.Show();
        }
    }
}
