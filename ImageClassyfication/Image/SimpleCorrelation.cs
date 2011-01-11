using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using AForge.Imaging.Formats;
using AForge.Imaging.Filters;

namespace ImageClassyfication.Image
{
    public class SimpleCorrelation 
    {
        #region IImageCorrelation Members

        public double CalculateCorrCoefficent(Bitmap bmp1, Bitmap bmp2)
        {
            double bmp1Mean = CalculateBitmapMean(bmp1);
            double bmp2Mean = CalculateBitmapMean(bmp2);

            double value1= 0.0;
            double value2 = 0.0;
            double value3 = 0.0;
            double corrCoefficent = 0.0;

            for (int x = 0; x < bmp1.Width; x++)
            {
                for (int y = 0; y < bmp1.Height; y++)
                {
                    value1 += (bmp1.GetPixel(x, y).R - bmp1Mean) * (bmp2.GetPixel(x, y).R - bmp2Mean);
                    value2 += Math.Pow((bmp1.GetPixel(x, y).R - bmp1Mean), 2);
                    value3 += Math.Pow((bmp2.GetPixel(x, y).R - bmp1Mean), 2);
                }
            }

            corrCoefficent = value1/(Math.Sqrt(value2)*Math.Sqrt(value3));

            return corrCoefficent;         
        }

        private double CalculateBitmapMean(Bitmap bmp)
        {
            double mean=0.0;
            double counter = 0;
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    counter++;
                    mean += bmp.GetPixel(x, y).R;
                }
            }
            return mean / counter;
        }


        //    Create pixel data to put in image, use 2 since it is 16bpp
        //    Random r = new Random();
        //    int width = 800;
        //    int height = 600;
        //    byte[] pixelValues = new byte[width * height * 2];
        //    for (int i = 0; i < pixelValues.Length; ++i)
        //    {
        //        //Just create random pixel values, don't care about
        //        //being greyscale values for example
        //        pixelValues = (byte)r.Next(0, 256);
        //    }

        //    CreateBitmapFromBytes(pixelValues, width, height);
        //}

        //private static void CreateBitmapFromBytes(byte[] pixelValues, int width, int height)
        //{
        //    //Create an image that will hold the image data
        //    Bitmap pic = new Bitmap(width, height, PixelFormat.Format16bppGrayScale);

        //    //Get a reference to the images pixel data
        //    Rectangle dimension = new Rectangle(0, 0, pic.Width, pic.Height);
        //    BitmapData picData = pic.LockBits(dimension, ImageLockMode.ReadWrite, pic.PixelFormat);
        //    IntPtr pixelStartAddress = picData.Scan0;

        //    //Copy the pixel data into the bitmap structure
        //    System.Runtime.InteropServices.Marshal.Copy(pixelValues, 0, pixelStartAddress, pixelValues.Length);

        //    pic.UnlockBits(picData);
        //    pic.Save(@"c:\users\mark\mypic1.bmp", ImageFormat.Bmp);
        //}
        #endregion
    }
}
