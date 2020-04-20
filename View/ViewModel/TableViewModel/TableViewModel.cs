using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableMonitoring
{
    public class TableViewModel
    {
        public TableViewModel(TableModel model)
        {
            this.model = model;
        }

        TableModel model;
        public int Table { get { return model.TableId; } }
        public DateTime TimeStarted { get { return model.TimeStarted; } }
        public double TableRate{ get { return model.TableRate; } }
        public string RentTime{ get { return model.RentTime.ToString(@"d\.hh\:mm\:ss"); } }
        public string Transaction { get { return model.TransactionType; } }
        public string TableState{ get { return model.State; } }
        public double RentAmount { get { return model.TransactionAmount; } }

        public Point GetLocation()
        {
            return new Point(model.X,model.Y);
        }
        public Size GetSize()
        {
            return new Size(model.width, model.height);
        }
    }
}
