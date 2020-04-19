using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableMonitoring
{
    public class Transaction
    {
        public DateTime TimeStarted { get; set; }
        public DateTime TimeEnded { get; set; }
        public double HourlyRate { get; set; }
        public double RackRate { get; set; }
        public int TotalRacks { get; set; }
        public TimeSpan CurrentRentTime{
            get {
                return (DateTime.Now - TimeStarted);
            }
        }
        public TimeSpan TotalRentTime
        {
            get
            {
                return (TimeEnded - TimeStarted);
            }
        }
        public void toVacant()
        {
            this.TimeStarted = DateTime.Now;
            this.TimeEnded = DateTime.MinValue;
            this.TotalRacks = 0;
        }
    }
}
