using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternRecognition
{
    public class PatternClass
    {
        public WektorCech WektorCech {get;set;}
        public int NumerKlasy { get; set; }
        public double Distance { get; set; }

        public PatternClass(WektorCech cechy, int klasa)
        {
            WektorCech = cechy;
            NumerKlasy = klasa;
        }

    }
}
