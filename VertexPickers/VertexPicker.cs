using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LightFiller.VertexPickers
{
    public class VertexPicker : Button
    {
        protected virtual Size PickerSize { get { return new Size(15, 15);  } }

        public int Index { get; set; }

        public VertexPicker(Point Origin, int index)
        {
            this.Size = PickerSize;
            this.Location = new Point(Origin.X - PickerSize.Width / 2, Origin.Y - PickerSize.Height / 2);
            this.Index = index;
        }

        public void SetLocation(Point point)
        {
            this.Location = new Point(point.X - PickerSize.Width / 2, point.Y - PickerSize.Height / 2);
        }
    }
}
