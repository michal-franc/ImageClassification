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
        /// <summary>
        /// Classyfies the specified object to one of the class using the Naive Bayes classsificator
        /// </summary>
        /// <param name="gen1"></param>
        /// <param name="gen2"></param>
        /// <param name="p1">Propability of the 1st class</param>
        /// <param name="p2">Propability of the 2nd class</param>
        /// <param name="klasyfikowanyObiekt"></param>
        /// <returns></returns>
        public int Classify(IContinuousDistribution gen1,IContinuousDistribution gen2, double p1, double p2, List<double> klasyfikowanyObiekt)
        {

            double val1 = p1 * gen1.Density(klasyfikowanyObiekt[0]);
            double val2 = p2 * gen2.Density(klasyfikowanyObiekt[0]);

            if (val1 > val2)
                return 1;
            else
                return 2;
        }

        /// <summary>
        /// Calculates the Bayes Risk
        /// </summary>
        /// <param name="gen1">First Distribution</param>
        /// <param name="gen2">Second Distribution</param>
        /// <param name="p1">Propability of the class in the First Distribution</param>
        /// <param name="p2">Propability of the class in the Second Distribution </param>
        /// <returns></returns>
        public double CalculateBayesRisk(IContinuousDistribution dist1,IContinuousDistribution dist2,double p1,double p2)
        {
            bool found = false;
            double x = 0.0;
            double sum = 0.0;
            double sum1 = 0.0;


            found = FindCommonPoint(dist1, dist2, ref x);

            if (dist2.Mean > dist1.Mean)
                if (found)
                    return CalculateIntegral(dist1, dist2, x, p1, p2);
            else
                if (found)
                    return CalculateIntegral(dist2, dist1, x, p1, p2);

            return 0.0;
        }

        /// <summary>
        /// Find the common point beetwen 2 distributions
        /// </summary>
        /// <param name="dist1">First Distribution</param>
        /// <param name="dist2">Second Distribution</param>
        /// <param name="commonPoint"></param>
        /// <returns></returns>
        public bool FindCommonPoint(IContinuousDistribution dist1,IContinuousDistribution dist2,ref double commonPoint)
        {
            bool found = false;
            double step = 0.0;
            if (dist2.Mean > dist1.Mean)
                step = 0.001;
            else
                step = -0.001;

                for (double i = dist1.Mean; i < dist2.Mean; i += 0.001)
                {
                    if (Math.Abs(dist1.Density(i) - dist2.Density(i)) < 0.00001)
                    {
                        commonPoint = i;
                        found = true;
                        break;
                    }
                }

            return found;
        }

        /// <summary>
        /// Calculate integral part of the intersection beetwen two distributions with specified propability
        /// </summary>
        /// <param name="dist1">First Distribution</param>
        /// <param name="dist2">Second Distribution</param>
        /// <param name="commonPoint">common Point of two distributions</param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
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
