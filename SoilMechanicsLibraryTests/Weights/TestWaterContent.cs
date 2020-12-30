using System;
using NUnit.Framework;
using SoilMechanicsLibrary.Weights;

namespace SoilMechanicsLibraryTests.Weights
{
    public class TestWaterContent
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor1ShouldStoreAndPrintValueAndSymbol()
        {
            WaterContent wc = new WaterContent(.1);
            String correctAnswer = "w = 10 %";
            Assert.AreEqual("w", wc.Symbol);
            Assert.AreEqual(wc.NumericValue, .1);
            Assert.AreEqual(correctAnswer, wc.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbol()
        {
            WeightOfSolidMatter wsm = new WeightOfSolidMatter(10, WeightUnits.Kilograms);
            WeightOfWater ww = new WeightOfWater(10000, WeightUnits.Grams);
            WaterContent wc = new WaterContent(wsm, ww);
            String correctAnswer = "w = 100 %";
            Assert.AreEqual("w", wc.Symbol);
            Assert.AreEqual(wc.NumericValue, 1);
            Assert.AreEqual(correctAnswer, wc.ToString());
        }
    }
}
