using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LightFiller
{
    public class LineService
    {
        public Bitmap Bmp { get; set; }

        public Bitmap TrackingBmp { get; set; }

        public BresenhamLine BrensehamLine { get; set; }

        public BresenhamLine BrensehamTrackingLine { get; set; }

        public LineTracker LineTracker { get; set; }

        public LineTracker DoubleTracker { get; set; }

        public PictureBox PictureBox { get; set; }

        public bool IsLineTracking { get; set; }

        public LineService(Bitmap bmp, PictureBox pictureBox)
        {
            this.Bmp = bmp;
            this.BrensehamLine = new BresenhamLine(bmp);
            
            this.PictureBox = pictureBox;
        }

        public void BeginTracking(int x, int y)
        {
            this.IsLineTracking = true;
            TrackingBmp = (Bitmap)Bmp.Clone();
            this.BrensehamTrackingLine = new BresenhamLine(TrackingBmp);
            this.PictureBox.Image = TrackingBmp;
            this.PictureBox.Invalidate();
            LineTracker = new LineTracker(this, x, y);
            this.PictureBox.MouseMove += this.LineTracker.Update;
        }

        public void BeginTrackingNoUpdate()
        {
            TrackingBmp = (Bitmap)Bmp.Clone();
            this.BrensehamTrackingLine = new BresenhamLine(TrackingBmp);
            this.PictureBox.Image = TrackingBmp;
            this.PictureBox.Invalidate();
        }

        public void BeginDoubleTracking(int x1, int y1, int x2, int y2)
        {
            TrackingBmp = (Bitmap)Bmp.Clone();
            this.BrensehamTrackingLine = new BresenhamLine(TrackingBmp);
            this.PictureBox.Image = TrackingBmp;
            this.PictureBox.Invalidate();
            LineTracker = new LineTracker(this, x1, y1);
            DoubleTracker = new LineTracker(this, x2, y2);

        }

        public void StopTracking()
        {
            var line = this.LineTracker.LastLine;
            this.CreateLine(line);

            this.PictureBox.Image = Bmp;
            this.TrackingBmp.Dispose();
            LineTracker = null;

            this.PictureBox.Invalidate();
        }

        public void StopTracking(Line line)
        {
            this.CreateLine(line);

            this.PictureBox.Image = Bmp;
            this.TrackingBmp.Dispose();

            this.PictureBox.Invalidate();
        }

        public void StopTrackingNoDrawing()
        {
            this.PictureBox.Image = Bmp;
            this.TrackingBmp.Dispose();

            this.PictureBox.Invalidate();
        }

        public (Line, Line) StopDoubleTracking()
        {
            var line = this.LineTracker.LastLine;
            this.CreateLine(line);

            var dblLine = this.DoubleTracker.LastLine;
            this.CreateLine(dblLine);

            this.PictureBox.Image = Bmp;
            this.TrackingBmp.Dispose();
            LineTracker = null;
            DoubleTracker = null;

            this.PictureBox.Invalidate();

            return (line, dblLine);
        }

        public void AbortTracking()
        {

            this.PictureBox.Image = Bmp;
            this.TrackingBmp.Dispose();
            LineTracker = null;

            this.PictureBox.Invalidate();
            this.IsLineTracking = false;
        }

        public Line CreateLine(int x1, int y1, int x2, int y2)
        {
            return BrensehamLine.CreateLine(x1, y1, x2, y2);
        }

        public Line CreateLine(Line line)
        {
            return this.CreateLine(line.Points[0].X, line.Points[0].Y, line.Points[1].X, line.Points[1].Y);
        }

        public Line CreateTrackingLine(int x1, int y1, int x2, int y2)
        {
            return BrensehamTrackingLine.CreateLine(x1, y1, x2, y2);
        }
        public Line CreateTrackingLine(Line line)
        {
            return this.CreateTrackingLine(line.Points[0].X, line.Points[0].Y, line.Points[1].X, line.Points[1].Y);
        }


        public void EraseLine(Line line)
        {
            BrensehamLine.EraseLine(line);
        }

        public void EraseTrackingLine(Line line)
        {
            BrensehamTrackingLine.EraseLine(line);
        }

        public void FastHorizontalLine(int x1, int x2, int y, Color color)
        {
            int x = x1;
            while (x <= x2)
            {
                Bmp.SetPixel(x, y, color);
                x++;
            }
        }
    }
}
