using System;
using NUnit.Framework;
using SoilMechanicsLibrary.Volumes;

namespace SoilMechanicsLibraryTests.Volumes
{
    public class TestTotalVolume
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor1ShouldStoreAndPrintValueAndSymbol()
        {
            TotalVolume tv = new TotalVolume(10, VolumeUnits.CubicCentimeters);
            String correctAnswer = "V = 10 cc";
            Assert.AreEqual("V", tv.Symbol);
            Assert.AreEqual(tv.NumericValue, 10);
            Assert.AreEqual(tv.UnitOfMeasure, VolumeUnits.CubicCentimeters);
            Assert.AreEqual(correctAnswer, tv.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithCC()
        {
            VolumeOfSolidMatter vsm = new VolumeOfSolidMatter(10, VolumeUnits.CubicCentimeters);
            VolumeOfVoids vv = new VolumeOfVoids(10, VolumeUnits.CubicCentimeters);
            TotalVolume tv = new TotalVolume(vsm, vv, VolumeUnits.CubicCentimeters);
            String correctAnswer = "V = 20 cc";
            Assert.AreEqual("V", tv.Symbol);
            Assert.AreEqual(tv.NumericValue, 20);
            Assert.AreEqual(tv.UnitOfMeasure, VolumeUnits.CubicCentimeters);
            Assert.AreEqual(correctAnswer, tv.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithM3()
        {
            VolumeOfSolidMatter vsm = new VolumeOfSolidMatter(10, VolumeUnits.CubicCentimeters);
            VolumeOfVoids vv = new VolumeOfVoids(10, VolumeUnits.CubicCentimeters);
            TotalVolume tv = new TotalVolume(vsm, vv, VolumeUnits.CubicMeters);
            String correctAnswer = "V = 0 m^3";
            Assert.AreEqual("V", tv.Symbol);
            Assert.AreEqual(tv.NumericValue, 2e-5);
            Assert.AreEqual(tv.UnitOfMeasure, VolumeUnits.CubicMeters);
            Assert.AreEqual(correctAnswer, tv.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithFt3()
        {
            VolumeOfSolidMatter vsm = new VolumeOfSolidMatter(10, VolumeUnits.CubicCentimeters);
            VolumeOfVoids vv = new VolumeOfVoids(10, VolumeUnits.CubicCentimeters);
            TotalVolume tv = new TotalVolume(vsm, vv, VolumeUnits.CubicFeet);
            String correctAnswer = "V = 0 ft^3";
            Assert.AreEqual("V", tv.Symbol);
            Assert.AreEqual(Math.Round(tv.NumericValue,6), 0.000706);
            Assert.AreEqual(tv.UnitOfMeasure, VolumeUnits.CubicFeet);
            Assert.AreEqual(correctAnswer, tv.ToString());
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbolWithCC()
        {
            Porosity p = new Porosity(.1);
            VolumeOfVoids vv = new VolumeOfVoids(10, VolumeUnits.CubicCentimeters);
            TotalVolume tv = new TotalVolume(p, vv, VolumeUnits.CubicCentimeters);
            Assert.AreEqual("V", tv.Symbol);
            Assert.AreEqual(Math.Round(tv.NumericValue, 2), 100);
            Assert.AreEqual(tv.UnitOfMeasure, VolumeUnits.CubicCentimeters);
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbolWithM3()
        {
            Porosity p = new Porosity(.1);
            VolumeOfVoids vv = new VolumeOfVoids(10, VolumeUnits.CubicCentimeters);
            TotalVolume tv = new TotalVolume(p, vv, VolumeUnits.CubicMeters);
            Assert.AreEqual("V", tv.Symbol);
            Assert.AreEqual(Math.Round(tv.NumericValue, 5), 1e-4);
            Assert.AreEqual(tv.UnitOfMeasure, VolumeUnits.CubicMeters);
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbolWithFt3()
        {
            Porosity p = new Porosity(.1);
            VolumeOfVoids vv = new VolumeOfVoids(10, VolumeUnits.CubicCentimeters);
            TotalVolume tv = new TotalVolume(p, vv, VolumeUnits.CubicFeet);
            Assert.AreEqual("V", tv.Symbol);
            Assert.AreEqual(Math.Round(tv.NumericValue, 5), 0.00353);
            Assert.AreEqual(tv.UnitOfMeasure, VolumeUnits.CubicFeet);
        }
    }
}
