using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.TableObject.State
{
    public class Vacant : ITableState
    {
        public ITableState PayOut(Action toVacant) => this;

        public ITableState RunningAmount(Action checkRunningAmt) => this;

        public string StateColor()
        {
            return "White";
        }

        public ITableState TimeIn(Action timeIn)
        {
            timeIn();
            return new Occupied();
        }

        public ITableState TimeOut(Action timeOut) => this;
    }
}
