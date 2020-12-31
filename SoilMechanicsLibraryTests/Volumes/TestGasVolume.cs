using System;
using NUnit.Framework;
using SoilMechanicsLibrary.Volumes;

namespace SoilMechanicsLibraryTests.Volumes
{
    public class TestGasVolume
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor1ShouldStoreAndPrintValueAndSymbol()
        {
            GasVolume gv = new GasVolume(10, VolumeUnits.CubicCentimeters);
            String correctAnswer = "V_g = 10 cc";
            Assert.AreEqual("V_g", gv.Symbol);
            Assert.AreEqual(gv.NumericValue, 10);
            Assert.AreEqual(gv.UnitOfMeasure, VolumeUnits.CubicCentimeters);
            Assert.AreEqual(correctAnswer, gv.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithCubicCentimeters()
        {
            VolumeOfVoids vv = new VolumeOfVoids(20, VolumeUnits.CubicCentimeters);
            WaterVolume wv = new WaterVolume(10, VolumeUnits.CubicCentimeters);
            GasVolume gv = new GasVolume(vv, wv, VolumeUnits.CubicCentimeters);
            String correctAnswer = "V_g = 10 cc";
            Assert.AreEqual("V_g", gv.Symbol);
            Assert.AreEqual(gv.NumericValue, 10);
            Assert.AreEqual(gv.UnitOfMeasure, VolumeUnits.CubicCentimeters);
            Assert.AreEqual(correctAnswer, gv.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithM3()
        {
            VolumeOfVoids vv = new VolumeOfVoids(20, VolumeUnits.CubicCentimeters);
            WaterVolume wv = new WaterVolume(10, VolumeUnits.CubicCentimeters);
            GasVolume gv = new GasVolume(vv, wv, VolumeUnits.CubicMeters);
            String correctAnswer = "V_g = 0 m^3";
            Assert.AreEqual("V_g", gv.Symbol);
            Assert.AreEqual(gv.NumericValue, 1e-5);
            Assert.AreEqual(gv.UnitOfMeasure, VolumeUnits.CubicMeters);
            Assert.AreEqual(correctAnswer, gv.ToString());
        }

        [Test]
        public void Constructor2ShouldStoreAndPrintValueAndSymbolWithPounds()
        {
            VolumeOfVoids vv = new VolumeOfVoids(20, VolumeUnits.CubicCentimeters);
            WaterVolume wv = new WaterVolume(10, VolumeUnits.CubicCentimeters);
            GasVolume gv = new GasVolume(vv, wv, VolumeUnits.CubicFeet);
            String correctAnswer = "V_g = 0 ft^3";
            Assert.AreEqual("V_g", gv.Symbol);
            Assert.AreEqual(Math.Round(gv.NumericValue, 6), 0.000353);
            Assert.AreEqual(gv.UnitOfMeasure, VolumeUnits.CubicFeet);
            Assert.AreEqual(correctAnswer, gv.ToString());
        }
    }
}
