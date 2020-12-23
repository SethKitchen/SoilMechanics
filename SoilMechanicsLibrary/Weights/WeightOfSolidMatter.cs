// <copyright file="WeightOfSolidMatter.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.Weights
{
    /// <summary>
    /// <see cref="TotalWeight"/>. This relates to just solid matter.
    /// </summary>
    public class WeightOfSolidMatter : BaseWeightScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeightOfSolidMatter"/> class.
        /// </summary>
        /// <param name="numericalValue">Decimal value to use in calculation.</param>
        /// <param name="units">Measurement unit (ie kg).</param>
        public WeightOfSolidMatter(double numericalValue, WeightUnits units)
            : base("W_s", numericalValue, units)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeightOfSolidMatter"/> class.
        /// </summary>
        /// <param name="waterWeight">W_w in W=W_w+W_s.</param>
        /// <param name="totalWeight">W in W=W_w+W_s.</param>
        /// <param name="units">Measurement unit to hold value after initial calculation (ie kg).</param>
        public WeightOfSolidMatter(WeightOfWater waterWeight, TotalWeight totalWeight, WeightUnits units)
            : this(ConvertToUnits(totalWeight, units).NumericValue - ConvertToUnits(waterWeight, units).NumericValue, units)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeightOfSolidMatter"/> class.
        /// </summary>
        /// <param name="waterContent">w in w=W_w/W_s.</param>
        /// <param name="waterWeight">W_w in w=W_w/W_s.</param>
        /// <param name="units">Measurement unit to hold value after initial calculation (ie kg).</param>
        public WeightOfSolidMatter(WaterContent waterContent, WeightOfWater waterWeight, WeightUnits units)
            : this(BaseWeightScalar.ConvertToUnits(waterWeight, units).NumericValue / waterContent.NumericValue, units)
        {
        }
    }
}
