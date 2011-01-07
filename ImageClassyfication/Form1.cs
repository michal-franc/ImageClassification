using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ImageRecognition;
using Telerik.Charting;
using MathNet.Numerics.Distributions;
using System.Windows.Forms.DataVisualization.Charting;
using PatternRecognition;
using ImageRecognition.ClassyfiAlgorithm;

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

        public int TwoDimNrOfSamples
        {
            get
            {
                return int.Parse(textBox2DimNrOfSampleObjects.Text);
            }
        }

        public int TwoDimNrOfTries
        {
            get
            {
                return int.Parse(textBox2DimNrOfTries.Text);
            }
        }

        public int TwoDimNrOfTeachingVectors
        {
            get
            {
                return int.Parse(textBox2DimNVectors.Text);
            }
        }

        public double TwoDimP1
        {
            get
            {
                return double.Parse(textBoxTwoDimP1.Text);
            }
        }

        public double TwoDimP2
        {
            get
            {
                return double.Parse(textBox2DimP2.Text);
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
                List<PatternClass> obiektyTestowe = Common.CreateSampleObject(generator1, IloscTestowychProbek / 2, 1);
                obiektyTestowe.InsertRange(obiektyTestowe.Count, Common.CreateSampleObject(generator2, IloscTestowychProbek / 2, 2));

                avgAlgorithmCounter += RunClassyfication(obiektyTestowe, new NearestAverage(new EuclideanDistance()), wektoryUczace);
                nearestAlgorithmCounter += RunClassyfication(obiektyTestowe, new NearestNeighbour(1, new EuclideanDistance()), wektoryUczace);
                naiveBayesCounter += RunClassyfication(obiektyTestowe, new NaiveBayes(generator1,generator2,P1,P2), wektoryUczace);
            }

            double bayesRisk = NaiveBayes.CalculateBayesRisk(generator1, generator2, P1, P2);

            textBoxData.Text = String.Format("Nearest : {0} \n Average {1} \n Bayes {2} \n Baies Risk {3}",
                CalculateErrorPercent(nearestAlgorithmCounter, IloscProb, IloscTestowychProbek),
                CalculateErrorPercent(avgAlgorithmCounter, IloscProb, IloscTestowychProbek),
                CalculateErrorPercent(naiveBayesCounter,IloscProb, IloscTestowychProbek),
                bayesRisk);
        }

        private double CalculateErrorPercent(double counter,double nrOfTries,double nrOfSampleObjects)
        {
            return 100 * counter / (nrOfTries * nrOfSampleObjects);
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


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();

            pictureBox1.Image = Bitmap.FromFile(dialog.FileName);
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
                generatorSecondFeature1 = new Normal(SecondFeatureA1, SecondFeatureA2);
                generatorSecondFeature2 = new Normal(SecondFeatureB1, SecondFeatureB2);

            }
            else if (SelectedGenerator == GeneratorType.Uniform)
            {
                generatorFirstFeature1 = new ContinuousUniform(FirstFeatureA1, FirstFeatureA2);
                generatorFirstFeature2 = new ContinuousUniform(FirstFeatureB1, FirstFeatureB2);
                generatorSecondFeature1 = new ContinuousUniform(SecondFeatureA1, SecondFeatureA2);
                generatorSecondFeature2 = new ContinuousUniform(SecondFeatureB1, SecondFeatureB2);
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

            for (int i = 0; i < TwoDimNrOfTries; i++)
            {

                teachingVectors = Common.Create2DimTeachingVectors(TwoDimP1, TwoDimP2, generatorFirstFeature1, generatorFirstFeature2, generatorSecondFeature1, generatorSecondFeature2, TwoDimNrOfTeachingVectors);
                sampleObjects = Common.Create2dimSampleObject(generatorFirstFeature1, generatorSecondFeature1, TwoDimNrOfSamples / 2, 1);
                sampleObjects.InsertRange(sampleObjects.Count, Common.Create2dimSampleObject(generatorFirstFeature2, generatorSecondFeature2, TwoDimNrOfSamples / 2, 2));

                averageCounter += RunClassyfication(sampleObjects, new NearestAverage(new EuclideanDistance()), teachingVectors);
                //naiveBayesCounter += RunClassyfication(sampleObjects, new NaiveBayes(generatorFirstFeature1, generatorSecondFeature1, P1, P2));
                nearestCounter += RunClassyfication(sampleObjects, new NearestNeighbour(3, new EuclideanDistance()), teachingVectors);
            }

            double bayesRisk = 0.0;
            //double bayesRisk = NaiveBayes.CalculateBayesRisk(generatorFirstFeature1,generatorSecondFeature1,P1,P2);

            textBoxData.Text = String.Format("Neares : {0} \n Average {1} \n Bayes {2} \n Bayes Risk {3} ", CalculateErrorPercent(nearestCounter, TwoDimNrOfTries, TwoDimNrOfTeachingVectors), CalculateErrorPercent(averageCounter, TwoDimNrOfTries, TwoDimNrOfTeachingVectors), CalculateErrorPercent(naiveBayesCounter, TwoDimNrOfTries, TwoDimNrOfTeachingVectors), bayesRisk);

            foreach (Series ser in CreateXYSeries(sampleObjects))
            {
                chartXYDistribution.Series.Add(ser);
            }
            chartXYDistribution.Update();

            foreach (Series ser in CreateXYSeries(teachingVectors))
            {
                chartXYDistribution.Series.Add(ser);
            }


            //Put those objects on XY chart green - good classyfication , red - bad classyfication
            //Create statstics
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
                createdSerie.Points.Add(new DataPoint(i, distributionn.Density(i)));
            }

            return createdSerie;
        } 
        #endregion
    }
}
