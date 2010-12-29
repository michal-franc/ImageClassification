using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageRecognition
{
    public class NearestNeighbour : IImageRecognitionAlgorithm
    {
        private int _K = 3;

        public NearestNeighbour(int K)
        {
            _K = K;
        }
        #region IImageRecognitionAlgorithm Members

        public ImageClass Classify()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
