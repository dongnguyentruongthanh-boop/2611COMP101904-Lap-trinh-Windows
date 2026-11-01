using System.Data;
using QLSinhVienLab12.DAL;

namespace QLSinhVienLab12.Forms
{
    public partial class FrmNhapDiemTheoLop : Form
    {
        private readonly KetQuaDAL ketQuaDAL = new KetQuaDAL();
        private readonly BindingSource ketQuaSource = new BindingSource();

        public FrmNhapDiemTheoLop()
        {
            InitializeComponent();
        }

        // Chuc nang 1: mo form la load lop va mon hoc vao ComboBox
        private void FrmNhapDiemTheoLop_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComboBox();
                dgvKetQua.AutoGenerateColumns = true;
                dgvKetQua.DataSource = ketQuaSource;
                lblTrangThai.Text = "Chọn lớp, môn học rồi bấm Tải danh sách";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được database: " + ex.Message);
                lblTrangThai.Text = "Lỗi kết nối database";
            }
        }

        private void LoadComboBox()
        {
            cboLop.DataSource = ketQuaDAL.GetLop();
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";

            cboMonHoc.DataSource = ketQuaDAL.GetMonHoc();
            cboMonHoc.DisplayMember = "TenMon";
            cboMonHoc.ValueMember = "MaMon";
        }

        // Chuc nang 2: tai danh sach sinh vien
        private void btnTaiDanhSach_Click(object sender, EventArgs e)
        {
            string maLop = cboLop.SelectedValue?.ToString() ?? "";
            string maMon = cboMonHoc.SelectedValue?.ToString() ?? "";

            if (maLop.Length == 0 || maMon.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp và môn học.");
                return;
            }

            try
            {
                DataTable table = ketQuaDAL.GetKetQuaByLopMon(maLop, maMon);
                ketQuaSource.DataSource = table;
                FormatGrid();
                lblTrangThai.Text = "Đã tải " + table.Rows.Count + " sinh viên";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được danh sách: " + ex.Message);
            }
        }

        // Chi cho sua cot Diem va GhiChu, hai cot con lai chi xem
        private void FormatGrid()
        {
            dgvKetQua.Columns["MaSV"].HeaderText = "Mã SV";
            dgvKetQua.Columns["HoTen"].HeaderText = "Họ tên";
            dgvKetQua.Columns["Diem"].HeaderText = "Điểm";
            dgvKetQua.Columns["GhiChu"].HeaderText = "Ghi chú";

            dgvKetQua.Columns["MaSV"].ReadOnly = true;
            dgvKetQua.Columns["HoTen"].ReadOnly = true;
        }

        // Chuc nang 5, 6, 7: luu tat ca bang transaction
        private void btnLuuTatCa_Click(object sender, EventArgs e)
        {
            try
            {
                if (ketQuaSource.DataSource is not DataTable)
                {
                    MessageBox.Show("Vui lòng tải danh sách sinh viên trước.");
                    return;
                }

                ketQuaSource.EndEdit(); // day gia tri dang sua tren grid ve DataTable
                DataTable table = (DataTable)ketQuaSource.DataSource;

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để lưu.");
                    return;
                }

                ValidateData(table);

                string maMon = cboMonHoc.SelectedValue?.ToString() ?? "";
                int count = ketQuaDAL.SaveAll(maMon, table);

                lblTrangThai.Text = "Đã lưu " + count + " dòng";
                MessageBox.Show($"Đã lưu thành công {count} dòng.");
            }
            catch (Exception ex)
            {
                lblTrangThai.Text = "Lưu thất bại";
                MessageBox.Show("Không thể lưu dữ liệu: " + ex.Message);
            }
        }

        // Chuc nang 4: kiem tra diem khong rong, la so, tu 0 den 10
        private void ValidateData(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                string maSV = row["MaSV"].ToString() ?? "";
                string diemText = row["Diem"].ToString() ?? "";

                if (!double.TryParse(diemText, out double diem))
                    throw new Exception($"Điểm của sinh viên {maSV} không hợp lệ.");

                if (diem < 0 || diem > 10)
                    throw new Exception($"Điểm của sinh viên {maSV} phải từ 0 đến 10.");
            }
        }

        // Neu go chu vao o diem thi grid tu bao loi, ta hien thong bao de hieu hon
        private void dgvKetQua_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Giá trị nhập không hợp lệ. Điểm phải là số từ 0 đến 10 (nhấn Esc để hủy ô đang sửa).");
            e.ThrowException = false;
        }
    }
}
