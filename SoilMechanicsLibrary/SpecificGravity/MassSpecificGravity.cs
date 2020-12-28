// <copyright file="MassSpecificGravity.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.SpecificGravity
{
    using SoilMechanicsLibrary.Shared;
    using SoilMechanicsLibrary.UnitWeights;

    /// <summary>
    /// p. 15 "Ratio between unit weight of substance and the unit weight of some reference substance".
    /// </summary>
    public class MassSpecificGravity : BaseScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MassSpecificGravity"/> class.
        /// </summary>
        /// <param name="numericalValue">Decimal value used for calculations.</param>
        public MassSpecificGravity(double numericalValue)
        {
            this.Symbol = "G_m";
            this.NumericValue = numericalValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MassSpecificGravity"/> class. Uses <see cref="UnitWeightOfWaterAt4DegreesC" /> as reference.
        /// </summary>
        /// <param name="totalUnitWeight">Calculation for gamma_t/gamma_0.</param>
        public MassSpecificGravity(TotalUnitWeight totalUnitWeight)
        {
            this.Symbol = "G_m";
            UnitWeightOfWaterAt4DegreesC referenceWeight = new UnitWeightOfWaterAt4DegreesC();
            this.NumericValue = totalUnitWeight.NumericValue / BaseUnitWeightScalar.ConvertToUnits(referenceWeight, totalUnitWeight.UnitOfMeasure).NumericValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MassSpecificGravity"/> class.
        /// </summary>
        /// <param name="totalUnitWeight">gamma_t in G_m=gamma_t/gamma_0.</param>
        /// <param name="referenceWeight">gamma_0 in G_m=gamma_t/gamma_0.</param>
        public MassSpecificGravity(TotalUnitWeight totalUnitWeight, UnitWeightOfWater referenceWeight)
        {
            this.Symbol = "G_m";
            this.NumericValue = totalUnitWeight.NumericValue / BaseUnitWeightScalar.ConvertToUnits(referenceWeight, totalUnitWeight.UnitOfMeasure).NumericValue;
        }
    }
}
