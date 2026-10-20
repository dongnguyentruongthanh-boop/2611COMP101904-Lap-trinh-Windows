namespace Lab_6
{
    partial class FrmProduct 
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLamMoi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanLy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSua = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTroGiup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGioiThieu = new System.Windows.Forms.ToolStripMenuItem();

            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnToolThem = new System.Windows.Forms.ToolStripButton();
            this.btnToolSua = new System.Windows.Forms.ToolStripButton();
            this.btnToolXoa = new System.Windows.Forms.ToolStripButton();
            this.btnToolLamMoi = new System.Windows.Forms.ToolStripButton();

            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.lblMaSP = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.lblLoaiSP = new System.Windows.Forms.Label();
            this.cboLoaiSP = new System.Windows.Forms.ComboBox();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.numDonGia = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lblNgayNhap = new System.Windows.Forms.Label();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.chkConKinhDoanh = new System.Windows.Forms.CheckBox();
            this.lblDuongDanAnh = new System.Windows.Forms.Label();
            this.txtDuongDanAnh = new System.Windows.Forms.TextBox();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.picAnh = new System.Windows.Forms.PictureBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();

            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnHuyTim = new System.Windows.Forms.Button();

            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.contextMenuDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxXemChiTiet = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxSua = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxXoa = new System.Windows.Forms.ToolStripMenuItem();

            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);


            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuHeThong, this.mnuQuanLy, this.mnuTroGiup });
            this.mnuHeThong.Text = "Hệ thống";
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuLamMoi, this.mnuThoat });
            this.mnuLamMoi.Text = "Làm mới";
            this.mnuLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler((s, e) => this.Close());

            this.mnuQuanLy.Text = "Quản lý";
            this.mnuQuanLy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuThem, this.mnuSua, this.mnuXoa });
            this.mnuThem.Text = "Thêm";
            this.mnuThem.Click += new System.EventHandler(this.btnThem_Click);
            this.mnuSua.Text = "Sửa";
            this.mnuSua.Click += new System.EventHandler(this.btnSua_Click);
            this.mnuXoa.Text = "Xóa";
            this.mnuXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.mnuTroGiup.Text = "Trợ giúp";
            this.mnuTroGiup.DropDownItems.Add(this.mnuGioiThieu);
            this.mnuGioiThieu.Text = "Giới thiệu";
            this.mnuGioiThieu.Click += new System.EventHandler((s, e) => System.Windows.Forms.MessageBox.Show("Lab 05 - Quản lý sản phẩm\nCOMP1019 - Lập trình Windows", "Giới thiệu"));


            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.btnToolThem, new System.Windows.Forms.ToolStripSeparator(),
                this.btnToolSua, new System.Windows.Forms.ToolStripSeparator(),
                this.btnToolXoa, new System.Windows.Forms.ToolStripSeparator(),
                this.btnToolLamMoi
            });
            this.btnToolThem.Text = "Thêm";
            this.btnToolThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnToolSua.Text = "Sửa";
            this.btnToolSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnToolXoa.Text = "Xóa";
            this.btnToolXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnToolLamMoi.Text = "Làm mới";
            this.btnToolLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);


            this.grpInfo.Text = "Thông tin sản phẩm";
            this.grpInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpInfo.Location = new System.Drawing.Point(15, 60);
            this.grpInfo.Size = new System.Drawing.Size(1040, 210);
            this.grpInfo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.lblMaSP.Text = "Mã SP (*):";
            this.lblMaSP.Location = new System.Drawing.Point(20, 30);
            this.lblMaSP.AutoSize = true;
            this.txtMaSP.Location = new System.Drawing.Point(120, 27);
            this.txtMaSP.Size = new System.Drawing.Size(180, 23);

            this.lblTenSP.Text = "Tên SP (*):";
            this.lblTenSP.Location = new System.Drawing.Point(20, 65);
            this.lblTenSP.AutoSize = true;
            this.txtTenSP.Location = new System.Drawing.Point(120, 62);
            this.txtTenSP.Size = new System.Drawing.Size(180, 23);

            this.lblLoaiSP.Text = "Loại SP:";
            this.lblLoaiSP.Location = new System.Drawing.Point(20, 100);
            this.lblLoaiSP.AutoSize = true;
            this.cboLoaiSP.Location = new System.Drawing.Point(120, 97);
            this.cboLoaiSP.Size = new System.Drawing.Size(180, 23);
            this.cboLoaiSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblDuongDanAnh.Text = "Ảnh SP:";
            this.lblDuongDanAnh.Location = new System.Drawing.Point(20, 135);
            this.lblDuongDanAnh.AutoSize = true;
            this.txtDuongDanAnh.Location = new System.Drawing.Point(120, 132);
            this.txtDuongDanAnh.Size = new System.Drawing.Size(120, 23);
            this.txtDuongDanAnh.ReadOnly = true;
            this.btnChonAnh.Text = "Chọn";
            this.btnChonAnh.Location = new System.Drawing.Point(245, 131);
            this.btnChonAnh.Size = new System.Drawing.Size(55, 25);
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);

            this.lblDonGia.Text = "Đơn giá:";
            this.lblDonGia.Location = new System.Drawing.Point(340, 30);
            this.lblDonGia.AutoSize = true;
            this.numDonGia.Location = new System.Drawing.Point(440, 27);
            this.numDonGia.Size = new System.Drawing.Size(160, 23);
            this.numDonGia.Maximum = 1000000000;
            this.numDonGia.ThousandsSeparator = true;

            this.lblSoLuong.Text = "Số lượng:";
            this.lblSoLuong.Location = new System.Drawing.Point(340, 65);
            this.lblSoLuong.AutoSize = true;
            this.numSoLuong.Location = new System.Drawing.Point(440, 62);
            this.numSoLuong.Size = new System.Drawing.Size(160, 23);
            this.numSoLuong.Maximum = 10000;

            this.lblNgayNhap.Text = "Ngày nhập:";
            this.lblNgayNhap.Location = new System.Drawing.Point(340, 100);
            this.lblNgayNhap.AutoSize = true;
            this.dtpNgayNhap.Location = new System.Drawing.Point(440, 97);
            this.dtpNgayNhap.Size = new System.Drawing.Size(160, 23);
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayNhap.CustomFormat = "dd/MM/yyyy";

            this.chkConKinhDoanh.Text = "Còn kinh doanh";
            this.chkConKinhDoanh.Location = new System.Drawing.Point(440, 132);
            this.chkConKinhDoanh.Size = new System.Drawing.Size(150, 23);
            this.chkConKinhDoanh.Checked = true;

            this.picAnh.Location = new System.Drawing.Point(640, 25);
            this.picAnh.Size = new System.Drawing.Size(170, 140);
            this.picAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnh.BackColor = System.Drawing.Color.White;

            this.btnThem.Text = "Thêm mới";
            this.btnThem.Location = new System.Drawing.Point(850, 25);
            this.btnThem.Size = new System.Drawing.Size(160, 32);
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(30, 70, 120);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Text = "Cập nhật";
            this.btnSua.Location = new System.Drawing.Point(850, 62);
            this.btnSua.Size = new System.Drawing.Size(160, 32);
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(70, 130, 180);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Text = "Xóa";
            this.btnXoa.Location = new System.Drawing.Point(850, 99);
            this.btnXoa.Size = new System.Drawing.Size(160, 32);
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(190, 50, 50);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Location = new System.Drawing.Point(850, 136);
            this.btnLamMoi.Size = new System.Drawing.Size(160, 32);
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(230, 235, 240);
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            this.grpInfo.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblMaSP, this.txtMaSP, this.lblTenSP, this.txtTenSP, this.lblLoaiSP, this.cboLoaiSP,
                this.lblDuongDanAnh, this.txtDuongDanAnh, this.btnChonAnh, this.lblDonGia, this.numDonGia,
                this.lblSoLuong, this.numSoLuong, this.lblNgayNhap, this.dtpNgayNhap, this.chkConKinhDoanh,
                this.picAnh, this.btnThem, this.btnSua, this.btnXoa, this.btnLamMoi
            });


            this.pnlSearch.Location = new System.Drawing.Point(15, 280);
            this.pnlSearch.Size = new System.Drawing.Size(1040, 35);
            this.pnlSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.lblSearch.Text = "Tìm theo Mã/Tên:";
            this.lblSearch.Location = new System.Drawing.Point(0, 7);
            this.lblSearch.AutoSize = true;
            this.txtTimKiem.Location = new System.Drawing.Point(120, 5);
            this.txtTimKiem.Size = new System.Drawing.Size(250, 23);
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.Location = new System.Drawing.Point(380, 4);
            this.btnTimKiem.Size = new System.Drawing.Size(75, 25);
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            this.btnHuyTim.Text = "Hủy tìm";
            this.btnHuyTim.Location = new System.Drawing.Point(460, 4);
            this.btnHuyTim.Size = new System.Drawing.Size(75, 25);
            this.btnHuyTim.Click += new System.EventHandler((s, e) => { this.txtTimKiem.Clear(); this.btnTimKiem_Click(null, null); });
            this.pnlSearch.Controls.AddRange(new System.Windows.Forms.Control[] { this.lblSearch, this.txtTimKiem, this.btnTimKiem, this.btnHuyTim });


            this.contextMenuDgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.ctxXemChiTiet, this.ctxSua, this.ctxXoa });
            this.ctxXemChiTiet.Text = "Xem chi tiết";
            this.ctxXemChiTiet.Click += new System.EventHandler(this.ShowDetail_Click);
            this.ctxSua.Text = "Sửa";
            this.ctxSua.Click += new System.EventHandler(this.btnSua_Click);
            this.ctxXoa.Text = "Xóa";
            this.ctxXoa.Click += new System.EventHandler(this.btnXoa_Click);


            this.dgvProducts.Location = new System.Drawing.Point(15, 325);
            this.dgvProducts.Size = new System.Drawing.Size(1040, 300);
            this.dgvProducts.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.ContextMenuStrip = this.contextMenuDgv;
            this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);
            this.dgvProducts.DoubleClick += new System.EventHandler(this.ShowDetail_Click);

            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblStatus, this.lblCount });
            this.lblStatus.Spring = true;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.Text = "Trạng thái: Sẵn sàng";


            this.ClientSize = new System.Drawing.Size(1070, 660);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.dgvProducts, this.pnlSearch, this.grpInfo, this.toolStrip1, this.menuStrip1, this.statusStrip1
            });
            this.MainMenuStrip = this.menuStrip1;
            this.Text = "Quản lý sản phẩm - Lab 05";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong, mnuLamMoi, mnuThoat, mnuQuanLy, mnuThem, mnuSua, mnuXoa, mnuTroGiup, mnuGioiThieu;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnToolThem, btnToolSua, btnToolXoa, btnToolLamMoi;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblMaSP, lblTenSP, lblLoaiSP, lblDonGia, lblSoLuong, lblNgayNhap, lblDuongDanAnh;
        private System.Windows.Forms.TextBox txtMaSP, txtTenSP, txtDuongDanAnh, txtTimKiem;
        private System.Windows.Forms.ComboBox cboLoaiSP;
        private System.Windows.Forms.NumericUpDown numDonGia, numSoLuong;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.CheckBox chkConKinhDoanh;
        private System.Windows.Forms.Button btnChonAnh, btnThem, btnSua, btnXoa, btnLamMoi;
        private System.Windows.Forms.PictureBox picAnh;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnTimKiem, btnHuyTim;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.ContextMenuStrip contextMenuDgv;
        private System.Windows.Forms.ToolStripMenuItem ctxXemChiTiet, ctxSua, ctxXoa;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus, lblCount;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}