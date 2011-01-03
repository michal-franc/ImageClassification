using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternRecognition
{
    public class NearestAverage : IClassyfiAlgorithm
    {
        private IDistanceAlgorithm _dist;



        public NearestAverage(IDistanceAlgorithm dist)
        {
            _dist = dist;
        }

        #region IClassyfiAlgorithm Members

        public int Classify(List<PatternClass> wektoryUczace, List<double> klasyfikowanyObiekt)
        {

            //1. obliczyc wartosci modalne (srednie)
            Dictionary<int, double> wartosciModalne = new Dictionary<int, double>();
            Dictionary<int, double> sumy = new Dictionary<int,double>();

            foreach (PatternClass obj in wektoryUczace)
            {
                if (!wartosciModalne.ContainsKey(obj.NumerKlasy))
                {
                    wartosciModalne.Add(obj.NumerKlasy, 0);
                    sumy.Add(obj.NumerKlasy,0);
                }

                wartosciModalne[obj.NumerKlasy]++;
                sumy[obj.NumerKlasy] += obj.WektorCech.wartosci[0];
            }

            for (int i = 1; i <= wartosciModalne.Count+1;i++ )
            {
                if (wartosciModalne.ContainsKey(i))
                {
                    wartosciModalne[i] = sumy[i] / wartosciModalne[i];
                }
            }

            int numerKlasy = 0;
            double min = double.MaxValue;
            for (int i = 1; i <= wartosciModalne.Count+1;i++ )
            {
                if (wartosciModalne.ContainsKey(i))
                {
                    if (_dist.CalculateDistance(new List<double>() { wartosciModalne[i] }, klasyfikowanyObiekt) < min)
                    {
                        numerKlasy = i;
                        min = _dist.CalculateDistance(new List<double>() { wartosciModalne[i] }, klasyfikowanyObiekt);
                    }
                }
            }
            return numerKlasy;
        }

        #endregion
    }
}
