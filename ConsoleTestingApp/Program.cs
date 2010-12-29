using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpCity.Tools.RandomNumberGenerators;
using System.Drawing;
using ImageRecognition;

namespace ConsoleTestingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 klasa Obraz pixele z zakresu 0-150
            //2 klasa Obraz pixele z zakresu 150-255
            List<Bitmap> FirstClass = new List<Bitmap>();
            FirstClass.Add(ImageRecognition.ImageGenerator.GenerateImage(new UniformRandomGenerator(0, 150), 10));
            FirstClass.Add(ImageRecognition.ImageGenerator.GenerateImage(new UniformRandomGenerator(0, 150), 10));
            FirstClass.Add(ImageRecognition.ImageGenerator.GenerateImage(new UniformRandomGenerator(0, 150), 10));
            FirstClass.Add(ImageRecognition.ImageGenerator.GenerateImage(new UniformRandomGenerator(0, 150), 10));
            FirstClass.Add(ImageRecognition.ImageGenerator.GenerateImage(new UniformRandomGenerator(0, 150), 10));
            FirstClass.Add(ImageRecognition.ImageGenerator.GenerateImage(new UniformRandomGenerator(0, 150), 10));

            List<Bitmap> SecondClass = new List<Bitmap>();
            SecondClass.Add(ImageRecognition.ImageGenerator.GenerateImage(new UniformRandomGenerator(150, 255), 10));
            SecondClass.Add(ImageRecognition.ImageGenerator.GenerateImage(new UniformRandomGenerator(150, 255), 10));
            SecondClass.Add(ImageRecognition.ImageGenerator.GenerateImage(new UniformRandomGenerator(150, 255), 10));
            SecondClass.Add(ImageRecognition.ImageGenerator.GenerateImage(new UniformRandomGenerator(150, 255), 10));
            SecondClass.Add(ImageRecognition.ImageGenerator.GenerateImage(new UniformRandomGenerator(150, 255), 10));
            SecondClass.Add(ImageRecognition.ImageGenerator.GenerateImage(new UniformRandomGenerator(150, 255), 10));


            Bitmap FirstClassTest = ImageGenerator.GenerateImage(new UniformRandomGenerator(0,150), 10);
            Bitmap SecondClassTest = ImageGenerator.GenerateImage(new UniformRandomGenerator(150, 255), 10);
            Bitmap RandomClassTest = ImageGenerator.GenerateImage(new UniformRandomGenerator(50, 200), 10);

            EuclideanDistance distance = new EuclideanDistance();

            double dist = double.MaxValue;
            string classS ="";

            foreach (Bitmap bmp in FirstClass)
            {
                double tmpDist = 0;
                tmpDist = distance.CalculateDistance(RandomClassTest, bmp);
                if (tmpDist < dist)
                {
                    classS = "First";
                    dist = tmpDist;
                }
            }

            foreach (Bitmap bmp in SecondClass)
            {
                double tmpDist = 0;
                tmpDist = distance.CalculateDistance(RandomClassTest, bmp);
                if (tmpDist < dist)
                {
                    classS = "Second";
                    dist = tmpDist;
                }
            }

            Console.WriteLine(classS);
            Console.ReadLine();
        
        }
    }
}
