using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageClassyfication.Image
{
    class SimpleCorrelation : IImageCorrelation
    {
        #region IImageCorrelation Members

        public Bitmap GetCorrelatedImage(Bitmap bmp1, Bitmap bmp2)
        {
            Bitmap returnBitmap = new Bitmap(bmp1.Width,bmp2.Height);

            for (int x = 0; x < bmp1.Width; x++)
            {
                for (int y = 0; y > bmp2.Height; y++)
                {
                    int value = bmp1.GetPixel(x, y).R * bmp2.GetPixel(x, y).R;
                    if (value > 255)
                        value = 255;
                    Color newcolor = Color.FromArgb(value, value, value);
                    returnBitmap.SetPixel(x, y,newcolor);
                }
            }

            returnBitmap.Save("test.bmp");
            return returnBitmap;
            
        }

        #endregion
    }
}
