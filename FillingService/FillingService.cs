using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LightFiller
{
    public class FillingService
    {
        private LineService lineService;

        public FillingService(LineService lineService)
        {
            this.lineService = lineService;
        }

        public List<EdgeHandler> InitTables(Polygon polygon, Line[] extraEdges = null)
        {
            var edgeTable = new List<EdgeHandler>();
            edgeTable.Clear();
            
            foreach (var line in polygon.Edges.Where(e => e != null))
            {
                edgeTable.Add(new EdgeHandler(line));
            }
            if (extraEdges != null)
                foreach (var line in extraEdges)
                {
                    edgeTable.Add(new EdgeHandler(line));
                }
            edgeTable = edgeTable.OrderBy(e => e.yMin).ToList();

            return edgeTable;
        }

        public void RunFilling(List<EdgeHandler> edgeTable, Color color, bool isTracking)
        {
            var activeEdgeTable = new List<EdgeHandler>();
            int eInd = 0;
            int y = edgeTable[eInd].yMin;
            while(eInd < edgeTable.Count)
            {
                if (y == edgeTable[eInd].yMin)
                {
                    while (eInd < edgeTable.Count && y == edgeTable[eInd].yMin)
                    {
                        activeEdgeTable.Add(edgeTable[eInd]);
                        eInd++;
                    }
                    
                }
                
                activeEdgeTable = activeEdgeTable.FindAll(e => e.yMax > y);
                activeEdgeTable = activeEdgeTable.OrderBy(e => e.x).ThenBy(e => e.dX).ToList();

                for (int i = 0; i < activeEdgeTable.Count - 1; i += 2)
                {
                    if (isTracking)
                        this.lineService.FastHorizontalTrackingLine(
                        activeEdgeTable[i].x,
                        activeEdgeTable[i + 1].x, y,
                        color);
                    else
                        this.lineService.FastHorizontalLine(
                        activeEdgeTable[i].x,
                        activeEdgeTable[i + 1].x, y,
                        color);
                }

                y++;
                activeEdgeTable.ForEach(e => { e.x = e.basicX + (y - e.yMin) * e.dX / e.dY; });
            
            }
            while (activeEdgeTable.Count > 0)
            {
                for (int i = 0; i < activeEdgeTable.Count - 1; i += 2)
                {
                    if (isTracking)
                        this.lineService.FastHorizontalTrackingLine(
                        activeEdgeTable[i].x,
                        activeEdgeTable[i + 1].x, y,
                        color);
                    else
                        this.lineService.FastHorizontalLine(
                        activeEdgeTable[i].x,
                        activeEdgeTable[i + 1].x, y,
                        color);
                }

                activeEdgeTable = activeEdgeTable.FindAll(e => e.yMax > y);
                activeEdgeTable = activeEdgeTable.OrderBy(e => e.x).ThenBy(e => e.dX).ToList();

                y++;
                activeEdgeTable.ForEach(e => { e.x = e.basicX + (y - e.yMin) * e.dX / e.dY; });

            }

        }

        public void RunGradientFilling(List<EdgeHandler> edgeTable, Polygon polygon, bool isTracking)
        {
            int eInd = 0;
            var activeEdgeTable = new List<EdgeHandler>();
            int y = edgeTable[eInd].yMin;
            while (eInd < edgeTable.Count)
            {
                if (y == edgeTable[eInd].yMin)
                {
                    while (eInd < edgeTable.Count && y == edgeTable[eInd].yMin)
                    {
                        activeEdgeTable.Add(edgeTable[eInd]);
                        eInd++;
                    }

                }

                activeEdgeTable = activeEdgeTable.FindAll(e => e.yMax > y);
                activeEdgeTable = activeEdgeTable.OrderBy(e => e.x).ThenBy(e => e.dX).ToList();

                for (int i = 0; i < activeEdgeTable.Count - 1; i += 2)
                {
                    if (isTracking)
                        this.lineService.GradientHorizontalTrackingLine(
                        activeEdgeTable[i].x,
                        activeEdgeTable[i + 1].x, y,
                        polygon);
                    else
                        this.lineService.GradientHorizontalLine(
                        activeEdgeTable[i].x,
                        activeEdgeTable[i + 1].x, y,
                        polygon);
                }

                y++;
                activeEdgeTable.ForEach(e => { e.x = e.basicX + (y - e.yMin) * e.dX / e.dY; });

            }
            while (activeEdgeTable.Count > 0)
            {
                for (int i = 0; i < activeEdgeTable.Count - 1; i += 2)
                {
                    if (isTracking)
                        this.lineService.GradientHorizontalTrackingLine(
                        activeEdgeTable[i].x,
                        activeEdgeTable[i + 1].x, y,
                        polygon);
                    else
                        this.lineService.GradientHorizontalLine(
                        activeEdgeTable[i].x,
                        activeEdgeTable[i + 1].x, y,
                        polygon);
                }

                activeEdgeTable = activeEdgeTable.FindAll(e => e.yMax > y);
                activeEdgeTable = activeEdgeTable.OrderBy(e => e.x).ThenBy(e => e.dX).ToList();

                y++;
                activeEdgeTable.ForEach(e => { e.x = e.basicX + (y - e.yMin) * e.dX / e.dY; });

            }

        }

        //public void RunCopyGradientalFilling(List<EdgeHandler> edgeTable, Polygon polygon, (int, int) offsetLocation, bool isTracking)
        //{
        //    int eInd = 0;
        //    var activeEdgeTable = new List<EdgeHandler>();
        //    int y = edgeTable[eInd].yMin;
        //    while (eInd < edgeTable.Count)
        //    {
        //        if (y == edgeTable[eInd].yMin)
        //        {
        //            while (eInd < edgeTable.Count && y == edgeTable[eInd].yMin)
        //            {
        //                activeEdgeTable.Add(edgeTable[eInd]);
        //                eInd++;
        //            }

        //        }

        //        activeEdgeTable = activeEdgeTable.FindAll(e => e.yMax > y);
        //        activeEdgeTable = activeEdgeTable.OrderBy(e => e.x).ThenBy(e => e.dX).ToList();

        //        for (int i = 0; i < activeEdgeTable.Count - 1; i += 2)
        //        {
        //            if (isTracking)
        //                this.lineService.CopyTrackingLine(
        //                activeEdgeTable[i].x,
        //                activeEdgeTable[i + 1].x, y,
        //                offsetLocation);
        //            else
        //                this.lineService.CopyLine(
        //                activeEdgeTable[i].x,
        //                activeEdgeTable[i + 1].x, y,
        //                offsetLocation);
        //        }

        //        y++;
        //        activeEdgeTable.ForEach(e => { e.x = e.basicX + (y - e.yMin) * e.dX / e.dY; });

        //    }
        //    while (activeEdgeTable.Count > 0)
        //    {
        //        for (int i = 0; i < activeEdgeTable.Count - 1; i += 2)
        //        {
        //            if (isTracking)
        //                this.lineService.GradientHorizontalTrackingLine(
        //                activeEdgeTable[i].x,
        //                activeEdgeTable[i + 1].x, y,
        //                polygon);
        //            else
        //                this.lineService.GradientHorizontalLine(
        //                activeEdgeTable[i].x,
        //                activeEdgeTable[i + 1].x, y,
        //                polygon);
        //        }

        //        activeEdgeTable = activeEdgeTable.FindAll(e => e.yMax > y);
        //        activeEdgeTable = activeEdgeTable.OrderBy(e => e.x).ThenBy(e => e.dX).ToList();

        //        y++;
        //        activeEdgeTable.ForEach(e => { e.x = e.basicX + (y - e.yMin) * e.dX / e.dY; });

        //    }


        //}
    }

}
