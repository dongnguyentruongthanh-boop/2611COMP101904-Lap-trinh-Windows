namespace Lab_8
{
    partial class Form1
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.functionPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMode = new System.Windows.Forms.Label();
            this.cboMode = new System.Windows.Forms.ComboBox();
            this.lblWidth = new System.Windows.Forms.Label();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.canvas = new Lab_8.MyCanvas();
            this.topPanel.SuspendLayout();
            this.functionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.LightGray;
            this.topPanel.Controls.Add(this.functionPanel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(900, 50);
            this.topPanel.TabIndex = 0;
            // 
            // functionPanel
            // 
            this.functionPanel.AutoSize = true;
            this.functionPanel.Controls.Add(this.lblMode);
            this.functionPanel.Controls.Add(this.cboMode);
            this.functionPanel.Controls.Add(this.lblWidth);
            this.functionPanel.Controls.Add(this.nudWidth);
            this.functionPanel.Controls.Add(this.btnColor);
            this.functionPanel.Controls.Add(this.btnUndo);
            this.functionPanel.Controls.Add(this.btnClear);
            this.functionPanel.Location = new System.Drawing.Point(120, 8);
            this.functionPanel.Name = "functionPanel";
            this.functionPanel.Padding = new System.Windows.Forms.Padding(5);
            this.functionPanel.Size = new System.Drawing.Size(650, 42);
            this.functionPanel.TabIndex = 0;
            this.functionPanel.WrapContents = false;
            // 
            // lblMode
            // 
            this.lblMode.Location = new System.Drawing.Point(8, 5);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(55, 23);
            this.lblMode.TabIndex = 0;
            this.lblMode.Text = "Chế độ:";
            this.lblMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboMode
            // 
            this.cboMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMode.FormattingEnabled = true;
            this.cboMode.Items.AddRange(new object[] {
            "Pen",
            "Line",
            "Rectangle",
            "Ellipse"});
            this.cboMode.Location = new System.Drawing.Point(69, 8);
            this.cboMode.Name = "cboMode";
            this.cboMode.Size = new System.Drawing.Size(100, 24);
            this.cboMode.TabIndex = 1;
            // 
            // lblWidth
            // 
            this.lblWidth.Location = new System.Drawing.Point(175, 5);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(55, 23);
            this.lblWidth.TabIndex = 2;
            this.lblWidth.Text = "Độ dày:";
            this.lblWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudWidth
            // 
            this.nudWidth.Location = new System.Drawing.Point(236, 8);
            this.nudWidth.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(50, 22);
            this.nudWidth.TabIndex = 3;
            this.nudWidth.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Brown;
            this.btnColor.ForeColor = System.Drawing.Color.White;
            this.btnColor.Location = new System.Drawing.Point(292, 8);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(65, 26);
            this.btnColor.TabIndex = 4;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.BtnColor_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(363, 8);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(65, 26);
            this.btnUndo.TabIndex = 5;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.BtnUndo_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(434, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(65, 26);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bottomPanel.Controls.Add(this.lblStatus);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 570);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(900, 30);
            this.bottomPanel.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(10, 7);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(108, 16);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Tọa độ: X=0, Y=0";
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.Cursor = System.Windows.Forms.Cursors.Cross;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 50);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(900, 520);
            this.canvas.TabIndex = 2;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.topPanel);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Form1";
            this.Text = "COMP1019_Lab08_SimplePaint";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.functionPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.FlowLayoutPanel functionPanel;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.ComboBox cboMode;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Label lblStatus;
        private Lab_8.MyCanvas canvas;
    }
}