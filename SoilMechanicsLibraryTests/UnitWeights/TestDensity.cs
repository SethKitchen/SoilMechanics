using System;
using NUnit.Framework;
using SoilMechanicsLibrary.UnitWeights;

namespace SoilMechanicsLibraryTests.UnitWeights
{
    public class TestDensity
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor1ShouldStoreAndPrintValueAndSymbol()
        {
            Density d = new Density(10, UnitWeightUnits.GramPerCubicCentimeter);
            String correctAnswer = "ρ = 10 g/cc";
            Assert.AreEqual("ρ", d.Symbol);
            Assert.AreEqual(d.NumericValue, 10);
            Assert.AreEqual(correctAnswer, d.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithGramPerCubicCentimeter()
        {
            TotalUnitWeight tuw = new TotalUnitWeight(10, UnitWeightUnits.GramPerCubicCentimeter);
            Density d = new Density(tuw, UnitWeightUnits.GramPerCubicCentimeter);
            Assert.AreEqual(Math.Round(d.NumericValue, 3), 1.019);
            Assert.AreEqual(d.UnitOfMeasure, UnitWeightUnits.GramPerCubicCentimeter);
            Assert.AreEqual(d.Symbol, "ρ");
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithKilogramPerMeterCubed()
        {
            TotalUnitWeight tuw = new TotalUnitWeight(10, UnitWeightUnits.GramPerCubicCentimeter);
            Density d = new Density(tuw, UnitWeightUnits.KilogramPerMeterCubed);
            Assert.AreEqual(Math.Round(d.NumericValue, 3), 1019.368);
            Assert.AreEqual(d.UnitOfMeasure, UnitWeightUnits.KilogramPerMeterCubed);
            Assert.AreEqual(d.Symbol, "ρ");
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithPoundPerFootCubed()
        {
            TotalUnitWeight tuw = new TotalUnitWeight(10, UnitWeightUnits.GramPerCubicCentimeter);
            Density d = new Density(tuw, UnitWeightUnits.PoundPerCubicFoot);
            Assert.AreEqual(Math.Round(d.NumericValue, 2), 63.64);
            Assert.AreEqual(d.UnitOfMeasure, UnitWeightUnits.PoundPerCubicFoot);
            Assert.AreEqual(d.Symbol, "ρ");
        }
    }
}
