using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableMonitoring
{
    public class Vacant : ITableState
    {
        private ITableModel _tableModel;

        public ITableState GetTransaction(Action getTransaction)
        {
            getTransaction();
            return this;
        }

        public ITableState RunningAmount(Action checkRunningAmt) => this;

        public ITableState saveCurrentTransaction(Action toSave) => this;

        public string StateColor()
        {
            return "White";
        }
        public string State()
        {
            return "Vacant";
        }

        public int StateType()
        {
            return 0;
        }

        public void TimeIn(Action timeIn)
        {
            var newState = new Occupied();
            newState.SetTableModel(_tableModel);
            this.SetTableState(newState);
            timeIn();
        }

        public void SetTransaction(Action timeOut)
        {

        }

        public ITableState GetTransactionType(Action action) => this;

        public ITableState GetTransactionRate(Action action) => this;

        public ITableState GetRentTime(Action action) => this;


        public ITableState GetTransactionDetails(Action occupiedInvoke, Action checkedOutInvoke) => this;

        public void SetTableModel(ITableModel model)
        {
            _tableModel = model;
        }
        public void SetTableState(ITableState newState)
        {
            _tableModel.SetState(newState);
        }

        public void PayOut(Action toVacant)
        {

        }
        public void SaveTransaction(Action saveTransaction)
        {
            
        }
    }
}
