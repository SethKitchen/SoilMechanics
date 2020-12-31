using System;
using NUnit.Framework;
using SoilMechanicsLibrary.Volumes;

namespace SoilMechanicsLibraryTests.Volumes
{
    public class TestBaseVolumeScalar
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor1ShouldStoreAndPrintValueAndSymbol()
        {
            BaseVolumeScalar bvs = new BaseVolumeScalar("x", 10, VolumeUnits.CubicCentimeters);
            String correctAnswer = "x = 10 cc";
            Assert.AreEqual("x", bvs.Symbol);
            Assert.AreEqual(bvs.NumericValue, 10);
            Assert.AreEqual(bvs.UnitOfMeasure, VolumeUnits.CubicCentimeters);
            Assert.AreEqual(correctAnswer, bvs.ToString());
        }

        [Test]
        public void ConvertFromCCToM3()
        {
            BaseVolumeScalar bvs = new BaseVolumeScalar("x", 10, VolumeUnits.CubicCentimeters);
            BaseVolumeScalar converted = BaseVolumeScalar.ConvertToUnits(bvs, VolumeUnits.CubicMeters);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(Math.Round(converted.NumericValue, 6), 1e-5);
            Assert.AreEqual(converted.UnitOfMeasure, VolumeUnits.CubicMeters);
        }

        [Test]
        public void ConvertFromCCToFt3()
        {
            BaseVolumeScalar bvs = new BaseVolumeScalar("x", 10, VolumeUnits.CubicCentimeters);
            BaseVolumeScalar converted = BaseVolumeScalar.ConvertToUnits(bvs, VolumeUnits.CubicFeet);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(Math.Round(converted.NumericValue, 5), 0.00035);
            Assert.AreEqual(converted.UnitOfMeasure, VolumeUnits.CubicFeet);
        }

        [Test]
        public void ConvertFromCCToCC()
        {
            BaseVolumeScalar bvs = new BaseVolumeScalar("x", 10, VolumeUnits.CubicCentimeters);
            BaseVolumeScalar converted = BaseVolumeScalar.ConvertToUnits(bvs, VolumeUnits.CubicCentimeters);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(converted.NumericValue, 10);
            Assert.AreEqual(converted.UnitOfMeasure, VolumeUnits.CubicCentimeters);
        }

        [Test]
        public void ConvertFromM3ToCC()
        {
            BaseVolumeScalar bvs = new BaseVolumeScalar("x", 10, VolumeUnits.CubicMeters);
            BaseVolumeScalar converted = BaseVolumeScalar.ConvertToUnits(bvs, VolumeUnits.CubicCentimeters);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(converted.NumericValue, 1e7);
            Assert.AreEqual(converted.UnitOfMeasure, VolumeUnits.CubicCentimeters);
        }

        [Test]
        public void ConvertFromM3ToFt3()
        {
            BaseVolumeScalar bvs = new BaseVolumeScalar("x", 10, VolumeUnits.CubicMeters);
            BaseVolumeScalar converted = BaseVolumeScalar.ConvertToUnits(bvs, VolumeUnits.CubicFeet);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(Math.Round(converted.NumericValue, 3), 353.147);
            Assert.AreEqual(converted.UnitOfMeasure, VolumeUnits.CubicFeet);
        }

        [Test]
        public void ConvertFromM3ToM3()
        {
            BaseVolumeScalar bvs = new BaseVolumeScalar("x", 10, VolumeUnits.CubicMeters);
            BaseVolumeScalar converted = BaseVolumeScalar.ConvertToUnits(bvs, VolumeUnits.CubicMeters);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(converted.NumericValue, 10);
            Assert.AreEqual(converted.UnitOfMeasure, VolumeUnits.CubicMeters);
        }

        [Test]
        public void ConvertFromFt3ToCC()
        {
            BaseVolumeScalar bvs = new BaseVolumeScalar("x", 10, VolumeUnits.CubicFeet);
            BaseVolumeScalar converted = BaseVolumeScalar.ConvertToUnits(bvs, VolumeUnits.CubicCentimeters);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(Math.Round(converted.NumericValue, 2), 283168.2);
            Assert.AreEqual(converted.UnitOfMeasure, VolumeUnits.CubicCentimeters);
        }

        [Test]
        public void ConvertFromFt3ToM3()
        {
            BaseVolumeScalar bvs = new BaseVolumeScalar("x", 10, VolumeUnits.CubicFeet);
            BaseVolumeScalar converted = BaseVolumeScalar.ConvertToUnits(bvs, VolumeUnits.CubicMeters);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(Math.Round(converted.NumericValue, 3), .283);
            Assert.AreEqual(converted.UnitOfMeasure, VolumeUnits.CubicMeters);
        }

        [Test]
        public void ConvertFromFt3ToFt3()
        {
            BaseVolumeScalar bvs = new BaseVolumeScalar("x", 10, VolumeUnits.CubicFeet);
            BaseVolumeScalar converted = BaseVolumeScalar.ConvertToUnits(bvs, VolumeUnits.CubicFeet);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(converted.NumericValue, 10);
            Assert.AreEqual(converted.UnitOfMeasure, VolumeUnits.CubicFeet);
        }
    }
}
