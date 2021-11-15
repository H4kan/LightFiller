using LightFiller.VertexPickers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using LightFiller.Enums;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

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

        public FillingService FillingService { get; set; }

        public RandomService RandomService { get; set; }

        private bool shouldThreadGetCancelled { get; set; }

        public List<(int, int)> speedVectors { get; set; }

        public double speedRatio = 0.5;

        public MemoryService(
            GroupBox polygonActionsBox,
            ListView polygonListBox,
            PictureBox pictureBox,
            LineService lineService,
            FillingService fillingService,
            RandomService randomService,
            Form1 form)
        {
            Polygons = new List<Polygon>();

            this.polygonListBox = polygonListBox;
            this.polygonActionsBox = polygonActionsBox;

            this.pictureBox = pictureBox;
            this.LineService = lineService;
            this.form = form;

            this.FillingService = fillingService;
            this.RandomService = randomService;
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
                var mover = new Mover(vertice, this, this.FillingService, idx++);
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

 

            this.SelectedPolygon.Colors = this.SelectedPolygon.Colors.FindAll(c => c.Item1 != index);
            for (int i = 0; i < this.SelectedPolygon.Colors.Count; i++)
            {
                if (this.SelectedPolygon.Colors[i].Item1 > index)
                    this.SelectedPolygon.Colors[i] = (this.SelectedPolygon.Colors[i].Item1 - 1,
                        this.SelectedPolygon.Colors[i].Item2);
            }

            bool isColorful = this.SelectedPolygon.Colors.Count > 0;
            bool hasImage = this.SelectedPolygon.IsBitmapSet();
            bool isHeightedImage = this.SelectedPolygon.IsBitmapHeighted;
            bool isSingleColor = !this.SelectedPolygon.Colors.Any(c => c.Item2 != this.SelectedPolygon.Colors[0].Item2);

            if (isColorful || hasImage)
            {
                var edgeTable = this.FillingService.InitTables(this.SelectedPolygon);
                this.FillingService.RunFilling(edgeTable, Color.White, false, true);
            }

            this.SelectedPolygon.Edges[prevEdgeIdx] = newLine;
            this.SelectedPolygon.Edges.RemoveAt(index);

          
            if (this.VertexPickers.Count <= 2)
            {
                if (this.SelectedPolygon.IsBitmapSet())
                    this.SelectedPolygon.BitmapFilling.Dispose();
                this.Polygons.Remove(this.SelectedPolygon);
                foreach (var line in this.SelectedPolygon.Edges)
                    this.LineService.EraseLine(line);
                this.ExitPolygonOptions();
                this.CauseRedrawPolygons();
                this.pictureBox.Invalidate();
                return;
            }

            if (isColorful || hasImage)
            {
                var edgeTable = this.FillingService.InitTables(this.SelectedPolygon);

                if (hasImage)
                {
                    if (isHeightedImage)
                    {
                        this.FillingService.RunHeightImageFilling(edgeTable, this.SelectedPolygon, false);
                    }
                    else
                    {
                        this.FillingService.RunImageFilling(edgeTable, this.SelectedPolygon, false);
                    }
                }
                else if (isSingleColor && this.SelectedPolygon.Colors.Count > 0)
                {
                    this.FillingService.RunFilling(edgeTable, this.SelectedPolygon.Colors[0].Item2, false);
                }
                else
                {
                    this.FillingService.RunGradientFilling(edgeTable, this.SelectedPolygon, false);
                }


                foreach (var polygon in this.Polygons)
                {
                    foreach (var edge in polygon.Edges)
                    {
                        this.LineService.CreateLine(edge);
                    }
                }
            }

            this.CauseRedrawPolygons();
            this.pictureBox.Invalidate();

        }

        public void SavePolygon(Polygon polygon)
        {
            this.Polygons.Add(polygon);
            this.polygonListBox.Items.Add(new ListViewItem() { Text = $"p_{this.Polygons.Count}", Name = $"p_{this.Polygons.Count}" });
        }

        public void BeginDoubleTracking(Mover mover)
        {
            var prevVertice = this.SelectedPolygon.Vertices[mover.Index == 0 ? this.SelectedPolygon.Vertices.Count - 1 : mover.Index - 1];
            var nextVertice = this.SelectedPolygon.Vertices[mover.Index == this.SelectedPolygon.Vertices.Count - 1 ? 0 : mover.Index + 1];
            this.LineService.BeginDoubleTracking(prevVertice.X, prevVertice.Y, nextVertice.X, nextVertice.Y);
            if (this.SelectedPolygon.Colors.Count > 0 || this.SelectedPolygon.IsBitmapSet())
            {
                var edgeTable = this.FillingService.InitTables(this.SelectedPolygon);
                this.FillingService.RunFilling(edgeTable, Color.White, false, true);
            }
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

        public void EnterFillPolygonMode()
        {
            var edgeTable = this.FillingService.InitTables(this.SelectedPolygon);

            var colorDialog = new ColorDialog();
            colorDialog.Color = Color.Red;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.FillingService.RunFilling(edgeTable, colorDialog.Color, false);

                if (this.SelectedPolygon.IsBitmapSet())
                    this.SelectedPolygon.BitmapFilling.Dispose();

                this.SelectedPolygon.Colors.Clear();
                for (int i = 0; i < this.SelectedPolygon.Vertices.Count; i++)
                {
                    this.SelectedPolygon.Colors.Add((i, colorDialog.Color));
                }

            }
            else return;

            foreach (var polygon in this.Polygons)
            {
                foreach (var line in polygon.Edges)
                {
                    this.LineService.CreateLine(line);
                }
            }

            this.pictureBox.Invalidate();
        }

        public void EnterImagePolygonMode()
        {
            var edgeTable = this.FillingService.InitTables(this.SelectedPolygon);

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Browse Image Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "png",
                Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg",
                FilterIndex = 1,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var image = Image.FromFile(openFileDialog.FileName);
                var directBitmap = new DirectBitmap(image.Width, image.Height);
                using (Graphics g = Graphics.FromImage(directBitmap.Bitmap))
                {
                    g.DrawImage(image, 0, 0, image.Width, image.Height);
                }


                if (this.SelectedPolygon.IsBitmapSet())
                    this.SelectedPolygon.BitmapFilling.Dispose();

                this.SelectedPolygon.IsBitmapHeighted = false;

                this.form.imageBmp = directBitmap;
                this.SelectedPolygon.BitmapFilling = this.form.imageBmp;

                this.FillingService.RunImageFilling(edgeTable, this.SelectedPolygon, false);

                this.SelectedPolygon.Colors.Clear();
                
            }

            foreach (var polygon in this.Polygons)
            {
                foreach (var line in polygon.Edges)
                {
                    this.LineService.CreateLine(line);
                }
            }

            this.pictureBox.Invalidate();
        }

        public void EnterColorVerticeMode()
        {
            int idx = 0;
            foreach (var vertice in SelectedPolygon.Vertices)
            {
                var vertexColorer = new VertexColorer(vertice, idx++, this);
                VertexPickers.Add(vertexColorer);
                this.pictureBox.Controls.Add(vertexColorer);
            }
        }

        public void ColorVertice(int index)
        {
            var edgeTable = this.FillingService.InitTables(this.SelectedPolygon);

            var colorDialog = new ColorDialog();
            colorDialog.Color = Color.Red;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.SelectedPolygon.Colors = this.SelectedPolygon.Colors.FindAll(c => c.Item1 != index);
                this.SelectedPolygon.Colors.Add((index, colorDialog.Color));

                this.FillingService.RunGradientFilling(edgeTable, this.SelectedPolygon, false);

                if (this.SelectedPolygon.IsBitmapSet())
                    this.SelectedPolygon.BitmapFilling.Dispose();

            }
            else return;

            foreach (var polygon in this.Polygons)
            {
                foreach (var line in polygon.Edges)
                {
                    this.LineService.CreateLine(line);
                }
            }

            this.pictureBox.Invalidate();
        }

        public List<Direction> MovePolygon(Polygon polygon, (int, int) offsetLocation)
        {
            bool isColorful = polygon.Colors.Count > 0;
            bool isSingleColor = !polygon.Colors.Any(c => c.Item2 != polygon.Colors[0].Item2);
            bool hasImage = polygon.IsBitmapSet();
            bool isHeightedImage = polygon.IsBitmapHeighted;

            if (isColorful || hasImage)
            {
                var edgeTable = this.FillingService.InitTables(polygon);
                this.FillingService.RunFilling(edgeTable, Color.White, true, true);
            }


            for (int i = 0; i < polygon.Vertices.Count; i++)
            {
                var oldPoint = polygon.Vertices[i];

                polygon.Vertices[i] = new Point(
                    oldPoint.X + offsetLocation.Item1,
                    oldPoint.Y + offsetLocation.Item2);

                var currLine = polygon.Edges[i];
                this.LineService.EraseTrackingLine(currLine);

                currLine.Points[0] = new Point(currLine.Points[0].X + offsetLocation.Item1,
                    currLine.Points[0].Y + offsetLocation.Item2);
                currLine.Points[1] = new Point(currLine.Points[1].X + offsetLocation.Item1,
                    currLine.Points[1].Y + offsetLocation.Item2);
            }
            if (isColorful || hasImage)
            {
                var edgeTable = this.FillingService.InitTables(polygon);
                if (hasImage)
                {
                    if (isHeightedImage)
                    {
                        this.FillingService.RunHeightImageFilling(edgeTable, polygon, true);
                    }
                    else
                    {
                        this.FillingService.RunImageFilling(edgeTable, polygon, true);
                    }
                }
                else if (isSingleColor)
                {
                    this.FillingService.RunFilling(edgeTable, polygon.Colors[0].Item2, true);
                }
                else
                {
                    this.FillingService.RunGradientFilling(edgeTable, polygon, true);
            }
        }
            foreach (var line in polygon.Edges)
            {
                this.LineService.CreateTrackingLine(line);
            }

            return EvaluatePossibleReverse(polygon);
        }

        public List<Direction> EvaluatePossibleReverse(Polygon polygon)
        {
            var directions = new List<Direction>();
            foreach (var edge in polygon.Edges)
            {
                if (edge.Points[0].X <= 0 || edge.Points[1].X <= 0)
                    directions.Add(Direction.Left);
                else if (edge.Points[0].X >= this.LineService.Bmp.Width || edge.Points[1].Y >= this.LineService.Bmp.Width)
                    directions.Add(Direction.Right);
                if (edge.Points[0].Y <= 0 || edge.Points[1].Y <= 0)
                    directions.Add(Direction.Top);
                else if (edge.Points[0].Y >= this.LineService.Bmp.Height || edge.Points[1].Y >= this.LineService.Bmp.Height)
                    directions.Add(Direction.Bottom);
            }
            return directions;
        }

        public void BeginAnimation()
        {
        
            var invalidationWaiters = this.Polygons.Select(p => new ManualResetEvent(false)).ToList();
            var polygonWaiters = this.Polygons.Select(p => new ManualResetEvent(false)).ToList();

            this.shouldThreadGetCancelled = false;

            this.speedVectors = this.RandomService.GenerateRandomSpeedVectors(this.Polygons.Count);


            this.LineService.BeginTrackingNoUpdate();

            foreach (var polygon in this.Polygons)
            {
                if (polygon.Colors.Count > 0 || polygon.IsBitmapSet())
                {
                    var edgeTable = this.FillingService.InitTables(polygon);

                    this.FillingService.RunFilling(edgeTable, Color.White, false, true);
                }
                foreach(var line in polygon.Edges)
                {
                    this.LineService.EraseLine(line);
                }
            }

            Task.Factory.StartNew(() =>
            {
                Parallel.ForEach(this.Polygons, (polygon, state, index) =>
                {
                    var i = Convert.ToInt32(index);
                    var stopWatch = new Stopwatch();
                    while (!shouldThreadGetCancelled)
                    {
                        stopWatch.Start();
                        var direction = MovePolygon(polygon, 
                            (Convert.ToInt32(Math.Round(speedVectors[i].Item1 * this.speedRatio)),
                            Convert.ToInt32(Math.Round(speedVectors[i].Item2 * this.speedRatio))));
                        if (direction.Count > 0)
                        {
                            speedVectors[i] = this.RandomService.GenerateRandomSpeedVector(direction);
                        };
                        stopWatch.Stop();
                        Thread.Sleep((int)Math.Max(0, 50 - stopWatch.ElapsedMilliseconds));
                        stopWatch.Reset();
                        invalidationWaiters[i].Set();
                        polygonWaiters[i].WaitOne();
                        polygonWaiters[i].Reset();
                    }
                    invalidationWaiters[i].Set();
                });
            });
            Control.CheckForIllegalCrossThreadCalls = false;
            Task.Factory.StartNew(() =>
            {
                while (!shouldThreadGetCancelled)
                {
                    for (int i = 0; i < Polygons.Count; i++)
                    {
                        invalidationWaiters[i].WaitOne();
                        invalidationWaiters[i].Reset();
                    }
                    
                    
                    this.LineService.PictureBox.Refresh();
                    
                    for (int i = 0; i < Polygons.Count; i++)
                    {
                        polygonWaiters[i].Set();
                    }
                }
            });
        }

        public void StopAnimation()
        {
            foreach (var polygon in this.Polygons)
            {
                bool isColorful = polygon.Colors.Count > 0;
                bool isSingleColor = !polygon.Colors.Any(c => c.Item2 != polygon.Colors[0].Item2);
                bool hasImage = polygon.IsBitmapSet();
                bool isHeightedImage = polygon.IsBitmapHeighted;

                if (isColorful || hasImage)
                {
                    var edgeTable = this.FillingService.InitTables(polygon);
                    if (hasImage)
                    {
                        if (isHeightedImage)
                        {
                            this.FillingService.RunHeightImageFilling(edgeTable, polygon, false);
                        }
                        else
                        {
                            this.FillingService.RunImageFilling(edgeTable, polygon, false);
                        }
                    }
                    else if (isSingleColor)
                    {
                        this.FillingService.RunFilling(edgeTable, polygon.Colors[0].Item2, false);
                    }
                    else
                    {
                        this.FillingService.RunGradientFilling(edgeTable, polygon, false);
                    }
                }
            }
            foreach (var polygon in this.Polygons)
            {
                foreach (var line in polygon.Edges)
                {
                    this.LineService.CreateLine(line);
                }
            }
            this.LineService.StopTrackingNoDrawing();
            this.shouldThreadGetCancelled = true;
        }

        public void CauseRedrawPolygons()
        {
            foreach (var polygon in this.Polygons)
            {
                bool isColorful = polygon.Colors.Count > 0;
                bool isSingleColor = !polygon.Colors.Any(c => c.Item2 != polygon.Colors[0].Item2);
                bool hasImage = polygon.IsBitmapSet();
                bool isHeightedImage = polygon.IsBitmapHeighted;
                
                if (isColorful || hasImage)
                {
                    var edgeTable = this.FillingService.InitTables(polygon);
                    if (hasImage)
                    {
                        if (isHeightedImage)
                        {
                            this.FillingService.RunHeightImageFilling(edgeTable, polygon, false);
                        }
                        else
                        {
                            this.FillingService.RunImageFilling(edgeTable, polygon, false);
                        }
                    }
                    else if (isSingleColor)
                    {
                        this.FillingService.RunFilling(edgeTable, polygon.Colors[0].Item2, false);
                    }
                    else
                    {
                        this.FillingService.RunGradientFilling(edgeTable, polygon, false);
                    }
                }
            }
            foreach (var polygon in this.Polygons)
            {
                foreach (var line in polygon.Edges)
                {
                    this.LineService.CreateLine(line);
                }
            }
            this.LineService.PictureBox.Invalidate();
        }

        public void EnterHeightImageMode()
        {
            var edgeTable = this.FillingService.InitTables(this.SelectedPolygon);

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Browse Image Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "png",
                Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg",
                FilterIndex = 1,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var image = Image.FromFile(openFileDialog.FileName);
                var directBitmap = new DirectBitmap(image.Width, image.Height);
                using (Graphics g = Graphics.FromImage(directBitmap.Bitmap))
                {
                    g.DrawImage(image, 0, 0, image.Width, image.Height);
                }


                if (this.SelectedPolygon.IsBitmapSet())
                    this.SelectedPolygon.BitmapFilling.Dispose();

                this.SelectedPolygon.IsBitmapHeighted = true;

                this.form.imageBmp = directBitmap;
                this.SelectedPolygon.BitmapFilling = this.form.imageBmp;

                this.FillingService.RunHeightImageFilling(edgeTable, this.SelectedPolygon, false);

                this.SelectedPolygon.Colors.Clear();

            }

            foreach (var polygon in this.Polygons)
            {
                foreach (var line in polygon.Edges)
                {
                    this.LineService.CreateLine(line);
                }
            }

            this.pictureBox.Invalidate();
        }
    }
}
