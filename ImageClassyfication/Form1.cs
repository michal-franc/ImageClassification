using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ImageRecognition;
using MathNet.Numerics.Distributions;
using System.Windows.Forms.DataVisualization.Charting;
using PatternRecognition;
using ImageRecognition.ClassyfiAlgorithm;
using ImageClassyfication.Image;

namespace ImageClassyfication
{

    public partial class Form1 : Form
    {
        #region Properties with parsed data
        public double A1
        {
            get
            {
                return double.Parse(this.textBoxA1.Text);
            }
        }

        public double A2
        {
            get
            {
                return double.Parse(this.textBoxA2.Text);
            }
        }

        public double B1
        {
            get
            {
                return double.Parse(this.textBoxB1.Text);
            }
        }

        public double B2
        {
            get
            {
                return double.Parse(this.textBoxB2.Text);
            }
        }

        public double P1
        {
            get
            {
                return double.Parse(this.textBoxP1.Text);
            }
        }

        public double P2
        {
            get
            {
                return double.Parse(this.textBoxP2.Text);
            }
        }

        public double FirstFeatureA1
        {
            get
            {
                return double.Parse(textBoxFirstFeatureA1.Text);
            }
        }

        public double FirstFeatureA2
        {
            get
            {
                return double.Parse(textBoxFirstFeatureA2.Text);
            }
        }

        public double FirstFeatureB1
        {
            get
            {
                return double.Parse(textBoxFirstFeatureB1.Text);
            }
        }

        public double FirstFeatureB2
        {
            get
            {
                return double.Parse(textBoxFirstFeatureB2.Text);
            }
        }

        public double SecondFeatureA1
        {
            get
            {
                return double.Parse(textBoxSecondFeatureA1.Text);
            }
        }

        public double SecondFeatureA2
        {
            get
            {
                return double.Parse(textBoxSecondFeatureA2.Text);
            }
        }

        public double SecondFeatureB1
        {
            get
            {
                return double.Parse(textBoxSecondFeatureB1.Text);
            }
        }

        public double SecondFeatureB2
        {
            get
            {
                return double.Parse(textBoxSecondFeatureB2.Text);
            }
        }

        public int Alpha
        {
            get
            {
                return int.Parse(textBoxAlpha.Text);
            }
        }

        public int IloscWektorow
        {
            get
            {
                return int.Parse(this.textBoxIloscWekt.Text);
            }
        }

        public int IloscProb
        {
            get
            {
                return int.Parse(this.textBoxIloscProb.Text);
            }
        }

        public int IloscTestowychProbek
        {
            get
            {
                return int.Parse(textBoxIloscTestowychProbek.Text);
            }
        }

        public GeneratorType SelectedGenerator
        {
            get
            {
                if (comboBoxGeneratorType.SelectedItem.ToString().Contains("Normal"))
                    return GeneratorType.Normal;
                else if (comboBoxGeneratorType.SelectedItem.ToString().Contains("Uniform"))
                    return GeneratorType.Uniform;
                else
                    return GeneratorType.None;
            }
        }
        
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCorrelation_Click(object sender, EventArgs e)
        {
            SimpleCorrelation correlation = new SimpleCorrelation();

            Bitmap bmp0 = new Bitmap(Bitmap.FromFile("0.bmp"));
            Bitmap bmp1 = new Bitmap(Bitmap.FromFile("1.bmp"));
            Bitmap bmp2 = new Bitmap(Bitmap.FromFile("2.bmp"));
            Bitmap bmp3 = new Bitmap(Bitmap.FromFile("3.bmp"));
            Bitmap bmp4 = new Bitmap(Bitmap.FromFile("4.bmp"));
            Bitmap bmp5 = new Bitmap(Bitmap.FromFile("5.bmp"));
            Bitmap bmp6 = new Bitmap(Bitmap.FromFile("6.bmp"));
            Bitmap bmp7 = new Bitmap(Bitmap.FromFile("7.bmp"));
            Bitmap bmp8 = new Bitmap(Bitmap.FromFile("8.bmp"));
            Bitmap bmp9 = new Bitmap(Bitmap.FromFile("9.bmp"));

            List<PatternClass> teachingVector = new List<PatternClass>();
            for (int i = 0; i < 5; i++)
            {
                teachingVector.Add(new PatternClass(new FeatureVector(ImageFeatureExtractor.ExtractFeatures(CropImage(bmp0, i),0)), 0));
                teachingVector.Add(new PatternClass(new FeatureVector(ImageFeatureExtractor.ExtractFeatures(CropImage(bmp1, i),1)), 1));
                teachingVector.Add(new PatternClass(new FeatureVector(ImageFeatureExtractor.ExtractFeatures(CropImage(bmp2, i),2)), 2));
                teachingVector.Add(new PatternClass(new FeatureVector(ImageFeatureExtractor.ExtractFeatures(CropImage(bmp3, i),3)), 3));
                teachingVector.Add(new PatternClass(new FeatureVector(ImageFeatureExtractor.ExtractFeatures(CropImage(bmp4, i),4)), 4));
                teachingVector.Add(new PatternClass(new FeatureVector(ImageFeatureExtractor.ExtractFeatures(CropImage(bmp5, i),5)), 5));
                teachingVector.Add(new PatternClass(new FeatureVector(ImageFeatureExtractor.ExtractFeatures(CropImage(bmp6, i),6)), 6));
                teachingVector.Add(new PatternClass(new FeatureVector(ImageFeatureExtractor.ExtractFeatures(CropImage(bmp7, i),7)), 7));
                teachingVector.Add(new PatternClass(new FeatureVector(ImageFeatureExtractor.ExtractFeatures(CropImage(bmp8, i),8)), 8));
                teachingVector.Add(new PatternClass(new FeatureVector(ImageFeatureExtractor.ExtractFeatures(CropImage(bmp9, i),9)), 9));
            }

            List<PatternClass> sampleObjects = new List<PatternClass>();
            sampleObjects.Add(new PatternClass(new FeatureVector(ImageFeatureExtractor.ExtractFeatures((Bitmap)pictureBox1.Image, 10)), 0));

            NearestAverage averageAlg = new NearestAverage(new EuclideanDistance());
            int classyfiAvg = averageAlg.Classify(teachingVector, sampleObjects[0].FeatureVector.Values);

            NearestNeighbour neighbourAlb = new NearestNeighbour(3, new EuclideanDistance());
            int classyfiNeighbour = neighbourAlb.Classify(teachingVector, sampleObjects[0].FeatureVector.Values);

            pictureBox1.Image = null;
            pictureBox1.Invalidate();

            MessageBox.Show(classyfiNeighbour.ToString());
        }

        private static Bitmap CropImage(Bitmap bmp,int imageNumber )
        {
            Rectangle cropArea = new Rectangle(0, imageNumber * 64, 64, 64);
            Bitmap bmpCrop = bmp.Clone(cropArea,bmp.PixelFormat);
            return bmpCrop;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            #region Prepare Generators
            chartDistribution.Series.Clear();
            chartDistribution.ResetAutoValues();

            IContinuousDistribution generator1 = null;
            IContinuousDistribution generator2 = null;

            if (SelectedGenerator == GeneratorType.Normal)
            {
                generator1 = new Normal(A1, A2);
                generator2 = new Normal(B1, B2);
            }
            else if (SelectedGenerator == GeneratorType.Uniform)
            {
                generator1 = new ContinuousUniform(A1, A2);
                generator2 = new ContinuousUniform(B1, B2);
            }

            generator1.RandomSource = new Random(DateTime.Now.Millisecond);
            generator2.RandomSource = new Random(DateTime.Now.Millisecond + 10); 
            #endregion

            chartDistribution.Series.Add(CreateDistributionSerie(generator1));
            chartDistribution.Series.Add(CreateDistributionSerie(generator2));
            chartDistribution.Update();                


            double avgAlgorithmCounter = 0.0;
            double nearestAlgorithmCounter = 0.0;
            double naiveBayesCounter = 0.0;

            for (int i = 0; i < IloscProb; i++)
            {                   
                List<PatternClass> wektoryUczace = Common.CreateTeachingVectors(P1, P2, generator1, generator2, IloscWektorow);
                List<PatternClass> obiektyTestowe = Common.CreateTeachingVectors(P1, P2, generator1,generator2, IloscTestowychProbek);

                //var Count  = (from  mega in obiektyTestowe where mega.ClassNumber ==1 select mega).Count();
                //var Count2 = (from mega in obiektyTestowe where mega.ClassNumber == 2 select mega).Count();


                avgAlgorithmCounter += RunClassyfication(obiektyTestowe, new NearestAverage(new EuclideanDistance()), wektoryUczace);
                nearestAlgorithmCounter += RunClassyfication(obiektyTestowe, new NearestNeighbour(Alpha, new EuclideanDistance()), wektoryUczace);
                naiveBayesCounter += RunClassyfication(obiektyTestowe, new NaiveBayes(new List<IContinuousDistribution>(){generator1},new List<IContinuousDistribution>(){generator2},P1,P2), wektoryUczace);
            }

            double bayesRisk = NaiveBayes.CalculateBayesRisk(new List<IContinuousDistribution>(){generator1}, new List<IContinuousDistribution>(){generator2}, P1, P2);

            textBoxData.Text = String.Format("Nearest : {0} \n Average {1} \n Bayes {2} \n Baies Risk {3}",
                CalculateErrorPercent(nearestAlgorithmCounter, IloscProb, IloscTestowychProbek),
                CalculateErrorPercent(avgAlgorithmCounter, IloscProb, IloscTestowychProbek),
                CalculateErrorPercent(naiveBayesCounter,IloscProb, IloscTestowychProbek),
                bayesRisk);
        }

        private double CalculateErrorPercent(double counter,double nrOfTries,double nrOfSampleObjects)
        {
            return counter / (nrOfTries * nrOfSampleObjects);
        }

        private double RunClassyfication(List<PatternClass> obiektyTestowe, IClassyfiAlgorithm algorithm, List<PatternClass> wektoryUczace)
        {
            double counter = 0.0;

                foreach (PatternClass pClass in obiektyTestowe)
                {
                    if (algorithm.Classify(wektoryUczace, pClass.FeatureVector.Values) != pClass.ClassNumber)
                    {
                        counter++;
                    }
                }

            return counter;
        }

        private void btnCalculate2Dim_Click(object sender, EventArgs e)
        {
            #region Prepare Generators
            chartFirstFeatureDistribution.Series.Clear();
            chartFirstFeatureDistribution.ResetAutoValues();

            chartSecondFeatureDistribution.Series.Clear();
            chartSecondFeatureDistribution.ResetAutoValues();

            chartXYDistribution.Series.Clear();
            chartXYDistribution.ResetAutoValues();


            IContinuousDistribution generatorFirstFeature1 = null;
            IContinuousDistribution generatorFirstFeature2 = null;

            IContinuousDistribution generatorSecondFeature1 = null;
            IContinuousDistribution generatorSecondFeature2 = null;

            if (SelectedGenerator == GeneratorType.Normal)
            {
                generatorFirstFeature1 = new Normal(FirstFeatureA1, FirstFeatureA2);
                generatorFirstFeature2 = new Normal(FirstFeatureB1, FirstFeatureB2);
                generatorSecondFeature1 = new Normal(FirstFeatureA1, FirstFeatureA2);
                generatorSecondFeature2 = new Normal(FirstFeatureB1, FirstFeatureB2);
            }
            else if (SelectedGenerator == GeneratorType.Uniform)
            {
                generatorFirstFeature1 = new ContinuousUniform(FirstFeatureA1, FirstFeatureA2);
                generatorFirstFeature2 = new ContinuousUniform(FirstFeatureB1, FirstFeatureB2);
                generatorSecondFeature1 = new ContinuousUniform(FirstFeatureA1, FirstFeatureA2);
                generatorSecondFeature2 = new ContinuousUniform(FirstFeatureB1, FirstFeatureB2);
            }

            generatorFirstFeature1.RandomSource = new Random(DateTime.Now.Millisecond);
            generatorFirstFeature2.RandomSource = new Random(DateTime.Now.Millisecond + 10);
            generatorSecondFeature1.RandomSource = new Random(DateTime.Now.Millisecond + 20);
            generatorSecondFeature2.RandomSource = new Random(DateTime.Now.Millisecond + 30); 
            #endregion

            chartFirstFeatureDistribution.Series.Add(CreateDistributionSerie(generatorFirstFeature1));
            chartFirstFeatureDistribution.Series.Add(CreateDistributionSerie(generatorFirstFeature2));
            chartSecondFeatureDistribution.Series.Add(CreateDistributionSerie(generatorSecondFeature1));
            chartSecondFeatureDistribution.Series.Add(CreateDistributionSerie(generatorSecondFeature2));


            //Classyfi objects

            double naiveBayesCounter = 0;
            double averageCounter = 0;
            double nearestCounter = 0;
            List<PatternClass> teachingVectors = null;
            List<PatternClass> sampleObjects = null;

            for (int i = 0; i < IloscProb; i++)
            {

                teachingVectors = Common.Create2DimTeachingVectors(P1, P2, generatorFirstFeature1, generatorFirstFeature2, generatorSecondFeature1, generatorSecondFeature2, IloscWektorow);
                sampleObjects = Common.Create2DimTeachingVectors(P1, P2, generatorFirstFeature1, generatorFirstFeature2, generatorSecondFeature1, generatorSecondFeature2, IloscTestowychProbek);
                averageCounter += RunClassyfication(sampleObjects, new NearestAverage(new EuclideanDistance()), teachingVectors);
                naiveBayesCounter += RunClassyfication(sampleObjects, new NaiveBayes(new List<IContinuousDistribution>(){generatorFirstFeature1, generatorSecondFeature1},new List<IContinuousDistribution>(){generatorFirstFeature2,generatorSecondFeature2}, P1, P2), teachingVectors);
                nearestCounter += RunClassyfication(sampleObjects, new NearestNeighbour(Alpha, new EuclideanDistance()), teachingVectors);
            }

            double bayesRisk1 = NaiveBayes.CalculateBayesRisk(new List<IContinuousDistribution>(){generatorFirstFeature1,generatorSecondFeature1}, new List<IContinuousDistribution>(){generatorFirstFeature2,generatorSecondFeature2}, P1, P2);



            textBoxData.Text = String.Format("Neares : {0} \n Average {1} \n Bayes {2} \n Bayes Risk {3} ", CalculateErrorPercent(nearestCounter, IloscProb, IloscTestowychProbek), CalculateErrorPercent(averageCounter, IloscProb, IloscTestowychProbek), CalculateErrorPercent(naiveBayesCounter, IloscProb, IloscTestowychProbek), (bayesRisk1));


            foreach (Series ser in CreateXYSeries(teachingVectors))
            {
                chartXYDistribution.Series.Add(ser);
            }

            //foreach (Series ser in CreateXYSeries(sampleObjects))
            //{
            //    chartXYDistribution.Series.Add(ser);
            //}
            chartXYDistribution.Update();


            //Put those objects on XY chart green - good classyfication , red - bad classyfication
            //Create statstics
        }


        private Pen myPen = new Pen(Color.Black, 3);
        private Point? _Previous = null;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _Previous = e.Location;
            pictureBox1_MouseMove(sender, e);
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_Previous != null)
            {
                if (pictureBox1.Image == null)
                {
                    Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.White);
                    }
                    pictureBox1.Image = bmp;
                }
                using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                {
                    
                    g.DrawLine(myPen, _Previous.Value, e.Location);
                }
                pictureBox1.Invalidate();
                _Previous = e.Location;
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _Previous = null;
        }

       #region Chart Helper Methods
        private List<Series> CreateXYSeries(List<PatternClass> objects)
        {
            Series serie1Class = new Series();
            serie1Class.ChartType = SeriesChartType.Point;
            serie1Class.MarkerSize = 5;

            Series serie2Class = new Series();
            serie2Class.ChartType = SeriesChartType.Point;
            serie2Class.MarkerSize = 5;

            foreach (PatternClass obj in objects)
            {
                if (obj.ClassNumber == 1)
                {
                    serie1Class.Points.Add(new DataPoint(obj.FeatureVector.Values[0], obj.FeatureVector.Values[1]));
                }
                else
                {
                    serie2Class.Points.Add(new DataPoint(obj.FeatureVector.Values[0], obj.FeatureVector.Values[1]));
                }
            }

            return new List<Series>() { serie1Class, serie2Class };

        }


        private Series CreateDistributionSerie(IContinuousDistribution distributionn)
        {
            Series createdSerie = new Series();
            createdSerie.ChartType = SeriesChartType.SplineArea;

            for (double i = distributionn.Mean - (8 * distributionn.StdDev); i < distributionn.Mean + (8 * distributionn.StdDev); i += 0.5)
            {
                if (distributionn is ContinuousUniform)
                {
                    createdSerie.Points.Add(new DataPoint((int)i, distributionn.Density(i)));
                }
                else
                {
                    createdSerie.Points.Add(new DataPoint(i, distributionn.Density(i)));

                }
            }

            return createdSerie;
        } 
        #endregion

        private void btnCreateStats_Click(object sender, EventArgs e)
        {
            //1. Pobieram p1 p2
            //2. Pobieram rodzaj generatora
            //3. Pobieram przestrzen

            #region Prepare Generators
            chartStats.Series.Clear();
            chartStats.ResetAutoValues();
            chartDistribution.Series.Clear();
            chartDistribution.ResetAutoValues();

            IContinuousDistribution generator1 = null;
            IContinuousDistribution generator2 = null;

            if (SelectedGenerator == GeneratorType.Normal)
            {
                generator1 = new Normal(A1, A2);
                generator2 = new Normal(B1, B2);
            }
            else if (SelectedGenerator == GeneratorType.Uniform)
            {
                generator1 = new ContinuousUniform(A1, A2);
                generator2 = new ContinuousUniform(B1, B2);
            }

            generator1.RandomSource = new Random(DateTime.Now.Millisecond);
            generator2.RandomSource = new Random(DateTime.Now.Millisecond + 10);
            #endregion

            Series NN1 = new Series();
            NN1.ChartType =  SeriesChartType.Line;
            NN1.MarkerStyle = MarkerStyle.Circle;
            NN1.MarkerSize = 5;
            NN1.Name = "NN - 1";
            Series NN3 = new Series();
            NN3.ChartType =  SeriesChartType.Line;
            NN3.MarkerStyle = MarkerStyle.Diamond;
            NN3.MarkerSize = 5;
            NN3.Name = "NN - 3";
            Series NN5 = new Series();
            NN5.ChartType =  SeriesChartType.Line;
            NN5.MarkerStyle = MarkerStyle.Cross;
            NN5.MarkerSize = 5;
            NN5.Name = "NN - 5";
            Series NM = new Series();
            NM.ChartType =  SeriesChartType.Line;
            NM.MarkerStyle = MarkerStyle.Square;
            NM.MarkerSize = 5;
            NM.Name = "NM";
            Series Bayes = new Series();
            Bayes.ChartType =  SeriesChartType.Line;
            Bayes.MarkerStyle = MarkerStyle.Triangle;
            Bayes.MarkerSize = 5;
            Bayes.Name = "Bayes";


            for (int k = 5; k <= 100; k +=5)
            {
                double avgAlgorithmCounter = 0.0;
                double nearestAlgorithm1Counter = 0.0;
                double nearestAlgorithm3Counter = 0.0;
                double nearestAlgorithm5Counter = 0.0;
                double naiveBayesCounter = 0.0;

                for (int i = 0; i < 100; i++)
                {
                    //NN -1
                    //NN -3
                    //NN -5
                    //NM

                    List<PatternClass> wektoryUczace = Common.CreateTeachingVectors(P1, P2, generator1, generator2, k);
                    List<PatternClass> obiektyTestowe = Common.CreateTeachingVectors(P1, P2, generator1, generator2, 100);

                    avgAlgorithmCounter += RunClassyfication(obiektyTestowe, new NearestAverage(new EuclideanDistance()), wektoryUczace);
                    nearestAlgorithm1Counter += RunClassyfication(obiektyTestowe, new NearestNeighbour(1, new EuclideanDistance()), wektoryUczace);
                    nearestAlgorithm3Counter += RunClassyfication(obiektyTestowe, new NearestNeighbour(3, new EuclideanDistance()), wektoryUczace);
                    nearestAlgorithm5Counter += RunClassyfication(obiektyTestowe, new NearestNeighbour(5, new EuclideanDistance()), wektoryUczace);
                    naiveBayesCounter += RunClassyfication(obiektyTestowe, new NaiveBayes(new List<IContinuousDistribution>() { generator1 }, new List<IContinuousDistribution>() { generator2 }, P1, P2), wektoryUczace);
                }

                
                    NN1.Points.Add(new DataPoint(k,CalculateErrorPercent(nearestAlgorithm1Counter,100,100)));
                    NN3.Points.Add(new DataPoint(k,CalculateErrorPercent(nearestAlgorithm3Counter,100,100)));
                    NN5.Points.Add(new DataPoint(k,CalculateErrorPercent(nearestAlgorithm5Counter,100,100)));
                    NM.Points.Add(new DataPoint(k,CalculateErrorPercent(avgAlgorithmCounter,100,100)));
                    Bayes.Points.Add(new DataPoint(k,CalculateErrorPercent(naiveBayesCounter,100,100)));
            }

            if (generator1 is ContinuousUniform)
            {
                chartStats.ChartAreas[0].AxisX.Title = String.Format("Ilość wektorów uczących \n  f1(x) = U({0},{1}) , f2(x) = U({2},{3})", generator1.Minimum, generator1.Maximum, generator2.Minimum, generator2.Maximum);
                chartDistribution.ChartAreas[0].AxisX.Title = String.Format("Rozkład \n f1(x) = U({0},{1}) , f2(x) = U({2},{3})", generator1.Minimum, generator1.Maximum, generator2.Minimum, generator2.Maximum);
            }
            else
            {
                chartStats.ChartAreas[0].AxisX.Title = String.Format("Ilość wektorów uczących \n  f1(x) = U({0},{1}) , f2(x) = U({2},{3})", generator1.Minimum, generator1.Maximum, generator2.Minimum, generator2.Maximum);
                chartDistribution.ChartAreas[0].AxisX.Title = String.Format("Rozkład \n f1(x) = N({0},{1}) , f2(x) = N({2},{3})", generator1.Mean, generator1.StdDev, generator2.Mean, generator1.StdDev);
            }
            chartStats.ChartAreas[0].AxisY.Title = String.Format("Częstość błędnej klasyfikacji");
            chartDistribution.ChartAreas[0].AxisY.Title = "Gęstość prawdopodobieństwa";

            chartDistribution.Series.Add(CreateDistributionSerie(generator1));
            chartDistribution.Series.Add(CreateDistributionSerie(generator2));
            chartDistribution.Update();                

            chartStats.Series.Add(NN1);
            chartStats.Series.Add(NN3);
            chartStats.Series.Add(NN5);
            chartStats.Series.Add(NM);
            chartStats.Series.Add(Bayes);
            chartStats.Update();
        }
                                
        private void chartStats_Click(object sender, EventArgs e)
        {

        }

        private void btnCreate2DimStats_Click(object sender, EventArgs e)
        {
            #region Prepare Generators
            chart2DimStats.Series.Clear();
            chart2DimStats.ResetAutoValues();
            chartXYDistribution.Series.Clear();
            chartXYDistribution.ResetAutoValues();

            IContinuousDistribution generatorFirstFeature1 = null;
            IContinuousDistribution generatorFirstFeature2 = null;

            IContinuousDistribution generatorSecondFeature1 = null;
            IContinuousDistribution generatorSecondFeature2 = null;

            if (SelectedGenerator == GeneratorType.Normal)
            {
                generatorFirstFeature1 = new Normal(FirstFeatureA1, FirstFeatureA2);
                generatorFirstFeature2 = new Normal(FirstFeatureB1, FirstFeatureB2);
                generatorSecondFeature1 = new Normal(FirstFeatureA1, FirstFeatureA2);
                generatorSecondFeature2 = new Normal(FirstFeatureB1, FirstFeatureB2);
            }
            else if (SelectedGenerator == GeneratorType.Uniform)
            {
                generatorFirstFeature1 = new ContinuousUniform(FirstFeatureA1, FirstFeatureA2);
                generatorFirstFeature2 = new ContinuousUniform(FirstFeatureB1, FirstFeatureB2);
                generatorSecondFeature1 = new ContinuousUniform(FirstFeatureA1, FirstFeatureA2);
                generatorSecondFeature2 = new ContinuousUniform(FirstFeatureB1, FirstFeatureB2);
            }

            generatorFirstFeature1.RandomSource = new Random(DateTime.Now.Millisecond);
            generatorFirstFeature2.RandomSource = new Random(DateTime.Now.Millisecond + 10);
            generatorSecondFeature1.RandomSource = new Random(DateTime.Now.Millisecond + 20);
            generatorSecondFeature2.RandomSource = new Random(DateTime.Now.Millisecond + 30);
            #endregion

            Series NN1 = new Series();
            NN1.ChartType = SeriesChartType.Line;
            NN1.MarkerStyle = MarkerStyle.Circle;
            NN1.MarkerSize = 5;
            NN1.Name = "NN - 1";
            Series NN3 = new Series();
            NN3.ChartType = SeriesChartType.Line;
            NN3.MarkerStyle = MarkerStyle.Diamond;
            NN3.MarkerSize = 5;
            NN3.Name = "NN - 3";
            Series NN5 = new Series();
            NN5.ChartType = SeriesChartType.Line;
            NN5.MarkerStyle = MarkerStyle.Cross;
            NN5.MarkerSize = 5;
            NN5.Name = "NN - 5";
            Series NM = new Series();
            NM.ChartType = SeriesChartType.Line;
            NM.MarkerStyle = MarkerStyle.Square;
            NM.MarkerSize = 5;
            NM.Name = "NM";
            Series Bayes = new Series();
            Bayes.ChartType = SeriesChartType.Line;
            Bayes.MarkerStyle = MarkerStyle.Triangle;
            Bayes.MarkerSize = 5;
            Bayes.Name = "Bayes";

            for (int k = 5; k <= 100; k += 5)
            {
                double avgAlgorithmCounter = 0.0;
                double nearestAlgorithm1Counter = 0.0;
                double nearestAlgorithm3Counter = 0.0;
                double nearestAlgorithm5Counter = 0.0;
                double naiveBayesCounter = 0.0;

                for (int i = 0; i < 100; i++)
                {
                    List<PatternClass> wektoryUczace = Common.Create2DimTeachingVectors(P1, P2, generatorFirstFeature1, generatorFirstFeature2, generatorSecondFeature1, generatorSecondFeature2, k);
                    List<PatternClass> obiektyTestowe = Common.Create2DimTeachingVectors(P1, P2, generatorFirstFeature1, generatorFirstFeature2, generatorSecondFeature1, generatorSecondFeature2, 100);

                    avgAlgorithmCounter += RunClassyfication(obiektyTestowe, new NearestAverage(new EuclideanDistance()), wektoryUczace);
                    nearestAlgorithm1Counter += RunClassyfication(obiektyTestowe, new NearestNeighbour(1, new EuclideanDistance()), wektoryUczace);
                    nearestAlgorithm3Counter += RunClassyfication(obiektyTestowe, new NearestNeighbour(3, new EuclideanDistance()), wektoryUczace);
                    nearestAlgorithm5Counter += RunClassyfication(obiektyTestowe, new NearestNeighbour(5, new EuclideanDistance()), wektoryUczace);
                    naiveBayesCounter += RunClassyfication(obiektyTestowe, new NaiveBayes(new List<IContinuousDistribution>() { generatorFirstFeature1, generatorSecondFeature1 }, new List<IContinuousDistribution>() { generatorFirstFeature2, generatorSecondFeature2 }, P1, P2), wektoryUczace);
                }


                NN1.Points.Add(new DataPoint(k, CalculateErrorPercent(nearestAlgorithm1Counter, 100, 100)));
                NN3.Points.Add(new DataPoint(k, CalculateErrorPercent(nearestAlgorithm3Counter, 100, 100)));
                NN5.Points.Add(new DataPoint(k, CalculateErrorPercent(nearestAlgorithm5Counter, 100, 100)));
                NM.Points.Add(new DataPoint(k, CalculateErrorPercent(avgAlgorithmCounter, 100, 100)));
                Bayes.Points.Add(new DataPoint(k, CalculateErrorPercent(naiveBayesCounter, 100, 100)));
            }

            if (generatorFirstFeature1 is ContinuousUniform)
            {
                chart2DimStats.ChartAreas[0].AxisX.Title = String.Format("Ilość wektorów uczących \n  f11(x) = U({0},{1}),  f12(x) = U({0},{1}) \n f21(x) = U({2},{3}) , f22(x) = U({2},{3})", generatorFirstFeature1.Minimum, generatorFirstFeature1.Maximum, generatorSecondFeature1.Minimum, generatorSecondFeature1.Maximum);
                chartXYDistribution.ChartAreas[0].AxisX.Title = String.Format("f11(x) = U({0},{1}),  f12(x) = U({0},{1}) \n f21(x) = U({2},{3}) , f22(x) = U({2},{3})", generatorFirstFeature1.Minimum, generatorFirstFeature1.Maximum, generatorSecondFeature1.Minimum, generatorSecondFeature1.Maximum);
            }
            else
            {
                chart2DimStats.ChartAreas[0].AxisX.Title = String.Format("Ilość wektorów uczących \n  f11(x) = N({0},{1}),  f12(x) = N({0},{1}) \n f21(x) = N({2},{3}) , f22(x) = N({2},{3})", generatorFirstFeature1.Mean, generatorFirstFeature1.StdDev, generatorSecondFeature1.Mean, generatorSecondFeature1.StdDev);
                chartXYDistribution.ChartAreas[0].AxisX.Title = String.Format("f11(x) = N({0},{1}),  f12(x) = N({0},{1}) \n f21(x) = N({2},{3}) , f22(x) = N({2},{3})", generatorFirstFeature1.Mean, generatorFirstFeature1.StdDev, generatorSecondFeature1.Mean, generatorSecondFeature1.StdDev);
            }

            chart2DimStats.ChartAreas[0].AxisY.Title = String.Format("Częstość błędnej klasyfikacji");

            chart2DimStats.Series.Add(NN1);
            chart2DimStats.Series.Add(NN3);
            chart2DimStats.Series.Add(NN5);  
            chart2DimStats.Series.Add(NM);
            chart2DimStats.Series.Add(Bayes);
            chart2DimStats.Update();


            List<PatternClass> teachingVectors = Common.Create2DimTeachingVectors(P1, P2, generatorFirstFeature1, generatorFirstFeature2, generatorSecondFeature1, generatorSecondFeature2, 1000);

            foreach (Series ser in CreateXYSeries(teachingVectors))
            {
                chartXYDistribution.Series.Add(ser);
            }

            //foreach (Series ser in CreateXYSeries(sampleObjects))
            //{
            //    chartXYDistribution.Series.Add(ser);
            //}
            chartXYDistribution.Update();
        }
    }
}
