using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lab_6
{
    public partial class FrmProduct : Form
    {
        private BindingList<Product> listProducts = new BindingList<Product>();
        private BindingSource bindingSource = new BindingSource();
        private bool isEditing = false;

        public FrmProduct()
        {
            InitializeComponent();
            this.FormClosing += FrmProduct_FormClosing;

            cboLoaiSP.Items.AddRange(new object[] { "Điện tử", "Văn phòng phẩm", "Gia dụng", "Thời trang" });

            listProducts.Add(new Product("SP01", "Chuột Logitech G102", "Điện tử", 420000m, 25, DateTime.Now.AddDays(-10), true));
            listProducts.Add(new Product("SP02", "Bút ký Parker", "Văn phòng phẩm", 350000m, 15, DateTime.Now.AddDays(-5), true));
            listProducts.Add(new Product("SP03", "Bình giữ nhiệt Lock&Lock", "Gia dụng", 280000m, 40, DateTime.Now.AddDays(-2), true));

            bindingSource.DataSource = listProducts;
            dgvProducts.DataSource = bindingSource;

            if (dgvProducts.Columns["DonGia"] != null)
                dgvProducts.Columns["DonGia"].DefaultCellStyle.Format = "#,##0 VNĐ";
            if (dgvProducts.Columns["DuongDanAnh"] != null)
                dgvProducts.Columns["DuongDanAnh"].Visible = false;

            ClearInput();
        }

        // 1. Bắt lỗi nhập liệu
        private bool ValidateInput()
        {
            errorProvider1.Clear();
            bool ok = true;
            string ma = txtMaSP.Text.Trim();

            if (string.IsNullOrEmpty(ma))
            {
                errorProvider1.SetError(txtMaSP, "Không để trống mã!");
                ok = false;
            }
            else if (!isEditing && listProducts.Any(p => p.MaSP.Equals(ma, StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider1.SetError(txtMaSP, "Mã sản phẩm đã tồn tại!");
                ok = false;
            }

            if (string.IsNullOrEmpty(txtTenSP.Text.Trim()))
            {
                errorProvider1.SetError(txtTenSP, "Không để trống tên!");
                ok = false;
            }
            if (numDonGia.Value <= 0)
            {
                errorProvider1.SetError(numDonGia, "Đơn giá phải > 0!");
                ok = false;
            }
            if (dtpNgayNhap.Value.Date > DateTime.Now.Date)
            {
                errorProvider1.SetError(dtpNgayNhap, "Ngày không vượt quá hiện tại!");
                ok = false;
            }

            return ok;
        }

        // 2. Thêm mới
        private void btnThem_Click(object sender, EventArgs e)
        {
            isEditing = false;
            if (!ValidateInput()) return;

            Product p = new Product(txtMaSP.Text.Trim().ToUpper(), txtTenSP.Text.Trim(), cboLoaiSP.SelectedItem.ToString(),
                                    numDonGia.Value, (int)numSoLuong.Value, dtpNgayNhap.Value, chkConKinhDoanh.Checked, txtDuongDanAnh.Text);
            listProducts.Add(p);
            ClearInput();
            UpdateStatus("Đã thêm: " + p.TenSP);
        }

        // 3. Cập nhật
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;
            Product p = dgvProducts.CurrentRow.DataBoundItem as Product;
            if (p == null) return;

            isEditing = true;
            if (!ValidateInput()) return;

            p.TenSP = txtTenSP.Text.Trim();
            p.LoaiSP = cboLoaiSP.SelectedItem.ToString();
            p.DonGia = numDonGia.Value;
            p.SoLuong = (int)numSoLuong.Value;
            p.NgayNhap = dtpNgayNhap.Value;
            p.ConKinhDoanh = chkConKinhDoanh.Checked;
            p.DuongDanAnh = txtDuongDanAnh.Text;

            bindingSource.ResetBindings(false);
            ClearInput();
            UpdateStatus("Đã cập nhật: " + p.TenSP);
        }

        // 4. Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;
            Product p = dgvProducts.CurrentRow.DataBoundItem as Product;
            if (p == null) return;

            if (MessageBox.Show($"Xác nhận xóa [{p.TenSP}]?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                listProducts.Remove(p);
                ClearInput();
                UpdateStatus("Đã xóa: " + p.TenSP);
            }
        }

        // 5. Tìm kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string kw = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(kw))
            {
                bindingSource.DataSource = listProducts;
            }
            else
            {
                var filtered = listProducts.Where(p =>
                    p.MaSP.IndexOf(kw, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    p.TenSP.IndexOf(kw, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                bindingSource.DataSource = new BindingList<Product>(filtered);
            }
            UpdateStatus("Tìm thấy: " + bindingSource.Count + " kết quả");
        }

        // 6. Chọn và hiển thị ảnh
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "Ảnh (*.jpg;*.png)|*.jpg;*.png" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtDuongDanAnh.Text = ofd.FileName;
                    picAnh.ImageLocation = ofd.FileName;
                }
            }
        }

        // 7. Nhấp chọn dòng trên bảng
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;
            Product p = dgvProducts.CurrentRow.DataBoundItem as Product;
            if (p == null) return;

            txtMaSP.Text = p.MaSP;
            txtMaSP.ReadOnly = true;
            txtTenSP.Text = p.TenSP;
            cboLoaiSP.SelectedItem = p.LoaiSP;
            numDonGia.Value = p.DonGia;
            numSoLuong.Value = p.SoLuong;
            dtpNgayNhap.Value = p.NgayNhap;
            chkConKinhDoanh.Checked = p.ConKinhDoanh;
            txtDuongDanAnh.Text = p.DuongDanAnh;
            picAnh.ImageLocation = File.Exists(p.DuongDanAnh) ? p.DuongDanAnh : null;
            isEditing = true;
        }

        // 8. Xem chi tiết
        private void ShowDetail_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;
            Product p = dgvProducts.CurrentRow.DataBoundItem as Product;
            if (p != null)
                MessageBox.Show($"Mã: {p.MaSP}\nTên: {p.TenSP}\nLoại: {p.LoaiSP}\nĐơn giá: {p.DonGia:N0} VNĐ\nSố lượng: {p.SoLuong}", "Chi tiết");
        }

        // 9. Làm mới form
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();
            bindingSource.DataSource = listProducts;
            UpdateStatus("Sẵn sàng");
        }

        private void ClearInput()
        {
            txtMaSP.Clear();
            txtMaSP.ReadOnly = false;
            txtTenSP.Clear();
            if (cboLoaiSP.Items.Count > 0) cboLoaiSP.SelectedIndex = 0;
            numDonGia.Value = 10000;
            numSoLuong.Value = 1;
            dtpNgayNhap.Value = DateTime.Now;
            chkConKinhDoanh.Checked = true;
            txtDuongDanAnh.Clear();
            picAnh.ImageLocation = null;
            errorProvider1.Clear();
            isEditing = false;
        }

        private void UpdateStatus(string msg)
        {
            lblStatus.Text = "Trạng thái: " + msg;
            lblCount.Text = $"Tổng: {listProducts.Count} SP";
        }

        // 10. Sự kiện xác nhận khi đóng Form
        private void FrmProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show(
                "Bạn có thực sự muốn thoát chương trình không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (res == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}