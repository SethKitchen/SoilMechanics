using System;
using NUnit.Framework;
using SoilMechanicsLibrary.SpecificGravity;
using SoilMechanicsLibrary.UnitWeights;

namespace SoilMechanicsLibraryTests.SpecificGravity
{
    public class TestSpecificGravityOfSolids
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor1ShouldStoreAndPrintValueAndSymbol()
        {
            SpecificGravityOfSolids sgs = new SpecificGravityOfSolids(10);
            String correctAnswer = "G_s = 10";
            Assert.AreEqual("G_s", sgs.Symbol);
            Assert.AreEqual(sgs.NumericValue, 10);
            Assert.AreEqual(correctAnswer, sgs.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbol()
        {
            UnitWeightOfSolids uws = new UnitWeightOfSolids(10, UnitWeightUnits.GramPerCubicCentimeter);
            SpecificGravityOfSolids sgs = new SpecificGravityOfSolids(uws);
            String correctAnswer = "G_s = 10";
            Assert.AreEqual("G_s", sgs.Symbol);
            Assert.AreEqual(sgs.NumericValue, 10);
            Assert.AreEqual(correctAnswer, sgs.ToString());
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbol()
        {
            UnitWeightOfSolids uws = new UnitWeightOfSolids(10, UnitWeightUnits.GramPerCubicCentimeter);
            UnitWeightOfWater uww = new UnitWeightOfWater(2, UnitWeightUnits.GramPerCubicCentimeter);
            SpecificGravityOfSolids sgs = new SpecificGravityOfSolids(uws, uww);
            String correctAnswer = "G_s = 5";
            Assert.AreEqual("G_s", sgs.Symbol);
            Assert.AreEqual(sgs.NumericValue, 5);
            Assert.AreEqual(correctAnswer, sgs.ToString());
        }
    }
}
