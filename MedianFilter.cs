using System.Collections.Generic;
using System.Linq;

namespace Recognizer
{
	internal static class MedianFilter
	{
		public static double[,] MedianFilterRun(double[,] original)
		{
            var width = original.GetLength(0);
            var height = original.GetLength(1);

            var filteredPicture = new double[width, height];

            var medianCashList = new List<double>();
            double averageValue = 0;
            if (width == 1 && height == 1) return original;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    medianCashList.Add(original[i, j]);
                    if (i - 1 >= 0 && j - 1 >= 0) medianCashList.Add(original[i-1, j-1]);
                    if (i >= 0 && j - 1 >= 0) medianCashList.Add(original[i, j - 1]);
                    if (i + 1 >= 0 && j - 1 >= 0 && i + 1 < width && j - 1 < height) medianCashList.Add(original[i + 1, j - 1]);
                    if (i + 1 < width && j < height) medianCashList.Add(original[i + 1, j]);
                    if (i + 1 < width && j + 1 < height) medianCashList.Add(original[i + 1, j + 1]);
                    if (i < width && j + 1 < height) medianCashList.Add(original[i, j + 1]);
                    if (i - 1 >= 0 && j + 1 >= 0 && i - 1 < width && j + 1 < height) medianCashList.Add(original[i - 1, j + 1]);
                    if (i - 1 >= 0 && j >= 0) medianCashList.Add(original[i - 1, j]);
                    medianCashList.Sort();
                    if (medianCashList.Count() % 2 == 0)
                    {
                        averageValue = (medianCashList[medianCashList.Count() / 2 - 1] + medianCashList[medianCashList.Count() / 2]) / 2;
                    }
                    else
                    {
                        averageValue = medianCashList[medianCashList.Count() / 2];
                    }
                    //filteredPicture[i, j] = medianCashList.Average();
                    filteredPicture[i, j] = averageValue;
                    medianCashList.Clear();
                }
            }
			return filteredPicture;
		}
	}
}