using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableMonitoring
{
    public class TransactionBuilder
    {
        private DateTime TimeStarted;
        private DateTime TimeEnded;
        private double HourlyRate;
        private double RackRate;
        private int TotalRacks;
        private Transaction duplicateTransaction;

        public TransactionBuilder SetTimeStarted(DateTime timeStarted)
        {
            this.TimeStarted = timeStarted;
            return this;
        }
        public TransactionBuilder SetTimeEnded(DateTime timeEnded)
        {
            this.TimeEnded = timeEnded;
            return this;
        }
        public TransactionBuilder SetHourlyRate(double hourlyRate)
        {
            this.HourlyRate= hourlyRate;
            return this;
        }
        public TransactionBuilder SetRackRate(double rackRate)
        {
            this.RackRate= rackRate;
            return this;
        }
        public TransactionBuilder SetTotalRacks(int totalRacks)
        {
            this.TotalRacks= totalRacks;
            return this;
        }
        public TransactionBuilder DuplicateTransaction(Transaction toDuplicate)
        {
            this.duplicateTransaction= toDuplicate;
            return this;
        }

        public Transaction Construct()
        {
            Transaction createdTransaction = new Transaction();
            createdTransaction.HourlyRate = this.HourlyRate;
            createdTransaction.TimeStarted= this.TimeStarted;
            createdTransaction.TimeEnded = this.TimeEnded;
            createdTransaction.RackRate= this.RackRate;
            createdTransaction.TotalRacks= this.TotalRacks;
            return createdTransaction;
        }
        public Transaction Duplicate()
        {
            Transaction createdTransaction = new Transaction();
            createdTransaction.HourlyRate = this.duplicateTransaction.HourlyRate;
            createdTransaction.TimeStarted = this.duplicateTransaction.TimeStarted;
            createdTransaction.TimeEnded = this.duplicateTransaction.TimeEnded;
            createdTransaction.RackRate = this.duplicateTransaction.RackRate;
            createdTransaction.TotalRacks = this.duplicateTransaction.  TotalRacks;
            return createdTransaction;
        }

    }
}
