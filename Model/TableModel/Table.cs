using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableMonitoring
{
    public class Table
    {
        public Table(ITableState dbState)
        {
            this.state = dbState;
        }

        [System.ComponentModel.DisplayName("Table ID")]
        public double tableId { get; set; }

        [System.ComponentModel.DisplayName("Time Started")]
        public DateTime timeStarted { get; set; }

        [System.ComponentModel.DisplayName("Table Rate")]
        public double rate {
            get
            {
                double ret = 0;
                state = this.state.GetTransactionRate(() => {
                    ret = transaction.GetRate(_tableRate);
                });
                return ret;
            }
        }

        [System.ComponentModel.DisplayName("Rent Time")]
        public TimeSpan totalRentTime { get; set; }

        [System.ComponentModel.DisplayName("Transaction")]
        public string TransactionType {
            get
            {
                string ret = "Vacant";
                state = this.state.GetTransactionType(() => {
                    ret = transaction.Transaction();
                });
                return ret;
            }
        }
        [System.ComponentModel.DisplayName("Table State")]
        public string State { get { return state.State(); } }

        [System.ComponentModel.DisplayName("Rent Amount")]
        public double runningRentAmount {
            get
            {
                state = this.state.RunningAmount(() => {
                    currentRunningRentAmount = transaction.checkRunningAmount(this);
                });
                return currentRunningRentAmount;
            }
        }
        private DateTime _timeEnded { get; set; }
        public DateTime timeEnded() { return _timeEnded; }
        public void timeEnded(DateTime value) { _timeEnded = value; }


        private Rate _tableRate { get; set; }
        public Rate GetTableRate()
        {
            return _tableRate;
        }
        public void SetTableRate (Rate rateInst)
        {
            _tableRate = rateInst;
        }

        private double currentRunningRentAmount { get; set; }

        private ITableState state;

        private ITableTransaction transaction;

        private Transaction tableTransaction;

        public void SetTransaction(Transaction newTransaction)
        {
            tableTransaction = newTransaction;
        }
        public Transaction GetTransaction()
        {
            return tableTransaction;
        }
        public int GetTransactionTypeCode()
        {
            int ret = 0;
            state = this.state.GetTransactionType(() => {
                ret = transaction.TransactionType();
            });
            return ret;
        }
        public int GetStateCode()
        {
            return state.StateType();
        }

        public void TimeIn(ITableTransaction transType, Action<Table> saveCurrentTransaction, DateTime timeStarted)
        {
            state = this.state.TimeIn(() => {
                transaction = transType;
                this.timeStarted = timeStarted;
                Console.WriteLine(state.StateType());
            });

            state = this.state.saveCurrentTransaction(() =>
            {
                saveCurrentTransaction(this);
            });
        }
        public string StateColor()
        {
            return state.StateColor();
        }
        public void TimeOut()
        {
            state = this.state.TimeOut(() => {
                this.timeEnded(DateTime.Now);
                this.transaction.timeOut(this);
            });
        }

        public void ToVacant(Action<Table> saveDetails)
        {
            state = this.state.PayOut(() => {
                saveDetails(this);
                transactionEnded();
            });
        }

        private void transactionEnded()
        {
            timeStarted = DateTime.MinValue;
            timeEnded(DateTime.MinValue);
            totalRentTime = TimeSpan.MinValue;
            currentRunningRentAmount = 0;
        }

    }
}
