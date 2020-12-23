// <copyright file="TotalUnitWeight.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.UnitWeights
{
    using SoilMechanicsLibrary.SpecificGravity;
    using SoilMechanicsLibrary.Volumes;
    using SoilMechanicsLibrary.Weights;

    /// <summary>
    /// p. 14 "Weight per unit of volume".
    /// </summary>
    public class TotalUnitWeight : BaseUnitWeightScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TotalUnitWeight"/> class.
        /// </summary>
        /// <param name="numericalValue">Decimal value to use in calculations.</param>
        /// <param name="units">Measurement unit (ie g/cc).</param>
        public TotalUnitWeight(double numericalValue, UnitWeightUnits units)
            : base("𝛾_t", numericalValue, units)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TotalUnitWeight"/> class.
        /// </summary>
        /// <param name="totalWeight">W in gamma_t=W/V.</param>
        /// <param name="totalVolume">V in gamma_t=W/V.</param>
        /// <param name="units">Measurement unit to use after construction from formula (ie g/cc).</param>
        public TotalUnitWeight(TotalWeight totalWeight, TotalVolume totalVolume, UnitWeightUnits units)
            : this(ConvertToUnits(new BaseUnitWeightScalar("𝛾", BaseWeightScalar.ConvertToUnits(totalWeight, WeightUnits.Kilograms).NumericValue / BaseVolumeScalar.ConvertToUnits(totalVolume, VolumeUnits.CubicMeters).NumericValue, UnitWeightUnits.KilogramPerMeterCubed), units).NumericValue, units)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TotalUnitWeight"/> class.
        /// </summary>
        /// <param name="gravityOfSolids">G_s in ((G_s+Se)/(1+e))gamma_w.</param>
        /// <param name="saturation">S in ((G_s+Se)/(1+e))gamma_w.</param>
        /// <param name="voidRatio">e in ((G_s+Se)/(1+e))gamma_w.</param>
        /// <param name="unitWeightOfWater">gamma_w in ((G_s+Se)/(1+e))gamma_w.</param>
        /// <param name="units">Measurement unit to use after construction from formula (ie g/cc).</param>
        public TotalUnitWeight(SpecificGravityOfSolids gravityOfSolids, DegreeOfSaturation saturation, VoidRatio voidRatio, UnitWeightOfWater unitWeightOfWater, UnitWeightUnits units)
            : this(((gravityOfSolids.NumericValue + (saturation.NumericValue * voidRatio.NumericValue)) / (1 + voidRatio.NumericValue)) * ConvertToUnits(unitWeightOfWater, units).NumericValue, units)
        {
        }
    }
}
