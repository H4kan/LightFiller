using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LightFiller
{
    public class LineService
    {
        public DirectBitmap Bmp { get; set; }

        public DirectBitmap TrackingBmp { get; set; }

        public BresenhamLine BrensehamLine { get; set; }

        public BresenhamLine BrensehamTrackingLine { get; set; }

        public LineTracker LineTracker { get; set; }

        public LineTracker DoubleTracker { get; set; }

        public PictureBox PictureBox { get; set; }

        public bool IsLineTracking { get; set; }

        private LightService lightService;

        private Form1 form;

        public LineService(DirectBitmap bmp, PictureBox pictureBox, LightService lightService, Form1 form)
        {
            this.Bmp = bmp;
            this.BrensehamLine = new BresenhamLine(bmp);
            
            this.PictureBox = pictureBox;
            this.lightService = lightService;
            this.form = form;
        }

        public void BeginTracking(int x, int y)
        {
            this.IsLineTracking = true;
            TrackingBmp = (DirectBitmap)Bmp.Clone();
            this.BrensehamTrackingLine = new BresenhamLine(TrackingBmp);
            this.PictureBox.Image = TrackingBmp.Bitmap;
            this.PictureBox.Invalidate();
            LineTracker = new LineTracker(this, x, y);
            this.PictureBox.MouseMove += this.LineTracker.Update;
        }

        public void BeginTrackingNoUpdate()
        {
            TrackingBmp = (DirectBitmap)Bmp.Clone();
            this.BrensehamTrackingLine = new BresenhamLine(TrackingBmp);
            this.PictureBox.Image = TrackingBmp.Bitmap;
            this.PictureBox.Invalidate();
        }

        public void BeginDoubleTracking(int x1, int y1, int x2, int y2)
        {
            TrackingBmp = (DirectBitmap)Bmp.Clone();
            this.BrensehamTrackingLine = new BresenhamLine(TrackingBmp);
            this.PictureBox.Image = TrackingBmp.Bitmap;
            this.PictureBox.Invalidate();
            LineTracker = new LineTracker(this, x1, y1);
            DoubleTracker = new LineTracker(this, x2, y2);

        }

        public void StopTracking()
        {
            var line = this.LineTracker.LastLine;
            this.CreateLine(line);

            this.PictureBox.Image = Bmp.Bitmap;
            this.TrackingBmp.Dispose();
            LineTracker = null;

            this.PictureBox.Invalidate();
        }

        public void StopTracking(Line line)
        {
            this.CreateLine(line);

            this.PictureBox.Image = Bmp.Bitmap;
            this.TrackingBmp.Dispose();

            this.PictureBox.Invalidate();
        }

        public void StopTrackingNoDrawing()
        {
            this.PictureBox.Image = Bmp.Bitmap;
            this.TrackingBmp.Dispose();

            this.PictureBox.Invalidate();
        }

        public (Line, Line) StopDoubleTracking()
        {
            var line = this.LineTracker.LastLine;
            this.CreateLine(line);

            var dblLine = this.DoubleTracker.LastLine;
            this.CreateLine(dblLine);

            this.PictureBox.Image = Bmp.Bitmap;
            this.TrackingBmp.Dispose();
            LineTracker = null;
            DoubleTracker = null;

            this.PictureBox.Invalidate();

            return (line, dblLine);
        }

        public void AbortTracking()
        {

            this.PictureBox.Image = Bmp.Bitmap;
            this.TrackingBmp.Dispose();
            LineTracker = null;

            this.PictureBox.Invalidate();
            this.IsLineTracking = false;
        }

        public Line CreateLine(int x1, int y1, int x2, int y2)
        {
                return BrensehamLine.CreateLine(
                x1, y1, x2, y2);

            
        }
        public Line CreateLine(Line line)
        {
            return this.CreateLine(line.Points[0].X, line.Points[0].Y, line.Points[1].X, line.Points[1].Y);
        }

        public Line CreateTrackingLine(int x1, int y1, int x2, int y2)
        {
            
            return BrensehamTrackingLine.CreateLine(x1, y1, x2, y2);

            
        }
        public Line CreateTrackingLine(Line line)
        {
            return this.CreateTrackingLine(line.Points[0].X, line.Points[0].Y, line.Points[1].X, line.Points[1].Y);
        }


        public void EraseLine(Line line)
        {
            BrensehamLine.EraseLine(line);
        }

        public void EraseTrackingLine(Line line)
        {
            BrensehamTrackingLine.EraseLine(line);
        }

        public void FastHorizontalLine(int x1, int x2, int y, Color color)
        {
            if (x1 >= Bmp.Width || x2 < 0 || y < 0 || y >= Bmp.Height) return;
            if (x1 < 0) x1 = 0;
            if (x2 >= Bmp.Width) x2 = Bmp.Width - 1;
            int x = x1;
            while (x <= x2)
            {       
                Bmp.SetPixel(x, y, color);
                x++;
            }   
            
        }

        public void FastHorizontalTrackingLine(int x1, int x2, int y, Color color)
        {
            if (x1 >= Bmp.Width || x2 < 0 || y < 0 || y >= Bmp.Height) return;
            if (x1 < 0) x1 = 0;
            if (x2 >= Bmp.Width) x2 = Bmp.Width - 1;
            int x = x1;
            while (x <= x2)
            {
                TrackingBmp.SetPixel(x, y, color);    
                x++;
            }
            
        }

        public void FastHorizontalLightedLine(int x1, int x2, int y, Color color)
        {
            if (x1 >= Bmp.Width || x2 < 0 || y < 0 || y >= Bmp.Height) return;
            if (x1 < 0) x1 = 0;
            if (x2 >= Bmp.Width) x2 = Bmp.Width - 1;
            int x = x1;
            while (x <= x2)
            {
                Bmp.SetPixel(x, y, this.lightService.EvaluateLightedColor(color, new Point(x, y)));
                x++;
            }

        }

        public void FastHorizontalLightedTrackingLine(int x1, int x2, int y, Color color)
        {
            if (x1 >= Bmp.Width || x2 < 0 || y < 0 || y >= Bmp.Height) return;
            if (x1 < 0) x1 = 0;
            if (x2 >= Bmp.Width) x2 = Bmp.Width - 1;
            int x = x1;
            while (x <= x2)
            {
                TrackingBmp.SetPixel(x, y, this.lightService.EvaluateLightedColor(color, new Point(x, y)));
                x++;
            }

        }


        public void GradientHorizontalLine(int x1, int x2, int y, Polygon polygon)
        {
            if (x1 >= Bmp.Width || x2 < 0 || y < 0 || y >= Bmp.Height) return;
            if (x1 < 0) x1 = 0;
            if (x2 >= Bmp.Width) x2 = Bmp.Width - 1;
            int x = x1;
            while (x <= x2)
            {
                Bmp.SetPixel(x, y, EvaluateGradient(polygon, x, y));

                x++;
            }   
        }
        

        public void GradientHorizontalTrackingLine(int x1, int x2, int y, Polygon polygon)
        {
            if (x1 >= Bmp.Width || x2 < 0 || y < 0 || y >= Bmp.Height) return;
            if (x1 < 0) x1 = 0;
            if (x2 >= Bmp.Width) x2 = Bmp.Width - 1;
            int x = x1;
            while (x <= x2)
            {
                TrackingBmp.SetPixel(x, y, EvaluateGradient(polygon, x, y));

                x++;
            }
        }

        public void GradientHorizontalLightedLine(int x1, int x2, int y, Polygon polygon)
        {
            if (x1 >= Bmp.Width || x2 < 0 || y < 0 || y >= Bmp.Height) return;
            if (x1 < 0) x1 = 0;
            if (x2 >= Bmp.Width) x2 = Bmp.Width - 1;
            int x = x1;
            while (x <= x2)
            {
                Bmp.SetPixel(x, y, this.lightService.EvaluateLightedColor(EvaluateGradient(polygon, x, y), new Point(x, y)));

                x++;
            }
        }


        public void GradientHorizontalLightedTrackingLine(int x1, int x2, int y, Polygon polygon)
        {
            if (x1 >= Bmp.Width || x2 < 0 || y < 0 || y >= Bmp.Height) return;
            if (x1 < 0) x1 = 0;
            if (x2 >= Bmp.Width) x2 = Bmp.Width - 1;
            int x = x1;
            while (x <= x2)
            {
                TrackingBmp.SetPixel(x, y, this.lightService.EvaluateLightedColor(EvaluateGradient(polygon, x, y), new Point(x, y)));

                x++;
            }
        }

        public void FastHorizontalImageLine(int x1, int x2, int y, int offsetX, int offsetY, Polygon polygon)
        {
            if (x1 >= Bmp.Width || x2 < 0 || y < 0 || y >= Bmp.Height) return;
            if (x1 < 0) x1 = 0;
            if (x2 >= Bmp.Width) x2 = Bmp.Width - 1;
            int x = x1;
            while (x <= x2)
            {
                Bmp.SetPixel(x, y, polygon.BitmapFilling.GetPixel((x - offsetX) % polygon.BitmapFilling.Width, 
                    (y - offsetY) % polygon.BitmapFilling.Height));
                x++;
            }

        }

        public void FastHorizontalImageTrackingLine(int x1, int x2, int y, int offsetX, int offsetY, Polygon polygon)
        {
            if (x1 >= Bmp.Width || x2 < 0 || y < 0 || y >= Bmp.Height) return;
            if (x1 < 0) x1 = 0;
            if (x2 >= Bmp.Width) x2 = Bmp.Width - 1;
            int x = x1;
            while (x <= x2)
            {
                TrackingBmp.SetPixel(x, y, polygon.BitmapFilling.GetPixel((x - offsetX) % polygon.BitmapFilling.Width, 
                    (y - offsetY) % polygon.BitmapFilling.Height));
                x++;
            }

        }

        public void FastHorizontalImageLightedLine(int x1, int x2, int y, int offsetX, int offsetY, Polygon polygon)
        {
            if (x1 >= Bmp.Width || x2 < 0 || y < 0 || y >= Bmp.Height) return;
            if (x1 < 0) x1 = 0;
            if (x2 >= Bmp.Width) x2 = Bmp.Width - 1;
            int x = x1;
            while (x <= x2)
            {
                Bmp.SetPixel(x, y,
                    this.lightService.EvaluateLightedColor(polygon.BitmapFilling.GetPixel((x - offsetX) % polygon.BitmapFilling.Width,
                            (y - offsetY) % polygon.BitmapFilling.Height),
                        new Point(x, y))
                    );
                x++;
            }
        }

        public void FastHorizontalImageLightedTrackingLine(int x1, int x2, int y, int offsetX, int offsetY, Polygon polygon)
        {
            if (x1 >= Bmp.Width || x2 < 0 || y < 0 || y >= Bmp.Height) return;
            if (x1 < 0) x1 = 0;
            if (x2 >= Bmp.Width) x2 = Bmp.Width - 1;
            int x = x1;
            while (x <= x2)
            {
                TrackingBmp.SetPixel(x, y, 
                    this.lightService.EvaluateLightedColor(polygon.BitmapFilling.GetPixel((x - offsetX) % polygon.BitmapFilling.Width, 
                            (y - offsetY) % polygon.BitmapFilling.Height), 
                        new Point(x, y))
                    );
                x++;
            }
        }

        public void FastHorizontalHeightedImageLine(int x1, int x2, int y, int offsetX, int offsetY, Polygon polygon)
        {
            if (x1 >= Bmp.Width || x2 < 0 || y < 0 || y >= Bmp.Height) return;
            if (x1 < 0) x1 = 0;
            if (x2 >= Bmp.Width) x2 = Bmp.Width - 1;
            int x = x1;
            while (x <= x2)
            {
                Bmp.SetPixel(x, y, polygon.BitmapFilling.GetPixel((x - offsetX) % polygon.BitmapFilling.Width,
                    (y - offsetY) % polygon.BitmapFilling.Height));
                x++;
            }

        }

        public void FastHorizontalHeightedImageTrackingLine(int x1, int x2, int y, int offsetX, int offsetY, Polygon polygon)
        {
            if (x1 >= Bmp.Width || x2 < 0 || y < 0 || y >= Bmp.Height) return;
            if (x1 < 0) x1 = 0;
            if (x2 >= Bmp.Width) x2 = Bmp.Width - 1;
            int x = x1;
            while (x <= x2)
            {
                TrackingBmp.SetPixel(x, y, polygon.BitmapFilling.GetPixel((x - offsetX) % polygon.BitmapFilling.Width,
                    (y - offsetY) % polygon.BitmapFilling.Height));
                x++;
            }

        }

        public void FastHorizontalHeightedImageLightedLine(int x1, int x2, int y, int offsetX, int offsetY, Polygon polygon)
        {
            if (x1 >= Bmp.Width || x2 < 0 || y < 0 || y >= Bmp.Height) return;
            if (x1 < 0) x1 = 0;
            if (x2 >= Bmp.Width) x2 = Bmp.Width - 1;
            int x = x1;
            
            while (x <= x2)
            {
                var prevXPixel = polygon.BitmapFilling.GetPixel(
                ((x - 1 - offsetX) % polygon.BitmapFilling.Width + polygon.BitmapFilling.Width) % polygon.BitmapFilling.Width,
                            (y - offsetY) % polygon.BitmapFilling.Height);
                var nextXPixel = polygon.BitmapFilling.GetPixel((x + 1 - offsetX) % polygon.BitmapFilling.Width,
                                (y - offsetY) % polygon.BitmapFilling.Height);
                var prevYPixel = polygon.BitmapFilling.GetPixel((x - offsetX) % polygon.BitmapFilling.Width,
                                ((y - 1 - offsetY) % polygon.BitmapFilling.Height + polygon.BitmapFilling.Height) % polygon.BitmapFilling.Height);
                var nextYPixel = polygon.BitmapFilling.GetPixel((x - offsetX) % polygon.BitmapFilling.Width,
                                (y + 1 - offsetY) % polygon.BitmapFilling.Height);

                var xNeighbours = new (int, int)[3] {
                (prevXPixel.R, nextXPixel.R),
                (prevXPixel.G, nextXPixel.G),
                (prevXPixel.B, nextXPixel.B)
                };

                var yNeighbours = new (int, int)[3] {
                (prevYPixel.R, nextYPixel.R),
                (prevYPixel.G, nextYPixel.G),
                (prevYPixel.B, nextYPixel.B)
                };


                Bmp.SetPixel(x, y,
                    this.lightService.EvaluateHeightLightedColor(
                        new Point(x, y),
                        xNeighbours,
                        yNeighbours
                    ));
                x++;
            }
        }

        public void FastHorizontalHeightedImageLightedTrackingLine(int x1, int x2, int y, int offsetX, int offsetY, Polygon polygon)
        {
            if (x1 >= Bmp.Width || x2 < 0 || y < 0 || y >= Bmp.Height) return;
            if (x1 < 0) x1 = 0;
            if (x2 >= Bmp.Width) x2 = Bmp.Width - 1;
            int x = x1;
 
            while (x <= x2)
            {
                var prevXPixel = polygon.BitmapFilling.GetPixel(
               ((x - 1 - offsetX) % polygon.BitmapFilling.Width + polygon.BitmapFilling.Width) % polygon.BitmapFilling.Width,
                           (y - offsetY) % polygon.BitmapFilling.Height);
                var nextXPixel = polygon.BitmapFilling.GetPixel((x + 1 - offsetX) % polygon.BitmapFilling.Width,
                                (y - offsetY) % polygon.BitmapFilling.Height);
                var prevYPixel = polygon.BitmapFilling.GetPixel((x - offsetX) % polygon.BitmapFilling.Width,
                                ((y - 1 - offsetY) % polygon.BitmapFilling.Height + polygon.BitmapFilling.Height) % polygon.BitmapFilling.Height);
                var nextYPixel = polygon.BitmapFilling.GetPixel((x - offsetX) % polygon.BitmapFilling.Width,
                                (y + 1 - offsetY) % polygon.BitmapFilling.Height);

                var xNeighbours = new (int, int)[3] {
                (prevXPixel.R, nextXPixel.R),
                (prevXPixel.G, nextXPixel.G),
                (prevXPixel.B, nextXPixel.B)
                };

                var yNeighbours = new (int, int)[3] {
                (prevYPixel.R, nextYPixel.R),
                (prevYPixel.G, nextYPixel.G),
                (prevYPixel.B, nextYPixel.B)
                };


                TrackingBmp.SetPixel(x, y,
                    this.lightService.EvaluateHeightLightedColor(
                        new Point(x, y),
                        xNeighbours,
                        yNeighbours
                    ));
                x++;
            }
        }


        public Color EvaluateGradient(Polygon polygon, int x, int y)
        {
            var numOfColors = polygon.Colors.Count;
            double[] distances = new double[numOfColors];
            double sum = 0;
            for (int i = 0; i < numOfColors; i++)
            {
                distances[i] = 1 / (double)(Utils.CalculateDistance(polygon.Vertices[polygon.Colors[i].Item1], new Point(x, y)) + 1);
                sum += distances[i];
            }

            double rColor = 0, gColor = 0, bColor = 0;

            for (int i = 0; i < numOfColors; i++)
            {
                var ratio = distances[i] / sum;
                rColor +=  ratio * polygon.Colors[i].Item2.R;
                gColor += ratio * polygon.Colors[i].Item2.G;
                bColor += ratio * polygon.Colors[i].Item2.B;

            }

            return Color.FromArgb(
                Convert.ToInt32(Math.Round(rColor)),
                Convert.ToInt32(Math.Round(gColor)),
                Convert.ToInt32(Math.Round(bColor)));
        }
    }
}
