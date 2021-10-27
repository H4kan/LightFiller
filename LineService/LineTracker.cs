using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LightFiller
{
    public class LineTracker
    {
        public LineService LineService { get; set; }

        public Line LastLine { get; set; }

        public Point Origin { get; set; }

        public LineTracker(LineService lineService, int x, int y)
        {
            this.Origin = new Point(x, y);
            this.LineService = lineService;
            this.LastLine = new Line();
            this.LastLine.AppendPoint(Origin);
        }

        public void Update(object sender, MouseEventArgs e)
        {
            this.LineService.EraseTrackingLine(LastLine);

            LastLine = this.LineService.CreateTrackingLine(Origin.X, Origin.Y, e.X, e.Y);

            LineService.PictureBox.Invalidate();
        }
    }
}
