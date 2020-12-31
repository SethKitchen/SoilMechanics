using System;
using NUnit.Framework;
using SoilMechanicsLibrary.Volumes;

namespace SoilMechanicsLibraryTests.Volumes
{
    public class TestVoidRatio
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor1ShouldStoreAndPrintValueAndSymbol()
        {
            VoidRatio vr = new VoidRatio(.1);
            String correctAnswer = "e = 0.1";
            Assert.AreEqual("e", vr.Symbol);
            Assert.AreEqual(vr.NumericValue, .1);
            Assert.AreEqual(correctAnswer, vr.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbol()
        {
            VolumeOfVoids vv = new VolumeOfVoids(10, VolumeUnits.CubicCentimeters);
            VolumeOfSolidMatter vs = new VolumeOfSolidMatter(10, VolumeUnits.CubicCentimeters);
            VoidRatio vr = new VoidRatio(vv, vs);
            String correctAnswer = "e = 1";
            Assert.AreEqual("e", vr.Symbol);
            Assert.AreEqual(vr.NumericValue, 1);
            Assert.AreEqual(correctAnswer, vr.ToString());
        }
    }
}
