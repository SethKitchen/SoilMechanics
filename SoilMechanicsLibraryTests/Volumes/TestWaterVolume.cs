using System;
using NUnit.Framework;
using SoilMechanicsLibrary.Volumes;

namespace SoilMechanicsLibraryTests.Volumes
{
    public class TestWaterVolume
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor1ShouldStoreAndPrintValueAndSymbol()
        {
            WaterVolume wv = new WaterVolume(10, VolumeUnits.CubicCentimeters);
            String correctAnswer = "V_w = 10 cc";
            Assert.AreEqual("V_w", wv.Symbol);
            Assert.AreEqual(wv.NumericValue, 10);
            Assert.AreEqual(wv.UnitOfMeasure, VolumeUnits.CubicCentimeters);
            Assert.AreEqual(correctAnswer, wv.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithCubicCentimeters()
        {
            VolumeOfVoids vv = new VolumeOfVoids(20, VolumeUnits.CubicCentimeters);
            GasVolume gv = new GasVolume(10, VolumeUnits.CubicCentimeters);
            WaterVolume wv = new WaterVolume(vv, gv, VolumeUnits.CubicCentimeters);
            String correctAnswer = "V_w = 10 cc";
            Assert.AreEqual("V_w", wv.Symbol);
            Assert.AreEqual(wv.NumericValue, 10);
            Assert.AreEqual(wv.UnitOfMeasure, VolumeUnits.CubicCentimeters);
            Assert.AreEqual(correctAnswer, wv.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithM3()
        {
            VolumeOfVoids vv = new VolumeOfVoids(20, VolumeUnits.CubicCentimeters);
            GasVolume gv = new GasVolume(10, VolumeUnits.CubicCentimeters);
            WaterVolume wv = new WaterVolume(vv, gv, VolumeUnits.CubicMeters);
            String correctAnswer = "V_w = 0 m^3";
            Assert.AreEqual("V_w", wv.Symbol);
            Assert.AreEqual(wv.NumericValue, 1e-5);
            Assert.AreEqual(wv.UnitOfMeasure, VolumeUnits.CubicMeters);
            Assert.AreEqual(correctAnswer, wv.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithFt3()
        {
            VolumeOfVoids vv = new VolumeOfVoids(20, VolumeUnits.CubicCentimeters);
            GasVolume gv = new GasVolume(10, VolumeUnits.CubicCentimeters);
            WaterVolume wv = new WaterVolume(vv, gv, VolumeUnits.CubicFeet);
            String correctAnswer = "V_w = 0 ft^3";
            Assert.AreEqual("V_w", wv.Symbol);
            Assert.AreEqual(Math.Round(wv.NumericValue, 6), 0.000353);
            Assert.AreEqual(wv.UnitOfMeasure, VolumeUnits.CubicFeet);
            Assert.AreEqual(correctAnswer, wv.ToString());
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbolWithCubicCentimeters()
        {
            VolumeOfVoids vv = new VolumeOfVoids(10, VolumeUnits.CubicCentimeters);
            DegreeOfSaturation ds = new DegreeOfSaturation(.1);
            WaterVolume wv = new WaterVolume(ds, vv, VolumeUnits.CubicCentimeters);
            String correctAnswer = "V_w = 1 cc";
            Assert.AreEqual("V_w", wv.Symbol);
            Assert.AreEqual(wv.NumericValue, 1);
            Assert.AreEqual(wv.UnitOfMeasure, VolumeUnits.CubicCentimeters);
            Assert.AreEqual(correctAnswer, wv.ToString());
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbolWithM3()
        {
            VolumeOfVoids vv = new VolumeOfVoids(10, VolumeUnits.CubicCentimeters);
            DegreeOfSaturation ds = new DegreeOfSaturation(.1);
            WaterVolume wv = new WaterVolume(ds, vv, VolumeUnits.CubicMeters);
            String correctAnswer = "V_w = 0 m^3";
            Assert.AreEqual("V_w", wv.Symbol);
            Assert.AreEqual(Math.Round(wv.NumericValue,7), 1e-6);
            Assert.AreEqual(wv.UnitOfMeasure, VolumeUnits.CubicMeters);
            Assert.AreEqual(correctAnswer, wv.ToString());
        }

        [Test]
        public void Constructor3ShouldStoreAndPrintValueAndSymbolWithFt3()
        {
            VolumeOfVoids vv = new VolumeOfVoids(10, VolumeUnits.CubicCentimeters);
            DegreeOfSaturation ds = new DegreeOfSaturation(.1);
            WaterVolume wv = new WaterVolume(ds, vv, VolumeUnits.CubicFeet);
            String correctAnswer = "V_w = 0 ft^3";
            Assert.AreEqual("V_w", wv.Symbol);
            Assert.AreEqual(Math.Round(wv.NumericValue,7), 0.0000353);
            Assert.AreEqual(wv.UnitOfMeasure, VolumeUnits.CubicFeet);
            Assert.AreEqual(correctAnswer, wv.ToString());
        }
    }
}
