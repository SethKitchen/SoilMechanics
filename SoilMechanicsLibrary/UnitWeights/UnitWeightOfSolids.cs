// <copyright file="UnitWeightOfSolids.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.UnitWeights
{
    using SoilMechanicsLibrary.Volumes;
    using SoilMechanicsLibrary.Weights;

    /// <summary>
    /// <see cref="TotalUnitWeight"/>. This is with respect to just the solid portion of soil.
    /// </summary>
    public class UnitWeightOfSolids : BaseUnitWeightScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitWeightOfSolids"/> class.
        /// </summary>
        /// <param name="numericalValue">Decimal value used for calculations.</param>
        /// <param name="units">Measurement unit (ie g/cc).</param>
        public UnitWeightOfSolids(double numericalValue, UnitWeightUnits units)
            : base("𝛾_s", numericalValue, units)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitWeightOfSolids"/> class.
        /// </summary>
        /// <param name="solidWeight">W_s in gamma_s=W_s/V_s.</param>
        /// <param name="solidVolume">V_s in gamma_s=W_s/V_s.</param>
        /// <param name="units">Measurement system to hold value in after initial calculation.</param>
        public UnitWeightOfSolids(WeightOfSolidMatter solidWeight, VolumeOfSolidMatter solidVolume, UnitWeightUnits units)
            : this(ConvertToUnits(new BaseUnitWeightScalar("𝛾", BaseWeightScalar.ConvertToUnits(solidWeight, WeightUnits.Kilograms).NumericValue / BaseVolumeScalar.ConvertToUnits(solidVolume, VolumeUnits.CubicMeters).NumericValue, UnitWeightUnits.KilogramPerMeterCubed), units).NumericValue, units)
        {
        }
    }
}
