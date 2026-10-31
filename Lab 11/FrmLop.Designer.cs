namespace COMP1019_Buoi11_Lab11
{
    partial class FrmLop
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

        private void InitializeComponent()
        {
            lblMaLop = new Label();
            txtMaLop = new TextBox();
            lblTenLop = new Label();
            txtTenLop = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            dgvLop = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvLop).BeginInit();
            SuspendLayout();

            // lblMaLop
            lblMaLop.Name = "lblMaLop";
            lblMaLop.Text = "Mã lớp:";
            lblMaLop.SetBounds(20, 23, 80, 23);

            // txtMaLop
            txtMaLop.Name = "txtMaLop";
            txtMaLop.SetBounds(110, 20, 200, 27);

            // lblTenLop
            lblTenLop.Name = "lblTenLop";
            lblTenLop.Text = "Tên lớp:";
            lblTenLop.SetBounds(20, 58, 80, 23);

            // txtTenLop
            txtTenLop.Name = "txtTenLop";
            txtTenLop.SetBounds(110, 55, 300, 27);

            // btnThem
            btnThem.Name = "btnThem";
            btnThem.Text = "Thêm";
            btnThem.SetBounds(20, 100, 85, 32);
            btnThem.Click += btnThem_Click;

            // btnSua
            btnSua.Name = "btnSua";
            btnSua.Text = "Sửa";
            btnSua.SetBounds(115, 100, 85, 32);
            btnSua.Click += btnSua_Click;

            // btnXoa
            btnXoa.Name = "btnXoa";
            btnXoa.Text = "Xóa";
            btnXoa.SetBounds(210, 100, 85, 32);
            btnXoa.Click += btnXoa_Click;

            // btnLamMoi
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.SetBounds(305, 100, 85, 32);
            btnLamMoi.Click += btnLamMoi_Click;

            // txtTimKiem
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập mã hoặc tên lớp cần tìm";
            txtTimKiem.SetBounds(20, 148, 290, 27);

            // btnTimKiem
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.SetBounds(320, 146, 90, 30);
            btnTimKiem.Click += btnTimKiem_Click;

            // dgvLop
            dgvLop.Name = "dgvLop";
            dgvLop.SetBounds(20, 190, 600, 270);
            dgvLop.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLop.AllowUserToAddRows = false;
            dgvLop.AllowUserToDeleteRows = false;
            dgvLop.ReadOnly = true;
            dgvLop.MultiSelect = false;
            dgvLop.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLop.CellClick += dgvLop_CellClick;

            // FrmLop
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 480);
            Controls.Add(lblMaLop);
            Controls.Add(txtMaLop);
            Controls.Add(lblTenLop);
            Controls.Add(txtTenLop);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(txtTimKiem);
            Controls.Add(btnTimKiem);
            Controls.Add(dgvLop);
            Name = "FrmLop";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý lớp học";
            Load += FrmLop_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLop).EndInit();
            ResumeLayout(false);
        }

        private Label lblMaLop;
        private TextBox txtMaLop;
        private Label lblTenLop;
        private TextBox txtTenLop;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private DataGridView dgvLop;
    }
}
