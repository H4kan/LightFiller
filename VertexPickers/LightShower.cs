using LightFiller.VertexPickers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LightFiller
{
    public class LightShower : VertexPicker
    {
        protected override Size PickerSize { get { return new Size(25, 25); } }

        public LightShower() : base(new Point(100, 100), 0)
        {
            this.Text = "L";
            this.Visible = false;
        }

    }
}
