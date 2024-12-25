using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLDAPMM
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ConfigureComponents();
        }

        private void ConfigureComponents()
        {
            // Setup MenuStrip
            menuStrip = new MenuStrip();
            menuStrip.Items.AddRange(new ToolStripItem[] {
                CreateFileMenu(),
                CreateDistrictMenu(),
                CreateProvinceMenu(),
                CreateMonitoringMenu(),
                CreateLegalMenu(),
                CreateConfigMenu()
            });

            // Setup TabControl
            tabControl = new TabControl
            {
                Dock = DockStyle.Fill
            };

            this.Controls.Add(menuStrip);
            this.Controls.Add(tabControl);
            this.MainMenuStrip = menuStrip;
        }

        private ToolStripMenuItem CreateFileMenu()
        {
            var menu = new ToolStripMenuItem("Hồ sơ");
            menu.Click += (s, e) => OpenFormInTab(new DocumentManagementForm(), "Quản lý Hồ sơ");
            return menu;
        }

        private ToolStripMenuItem CreateDistrictMenu()
        {
            var menu = new ToolStripMenuItem("Hồ sơ cấp Huyện");
            menu.Click += (s, e) => OpenFormInTab(new DistrictManagementForm(), "Hồ sơ cấp Huyện");
            return menu;
        }

        private ToolStripMenuItem CreateProvinceMenu()
        {
            var menu = new ToolStripMenuItem("Hồ sơ cấp Tỉnh");
            menu.Click += (s, e) => OpenFormInTab(new ProvinceManagementForm(), "Hồ sơ cấp Tỉnh");
            return menu;
        }

        private ToolStripMenuItem CreateMonitoringMenu()
        {
            var menu = new ToolStripMenuItem("Quan trắc môi trường");
            menu.Click += (s, e) => OpenFormInTab(new MonitoringForm(), "Quan trắc môi trường");
            return menu;
        }

        private ToolStripMenuItem CreateLegalMenu()
        {
            var menu = new ToolStripMenuItem("Văn bản pháp lý");
            menu.Click += (s, e) => OpenFormInTab(new LegalDocumentForm(), "Văn bản pháp lý");
            return menu;
        }

        private ToolStripMenuItem CreateConfigMenu()
        {
            var menu = new ToolStripMenuItem("Cấu hình hệ thống");
            menu.Click += (s, e) => OpenFormInTab(new SystemConfigForm(), "Cấu hình hệ thống");
            return menu;
        }

        private void OpenFormInTab(Form form, string tabText)
        {
            TabPage tabPage = new TabPage(tabText);
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            tabPage.Controls.Add(form);
            tabControl.TabPages.Add(tabPage);
            form.Show();
            tabControl.SelectedTab = tabPage;
        }
    }
}