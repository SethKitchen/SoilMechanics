using System;
using NUnit.Framework;
using SoilMechanicsLibrary.SpecificGravity;

namespace SoilMechanicsLibraryTests.SpecificGravity
{
    public class TestSpecificGravityQuartz
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor1ShouldStoreAndPrintValueAndSymbol()
        {
            SpecificGravityQuartz sgq = new SpecificGravityQuartz();
            String correctAnswer = "G_{quartz} = 2.67";
            Assert.AreEqual("G_{quartz}", sgq.Symbol);
            Assert.AreEqual(sgq.NumericValue, 2.67);
            Assert.AreEqual(correctAnswer, sgq.ToString());
        }
    }
}
