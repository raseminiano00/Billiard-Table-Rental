using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableMonitoring.Model;
using TableMonitoring.Presenter;
namespace TableMonitoring.View
{
    public interface ITableMonitorView
    {
        TablePresenter presenter { set; }
        BindingList<TableViewModel> tableList { get; set; }

        int SelectedTable { get; set; }


    }
}
