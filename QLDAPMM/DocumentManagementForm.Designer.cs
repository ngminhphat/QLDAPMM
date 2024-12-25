namespace QLDAPMM
{
    partial class DocumentManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvDocuments;
        private ToolStrip toolStrip;
        private TextBox txtSearchBox;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnPrint;

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
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
        }
    }
}