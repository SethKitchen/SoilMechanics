using System;
using NUnit.Framework;
using SoilMechanicsLibrary.Volumes;

namespace SoilMechanicsLibraryTests.Volumes
{
    public class TestVolumeOfSolidMatter
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor1ShouldStoreAndPrintValueAndSymbol()
        {
            VolumeOfSolidMatter vsm = new VolumeOfSolidMatter(10, VolumeUnits.CubicCentimeters);
            String correctAnswer = "V_s = 10 cc";
            Assert.AreEqual("V_s", vsm.Symbol);
            Assert.AreEqual(vsm.NumericValue, 10);
            Assert.AreEqual(vsm.UnitOfMeasure, VolumeUnits.CubicCentimeters);
            Assert.AreEqual(correctAnswer, vsm.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithCubicCentimeters()
        {
            VolumeOfVoids vv = new VolumeOfVoids(10, VolumeUnits.CubicCentimeters);
            TotalVolume tv = new TotalVolume(20, VolumeUnits.CubicCentimeters);
            VolumeOfSolidMatter vsm = new VolumeOfSolidMatter(vv, tv, VolumeUnits.CubicCentimeters);
            String correctAnswer = "V_s = 10 cc";
            Assert.AreEqual("V_s", vsm.Symbol);
            Assert.AreEqual(vsm.NumericValue, 10);
            Assert.AreEqual(vsm.UnitOfMeasure, VolumeUnits.CubicCentimeters);
            Assert.AreEqual(correctAnswer, vsm.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithM3()
        {
            VolumeOfVoids vv = new VolumeOfVoids(10, VolumeUnits.CubicCentimeters);
            TotalVolume tv = new TotalVolume(20, VolumeUnits.CubicCentimeters);
            VolumeOfSolidMatter vsm = new VolumeOfSolidMatter(vv, tv, VolumeUnits.CubicMeters);
            String correctAnswer = "V_s = 0 m^3";
            Assert.AreEqual("V_s", vsm.Symbol);
            Assert.AreEqual(vsm.NumericValue, 1e-5);
            Assert.AreEqual(vsm.UnitOfMeasure, VolumeUnits.CubicMeters);
            Assert.AreEqual(correctAnswer, vsm.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithFt3()
        {
            VolumeOfVoids vv = new VolumeOfVoids(10, VolumeUnits.CubicCentimeters);
            TotalVolume tv = new TotalVolume(20, VolumeUnits.CubicCentimeters);
            VolumeOfSolidMatter vsm = new VolumeOfSolidMatter(vv, tv, VolumeUnits.CubicFeet);
            String correctAnswer = "V_s = 0 ft^3";
            Assert.AreEqual("V_s", vsm.Symbol);
            Assert.AreEqual(Math.Round(vsm.NumericValue,6), 0.000353);
            Assert.AreEqual(vsm.UnitOfMeasure, VolumeUnits.CubicFeet);
            Assert.AreEqual(correctAnswer, vsm.ToString());
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbolWithCubicCentimeters()
        {
            VolumeOfVoids vv = new VolumeOfVoids(10, VolumeUnits.CubicCentimeters);
            VoidRatio vr = new VoidRatio(.1);
            VolumeOfSolidMatter vsm = new VolumeOfSolidMatter(vr, vv, VolumeUnits.CubicCentimeters);
            String correctAnswer = "V_s = 100 cc";
            Assert.AreEqual("V_s", vsm.Symbol);
            Assert.AreEqual(vsm.NumericValue, 100);
            Assert.AreEqual(vsm.UnitOfMeasure, VolumeUnits.CubicCentimeters);
            Assert.AreEqual(correctAnswer, vsm.ToString());
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbolWithM3()
        {
            VolumeOfVoids vv = new VolumeOfVoids(10, VolumeUnits.CubicCentimeters);
            VoidRatio vr = new VoidRatio(.1);
            VolumeOfSolidMatter vsm = new VolumeOfSolidMatter(vr, vv, VolumeUnits.CubicMeters);
            String correctAnswer = "V_s = 0 m^3";
            Assert.AreEqual("V_s", vsm.Symbol);
            Assert.AreEqual(vsm.NumericValue, 1e-4);
            Assert.AreEqual(vsm.UnitOfMeasure, VolumeUnits.CubicMeters);
            Assert.AreEqual(correctAnswer, vsm.ToString());
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbolWithFt3()
        {
            VolumeOfVoids vv = new VolumeOfVoids(10, VolumeUnits.CubicCentimeters);
            VoidRatio vr = new VoidRatio(.1);
            VolumeOfSolidMatter vsm = new VolumeOfSolidMatter(vr, vv, VolumeUnits.CubicFeet);
            String correctAnswer = "V_s = 0 ft^3";
            Assert.AreEqual("V_s", vsm.Symbol);
            Assert.AreEqual(Math.Round(vsm.NumericValue,5), 0.00353);
            Assert.AreEqual(vsm.UnitOfMeasure, VolumeUnits.CubicFeet);
            Assert.AreEqual(correctAnswer, vsm.ToString());
        }
    }
}
