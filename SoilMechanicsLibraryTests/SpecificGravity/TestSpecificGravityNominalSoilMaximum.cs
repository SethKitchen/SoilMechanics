using System;
using NUnit.Framework;
using SoilMechanicsLibrary.SpecificGravity;

namespace SoilMechanicsLibraryTests.SpecificGravity
{
    public class TestSpecificGravityNominalSoilMaximum
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor1ShouldStoreAndPrintValueAndSymbol()
        {
            SpecificGravityNominalSoilMaximum sgnsm = new SpecificGravityNominalSoilMaximum();
            String correctAnswer = "G_{soil_max} = 2.85";
            Assert.AreEqual("G_{soil_max}", sgnsm.Symbol);
            Assert.AreEqual(sgnsm.NumericValue, 2.85);
            Assert.AreEqual(correctAnswer, sgnsm.ToString());
        }
    }
}
