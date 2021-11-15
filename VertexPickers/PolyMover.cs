using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LightFiller.VertexPickers
{
    public class PolyMover : VertexPicker
    {
        private MemoryService memoryService;
        
        private Point lastLocation;
        private bool isColorful;
        private bool isSingleColor;
        private bool hasImage;
        private bool isHeightedImage;

        public PolyMover(Point Origin, MemoryService memoryService, int index) : base(Origin, index)
        {
            this.MouseDown += BeginTracking;
            this.memoryService = memoryService;
        }

        private void BeginTracking(object sender, MouseEventArgs e)
        {
            this.MouseDown -= BeginTracking;
            this.MouseUp += StopTracking;
            this.MouseMove += Tracking;
            lastLocation = this.Location;

            this.memoryService.LineService.BeginTrackingNoUpdate();
            foreach (var line in this.memoryService.SelectedPolygon.Edges)
            {
                this.memoryService.LineService.EraseLine(line);
            }

            isColorful = this.memoryService.SelectedPolygon.Colors.Count > 0;
            isSingleColor = !this.memoryService.SelectedPolygon.Colors.Any(c => c.Item2 != this.memoryService.SelectedPolygon.Colors[0].Item2);
            hasImage = this.memoryService.SelectedPolygon.IsBitmapSet();
            isHeightedImage = this.memoryService.SelectedPolygon.IsBitmapHeighted;

            if (isColorful || hasImage)
            {
                var edgeTable = this.memoryService.FillingService.InitTables(this.memoryService.SelectedPolygon);
                this.memoryService.FillingService.RunFilling(edgeTable, Color.White, false, true);
            } 
        }

        private void Tracking(object sender, MouseEventArgs e)
        {
            var globalEventLocation = this.PointToScreen(e.Location);
            var globalPictureBoxLocation = this.memoryService.LineService.PictureBox.PointToScreen(new Point(0, 0));


            var newLocation = this.Location = new Point(
                Math.Min(Math.Max(globalEventLocation.X - globalPictureBoxLocation.X - PickerSize.Width / 2, 0), this.memoryService.LineService.Bmp.Width - PickerSize.Width - 1),
                Math.Min(Math.Max(globalEventLocation.Y - globalPictureBoxLocation.Y - PickerSize.Height / 2, 0), this.memoryService.LineService.Bmp.Height - PickerSize.Height - 1)); ;


            var offsetLocation = (newLocation.X - lastLocation.X, newLocation.Y - lastLocation.Y);
            if (hasImage || isColorful)
            {
                var edgeTable = this.memoryService.FillingService.InitTables(this.memoryService.SelectedPolygon);
                this.memoryService.FillingService.RunFilling(edgeTable, Color.White, true, true);
            }

            for (int i = 0; i < this.memoryService.SelectedPolygon.Vertices.Count; i++)
            {
                var oldPoint = this.memoryService.SelectedPolygon.Vertices[i];

                this.memoryService.SelectedPolygon.Vertices[i] = new Point(
                    oldPoint.X + offsetLocation.Item1,
                    oldPoint.Y + offsetLocation.Item2);
          
                var currLine = this.memoryService.SelectedPolygon.Edges[i];
                this.memoryService.LineService.EraseTrackingLine(currLine);

                currLine.Points[0] = new Point(currLine.Points[0].X + offsetLocation.Item1,
                    currLine.Points[0].Y + offsetLocation.Item2);
                currLine.Points[1] = new Point(currLine.Points[1].X + offsetLocation.Item1,
                    currLine.Points[1].Y + offsetLocation.Item2);

                this.memoryService.LineService.CreateTrackingLine(currLine);

            
            }
            for (int i = 0; i < this.memoryService.VertexPickers.Count; i++)
            {
                var oldPickerPoint = this.memoryService.VertexPickers[i].Location;
                this.memoryService.VertexPickers[i].Location = new Point(oldPickerPoint.X + offsetLocation.Item1,
                    oldPickerPoint.Y + offsetLocation.Item2);
            }
            if (hasImage || isColorful)
            {
                var edgeTable = this.memoryService.FillingService.InitTables(this.memoryService.SelectedPolygon);
                if (hasImage)
                {
                    if (isHeightedImage)
                    {
                        this.memoryService.FillingService.RunHeightImageFilling(edgeTable, this.memoryService.SelectedPolygon, true);
                    }
                    else
                    {
                        this.memoryService.FillingService.RunImageFilling(edgeTable, this.memoryService.SelectedPolygon, true);
                    }
                }
                else
                {
                    if (isSingleColor)
                    {
                        this.memoryService.FillingService.RunFilling(edgeTable, this.memoryService.SelectedPolygon.Colors[0].Item2, true);
                    }
                    else
                    {
                        this.memoryService.FillingService.RunGradientFilling(edgeTable, this.memoryService.SelectedPolygon, true);
                    }
                }
            }

            this.memoryService.LineService.PictureBox.Invalidate();

            lastLocation = newLocation;
        }

        private void StopTracking(object sender, MouseEventArgs e)
        {
            this.MouseUp -= StopTracking;
            this.MouseMove -= Tracking;
            this.MouseDown += BeginTracking;

            if (isColorful || hasImage)
            {
                var edgeTable = this.memoryService.FillingService.InitTables(this.memoryService.SelectedPolygon);
                if (hasImage)
                {
                    if (isHeightedImage)
                    {
                        this.memoryService.FillingService.RunHeightImageFilling(edgeTable, this.memoryService.SelectedPolygon, false);
                    }
                    else
                    {
                        this.memoryService.FillingService.RunImageFilling(edgeTable, this.memoryService.SelectedPolygon, false);
                    }
                }
                else
                {
                    if (isSingleColor)
                    {
                        this.memoryService.FillingService.RunFilling(edgeTable, this.memoryService.SelectedPolygon.Colors[0].Item2, false);
                    }
                    else
                    {
                        this.memoryService.FillingService.RunGradientFilling(edgeTable, this.memoryService.SelectedPolygon, false);
                    }
                }
               
            }

            foreach (var line in this.memoryService.SelectedPolygon.Edges)
            {
                this.memoryService.LineService.CreateLine(line);
            }

            this.memoryService.LineService.StopTrackingNoDrawing();

            this.memoryService.CauseRedrawPolygons();
        }
    }
}
