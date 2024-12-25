namespace QLDAPMM
{
    public partial class Form2 : Form
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtSoHoSo, txtBoPhan, txtDuAn, txtChuDuAn, txtDiaChi, txtDienThoai, txtEmail,
                       txtNoiDung, txtThanhPhan, txtKetQua, txtQuyenSo, txtSoThuTu1, txtSoThuTu2;
        private ComboBox cmbMa, cmbThoiGian;
        private DateTimePicker dtpNhan, dtpTra;
        private Button btnLayThongTin;

       

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Size = new System.Drawing.Size(700, 750);
            this.Text = "Biên nhận hồ sơ";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Toolbar with icons
            ToolStrip toolStrip = new ToolStrip
            {
                RenderMode = ToolStripRenderMode.System,
                BackColor = Color.FromArgb(227, 239, 255)
            };

            toolStrip.Items.AddRange(new ToolStripItem[] {
                new ToolStripButton("Lưu") { Image = GetSystemIcon("save") },
                new ToolStripButton("Cập nhật") { Image = GetSystemIcon("refresh") },
                new ToolStripButton("In") { Image = GetSystemIcon("print") },
                new ToolStripButton("In Trực Tiếp") { Image = GetSystemIcon("print") }
            });

            // Title
            Label lblTitle = new Label
            {
                Text = "GIẤY BIÊN NHẬN",
                ForeColor = Color.Red,
                Font = new Font("Arial", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 40,
                Dock = DockStyle.Top
            };

            // Initialize controls
            InitializeFormControls();

            // Main layout
            TableLayoutPanel mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 13,
                Padding = new Padding(10),
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None
            };

            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            // Add controls with proper spacing
            AddFormControls(mainLayout);

            // Container panel
            Panel container = new Panel { Dock = DockStyle.Fill };
            container.Controls.AddRange(new Control[] { toolStrip, lblTitle, mainLayout });
            this.Controls.Add(container);
        }

        private void InitializeFormControls()
        {
            // Initialize all TextBoxes with proper styling
            txtSoHoSo = new TextBox { Dock = DockStyle.Fill };
            txtBoPhan = new TextBox { Dock = DockStyle.Fill };
            txtDuAn = new TextBox { Dock = DockStyle.Fill };
            txtChuDuAn = new TextBox { Dock = DockStyle.Fill };
            txtDiaChi = new TextBox { Dock = DockStyle.Fill };
            txtDienThoai = new TextBox { Width = 150 };
            txtEmail = new TextBox { Width = 150 };
            txtNoiDung = new TextBox { Multiline = true, Height = 100, Dock = DockStyle.Fill };
            txtThanhPhan = new TextBox { Multiline = true, Height = 80, Dock = DockStyle.Fill };
            txtKetQua = new TextBox { Dock = DockStyle.Fill };
            txtQuyenSo = new TextBox { Width = 150 };
            txtSoThuTu1 = new TextBox { Width = 100 };
            txtSoThuTu2 = new TextBox { Width = 100 };

            // ComboBoxes
            cmbMa = new ComboBox { Width = 150 };
            cmbMa.Items.Add("KBM");
            cmbThoiGian = new ComboBox { Width = 150 };

            // DateTimePickers
            dtpNhan = new DateTimePicker { Width = 150 };
            dtpTra = new DateTimePicker { Width = 150 };

            // Button
            btnLayThongTin = new Button
            {
                Text = "Lấy thông tin",
                Width = 100,
                BackColor = Color.FromArgb(227, 239, 255)
            };
        }

        private void AddFormControls(TableLayoutPanel mainLayout)
        {
            int row = 0;

            // Số hồ sơ with button
            AddControlWithButton(mainLayout, "Số hồ sơ:", txtSoHoSo, btnLayThongTin, row++);

            // Mã with số thứ tự
            TableLayoutPanel maPanel = new TableLayoutPanel
            {
                ColumnCount = 4,
                Dock = DockStyle.Fill
            };
            maPanel.Controls.Add(cmbMa, 0, 0);
            maPanel.Controls.Add(new Label { Text = "Số thứ tự:", Margin = new Padding(10, 0, 0, 0) }, 2, 0);
            maPanel.Controls.Add(txtSoThuTu1, 3, 0);
            AddControlRow(mainLayout, "Mã:", maPanel, row++);

            AddControlRow(mainLayout, "Bộ phận tiếp nhận:", txtBoPhan, row++);
            AddControlRow(mainLayout, "Tên dự án:", txtDuAn, row++);
            AddControlRow(mainLayout, "Chủ dự án:", txtChuDuAn, row++);
            AddControlRow(mainLayout, "Địa chỉ:", txtDiaChi, row++);

            // Contact info
            TableLayoutPanel contactPanel = new TableLayoutPanel
            {
                ColumnCount = 4,
                Dock = DockStyle.Fill
            };
            contactPanel.Controls.Add(txtDienThoai, 0, 0);
            contactPanel.Controls.Add(new Label { Text = "Email:", Margin = new Padding(10, 0, 0, 0) }, 2, 0);
            contactPanel.Controls.Add(txtEmail, 3, 0);
            AddControlRow(mainLayout, "Điện thoại:", contactPanel, row++);

            AddControlRow(mainLayout, "Nội dung yêu cầu giải quyết:", txtNoiDung, row++);
            AddControlRow(mainLayout, "Thành phần hồ sơ:", txtThanhPhan, row++);

            // Số lượng and thời gian
            TableLayoutPanel thoiGianPanel = new TableLayoutPanel
            {
                ColumnCount = 4,
                Dock = DockStyle.Fill
            };
            thoiGianPanel.Controls.Add(new TextBox { Width = 100 }, 0, 0);
            thoiGianPanel.Controls.Add(new Label { Text = "Thời gian theo qui định:", Margin = new Padding(10, 0, 0, 0) }, 2, 0);
            thoiGianPanel.Controls.Add(cmbThoiGian, 3, 0);
            AddControlRow(mainLayout, "Số lượng hồ sơ:", thoiGianPanel, row++);

            // Dates
            TableLayoutPanel datesPanel = new TableLayoutPanel
            {
                ColumnCount = 4,
                Dock = DockStyle.Fill
            };
            datesPanel.Controls.Add(dtpNhan, 0, 0);
            datesPanel.Controls.Add(new Label { Text = "Thời gian trả:", Margin = new Padding(10, 0, 0, 0) }, 2, 0);
            datesPanel.Controls.Add(dtpTra, 3, 0);
            AddControlRow(mainLayout, "Thời gian nhận:", datesPanel, row++);

            AddControlRow(mainLayout, "Đăng ký nhận kết quả tại:", txtKetQua, row++);

            // Quyển số
            TableLayoutPanel quyenSoPanel = new TableLayoutPanel
            {
                ColumnCount = 4,
                Dock = DockStyle.Fill
            };
            quyenSoPanel.Controls.Add(txtQuyenSo, 0, 0);
            quyenSoPanel.Controls.Add(new Label { Text = "Số thứ tự:", Margin = new Padding(10, 0, 0, 0) }, 2, 0);
            quyenSoPanel.Controls.Add(txtSoThuTu2, 3, 0);
            AddControlRow(mainLayout, "Quyển số:", quyenSoPanel, row);
        }

        private void AddControlRow(TableLayoutPanel panel, string labelText, Control control, int row)
        {
            panel.Controls.Add(new Label { Text = labelText, Dock = DockStyle.Fill }, 0, row);
            panel.Controls.Add(control, 1, row);
        }

        private void AddControlWithButton(TableLayoutPanel panel, string labelText, Control control, Button button, int row)
        {
            panel.Controls.Add(new Label { Text = labelText }, 0, row);

            TableLayoutPanel controlPanel = new TableLayoutPanel
            {
                ColumnCount = 2,
                Dock = DockStyle.Fill
            };
            controlPanel.Controls.Add(control, 0, 0);
            controlPanel.Controls.Add(button, 1, 0);

            panel.Controls.Add(controlPanel, 1, row);
        }

        private Image GetSystemIcon(string type)
        {
            switch (type)
            {
                case "save": return SystemIcons.Application.ToBitmap();
                case "refresh": return SystemIcons.Information.ToBitmap();
                case "print": return SystemIcons.Exclamation.ToBitmap();
                default: return null;
            }
        }
    }
}