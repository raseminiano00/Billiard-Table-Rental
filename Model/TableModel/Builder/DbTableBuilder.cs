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


        public int Height { get; set; }

        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }


        public TableModel Construct()
        {
            TableModel createdTable = new TableModel(TableState,TransactionType, Transaction);
            TableState.SetTableModel(createdTable);
            createdTable.X = X;
            createdTable.Y = Y;
            createdTable.width= Width;
            createdTable.height = Height;
            createdTable.TableId = TableId;

            return createdTable;
        }

        public ITableBuilder SetTabledId(int id)
        {
            this.TableId = id;
            return this;
        }


        public ITableBuilder SetX(int X)
        {
            this.X = X;
            return this;
        }
        public ITableBuilder SetY(int Y)
        {
            this.Y = Y;
            return this;
        }
        public ITableBuilder SetWidth(int width)
        {
            this.Width = width;
            return this;
        }
        public ITableBuilder SetHeight(int height)
        {
            this.Height = height;
            return this;
        }
    }
}
