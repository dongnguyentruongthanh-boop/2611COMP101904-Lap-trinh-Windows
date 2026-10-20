using System.ComponentModel;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    public class FrmMain : Form
    {
        private MenuStrip menuStrip;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblUser;
        private ToolStripStatusLabel lblTime;
        private System.Windows.Forms.Timer timerClock;

        private User currentUser;

        // Du lieu dung chung, truyen sang cac form con
        private BindingList<Product> products = new BindingList<Product>();
        private BindingList<Customer> customers = new BindingList<Customer>();

        // true khi nguoi dung chon Dang xuat (de Program biet ma hien lai FrmLogin)
        public bool IsLogout { get; private set; } = false;

        public FrmMain(User user)
        {
            currentUser = user;
            InitUI();
            LoadSampleData();
            ShowUserInfo();
        }

        private void InitUI()
        {
            Text = "ShopManagerMini - Quản lý cửa hàng mini";
            Size = new Size(1000, 650);
            StartPosition = FormStartPosition.CenterScreen;
            IsMdiContainer = true;

            // ----- MenuStrip -----
            menuStrip = new MenuStrip();
            menuStrip.Name = "menuStrip";

            ToolStripMenuItem mnuSystem = new ToolStripMenuItem("Hệ thống");
            ToolStripMenuItem mnuLogout = new ToolStripMenuItem("Đăng xuất");
            ToolStripMenuItem mnuExit = new ToolStripMenuItem("Thoát");
            mnuLogout.Click += mnuLogout_Click;
            mnuExit.Click += mnuExit_Click;
            mnuSystem.DropDownItems.Add(mnuLogout);
            mnuSystem.DropDownItems.Add(mnuExit);

            ToolStripMenuItem mnuCategory = new ToolStripMenuItem("Danh mục");
            ToolStripMenuItem mnuProduct = new ToolStripMenuItem("Quản lý sản phẩm");
            ToolStripMenuItem mnuCustomer = new ToolStripMenuItem("Quản lý khách hàng");
            mnuProduct.Click += mnuProduct_Click;
            mnuCustomer.Click += mnuCustomer_Click;
            mnuCategory.DropDownItems.Add(mnuProduct);
            mnuCategory.DropDownItems.Add(mnuCustomer);

            ToolStripMenuItem mnuHelp = new ToolStripMenuItem("Trợ giúp");
            ToolStripMenuItem mnuAbout = new ToolStripMenuItem("Giới thiệu");
            mnuAbout.Click += mnuAbout_Click;
            mnuHelp.DropDownItems.Add(mnuAbout);

            menuStrip.Items.Add(mnuSystem);
            menuStrip.Items.Add(mnuCategory);
            menuStrip.Items.Add(mnuHelp);

            // ----- StatusStrip -----
            statusStrip = new StatusStrip();
            statusStrip.Name = "statusStrip";

            lblUser = new ToolStripStatusLabel();
            lblUser.Spring = true;
            lblUser.TextAlign = ContentAlignment.MiddleLeft;

            lblTime = new ToolStripStatusLabel();
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            statusStrip.Items.Add(lblUser);
            statusStrip.Items.Add(lblTime);

            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;

            // Dong ho cap nhat moi giay
            timerClock = new System.Windows.Forms.Timer();
            timerClock.Interval = 1000;
            timerClock.Tick += timerClock_Tick;
            timerClock.Start();

            FormClosing += FrmMain_FormClosing;
        }

        private void LoadSampleData()
        {
            products.Add(new Product("SP01", "Nước suối Aquafina 500ml", "Đồ uống", 6000, 120));
            products.Add(new Product("SP02", "Mì Hảo Hảo tôm chua cay", "Thực phẩm", 4500, 200));
            products.Add(new Product("SP03", "Bánh Oreo", "Bánh kẹo", 12000, 60));

            customers.Add(new Customer("KH01", "Nguyễn Văn An", "0901234567", "Thường"));
            customers.Add(new Customer("KH02", "Trần Thị Bình", "0912345678", "VIP"));
        }

        private void ShowUserInfo()
        {
            lblUser.Text = "Người dùng: " + currentUser.FullName + "   |   Vai trò: " + currentUser.Role;
        }

        // Mo form con: neu da mo roi thi chi kich hoat lai, khong tao moi
        private void OpenChild<T>(Func<T> createForm) where T : Form
        {
            foreach (Form f in MdiChildren)
            {
                if (f is T)
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Activate();
                    return;
                }
            }

            T child = createForm();
            child.MdiParent = this;
            child.Show();
        }

        private void mnuProduct_Click(object sender, EventArgs e)
        {
            OpenChild(() => new FrmProduct(products));
        }

        private void mnuCustomer_Click(object sender, EventArgs e)
        {
            OpenChild(() => new FrmCustomer(customers));
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            OpenChild(() => new FrmAbout());
        }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                IsLogout = true;
                Close();
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close(); // FormClosing se hoi xac nhan
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsLogout) return; // dang xuat thi khong hoi lai

            DialogResult r = MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Xác nhận thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
