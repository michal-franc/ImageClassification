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
    public class BayesRiskTests
    {
        [Test]
        public void SameVariance()
        {

         double actualBayesRisk = 30.514;
         double actualCommonPoint =0.5;
         double testedCommonPoint =0.0;
         double p1= 0.4;
         double p2 = 0.6;

         Normal gen1 =new Normal(0,1);
         Normal gen2 =new Normal(1,1);

         NaiveBayes bayes = new NaiveBayes(new List<IContinuousDistribution>(){gen1},new List<IContinuousDistribution>(){gen2},p1,p2);


         Assert.That(NaiveBayes.FindCommonPointNormalDistribution(gen1, gen2, ref testedCommonPoint), Is.True);
         Assert.That(Math.Abs(actualCommonPoint-testedCommonPoint),Is.LessThan(0.001));
         //Assert.That(Math.Abs(actualBayesRisk - NaiveBayes.CalculateBayesRisk(gen1, gen2, p1, p2)), Is.LessThan(0.001));

        }
    }
}
