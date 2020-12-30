using System;
using NUnit.Framework;
using SoilMechanicsLibrary.UnitWeights;
using SoilMechanicsLibrary.Volumes;
using SoilMechanicsLibrary.Weights;

namespace SoilMechanicsLibraryTests.UnitWeights
{
    public class TestUnitWeightOfSolids
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor1ShouldStoreAndPrintValueAndSymbol()
        {
            UnitWeightOfSolids uws = new UnitWeightOfSolids(10, UnitWeightUnits.GramPerCubicCentimeter);
            String correctAnswer = "𝛾_s = 10 g/cc";
            Assert.AreEqual("𝛾_s", uws.Symbol);
            Assert.AreEqual(uws.NumericValue, 10);
            Assert.AreEqual(correctAnswer, uws.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithGramPerCubicCentimeter()
        {
            WeightOfSolidMatter wsm = new WeightOfSolidMatter(10, WeightUnits.Grams);
            VolumeOfSolidMatter vsm = new VolumeOfSolidMatter(10, VolumeUnits.CubicCentimeters);
            UnitWeightOfSolids uws = new UnitWeightOfSolids(wsm, vsm, UnitWeightUnits.GramPerCubicCentimeter);
            Assert.AreEqual(Math.Round(uws.NumericValue, 3), 1);
            Assert.AreEqual(uws.UnitOfMeasure, UnitWeightUnits.GramPerCubicCentimeter);
            Assert.AreEqual(uws.Symbol, "𝛾_s");
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithKilogramPerMeterCubed()
        {
            WeightOfSolidMatter wsm = new WeightOfSolidMatter(10, WeightUnits.Grams);
            VolumeOfSolidMatter vsm = new VolumeOfSolidMatter(10, VolumeUnits.CubicCentimeters);
            UnitWeightOfSolids uws = new UnitWeightOfSolids(wsm, vsm, UnitWeightUnits.KilogramPerMeterCubed);
            Assert.AreEqual(Math.Round(uws.NumericValue, 3), 1000);
            Assert.AreEqual(uws.UnitOfMeasure, UnitWeightUnits.KilogramPerMeterCubed);
            Assert.AreEqual(uws.Symbol, "𝛾_s");
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithPoundPerFootCubed()
        {
            WeightOfSolidMatter wsm = new WeightOfSolidMatter(10, WeightUnits.Grams);
            VolumeOfSolidMatter vsm = new VolumeOfSolidMatter(10, VolumeUnits.CubicCentimeters);
            UnitWeightOfSolids uws = new UnitWeightOfSolids(wsm, vsm, UnitWeightUnits.PoundPerCubicFoot);
            Assert.AreEqual(Math.Round(uws.NumericValue, 1), 62.4);
            Assert.AreEqual(uws.UnitOfMeasure, UnitWeightUnits.PoundPerCubicFoot);
            Assert.AreEqual(uws.Symbol, "𝛾_s");
        }
    }
}
