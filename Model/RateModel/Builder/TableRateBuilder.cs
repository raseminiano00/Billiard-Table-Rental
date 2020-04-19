using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableMonitoring
{
    public class TableRateBuilder
    {
        private double hourlyRate;

        private double gameRate;

        public TableRateBuilder SetHourlyRate(double rate)
        {
            this.hourlyRate = rate;
            return this;
        }
        public TableRateBuilder SetGameRate(double rate)
        {
            this.gameRate = rate;
            return this;
        }
        public Rate Construct()
        {
            Rate createdRate = new Rate();
            createdRate.hourlyRate = hourlyRate;
            createdRate.gameRate = gameRate;
            return createdRate;
        }
    }
}
