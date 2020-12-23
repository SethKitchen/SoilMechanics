// <copyright file="Porosity.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.Volumes
{
    using System;
    using SoilMechanicsLibrary.Shared;

    /// <summary>
    /// p. 13 "Ratio of the Volume of Voids to the total volume of the mass".
    /// </summary>
    public class Porosity : BaseScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Porosity"/> class.
        /// </summary>
        /// <param name="numericalValue">Decimal value used for calculations.</param>
        public Porosity(double numericalValue)
        {
            this.Symbol = "n";
            this.NumericValue = numericalValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Porosity"/> class.
        /// </summary>
        /// <param name="voidVolume">V_v in n=V_v/V.</param>
        /// <param name="totalVolume">V in n=V_v/V.</param>
        public Porosity(VolumeOfVoids voidVolume, TotalVolume totalVolume)
        {
            this.Symbol = "n";
            var converted = BaseVolumeScalar.ConvertToUnits(voidVolume, totalVolume.UnitOfMeasure);
            this.NumericValue = converted.NumericValue / totalVolume.NumericValue;
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
