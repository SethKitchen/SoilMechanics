using System;
using NUnit.Framework;
using SoilMechanicsLibrary.Volumes;

namespace SoilMechanicsLibraryTests.Volumes
{
    public class TestVolumeOfVoids
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor1ShouldStoreAndPrintValueAndSymbol()
        {
            VolumeOfVoids vv = new VolumeOfVoids(10, VolumeUnits.CubicCentimeters);
            String correctAnswer = "V_v = 10 cc";
            Assert.AreEqual("V_v", vv.Symbol);
            Assert.AreEqual(vv.NumericValue, 10);
            Assert.AreEqual(vv.UnitOfMeasure, VolumeUnits.CubicCentimeters);
            Assert.AreEqual(correctAnswer, vv.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithCubicCentimeters()
        {
            WaterVolume wv = new WaterVolume(10, VolumeUnits.CubicCentimeters);
            GasVolume gv = new GasVolume(10, VolumeUnits.CubicCentimeters);
            VolumeOfVoids vv = new VolumeOfVoids(wv, gv, VolumeUnits.CubicCentimeters);
            String correctAnswer = "V_v = 20 cc";
            Assert.AreEqual("V_v", vv.Symbol);
            Assert.AreEqual(vv.NumericValue, 20);
            Assert.AreEqual(vv.UnitOfMeasure, VolumeUnits.CubicCentimeters);
            Assert.AreEqual(correctAnswer, vv.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithFt3()
        {
            WaterVolume wv = new WaterVolume(10, VolumeUnits.CubicCentimeters);
            GasVolume gv = new GasVolume(10, VolumeUnits.CubicCentimeters);
            VolumeOfVoids vv = new VolumeOfVoids(wv, gv, VolumeUnits.CubicFeet);
            String correctAnswer = "V_v = 0 ft^3";
            Assert.AreEqual("V_v", vv.Symbol);
            Assert.AreEqual(Math.Round(vv.NumericValue,6), 0.000706);
            Assert.AreEqual(vv.UnitOfMeasure, VolumeUnits.CubicFeet);
            Assert.AreEqual(correctAnswer, vv.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithM3()
        {
            WaterVolume wv = new WaterVolume(10, VolumeUnits.CubicCentimeters);
            GasVolume gv = new GasVolume(10, VolumeUnits.CubicCentimeters);
            VolumeOfVoids vv = new VolumeOfVoids(wv, gv, VolumeUnits.CubicMeters);
            String correctAnswer = "V_v = 0 m^3";
            Assert.AreEqual("V_v", vv.Symbol);
            Assert.AreEqual(Math.Round(vv.NumericValue, 6), 2e-5);
            Assert.AreEqual(vv.UnitOfMeasure, VolumeUnits.CubicMeters);
            Assert.AreEqual(correctAnswer, vv.ToString());
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbolWithCubicCentimeters()
        {
            VolumeOfSolidMatter vsm = new VolumeOfSolidMatter(10, VolumeUnits.CubicCentimeters);
            TotalVolume tv = new TotalVolume(20, VolumeUnits.CubicCentimeters);
            VolumeOfVoids vv = new VolumeOfVoids(vsm, tv, VolumeUnits.CubicCentimeters);
            String correctAnswer = "V_v = 10 cc";
            Assert.AreEqual("V_v", vv.Symbol);
            Assert.AreEqual(vv.NumericValue, 10);
            Assert.AreEqual(vv.UnitOfMeasure, VolumeUnits.CubicCentimeters);
            Assert.AreEqual(correctAnswer, vv.ToString());
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbolWithFt3()
        {
            VolumeOfSolidMatter vsm = new VolumeOfSolidMatter(10, VolumeUnits.CubicCentimeters);
            TotalVolume tv = new TotalVolume(20, VolumeUnits.CubicCentimeters);
            VolumeOfVoids vv = new VolumeOfVoids(vsm, tv, VolumeUnits.CubicFeet);
            String correctAnswer = "V_v = 0 ft^3";
            Assert.AreEqual("V_v", vv.Symbol);
            Assert.AreEqual(Math.Round(vv.NumericValue,6), 0.000353);
            Assert.AreEqual(vv.UnitOfMeasure, VolumeUnits.CubicFeet);
            Assert.AreEqual(correctAnswer, vv.ToString());
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbolWithM3()
        {
            VolumeOfSolidMatter vsm = new VolumeOfSolidMatter(10, VolumeUnits.CubicCentimeters);
            TotalVolume tv = new TotalVolume(20, VolumeUnits.CubicCentimeters);
            VolumeOfVoids vv = new VolumeOfVoids(vsm, tv, VolumeUnits.CubicMeters);
            String correctAnswer = "V_v = 0 m^3";
            Assert.AreEqual("V_v", vv.Symbol);
            Assert.AreEqual(Math.Round(vv.NumericValue, 6), 1e-5);
            Assert.AreEqual(vv.UnitOfMeasure, VolumeUnits.CubicMeters);
            Assert.AreEqual(correctAnswer, vv.ToString());
        }

        [Test]
        public void Constructor4ShouldStoreAndPrintValueAndSymbolWithCubicCentimeters()
        {
            Porosity p = new Porosity(.1);
            TotalVolume tv = new TotalVolume(10, VolumeUnits.CubicCentimeters);
            VolumeOfVoids vv = new VolumeOfVoids(p, tv, VolumeUnits.CubicCentimeters);
            String correctAnswer = "V_v = 1 cc";
            Assert.AreEqual("V_v", vv.Symbol);
            Assert.AreEqual(vv.NumericValue, 1);
            Assert.AreEqual(vv.UnitOfMeasure, VolumeUnits.CubicCentimeters);
            Assert.AreEqual(correctAnswer, vv.ToString());
        }

        [Test]
        public void Constructor4ShouldStoreAndPrintValueAndSymbolWithFt3()
        {
            Porosity p = new Porosity(.1);
            TotalVolume tv = new TotalVolume(10, VolumeUnits.CubicCentimeters);
            VolumeOfVoids vv = new VolumeOfVoids(p, tv, VolumeUnits.CubicFeet);
            String correctAnswer = "V_v = 0 ft^3";
            Assert.AreEqual("V_v", vv.Symbol);
            Assert.AreEqual(Math.Round(vv.NumericValue, 6), 0.000035);
            Assert.AreEqual(vv.UnitOfMeasure, VolumeUnits.CubicFeet);
            Assert.AreEqual(correctAnswer, vv.ToString());
        }

        [Test]
        public void Constructor4ShouldStoreAndPrintValueAndSymbolWithM3()
        {
            Porosity p = new Porosity(.1);
            TotalVolume tv = new TotalVolume(10, VolumeUnits.CubicCentimeters);
            VolumeOfVoids vv = new VolumeOfVoids(p, tv, VolumeUnits.CubicMeters);
            String correctAnswer = "V_v = 0 m^3";
            Assert.AreEqual("V_v", vv.Symbol);
            Assert.AreEqual(Math.Round(vv.NumericValue, 6), 1e-6);
            Assert.AreEqual(vv.UnitOfMeasure, VolumeUnits.CubicMeters);
            Assert.AreEqual(correctAnswer, vv.ToString());
        }

        [Test]
        public void Constructor5ShouldStoreAndPrintValueAndSymbolWithCubicCentimeters()
        {
            VoidRatio vr = new VoidRatio(.1);
            VolumeOfSolidMatter vsm = new VolumeOfSolidMatter(10, VolumeUnits.CubicCentimeters);
            VolumeOfVoids vv = new VolumeOfVoids(vr, vsm, VolumeUnits.CubicCentimeters);
            String correctAnswer = "V_v = 1 cc";
            Assert.AreEqual("V_v", vv.Symbol);
            Assert.AreEqual(vv.NumericValue, 1);
            Assert.AreEqual(vv.UnitOfMeasure, VolumeUnits.CubicCentimeters);
            Assert.AreEqual(correctAnswer, vv.ToString());
        }

        [Test]
        public void Constructor5ShouldStoreAndPrintValueAndSymbolWithFt3()
        {
            VoidRatio vr = new VoidRatio(.1);
            VolumeOfSolidMatter vsm = new VolumeOfSolidMatter(10, VolumeUnits.CubicCentimeters);
            VolumeOfVoids vv = new VolumeOfVoids(vr, vsm, VolumeUnits.CubicFeet);
            String correctAnswer = "V_v = 0 ft^3";
            Assert.AreEqual("V_v", vv.Symbol);
            Assert.AreEqual(Math.Round(vv.NumericValue, 6), 0.000035);
            Assert.AreEqual(vv.UnitOfMeasure, VolumeUnits.CubicFeet);
            Assert.AreEqual(correctAnswer, vv.ToString());
        }

        [Test]
        public void Constructor5ShouldStoreAndPrintValueAndSymbolWithM3()
        {
            VoidRatio vr = new VoidRatio(.1);
            VolumeOfSolidMatter vsm = new VolumeOfSolidMatter(10, VolumeUnits.CubicCentimeters);
            VolumeOfVoids vv = new VolumeOfVoids(vr, vsm, VolumeUnits.CubicMeters);
            String correctAnswer = "V_v = 0 m^3";
            Assert.AreEqual("V_v", vv.Symbol);
            Assert.AreEqual(Math.Round(vv.NumericValue, 6), 1e-6);
            Assert.AreEqual(vv.UnitOfMeasure, VolumeUnits.CubicMeters);
            Assert.AreEqual(correctAnswer, vv.ToString());
        }

        [Test]
        public void Constructor6ShouldStoreAndPrintValueAndSymbolWithCubicCentimeters()
        {
            DegreeOfSaturation ds = new DegreeOfSaturation(.1);
            WaterVolume wv = new WaterVolume(10, VolumeUnits.CubicCentimeters);
            VolumeOfVoids vv = new VolumeOfVoids(ds, wv, VolumeUnits.CubicCentimeters);
            String correctAnswer = "V_v = 100 cc";
            Assert.AreEqual("V_v", vv.Symbol);
            Assert.AreEqual(vv.NumericValue, 100);
            Assert.AreEqual(vv.UnitOfMeasure, VolumeUnits.CubicCentimeters);
            Assert.AreEqual(correctAnswer, vv.ToString());
        }

        [Test]
        public void Constructor6ShouldStoreAndPrintValueAndSymbolWithFt3()
        {
            DegreeOfSaturation ds = new DegreeOfSaturation(.1);
            WaterVolume wv = new WaterVolume(10, VolumeUnits.CubicCentimeters);
            VolumeOfVoids vv = new VolumeOfVoids(ds, wv, VolumeUnits.CubicFeet);
            String correctAnswer = "V_v = 0 ft^3";
            Assert.AreEqual("V_v", vv.Symbol);
            Assert.AreEqual(Math.Round(vv.NumericValue, 4), 0.0035);
            Assert.AreEqual(vv.UnitOfMeasure, VolumeUnits.CubicFeet);
            Assert.AreEqual(correctAnswer, vv.ToString());
        }

        [Test]
        public void Constructor6ShouldStoreAndPrintValueAndSymbolWithM3()
        {
            DegreeOfSaturation ds = new DegreeOfSaturation(.1);
            WaterVolume wv = new WaterVolume(10, VolumeUnits.CubicCentimeters);
            VolumeOfVoids vv = new VolumeOfVoids(ds, wv, VolumeUnits.CubicMeters);
            String correctAnswer = "V_v = 0 m^3";
            Assert.AreEqual("V_v", vv.Symbol);
            Assert.AreEqual(Math.Round(vv.NumericValue, 4), 1e-4);
            Assert.AreEqual(vv.UnitOfMeasure, VolumeUnits.CubicMeters);
            Assert.AreEqual(correctAnswer, vv.ToString());
        }
    }
}
