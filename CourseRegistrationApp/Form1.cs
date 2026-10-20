using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CourseRegistrationApp
{
    public partial class dangKyKhoaHoc : Form
    {
       
        public class KhoaHoc
        {
            public string TenKhoaHoc { get; }
            public decimal HocPhi { get; }

            public KhoaHoc(string ten, decimal hocPhi)
            {
                TenKhoaHoc = ten;
                HocPhi = hocPhi;
            }

            public override string ToString()
            {
                return TenKhoaHoc;
            }
        }

        public dangKyKhoaHoc()
        {
            this.ResizeRedraw = true;
            InitializeComponent();
        }

        private void dangKyKhoaHoc_Load(object sender, EventArgs e)
        {
            cboKhoaHoc.Items.Clear();
            cboKhoaHoc.Items.Add(new KhoaHoc("C# WinForms cơ bản", 800000));
            cboKhoaHoc.Items.Add(new KhoaHoc("SQL Server cơ bản", 700000));
            cboKhoaHoc.Items.Add(new KhoaHoc("Web Frontend cơ bản", 750000));
            cboKhoaHoc.Items.Add(new KhoaHoc("Lập trình Python cơ bản", 650000));

            
            if (cboKhoaHoc.Items.Count > 0)
                cboKhoaHoc.SelectedIndex = 0;

            
            radOnline.Checked = true;
            numSoThang.Value = 1;

            
            TinhHocPhi();
        }

        private void TinhHocPhi()
        {
            if (cboKhoaHoc.SelectedItem is KhoaHoc kh)
            {
                decimal tongTien = kh.HocPhi * numSoThang.Value;
                lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
            }
        }

        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhHocPhi();
        }

        private void numSoThang_ValueChanged(object sender, EventArgs e)
        {
            TinhHocPhi();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
          
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }
            if (txtHoTen.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Họ tên không được chứa chữ số!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            
            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }
            if (txtSoDienThoai.Text.Trim().Length != 10)
            {
                MessageBox.Show("Số điện thoại phải có đúng 10 chữ số!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }
            if (!txtSoDienThoai.Text.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại chỉ được bao gồm các chữ số!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }

            // 3. Kiểm tra khóa học
            if (cboKhoaHoc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn khóa học!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Kiểm tra ngày sinh
            if (dtpNgaySinh.Value.Date >= DateTime.Today)
            {
                MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Focus();
                return;
            }

            string hinhThuc = radOnline.Checked ? "Online" : "Trực tiếp";
            string email = chkNhanEmail.Checked ? "Có" : "Không";

            // Hiển thị thông tin đăng ký
            string thongTin =
                    "=======================================\n" +
                  "             THÔNG TIN ĐĂNG KÝ KHÓA HỌC        \n" +
                  "=======================================\n\n" +
                  $"* Họ và tên    : {txtHoTen.Text.Trim()}\n" +
                  $"* Điện thoại   : {txtSoDienThoai.Text.Trim()}\n" +
                  $"* Ngày sinh    : {dtpNgaySinh.Value:dd/MM/yyyy}\n" +
                  $"* Khóa học     : {cboKhoaHoc.Text}\n" +
                  $"* Hình thức    : {hinhThuc}\n" +
                  $"* Thời gian    : {numSoThang.Value} tháng\n" +
                  $"* Nhận email   : {email}\n\n" +
                  "----------------------------------------\n" +
                  $"==> TỔNG TIỀN  : {lblTongTien.Text}\n" +
                  "========================================";

            MessageBox.Show(thongTin, "Phiếu đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            dtpNgaySinh.Value = DateTime.Today;
            chkNhanEmail.Checked = false;

            if (cboKhoaHoc.Items.Count > 0)
                cboKhoaHoc.SelectedIndex = 0;

            radOnline.Checked = true;
            numSoThang.Value = 1;

            TinhHocPhi();
            txtHoTen.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn thoát?",
                "Xác Nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

       

        
        private void label1_Click(object sender, EventArgs e) { }
        private void lbldangKyKhoaHoc_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void grpKhoaHoc_Enter(object sender, EventArgs e) { }
        private void lblTongTien_Click(object sender, EventArgs e) { }
        private void chkNhanEmail_CheckedChanged(object sender, EventArgs e) { }


        private void dangKyKhoaHoc_Paint(object sender, PaintEventArgs e)
        {

            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(230, 242, 255),  
                Color.FromArgb(245, 245, 250),  
                90F))                           
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}