using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PatternRecognition
{
    /// <summary>
    /// Calculates the distance beetwen two features 
    /// </summary>
    public class EuclideanDistance : IDistanceAlgorithm
    {
        #region IDistanceAlgorithm Members

        public double CalculateDistance(List<double> x1, List<double> x2)
        {
            double sum = 0.0;

            if (x1.Count != x2.Count)
            {
                throw new System.ArgumentException("Problem with parameters dimension");
            }

            for (int i = 0; i < x1.Count; i++)
            {
                sum += Math.Pow(Math.Abs(x1[i] - x2[i]), 2);
            }

            return Math.Sqrt(sum); ;
        }

        #endregion
    }
}
