using System;
using NUnit.Framework;
using SoilMechanicsLibrary.SpecificGravity;
using SoilMechanicsLibrary.UnitWeights;

namespace SoilMechanicsLibraryTests.SpecificGravity
{
    public class TestSpecificGravityOfWater
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor1ShouldStoreAndPrintValueAndSymbol()
        {
            SpecificGravityOfWater sgw = new SpecificGravityOfWater(10);
            String correctAnswer = "G_w = 10";
            Assert.AreEqual("G_w", sgw.Symbol);
            Assert.AreEqual(sgw.NumericValue, 10);
            Assert.AreEqual(correctAnswer, sgw.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbol()
        {
            UnitWeightOfWater uws = new UnitWeightOfWater(10, UnitWeightUnits.GramPerCubicCentimeter);
            SpecificGravityOfWater sgw = new SpecificGravityOfWater(uws);
            String correctAnswer = "G_w = 10";
            Assert.AreEqual("G_w", sgw.Symbol);
            Assert.AreEqual(sgw.NumericValue, 10);
            Assert.AreEqual(correctAnswer, sgw.ToString());
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbol()
        {
            UnitWeightOfWater uww = new UnitWeightOfWater(10, UnitWeightUnits.GramPerCubicCentimeter);
            UnitWeightOfWater uwwRef = new UnitWeightOfWater(2, UnitWeightUnits.GramPerCubicCentimeter);
            SpecificGravityOfWater sgw = new SpecificGravityOfWater(uww, uwwRef);
            String correctAnswer = "G_w = 5";
            Assert.AreEqual("G_w", sgw.Symbol);
            Assert.AreEqual(sgw.NumericValue, 5);
            Assert.AreEqual(correctAnswer, sgw.ToString());
        }
    }
}
