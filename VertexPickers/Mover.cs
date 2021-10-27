using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LightFiller.VertexPickers
{
    public class Mover : VertexPicker
    {
        private MemoryService memoryService;

        public Mover(Point Origin, MemoryService memoryService, int index) : base(Origin, index)
        {
            this.MouseDown += BeginTracking;
            this.memoryService = memoryService;
        }

        private void BeginTracking(object sender, MouseEventArgs e)
        {
            this.MouseDown -= BeginTracking;
            this.MouseUp += StopTracking;
            this.MouseMove += Tracking;

            this.memoryService.BeginDoubleTracking(this);
        }

        private void Tracking(object sender, MouseEventArgs e)
        {
            var globalEventLocation = this.PointToScreen(e.Location);
            var globalPictureBoxLocation = this.memoryService.LineService.PictureBox.PointToScreen(new Point(0, 0));


            this.Location = new Point(globalEventLocation.X - globalPictureBoxLocation.X - PickerSize.Width / 2, 
                globalEventLocation.Y - globalPictureBoxLocation.Y - PickerSize.Height / 2);



            this.memoryService.LineService.LineTracker.Update(this, new MouseEventArgs(MouseButtons.Left, 1,
                this.Location.X + PickerSize.Width / 2,
                this.Location.Y + PickerSize.Height / 2, 0));
            this.memoryService.LineService.DoubleTracker.Update(this, new MouseEventArgs(MouseButtons.Left, 1,
                this.Location.X + PickerSize.Width / 2,
                this.Location.Y + PickerSize.Height / 2, 0));
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
        }
    }
}
