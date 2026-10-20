using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    public class FrmLogin : Form
    {
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnExit;

        private List<User> users = new List<User>();

        // FrmMain se lay user dang nhap qua property nay
        public User LoggedUser { get; private set; }

        public FrmLogin()
        {
            InitUI();
            LoadUsers();
        }

        private void LoadUsers()
        {
            users.Add(new User("admin", "123", "Quản trị viên", "Admin"));
            users.Add(new User("user", "123", "Nhân viên bán hàng", "User"));
        }

        private void InitUI()
        {
            Text = "Đăng nhập";
            ClientSize = new Size(340, 230);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            Label lblTitle = new Label();
            lblTitle.Text = "ĐĂNG NHẬP HỆ THỐNG";
            lblTitle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            lblTitle.AutoSize = false;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.SetBounds(0, 15, 340, 35);

            Label lblUsername = new Label();
            lblUsername.Text = "Tên đăng nhập:";
            lblUsername.SetBounds(25, 70, 100, 23);

            txtUsername = new TextBox();
            txtUsername.Name = "txtUsername";
            txtUsername.SetBounds(130, 67, 180, 25);

            Label lblPassword = new Label();
            lblPassword.Text = "Mật khẩu:";
            lblPassword.SetBounds(25, 110, 100, 23);

            txtPassword = new TextBox();
            txtPassword.Name = "txtPassword";
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.SetBounds(130, 107, 180, 25);

            btnLogin = new Button();
            btnLogin.Name = "btnLogin";
            btnLogin.Text = "Đăng nhập";
            btnLogin.SetBounds(60, 160, 100, 32);
            btnLogin.Click += btnLogin_Click;

            btnExit = new Button();
            btnExit.Name = "btnExit";
            btnExit.Text = "Thoát";
            btnExit.SetBounds(180, 160, 100, 32);
            btnExit.Click += btnExit_Click;

            Controls.Add(lblTitle);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);
            Controls.Add(btnExit);

            AcceptButton = btnLogin; // nhan Enter de dang nhap
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Kiem tra bo trong
            if (username == "" || password == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tim tai khoan khop
            User found = null;
            foreach (User u in users)
            {
                if (u.Username == username && u.Password == password)
                {
                    found = u;
                    break;
                }
            }

            if (found == null)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            LoggedUser = found;
            DialogResult = DialogResult.OK; // form tu dong dong lai
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
