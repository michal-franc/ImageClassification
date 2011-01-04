using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternRecognition
{
    /// <summary>
    /// Used to store features
    /// </summary>
    public class FeatureVector
    {
        public List<double> Values { get; set; }


        public FeatureVector(params double[] values)
        {
            Values = new List<double>();
            foreach (double d in values)
            {
                Values.Add(d);
            }
        }
    }
}
