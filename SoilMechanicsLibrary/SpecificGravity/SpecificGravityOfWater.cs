// <copyright file="SpecificGravityOfWater.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.SpecificGravity
{
    using SoilMechanicsLibrary.Shared;
    using SoilMechanicsLibrary.UnitWeights;

    /// <summary>
    /// See <see cref="MassSpecificGravity"/>. This is with respect to only the water in the soil.
    /// </summary>
    public class SpecificGravityOfWater : BaseScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificGravityOfWater"/> class.
        /// </summary>
        /// <param name="numericalValue">The decimal value to do calculations with.</param>
        public SpecificGravityOfWater(double numericalValue)
        {
            this.Symbol = "G_w";
            this.NumericValue = numericalValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificGravityOfWater"/> class. Uses <see cref="UNIT_WEIGHT_OF_WATER_AT_4_DEGREES_C" /> as reference.
        /// </summary>
        /// <param name="waterUnitWeight">Calculation for gamma_w/gamma_0.</param>
        public SpecificGravityOfWater(UnitWeightOfWater waterUnitWeight)
        {
            this.Symbol = "G_w";
            UNIT_WEIGHT_OF_WATER_AT_4_DEGREES_C referenceWeight = new UNIT_WEIGHT_OF_WATER_AT_4_DEGREES_C();
            this.NumericValue = waterUnitWeight.NumericValue / BaseUnitWeightScalar.ConvertToUnits(referenceWeight, waterUnitWeight.UnitOfMeasure).NumericValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificGravityOfWater"/> class.
        /// </summary>
        /// <param name="waterUnitWeight">gamma_w for gamma_w/gamma_0.</param>
        /// <param name="referenceWeight">gamma_0 for gamma_w/gamma_0.</param>
        public SpecificGravityOfWater(UnitWeightOfWater waterUnitWeight, UnitWeightOfWater referenceWeight)
        {
            this.Symbol = "G_w";
            this.NumericValue = waterUnitWeight.NumericValue / BaseUnitWeightScalar.ConvertToUnits(referenceWeight, waterUnitWeight.UnitOfMeasure).NumericValue;
        }
    }
}
