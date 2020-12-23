// <copyright file="SpecificGravityOfSolids.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.SpecificGravity
{
    using SoilMechanicsLibrary.Shared;
    using SoilMechanicsLibrary.UnitWeights;

    /// <summary>
    /// See <see cref="MassSpecificGravity"/>. This is with respect to only the solids in the soil.
    /// </summary>
    public class SpecificGravityOfSolids : BaseScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificGravityOfSolids"/> class.
        /// </summary>
        /// <param name="numericalValue">The decimal value to do calculations with.</param>
        public SpecificGravityOfSolids(double numericalValue)
        {
            this.Symbol = "G_s";
            this.NumericValue = numericalValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificGravityOfSolids"/> class. Uses <see cref="UNIT_WEIGHT_OF_WATER_AT_4_DEGREES_C" /> as reference.
        /// </summary>
        /// <param name="solidUnitWeight">Calculation for gamma_s/gamma_0.</param>
        public SpecificGravityOfSolids(UnitWeightOfSolids solidUnitWeight)
        {
            this.Symbol = "G_s";
            UNIT_WEIGHT_OF_WATER_AT_4_DEGREES_C referenceWeight = new UNIT_WEIGHT_OF_WATER_AT_4_DEGREES_C();
            this.NumericValue = solidUnitWeight.NumericValue / BaseUnitWeightScalar.ConvertToUnits(referenceWeight, solidUnitWeight.UnitOfMeasure).NumericValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificGravityOfSolids"/> class.
        /// </summary>
        /// <param name="solidUnitWeight">gamma_s for gamma_s/gamma_0.</param>
        /// <param name="referenceWeight">gamma_0 for gamma_s/gamma_0.</param>
        public SpecificGravityOfSolids(UnitWeightOfSolids solidUnitWeight, UnitWeightOfWater referenceWeight)
        {
            this.Symbol = "G_s";
            this.NumericValue = solidUnitWeight.NumericValue / BaseUnitWeightScalar.ConvertToUnits(referenceWeight, solidUnitWeight.UnitOfMeasure).NumericValue;
        }
    }
}
