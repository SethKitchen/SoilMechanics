// <copyright file="TotalWeight.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.Weights
{
    using SoilMechanicsLibrary.SpecificGravity;
    using SoilMechanicsLibrary.UnitWeights;
    using SoilMechanicsLibrary.Volumes;

    /// <summary>
    /// Total force of gravity.
    /// </summary>
    public class TotalWeight : BaseWeightScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TotalWeight"/> class.
        /// </summary>
        /// <param name="numericalValue">Decimal value to use in calculations.</param>
        /// <param name="units">Measurement unit (ie kg).</param>
        public TotalWeight(double numericalValue, WeightUnits units)
            : base("W", numericalValue, units)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TotalWeight"/> class.
        /// </summary>
        /// <param name="solidWeight">W_s in W=W_s+W_w.</param>
        /// <param name="waterWeight">W_w in W=W_s+W_w.</param>
        /// <param name="units">Measurement unit to hold value after initial calculation (ie kg). </param>
        public TotalWeight(WeightOfSolidMatter solidWeight, WeightOfWater waterWeight, WeightUnits units)
            : this(ConvertToUnits(solidWeight, units).NumericValue + ConvertToUnits(waterWeight, units).NumericValue, units)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TotalWeight"/> class.
        /// </summary>
        /// <param name="massSpecificGravity">G_m in W=G_m*gamma_w*V.</param>
        /// <param name="unitWeightOfWater">gamma_w in W=G_m*gamma_w*V.</param>
        /// <param name="totalVolume">V in W=G_m*gamma_w*V.</param>
        /// <param name="units">Measurement unit to hold value after initial calculation (ie kg).</param>
        public TotalWeight(MassSpecificGravity massSpecificGravity, UnitWeightOfWater unitWeightOfWater, TotalVolume totalVolume, WeightUnits units)
            : this(ConvertToUnits(new BaseWeightScalar("𝛾", BaseUnitWeightScalar.ConvertToUnits(unitWeightOfWater, UnitWeightUnits.KilogramPerMeterCubed).NumericValue * BaseVolumeScalar.ConvertToUnits(totalVolume, VolumeUnits.CubicMeters).NumericValue * massSpecificGravity.NumericValue, WeightUnits.Kilograms), units).NumericValue, units)
        {
        }
    }
}
