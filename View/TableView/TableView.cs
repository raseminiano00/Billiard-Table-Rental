using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace TableMonitoring
{
    public partial class TableView : UserControl
    {
        public TableView(TableViewModel viewModel)
        {
            //InitializeComponent();
            this.tableViewModel = viewModel;
            this.Size = viewModel.GetSize();
            this.Location = viewModel.GetLocation();
            this.BackgroundImage = BackGroundImage();
            this.BackgroundImageLayout = ImageLayout.Stretch;
            CalculateFontSize();
            BindModelDetails();
            ShowTransactionDetails();
        }
        string tableBackGround;
        List<string> tableDetails;
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        private float proportionalNewWidth;
        private float proportionalNewHeight;
        private float proportionalSize;

        private void CalculateFontSize()
        {
            initialWidth = Width;
            initialHeight = Height;
            proportionalNewWidth = (float)Width / initialWidth;
            proportionalNewHeight = (float)Height / initialHeight;
        }
        private void BindModelDetails()
        {
            tableDetails = new List<string>();
            tableDetails.Add("Table " + tableViewModel.Table);
            tableDetails.Add(tableViewModel.Transaction);
            tableDetails.Add("Per Hour Rate:"+Convert.ToString(tableViewModel.TableRate));
            tableDetails.Add(Convert.ToString(tableViewModel.RentTime));
            tableDetails.Add("Rent Amount"+Convert.ToString(tableViewModel.RentAmount));
        }
        private void ShowTransactionDetails()
        {
            int i = 0;
            Font labelFont = new Font(this.Font.FontFamily, 15);
            initialFontSize = labelFont.Size;
            labelFont = new Font(labelFont.FontFamily, initialFontSize *
       (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
           labelFont.Style);
            foreach (string values in tableDetails)
            {
                LabelDetail labelDetail = new LabelDetail
                {
                    Text = values,
                    BackColor = System.Drawing.Color.Transparent,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Name = i.ToString(),
                    Font = labelFont,
                    MultiLine = true,
                    AutoSize = true
                };

                labelDetail.Location = new Point(GetHorizontalCenter(labelDetail.Size.Width), GetVerticalCenter(i, labelDetail.Size.Height));
                this.Controls.Add(labelDetail);
                i += 1;
            }
        }
        private void RemoveTransactionDetails()
        {
            Controls.Clear();
        }
        private int GetHorizontalCenter(int width)
        {
            return (this.Size.Width - width) / 2;
        }
        private int GetVerticalCenter(int index, int height)
        {
            int overAllHeight = this.tableDetails.Count * height;
            int heightPerItem = index * height;
            return ((this.Size.Height - overAllHeight) / 2) + heightPerItem;
        }

        public TableViewModel tableViewModel { get; set; }
        private void Table_Load(object sender, EventArgs e)
        {

        }
        private Image BackGroundImage()
        {
            tableBackGround = Path.GetFileName(Properties.Resources.Table1);
            return Image.FromFile(Properties.Resources.Table1);
        }

        public void Rotate(float rotateAngle)
        {
            this.BackgroundImage = RotateBackGround();
            this.Size = RotateSize();
            RemoveTransactionDetails();
            ShowTransactionDetails();
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void RotateBackGround(float rotationAngle)
        {
            Image img = this.BackgroundImage;
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            //return bmp;
        }
        private Image RotateBackGround()
        {
            if (tableBackGround != Path.GetFileName(Properties.Resources.Table_Vertical))
            {
                tableBackGround = Path.GetFileName(Properties.Resources.Table_Vertical);
                return Image.FromFile(Properties.Resources.Table_Vertical);

            }
            return this.BackGroundImage();
        }
        private Size RotateSize()
        {
            return new Size(this.Size.Height, this.Size.Width);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TableView
            // 
            this.Name = "TableView";
            this.Size = new System.Drawing.Size(244, 226);
            this.ResumeLayout(false);

        }
    }
    public class LabelDetail : Label {
        bool mline = false;

        public bool MultiLine
        {
            get { return mline; }
            set { mline = value; }
        }

        protected override void OnResize(EventArgs e)
        {
            int tw = 0;
            int i = 0;
            String s = base.Text;
            String c = String.Empty;
            Font f = base.Font;
            Control p = base.Parent;
            //get the width of label
            int lw = base.Width;
            //get the with of parent control
            int cw = p.Width;
            StringBuilder sb = null;
            if (mline == true)
            {
                if (lw > cw)
                {
                    while (tw < cw)
                    {
                        i += 1;
                        c = s.Substring(0, i);
                        //calculate the length of string
                        Size txtSize = TextRenderer.MeasureText(c, f);
                        //get the width of text 
                        tw = txtSize.Width;
                    }
                    //decrease the length of text 
                    i -= 1;
                    //insert brakes
                    sb = new StringBuilder();
                    int j = 0;
                    while (j < s.Length)
                    {
                        if (j + i > s.Length) i = s.Length - j;
                        c = s.Substring(j, i); //+ "/r/n";
                        sb.AppendLine(c);
                        j += i;
                    }
                    base.Text = sb.ToString();
                }
            }
            base.OnResize(e);
        }

    }

}
