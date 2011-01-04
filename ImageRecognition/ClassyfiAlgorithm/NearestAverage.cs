using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternRecognition
{
    /// <summary>
    /// Implementation of the Nearest Average Algorithm
    /// </summary>
    public class NearestAverage : IClassyfiAlgorithm
    {
        private IDistanceAlgorithm _dist;



        public NearestAverage(IDistanceAlgorithm dist)
        {
            _dist = dist;
        }

        #region IClassyfiAlgorithm Members

        public int Classify(List<PatternClass> teachingVectors, List<double> classyfiedObject)
        {
            Dictionary<int, double> averageValues = new Dictionary<int, double>();
            Dictionary<int, double> sums = new Dictionary<int,double>();

            foreach (PatternClass obj in teachingVectors)
            {
                if (!averageValues.ContainsKey(obj.ClassNumber))
                {
                    averageValues.Add(obj.ClassNumber, 0);
                    sums.Add(obj.ClassNumber,0);
                }

                averageValues[obj.ClassNumber]++;
                sums[obj.ClassNumber] += obj.FeatureVector.Values[0];
            }

            for (int i = 1; i <= averageValues.Count+1;i++ )
            {
                if (averageValues.ContainsKey(i))
                {
                    averageValues[i] = sums[i] / averageValues[i];
                }
            }

            int classNumber = 0;
            double min = double.MaxValue;
            for (int i = 1; i <= averageValues.Count+1;i++ )
            {
                if (averageValues.ContainsKey(i))
                {
                    if (_dist.CalculateDistance(new List<double>() { averageValues[i] }, classyfiedObject) < min)
                    {
                        classNumber = i;
                        min = _dist.CalculateDistance(new List<double>() { averageValues[i] }, classyfiedObject);
                    }
                }
            }
            return classNumber;
        }

        #endregion
    }
}
