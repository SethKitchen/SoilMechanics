// <copyright file="BaseWeightScalar.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.Weights
{
    using System;
    using SoilMechanicsLibrary.Shared;

    /// <summary>
    /// Extends base scalar by adding the unit of measurement for weight.
    /// </summary>
    public class BaseWeightScalar : BaseScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseWeightScalar"/> class.
        /// </summary>
        /// <param name="symbol">LateX symbol for pretty print.</param>
        /// <param name="numericalValue">Decimal value used for calculations.</param>
        /// <param name="units">Measurement unit (ie kg).</param>
        public BaseWeightScalar(string symbol, double numericalValue, WeightUnits units)
        {
            this.UnitOfMeasure = units;
            this.Symbol = symbol;
            this.NumericValue = numericalValue;
        }

        /// <summary>
        /// Gets or sets the measurement unit (ie kg).
        /// </summary>
        public WeightUnits UnitOfMeasure { get; set; }

        /// <summary>
        /// Unit Weight conversion function from Metric to Metric, Metric to English, or vice versa.
        /// </summary>
        /// <param name="toConvert">Original, operating, weight.</param>
        /// <param name="toConvertTo">Measurement unit to convert into (ie kg).</param>
        /// <returns>A new weight with correct type and numeric value.</returns>
        public static BaseWeightScalar ConvertToUnits(BaseWeightScalar toConvert, WeightUnits toConvertTo)
        {
            if (toConvert.UnitOfMeasure == toConvertTo)
            {
                return toConvert;
            }

            double newVal = toConvert.NumericValue;
            if (toConvert.UnitOfMeasure == WeightUnits.Grams && toConvertTo == WeightUnits.Kilograms)
            {
                newVal /= 1000.0;
            }
            else if (toConvert.UnitOfMeasure == WeightUnits.Grams && toConvertTo == WeightUnits.Pounds)
            {
                newVal /= 453.592;
            }
            else if (toConvert.UnitOfMeasure == WeightUnits.Kilograms && toConvertTo == WeightUnits.Pounds)
            {
                newVal *= 2.205;
            }
            else if (toConvert.UnitOfMeasure == WeightUnits.Kilograms && toConvertTo == WeightUnits.Grams)
            {
                newVal *= 1000.0;
            }
            else if (toConvert.UnitOfMeasure == WeightUnits.Pounds && toConvertTo == WeightUnits.Grams)
            {
                newVal *= 453.592;
            }
            else if (toConvert.UnitOfMeasure == WeightUnits.Pounds && toConvertTo == WeightUnits.Kilograms)
            {
                newVal /= 2.205;
            }

            BaseWeightScalar toReturn = new BaseWeightScalar(toConvert.Symbol, newVal, toConvertTo);
            return toReturn;
        }

        /// <summary>
        /// [LateX symbol] = [Numeric Value] [Units].
        /// </summary>
        /// <returns>String representation ready to be pretty printed.</returns>
        public override string ToString()
        {
            return this.Symbol + " = " + Math.Round(this.NumericValue, 2) + " " + Utils.GetDescription(this.UnitOfMeasure);
        }
    }
}
