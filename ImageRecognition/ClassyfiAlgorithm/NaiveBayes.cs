using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatternRecognition;
using MathNet.Numerics.Distributions;

namespace ImageRecognition.ClassyfiAlgorithm
{
    public class NaiveBayes  : IClassyfiAlgorithm
    {
        public double P1 {get;set;}
        public double P2 {get;set;}
        public List<IContinuousDistribution> Gen1 {get;set;}
        public List<IContinuousDistribution> Gen2 { get; set; }

        public NaiveBayes(List<IContinuousDistribution> gen1, List<IContinuousDistribution> gen2, double p1, double p2)
        {
            P1 = p1;
            P2 = p2;
            Gen1 = gen1;
            Gen2 = gen2;
        }

        public int Classify(List<PatternClass> teachingVectors,List<double> klasyfikowanyObiekt)
        {
            //double val1 = 0.0;
            //double val2 = 0.0;

            ////P(D)
            //double sum = P1 * Gen1[0].Density(klasyfikowanyObiekt[0]) + P2 * Gen2[0].Density(klasyfikowanyObiekt[0]);

            ////P(h1,D)
            //val1 = P1 * Gen1[0].Density(klasyfikowanyObiekt[0]) / sum;
            ////P(h2,D)
            //val2 = P2 * Gen2[0].Density(klasyfikowanyObiekt[0]) / sum;

            //double sum1 = val1 * Gen1[0].Density(klasyfikowanyObiekt[0]) + (1-val2 *  Gen2[0].Density(klasyfikowanyObiekt[0]));
            //double sum2 = val2 * Gen2[0].Density(klasyfikowanyObiekt[0]) + (1-val1 *  Gen1[0].Density(klasyfikowanyObiekt[0]));

            double val1 = 0.0;
            double val2 = 0.0;
            foreach (IContinuousDistribution dist in Gen1)
            {
                foreach (double d in klasyfikowanyObiekt)
                {
                    val1 += P1 * dist.Density(d);
                }
            }

            foreach (IContinuousDistribution dist in Gen2)
            {
                foreach (double d in klasyfikowanyObiekt)
                {
                    val2 += P2 * dist.Density(d);
                }
            }
            if (val1 >= val2)
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
        public static double CalculateBayesRisk(List<IContinuousDistribution> dist1,List<IContinuousDistribution> dist2,double p1,double p2)
        {


            if (dist1.Count == 1)
            {
                return CalculateIntegral1(dist1[0], dist2[0], 0, p1, p2);
            }
            else
            {
                return CalculateIntegral(dist1, dist2, p1, p2);
            }
            return 0;

        }

        /// <summary>
        /// Find the common point beetwen 2 distributions
        /// </summary>
        /// <param name="dist1">First Distribution</param>
        /// <param name="dist2">Second Distribution</param>
        /// <param name="commonPoint"></param>
        /// <returns></returns>
        public static bool FindCommonPointNormalDistribution(IContinuousDistribution dist1,IContinuousDistribution dist2,ref double commonPoint)
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
        private static double CalculateIntegral(List<IContinuousDistribution> dist1,List<IContinuousDistribution> dist2,double p1,double p2)
        {
            double start= double.MaxValue;
            double stop = 0.0;

            
            {
                double start1 = dist1[0].Mean - 4*dist1[0].StdDev;
                double start2 = dist2[0].Mean - 4*dist2[0].StdDev;

                double stop1 = dist1[0].Mean + 4 * dist1[0].StdDev;
                double stop2= dist2[0].Mean + 4 * dist2[0].StdDev;

                start = start1 < start2 ? start1 : start2;
                stop = stop1 > stop2 ? stop1 : stop2;

            }

            
            {
                double start1 = dist1[1].Mean - 4 * dist1[1].StdDev;
                double start2 = dist2[1].Mean - 4 * dist2[1].StdDev;

                double stop1 = dist1[1].Mean + 4 * dist1[1].StdDev;
                double stop2 = dist2[1].Mean + 4 * dist2[1].StdDev;

                double start3 = (start1 < start2 ? start1 : start2);
                double stop3 = (stop1 > stop2 ? stop1 : stop2);

                start = start3 < start ? start3 : start;
                stop = stop3 > stop ? stop3 : stop;
            }

            double sum = 0.0;
            double sum1 = 0.0;
            for (double i = start; i < stop; i += 0.0001)
            {

                double d1=p1;
                double d2=p2;

                    d1 = d1 * dist1[0].Density(i);
                    d1 = d1 * dist1[1].Density(i);

                    d2 = d2 * dist2[0].Density(i);
                    d2 = d2 * dist2[1].Density(i);
                    if (d1 <= d2)
                    {
                        sum += 0.0001 * d1;
                    }
                    else
                    {
                        sum += 0.0001 * d2;
                    }
            }

            return (sum);
        }

        private static double CalculateIntegralUniform(IContinuousDistribution dist1, IContinuousDistribution dist2,double p1, double p2)
        {

            bool found = false;
            double zakresDist1 = dist1.Maximum - dist1.Minimum;
            double zakresDist2 = dist2.Maximum - dist2.Minimum;

            if (dist2.Maximum <= dist1.Maximum && dist1.Maximum < dist2.Maximum )
            {

            }

            double sum = 0.0;
            if (p1 > p2)
                return p2 * sum;
            else
                return p1 * sum;
        }

        private static double CalculateIntegral1(IContinuousDistribution dist1, IContinuousDistribution dist2, double commonPoint, double p1, double p2)
        {

            double sum = 0.0;
            double sum1 = 0.0;
            for (double i = dist1.Mean - (8 * dist1.StdDev); i < dist1.Mean + (8 * dist1.StdDev); i += 0.0001)
            {
                double d1 = p1*dist1.Density(i);
                double d2 = p2*dist2.Density(i);
                    if (d1 <= d2)
                    {
                        sum += 0.0001 * d1;
                    }
                    else
                    {
                        sum += 0.0001 * d2;
                    }
            }
            return sum;

        }

        #region IClassyfiAlgorithm Members


        #endregion

        public static double CalculateBayesRiskUniformDistribution(IContinuousDistribution generator1, IContinuousDistribution generator2, double P1, double P2)
        {
            double dens1 = generator1.Density(generator1.Mean);
            double dens2 = generator2.Density(generator2.Mean);

            if (dens1 > dens2)
            {
                double range = generator1.Maximum - generator2.Minimum;
                if (range > 0.0)
                {
                    return range * dens2  * 100;
                }

            }
            else if (dens2 > dens1)
            {
                double range = generator2.Maximum - generator1.Minimum;
                if (range > 0.0)
                {
                    return range * dens1 * 100;
                }
            }
            else
            {
                double range1 = generator2.Maximum - generator1.Minimum;
                double range2 = generator1.Maximum - generator2.Minimum;

                if (range1 > 0.0)
                {
                    return range1 * dens1*100;
                }

                if (range2 > 0.0)
                {
                    return range2 * dens1 * 100;
                }
            }

            return 0.0;
        }
    }
}
