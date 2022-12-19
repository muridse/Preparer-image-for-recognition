using System;

namespace Recognizer
{
    internal static class SobelFilter
    {
        public static double[,] SobelFilterRun(double[,] g, double[,] sx)
        {
            var width = g.GetLength(0);
            var height = g.GetLength(1);

            var widthSX = sx.GetLength(0);
            var heightSX = sx.GetLength(1);

            var result = new double[width, height];


            //for (int x = widthSX / 2; x < width - widthSX / 2; x++)
            //    for (int y = heightSX / 2; y < height - heightSX / 2; y++)
            //    {
            //        var gx =
            //            g[x - 1, y - 1] * 3 + g[x, y - 1] * 10 + g[x + 1, y - 1] * 3
            //          + g[x - 1, y] * 0 + g[x, y] * 0 + g[x + 1, y] * 0
            //          + g[x - 1, y + 1] * (-3) + g[x, y + 1] * (-10) + g[x + 1, y + 1] * (-3);
            //        var gy =
            //            g[x - 1, y - 1] * 3 + g[x, y - 1] * 0 + g[x + 1, y - 1] * (-3)
            //          + g[x - 1, y] * 10 + g[x, y] * 0 + g[x + 1, y] * (-10)
            //          + g[x - 1, y + 1] * 3 + g[x, y + 1] * 0 + g[x + 1, y + 1] * (-3);
            //        result[x, y] = Math.Sqrt(gx * gx + gy * gy);
            //    }



            for (int x = widthSX / 2; x < width - widthSX / 2; x++)
                for (int y = heightSX / 2; y < height - heightSX / 2; y++)
                {
                    var gx =
                        g[x - 1, y - 1] * sx[0, 0] + g[x, y - 1] * sx[0, 1] + g[x + 1, y - 1] * sx[0, 2]
                      + g[x - 1, y] * sx[1, 0] + g[x, y] * sx[1, 1] + g[x + 1, y] * sx[1, 2]
                      + g[x - 1, y + 1] * sx[2, 0] + g[x, y + 1] * sx[2, 1] + g[x + 1, y + 1] * sx[2, 2];
                    var gy =
                        g[x - 1, y - 1] * sx[0, 0] + g[x, y - 1] * sx[1, 0] + g[x + 1, y - 1] * sx[2, 0]
                      + g[x - 1, y] * sx[0, 1] + g[x, y] * sx[1, 1] + g[x + 1, y] * sx[2, 1]
                      + g[x - 1, y + 1] * sx[0, 2] + g[x, y + 1] * sx[1, 2] + g[x + 1, y + 1] * sx[2, 2];
                    result[x, y] = Math.Sqrt(gx * gx + gy * gy);
                }

            return result;
        }
    }
}