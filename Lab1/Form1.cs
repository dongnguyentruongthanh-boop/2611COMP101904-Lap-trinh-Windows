using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboKhoa.Items.Add("Công nghệ thông tin");
            cboKhoa.Items.Add("Công nghệ giáo dục");
            cboKhoa.Items.Add("Sư phạm Tin học");  
            cboKhoa.SelectedIndex = -1;
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo");
                txtHoTen.Focus();
                return;
            }
            if (txtNamSinh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập năm sinh!", "Thông báo");
                txtNamSinh.Focus();
                return;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Vui lòng nhập email!", "Thông báo");
                txtEmail.Focus();
                return;
            }
            if (radNam.Checked == false && radNu.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Thông báo");
                return;
            }
            if (cboKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Khoa!", "Thông báo");
                return;
            }

            // Tính tuổi
            int namSinh = 0;
            try
            {
                namSinh = int.Parse(txtNamSinh.Text);
            }
            catch
            {
                MessageBox.Show("Năm sinh phải là số nguyên!", "Lỗi");
                txtNamSinh.Focus();
                return;
            }
            int tuoi = DateTime.Now.Year - namSinh;

           
            string gioiTinh = "";
            if (radNam.Checked == true) gioiTinh = "Nam";
            else if (radNu.Checked == true) gioiTinh = "Nữ";

            
            string ketQua = "THÔNG TIN SINH VIÊN\n\n";
            ketQua = ketQua + "Họ và tên: " + txtHoTen.Text + "\n";
            ketQua = ketQua + "Tuổi: " + tuoi.ToString() + "\n";
            ketQua = ketQua + "Email: " + txtEmail.Text + "\n";
            ketQua = ketQua + "Giới tính: " + gioiTinh + "\n";
            ketQua = ketQua + "Khoa: " + cboKhoa.SelectedItem.ToString();

            lblKetQua.Text = ketQua;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = "";
            txtNamSinh.Text = "";
            txtEmail.Text = "";
            radNam.Checked = false;
            radNu.Checked = false;
            cboKhoa.SelectedIndex = -1;
            lblKetQua.Text = "";
            txtHoTen.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult luaChon = MessageBox.Show("Bạn có thực sự muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (luaChon == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
