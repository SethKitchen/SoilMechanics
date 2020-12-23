// <copyright file="WeightOfWater.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.Weights
{
    /// <summary>
    /// <see cref="TotalWeight"/>. This portion is solely water matter.
    /// </summary>
    public class WeightOfWater : BaseWeightScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeightOfWater"/> class.
        /// </summary>
        /// <param name="numericalValue">Decimal value to use in calculations.</param>
        /// <param name="units">Measurement unit (ie kg).</param>
        public WeightOfWater(double numericalValue, WeightUnits units)
            : base("W_w", numericalValue, units)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeightOfWater"/> class.
        /// </summary>
        /// <param name="solidWeight">W_s in W=W_s+W_w.</param>
        /// <param name="totalWeight">W in W=W_s+W_w.</param>
        /// <param name="units">Measurement unit to hold value in after initial calculation (ie kg).</param>
        public WeightOfWater(WeightOfSolidMatter solidWeight, TotalWeight totalWeight, WeightUnits units)
            : this(ConvertToUnits(totalWeight, units).NumericValue - ConvertToUnits(solidWeight, units).NumericValue, units)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeightOfWater"/> class.
        /// </summary>
        /// <param name="waterContent">w in w=W_w/W_s.</param>
        /// <param name="solidWeight">W_s in w=W_w/W_s.</param>
        /// <param name="units">Measurement unit to hold value in after initial calculation (ie kg).</param>
        public WeightOfWater(WaterContent waterContent, WeightOfSolidMatter solidWeight, WeightUnits units)
            : this(BaseWeightScalar.ConvertToUnits(solidWeight, units).NumericValue * waterContent.NumericValue, units)
        {
        }
    }
}
