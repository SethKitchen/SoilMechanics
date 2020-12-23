// <copyright file="BaseVolumeScalar.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.Volumes
{
    using System;
    using SoilMechanicsLibrary.Shared;

    /// <summary>
    /// Extends base scalar by adding the unit of measurement for unit weight.
    /// </summary>
    public class BaseVolumeScalar : BaseScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseVolumeScalar"/> class.
        /// </summary>
        /// <param name="symbol">LateX symbol for pretty print.</param>
        /// <param name="numericalValue">Decimal value for calculation.</param>
        /// <param name="units">Measurement unit (ie cc).</param>
        public BaseVolumeScalar(string symbol, double numericalValue, VolumeUnits units)
        {
            this.UnitOfMeasure = units;
            this.Symbol = symbol;
            this.NumericValue = numericalValue;
        }

        /// <summary>
        /// Gets or sets the measurement unit (ie cc).
        /// </summary>
        public VolumeUnits UnitOfMeasure { get; set; }

        /// <summary>
        /// Unit Weight conversion function from Metric to Metric, Metric to English, or vice versa.
        /// </summary>
        /// <param name="toConvert">Original, operating, unit weight.</param>
        /// <param name="toConvertTo">Measurement unit to convert into (ie cc).</param>
        /// <returns>A new unit weight with correct type and numeric value.</returns>
        public static BaseVolumeScalar ConvertToUnits(BaseVolumeScalar toConvert, VolumeUnits toConvertTo)
        {
            if (toConvert.UnitOfMeasure == toConvertTo)
            {
                return toConvert;
            }

            double newVal = toConvert.NumericValue;
            if (toConvert.UnitOfMeasure == VolumeUnits.CubicCentimeters && toConvertTo == VolumeUnits.CubicMeters)
            {
                newVal /= 1e6;
            }
            else if (toConvert.UnitOfMeasure == VolumeUnits.CubicCentimeters && toConvertTo == VolumeUnits.CubicFeet)
            {
                newVal /= 28317;
            }
            else if (toConvert.UnitOfMeasure == VolumeUnits.CubicFeet && toConvertTo == VolumeUnits.CubicCentimeters)
            {
                newVal *= 28317;
            }
            else if (toConvert.UnitOfMeasure == VolumeUnits.CubicFeet && toConvertTo == VolumeUnits.CubicMeters)
            {
                newVal /= 35.315;
            }
            else if (toConvert.UnitOfMeasure == VolumeUnits.CubicMeters && toConvertTo == VolumeUnits.CubicCentimeters)
            {
                newVal *= 1e6;
            }
            else if (toConvert.UnitOfMeasure == VolumeUnits.CubicMeters && toConvertTo == VolumeUnits.CubicFeet)
            {
                newVal *= 35.315;
            }

            BaseVolumeScalar toReturn = new BaseVolumeScalar(toConvert.Symbol, newVal, toConvertTo);
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
