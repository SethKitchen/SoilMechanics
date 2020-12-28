using System;
using NUnit.Framework;
using SoilMechanicsLibrary.SpecificGravity;

namespace SoilMechanicsLibraryTests.SpecificGravity
{
    public class TestSpecificGravityNominalSoilMinimum
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor1ShouldStoreAndPrintValueAndSymbol()
        {
            SpecificGravityNominalSoilMinimum sgnsm = new SpecificGravityNominalSoilMinimum();
            String correctAnswer = "G_{soil_min} = 2.65";
            Assert.AreEqual("G_{soil_min}", sgnsm.Symbol);
            Assert.AreEqual(sgnsm.NumericValue, 2.65);
            Assert.AreEqual(correctAnswer, sgnsm.ToString());
        }
    }
}
