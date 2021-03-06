using System;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit2;

namespace AutoFixtureSamples
{
    [TestFixture]
    public class TheoryDemoTests
    {
        // example-based
        [Test]        
        public void CheckFunc()
        {
            double result = Func(0.5);
            Assert.That(result, Is.EqualTo(5));
        }

        [Datapoint] public double Zero = 0;
        [Datapoint] public double One = 1;
        [Datapoint] public double Negative = -1;
        [Datapoints] public double[] TestPoints = {0.1, 0.2, 300};

        // statement-based
        [Theory]
        public void FuncTesting(double x)
        {
            Assume.That(x >= 0.0 && x <= 1);
            double result = Func(x);
            Assert.That(result, Is.EqualTo(x*10).Within(0.00001));
        }

        // statement-based
        [Theory]
        [AutoData]
        public void DescriptorTests(FileParameterDescriptor descriptor)
        {
            string code = CodeLength(descriptor);
            Assert.That(code.Length, Is.EqualTo(descriptor.Id.Length + descriptor.Alias.Length));
        }

        double Func(double x)
        {
            if (x < 0)
                throw new ArgumentException();
            if (x > 1)
                throw new ArgumentException();
            return x*10;
        }

        string CodeLength(FileParameterDescriptor descriptor)
        {
            return descriptor.Id + descriptor.Alias;
        }
    }
}