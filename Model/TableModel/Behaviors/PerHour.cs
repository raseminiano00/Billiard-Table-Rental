using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableMonitoring
{
    public class PerHour : ITableTransaction
    {
        public double checkRunningAmount(Transaction currentTransaction)
        {
            return computeAmount(Convert.ToInt32(currentTransaction.CurrentRentTime.TotalMinutes),currentTransaction.HourlyRate);
        }
        public int TransactionType()
        {
            return 1;
        }
        public static int GetTransactionCode()
        {
            return 1;
        }

        public double GetTotalAmount(Transaction currentTransaction)
        {
            return computeAmount(Convert.ToInt32(currentTransaction.TotalRentTime.TotalMinutes), currentTransaction.HourlyRate);
        }

        private double computeAmount(int timeConsumed,double hourlyRate)
        {
            int hoursConsumed = timeConsumed / 60;
            int leftMinutes = timeConsumed - (hoursConsumed * 60);

            double totalAmount = (hoursConsumed * hourlyRate);
            return totalAmount + getMinuteRate(leftMinutes, getMinimumAmount(hourlyRate));

        }
        private double getMinimumAmount(double hourlyRate)
        {
            return hourlyRate / 4;
        }
        private double getMinuteRate(int minutes,double minimumRate)
        {
            Console.WriteLine("Eto "+minimumRate);
            if (minutes >= 45)
            {
                return minimumRate * 4;
            }
            else if (minutes >= 40)
            {
                return minimumRate * 3;
            }
            else if(minutes >= 20)
            {
                return minimumRate * 2;
            }
            else if(minutes < 5)
            {
                return 0;
            }
            return minimumRate;
        }

        public double GetRate(Transaction currentTransaction)
        {
            return currentTransaction.HourlyRate;
        }

        public string Transaction()
        {
            return "PER HOUR";
        }
    }
}
