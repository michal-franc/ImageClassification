using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageRecognition
{
    public interface IImageRecognitionAlgorithm
    {
        ImageClass Classify();
    }
}
