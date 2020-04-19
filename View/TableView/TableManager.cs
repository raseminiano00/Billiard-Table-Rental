using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableMonitoring
{
    public class TableManager : Panel, IDragable
    {
        public TableManager(Color specifiedColor)
        {
            this.Location = new Point(30, 50);
            this.Size = new Size(100, 100);
            this.BackColor = specifiedColor;
            this.AutoScroll = false;
            this.HorizontalScroll.Enabled = false;
            this.HorizontalScroll.Visible = false;
            this.HorizontalScroll.Maximum = 0;
            this.AutoScroll = true;
        }
        private Control activeControl;
        private Point prevPos;
        private TableView interactedTable;
        private ContextMenuStrip tableMenu;
        private void time_OnTick(object sender, EventArgs e)
        {
            activeControl = null;
        }
        public void AddControl(TableView newPanel)
        {
            newPanel.MouseDown += new MouseEventHandler(MouseDownEvent);
            newPanel.MouseMove += new MouseEventHandler(MouseMoveEvent);
            newPanel.MouseUp += new MouseEventHandler(MouseUpEvent);
            this.Controls.Add(newPanel);
            newPanel.Show();
        }
        private bool OutsideHeight(Point loc)
        {
            var newY = (loc.Y + this.Height);
            if ( newY== this.Parent.Height)
            {
                return true;
            }
            return false;
        }
        private bool OutsideWidth(Point loc)
        {
            var newX = (loc.X + this.Width);
            if (newX == this.Parent.Width)
            {
                return true;
            }
            return false;
        }
        public void MouseDownEvent(object sender, MouseEventArgs e)
        {

            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                interactedTable = sender as TableView;
                interactedTable.Rotate(90);
            }
            if (me.Button == System.Windows.Forms.MouseButtons.Left)
            {
                activeControl = sender as Control;
                prevPos = e.Location;
                Cursor = Cursors.Hand;
            }
        }

        public void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            if (activeControl == null || activeControl != sender)
            {
                return;
            }
            var location = activeControl.Location;
            if (OutsideWidth(e.Location))
            {
                location.Offset((e.Location.X - prevPos.X) - 1, e.Location.Y - prevPos.Y);
                activeControl.Location = location;
                return;
            }
            else if (OutsideHeight(e.Location))
            {
                location.Offset(e.Location.X - prevPos.X,( e.Location.Y - prevPos.Y) - 1);
                activeControl.Location = location;
                return;
            }
            else
            {
                location.Offset(e.Location.X - prevPos.X, e.Location.Y - prevPos.Y);
                activeControl.Location = location;
            }
            activeControl.Location = location;
        }

        public void MouseUpEvent(object send, MouseEventArgs e)
        {
            activeControl = null;
            Cursor = Cursors.Default;
        }
        private void adjustToLimitedSpace()
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
        
    }
}
