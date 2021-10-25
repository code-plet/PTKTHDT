using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;


namespace HRM_VTHP.HeThong
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult hoi;
            hoi = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.Yes)
            this.Close();
        }


        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            string sql = "";
            sql = "Select NguoiDungID from NguoiDung where TenDangNhap = '"+ txtTenDangNhap.Text +"' and MatKhau = '"+ txtMatKhau.Text +"'";
            DataTable dt = Core.Core.GetData(sql);
            if(txtTenDangNhap.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập");
            }
            else if(txtMatKhau.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu");
            }
            else if (dt.Rows.Count > 0)
            {
                string NguoiDungID = dt.Rows[0]["NguoiDungID"].ToString();
                frmMainForm frm = new frmMainForm(NguoiDungID);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khỏan, mật khẩu");
                txtTenDangNhap.Focus();
            }
        }
    }
}