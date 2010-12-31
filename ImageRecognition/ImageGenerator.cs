using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpCity.Tools.RandomNumberGenerators;
using System.Drawing;

namespace PatternRecognition
{
    public static  class ImageGenerator
    {
        private static Color _pixelColor = Color.Black;
        
        public static Bitmap GenerateImage(IRandomGenerator generator,int imageSize)
        {
            //Generates white gray black images
            Bitmap outImage = new Bitmap(imageSize,imageSize);
            
            for(int x=0;x<imageSize;x++)
            {
                for(int y=0;y<imageSize;y++ )
                {
                        int value = generator.Next();
                        outImage.SetPixel(x,y,Color.FromArgb(value,value,value));
                }
            }
            outImage.Save("test.bmp");
            return outImage;
        }


    }
}

