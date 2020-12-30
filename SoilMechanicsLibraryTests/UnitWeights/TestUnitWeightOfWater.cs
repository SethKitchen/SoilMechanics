using System;
using NUnit.Framework;
using SoilMechanicsLibrary.UnitWeights;
using SoilMechanicsLibrary.Volumes;
using SoilMechanicsLibrary.Weights;

namespace SoilMechanicsLibraryTests.UnitWeights
{
    public class TestUnitWeightOfWater
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor1ShouldStoreAndPrintValueAndSymbol()
        {
            UnitWeightOfWater uww = new UnitWeightOfWater(10, UnitWeightUnits.GramPerCubicCentimeter);
            String correctAnswer = "𝛾_w = 10 g/cc";
            Assert.AreEqual("𝛾_w", uww.Symbol);
            Assert.AreEqual(uww.NumericValue, 10);
            Assert.AreEqual(correctAnswer, uww.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithGramPerCubicCentimeter()
        {
            WeightOfWater ww = new WeightOfWater(10, WeightUnits.Grams);
            WaterVolume wv = new WaterVolume(10, VolumeUnits.CubicCentimeters);
            UnitWeightOfWater uww = new UnitWeightOfWater(ww, wv, UnitWeightUnits.GramPerCubicCentimeter);
            Assert.AreEqual(Math.Round(uww.NumericValue, 3), 1);
            Assert.AreEqual(uww.UnitOfMeasure, UnitWeightUnits.GramPerCubicCentimeter);
            Assert.AreEqual(uww.Symbol, "𝛾_w");
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithKilogramPerMeterCubed()
        {
            WeightOfWater ww = new WeightOfWater(10, WeightUnits.Grams);
            WaterVolume wv = new WaterVolume(10, VolumeUnits.CubicCentimeters);
            UnitWeightOfWater uww = new UnitWeightOfWater(ww, wv, UnitWeightUnits.KilogramPerMeterCubed);
            Assert.AreEqual(Math.Round(uww.NumericValue, 3), 1000);
            Assert.AreEqual(uww.UnitOfMeasure, UnitWeightUnits.KilogramPerMeterCubed);
            Assert.AreEqual(uww.Symbol, "𝛾_w");
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithPoundPerFootCubed()
        {
            WeightOfWater ww = new WeightOfWater(10, WeightUnits.Grams);
            WaterVolume wv = new WaterVolume(10, VolumeUnits.CubicCentimeters);
            UnitWeightOfWater uww = new UnitWeightOfWater(ww, wv, UnitWeightUnits.PoundPerCubicFoot);
            Assert.AreEqual(Math.Round(uww.NumericValue, 1), 62.4);
            Assert.AreEqual(uww.UnitOfMeasure, UnitWeightUnits.PoundPerCubicFoot);
            Assert.AreEqual(uww.Symbol, "𝛾_w");
        }
    }
}
