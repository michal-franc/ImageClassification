using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternRecognition
{
    public class WektorCech
    {
        public List<double> wartosci { get; set; }


        public WektorCech(params double[] values)
        {
            wartosci = new List<double>();
            foreach (double d in values)
            {
                wartosci.Add(d);
            }
        }
    }
}
