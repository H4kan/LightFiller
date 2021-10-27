using LightFiller.VertexPickers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using LightFiller.Enums;

namespace LightFiller
{
    public class MemoryService
    {
        public List<Polygon> Polygons;

        public Polygon SelectedPolygon { get; set; }

        public List<VertexPicker> VertexPickers = new List<VertexPicker>();

        GroupBox polygonActionsBox;
        ListView polygonListBox;

        PictureBox pictureBox;
        public Form1 form;
        public LineService LineService { get; set; }

        public MemoryService(
            GroupBox polygonActionsBox,
            ListView polygonListBox,
            PictureBox pictureBox,
            LineService lineService, 
            Form1 form)
        {
            Polygons = new List<Polygon>();

            this.polygonListBox = polygonListBox;
            this.polygonActionsBox = polygonActionsBox;

            this.pictureBox = pictureBox;
            this.LineService = lineService;
            this.form = form;
        }

        public void ShowPolygonOptions()
        {
            polygonActionsBox.Visible = true;
        }

        public void ExitPolygonOptions()
        {
            polygonActionsBox.Visible = false;
        
            this.SelectedPolygon = null;
            this.polygonListBox.SelectedIndices.Clear();
            this.polygonListBox.Items.Clear();
            int idx = 1;
            foreach (var polygon in this.Polygons)
            {
                this.polygonListBox.Items.Add(new ListViewItem() { Text = $"p_{idx}", Name = $"p_{idx}" });
                idx++;
            }

        }



        public void EnterMoveVerticeMode()
        {        
            int idx = 0;
            foreach (var vertice in SelectedPolygon.Vertices)
            {
                var mover = new Mover(vertice, this, idx++);
                VertexPickers.Add(mover);
                this.pictureBox.Controls.Add(mover);

            }
        }

        public void EnterDeleteVerticeMode()
        {
            int idx = 0;
            foreach (var vertice in SelectedPolygon.Vertices)
            {
                var deleter = new Deleter(vertice, idx++, this);
                VertexPickers.Add(deleter);
                this.pictureBox.Controls.Add(deleter);
            }
        }

        public void DeleteVertice(int index)
        {


            this.pictureBox.Controls.Remove(this.VertexPickers[index]);
            this.VertexPickers.RemoveAt(index);
            if (this.VertexPickers.Count == 0)
            {
                this.Polygons.Remove(this.SelectedPolygon);
                this.ExitPolygonOptions();
                return;
            }
            int idx = 0;
            foreach (var vertexPicker in this.VertexPickers)
            {
                vertexPicker.Index = idx++;
            }

            this.SelectedPolygon.Vertices.RemoveAt(index);

            var prevEdgeIdx = index == 0 ? this.SelectedPolygon.Edges.Count - 1 : index - 1;

            this.LineService.EraseLine(this.SelectedPolygon.Edges[prevEdgeIdx]);
            this.LineService.EraseLine(this.SelectedPolygon.Edges[index]);

            var firstPoint = this.SelectedPolygon.Edges[prevEdgeIdx].Points[0];
            var secPoint = this.SelectedPolygon.Edges[index].Points[1];

            var newLine = this.LineService.CreateLine(firstPoint.X, firstPoint.Y, secPoint.X, secPoint.Y);

            this.SelectedPolygon.Edges[prevEdgeIdx] = newLine;
            this.SelectedPolygon.Edges.RemoveAt(index);

            this.pictureBox.Invalidate();

        }

        public void SavePolygon(Polygon polygon)
        {
            this.Polygons.Add(polygon);
            this.polygonListBox.Items.Add(new ListViewItem() { Text = $"p_{this.Polygons.Count}", Name= $"p_{this.Polygons.Count}" });
        }

        public void BeginDoubleTracking(Mover mover)
        {
            var prevVertice = this.SelectedPolygon.Vertices[mover.Index == 0 ? this.SelectedPolygon.Vertices.Count - 1 : mover.Index - 1];
            var nextVertice = this.SelectedPolygon.Vertices[mover.Index == this.SelectedPolygon.Vertices.Count - 1 ? 0 : mover.Index + 1];
            this.LineService.BeginDoubleTracking(prevVertice.X, prevVertice.Y, nextVertice.X, nextVertice.Y);
            if (mover.Index == 0)
            {
                this.LineService.EraseTrackingLine(this.SelectedPolygon.Edges[0]);
                this.LineService.EraseTrackingLine(this.SelectedPolygon.Edges[this.SelectedPolygon.Edges.Count - 1]);

                this.LineService.EraseLine(this.SelectedPolygon.Edges[0]);
                this.LineService.EraseLine(this.SelectedPolygon.Edges[this.SelectedPolygon.Edges.Count - 1]);

                // gets regenerated after ending of double tracking
                this.SelectedPolygon.Edges[0] = null;
                this.SelectedPolygon.Edges[this.SelectedPolygon.Edges.Count - 1] = null;
            }
            else 
            {
                this.LineService.EraseTrackingLine(this.SelectedPolygon.Edges[mover.Index - 1]);
                this.LineService.EraseTrackingLine(this.SelectedPolygon.Edges[mover.Index]);

                this.LineService.EraseLine(this.SelectedPolygon.Edges[mover.Index - 1]);
                this.LineService.EraseLine(this.SelectedPolygon.Edges[mover.Index]);

                this.SelectedPolygon.Edges[mover.Index] = null;
                this.SelectedPolygon.Edges[mover.Index - 1] = null;
            }
        }

        public void ExitVertexPickersMode()
        {
            foreach (var vertexPicker in this.VertexPickers)
            {
                this.pictureBox.Controls.Remove(vertexPicker);
            }
            VertexPickers.Clear();
        }

        public void EnterAddVerticeMode()
        {
            int idx = 0;
            foreach (var edge in SelectedPolygon.Edges)
            {
                var adder = new Adder(edge.EvaluateMidPoint(), idx++, this);
                VertexPickers.Add(adder);
                this.pictureBox.Controls.Add(adder);
            }
        }

        public void InsertVertice(int index)
        {

            var newPoint = this.SelectedPolygon.Edges[index].EvaluateMidPoint();
            this.SelectedPolygon.Vertices.Insert(index + 1, newPoint);

            var oldEndPoint = this.SelectedPolygon.Edges[index].Points[1];

            this.LineService.EraseLine(this.SelectedPolygon.Edges[index]);
            this.SelectedPolygon.Edges[index].Points[1] = newPoint;

            var newEdge = new Line();
            newEdge.AppendPoint(newPoint);
            newEdge.AppendPoint(oldEndPoint);



            this.SelectedPolygon.Edges.Insert(index + 1, newEdge);

            this.LineService.CreateLine(this.SelectedPolygon.Edges[index]);

            this.LineService.CreateLine(this.SelectedPolygon.Edges[index + 1]);

            this.pictureBox.Invalidate();

            this.form.switchToMoveVerticeMode();
        }

        public void EnterMovePolygonMode()
        {
            var polyMover = new PolyMover(SelectedPolygon.Vertices[0], this, 0);
            VertexPickers.Add(polyMover);
            this.pictureBox.Controls.Add(polyMover);
        }
    }
}
