using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableMonitoring.Model;
namespace TableMonitoring
{
    public interface ITableRepository
    {
        BindingList<TableModel> GetAllTables();
        TableModel GetATable(int id);
        Action<TableModel> saveCurrentTransaction();

        Action<TableModel> saveCheckOutTransaction();
        Action<TableModel> saveAction();
    }
}
