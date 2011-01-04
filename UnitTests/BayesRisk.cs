using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MathNet.Numerics.Distributions;
using ImageRecognition.ClassyfiAlgorithm;

namespace UnitTests
{
    [TestFixture]
    public class BayesRisk
    {
        [Test]
        public void SameVariance()
        {
         NaiveBayes bayes = new NaiveBayes();

         double actualBayesRisk = 30.514;
         double actualCommonPoint =0.5;
         double testedCommonPoint =0.0;
         double p1= 0.4;
         double p2 = 0.6;

         Normal gen1 =new Normal(0,1);
         Normal gen2 =new Normal(1,1);

         Assert.That(bayes.FindCommonPoint(gen1, gen2, ref testedCommonPoint),Is.True);
         Assert.That(Math.Abs(actualCommonPoint-testedCommonPoint),Is.LessThan(0.001));
         Assert.That(Math.Abs(actualBayesRisk - bayes.CalculateBayesRisk(gen1,gen2,p1,p2)), Is.LessThan(0.001));

        }
    }
}
