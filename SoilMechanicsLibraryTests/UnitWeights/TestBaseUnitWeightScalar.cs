using System;
using NUnit.Framework;
using SoilMechanicsLibrary.UnitWeights;

namespace SoilMechanicsLibraryTests.UnitWeights
{
    public class TestBaseUnitWeightScalar
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor1ShouldStoreAndPrintValueAndSymbol()
        {
            BaseUnitWeightScalar buws = new BaseUnitWeightScalar("x", 10, UnitWeightUnits.GramPerCubicCentimeter);
            String correctAnswer = "x = 10 g/cc";
            Assert.AreEqual("x", buws.Symbol);
            Assert.AreEqual(buws.NumericValue, 10);
            Assert.AreEqual(buws.UnitOfMeasure, UnitWeightUnits.GramPerCubicCentimeter);
            Assert.AreEqual(correctAnswer, buws.ToString());
        }

        [Test]
        public void ConvertFromGramsPerCubicCentimeterToKilogramPerMeterCubed()
        {
            BaseUnitWeightScalar buws = new BaseUnitWeightScalar("x", 10, UnitWeightUnits.GramPerCubicCentimeter);
            BaseUnitWeightScalar converted = BaseUnitWeightScalar.ConvertToUnits(buws, UnitWeightUnits.KilogramPerMeterCubed);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(converted.NumericValue, 10000);
            Assert.AreEqual(converted.UnitOfMeasure, UnitWeightUnits.KilogramPerMeterCubed);
        }

        [Test]
        public void ConvertFromGramsPerCubicCentimeterToPoundPerFootCubed()
        {
            BaseUnitWeightScalar buws = new BaseUnitWeightScalar("x", 10, UnitWeightUnits.GramPerCubicCentimeter);
            BaseUnitWeightScalar converted = BaseUnitWeightScalar.ConvertToUnits(buws, UnitWeightUnits.PoundPerCubicFoot);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(converted.NumericValue, 624.28);
            Assert.AreEqual(converted.UnitOfMeasure, UnitWeightUnits.PoundPerCubicFoot);
        }

        [Test]
        public void ConvertFromGramsPerCubicCentimeterToGramPerCubicCentimeter()
        {
            BaseUnitWeightScalar buws = new BaseUnitWeightScalar("x", 10, UnitWeightUnits.GramPerCubicCentimeter);
            BaseUnitWeightScalar converted = BaseUnitWeightScalar.ConvertToUnits(buws, UnitWeightUnits.GramPerCubicCentimeter);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(converted.NumericValue, 10);
            Assert.AreEqual(converted.UnitOfMeasure, UnitWeightUnits.GramPerCubicCentimeter);
        }

        [Test]
        public void ConvertFromKilogramPerMeterCubedToGramsPerCubicCentimeter()
        {
            BaseUnitWeightScalar buws = new BaseUnitWeightScalar("x", 10, UnitWeightUnits.KilogramPerMeterCubed);
            BaseUnitWeightScalar converted = BaseUnitWeightScalar.ConvertToUnits(buws, UnitWeightUnits.GramPerCubicCentimeter);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(converted.NumericValue, .01);
            Assert.AreEqual(converted.UnitOfMeasure, UnitWeightUnits.GramPerCubicCentimeter);
        }

        [Test]
        public void ConvertFromKilogramPerMeterCubedToPoundPerFootCubed()
        {
            BaseUnitWeightScalar buws = new BaseUnitWeightScalar("x", 10, UnitWeightUnits.KilogramPerMeterCubed);
            BaseUnitWeightScalar converted = BaseUnitWeightScalar.ConvertToUnits(buws, UnitWeightUnits.PoundPerCubicFoot);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(Math.Round(converted.NumericValue, 3), 0.624);
            Assert.AreEqual(converted.UnitOfMeasure, UnitWeightUnits.PoundPerCubicFoot);
        }

        [Test]
        public void ConvertFromKilogramPerMeterCubedToKilogramPerMeterCubed()
        {
            BaseUnitWeightScalar buws = new BaseUnitWeightScalar("x", 10, UnitWeightUnits.KilogramPerMeterCubed);
            BaseUnitWeightScalar converted = BaseUnitWeightScalar.ConvertToUnits(buws, UnitWeightUnits.KilogramPerMeterCubed);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(converted.NumericValue, 10);
            Assert.AreEqual(converted.UnitOfMeasure, UnitWeightUnits.KilogramPerMeterCubed);
        }

        [Test]
        public void ConvertFromPoundPerFootCubedToKilogramPerMeterCubed()
        {
            BaseUnitWeightScalar buws = new BaseUnitWeightScalar("x", 10, UnitWeightUnits.PoundPerCubicFoot);
            BaseUnitWeightScalar converted = BaseUnitWeightScalar.ConvertToUnits(buws, UnitWeightUnits.KilogramPerMeterCubed);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(Math.Round(converted.NumericValue, 2), 160.18);
            Assert.AreEqual(converted.UnitOfMeasure, UnitWeightUnits.KilogramPerMeterCubed);
        }

        [Test]
        public void ConvertFromPoundPerFootCubedToGramPerCubicCentimeter()
        {
            BaseUnitWeightScalar buws = new BaseUnitWeightScalar("x", 10, UnitWeightUnits.PoundPerCubicFoot);
            BaseUnitWeightScalar converted = BaseUnitWeightScalar.ConvertToUnits(buws, UnitWeightUnits.GramPerCubicCentimeter);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(Math.Round(converted.NumericValue, 3), 0.160);
            Assert.AreEqual(converted.UnitOfMeasure, UnitWeightUnits.GramPerCubicCentimeter);
        }

        [Test]
        public void ConvertFromPoundPerFootCubedToPoundPerFootCubed()
        {
            BaseUnitWeightScalar buws = new BaseUnitWeightScalar("x", 10, UnitWeightUnits.PoundPerCubicFoot);
            BaseUnitWeightScalar converted = BaseUnitWeightScalar.ConvertToUnits(buws, UnitWeightUnits.PoundPerCubicFoot);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(converted.NumericValue, 10);
            Assert.AreEqual(converted.UnitOfMeasure, UnitWeightUnits.PoundPerCubicFoot);
        }
    }
}
