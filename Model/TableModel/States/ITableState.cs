using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableMonitoring
{
    public interface ITableState
    {
        void TimeIn(Action timeIn);
        void SetTransaction(Action timeOut);
        ITableState RunningAmount(Action checkRunningAmt);
        void PayOut(Action toVacant);
        string StateColor();
        int StateType();
        string State();
        ITableState GetTransactionType(Action action);

        ITableState GetTransactionRate(Action action);
        ITableState saveCurrentTransaction(Action toSave);

        ITableState GetTransaction(Action getTransaction);
        ITableState GetTransactionDetails(Action occupiedInvoke,Action checkedOutInvoke);

        void SetTableModel(ITableModel model);

        void SetTableState(ITableState newState);

        void SaveTransaction(Action saveTransaction);
    }
}
