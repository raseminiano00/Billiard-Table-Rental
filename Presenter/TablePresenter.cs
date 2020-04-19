using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableMonitoring.Model;
using TableMonitoring.Repository;
using TableMonitoring.View;
namespace TableMonitoring.Presenter
{
    public class TablePresenter
    {
        private readonly ITableMonitorView _view;
        private readonly ITableRepository _repository;
        public TablePresenter(ITableRepository repository, ITableMonitorView view)
        {
            _view = view;
            _repository = repository;
            _view.presenter = this;
            updateTable();
        }

        public void updateTable()
        {
            var tableList = TableView();
            _view.tableList = tableList;
        }

        public void tableIn(int i)
        {
            TableModel table = _repository.GetATable(i);
            Transaction tableTransaction = new TransactionBuilder()
                .DuplicateTransaction(table.GetTransaction())
                .Duplicate();
            tableTransaction.TimeStarted = DateTime.Now;
            table.TimeIn(new PerHour(), tableTransaction, _repository.saveCurrentTransaction());
        }
        public void tablePerGame(int i)
        {
            TableModel table = _repository.GetATable(i);
            Transaction tableTransaction = new TransactionBuilder()
                .DuplicateTransaction(table.GetTransaction())
                .Duplicate();
            tableTransaction.TimeStarted = DateTime.Now;
            table.TimeIn(new PerHour(), tableTransaction, _repository.saveCurrentTransaction());
        }
        public void TableOut(int i)
        {
            TableModel table = _repository.GetATable(i);
            Transaction tableTransaction = new TransactionBuilder()
                .DuplicateTransaction(table.GetTransaction())
                .Duplicate();
            tableTransaction.TimeEnded= DateTime.Now;
            table.SetTransaction(tableTransaction, _repository.saveCheckOutTransaction());
        }
        private BindingList<TableViewModel> TableView()
        {
            var ret = new BindingList<TableViewModel>();
            foreach (TableModel model in _repository.GetAllTables())
            {
                var temp = new TableViewModel(model);
                ret.Add(temp);
            }
           return ret;
        }

        internal void RefreshTable()
        {
            _view.tableList = TableView();
        }
        public void TablePayOut(int i)
        {
            TableModel table = _repository.GetATable(i);
            table.SettleableTransaction(_repository.saveAction());
            table.CheckOut(_repository.saveCurrentTransaction());
        }
    }
}
