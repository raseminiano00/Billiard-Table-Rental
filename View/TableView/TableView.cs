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
        public TableView(Color BackColor)
        {
            //InitializeComponent();
            this.BackColor = BackColor;
            this.Location = new Point(30, 50);
            this.Size = new Size(300, 200);
            this.BackgroundImage = BackGroundImage();
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        string tableBackGround;
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
            if(tableBackGround != Path.GetFileName(Properties.Resources.Table_Vertical))
            {
                tableBackGround = Path.GetFileName(Properties.Resources.Table_Vertical);
                return Image.FromFile(Properties.Resources.Table_Vertical);

            }
            return this.BackGroundImage();
        }
        private Size RotateSize()
        {
            return new Size(this.Size.Height,this.Size.Width);
        }
    }
}
