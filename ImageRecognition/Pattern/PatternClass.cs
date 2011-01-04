using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternRecognition
{
    /// <summary>
    /// Class Representing Object with Class And Feature Vector
    /// </summary>
    public class PatternClass
    {
        public FeatureVector FeatureVector {get;set;}
        public int ClassNumber { get; set; }
        public double Distance { get; set; }

        public PatternClass(FeatureVector features, int classNumber)
        {
            FeatureVector = features;
            ClassNumber = classNumber;
        }

    }
}
