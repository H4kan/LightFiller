using System;
using System.Collections.Generic;
using System.Text;

namespace LightFiller.FillingService
{
    public class EdgeBucket
    {
        public int yMax { get; set; }
        public int yMin { get; set; }
        public int x { get; set; }
        public bool positiveSign { get; set; }
        public int dX { get; set; }
        public int dY { get; set; }
        public int sum { get; set; }

        public EdgeBucket(Line line)
        {
            var smallerY = line.Points[0].Y > line.Points[1].Y ? line.Points[1] : line.Points[0];
            var greaterY = line.Points[0].Y > line.Points[1].Y ? line.Points[0] : line.Points[1];
            yMin = smallerY.Y;
            x = smallerY.X;
            yMax = greaterY.Y;
            positiveSign = (greaterY.X - smallerY.X) > 0;
            dX = Math.Abs(greaterY.X - smallerY.X);
            dY = greaterY.Y - smallerY.Y;
            sum = 0;
        }
    }
}
