#nullable disable

namespace StudentCardPrinter
{
    partial class FrmStudentCard
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
            components = new System.ComponentModel.Container();

            grpInfo = new GroupBox();
            lblStudentId = new Label();
            lblFullName = new Label();
            lblClass = new Label();
            lblFaculty = new Label();
            lblCourse = new Label();
            lblBirthDate = new Label();
            lblGender = new Label();
            txtStudentId = new TextBox();
            txtFullName = new TextBox();
            cboClass = new ComboBox();
            cboFaculty = new ComboBox();
            txtCourse = new TextBox();
            dtpBirthDate = new DateTimePicker();
            cboGender = new ComboBox();

            grpPhoto = new GroupBox();
            picAvatar = new PictureBox();
            btnChoosePhoto = new Button();

            pnlCardPreview = new Panel();
            btnPreviewPrint = new Button();
            btnPrint = new Button();
            btnClear = new Button();
            btnExit = new Button();

            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printPreviewDialog1 = new PrintPreviewDialog();
            printDialog1 = new PrintDialog();

            grpInfo.SuspendLayout();
            grpPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            SuspendLayout();

            // grpInfo
            grpInfo.Name = "grpInfo";
            grpInfo.Text = "Thông tin sinh viên";
            grpInfo.SetBounds(12, 12, 360, 285);
            grpInfo.Controls.Add(lblStudentId);
            grpInfo.Controls.Add(txtStudentId);
            grpInfo.Controls.Add(lblFullName);
            grpInfo.Controls.Add(txtFullName);
            grpInfo.Controls.Add(lblClass);
            grpInfo.Controls.Add(cboClass);
            grpInfo.Controls.Add(lblFaculty);
            grpInfo.Controls.Add(cboFaculty);
            grpInfo.Controls.Add(lblCourse);
            grpInfo.Controls.Add(txtCourse);
            grpInfo.Controls.Add(lblBirthDate);
            grpInfo.Controls.Add(dtpBirthDate);
            grpInfo.Controls.Add(lblGender);
            grpInfo.Controls.Add(cboGender);

            // labels
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Text = "Mã sinh viên:";
            lblStudentId.SetBounds(15, 33, 100, 23);

            lblFullName.Name = "lblFullName";
            lblFullName.Text = "Họ tên:";
            lblFullName.SetBounds(15, 68, 100, 23);

            lblClass.Name = "lblClass";
            lblClass.Text = "Lớp:";
            lblClass.SetBounds(15, 103, 100, 23);

            lblFaculty.Name = "lblFaculty";
            lblFaculty.Text = "Khoa:";
            lblFaculty.SetBounds(15, 138, 100, 23);

            lblCourse.Name = "lblCourse";
            lblCourse.Text = "Khóa học:";
            lblCourse.SetBounds(15, 173, 100, 23);

            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Text = "Ngày sinh:";
            lblBirthDate.SetBounds(15, 208, 100, 23);

            lblGender.Name = "lblGender";
            lblGender.Text = "Giới tính:";
            lblGender.SetBounds(15, 243, 100, 23);

            // inputs
            txtStudentId.Name = "txtStudentId";
            txtStudentId.SetBounds(120, 30, 220, 27);

            txtFullName.Name = "txtFullName";
            txtFullName.SetBounds(120, 65, 220, 27);

            cboClass.Name = "cboClass";
            cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClass.SetBounds(120, 100, 220, 28);

            cboFaculty.Name = "cboFaculty";
            cboFaculty.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFaculty.SetBounds(120, 135, 220, 28);

            txtCourse.Name = "txtCourse";
            txtCourse.PlaceholderText = "VD: K49";
            txtCourse.SetBounds(120, 170, 220, 27);

            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Format = DateTimePickerFormat.Custom;
            dtpBirthDate.CustomFormat = "dd/MM/yyyy";
            dtpBirthDate.SetBounds(120, 205, 220, 27);

            cboGender.Name = "cboGender";
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.SetBounds(120, 240, 220, 28);

            // grpPhoto
            grpPhoto.Name = "grpPhoto";
            grpPhoto.Text = "Ảnh đại diện";
            grpPhoto.SetBounds(12, 305, 360, 195);
            grpPhoto.Controls.Add(picAvatar);
            grpPhoto.Controls.Add(btnChoosePhoto);

            picAvatar.Name = "picAvatar";
            picAvatar.BorderStyle = BorderStyle.FixedSingle;
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.SetBounds(15, 25, 115, 150);

            btnChoosePhoto.Name = "btnChoosePhoto";
            btnChoosePhoto.Text = "Chọn ảnh...";
            btnChoosePhoto.SetBounds(150, 25, 130, 35);

            // pnlCardPreview
            pnlCardPreview.Name = "pnlCardPreview";
            pnlCardPreview.BackColor = Color.White;
            pnlCardPreview.BorderStyle = BorderStyle.FixedSingle;
            pnlCardPreview.SetBounds(390, 12, 560, 360);

            // buttons
            btnPreviewPrint.Name = "btnPreviewPrint";
            btnPreviewPrint.Text = "Xem trước in";
            btnPreviewPrint.SetBounds(390, 390, 140, 42);

            btnPrint.Name = "btnPrint";
            btnPrint.Text = "In";
            btnPrint.SetBounds(540, 390, 140, 42);

            btnClear.Name = "btnClear";
            btnClear.Text = "Làm mới";
            btnClear.SetBounds(690, 390, 140, 42);

            btnExit.Name = "btnExit";
            btnExit.Text = "Thoát";
            btnExit.SetBounds(840, 390, 110, 42);

            // printDocument1 / printPreviewDialog1 / printDialog1
            printDocument1.DocumentName = "The sinh vien";

            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.StartPosition = FormStartPosition.CenterParent;

            printDialog1.UseEXDialog = true;

            // FrmStudentCard
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(965, 512);
            Controls.Add(grpInfo);
            Controls.Add(grpPhoto);
            Controls.Add(pnlCardPreview);
            Controls.Add(btnPreviewPrint);
            Controls.Add(btnPrint);
            Controls.Add(btnClear);
            Controls.Add(btnExit);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmStudentCard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thiết kế và in thẻ sinh viên";

            grpInfo.ResumeLayout(false);
            grpPhoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            ResumeLayout(false);
        }

        private GroupBox grpInfo;
        private GroupBox grpPhoto;
        private Label lblStudentId;
        private Label lblFullName;
        private Label lblClass;
        private Label lblFaculty;
        private Label lblCourse;
        private Label lblBirthDate;
        private Label lblGender;
        private TextBox txtStudentId;
        private TextBox txtFullName;
        private ComboBox cboClass;
        private ComboBox cboFaculty;
        private TextBox txtCourse;
        private DateTimePicker dtpBirthDate;
        private ComboBox cboGender;
        private PictureBox picAvatar;
        private Panel pnlCardPreview;
        private Button btnChoosePhoto;
        private Button btnPreviewPrint;
        private Button btnPrint;
        private Button btnClear;
        private Button btnExit;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;
        private PrintDialog printDialog1;
    }
}
