using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PatternRecognition
{
    public interface IDistanceAlgorithm
    {
        double CalculateDistance(List<double> x1, List<double> x2);
    }
}
