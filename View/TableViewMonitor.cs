using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TableMonitoring.Presenter;

namespace TableMonitoring
{
    public partial class TableViewMonitor : Form, ITableMonitorView
    {
        public TableViewMonitor()
        {
            InitializeComponent();
            table = new TableManager(Color.IndianRed);
            table.Dock = DockStyle.Fill;
            this.Controls.Add(table);
        }
        private TableManager table;

        public TablePresenter presenter { private get; set; }
        public int SelectedTable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        private List<TableViewModel> _tableList;
        public List<TableViewModel> tableList
        {
            get {
                return _tableList;
            }
            set {
                _tableList = value;
                table.SetTables(new TableViewBuilder(value).Construct());
            }
        }

        private void LayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
