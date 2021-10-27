using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LightFiller
{
    public class Polygon
    {
        public List<Line> Edges { get; set; }

        public List<Point> Vertices { get; set; }
        
        public Polygon(int x, int y)
        {
            Vertices = new List<Point>();
            Vertices.Add(new Point(x, y));
            Edges = new List<Line>();
        }
         
        public void AppendLine(Line line)
        {
            if (Edges.Count > 1)
            {
                var lastPoint = Edges[Edges.Count - 1].Points[Edges[Edges.Count - 1].Points.Count - 1];
                var lastNewPoint = line.Points[line.Points.Count - 1];
                if (lastPoint.X == lastNewPoint.X && lastPoint.Y == lastNewPoint.Y)
                {
                    line.Points.Reverse();
                }
            }
            this.Vertices.Add(line.Points[line.Points.Count - 1]);
            this.Edges.Add(line);
        }

        public void CompletePolygon(Line line)
        {
            this.Edges.Add(line);
            this.FixLineDirection(this.Edges.Count - 1);
        }

        public void FixLineDirection(int index)
        {
            if (this.Vertices[index] != this.Edges[index].Points[0])
            {
                this.Edges[index].Points.Reverse();

            }
        }
    }
}
