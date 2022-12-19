namespace Recognizer
{
	public static class Grayscale
	{

		public static double[,] ToGrayscale(Pixel[,] original)
		{
            var width = original.GetLength(0);
            var higth = original.GetLength(1);
            var grayPixel = new double[width, higth];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < higth; j++)
                {
                    grayPixel[i, j] = (0.299 * original[i,j].R + 0.587 * original[i, j].G + 0.114 * original[i, j].B) / 255;
                }
            }
            return grayPixel;
		}
	}
}