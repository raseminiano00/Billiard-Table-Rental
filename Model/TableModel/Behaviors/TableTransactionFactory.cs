using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableMonitoring
{
    public class TableTransactionFactory
    {
        public static ITableTransaction GetTransType(int transType)
        {
            ITableTransaction retTransType;
            switch (transType)
            {
                case 1:
                    retTransType = new PerHour();
                    break;
                default:
                    retTransType = null;
                    break;
            }
            return retTransType;
        }
    }
}
