// <copyright file="SpecificGravityNominalSoilMaximum.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.SpecificGravity
{
    using SoilMechanicsLibrary.Shared;

    /// <summary>
    /// pg. 15 "... for the majority of soils [specific gravity] value falls between ... and 2.85.
    /// </summary>
    public class SpecificGravityNominalSoilMaximum : BaseScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificGravityNominalSoilMaximum"/> class.
        /// </summary>
        public SpecificGravityNominalSoilMaximum()
        {
            this.Symbol = "G_{soil_max}";
            this.NumericValue = 2.85;
        }
    }
}
