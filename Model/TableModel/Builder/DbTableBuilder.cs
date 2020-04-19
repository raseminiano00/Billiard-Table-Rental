using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableMonitoring           
{
    public class DbTableBuilder : ITableBuilder
    {
        public DbTableBuilder(ITableTransaction transType,ITableState tableState,Transaction currentTransaction)
        {
            this.TransactionType = transType;
            this.TableState = tableState;
            this.Transaction = currentTransaction;
        }
        public int TableId { get; set; }
        public double HourlyRate { get; set; }
        public double GameRate { get; set; }
        public ITableTransaction TransactionType { get; set; }
        public ITableState TableState { get; set; }
        public DateTime timeIn { get; set; }
        public Transaction Transaction { get; set; }

        public TableModel Construct()
        {
            TableModel createdTable = new TableModel(TableState,TransactionType, Transaction);
            TableState.SetTableModel(createdTable);
            createdTable.TableId = TableId;

            return createdTable;
        }

        public ITableBuilder SetTabledId(int id)
        {
            this.TableId = id;
            return this;
        }

    }
}
