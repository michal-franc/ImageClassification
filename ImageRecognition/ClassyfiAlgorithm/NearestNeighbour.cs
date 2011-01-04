using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternRecognition
{
    /// <summary>
    /// Implementation of the Nearest Neighbour Algorithm
    /// </summary>
    public class NearestNeighbour : IClassyfiAlgorithm
    {
        private int _alpha = 2;
        IDistanceAlgorithm _dist;

        public NearestNeighbour(int alpha, IDistanceAlgorithm dist)
        {
            _alpha = alpha;
            _dist = dist;
        }
        #region IImageRecognitionAlgorithm Members

        public int Classify(List<PatternClass> teachingVectors, List<double> classyfiedObject)
        {
            double min = double.MaxValue;
            foreach (PatternClass pClass in teachingVectors)
            {
                if (_dist.CalculateDistance(pClass.FeatureVector.Values, classyfiedObject) < min)
                {
                    pClass.Distance = _dist.CalculateDistance(pClass.FeatureVector.Values, classyfiedObject);
                }
            }

            var sortedDistances = from w in teachingVectors orderby w.Distance ascending select w;

            Dictionary<int , int> classCounter = new Dictionary<int,int>();

            int i = 0;
            foreach(PatternClass p in sortedDistances )
            {
                if(!classCounter.ContainsKey(p.ClassNumber))
                {
                    classCounter.Add(p.ClassNumber,0);
                }

                classCounter[p.ClassNumber]++;
                i++;
                if (i >= _alpha)
                {
                    break;
                }
            }

            return (from w in classCounter orderby w.Value descending select w.Key).First();
        }

        #endregion
    }
}
