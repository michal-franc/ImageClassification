using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternRecognition
{
    public class NearestNeighbour : IClassyfiAlgorithm
    {
        private int _alpha = 2;
        IDistanceAlgorithm _dist;

        public NearestNeighbour(int alpha, IDistanceAlgorithm dist)
        {
            _alpha = alpha;
            _dist = dist;
        }
        #region IImageRecognitionAlgorithm Members

        public int Classify(List<PatternClass> wektoryUczace, List<double> klasyfikowanyObiekt)
        {
            double min = double.MaxValue;
            foreach (PatternClass pClass in wektoryUczace)
            {
                if (_dist.CalculateDistance(pClass.WektorCech.wartosci, klasyfikowanyObiekt) < min)
                {
                    pClass.Distance = _dist.CalculateDistance(pClass.WektorCech.wartosci, klasyfikowanyObiekt);
                }
            }

            var posortowaneOdleglosci = from w in wektoryUczace orderby w.Distance ascending select w;

            Dictionary<int , int> licznikKlas = new Dictionary<int,int>();

            int i = 0;
            foreach(PatternClass p in posortowaneOdleglosci )
            {
                if(!licznikKlas.ContainsKey(p.NumerKlasy))
                {
                    licznikKlas.Add(p.NumerKlasy,0);
                }

                licznikKlas[p.NumerKlasy]++;
                i++;
                if (i >= _alpha)
                {
                    break;
                }
            }

            return (from w in licznikKlas orderby w.Value descending select w.Key).First();
        }

        #endregion
    }
}
