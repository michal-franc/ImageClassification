using System;
using System.Collections.Generic;
using System.Linq;

namespace ImageRecognition
{
    public class Distribution
    {
        public double StandardDeviation { get; set; }
        public double Variance { get; set; }
        public double Mean { get; set; }

        public Distribution(List<Double> values)
        {
            Mean  = CalculateMean(values);
            Variance = CalculateVariation(values,Mean);
            StandardDeviation = CalculateStandardDeviation(Variance);
        }

        public static double CalculateStandardDeviation(double Variation)
        {
            return Math.Sqrt(Variation);
        }

        public static double CalculateVariation(List<double> values,double Mean)
        {
            double value = 1.0 / (values.Count - 1);
            double value1= 0.0; 

            foreach(double d in values)
            {
                value1+= Math.Pow(d-Mean,2);
            }
            return value *value1;
        }

        public static double CalculateMean(List<Double> values)
        {
            return values.Sum() / values.Count;
        }

    }
}
