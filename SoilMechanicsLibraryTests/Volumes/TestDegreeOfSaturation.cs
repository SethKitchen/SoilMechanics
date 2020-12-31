using System;
using NUnit.Framework;
using SoilMechanicsLibrary.Volumes;

namespace SoilMechanicsLibraryTests.Volumes
{
    public class TestDegreeOfSaturation
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor1ShouldStoreAndPrintValueAndSymbol()
        {
            DegreeOfSaturation ds = new DegreeOfSaturation(.1);
            String correctAnswer = "S = 10 %";
            Assert.AreEqual("S", ds.Symbol);
            Assert.AreEqual(ds.NumericValue, .1);
            Assert.AreEqual(correctAnswer, ds.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbol()
        {
            WaterVolume wv = new WaterVolume(10, VolumeUnits.CubicCentimeters);
            VolumeOfVoids vv = new VolumeOfVoids(10, VolumeUnits.CubicCentimeters);
            DegreeOfSaturation ds = new DegreeOfSaturation(wv, vv);
            String correctAnswer = "S = 100 %";
            Assert.AreEqual("S", ds.Symbol);
            Assert.AreEqual(ds.NumericValue, 1);
            Assert.AreEqual(correctAnswer, ds.ToString());
        }
    }
}
