using System;
using System.Collections.Generic;
using System.Text;

namespace LightFiller
{
    public class EdgeHandler
    {
        public int yMax { get; set; }
        public int yMin { get; set; }
        public int x { get; set; }
        
        public int dX { get; set; }
        public int dY { get; set; }

        public int basicX { get; set; }
        

        public EdgeHandler(Line line)
        {
            var smallerY = line.Points[0].Y > line.Points[1].Y ? line.Points[1] : line.Points[0];
            var greaterY = line.Points[0].Y > line.Points[1].Y ? line.Points[0] : line.Points[1];
            yMin = smallerY.Y;
            x = smallerY.X;
            basicX = x;
            yMax = greaterY.Y;
            
            dX = (greaterY.X - smallerY.X);
            dY = (greaterY.Y - smallerY.Y);
            
        }
    }
}
