namespace ShopManagerMini.Forms
{
    public class FrmAbout : Form
    {
        public FrmAbout()
        {
            Text = "Giới thiệu";
            ClientSize = new Size(380, 230);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Label lblName = new Label();
            lblName.Text = "ShopManagerMini";
            lblName.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblName.AutoSize = false;
            lblName.TextAlign = ContentAlignment.MiddleCenter;
            lblName.SetBounds(0, 20, 380, 40);

            Label lblInfo = new Label();
            lblInfo.Text =
                "Ứng dụng quản lý cửa hàng mini\r\n" +
                "Phiên bản: 1.0\r\n" +
                "Môn học: COMP1019 - Lập trình trên Windows\r\n" +
                "Bài lab 7: SDI, MDI và ứng dụng nhiều Form\r\n\r\n" +
                "Sinh viên: ................................\r\n" +
                "Lớp: ................................";
            lblInfo.AutoSize = false;
            lblInfo.SetBounds(40, 70, 320, 130);

            Controls.Add(lblName);
            Controls.Add(lblInfo);
        }
    }
}
