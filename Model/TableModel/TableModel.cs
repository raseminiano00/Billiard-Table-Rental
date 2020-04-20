using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableMonitoring
{
    public class TableModel : ITableModel
    {
        private ITableState tableState;
        private ITableTransaction rentTransaction;
        private Transaction currentTransaction;

        public int TableId { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public string State { get { return tableState.State(); } }

        public TableModel(ITableState state,Transaction trans)
        {
            tableState = state;
            currentTransaction = trans;
        }
        public TableModel(ITableState state, ITableTransaction rentTrans,Transaction trans)
        {
            tableState = state;
            currentTransaction = trans;
            rentTransaction = rentTrans;

        }

        public void TimeIn(ITableTransaction transType, Transaction newTransaction, Action<TableModel> saveCurrentTransaction)
        {
            this.tableState.TimeIn(() => {
                rentTransaction = transType;
                currentTransaction = newTransaction;
                SaveAction(saveCurrentTransaction);
            });
        }
        public void SetTransaction(Transaction checkedOutTransaction, Action<TableModel> saveCurrentTransaction)
        {
            this.tableState.SetTransaction(() => {
                currentTransaction = checkedOutTransaction;
                SaveAction(saveCurrentTransaction);
            });
            
        }
        public void SettleableTransaction(Action<TableModel> saveTransaction)
        {
            this.tableState.SaveTransaction(() => {
                SaveAction(saveTransaction);
            });
        }
        public void CheckOut(Action<TableModel> saveTransaction)
        {
            this.tableState.PayOut(() => {
                currentTransaction.toVacant();
                saveTransaction(this);
                rentTransaction = null;
            });
        }
        public Transaction GetTransaction()
        {
            Transaction ret = new Transaction();
            tableState = this.tableState.GetTransaction(() => {
                ret = currentTransaction;
            });
            return ret;
        }
        public double TransactionAmount
        {
            get
            {
                double ret = 0;
                tableState = this.tableState.GetTransactionDetails(() =>
                {
                    ret = rentTransaction.checkRunningAmount(currentTransaction);
                },
                () =>
                {
                    ret = rentTransaction.GetTotalAmount(currentTransaction);
                });
                return ret;
            }
        }
        public TimeSpan RentTime
        {
            get{
                TimeSpan ret = TimeSpan.FromHours(0);
                tableState = this.tableState.GetTransactionDetails(() => {
                    ret = currentTransaction.CurrentRentTime;
                },
                () => {
                    ret = currentTransaction.TotalRentTime;
                });
                return ret;
            }
        }
        public int NumberOfRacks
        {
            get
            {
                int ret = 0;
                Action getRacks = () =>
                {
                    ret = currentTransaction.TotalRacks;
                };
                tableState = this.tableState.GetTransactionDetails(getRacks, getRacks);
                return ret;
            }
        }
        public string TransactionType
        {
            get
            {
                string ret = "Vacant";
                Action GetTransactionType = () =>
                {
                    ret = rentTransaction.Transaction();
                };
                tableState = this.tableState.GetTransactionDetails(GetTransactionType, GetTransactionType);
                return ret;
            }
        }
        public DateTime TimeStarted {
            get
            {
                DateTime ret = new DateTime();
                Action GetTimeStarted = () =>
                {
                    ret = currentTransaction.TimeStarted;
                };
                tableState = this.tableState.GetTransactionDetails(GetTimeStarted, GetTimeStarted);
                return ret;
            }
        }
        public double TableRate {
            get
            {
                double ret =0;
                Action GetTimeStarted = () =>
                {
                    ret = rentTransaction.GetRate(currentTransaction);
                };
                tableState = this.tableState.GetTransactionDetails(GetTimeStarted, GetTimeStarted);
                return ret;
            }
        }
        public string TableState {
            get
            {
                string ret="VACANT";
                Action GetState= () =>
                {
                    ret = tableState.State();
                };
                tableState = this.tableState.GetTransactionDetails(GetState, GetState);
                return ret;
            }
        }
        public int TransactionTypeCode
        {
            get
            {
                int ret = 0;
                Action GetTransType = () =>
                {
                    ret = rentTransaction.TransactionType();
                };
                tableState = this.tableState.GetTransactionType(GetTransType);
                return ret;
            }
        }

        public int GetTableStateCode
        {
            get
            {
                return tableState.StateType();
            }
        }

        private void SaveAction(Action<TableModel> saveAction)
        {
            tableState = this.tableState.saveCurrentTransaction(() =>
            {
                saveAction(this);
            });
        }

        public void SetState(ITableState newState)
        {
            tableState = newState;
        }
    }
}
