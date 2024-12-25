// DocumentDetailForm.cs
using System;
using System.Drawing;
using System.Reflection.Metadata;
using System.Windows.Forms;

namespace QLDAPMM
{
    public partial class DocumentDetailForm : Form
    {
        private DatabaseConnection _db;

        public DocumentDetailForm(DatabaseConnection db)
        {
            InitializeComponent();
            _db = db;

            // Wire up button events
            
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                var doc = new Document
                {
                    SoHoSo = txtSoHoSo.Text,
                    Ma = cmbMa.Text,
                    STT = txtSTT.Text,
                    BoPhanTiepNhan = txtBoPhanTiepNhan.Text,
                    TenDuAn = txtTenDuAn.Text,
                    ChuDuAn = txtChuDuAn.Text,
                    DiaChi = txtDiaChi.Text,
                    DienThoai = txtDienThoai.Text,
                    Email = txtEmail.Text,
                    NoiDung = txtNoiDung.Text,
                    ThanhPhan = txtThanhPhan.Text,
                    SoLuong = txtSoLuong.Text,
                    ThoiGianQuyDinh = cmbThoiGianQuyDinh.Text,
                    ThoiGianNhan = cmbThoiGianNhan.Text,
                    ThoiGianTra = cmbThoiGianTra.Text,
                    DangKy = txtDangKy.Text
                };

                _db.SaveDocument(doc);
                MessageBox.Show("Lưu thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}");
            }
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                // Similar to save but update existing record
                var doc = GetDocumentFromForm();
                _db.UpdateDocument(doc);
                MessageBox.Show("Cập nhật thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}");
            }
        }

        private void BtnLay_Click(object sender, EventArgs e)
        {
            var soHoSo = txtSoHoSo.Text;
            var doc = _db.GetDocument(soHoSo);
            if (doc != null)
            {
                PopulateForm(doc);
            }
            else
            {
                MessageBox.Show("Không tìm thấy hồ sơ");
            }
        }

        private void BtnIn_Click(object sender, EventArgs e)
        {
            // Implement print functionality
        }

        private void BtnInTrucTiep_Click(object sender, EventArgs e)
        {
            // Implement direct print functionality
        }

        private Document GetDocumentFromForm()
        {
            return new Document
            {
                SoHoSo = txtSoHoSo.Text,
                Ma = cmbMa.Text,
                STT = txtSTT.Text,
                // Map other fields similarly
            };
        }

        private void PopulateForm(Document doc)
        {
            txtSoHoSo.Text = doc.SoHoSo;
            cmbMa.Text = doc.Ma;
            txtSTT.Text = doc.STT;
            // Populate other fields similarly
        }
    }
}