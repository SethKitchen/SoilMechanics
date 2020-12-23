// <copyright file="Density.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.UnitWeights
{
    /// <summary>
    /// p. 16 "Unit mass or mass per unit of volume".
    /// </summary>
    public class Density : BaseUnitWeightScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Density"/> class.
        /// </summary>
        /// <param name="numericalValue">Decimal value to do calculations with.</param>
        /// <param name="units">Measurement system (ie g/cc).</param>
        public Density(double numericalValue, UnitWeightUnits units)
            : base("ρ", numericalValue, units)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Density"/> class. Assumes g = 9.81 m/s^2.
        /// </summary>
        /// <param name="totalUnitWeight">gamma_t in rho=gamma_t/g.</param>
        /// <param name="units">Measurement system to hold value in after initial calculation.</param>
        public Density(TotalUnitWeight totalUnitWeight, UnitWeightUnits units)
            : this(ConvertToUnits(new BaseUnitWeightScalar("𝛾", ConvertToUnits(totalUnitWeight, UnitWeightUnits.KilogramPerMeterCubed).NumericValue / 9.81, UnitWeightUnits.KilogramPerMeterCubed), units).NumericValue, units)
        {
        }
    }
}
