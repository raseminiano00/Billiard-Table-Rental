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

        public TablePresenter presenter { set => throw new NotImplementedException(); }
        public BindingList<TableViewModel> tableList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int SelectedTable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
