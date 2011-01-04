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

            double val1 = p1 * gen1.Density(klasyfikowanyObiekt[0]);
            double val2 = p2 * gen2.Density(klasyfikowanyObiekt[0]);

            if (val1 > val2)
                return 1;
            else
                return 2;
        }

        public double CalculateBayesRisk(IContinuousDistribution gen1,IContinuousDistribution gen2,double p1,double p2)
        {
            bool found = false;
            double x = 0.0;
            double sum = 0.0;
            double sum1 = 0.0;


            found = FindCommonPoint(gen1, gen2, ref x);

            if (gen2.Mean > gen1.Mean)
            {

                if (found)
                {
                    return CalculateIntegral(gen1, gen2, x, p1, p2);
                }

            }
            else
            {

                if (found)
                {
                    return CalculateIntegral(gen2, gen1, x, p1, p2);
                }
            }

            return 0.0;
        }

        //Find the common point beetwen 2 distributions
        public bool FindCommonPoint(IContinuousDistribution dist1,IContinuousDistribution dist2,ref double commonPoint)
        {
            bool found = false;
            if (dist2.Mean > dist1.Mean)
            {
                for (double i = dist1.Mean; i < dist2.Mean; i += 0.001)
                {
                    if (Math.Abs(dist1.Density(i) - dist2.Density(i)) < 0.00001)
                    {
                        commonPoint = i;
                        found = true;
                        break;
                    }
                }
            }
            else
            {
                for (double i = dist2.Mean; i < dist1.Mean; i += 0.001)
                {
                    if (Math.Abs(dist1.Density(i) - dist2.Density(i)) < 0.00001)
                    {
                        commonPoint = i;
                        found = true;
                        break;
                    }
                }
            }
            return found;
        }

        // Calculate integral of the intersection beetwen distributions
        private double CalculateIntegral(IContinuousDistribution dist1,IContinuousDistribution dist2,double commonPoint,double p1,double p2)
        {

            double sum = 0.0;
            double sum1 = 0.0;
            for (double i = commonPoint; i < dist1.Mean + (4 * dist1.StdDev); i += 0.1)
            {
                sum += 0.1 * dist1.Density(i);
            }

            for (double i = commonPoint - (4 * dist2.StdDev); i < commonPoint; i += 0.1)
            {
                sum1 += 0.1 * dist2.Density(i);
            }

            return (p1 * sum + p2 * sum1) * 100;
        }
    }
}
