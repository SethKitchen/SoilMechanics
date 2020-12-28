// <copyright file="SpecificGravityQuartz.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.SpecificGravity
{
    using SoilMechanicsLibrary.Shared;

    /// <summary>
    /// p. 15 "The specific gravity of quartz is 2.67".
    /// </summary>
    public class SpecificGravityQuartz : BaseScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificGravityQuartz"/> class.
        /// </summary>
        public SpecificGravityQuartz()
        {
            this.Symbol = "G_{quartz}";
            this.NumericValue = 2.67;
        }
    }
}
