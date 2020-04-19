using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.TableObject.State
{
    public interface ITableState
    {
        ITableState TimeIn(Action timeIn);
        ITableState TimeOut(Action timeOut);
        ITableState RunningAmount(Action checkRunningAmt);
        ITableState PayOut(Action toVacant);
        string StateColor();
    }
}
