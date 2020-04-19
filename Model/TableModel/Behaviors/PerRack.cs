using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableMonitoring.Model.TableModel.Behaviors
{
    public class PerRack : ITableTransaction
    {
        public double checkRunningAmount(Transaction table)
        {
            return (table.TotalRacks * table.RackRate);
        }

        public double GetRate(Transaction currentTransaction)
        {
            return currentTransaction.RackRate;
        }

        public double GetTotalAmount(Transaction currentTransaction)
        {
            return (currentTransaction.TotalRacks * currentTransaction.RackRate);
        }

        public string Transaction()
        {
            return "Per Rack Rate";
        }

        public int TransactionType()
        {
            return 2;
        }
    }
}
