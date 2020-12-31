using System;
using NUnit.Framework;
using SoilMechanicsLibrary.SpecificGravity;
using SoilMechanicsLibrary.UnitWeights;
using SoilMechanicsLibrary.Volumes;
using SoilMechanicsLibrary.Weights;

namespace SoilMechanicsLibraryTests.Weights
{
    public class TestTotalWeight
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor1ShouldStoreAndPrintValueAndSymbol()
        {
            TotalWeight tw = new TotalWeight(10, WeightUnits.Grams);
            String correctAnswer = "W = 10 g";
            Assert.AreEqual("W", tw.Symbol);
            Assert.AreEqual(tw.NumericValue, 10);
            Assert.AreEqual(tw.UnitOfMeasure, WeightUnits.Grams);
            Assert.AreEqual(correctAnswer, tw.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithGrams()
        {
            WeightOfSolidMatter wsm = new WeightOfSolidMatter(10, WeightUnits.Grams);
            WeightOfWater ww = new WeightOfWater(10, WeightUnits.Grams);
            TotalWeight tw = new TotalWeight(wsm, ww, WeightUnits.Grams);
            String correctAnswer = "W = 20 g";
            Assert.AreEqual("W", tw.Symbol);
            Assert.AreEqual(tw.NumericValue, 20);
            Assert.AreEqual(tw.UnitOfMeasure, WeightUnits.Grams);
            Assert.AreEqual(correctAnswer, tw.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithKilograms()
        {
            WeightOfSolidMatter wsm = new WeightOfSolidMatter(10, WeightUnits.Grams);
            WeightOfWater ww = new WeightOfWater(10, WeightUnits.Grams);
            TotalWeight tw = new TotalWeight(wsm, ww, WeightUnits.Kilograms);
            Assert.AreEqual("W", tw.Symbol);
            Assert.AreEqual(Math.Round(tw.NumericValue, 2), .02);
            Assert.AreEqual(tw.UnitOfMeasure, WeightUnits.Kilograms);
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithPounds()
        {
            WeightOfSolidMatter wsm = new WeightOfSolidMatter(10, WeightUnits.Grams);
            WeightOfWater ww = new WeightOfWater(10, WeightUnits.Grams);
            TotalWeight tw = new TotalWeight(wsm, ww, WeightUnits.Pounds);
            Assert.AreEqual("W", tw.Symbol);
            Assert.AreEqual(Math.Round(tw.NumericValue, 3), 0.044);
            Assert.AreEqual(tw.UnitOfMeasure, WeightUnits.Pounds);
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbolWithPounds()
        {
            MassSpecificGravity msg = new MassSpecificGravity(10);
            UnitWeightOfWater uww = new UnitWeightOfWater(1, UnitWeightUnits.GramPerCubicCentimeter);
            TotalVolume tv = new TotalVolume(10, VolumeUnits.CubicCentimeters);
            TotalWeight tw = new TotalWeight(msg, uww, tv, WeightUnits.Pounds);
            Assert.AreEqual("W", tw.Symbol);
            Assert.AreEqual(Math.Round(tw.NumericValue, 2), 0.22);
            Assert.AreEqual(tw.UnitOfMeasure, WeightUnits.Pounds);
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbolWithGrams()
        {
            MassSpecificGravity msg = new MassSpecificGravity(10);
            UnitWeightOfWater uww = new UnitWeightOfWater(1, UnitWeightUnits.GramPerCubicCentimeter);
            TotalVolume tv = new TotalVolume(10, VolumeUnits.CubicCentimeters);
            TotalWeight tw = new TotalWeight(msg, uww, tv, WeightUnits.Grams);
            Assert.AreEqual("W", tw.Symbol);
            Assert.AreEqual(Math.Round(tw.NumericValue, 2), 100);
            Assert.AreEqual(tw.UnitOfMeasure, WeightUnits.Grams);
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbolWithKilograms()
        {
            MassSpecificGravity msg = new MassSpecificGravity(10);
            UnitWeightOfWater uww = new UnitWeightOfWater(1, UnitWeightUnits.GramPerCubicCentimeter);
            TotalVolume tv = new TotalVolume(10, VolumeUnits.CubicCentimeters);
            TotalWeight tw = new TotalWeight(msg, uww, tv, WeightUnits.Kilograms);
            Assert.AreEqual("W", tw.Symbol);
            Assert.AreEqual(Math.Round(tw.NumericValue, 2), .10);
            Assert.AreEqual(tw.UnitOfMeasure, WeightUnits.Kilograms);
        }
    }
}
