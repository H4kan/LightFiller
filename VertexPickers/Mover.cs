using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LightFiller.VertexPickers
{
    public class Mover : VertexPicker
    {

        bool isColorful = false;
        bool isSingleColor = true;
        private MemoryService memoryService;
        private FillingService fillingService;
        private bool hasImage;
        private bool isHeightedImage;

        public Mover(Point Origin, MemoryService memoryService, FillingService fillingService, int index) : base(Origin, index)
        {
            this.MouseDown += BeginTracking;
            this.memoryService = memoryService;
            this.fillingService = fillingService;
        }

        private void BeginTracking(object sender, MouseEventArgs e)
        {
            this.MouseDown -= BeginTracking;
            this.MouseUp += StopTracking;
            this.MouseMove += Tracking;

            this.memoryService.BeginDoubleTracking(this);

            isColorful = this.memoryService.SelectedPolygon.Colors.Count > 0;
            isSingleColor = !this.memoryService.SelectedPolygon.Colors.Any(c => c.Item2 != this.memoryService.SelectedPolygon.Colors[0].Item2);
            hasImage = this.memoryService.SelectedPolygon.IsBitmapSet() ;
            isHeightedImage = this.memoryService.SelectedPolygon.IsBitmapHeighted;
        }

        private void Tracking(object sender, MouseEventArgs e)
        {
            var globalEventLocation = this.PointToScreen(e.Location);
            var globalPictureBoxLocation = this.memoryService.LineService.PictureBox.PointToScreen(new Point(0, 0));


            this.Location = new Point(
                Math.Min(Math.Max(globalEventLocation.X - globalPictureBoxLocation.X - PickerSize.Width / 2, 0), this.memoryService.LineService.Bmp.Width - PickerSize.Width  - 1), 
                Math.Min(Math.Max(globalEventLocation.Y - globalPictureBoxLocation.Y - PickerSize.Height / 2, 0), this.memoryService.LineService.Bmp.Height - PickerSize.Height - 1));


            if (isColorful || hasImage)
            {
                var lines = new Line[] { this.memoryService.LineService.LineTracker.LastLine,
                    this.memoryService.LineService.DoubleTracker.LastLine };

                var edgeTable = this.fillingService.InitTables(this.memoryService.SelectedPolygon,
                        lines);
                
                this.fillingService.RunFilling(edgeTable, Color.White, true, true);
            }

            this.memoryService.LineService.LineTracker.Update(this, new MouseEventArgs(MouseButtons.Left, 1,
                this.Location.X + PickerSize.Width / 2,
                this.Location.Y + PickerSize.Height / 2, 0));
            this.memoryService.LineService.DoubleTracker.Update(this, new MouseEventArgs(MouseButtons.Left, 1,
                this.Location.X + PickerSize.Width / 2,
                this.Location.Y + PickerSize.Height / 2, 0));

            if (isColorful || hasImage)
            {
                var linesAfter = new Line[] { this.memoryService.LineService.LineTracker.LastLine,
                    this.memoryService.LineService.DoubleTracker.LastLine };
               
                var edgeTable = this.fillingService.InitTables(this.memoryService.SelectedPolygon, linesAfter);

                if (hasImage)
                {
                    if (isHeightedImage)
                    {
                        this.fillingService.RunHeightImageFilling(edgeTable, this.memoryService.SelectedPolygon, true);
                    }
                    else
                    {
                        this.fillingService.RunImageFilling(edgeTable, this.memoryService.SelectedPolygon, true);
                    }
                }
                else if (isSingleColor)
                {
                    this.fillingService.RunFilling(edgeTable, this.memoryService.SelectedPolygon.Colors[0].Item2, true);
                }
                else
                {
                    this.fillingService.RunGradientFilling(edgeTable, this.memoryService.SelectedPolygon, true);
                }
                
            }
        }

        private void StopTracking(object sender, MouseEventArgs e)
        {
            this.MouseUp -= StopTracking;
            this.MouseMove -= Tracking;
            this.MouseDown += BeginTracking;

            // we need to ensure that there is at least one update on lines in case no mouse moving happen
            this.memoryService.LineService.LineTracker.Update(this, new MouseEventArgs(MouseButtons.Left, 1, 
                this.Location.X + PickerSize.Width / 2, 
                this.Location.Y + PickerSize.Height / 2, 0));
            this.memoryService.LineService.DoubleTracker.Update(this, new MouseEventArgs(MouseButtons.Left, 1, 
                this.Location.X + PickerSize.Width / 2, 
                this.Location.Y + PickerSize.Height / 2, 0));



            var lines = this.memoryService.LineService.StopDoubleTracking();

            var line = lines.Item1;
            var dblLine = lines.Item2;

            int firstRemovedIdx, secondRemovedIdx;

            if (this.Index == 0)
            {
                firstRemovedIdx = this.memoryService.SelectedPolygon.Edges.FindIndex(p => p == null);

                this.memoryService.SelectedPolygon.Edges[firstRemovedIdx] = dblLine;

                secondRemovedIdx = this.memoryService.SelectedPolygon.Edges.FindIndex(p => p == null);

                this.memoryService.SelectedPolygon.Edges[secondRemovedIdx] = line;

            }
            else
            {
                firstRemovedIdx = this.memoryService.SelectedPolygon.Edges.FindIndex(p => p == null);

                this.memoryService.SelectedPolygon.Edges[firstRemovedIdx] = line;

                secondRemovedIdx = this.memoryService.SelectedPolygon.Edges.FindIndex(p => p == null);

                this.memoryService.SelectedPolygon.Edges[secondRemovedIdx] = dblLine;
            }

            this.memoryService.SelectedPolygon.FixLineDirection(firstRemovedIdx);
            this.memoryService.SelectedPolygon.FixLineDirection(secondRemovedIdx);
          

            this.memoryService.SelectedPolygon.Vertices[this.Index] = new Point(this.Location.X + PickerSize.Width / 2, this.Location.Y + PickerSize.Height / 2);

            if (isColorful || hasImage)
            {
                var edgeTable = this.fillingService.InitTables(this.memoryService.SelectedPolygon);
                if (hasImage)
                {
                    if (isHeightedImage)
                    {
                        this.fillingService.RunHeightImageFilling(edgeTable, this.memoryService.SelectedPolygon, false);
                    }
                    else
                    {
                        this.fillingService.RunImageFilling(edgeTable, this.memoryService.SelectedPolygon, false);
                    }
                }
                else if (isSingleColor)
                {
                    this.fillingService.RunFilling(edgeTable, this.memoryService.SelectedPolygon.Colors[0].Item2, false);
                }
                else
                {
                    this.fillingService.RunGradientFilling(edgeTable, this.memoryService.SelectedPolygon, false);
                }
                
                foreach (var polygon in this.memoryService.Polygons)
                {
                    foreach (var edge in polygon.Edges)
                    {
                        this.memoryService.LineService.CreateLine(edge);
                    }
                }
            }

            this.memoryService.CauseRedrawPolygons();
            
        }
    }
}
