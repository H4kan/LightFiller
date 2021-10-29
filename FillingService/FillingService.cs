using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LightFiller
{
    public class FillingService
    {
        private List<EdgeHandler> EdgeTable = new List<EdgeHandler>();
        private List<EdgeHandler> ActiveEdgeTable = new List<EdgeHandler>();

        private LineService lineService;

        public FillingService(LineService lineService)
        {
            this.lineService = lineService;
        }

        public void InitTables(Polygon polygon)
        {
            EdgeTable.Clear();
            ActiveEdgeTable.Clear();
            foreach (var line in polygon.Edges)
            {
                EdgeTable.Add(new EdgeHandler(line));
            }
            EdgeTable = EdgeTable.OrderBy(e => e.yMin).ToList();


        }

        public void RunFilling(Color color)
        {
            int eInd = 0;
            int y = EdgeTable[eInd].yMin;
            while(eInd < EdgeTable.Count)
            {
                if (y == EdgeTable[eInd].yMin)
                {
                    while (eInd < EdgeTable.Count && y == EdgeTable[eInd].yMin)
                    {
                        ActiveEdgeTable.Add(EdgeTable[eInd]);
                        eInd++;
                    }
                    ActiveEdgeTable = ActiveEdgeTable.OrderBy(e => e.x).ThenBy(e => e.dX).ToList();
                }

                ActiveEdgeTable = ActiveEdgeTable.FindAll(e => e.yMax > y);

                for (int i = 0; i < ActiveEdgeTable.Count - 1; i += 2)
                {
                    this.lineService.FastHorizontalLine(
                        ActiveEdgeTable[i].x,
                        ActiveEdgeTable[i + 1].x, y,
                        color);
                }

                

                y++;
                ActiveEdgeTable.ForEach(e => { e.x = e.basicX + (y - e.yMin) * e.dX / e.dY; });
            
            }
            while (ActiveEdgeTable.Count > 0)
            {
                for (int i = 0; i < ActiveEdgeTable.Count - 1; i += 2)
                {
                    this.lineService.FastHorizontalLine(
                        ActiveEdgeTable[i].x,
                        ActiveEdgeTable[i + 1].x, y,
                        color);
                }

                ActiveEdgeTable = ActiveEdgeTable.FindAll(e => e.yMax > y);

                y++;
                ActiveEdgeTable.ForEach(e => { e.x = e.basicX + (y - e.yMin) * e.dX / e.dY; });

            }

        }
    }
}
