using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TableMonitoring.Model
{
    public class Table : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _tableId;
        public int tableid {
            get {
                return _tableId;
                }
            set
            {
                _tableId = value;
                onPropertyChanged("tableid");
            } }
        public double ratePerHour { get; set; }
        public double ratePerGame { get; set; }
        public DateTime _timeStarted;
        public DateTime timeStarted
        {
            get
            {
                return _timeStarted;
            }
            set
            {
                _timeStarted = value;
                onPropertyChanged("timeStarted");
            }
        }
        public TimeSpan runningTime { get; set; }
        private Status status { get; set; }

        public enum Status {
            NOT_OCCUPIED,
            HOURLY_RATE,
            GAME_RATE
        }

        public override bool Equals(object obj)
        {
            Table other = obj as Table;
            return base.Equals(obj);
        }

        public bool Equals(Table other)
        {
            if (other == null)
                return false;

            return this.tableid == other.tableid
                && this.ratePerHour == other.ratePerHour
                && this.ratePerGame == other.ratePerGame;
        }
        public void  setStatus(Status stat)
        {
            status = (stat); 
        }

        public Status getStatus()
        {
            return status;
        }
        public void onPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        
        
    }
}
