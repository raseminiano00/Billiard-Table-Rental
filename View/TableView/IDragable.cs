using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableMonitoring
{
    public interface IDragable 
    {
        void MouseUpEvent(object send, MouseEventArgs e);
        void MouseDownEvent(object sender, MouseEventArgs e);
        void MouseMoveEvent(object sender, MouseEventArgs e);
    }
}
