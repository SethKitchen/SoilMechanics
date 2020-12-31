using System;
using NUnit.Framework;
using SoilMechanicsLibrary.Weights;

namespace SoilMechanicsLibraryTests.Weights
{
    public class TestWeightOfSolidMatter
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor1ShouldStoreAndPrintValueAndSymbol()
        {
            WeightOfSolidMatter wsm = new WeightOfSolidMatter(10, WeightUnits.Grams);
            String correctAnswer = "W_s = 10 g";
            Assert.AreEqual("W_s", wsm.Symbol);
            Assert.AreEqual(wsm.NumericValue, 10);
            Assert.AreEqual(wsm.UnitOfMeasure, WeightUnits.Grams);
            Assert.AreEqual(correctAnswer, wsm.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithGrams()
        {
            WeightOfWater ww = new WeightOfWater(10, WeightUnits.Grams);
            TotalWeight tw = new TotalWeight(20, WeightUnits.Grams);
            WeightOfSolidMatter wsm = new WeightOfSolidMatter(ww, tw, WeightUnits.Grams);
            String correctAnswer = "W_s = 10 g";
            Assert.AreEqual("W_s", wsm.Symbol);
            Assert.AreEqual(wsm.NumericValue, 10);
            Assert.AreEqual(wsm.UnitOfMeasure, WeightUnits.Grams);
            Assert.AreEqual(correctAnswer, wsm.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithKilograms()
        {
            WeightOfWater ww = new WeightOfWater(10, WeightUnits.Grams);
            TotalWeight tw = new TotalWeight(20, WeightUnits.Grams);
            WeightOfSolidMatter wsm = new WeightOfSolidMatter(ww, tw, WeightUnits.Kilograms);
            Assert.AreEqual(Math.Round(wsm.NumericValue, 2), .01);
            Assert.AreEqual(wsm.UnitOfMeasure, WeightUnits.Kilograms);
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithPounds()
        {
            WeightOfWater ww = new WeightOfWater(10, WeightUnits.Grams);
            TotalWeight tw = new TotalWeight(20, WeightUnits.Grams);
            WeightOfSolidMatter wsm = new WeightOfSolidMatter(ww, tw, WeightUnits.Pounds);
            Assert.AreEqual(Math.Round(wsm.NumericValue, 3), 0.022);
            Assert.AreEqual(wsm.UnitOfMeasure, WeightUnits.Pounds);
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbolWithGrams()
        {
            WaterContent wc = new WaterContent(.1);
            WeightOfWater ww = new WeightOfWater(10, WeightUnits.Grams);
            WeightOfSolidMatter wsm = new WeightOfSolidMatter(wc, ww, WeightUnits.Grams);
            Assert.AreEqual(Math.Round(wsm.NumericValue, 2), 100);
            Assert.AreEqual(wsm.UnitOfMeasure, WeightUnits.Grams);
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbolWithKilograms()
        {
            WaterContent wc = new WaterContent(.1);
            WeightOfWater ww = new WeightOfWater(10, WeightUnits.Grams);
            WeightOfSolidMatter wsm = new WeightOfSolidMatter(wc, ww, WeightUnits.Kilograms);
            Assert.AreEqual(Math.Round(wsm.NumericValue, 2), .10);
            Assert.AreEqual(wsm.UnitOfMeasure, WeightUnits.Kilograms);
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbolWithPounds()
        {
            WaterContent wc = new WaterContent(.1);
            WeightOfWater ww = new WeightOfWater(10, WeightUnits.Grams);
            WeightOfSolidMatter wsm = new WeightOfSolidMatter(wc, ww, WeightUnits.Pounds);
            Assert.AreEqual(Math.Round(wsm.NumericValue, 2), .22);
            Assert.AreEqual(wsm.UnitOfMeasure, WeightUnits.Pounds);
        }
    }
}
