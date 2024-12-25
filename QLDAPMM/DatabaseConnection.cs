using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Windows.Forms;

namespace QLDAPMM
{
    public class DatabaseConnection
    {
        private readonly string _connectionString;

        public DatabaseConnection()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["HSMT"].ConnectionString;
        }

        public void SaveDocument(Document doc)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Save main document entry
                            SaveMainDocument(doc, conn, transaction);

                            // Save metadata
                            SaveDocumentMeta(doc, conn, transaction);

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu hồ sơ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveMainDocument(Document doc, SqlConnection conn, SqlTransaction transaction)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.Transaction = transaction;
                cmd.CommandText = @"
                    INSERT INTO MoiTruongs 
                    (Id, CreateDate, ModifiedDate, ParentId, UserId, MT_Type) 
                    VALUES 
                    (@Id, @CreateDate, @ModifiedDate, @ParentId, @UserId, @MT_Type)";

                cmd.Parameters.AddWithValue("@Id", doc.SoHoSo);
                cmd.Parameters.AddWithValue("@CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@ParentId", "1");
                cmd.Parameters.AddWithValue("@UserId", "1");
                cmd.Parameters.AddWithValue("@MT_Type", "HoSo");

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateDocument(Document doc)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            UpdateMainDocument(doc, conn, transaction);
                            UpdateDocumentMeta(doc, conn, transaction);
                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật hồ sơ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateMainDocument(Document doc, SqlConnection conn, SqlTransaction transaction)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.Transaction = transaction;
                cmd.CommandText = @"
                    UPDATE MoiTruongs 
                    SET ModifiedDate = @ModifiedDate 
                    WHERE Id = @Id";

                cmd.Parameters.AddWithValue("@Id", doc.SoHoSo);
                cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                cmd.ExecuteNonQuery();
            }
        }

        public Document GetDocument(string soHoSo)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    var doc = GetMainDocument(soHoSo, conn);
                    if (doc != null)
                    {
                        FillDocumentMetadata(doc, conn);
                    }
                    return doc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm hồ sơ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private Document GetMainDocument(string soHoSo, SqlConnection conn)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM MoiTruongs WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", soHoSo);

                using (var reader = cmd.ExecuteReader())
                {
                    return reader.Read() ? new Document { SoHoSo = soHoSo } : null;
                }
            }
        }

        private void FillDocumentMetadata(Document doc, SqlConnection conn)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT MetaKey, MetaValue FROM MoiTruongMetas WHERE MoiTruongId = @Id";
                cmd.Parameters.AddWithValue("@Id", doc.SoHoSo);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var key = reader["MetaKey"].ToString();
                        var value = reader["MetaValue"].ToString();

                        switch (key)
                        {
                            case "Mã số": doc.Ma = value; break;
                            case "Số thứ tự": doc.STT = value; break;
                            case "Bộ phận tiếp nhận": doc.BoPhanTiepNhan = value; break;
                            case "Tên dự án": doc.TenDuAn = value; break;
                            case "Chủ dự án": doc.ChuDuAn = value; break;
                            case "Địa chỉ": doc.DiaChi = value; break;
                            case "Điện thoại": doc.DienThoai = value; break;
                            case "Email": doc.Email = value; break;
                        }
                    }
                }
            }
        }

        private void SaveDocumentMeta(Document doc, SqlConnection conn, SqlTransaction transaction)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.Transaction = transaction;
                cmd.CommandText = @"
                    INSERT INTO MoiTruongMetas 
                    (MetaId, MoiTruongId, MetaKey, MetaValue) 
                    VALUES 
                    (@MetaId, @MoiTruongId, @MetaKey, @MetaValue)";

                var metaData = new[]
                {
                    new { Key = "Mã số", Value = doc.Ma },
                    new { Key = "Số thứ tự", Value = doc.STT },
                    new { Key = "Bộ phận tiếp nhận", Value = doc.BoPhanTiepNhan },
                    new { Key = "Tên dự án", Value = doc.TenDuAn },
                    new { Key = "Chủ dự án", Value = doc.ChuDuAn },
                    new { Key = "Địa chỉ", Value = doc.DiaChi },
                    new { Key = "Điện thoại", Value = doc.DienThoai },
                    new { Key = "Email", Value = doc.Email }
                };

                foreach (var meta in metaData)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@MetaId", Guid.NewGuid().ToString("N").Substring(0, 10));
                    cmd.Parameters.AddWithValue("@MoiTruongId", doc.SoHoSo);
                    cmd.Parameters.AddWithValue("@MetaKey", meta.Key);
                    cmd.Parameters.AddWithValue("@MetaValue", meta.Value ?? "");

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void UpdateDocumentMeta(Document doc, SqlConnection conn, SqlTransaction transaction)
        {
            // Delete existing metadata
            using (var deleteCmd = conn.CreateCommand())
            {
                deleteCmd.Transaction = transaction;
                deleteCmd.CommandText = "DELETE FROM MoiTruongMetas WHERE MoiTruongId = @Id";
                deleteCmd.Parameters.AddWithValue("@Id", doc.SoHoSo);
                deleteCmd.ExecuteNonQuery();
            }

            // Save new metadata
            SaveDocumentMeta(doc, conn, transaction);
        }
    }
}
public class Document
{
    public string SoHoSo { get; set; }
    public string Ma { get; set; }
    public string STT { get; set; }
    public string BoPhanTiepNhan { get; set; }
    public string TenDuAn { get; set; }
    public string ChuDuAn { get; set; }
    public string DiaChi { get; set; }
    public string DienThoai { get; set; }
    public string Email { get; set; }
    public string NoiDung { get; set; }
    public string ThanhPhan { get; set; }
    public string SoLuong { get; set; }
    public string ThoiGianQuyDinh { get; set; }
    public string ThoiGianNhan { get; set; }
    public string ThoiGianTra { get; set; }
    public string DangKy { get; set; }
}