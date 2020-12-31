using System;
using NUnit.Framework;
using SoilMechanicsLibrary.Volumes;

namespace SoilMechanicsLibraryTests.Volumes
{
    public class TestPorosity
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor1ShouldStoreAndPrintValueAndSymbol()
        {
            Porosity p = new Porosity(.1);
            String correctAnswer = "n = 10 %";
            Assert.AreEqual("n", p.Symbol);
            Assert.AreEqual(p.NumericValue, .1);
            Assert.AreEqual(correctAnswer, p.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbol()
        {
            VolumeOfVoids vv = new VolumeOfVoids(10, VolumeUnits.CubicCentimeters);
            TotalVolume tv = new TotalVolume(10, VolumeUnits.CubicCentimeters);
            Porosity p = new Porosity(vv, tv);
            String correctAnswer = "n = 100 %";
            Assert.AreEqual("n", p.Symbol);
            Assert.AreEqual(p.NumericValue, 1);
            Assert.AreEqual(correctAnswer, p.ToString());
        }
    }
}
