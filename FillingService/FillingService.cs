using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LightFiller.FillingService
{
    public class FillingService
    {
        private List<EdgeBucket> EdgeTable = new List<EdgeBucket>();
        private List<EdgeBucket> ActiveEdgeTable = new List<EdgeBucket>();

        public FillingService()
        {

        }

        public void InitTables(Polygon polygon)
        {
            EdgeTable.Clear();
            ActiveEdgeTable.Clear();
            foreach (var line in polygon.Edges)
            {
                EdgeTable.Add(new EdgeBucket(line));
            }
            EdgeTable.OrderBy(e => e.yMin);
        }
    }
}
