using LightFiller.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightFiller
{
    public class RandomService
    {
        /* CONSTANTS FOR RANDOM RANGING */
        
        private const int minSpeed = -60;
        private const int maxSpeed = 60;

        /* randomness seeds, if set to negative, takes time dependent one */
        private int seed = -1;


        Random rnd;
        public RandomService()
        {
            if (seed >= 0)
                rnd = new Random(seed);
            else
                rnd = new Random();
        }

        public List<(int, int)> GenerateRandomSpeedVectors(int polygonCount)
        {
            var speedVectorList = new List<(int, int)>();
            for (int i = 0; i < polygonCount; i++)
            {
                speedVectorList.Add((rnd.Next(minSpeed, maxSpeed), rnd.Next(minSpeed, maxSpeed)));
            }
            return speedVectorList;
        }

        public (int, int) GenerateRandomSpeedVector(List<Direction> directionToReverse)
        {
            var xVector = NextZ(minSpeed, maxSpeed);
            var yVector = NextZ(minSpeed, maxSpeed);

            if (directionToReverse.Contains(Direction.Left))
                xVector = NextZ(0, maxSpeed);
            else if (directionToReverse.Contains(Direction.Right))
                xVector = NextZ(minSpeed, 0);

            if (directionToReverse.Contains(Direction.Top))
                yVector = NextZ(0, maxSpeed);
            else if (directionToReverse.Contains(Direction.Bottom))
                yVector = NextZ(minSpeed, 0);

            return (xVector, yVector);
        }

        private int NextZ(int minValue, int maxValue)
        {
            if (minValue >= 0)
                return rnd.Next(Math.Max(1, minValue), maxValue);
            else if (maxValue <= 0)
                return rnd.Next(minValue, Math.Min(-1, maxValue));
            else
            {
                if (rnd.Next(0, 1) == 0)
                {
                    return rnd.Next(minValue, -1);
                }
                else
                {
                    return rnd.Next(1, maxValue);
                }
            }
        }
    }
}
