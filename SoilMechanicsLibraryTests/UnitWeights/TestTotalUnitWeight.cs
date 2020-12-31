using System;
using NUnit.Framework;
using SoilMechanicsLibrary.SpecificGravity;
using SoilMechanicsLibrary.UnitWeights;
using SoilMechanicsLibrary.Volumes;
using SoilMechanicsLibrary.Weights;

namespace SoilMechanicsLibraryTests.UnitWeights
{
    public class TestTotalUnitWeight
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor1ShouldStoreAndPrintValueAndSymbol()
        {
            TotalUnitWeight d = new TotalUnitWeight(10, UnitWeightUnits.GramPerCubicCentimeter);
            String correctAnswer = "𝛾_t = 10 g/cc";
            Assert.AreEqual("𝛾_t", d.Symbol);
            Assert.AreEqual(d.NumericValue, 10);
            Assert.AreEqual(correctAnswer, d.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithGramPerCubicCentimeter()
        {
            TotalWeight tw = new TotalWeight(10, WeightUnits.Grams);
            TotalVolume tv = new TotalVolume(10, VolumeUnits.CubicCentimeters);
            TotalUnitWeight tuw = new TotalUnitWeight(tw, tv, UnitWeightUnits.GramPerCubicCentimeter);
            Assert.AreEqual(Math.Round(tuw.NumericValue, 1), 1);
            Assert.AreEqual(tuw.UnitOfMeasure, UnitWeightUnits.GramPerCubicCentimeter);
            Assert.AreEqual(tuw.Symbol, "𝛾_t");
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithKilogramPerMeterCubed()
        {
            TotalWeight tw = new TotalWeight(10, WeightUnits.Grams);
            TotalVolume tv = new TotalVolume(10, VolumeUnits.CubicCentimeters);
            TotalUnitWeight tuw = new TotalUnitWeight(tw, tv, UnitWeightUnits.KilogramPerMeterCubed);
            Assert.AreEqual(Math.Round(tuw.NumericValue, 2), 1000);
            Assert.AreEqual(tuw.UnitOfMeasure, UnitWeightUnits.KilogramPerMeterCubed);
            Assert.AreEqual(tuw.Symbol, "𝛾_t");
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithPoundPerFootCubed()
        {
            TotalWeight tw = new TotalWeight(10, WeightUnits.Grams);
            TotalVolume tv = new TotalVolume(10, VolumeUnits.CubicCentimeters);
            TotalUnitWeight tuw = new TotalUnitWeight(tw, tv, UnitWeightUnits.PoundPerCubicFoot);
            Assert.AreEqual(Math.Round(tuw.NumericValue, 2), 62.43);
            Assert.AreEqual(tuw.UnitOfMeasure, UnitWeightUnits.PoundPerCubicFoot);
            Assert.AreEqual(tuw.Symbol, "𝛾_t"); ;
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbolWithGramPerCubicCentimeter()
        {
            SpecificGravityOfSolids sgos = new SpecificGravityOfSolids(10);
            DegreeOfSaturation dos = new DegreeOfSaturation(0.5);
            VoidRatio vr = new VoidRatio(0.5);
            UnitWeightOfWater uww = new UnitWeightOfWater(1, UnitWeightUnits.GramPerCubicCentimeter);
            TotalUnitWeight tuw = new TotalUnitWeight(sgos, dos, vr, uww, UnitWeightUnits.GramPerCubicCentimeter);
            Assert.AreEqual(Math.Round(tuw.NumericValue, 2), 6.83);
            Assert.AreEqual(tuw.UnitOfMeasure, UnitWeightUnits.GramPerCubicCentimeter);
            Assert.AreEqual(tuw.Symbol, "𝛾_t");
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbolWithKilogramPerMeterCubed()
        {
            SpecificGravityOfSolids sgos = new SpecificGravityOfSolids(10);
            DegreeOfSaturation dos = new DegreeOfSaturation(0.5);
            VoidRatio vr = new VoidRatio(0.5);
            UnitWeightOfWater uww = new UnitWeightOfWater(1, UnitWeightUnits.GramPerCubicCentimeter);
            TotalUnitWeight tuw = new TotalUnitWeight(sgos, dos, vr, uww, UnitWeightUnits.KilogramPerMeterCubed);
            Assert.AreEqual(Math.Round(tuw.NumericValue, 2), 6833.33);
            Assert.AreEqual(tuw.UnitOfMeasure, UnitWeightUnits.KilogramPerMeterCubed);
            Assert.AreEqual(tuw.Symbol, "𝛾_t");
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbolWithPoundPerFootCubed()
        {
            SpecificGravityOfSolids sgos = new SpecificGravityOfSolids(10);
            DegreeOfSaturation dos = new DegreeOfSaturation(0.5);
            VoidRatio vr = new VoidRatio(0.5);
            UnitWeightOfWater uww = new UnitWeightOfWater(1, UnitWeightUnits.GramPerCubicCentimeter);
            TotalUnitWeight tuw = new TotalUnitWeight(sgos, dos, vr, uww, UnitWeightUnits.PoundPerCubicFoot);
            Assert.AreEqual(Math.Round(tuw.NumericValue, 1), 426.6);
            Assert.AreEqual(tuw.UnitOfMeasure, UnitWeightUnits.PoundPerCubicFoot);
            Assert.AreEqual(tuw.Symbol, "𝛾_t"); ;
        }
    }
}
