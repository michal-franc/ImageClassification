using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageRecognition
{
    public class EuclideanDistance : IDistanceAlgorithm
    {
        #region IDistanceAlgorithm Members

        public double CalculateDistance(Bitmap bmp1, Bitmap bmp2)
        {

            int count = 0;
            double distance = 0.0;
            double sum = 0.0;
            if ((bmp1.Width != bmp2.Width) || (bmp1.Height != bmp2.Height))
            {
                throw new System.ArgumentException("Wielkosc Obrazkow nie jest rowna");
            }
            else
            {
                count = bmp1.Width;
            }
            for (int x = 0; x < count; x++)
            {
                for (int y = 0; y < count; y++)
                {
                    sum = sum + Math.Pow(Math.Abs(bmp1.GetPixel(x, y).R - bmp2.GetPixel(x, y).R), 2);
                }
            }
            distance = Math.Sqrt(sum);
            return distance;
        }

        #endregion
    }
}
