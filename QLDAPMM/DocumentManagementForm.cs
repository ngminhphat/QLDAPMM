using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLDAPMM
{
    public partial class DocumentManagementForm : Form
    {
        public DocumentManagementForm()
        {
            _db = new DatabaseConnection();
            InitializeComponent();
            ConfigureComponents();
        }
        private DatabaseConnection _db;
        private void ConfigureComponents()
        {
            InitializeToolStrip();
            InitializeDataGridView();
            InitializeButtons();
            this.Controls.AddRange(new Control[] { toolStrip, dgvDocuments });
        }

        private void InitializeToolStrip()
        {
            toolStrip = new ToolStrip();
            var btnNew = new ToolStripButton("Thêm mới");
            var btnList = new ToolStripButton("Xem danh sách");

            btnNew.Click += BtnNew_Click;
            btnList.Click += BtnList_Click;

            toolStrip.Items.AddRange(new ToolStripItem[] { btnNew, btnList });
        }

        private void InitializeDataGridView()
        {
            dgvDocuments = new DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            dgvDocuments.Columns.AddRange(new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn() { Name = "ID", HeaderText = "Số hồ sơ", Width = 100 },
                new DataGridViewTextBoxColumn() { Name = "ProjectName", HeaderText = "Tên dự án", Width = 200 },
                new DataGridViewTextBoxColumn() { Name = "Owner", HeaderText = "Chủ dự án", Width = 150 },
                new DataGridViewTextBoxColumn() { Name = "Address", HeaderText = "Địa chỉ", Width = 200 },
                new DataGridViewTextBoxColumn() { Name = "Phone", HeaderText = "Điện thoại", Width = 100 },
                new DataGridViewTextBoxColumn() { Name = "Email", HeaderText = "Email", Width = 150 }
            });

            dgvDocuments.CellDoubleClick += DgvDocuments_CellDoubleClick;
        }

        private void InitializeButtons()
        {
            btnAdd = new Button { Text = "Thêm", Size = new Size(80, 30) };
            btnEdit = new Button { Text = "Sửa", Size = new Size(80, 30) };
            btnDelete = new Button { Text = "Xóa", Size = new Size(80, 30) };
            btnPrint = new Button { Text = "In", Size = new Size(80, 30) };

            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnPrint.Click += BtnPrint_Click;
        }

        #region Event Handlers
        private void BtnNew_Click(object sender, EventArgs e)
        {
            using (var form = new DocumentDetailForm(_db)) // Truyền kết nối CSDL
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Làm mới dữ liệu
                    LoadDocuments();
                }
            }
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            LoadDocuments();
        }

        private void DgvDocuments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EditDocument(e.RowIndex);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new DocumentDetailForm(_db))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadDocuments();
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDocuments.CurrentRow != null)
            {
                EditDocument(dgvDocuments.CurrentRow.Index);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDocuments.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa hồ sơ này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteDocument(dgvDocuments.CurrentRow.Index);
                }
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument();
        }
        #endregion

        #region Helper Methods
        private void LoadDocuments()
        {
            // TODO: Implement data loading from database
        }

        private void EditDocument(int rowIndex)
        {
            // TODO: Implement document editing
        }

        private void DeleteDocument(int rowIndex)
        {
            // TODO: Implement document deletion
        }

        private void PrintDocument()
        {
            // TODO: Implement document printing
        }
        #endregion
    }
}