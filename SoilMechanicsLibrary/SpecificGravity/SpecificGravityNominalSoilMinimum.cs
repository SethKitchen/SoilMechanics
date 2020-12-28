// <copyright file="SpecificGravityNominalSoilMinimum.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.SpecificGravity
{
    using SoilMechanicsLibrary.Shared;

    /// <summary>
    /// pg. 15 "... for the majority of soils [specific gravity] value falls between 2.65...
    /// </summary>
    public class SpecificGravityNominalSoilMinimum : BaseScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificGravityNominalSoilMinimum"/> class.
        /// </summary>
        public SpecificGravityNominalSoilMinimum()
        {
            this.Symbol = "G_{soil_min}";
            this.NumericValue = 2.65;
        }
    }
}
