using System.Globalization;
using System.Text;
using StudentReportDemo.Models;

namespace StudentReportDemo.Forms
{
    public partial class FrmBaoCaoSinhVien : Form
    {
        // du lieu goc
        private List<SinhVien> danhSachSinhVien = new List<SinhVien>();

        // ket qua dang hien thi tren grid (dung lai khi xuat file)
        private List<object> duLieuDangHienThi = new List<object>();

        // true khi form dang khoi tao: luc nay cac su kien combobox/textbox chua nen chay bao cao
        private bool dangKhoiTao = true;

        public FrmBaoCaoSinhVien()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoSinhVien_Load(object sender, EventArgs e)
        {
            TaoDuLieuMau();
            LoadComboBox();
            dangKhoiTao = false;
            XemBaoCao(false);
        }

        // ---------- Du lieu mau ----------

        private void TaoDuLieuMau()
        {
            danhSachSinhVien = new List<SinhVien>
            {
                new SinhVien { MaSV = "SV001", HoTen = "Nguyễn Văn An",     MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 8.2 },
                new SinhVien { MaSV = "SV002", HoTen = "Trần Thị Bình",     MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 6.5 },
                new SinhVien { MaSV = "SV003", HoTen = "Lê Minh Cường",     MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 4.8 },
                new SinhVien { MaSV = "SV004", HoTen = "Phạm Thanh Dung",   MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 9.1 },
                new SinhVien { MaSV = "SV005", HoTen = "Hoàng Quốc Huy",    MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 7.4 },
                new SinhVien { MaSV = "SV006", HoTen = "Võ Gia Khang",      MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 3.9 },
                new SinhVien { MaSV = "SV007", HoTen = "Đặng Minh Khôi",    MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 5.5 },
                new SinhVien { MaSV = "SV008", HoTen = "Bùi Thảo Linh",     MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 8.0 },
                new SinhVien { MaSV = "SV009", HoTen = "Ngô Tuấn Minh",     MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 6.0 },
                new SinhVien { MaSV = "SV010", HoTen = "Đỗ Bảo Ngọc",       MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 9.3 },
                new SinhVien { MaSV = "SV011", HoTen = "Huỳnh Gia Phúc",    MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 4.2 },
                new SinhVien { MaSV = "SV012", HoTen = "Mai Anh Thư",       MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 7.8 }
            };
        }

        // ---------- ComboBox ----------

        private void LoadComboBox()
        {
            // lay danh sach lop khong trung bang Select + Distinct
            var dsLop = danhSachSinhVien
                .Select(sv => new { sv.MaLop, sv.TenLop })
                .Distinct()
                .OrderBy(lop => lop.MaLop)
                .ToList();

            cboLop.DataSource = dsLop;
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";

            cboKetQua.Items.Clear();
            cboKetQua.Items.Add("Tất cả");
            cboKetQua.Items.Add("Đạt");
            cboKetQua.Items.Add("Không đạt");
            cboKetQua.SelectedIndex = 0;
        }

        // ---------- Xem bao cao ----------

        // hienThongBao = true khi bam nut (hien MessageBox neu rong)
        // false khi bao cao tu cap nhat luc doi lop / go tu khoa (chi bao tren label, khong bat hop thoai moi phim)
        private void XemBaoCao(bool hienThongBao)
        {
            if (cboLop.SelectedValue == null) return;

            string maLop = cboLop.SelectedValue.ToString();
            string ketQua = cboKetQua.SelectedItem?.ToString() ?? "Tất cả";
            string tuKhoa = txtTuKhoa.Text.Trim().ToLower();

            // loc theo lop
            var query = danhSachSinhVien.Where(sv => sv.MaLop == maLop);

            // loc theo ket qua
            if (ketQua == "Đạt")
            {
                query = query.Where(sv => sv.Diem >= 5);
            }
            else if (ketQua == "Không đạt")
            {
                query = query.Where(sv => sv.Diem < 5);
            }

            // loc theo tu khoa (ma hoac ho ten)
            if (!string.IsNullOrWhiteSpace(tuKhoa))
            {
                query = query.Where(sv =>
                    sv.MaSV.ToLower().Contains(tuKhoa) ||
                    sv.HoTen.ToLower().Contains(tuKhoa));
            }

            // sap xep giam dan theo diem, bang diem thi theo ten
            var baoCao = query
                .OrderByDescending(sv => sv.Diem)
                .ThenBy(sv => sv.HoTen)
                .Select(sv => new
                {
                    sv.MaSV,
                    sv.HoTen,
                    sv.TenLop,
                    sv.Diem,
                    sv.KetQua
                })
                .ToList();

            dgvBaoCao.DataSource = baoCao;
            DatTieuDeCot();
            duLieuDangHienThi = baoCao.Cast<object>().ToList();

            CapNhatThongKe(baoCao.Count);

            if (baoCao.Count == 0)
            {
                lblThongKe.Text += "  -  Không có dữ liệu phù hợp";
                if (hienThongBao)
                {
                    MessageBox.Show("Không có dữ liệu phù hợp.");
                }
            }
        }

        // ---------- Thong ke tren label ----------

        private void CapNhatThongKe(int soDongHienThi)
        {
            string maLop = cboLop.SelectedValue?.ToString() ?? "";

            var dsLop = danhSachSinhVien
                .Where(sv => sv.MaLop == maLop)
                .ToList();

            int tongSo = dsLop.Count;
            int soDat = dsLop.Count(sv => sv.Diem >= 5);
            int soKhongDat = dsLop.Count(sv => sv.Diem < 5);
            // tranh loi khi tinh Average tren danh sach rong
            double diemTB = tongSo > 0 ? dsLop.Average(sv => sv.Diem) : 0;

            lblThongKe.Text = $"Đang hiển thị: {soDongHienThi} | " +
                              $"Tổng lớp: {tongSo} | Đạt: {soDat} | " +
                              $"Không đạt: {soKhongDat} | ĐTB: {diemTB:0.00}";
        }

        // ---------- Thong ke theo lop (GroupBy) ----------

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            var thongKe = danhSachSinhVien
                .GroupBy(sv => new { sv.MaLop, sv.TenLop })
                .Select(g => new
                {
                    g.Key.MaLop,
                    g.Key.TenLop,
                    SoLuong = g.Count(),
                    SoDat = g.Count(sv => sv.Diem >= 5),
                    SoKhongDat = g.Count(sv => sv.Diem < 5),
                    DiemTrungBinh = Math.Round(g.Average(sv => sv.Diem), 2)
                })
                .OrderBy(x => x.MaLop)
                .ToList();

            dgvBaoCao.DataSource = thongKe;
            DatTieuDeCot();
            duLieuDangHienThi = thongKe.Cast<object>().ToList();

            lblThongKe.Text = "Thống kê theo lớp (" + thongKe.Count + " lớp)";
        }

        // Doi tieu de cot sang tieng Viet (cot nao khong co thi bo qua)
        private void DatTieuDeCot()
        {
            var tieuDe = new Dictionary<string, string>
            {
                { "MaSV", "Mã SV" },
                { "HoTen", "Họ tên" },
                { "TenLop", "Tên lớp" },
                { "Diem", "Điểm" },
                { "KetQua", "Kết quả" },
                { "MaLop", "Mã lớp" },
                { "SoLuong", "Số lượng" },
                { "SoDat", "Số đạt" },
                { "SoKhongDat", "Số không đạt" },
                { "DiemTrungBinh", "Điểm TB" }
            };

            foreach (DataGridViewColumn col in dgvBaoCao.Columns)
            {
                if (tieuDe.ContainsKey(col.Name))
                {
                    col.HeaderText = tieuDe[col.Name];
                }
            }
        }

        // ---------- Xuat file CSV / TXT ----------

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            if (dgvBaoCao.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.");
                return;
            }

            XuatFile();
        }

        private void XuatFile()
        {
            using SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV file (*.csv)|*.csv|Text file (*.txt)|*.txt";
            sfd.FileName = "BaoCaoSinhVien.csv";

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                StringBuilder sb = new StringBuilder();

                // dong tieu de
                for (int i = 0; i < dgvBaoCao.Columns.Count; i++)
                {
                    sb.Append(dgvBaoCao.Columns[i].HeaderText);
                    if (i < dgvBaoCao.Columns.Count - 1) sb.Append(",");
                }
                sb.AppendLine();

                // cac dong du lieu
                foreach (DataGridViewRow row in dgvBaoCao.Rows)
                {
                    if (row.IsNewRow) continue;

                    for (int i = 0; i < dgvBaoCao.Columns.Count; i++)
                    {
                        object cell = row.Cells[i].Value;

                        // so thi doi sang dang chuan (dau cham) de khong bi lan voi dau phay phan cach cot
                        string value = cell is IFormattable so
                            ? so.ToString(null, CultureInfo.InvariantCulture)
                            : cell?.ToString() ?? "";

                        value = value.Replace(",", " ");
                        sb.Append(value);
                        if (i < dgvBaoCao.Columns.Count - 1) sb.Append(",");
                    }
                    sb.AppendLine();
                }

                File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                MessageBox.Show("Xuất file thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file: " + ex.Message);
            }
        }

        // ---------- Cac su kien tu cap nhat ----------

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            XemBaoCao(true);
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangKhoiTao) return;
            XemBaoCao(false);
        }

        private void cboKetQua_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangKhoiTao) return;
            XemBaoCao(false);
        }

        private void txtTuKhoa_TextChanged(object sender, EventArgs e)
        {
            if (dangKhoiTao) return;
            XemBaoCao(false);
        }
    }
}
