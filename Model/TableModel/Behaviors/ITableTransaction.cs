using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableMonitoring
{
    public interface ITableTransaction
    {
        int TransactionType();
        double GetTotalAmount(Transaction currentTransaction);
        double checkRunningAmount(Transaction table);
        string Transaction();
        double GetRate(Transaction currentTransaction);
    }
}
