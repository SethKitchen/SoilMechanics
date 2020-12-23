// <copyright file="DegreeOfSaturation.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.Volumes
{
    using System;
    using SoilMechanicsLibrary.Shared;

    /// <summary>
    /// Ratio of Volume of Water to Volume of Voids.
    /// </summary>
    public class DegreeOfSaturation : BaseScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DegreeOfSaturation"/> class.
        /// </summary>
        /// <param name="numericalValue">Decimal value used for calculation.</param>
        public DegreeOfSaturation(double numericalValue)
        {
            this.Symbol = "S";
            this.NumericValue = numericalValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DegreeOfSaturation"/> class.
        /// </summary>
        /// <param name="waterVolume">V_w in S=V_w/V_v.</param>
        /// <param name="voidVolume">V_v in S=V_w/V_v.</param>
        public DegreeOfSaturation(WaterVolume waterVolume, VolumeOfVoids voidVolume)
        {
            this.Symbol = "S";
            var converted = BaseVolumeScalar.ConvertToUnits(waterVolume, voidVolume.UnitOfMeasure);
            this.NumericValue = converted.NumericValue / voidVolume.NumericValue;
        }

        /// <summary>
        /// [LateX symbol] = [Numeric Value] %.
        /// </summary>
        /// <returns>String representation ready to be pretty printed.</returns>
        public override string ToString()
        {
            return this.Symbol + " = " + Math.Round(this.NumericValue * 100, 2) + " %";
        }
    }
}
