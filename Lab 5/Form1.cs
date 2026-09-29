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
        // Lớp Khóa học
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

            // Mặc định chọn khóa học đầu tiên
            if (cboKhoaHoc.Items.Count > 0)
                cboKhoaHoc.SelectedIndex = 0;

            // Mặc định chọn hình thức Online và số tháng là 1
            radOnline.Checked = true;
            numSoThang.Value = 1;

            // Tính học phí ban đầu
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
            // 1. Kiểm tra họ tên
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

            // 2. Kiểm tra SĐT
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
                "========================================\n" +
                "           PHIẾU ĐĂNG KÝ KHÓA HỌC           \n" +
                "========================================\n\n" +
                $"• Họ và tên:\t\t{txtHoTen.Text.Trim()}\n" +
                $"• Số điện thoại:\t\t{txtSoDienThoai.Text.Trim()}\n" +
                $"• Ngày sinh:\t\t{dtpNgaySinh.Value:dd/MM/yyyy}\n" +
                $"• Khóa học:\t\t{cboKhoaHoc.Text}\n" +
                $"• Hình thức:\t\t{hinhThuc}\n" +
                $"• Số tháng:\t\t{numSoThang.Value} tháng\n" +
                $"• Nhận email:\t\t{email}\n\n" +
                "----------------------------------------\n" +
                $"► TỔNG HỌC PHÍ:\t{lblTongTien.Text}\n" +
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

       

        // Các hàm sự kiện phụ giữ lại để tránh lỗi biên dịch nếu file Designer đang gọi
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