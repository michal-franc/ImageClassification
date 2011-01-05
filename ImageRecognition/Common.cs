using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatternRecognition;
using MathNet.Numerics.Distributions;

namespace ImageRecognition
{
     public static class Common
    {
         public static ContinuousUniform probabilityGenerator = new ContinuousUniform(0, 1);

         /// <summary>
         /// Creates 1 dimensional Teaching Vectors 
         /// </summary>
         /// <param name="p1"></param>
         /// <param name="p2"></param>
         /// <param name="generator1"></param>
         /// <param name="generator2"></param>
         /// <param name="nrOfTeachingVectors"></param>
         /// <returns></returns>
         public static List<PatternClass> CreateTeachingVectors(double p1, double p2, IContinuousDistribution generator1, IContinuousDistribution generator2, int nrOfTeachingVectors)
        {
             List<PatternClass> createdTeachingVectors = new List<PatternClass>();

            for (int i = 0; i < nrOfTeachingVectors; i++)
            {
                double value = 0;
                int classNumber = CreateClass(p1, p2);

                if (classNumber == 1)
                    value = generator1.Sample();
                else if (classNumber == 2)
                    value = generator2.Sample();

                createdTeachingVectors.Add(new PatternClass(new FeatureVector(value), classNumber));
            }

            return createdTeachingVectors;
        }

         public static List<PatternClass> Create2DimTeachingVectors(double p1, double p2, IContinuousDistribution generatorFirstFeature1, IContinuousDistribution generatorFirstFeature2, IContinuousDistribution generatorSecondFeature1, IContinuousDistribution generatorSecondFeature2, int nrOfTeachingVectors)
         {
             List<PatternClass> createdTeachingVectors = new List<PatternClass>();

             for (int i = 0; i < nrOfTeachingVectors; i++)
             {
                 double value = 0;
                 double value1 = 0;
                 int classNumber = CreateClass(p1, p2);

                 if (classNumber == 1)
                 {
                     value = generatorFirstFeature1.Sample();
                     value1 = generatorFirstFeature2.Sample();
                 }
                 else if (classNumber == 2)
                 {
                     value = generatorSecondFeature1.Sample();
                     value1 = generatorSecondFeature2.Sample();
                 }

                 createdTeachingVectors.Add(new PatternClass(new FeatureVector(value,value1), classNumber));
             }

             return createdTeachingVectors;
         }

         /// <summary>
         ///  Gives class number based on the prpability of a class
         /// </summary>
         /// <param name="propabilityOfClass1"></param>
         /// <param name="propabilityOfClass2"></param>
         /// <returns></returns>
        public static int CreateClass(double propabilityOfClass1, double propabilityOfClass2)
        {
            double p = probabilityGenerator.Sample();
            if (p <= propabilityOfClass1)
                return 1;
            else if (1 - propabilityOfClass2 < p)
                return 2;
            else
                return 0;
        }
        /// <summary>
        /// Creates the list of objects with specified class
        /// </summary>
        /// <param name="generator"></param>
        /// <param name="count"></param>
        /// <param name="classNumber"></param>
        /// <returns></returns>
        public static List<PatternClass> CreateSampleObject(IContinuousDistribution generator,int count,int classNumber)
        {
            List<PatternClass> sampleObjects = new List<PatternClass>();

            for (int i = 0; i < count; i++)
            {
                sampleObjects.Add(new PatternClass(new FeatureVector(generator.Sample()), classNumber));
            }
            return sampleObjects;
        }


    }
}
