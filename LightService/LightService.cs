using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LightFiller
{
    public class LightService
    {
        private (double, double, double) LightColor;

        public double k_d;
        public double k_s;

        public Point LightPosition;

        public int LightHeight;

        public int m = 50;

        private (double, double, double) V = (0, 0, 1);

        public LightShower LightShower;

        public LightService(LightShower lightShower)
        {
            this.LightShower = lightShower;
        }

        public void InitLight(Point location)
        {
            this.k_d = 0.5;
            this.k_s = 0.5;
            this.LightPosition = location;
            this.LightColor = (1, 1, 1);
            this.LightHeight = 200;
        }

        public void SetLight(Color color)
        {
            this.LightColor = (color.R / (double)255, color.G / (double)255, color.B / (double)255);
        }

        private double EvaluateColorRatio(Point point)
        {
            var N = GetNormalizedN();
            var L = GetNormalizedL(point);
            var R = GetNormalizedR(N, L);
            return k_d * (N.Item1 * L.Item1 + N.Item2 * L.Item2 + N.Item3 * L.Item3)
                + k_s * Math.Pow(V.Item1 * R.Item1 + V.Item2 * R.Item2 + V.Item3 * R.Item3, m);
        }

        private (double, double, double) GetNormalizedN()
        {
            return (0, 0, 1);
        }

        private (double, double, double) GetHeightedN((int, int) xNeighbours, (int, int) yNeighbours)
        {
            var vec = ((xNeighbours.Item2 - xNeighbours.Item1) * LightHeight / (double)255, 
                (yNeighbours.Item2 - yNeighbours.Item1) * LightHeight / (double)255, 1);

            var dist = Math.Sqrt(vec.Item1 * vec.Item1 + vec.Item2 * vec.Item2 + vec.Item3 * vec.Item3);

            return (vec.Item1 / dist, vec.Item2 / dist, vec.Item3 / dist);
        }

        private (double, double, double) GetNormalizedL(Point point)
        {
            (int, int, int) notNormalized = (LightPosition.X - point.X, LightPosition.Y - point.Y, LightHeight);

            var dist = Math.Sqrt(notNormalized.Item1 * notNormalized.Item1 + notNormalized.Item2 * notNormalized.Item2 +
                notNormalized.Item3 * notNormalized.Item3);

            return (notNormalized.Item1 * 1 / dist, notNormalized.Item2 * 1 / dist, notNormalized.Item3 * 1 / dist);
        }

        private (double, double, double) GetNormalizedR((double, double, double) N, (double, double, double) L)
        {
            var scalar = N.Item1 * L.Item1 + N.Item2 * L.Item2 + N.Item3 * L.Item3;
            return (2 * scalar * N.Item1 - L.Item1, 2 * scalar * N.Item2 - L.Item2, 2 * scalar * N.Item3 - L.Item3);
        }

        public Color EvaluateLightedColor(Color color, Point point)
        {
            var ratio = EvaluateColorRatio(point);

            var normalizedColors = (color.R / (double)255, color.G / (double)255, color.B / (double)255);

            return Color.FromArgb(
                Math.Min(Convert.ToInt32(Math.Round(normalizedColors.Item1 * LightColor.Item1 * ratio * 255)), 255),
                Math.Min(Convert.ToInt32(Math.Round(normalizedColors.Item2 * LightColor.Item2 * ratio * 255)), 255),
                Math.Min(Convert.ToInt32(Math.Round(normalizedColors.Item3 * LightColor.Item3 * ratio * 255)), 255)
                );
        }

        private double EvaluateHeightedColorRatio(Point point, (int, int) xNeighbours, (int, int) yNeighbours)
        {
            var N = GetHeightedN(xNeighbours, yNeighbours);
            var L = GetNormalizedL(point);
            var R = GetNormalizedR(N, L);
            return k_d * (N.Item1 * L.Item1 + N.Item2 * L.Item2 + N.Item3 * L.Item3)
                + k_s * Math.Pow(V.Item1 * R.Item1 + V.Item2 * R.Item2 + V.Item3 * R.Item3, m);
        }

        public Color EvaluateHeightLightedColor(Point point, (int, int)[] xNeighbours, (int, int)[] yNeighbours)
        {
            var ratioR = EvaluateHeightedColorRatio(point, xNeighbours[0], yNeighbours[0]);
            var ratioG = EvaluateHeightedColorRatio(point, xNeighbours[1], yNeighbours[1]);
            var ratioB = EvaluateHeightedColorRatio(point, xNeighbours[2], yNeighbours[2]);

            //var normalizedColors = (color.R / (double)255, color.G / (double)255, color.B / (double)255);

            var normalizedColors = (1, 1, 1);

            return Color.FromArgb(
                Math.Max(Math.Min(Convert.ToInt32(Math.Round(normalizedColors.Item1 * LightColor.Item1 * ratioR * 255)), 255), 0),
                Math.Max(Math.Min(Convert.ToInt32(Math.Round(normalizedColors.Item2 * LightColor.Item2 * ratioG * 255)), 255), 0),
                Math.Max(Math.Min(Convert.ToInt32(Math.Round(normalizedColors.Item3 * LightColor.Item3 * ratioB * 255)), 255), 0)
                );
        }
    }
}
