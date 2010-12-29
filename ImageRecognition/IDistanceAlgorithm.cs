using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageRecognition
{
    interface IDistanceAlgorithm
    {
        double CalculateDistance(Bitmap bmp1,Bitmap bmp2);
    }
}
