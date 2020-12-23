// <copyright file="SPECIFIC_GRAVITY_NOMINAL_SOIL_MAXIMUM.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.SpecificGravity
{
    using SoilMechanicsLibrary.Shared;

    /// <summary>
    /// pg. 15 "... for the majority of soils [specific gravity] value falls between ... and 2.85.
    /// </summary>
    public class SPECIFIC_GRAVITY_NOMINAL_SOIL_MAXIMUM : BaseScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SPECIFIC_GRAVITY_NOMINAL_SOIL_MAXIMUM"/> class.
        /// </summary>
        public SPECIFIC_GRAVITY_NOMINAL_SOIL_MAXIMUM()
        {
            this.Symbol = "G_{soil_max}";
            this.NumericValue = 2.85;
        }
    }
}
