using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageClassyfication.Image
{
    interface IImageCorrelation
    {
        Bitmap GetCorrelatedImage(Bitmap bmp1, Bitmap bmp2);
    }
}
