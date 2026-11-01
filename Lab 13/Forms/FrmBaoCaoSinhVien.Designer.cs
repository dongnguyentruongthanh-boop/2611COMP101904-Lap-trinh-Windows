namespace StudentReportDemo.Forms
{
    partial class FrmBaoCaoSinhVien
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
            lblLop = new Label();
            cboLop = new ComboBox();
            lblKetQua = new Label();
            cboKetQua = new ComboBox();
            lblTuKhoa = new Label();
            txtTuKhoa = new TextBox();
            btnXemBaoCao = new Button();
            btnThongKe = new Button();
            btnXuatFile = new Button();
            dgvBaoCao = new DataGridView();
            lblThongKe = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).BeginInit();
            SuspendLayout();

            // hang 1: bo loc
            lblLop.Name = "lblLop";
            lblLop.Text = "Lớp:";
            lblLop.SetBounds(20, 23, 45, 23);

            cboLop.Name = "cboLop";
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.SetBounds(70, 20, 200, 28);
            cboLop.SelectedIndexChanged += cboLop_SelectedIndexChanged;

            lblKetQua.Name = "lblKetQua";
            lblKetQua.Text = "Kết quả:";
            lblKetQua.SetBounds(290, 23, 70, 23);

            cboKetQua.Name = "cboKetQua";
            cboKetQua.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKetQua.SetBounds(365, 20, 140, 28);
            cboKetQua.SelectedIndexChanged += cboKetQua_SelectedIndexChanged;

            lblTuKhoa.Name = "lblTuKhoa";
            lblTuKhoa.Text = "Từ khóa:";
            lblTuKhoa.SetBounds(525, 23, 70, 23);

            txtTuKhoa.Name = "txtTuKhoa";
            txtTuKhoa.PlaceholderText = "Mã SV hoặc họ tên";
            txtTuKhoa.SetBounds(600, 20, 230, 27);
            txtTuKhoa.TextChanged += txtTuKhoa_TextChanged;

            // hang 2: nut
            btnXemBaoCao.Name = "btnXemBaoCao";
            btnXemBaoCao.Text = "Xem báo cáo";
            btnXemBaoCao.SetBounds(20, 62, 130, 34);
            btnXemBaoCao.Click += btnXemBaoCao_Click;

            btnThongKe.Name = "btnThongKe";
            btnThongKe.Text = "Thống kê";
            btnThongKe.SetBounds(160, 62, 130, 34);
            btnThongKe.Click += btnThongKe_Click;

            btnXuatFile.Name = "btnXuatFile";
            btnXuatFile.Text = "Xuất file";
            btnXuatFile.SetBounds(300, 62, 130, 34);
            btnXuatFile.Click += btnXuatFile_Click;

            // luoi bao cao
            dgvBaoCao.Name = "dgvBaoCao";
            dgvBaoCao.SetBounds(20, 110, 810, 350);
            dgvBaoCao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBaoCao.AllowUserToAddRows = false;
            dgvBaoCao.AllowUserToDeleteRows = false;
            dgvBaoCao.ReadOnly = true;
            dgvBaoCao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // nhan thong ke
            lblThongKe.Name = "lblThongKe";
            lblThongKe.AutoSize = false;
            lblThongKe.TextAlign = ContentAlignment.MiddleLeft;
            lblThongKe.Text = "";
            lblThongKe.SetBounds(20, 470, 810, 30);
            lblThongKe.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // form
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 515);
            Controls.Add(lblLop);
            Controls.Add(cboLop);
            Controls.Add(lblKetQua);
            Controls.Add(cboKetQua);
            Controls.Add(lblTuKhoa);
            Controls.Add(txtTuKhoa);
            Controls.Add(btnXemBaoCao);
            Controls.Add(btnThongKe);
            Controls.Add(btnXuatFile);
            Controls.Add(dgvBaoCao);
            Controls.Add(lblThongKe);
            Name = "FrmBaoCaoSinhVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Báo cáo danh sách sinh viên";
            Load += FrmBaoCaoSinhVien_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).EndInit();
            ResumeLayout(false);
        }

        private Label lblLop;
        private ComboBox cboLop;
        private Label lblKetQua;
        private ComboBox cboKetQua;
        private Label lblTuKhoa;
        private TextBox txtTuKhoa;
        private Button btnXemBaoCao;
        private Button btnThongKe;
        private Button btnXuatFile;
        private DataGridView dgvBaoCao;
        private Label lblThongKe;
    }
}
