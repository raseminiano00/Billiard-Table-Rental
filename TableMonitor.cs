using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TableMonitoring.Model;
using TableMonitoring.Presenter;
using TableMonitoring.View;
namespace TableMonitoring
{
    public partial class TableMonitor : Form,ITableMonitorView
    {
        public TableMonitor()
        {
            InitializeComponent();
            dgvTableRefresher.Start();
        }

        public BindingList<TableViewModel> tableList {
            get { return (BindingList<TableViewModel>)this.dataGridView1.DataSource; }
            set { dataGridView1.DataSource = value; }
        }

        public int SelectedTable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TablePresenter presenter { private get; set; }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            presenter.tableIn(dataGridView1.CurrentRow.Index);
        }

        private void DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgvTableRefresher_Tick(object sender, EventArgs e)
        {
            dataGridView1.Refresh();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            presenter.TableOut(dataGridView1.CurrentRow.Index);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            presenter.TablePayOut(dataGridView1.CurrentRow.Index);
        }

        private void Button4_Click(object sender, EventArgs e)
        {

        }
    }
}
