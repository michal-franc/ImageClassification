using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using AForge.Math;
using AForge.Imaging.Filters;
using AForge.Imaging;
using AForge;

namespace ImageClassyfication.Image
{
    public static class ImageFeatureExtractor
    {
        //1. bright pixel / dark pixel
        //2.lowest gray level
        //3.highest gray level
        //4.number of peaks in the x direction. 
        //5.number of peaks in the y direction. 
        public static double[] ExtractFeatures(Bitmap bmp,int i)
        {

            //Apply GrayScale
            GrayscaleBT709 greyScaleFilter = new GrayscaleBT709();
            Bitmap newBmp = greyScaleFilter.Apply((Bitmap)bmp.Clone());

            //Count Blobs
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.BackgroundThreshold = Color.FromArgb(255, 150, 150, 150);
            blobCounter.ProcessImage(newBmp);
            int blobs = (blobCounter.ObjectsCount - 1) * 30;

            //Count Corner
            SusanCornersDetector scd = new SusanCornersDetector();
            scd.DifferenceThreshold = 70;
            scd.GeometricalThreshold = 8;
            int corners = scd.ProcessImage((Bitmap)newBmp.Clone()).Count();

            //Apply Edge Filter
            CannyEdgeDetector filter = new CannyEdgeDetector();
            //newBmp = filter.Apply(newBmp);
            Histogram his = new HorizontalIntensityStatistics(newBmp).Gray;
            Histogram vis = new VerticalIntensityStatistics(newBmp).Gray;

            HoughLineTransformation lineTransform = new HoughLineTransformation();
            // apply Hough line transofrm
            lineTransform.ProcessImage(filter.Apply(newBmp));
            Bitmap houghLineImage = lineTransform.ToBitmap();
            // get lines using relative intensity
            HoughLine[] lines = lineTransform.GetLinesByRelativeIntensity(1);
            int linesCount = lines.Count() * 30;


            double[] features = new double[13] { blobs, corners, his.Max, his.Min, his.Mean, his.Median, his.StdDev,
                vis.Max, vis.Min, vis.Mean, vis.Median, vis.StdDev,linesCount};

            //double[] features = new double[3] { blobs, corners,lines};



            newBmp.Save(String.Format("test{0}.bmp",i));
            return features;
        }
    }
}
