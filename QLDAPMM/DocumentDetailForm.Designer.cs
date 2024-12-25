namespace QLDAPMM
{
    partial class DocumentDetailForm
    {
        private System.ComponentModel.IContainer components = null;
        private ToolStrip toolStrip;
        private TextBox txtSoHoSo;
        private ComboBox cmbMa;
        private TextBox txtSTT;
        private TextBox txtBoPhanTiepNhan;
        private TextBox txtTenDuAn;
        private TextBox txtChuDuAn;
        private TextBox txtDiaChi;
        private TextBox txtDienThoai;
        private TextBox txtEmail;
        private TextBox txtNoiDung;
        private TextBox txtThanhPhan;
        private TextBox txtSoLuong;
        private ComboBox cmbThoiGianQuyDinh;
        private ComboBox cmbThoiGianNhan;
        private ComboBox cmbThoiGianTra;
        private TextBox txtDangKy;
        private Button btnLay;
        private ToolStripButton btnLuu;
        private ToolStripButton btnCapNhat;
        private ToolStripButton btnIn;
        private ToolStripButton btnInTrucTiep;

        private Label lblSoHoSo;
        private Label lblMa;
        private Label lblSoThuTu;
        private Label lblBoPhanTiepNhan;
        private Label lblTenDuAn;
        private Label lblChuDuAn;
        private Label lblDiaChi;
        private Label lblDienThoai;
        private Label lblEmail;
        private Label lblNoiDung;
        private Label lblThanhPhan;
        private Label lblSoLuong;
        private Label lblThoiGianQuyDinh;
        private Label lblThoiGianNhan;
        private Label lblThoiGianTra;
        private Label lblDangKy;

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
            this.components = new System.ComponentModel.Container();
            this.Text = "Giấy biên nhận";
            this.Size = new Size(600, 600);

            toolStrip = new ToolStrip();
            toolStrip.Items.AddRange(new ToolStripItem[] {
               new ToolStripButton("Lưu"),
               new ToolStripButton("Cập nhật"),
               new ToolStripButton("In"),
               new ToolStripButton("In Trực Tiếp")
           });

            // Initialize controls
            txtSoHoSo = new TextBox();
            cmbMa = new ComboBox();
            txtSTT = new TextBox();
            txtBoPhanTiepNhan = new TextBox();
            txtTenDuAn = new TextBox();
            txtChuDuAn = new TextBox();
            txtDiaChi = new TextBox();
            txtDienThoai = new TextBox();
            txtEmail = new TextBox();
            txtNoiDung = new TextBox();
            txtThanhPhan = new TextBox();
            txtSoLuong = new TextBox();
            cmbThoiGianQuyDinh = new ComboBox();
            cmbThoiGianNhan = new ComboBox();
            cmbThoiGianTra = new ComboBox();
            txtDangKy = new TextBox();
            btnLay = new Button();

            // Initialize labels
            lblSoHoSo = new Label();
            lblMa = new Label();
            lblSoThuTu = new Label();
            lblBoPhanTiepNhan = new Label();
            lblTenDuAn = new Label();
            lblChuDuAn = new Label();
            lblDiaChi = new Label();
            lblDienThoai = new Label();
            lblEmail = new Label();
            lblNoiDung = new Label();
            lblThanhPhan = new Label();
            lblSoLuong = new Label();
            lblThoiGianQuyDinh = new Label();
            lblThoiGianNhan = new Label();
            lblThoiGianTra = new Label();
            lblDangKy = new Label();

            this.Controls.AddRange(new Control[] {
               toolStrip,
               txtSoHoSo, cmbMa, txtSTT, txtBoPhanTiepNhan,
               txtTenDuAn, txtChuDuAn, txtDiaChi,
               txtDienThoai, txtEmail, txtNoiDung,
               txtThanhPhan, txtSoLuong,
               cmbThoiGianQuyDinh, cmbThoiGianNhan,
               cmbThoiGianTra, txtDangKy, btnLay,
               lblSoHoSo, lblMa, lblSoThuTu,
               lblBoPhanTiepNhan, lblTenDuAn,
               lblChuDuAn, lblDiaChi, lblDienThoai,
               lblEmail, lblNoiDung, lblThanhPhan,
               lblSoLuong, lblThoiGianQuyDinh,
               lblThoiGianNhan, lblThoiGianTra, lblDangKy
           });
        }
    }
}