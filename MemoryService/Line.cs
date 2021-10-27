using LightFiller.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LightFiller
{
    public class Line
    {
        public List<Point> Points = new List<Point>();

        public bool HasNeighbouringRelation { get; set; }

        public void AppendPoint(Point point)
        {
            Points.Add(point);
        }

        public Point EvaluateMidPoint()
        {
            return new Point((Points[0].X + Points[Points.Count - 1].X) / 2,
                (Points[0].Y + Points[Points.Count - 1].Y) / 2);
        }
    }
}
