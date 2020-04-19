using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableMonitoring
{
    public class TableStateFactory
    {
        public static ITableState getTableStateByCode(int tableState)
        {
            ITableState ret;
            switch (tableState)
            {
                case 0:
                    ret = new Vacant();
                    break;
                case 1:
                    ret = new Occupied();
                    break;
                case 2:
                    ret = new CheckedOut();
                    break;
                default:
                    ret = new Vacant();
                    break;
            }
            return ret;
        }
    }
}
