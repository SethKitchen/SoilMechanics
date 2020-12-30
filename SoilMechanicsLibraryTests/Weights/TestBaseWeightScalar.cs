using System;
using NUnit.Framework;
using SoilMechanicsLibrary.Weights;

namespace SoilMechanicsLibraryTests.Weights
{
    public class TestBaseWeightScalar
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor1ShouldStoreAndPrintValueAndSymbol()
        {
            BaseWeightScalar bws = new BaseWeightScalar("x", 10, WeightUnits.Grams);
            String correctAnswer = "x = 10 g";
            Assert.AreEqual("x", bws.Symbol);
            Assert.AreEqual(bws.NumericValue, 10);
            Assert.AreEqual(bws.UnitOfMeasure, WeightUnits.Grams);
            Assert.AreEqual(correctAnswer, bws.ToString());
        }

        [Test]
        public void ConvertFromGramsToKilograms()
        {
            BaseWeightScalar bws = new BaseWeightScalar("x", 10, WeightUnits.Grams);
            BaseWeightScalar converted = BaseWeightScalar.ConvertToUnits(bws, WeightUnits.Kilograms);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(Math.Round(converted.NumericValue,2), .01);
            Assert.AreEqual(converted.UnitOfMeasure, WeightUnits.Kilograms);
        }

        [Test]
        public void ConvertFromGramsToPounds()
        {
            BaseWeightScalar bws = new BaseWeightScalar("x", 10, WeightUnits.Grams);
            BaseWeightScalar converted = BaseWeightScalar.ConvertToUnits(bws, WeightUnits.Pounds);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(Math.Round(converted.NumericValue,3), 0.022);
            Assert.AreEqual(converted.UnitOfMeasure, WeightUnits.Pounds);
        }

        [Test]
        public void ConvertFromGramsToGrams()
        {
            BaseWeightScalar bws = new BaseWeightScalar("x", 10, WeightUnits.Grams);
            BaseWeightScalar converted = BaseWeightScalar.ConvertToUnits(bws, WeightUnits.Grams);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(converted.NumericValue, 10);
            Assert.AreEqual(converted.UnitOfMeasure, WeightUnits.Grams);
        }

        [Test]
        public void ConvertFromKilogramsToGrams()
        {
            BaseWeightScalar bws = new BaseWeightScalar("x", 10, WeightUnits.Kilograms);
            BaseWeightScalar converted = BaseWeightScalar.ConvertToUnits(bws, WeightUnits.Grams);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(converted.NumericValue, 10000);
            Assert.AreEqual(converted.UnitOfMeasure, WeightUnits.Grams);
        }

        [Test]
        public void ConvertFromKilogramsToPounds()
        {
            BaseWeightScalar bws = new BaseWeightScalar("x", 10, WeightUnits.Kilograms);
            BaseWeightScalar converted = BaseWeightScalar.ConvertToUnits(bws, WeightUnits.Pounds);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(Math.Round(converted.NumericValue, 2), 22.05);
            Assert.AreEqual(converted.UnitOfMeasure, WeightUnits.Pounds);
        }

        [Test]
        public void ConvertFromKilogramsToKilograms()
        {
            BaseWeightScalar buws = new BaseWeightScalar("x", 10, WeightUnits.Kilograms);
            BaseWeightScalar converted = BaseWeightScalar.ConvertToUnits(buws, WeightUnits.Kilograms);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(converted.NumericValue, 10);
            Assert.AreEqual(converted.UnitOfMeasure, WeightUnits.Kilograms);
        }

        [Test]
        public void ConvertFromPoundsToKilograms()
        {
            BaseWeightScalar bws = new BaseWeightScalar("x", 10, WeightUnits.Pounds);
            BaseWeightScalar converted = BaseWeightScalar.ConvertToUnits(bws, WeightUnits.Kilograms);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(Math.Round(converted.NumericValue, 2), 4.54);
            Assert.AreEqual(converted.UnitOfMeasure, WeightUnits.Kilograms);
        }

        [Test]
        public void ConvertFromPoundsToGrams()
        {
            BaseWeightScalar bws = new BaseWeightScalar("x", 10, WeightUnits.Pounds);
            BaseWeightScalar converted = BaseWeightScalar.ConvertToUnits(bws, WeightUnits.Grams);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(Math.Round(converted.NumericValue, 1), 4535.9);
            Assert.AreEqual(converted.UnitOfMeasure, WeightUnits.Grams);
        }

        [Test]
        public void ConvertFromPoundsToPounds()
        {
            BaseWeightScalar bws = new BaseWeightScalar("x", 10, WeightUnits.Pounds);
            BaseWeightScalar converted = BaseWeightScalar.ConvertToUnits(bws, WeightUnits.Pounds);
            Assert.AreEqual("x", converted.Symbol);
            Assert.AreEqual(converted.NumericValue, 10);
            Assert.AreEqual(converted.UnitOfMeasure, WeightUnits.Pounds);
        }
    }
}
