using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.TableObject.State
{
    public class CheckedOut : ITableState
    {
        public ITableState PayOut(Action toVacant)
        {
            toVacant();
            return new Vacant();
        }

        public ITableState RunningAmount(Action checkRunningAmt) => this;
        public string StateColor()
        {
            return "Orange";
        }
        public ITableState TimeIn(Action timeIn) => this;

        public ITableState TimeOut(Action timeOut) => this;
    }
}
