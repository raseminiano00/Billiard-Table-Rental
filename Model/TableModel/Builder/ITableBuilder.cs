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
        ITableBuilder SetY(int val);
        ITableBuilder SetX(int val);
        ITableBuilder SetWidth(int val);
        ITableBuilder SetHeight(int val);

        TableModel Construct();
    }
}
