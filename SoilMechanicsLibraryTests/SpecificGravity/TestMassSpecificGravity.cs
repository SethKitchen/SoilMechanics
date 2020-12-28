using System;
using NUnit.Framework;
using SoilMechanicsLibrary.SpecificGravity;
using SoilMechanicsLibrary.UnitWeights;

namespace SoilMechanicsLibraryTests.SpecificGravity
{
    public class TestMassSpecificGravity
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor1ShouldStoreAndPrintValueAndSymbol()
        {
            MassSpecificGravity msg = new MassSpecificGravity(10);
            String correctAnswer = "G_m = 10";
            Assert.AreEqual("G_m", msg.Symbol);
            Assert.AreEqual(msg.NumericValue, 10);
            Assert.AreEqual(correctAnswer, msg.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbol()
        {
            TotalUnitWeight tuw = new TotalUnitWeight(10, UnitWeightUnits.GramPerCubicCentimeter);
            MassSpecificGravity msg = new MassSpecificGravity(tuw);
            String correctAnswer = "G_m = 10";
            Assert.AreEqual("G_m", msg.Symbol);
            Assert.AreEqual(msg.NumericValue, 10);
            Assert.AreEqual(correctAnswer, msg.ToString());
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbol()
        {
            TotalUnitWeight tuw = new TotalUnitWeight(10, UnitWeightUnits.GramPerCubicCentimeter);
            UnitWeightOfWater uww = new UnitWeightOfWater(2, UnitWeightUnits.GramPerCubicCentimeter);
            MassSpecificGravity msg = new MassSpecificGravity(tuw, uww);
            String correctAnswer = "G_m = 5";
            Assert.AreEqual("G_m", msg.Symbol);
            Assert.AreEqual(msg.NumericValue, 5);
            Assert.AreEqual(correctAnswer, msg.ToString());
        }
    }
}
