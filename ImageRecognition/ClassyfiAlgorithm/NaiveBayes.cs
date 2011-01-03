using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatternRecognition;
using MathNet.Numerics.Distributions;

namespace ImageRecognition.ClassyfiAlgorithm
{
    public class NaiveBayes 
    {
        public int Classify(IContinuousDistribution gen1,IContinuousDistribution gen2, double p1, double p2, List<double> klasyfikowanyObiekt)
        {

            double val1 = p1 * CalculateDensity(klasyfikowanyObiekt[0],gen1);
            double val2 = p2 * CalculateDensity(klasyfikowanyObiekt[0], gen2);

            if (val1 > val2)
                return 1;
            else
                return 2;
        }

        private double CalculateDensity(double x,IContinuousDistribution generator)
        {
            double value = 1.0 / (generator.StdDev * Math.Sqrt(2 * Math.PI));
            double value1 = -Math.Pow(x - generator.Mean, 2) / (2 * generator.Variance);
            double value2 = Math.Exp(value1);
            return value *value2;
        }

        public double CalculateBayesRisk(IContinuousDistribution gen1,IContinuousDistribution gen2,double p1,double p2)
        {
            bool found = false;
            double x = 0.0;
            double sum = 0.0;
            double sum1 = 0.0;
            if (gen2.Mean > gen1.Mean)
            {
                for (double i = gen1.Mean; i < gen2.Mean; i += 0.001)
                {
                    if (Math.Abs(gen1.Density(i) - gen2.Density(i)) < 0.00001)
                    {
                        x = i;
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    for (double i = x; i < gen1.Mean + (4 * gen1.StdDev); i += 0.1)
                    {
                        sum += 0.1 * gen1.Density(i);
                    }

                    for (double i = x - (4 * gen2.StdDev); i < x; i += 0.1)
                    {
                        sum1 += 0.1 * gen2.Density(i);
                    }
                }

            }
            else
            {
                for (double i = gen2.Mean; i < gen1.Mean; i += 0.001)
                {
                    if (Math.Abs(gen1.Density(i) - gen2.Density(i)) < 0.00001)
                    {
                        x = i;
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    for (double i = x; i < x + (8 * gen2.StdDev); i += 0.1)
                    {
                        sum += 0.1 * gen2.Density(i);
                    }

                    for (double i = x - (4 * gen1.StdDev); i < x; i += 0.1)
                    {
                        sum1 += 0.1 * gen1.Density(i);
                    }
                }
            }
            return (p1 * sum + p2 * sum1) * 100;
        }
    }
}
