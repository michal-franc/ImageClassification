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

         public static List<PatternClass> CreateWektoryUczaceUniform(double p1, double p2, IContinuousDistribution generator1, IContinuousDistribution generator2, int iloscWektorowUczacych)
        {
            List<PatternClass> wyjsciowaLista = new List<PatternClass>();

            for (int i = 0; i < iloscWektorowUczacych; i++)
            {
                double wartosc = 0;
                int numerKlasy = CreateClass(p1, p2);

                if (numerKlasy == 1)
                    wartosc = generator1.Sample();
                else if (numerKlasy == 2)
                    wartosc = generator2.Sample();

                wyjsciowaLista.Add(new PatternClass(new WektorCech(wartosc), numerKlasy));
            }

            return wyjsciowaLista;
        }

        public static int CreateClass(double propabilityOfClass1, double propabilityOfClass2)
        {
            double p = probabilityGenerator.Sample();
            if (p <= propabilityOfClass1)
            {
                return 1;
            }
            else if (1 - propabilityOfClass2 < p)
            {
                return 2;
            }
            else
                return 0;
        }

        public static List<PatternClass> CreateObject(IContinuousDistribution generator,int count,int classNumber)
        {
            List<PatternClass> returnObjects = new List<PatternClass>();

            for (int i = 0; i < count; i++)
            {
                returnObjects.Add(new PatternClass(new WektorCech(generator.Sample()), classNumber));
            }

            return returnObjects;
        }


    }
}
