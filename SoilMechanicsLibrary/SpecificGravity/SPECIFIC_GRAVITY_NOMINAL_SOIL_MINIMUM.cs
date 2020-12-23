// <copyright file="SPECIFIC_GRAVITY_NOMINAL_SOIL_MINIMUM.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.SpecificGravity
{
    using SoilMechanicsLibrary.Shared;

    /// <summary>
    /// pg. 15 "... for the majority of soils [specific gravity] value falls between 2.65...
    /// </summary>
    public class SPECIFIC_GRAVITY_NOMINAL_SOIL_MINIMUM : BaseScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SPECIFIC_GRAVITY_NOMINAL_SOIL_MINIMUM"/> class.
        /// </summary>
        public SPECIFIC_GRAVITY_NOMINAL_SOIL_MINIMUM()
        {
            this.Symbol = "G_{soil_min}";
            this.NumericValue = 2.65;
        }
    }
}
