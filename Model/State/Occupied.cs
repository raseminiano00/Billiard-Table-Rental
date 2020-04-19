using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.TableObject.State
{
    public class Occupied : ITableState
    {
        public ITableState PayOut(Action toVacant) => this;

        public ITableState RunningAmount(Action checkRunningAmt)
        {
            checkRunningAmt();
            return this;
        }

        public string StateColor()
        {
            return "Red";
        }

        public ITableState TimeIn(Action timeIn) => this;

        public ITableState TimeOut(Action timeOut)
        {
            timeOut();
            return new CheckedOut();
        }
    }
}
