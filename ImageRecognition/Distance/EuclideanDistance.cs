using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PatternRecognition
{
    public class EuclideanDistance : IDistanceAlgorithm
    {
        #region IDistanceAlgorithm Members

        public double CalculateDistance(List<double> x1, List<double> x2)
        {
            int count = 0;

            double distance = 0.0;

            double sum = 0.0;


            if (x1.Count != x2.Count)
            {
                throw new System.ArgumentException("Wektory uczace oraz wektor porownywany posiadaja rozne dlugosci !");
            }
            else
            {
                count = x1.Count;
            }

            for (int i = 0; i < count; i++)
            {
                sum = sum + Math.Pow(Math.Abs(x1[i] - x2[i]), 2);
            }
            distance = Math.Sqrt(sum);
            return distance;
        }

        #endregion
    }
}
