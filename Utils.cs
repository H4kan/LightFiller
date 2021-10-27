using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LightFiller
{
    public static class Utils
    {

        public static int CalculateDistance(Point p1, Point p2)
        {
            var p = Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
            return Convert.ToInt32(Math.Round(p));
        }
    }
}
