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
            int dimensions = teachingVectors.FirstOrDefault().FeatureVector.Values.Count;

            List<PatternClass> classWithAverages = new List<PatternClass>();

            for(int i=1;i<=2;i++)
            {
                PatternClass averageClass = new PatternClass(new FeatureVector(dimensions), i);
                foreach(PatternClass obj in teachingVectors.Where(x => x.ClassNumber == i) )
                {
                    int k=0;
                    foreach(double d in obj.FeatureVector.Values)
                    {
                        averageClass.FeatureVector.Values[k]+=d;
                        k++;
                    }
                }
                classWithAverages.Add(averageClass);
            }

            foreach (PatternClass averageClass in classWithAverages)
            {
                for (int i = 0; i < dimensions;i++ )
                {
                    double value = averageClass.FeatureVector.Values[i];
                    double count = teachingVectors.Where(x => x.ClassNumber == averageClass.ClassNumber).Count();
                    averageClass.FeatureVector.Values[i] = value / count;
                }
            }

            int classNumber = 0;
            double min = double.MaxValue;
            foreach(PatternClass avgClass in classWithAverages)
            {
                    if (_dist.CalculateDistance(avgClass.FeatureVector.Values, classyfiedObject) < min)
                    {
                        classNumber = avgClass.ClassNumber;
                        min = _dist.CalculateDistance(avgClass.FeatureVector.Values, classyfiedObject);
                    }
            }
            return classNumber;
        }

        #endregion
    }
}
