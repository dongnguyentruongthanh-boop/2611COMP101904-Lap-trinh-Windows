using System.ComponentModel;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    public class FrmProduct : Form
    {
        private BindingList<Product> products; // danh sach goc (lay tu FrmMain)
        private Product selected = null;       // san pham dang duoc chon tren grid

        private TextBox txtId;
        private TextBox txtName;
        private ComboBox cboCategory;
        private NumericUpDown numPrice;
        private NumericUpDown numQuantity;
        private TextBox txtSearch;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnClear;
        private Button btnSearch;
        private DataGridView dgvProducts;

        public FrmProduct(BindingList<Product> products)
        {
            this.products = products;
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
            Text = "Quản lý sản phẩm";
            ClientSize = new Size(780, 480);

            MakeLabel("Mã sản phẩm:", 20, 20);
            txtId = new TextBox();
            txtId.Name = "txtId";
            txtId.SetBounds(120, 20, 200, 25);

            MakeLabel("Tên sản phẩm:", 20, 55);
            txtName = new TextBox();
            txtName.Name = "txtName";
            txtName.SetBounds(120, 55, 200, 25);

            MakeLabel("Loại sản phẩm:", 20, 90);
            cboCategory = new ComboBox();
            cboCategory.Name = "cboCategory";
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Items.AddRange(new object[] { "Đồ uống", "Thực phẩm", "Bánh kẹo", "Đồ dùng cá nhân", "Khác" });
            cboCategory.SetBounds(120, 90, 200, 25);

            MakeLabel("Đơn giá:", 360, 20);
            numPrice = new NumericUpDown();
            numPrice.Name = "numPrice";
            numPrice.Minimum = 0;
            numPrice.Maximum = 1000000000;
            numPrice.Increment = 1000;
            numPrice.ThousandsSeparator = true;
            numPrice.SetBounds(460, 20, 150, 25);

            MakeLabel("Số lượng:", 360, 55);
            numQuantity = new NumericUpDown();
            numQuantity.Name = "numQuantity";
            numQuantity.Minimum = 0;
            numQuantity.Maximum = 100000;
            numQuantity.SetBounds(460, 55, 150, 25);

            btnAdd = MakeButton("btnAdd", "Thêm", 20, 135);
            btnEdit = MakeButton("btnEdit", "Sửa", 110, 135);
            btnDelete = MakeButton("btnDelete", "Xóa", 200, 135);
            btnClear = MakeButton("btnClear", "Làm mới", 290, 135);

            MakeLabel("Tìm kiếm:", 420, 135);
            txtSearch = new TextBox();
            txtSearch.Name = "txtSearch";
            txtSearch.SetBounds(500, 138, 150, 25);
            btnSearch = MakeButton("btnSearch", "Tìm", 660, 135);

            dgvProducts = new DataGridView();
            dgvProducts.Name = "dgvProducts";
            dgvProducts.SetBounds(20, 180, 740, 280);
            dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            AddColumn("Id", "Mã SP", "");
            AddColumn("Name", "Tên sản phẩm", "");
            AddColumn("Category", "Loại", "");
            AddColumn("Price", "Đơn giá", "N0");
            AddColumn("Quantity", "Số lượng", "");

            Controls.Add(txtId);
            Controls.Add(txtName);
            Controls.Add(cboCategory);
            Controls.Add(numPrice);
            Controls.Add(numQuantity);
            Controls.Add(txtSearch);
            Controls.Add(dgvProducts);

            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;
            btnSearch.Click += btnSearch_Click;
            dgvProducts.CellClick += dgvProducts_CellClick;
        }

        private void AddColumn(string property, string header, string format)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = property;
            col.HeaderText = header;
            if (format != "")
            {
                col.DefaultCellStyle.Format = format;
            }
            dgvProducts.Columns.Add(col);
        }

        // Hien toan bo san pham len grid
        private void ShowAll()
        {
            dgvProducts.DataSource = null;
            dgvProducts.DataSource = products;
            dgvProducts.ClearSelection();
        }

        private void ClearInput()
        {
            txtId.Clear();
            txtId.ReadOnly = false;
            txtName.Clear();
            cboCategory.SelectedIndex = -1;
            numPrice.Value = 0;
            numQuantity.Value = 0;
            selected = null;
            txtId.Focus();
        }

        // Kiem tra du lieu nhap, dung thi tra ve true
        private bool CheckInput()
        {
            if (txtId.Text.Trim() == "")
            {
                Warn("Vui lòng nhập mã sản phẩm!");
                txtId.Focus();
                return false;
            }
            if (txtName.Text.Trim() == "")
            {
                Warn("Vui lòng nhập tên sản phẩm!");
                txtName.Focus();
                return false;
            }
            if (cboCategory.SelectedIndex < 0)
            {
                Warn("Vui lòng chọn loại sản phẩm!");
                cboCategory.Focus();
                return false;
            }
            if (numPrice.Value < 0)
            {
                Warn("Đơn giá không được âm!");
                numPrice.Focus();
                return false;
            }
            if (numQuantity.Value < 0)
            {
                Warn("Số lượng không được âm!");
                numQuantity.Focus();
                return false;
            }
            return true;
        }

        private void Warn(string message)
        {
            MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private bool IdExists(string id)
        {
            foreach (Product p in products)
            {
                if (p.Id.ToLower() == id.ToLower())
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
                MessageBox.Show("Mã sản phẩm đã tồn tại! (Nếu đang chọn một dòng, bấm Làm mới trước khi thêm)",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtId.Focus();
                return;
            }

            Product p = new Product(id, txtName.Text.Trim(), cboCategory.Text,
                numPrice.Value, (int)numQuantity.Value);
            products.Add(p);

            ShowAll();
            ClearInput();
            MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selected == null)
            {
                Warn("Vui lòng chọn sản phẩm cần sửa trong danh sách!");
                return;
            }
            if (!CheckInput()) return;

            // Ma khong doi, chi sua cac thong tin con lai
            selected.Name = txtName.Text.Trim();
            selected.Category = cboCategory.Text;
            selected.Price = numPrice.Value;
            selected.Quantity = (int)numQuantity.Value;

            dgvProducts.Refresh();
            ClearInput();
            MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selected == null)
            {
                Warn("Vui lòng chọn sản phẩm cần xóa!");
                return;
            }

            DialogResult r = MessageBox.Show(
                "Bạn có chắc muốn xóa sản phẩm \"" + selected.Name + "\" không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                products.Remove(selected);
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

            // Tim theo ma hoac ten
            BindingList<Product> result = new BindingList<Product>();
            foreach (Product p in products)
            {
                if (p.Id.ToLower().Contains(keyword) || p.Name.ToLower().Contains(keyword))
                {
                    result.Add(p);
                }
            }

            dgvProducts.DataSource = null;
            dgvProducts.DataSource = result;
            dgvProducts.ClearSelection();

            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Click vao dong nao thi do du lieu len cac o nhap
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Product p = dgvProducts.Rows[e.RowIndex].DataBoundItem as Product;
            if (p == null) return;

            selected = p;
            txtId.Text = p.Id;
            txtId.ReadOnly = true; // khong cho doi ma khi sua
            txtName.Text = p.Name;
            cboCategory.Text = p.Category;
            numPrice.Value = p.Price;
            numQuantity.Value = p.Quantity;
        }
    }
}
