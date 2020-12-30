using System;
using NUnit.Framework;
using SoilMechanicsLibrary.Weights;

namespace SoilMechanicsLibraryTests.Weights
{
    public class TestWeightOfWater
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor1ShouldStoreAndPrintValueAndSymbol()
        {
            WeightOfWater ww = new WeightOfWater(10, WeightUnits.Grams);
            String correctAnswer = "W_w = 10 g";
            Assert.AreEqual("W_w", ww.Symbol);
            Assert.AreEqual(ww.NumericValue, 10);
            Assert.AreEqual(ww.UnitOfMeasure, WeightUnits.Grams);
            Assert.AreEqual(correctAnswer, ww.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithGrams()
        {
            WeightOfSolidMatter wsm = new WeightOfSolidMatter(10, WeightUnits.Grams);
            TotalWeight tw = new TotalWeight(20, WeightUnits.Grams);
            WeightOfWater ww = new WeightOfWater(wsm, tw, WeightUnits.Grams);
            String correctAnswer = "W_w = 10 g";
            Assert.AreEqual("W_w", ww.Symbol);
            Assert.AreEqual(ww.NumericValue, 10);
            Assert.AreEqual(ww.UnitOfMeasure, WeightUnits.Grams);
            Assert.AreEqual(correctAnswer, ww.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithKilograms()
        {
            WeightOfSolidMatter wsm = new WeightOfSolidMatter(10, WeightUnits.Grams);
            TotalWeight tw = new TotalWeight(20, WeightUnits.Grams);
            WeightOfWater ww = new WeightOfWater(wsm, tw, WeightUnits.Kilograms);
            Assert.AreEqual(Math.Round(ww.NumericValue, 2), .01);
            Assert.AreEqual(ww.UnitOfMeasure, WeightUnits.Kilograms);
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithPounds()
        {
            WeightOfSolidMatter wsm = new WeightOfSolidMatter(10, WeightUnits.Grams);
            TotalWeight tw = new TotalWeight(20, WeightUnits.Grams);
            WeightOfWater ww = new WeightOfWater(wsm, tw, WeightUnits.Pounds);
            Assert.AreEqual(Math.Round(ww.NumericValue, 3), 0.022);
            Assert.AreEqual(ww.UnitOfMeasure, WeightUnits.Pounds);
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbolWithGrams()
        {
            WaterContent wc = new WaterContent(.1);
            WeightOfSolidMatter wsm = new WeightOfSolidMatter(10, WeightUnits.Grams);
            WeightOfWater ww = new WeightOfWater(wc, wsm, WeightUnits.Grams);
            Assert.AreEqual(Math.Round(ww.NumericValue, 2), 1);
            Assert.AreEqual(ww.UnitOfMeasure, WeightUnits.Grams);
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbolWithKilograms()
        {
            WaterContent wc = new WaterContent(.1);
            WeightOfSolidMatter wsm = new WeightOfSolidMatter(10, WeightUnits.Grams);
            WeightOfWater ww = new WeightOfWater(wc, wsm, WeightUnits.Kilograms);
            Assert.AreEqual(Math.Round(ww.NumericValue, 3), .001);
            Assert.AreEqual(ww.UnitOfMeasure, WeightUnits.Kilograms);
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbolWithPounds()
        {
            WaterContent wc = new WaterContent(.1);
            WeightOfSolidMatter wsm = new WeightOfSolidMatter(10, WeightUnits.Grams);
            WeightOfWater ww = new WeightOfWater(wc, wsm, WeightUnits.Pounds);
            Assert.AreEqual(Math.Round(ww.NumericValue, 4), .0022);
            Assert.AreEqual(ww.UnitOfMeasure, WeightUnits.Pounds);
        }
    }
}
