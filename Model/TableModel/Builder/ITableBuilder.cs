using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableMonitoring
{
    public interface ITableBuilder
    {
        ITableBuilder SetTabledId(int id);
        TableModel Construct();
    }
}
