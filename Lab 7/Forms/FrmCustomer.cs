using System.ComponentModel;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    public class FrmCustomer : Form
    {
        private BindingList<Customer> customers;
        private Customer selected = null;

        private TextBox txtId;
        private TextBox txtName;
        private TextBox txtPhone;
        private ComboBox cboType;
        private TextBox txtSearch;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnClear;
        private Button btnSearch;
        private DataGridView dgvCustomers;

        public FrmCustomer(BindingList<Customer> customers)
        {
            this.customers = customers;
            InitUI();
            ShowAll();
        }

        private Label MakeLabel(string text, int x, int y)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.SetBounds(x, y + 3, 90, 23);
            Controls.Add(lbl);
            return lbl;
        }

        private Button MakeButton(string name, string text, int x, int y)
        {
            Button btn = new Button();
            btn.Name = name;
            btn.Text = text;
            btn.SetBounds(x, y, 80, 30);
            Controls.Add(btn);
            return btn;
        }

        private void InitUI()
        {
            Text = "Quản lý khách hàng";
            ClientSize = new Size(780, 480);

            MakeLabel("Mã khách hàng:", 20, 20);
            txtId = new TextBox();
            txtId.Name = "txtId";
            txtId.SetBounds(120, 20, 200, 25);

            MakeLabel("Họ tên:", 20, 55);
            txtName = new TextBox();
            txtName.Name = "txtName";
            txtName.SetBounds(120, 55, 200, 25);

            MakeLabel("Số điện thoại:", 360, 20);
            txtPhone = new TextBox();
            txtPhone.Name = "txtPhone";
            txtPhone.MaxLength = 11;
            txtPhone.SetBounds(460, 20, 180, 25);

            MakeLabel("Loại khách hàng:", 360, 55);
            cboType = new ComboBox();
            cboType.Name = "cboType";
            cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboType.Items.AddRange(new object[] { "Thường", "Thân thiết", "VIP" });
            cboType.SetBounds(460, 55, 180, 25);

            btnAdd = MakeButton("btnAdd", "Thêm", 20, 105);
            btnEdit = MakeButton("btnEdit", "Sửa", 110, 105);
            btnDelete = MakeButton("btnDelete", "Xóa", 200, 105);
            btnClear = MakeButton("btnClear", "Làm mới", 290, 105);

            MakeLabel("Tìm kiếm:", 420, 105);
            txtSearch = new TextBox();
            txtSearch.Name = "txtSearch";
            txtSearch.SetBounds(500, 108, 150, 25);
            btnSearch = MakeButton("btnSearch", "Tìm", 660, 105);

            dgvCustomers = new DataGridView();
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.SetBounds(20, 150, 740, 310);
            dgvCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.ReadOnly = true;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.MultiSelect = false;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            AddColumn("Id", "Mã KH");
            AddColumn("FullName", "Họ tên");
            AddColumn("Phone", "Số điện thoại");
            AddColumn("Type", "Loại khách hàng");

            Controls.Add(txtId);
            Controls.Add(txtName);
            Controls.Add(txtPhone);
            Controls.Add(cboType);
            Controls.Add(txtSearch);
            Controls.Add(dgvCustomers);

            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;
            btnSearch.Click += btnSearch_Click;
            dgvCustomers.CellClick += dgvCustomers_CellClick;
        }

        private void AddColumn(string property, string header)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = property;
            col.HeaderText = header;
            dgvCustomers.Columns.Add(col);
        }

        private void ShowAll()
        {
            dgvCustomers.DataSource = null;
            dgvCustomers.DataSource = customers;
            dgvCustomers.ClearSelection();
        }

        private void ClearInput()
        {
            txtId.Clear();
            txtId.ReadOnly = false;
            txtName.Clear();
            txtPhone.Clear();
            cboType.SelectedIndex = -1;
            selected = null;
            txtId.Focus();
        }

        private void Warn(string message)
        {
            MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private bool CheckInput()
        {
            if (txtId.Text.Trim() == "")
            {
                Warn("Vui lòng nhập mã khách hàng!");
                txtId.Focus();
                return false;
            }
            if (txtName.Text.Trim() == "")
            {
                Warn("Vui lòng nhập họ tên khách hàng!");
                txtName.Focus();
                return false;
            }

            string phone = txtPhone.Text.Trim();
            if (phone == "")
            {
                Warn("Vui lòng nhập số điện thoại!");
                txtPhone.Focus();
                return false;
            }
            // So dien thoai chi gom chu so, tu 9 den 11 so
            foreach (char c in phone)
            {
                if (!char.IsDigit(c))
                {
                    Warn("Số điện thoại chỉ được chứa chữ số!");
                    txtPhone.Focus();
                    return false;
                }
            }
            if (phone.Length < 9 || phone.Length > 11)
            {
                Warn("Số điện thoại phải từ 9 đến 11 chữ số!");
                txtPhone.Focus();
                return false;
            }

            if (cboType.SelectedIndex < 0)
            {
                Warn("Vui lòng chọn loại khách hàng!");
                cboType.Focus();
                return false;
            }
            return true;
        }

        private bool IdExists(string id)
        {
            foreach (Customer c in customers)
            {
                if (c.Id.ToLower() == id.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;

            string id = txtId.Text.Trim();
            if (IdExists(id))
            {
                MessageBox.Show("Mã khách hàng đã tồn tại! (Nếu đang chọn một dòng, bấm Làm mới trước khi thêm)",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtId.Focus();
                return;
            }

            customers.Add(new Customer(id, txtName.Text.Trim(), txtPhone.Text.Trim(), cboType.Text));
            ShowAll();
            ClearInput();
            MessageBox.Show("Thêm khách hàng thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selected == null)
            {
                Warn("Vui lòng chọn khách hàng cần sửa trong danh sách!");
                return;
            }
            if (!CheckInput()) return;

            selected.FullName = txtName.Text.Trim();
            selected.Phone = txtPhone.Text.Trim();
            selected.Type = cboType.Text;

            dgvCustomers.Refresh();
            ClearInput();
            MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selected == null)
            {
                Warn("Vui lòng chọn khách hàng cần xóa!");
                return;
            }

            DialogResult r = MessageBox.Show(
                "Bạn có chắc muốn xóa khách hàng \"" + selected.FullName + "\" không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                customers.Remove(selected);
                ShowAll();
                ClearInput();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInput();
            txtSearch.Clear();
            ShowAll();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            if (keyword == "")
            {
                ShowAll();
                return;
            }

            // Tim theo ma, ho ten hoac so dien thoai
            BindingList<Customer> result = new BindingList<Customer>();
            foreach (Customer c in customers)
            {
                if (c.Id.ToLower().Contains(keyword) ||
                    c.FullName.ToLower().Contains(keyword) ||
                    c.Phone.Contains(keyword))
                {
                    result.Add(c);
                }
            }

            dgvCustomers.DataSource = null;
            dgvCustomers.DataSource = result;
            dgvCustomers.ClearSelection();

            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy khách hàng nào!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Customer c = dgvCustomers.Rows[e.RowIndex].DataBoundItem as Customer;
            if (c == null) return;

            selected = c;
            txtId.Text = c.Id;
            txtId.ReadOnly = true;
            txtName.Text = c.FullName;
            txtPhone.Text = c.Phone;
            cboType.Text = c.Type;
        }
    }
}
