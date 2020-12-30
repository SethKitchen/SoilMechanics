using System;
using NUnit.Framework;
using SoilMechanicsLibrary.UnitWeights;

namespace SoilMechanicsLibraryTests.UnitWeights
{
    public class TestUnitWeightOfWaterAt4DegreesC
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor1ShouldStoreAndPrintValueAndSymbol()
        {
            UnitWeightOfWaterAt4DegreesC uww4d = new UnitWeightOfWaterAt4DegreesC();
            String correctAnswer = "𝛾_0 = 1 g/cc";
            Assert.AreEqual("𝛾_0", uww4d.Symbol);
            Assert.AreEqual(uww4d.NumericValue, 1);
            Assert.AreEqual(correctAnswer, uww4d.ToString());
        }
    }
}
