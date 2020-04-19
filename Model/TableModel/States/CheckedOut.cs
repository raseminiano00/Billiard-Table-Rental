using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableMonitoring
{
    public class CheckedOut : ITableState
    {
        ITableModel _tableModel;
        public ITableState GetRentTime(Action currentRentTime, Action totalRentTime)
        {
            totalRentTime();
            return this;
        }

        public ITableState GetTransaction(Action getTransaction)
        {
            getTransaction();
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
            var newState = new Vacant();
            newState.SetTableModel(_tableModel);
            SetTableState(newState);
            toVacant();

        }

        public ITableState RunningAmount(Action checkRunningAmt) => this;

        public ITableState saveCurrentTransaction(Action toSave)
        {
            toSave();
            return this;
        }

        public string State()
        {
            return "OUT";
        }

        public string StateColor()
        {
            return "Orange";
        }

        public int StateType()
        {
            return 2;
        }

        public void TimeIn(Action timeIn)
        {

        }

        public void SetTransaction(Action timeOut)
        {

        }


        public ITableState GetTransactionDetails(Action occupiedInvoke, Action checkedOutInvoke)
        {
            checkedOutInvoke();
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
            saveTransaction();
        }
    }
}
