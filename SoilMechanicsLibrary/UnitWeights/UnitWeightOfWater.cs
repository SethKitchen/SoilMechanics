// <copyright file="UnitWeightOfWater.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.UnitWeights
{
    using SoilMechanicsLibrary.Volumes;
    using SoilMechanicsLibrary.Weights;

    /// <summary>
    /// <see cref="TotalUnitWeight"/>. This is with respect to just the water portion of soil.
    /// </summary>
    public class UnitWeightOfWater : BaseUnitWeightScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitWeightOfWater"/> class.
        /// </summary>
        /// <param name="numericalValue">Decimal value used for calculations.</param>
        /// <param name="units">Measurement unit (ie g/cc).</param>
        public UnitWeightOfWater(double numericalValue, UnitWeightUnits units)
            : base("𝛾_w", numericalValue, units)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitWeightOfWater"/> class.
        /// </summary>
        /// <param name="waterWeight">W_w in gamma_w=W_w/V_w.</param>
        /// <param name="waterVolume">V_w in gamma_w=W_w/V_w.</param>
        /// <param name="units">Measurement system to hold value in after calculation.</param>
        public UnitWeightOfWater(WeightOfWater waterWeight, WaterVolume waterVolume, UnitWeightUnits units)
            : this(ConvertToUnits(new BaseUnitWeightScalar("𝛾", BaseWeightScalar.ConvertToUnits(waterWeight, WeightUnits.Kilograms).NumericValue / BaseVolumeScalar.ConvertToUnits(waterVolume, VolumeUnits.CubicMeters).NumericValue, UnitWeightUnits.KilogramPerMeterCubed), units).NumericValue, units)
        {
        }
    }
}
