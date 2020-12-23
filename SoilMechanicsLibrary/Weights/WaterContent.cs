// <copyright file="WaterContent.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.Weights
{
    using System;
    using SoilMechanicsLibrary.Shared;

    /// <summary>
    /// p. 13 "ratio of weight of water to weight of solid matter".
    /// NOT the same as geology which is a percentage of the total weight.
    /// </summary>
    public class WaterContent : BaseScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WaterContent"/> class.
        /// </summary>
        /// <param name="numericalValue">Decimal value used for calculation.</param>
        public WaterContent(double numericalValue)
        {
            this.Symbol = "w";
            this.NumericValue = numericalValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WaterContent"/> class.
        /// </summary>
        /// <param name="solidWeight">W_s in w=W_w/W_s.</param>
        /// <param name="waterWeight">W_w in w=W_w/W_s.</param>
        public WaterContent(WeightOfSolidMatter solidWeight, WeightOfWater waterWeight)
        {
            this.Symbol = "w";
            var converted = BaseWeightScalar.ConvertToUnits(solidWeight, waterWeight.UnitOfMeasure);
            this.NumericValue = waterWeight.NumericValue / converted.NumericValue;
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
