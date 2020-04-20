using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableMonitoring
{
    public class TableViewBuilder
    {
        private List<TableViewModel> _viewModel;
        public TableViewBuilder(List<TableViewModel> viewModelList)
        {
            this._viewModel = viewModelList;
        }

        public List<TableView> Construct()
        {
            List<TableView> createdList = new List<TableView>();
            foreach (TableViewModel viewModel in _viewModel)
            {
                TableView createdTableView = new TableView(viewModel);
                createdList.Add(createdTableView);
            }
            return createdList;
        }


    }
}
