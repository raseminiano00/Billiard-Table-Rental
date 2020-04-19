using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableMonitoring
{
    public class Occupied : ITableState
    {
        ITableModel _tableModel;
        public ITableState GetRentTime(Action currentRentTime, Action totalRentTime)
        {
            currentRentTime();
            return this;
        }
        public ITableState GetTransactionRate(Action action)
        {
            action();
            return this;
        }

        public ITableState GetTransactionType(Action action)
        {
            action();
            return this;
        }

        public void PayOut(Action toVacant)
        {

        }

        public ITableState RunningAmount(Action checkRunningAmt)
        {
            checkRunningAmt();
            return this;
        }

        public ITableState saveCurrentTransaction(Action toSave)
        {
            toSave();
            return this;
        }
        public string State()
        {
            return "OCCUPIED";
        }
        public string StateColor()
        {
            return "Red";
        }

        public int StateType()
        {
            return 1;
        }

        public void TimeIn(Action timeIn)
        {

        }

        public void SetTransaction(Action timeOut)
        {

            var newState = new CheckedOut();
            newState.SetTableModel(_tableModel);
            SetTableState(newState);
            timeOut();
        }
        public ITableState GetTransaction(Action getTransaction)
        {
            getTransaction();
            return this;
        }

        public ITableState GetTransactionDetails(Action occupiedInvoke, Action checkedOutInvoke)
        {
            occupiedInvoke();
            return this;
        }
        public void SetTableModel(ITableModel model)
        {
            _tableModel = model;
        }
        public void SetTableState(ITableState newState)
        {
            _tableModel.SetState(newState);
        }
        public void SaveTransaction(Action saveTransaction)
        {
        }
    }
}
