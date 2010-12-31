using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using PatternRecognition;
using MathNet.Numerics.Distributions;

namespace ConsoleTestingApp
{
    class Program
    {

       public static ContinuousUniform uniformGenerator1;
       public static ContinuousUniform uniformGenerator2;
       public static ContinuousUniform uniformGeneratorObiektBadany;
       public static ContinuousUniform pGenerator = null;

       public static bool first = true;

        static void Main(string[] args)
        {
            //Normal normalGenerator = new Normal(2,0.2);
            //normalGenerator.Sample();

            NearestNeighbour algorithm = new NearestNeighbour(1, new EuclideanDistance());
            //NearestAverage algorithm = new NearestAverage(new EuclideanDistance());
            PatternClass obiektBadany= null;
            for(int k =1;k<25;k++)
            {
                int counter = 0;
                for(int i=0;i<1000;i++)
                {
                    if (algorithm.Classify(CreateWektoryUczaceUniform(0.1, 0.8, 0, 20, 21, 100, k, ref obiektBadany), obiektBadany.WektorCech.wartosci)==obiektBadany.NumerKlasy)
                        counter++;
                }
                
            Console.WriteLine(String.Format("Dla K = {0} , {1}",k,(1000-counter)*100/1000));
            }

           Console.ReadLine();
        }

        private static List<PatternClass> CreateWektoryUczaceUniform(double p1,double p2,int a1,int a2,int b1,int b2,int iloscWektorowUczacych,ref PatternClass obiektBadany)
        {
            if (first)
            {
                uniformGenerator1 = new ContinuousUniform(a1, a2);
                uniformGenerator2 = new ContinuousUniform(b1, b2);
                uniformGeneratorObiektBadany = new ContinuousUniform(a1, b2);
                pGenerator = new ContinuousUniform(0, 1);

                first = false;
            }

            double wartoscObiektuBadanego = uniformGeneratorObiektBadany.Sample();
            int klasaObiektuBadanego = 0;
            if (a1 <= wartoscObiektuBadanego && wartoscObiektuBadanego  < a2)
                klasaObiektuBadanego = 1;
            else if (b1 <= wartoscObiektuBadanego && wartoscObiektuBadanego < b2)
                klasaObiektuBadanego = 2;

            obiektBadany = new PatternClass(new WektorCech(wartoscObiektuBadanego), klasaObiektuBadanego);

            List<PatternClass> wyjsciowaLista = new List<PatternClass>();

            for (int i = 0; i < iloscWektorowUczacych; i++)
            {

                double p = pGenerator.Sample();
                int numerKlasy = 0;
                double wartosc = 0;
                if (p <= p1)
                {
                    numerKlasy = 1;
                    wartosc = uniformGenerator1.Sample();
                }
                else if (1-p2<p)
                {
                    numerKlasy = 2;
                    wartosc = uniformGenerator2.Sample();
                }

                wyjsciowaLista.Add(new PatternClass(new WektorCech(wartosc), numerKlasy));
            }

            return wyjsciowaLista;


        }
    }
}
