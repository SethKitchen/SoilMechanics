// <copyright file="BaseUnitWeightScalar.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.UnitWeights
{
    using System;
    using SoilMechanicsLibrary.Shared;

    /// <summary>
    /// Extends base scalar by adding the unit of measurement for unit weight.
    /// </summary>
    public class BaseUnitWeightScalar : BaseScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseUnitWeightScalar"/> class.
        /// </summary>
        /// <param name="symbol">LateX symbol for pretty print.</param>
        /// <param name="numericalValue">Decimal value for calculation.</param>
        /// <param name="units">Measurement unit (ie g/cc).</param>
        public BaseUnitWeightScalar(string symbol, double numericalValue, UnitWeightUnits units)
        {
            this.UnitOfMeasure = units;
            this.Symbol = symbol;
            this.NumericValue = numericalValue;
        }

        /// <summary>
        /// Gets or sets the measurement unit (ie g/cc).
        /// </summary>
        public UnitWeightUnits UnitOfMeasure { get; set; }

        /// <summary>
        /// Unit Weight conversion function from Metric to Metric, Metric to English, or vice versa.
        /// </summary>
        /// <param name="toConvert">Original, operating, unit weight.</param>
        /// <param name="toConvertTo">Measurement unit to convert into (ie g/cc).</param>
        /// <returns>A new unit weight with correct type and numeric value.</returns>
        public static BaseUnitWeightScalar ConvertToUnits(BaseUnitWeightScalar toConvert, UnitWeightUnits toConvertTo)
        {
            if (toConvert.UnitOfMeasure == toConvertTo)
            {
                return toConvert;
            }

            double newVal = toConvert.NumericValue;
            if (toConvert.UnitOfMeasure == UnitWeightUnits.GramPerCubicCentimeter && toConvertTo == UnitWeightUnits.KilogramPerMeterCubed)
            {
                newVal *= 1000.0;
            }
            else if (toConvert.UnitOfMeasure == UnitWeightUnits.GramPerCubicCentimeter && toConvertTo == UnitWeightUnits.PoundPerCubicFoot)
            {
                newVal *= 62.428;
            }
            else if (toConvert.UnitOfMeasure == UnitWeightUnits.KilogramPerMeterCubed && toConvertTo == UnitWeightUnits.GramPerCubicCentimeter)
            {
                newVal /= 1000.0;
            }
            else if (toConvert.UnitOfMeasure == UnitWeightUnits.KilogramPerMeterCubed && toConvertTo == UnitWeightUnits.PoundPerCubicFoot)
            {
                newVal /= 16.018;
            }
            else if (toConvert.UnitOfMeasure == UnitWeightUnits.PoundPerCubicFoot && toConvertTo == UnitWeightUnits.GramPerCubicCentimeter)
            {
                newVal /= 62.428;
            }
            else if (toConvert.UnitOfMeasure == UnitWeightUnits.PoundPerCubicFoot && toConvertTo == UnitWeightUnits.KilogramPerMeterCubed)
            {
                newVal *= 16.018;
            }

            BaseUnitWeightScalar toReturn = new BaseUnitWeightScalar(toConvert.Symbol, newVal, toConvertTo);
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
