using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognizer
{
    class Buityfier
    {
        public static Pixel[,] BuityfyOriginalWithSobel(Pixel[,] original, double[,] sobel)
        {
            var width = original.GetLength(0);
            var higth = original.GetLength(1);
            var buityPhoto = new Pixel[width, higth];

            if (original.GetLength(0) != sobel.GetLength(0) && original.GetLength(1) != sobel.GetLength(1))
            {
                return new Pixel[width, higth];
            }



            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < higth; j++)
                {
                    double temp = 0;
                    double tempR = 0;
                    double tempG = 0;
                    double tempB = 0;
                    buityPhoto[i, j] = new Pixel(0,0,0);

                    if (sobel[i, j] >= 0.5) temp = 100 * sobel[i, j];
                    else temp = - 100 * sobel[i, j];
                    unchecked
                    {
                        tempR = Convert.ToByte(temp) + original[i, j].R;
                        tempG = Convert.ToByte(temp) + original[i, j].G;
                        tempB = Convert.ToByte(temp) + original[i, j].B;
                        var a = Convert.ToByte(tempR);
                        var b = Convert.ToByte(tempG);
                        var c = Convert.ToByte(tempB);

                        buityPhoto[i, j].R = a;
                        original[i, j].G = b;
                        original[i, j].B = c;
                    }
                }
            }

            return buityPhoto;
        }
    }
}
