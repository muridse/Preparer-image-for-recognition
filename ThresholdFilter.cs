using System.Collections.Generic;
using System.Linq;

namespace Recognizer
{
    public static class ThresholdFilter
    {
        public static double[,] ThresholdFilterRun(double[,] original, double whitePixelsFraction)
        {
            var width = original.GetLength(0);
            var height = original.GetLength(1);
            var threshold = new double[width, height];
            double thresholdFactor = 0;

            double whitePixels = whitePixelsFraction * width * height;
            if (width * height == 1) return new double[1, 1] { { (int)whitePixelsFraction } };
            var pixelsList = new List<double>();
            foreach (var pixel in original)
            {
                pixelsList.Add(pixel);
            }
            List<double> sortedPixelList = pixelsList.OrderByDescending(u => u).ToList<double>();

            if ((int)whitePixels == 0)
            {
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        threshold[i, j] = 0;
                    }
                }
            }
            else
            {
                thresholdFactor = sortedPixelList[(int)whitePixels - 1];

                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if (original[i, j] >= thresholdFactor)
                        {
                            threshold[i, j] = 1;
                        }
                        else
                        {
                            threshold[i, j] = 0;
                        }
                    }
                }
            }
            return threshold;
        }
    }
}