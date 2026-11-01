#nullable disable

namespace QLSinhVienLab12.Forms
{
    partial class FrmNhapDiemTheoLop
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
            lblMonHoc = new Label();
            cboMonHoc = new ComboBox();
            btnTaiDanhSach = new Button();
            dgvKetQua = new DataGridView();
            btnLuuTatCa = new Button();
            statusStrip1 = new StatusStrip();
            lblTrangThai = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();

            // lblLop
            lblLop.Name = "lblLop";
            lblLop.Text = "Lớp:";
            lblLop.SetBounds(20, 23, 60, 23);

            // cboLop
            cboLop.Name = "cboLop";
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.SetBounds(85, 20, 250, 28);

            // lblMonHoc
            lblMonHoc.Name = "lblMonHoc";
            lblMonHoc.Text = "Môn học:";
            lblMonHoc.SetBounds(365, 23, 70, 23);

            // cboMonHoc
            cboMonHoc.Name = "cboMonHoc";
            cboMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonHoc.SetBounds(440, 20, 250, 28);

            // btnTaiDanhSach
            btnTaiDanhSach.Name = "btnTaiDanhSach";
            btnTaiDanhSach.Text = "Tải danh sách";
            btnTaiDanhSach.SetBounds(20, 65, 150, 34);
            btnTaiDanhSach.Click += btnTaiDanhSach_Click;

            // dgvKetQua
            dgvKetQua.Name = "dgvKetQua";
            dgvKetQua.SetBounds(20, 110, 720, 330);
            dgvKetQua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvKetQua.AllowUserToAddRows = false;
            dgvKetQua.AllowUserToDeleteRows = false;
            dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKetQua.DataError += dgvKetQua_DataError;

            // btnLuuTatCa
            btnLuuTatCa.Name = "btnLuuTatCa";
            btnLuuTatCa.Text = "Lưu tất cả";
            btnLuuTatCa.SetBounds(590, 452, 150, 38);
            btnLuuTatCa.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLuuTatCa.Click += btnLuuTatCa_Click;

            // statusStrip1
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Items.Add(lblTrangThai);

            // lblTrangThai
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Text = "Sẵn sàng";

            // FrmNhapDiemTheoLop
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 530);
            Controls.Add(lblLop);
            Controls.Add(cboLop);
            Controls.Add(lblMonHoc);
            Controls.Add(cboMonHoc);
            Controls.Add(btnTaiDanhSach);
            Controls.Add(dgvKetQua);
            Controls.Add(btnLuuTatCa);
            Controls.Add(statusStrip1);
            Name = "FrmNhapDiemTheoLop";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nhập điểm theo lớp";
            Load += FrmNhapDiemTheoLop_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblLop;
        private ComboBox cboLop;
        private Label lblMonHoc;
        private ComboBox cboMonHoc;
        private Button btnTaiDanhSach;
        private DataGridView dgvKetQua;
        private Button btnLuuTatCa;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblTrangThai;
    }
}
