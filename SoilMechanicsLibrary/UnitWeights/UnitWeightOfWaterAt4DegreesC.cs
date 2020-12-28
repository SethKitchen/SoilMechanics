// <copyright file="UnitWeightOfWaterAt4DegreesC.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.UnitWeights
{
    /// <summary>
    /// p. 15 "At a temperature of 4 degrees C the value is exactly 1 gram per cc and designated by gamma_0".
    /// </summary>
    public class UnitWeightOfWaterAt4DegreesC : BaseUnitWeightScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitWeightOfWaterAt4DegreesC"/> class.
        /// </summary>
        public UnitWeightOfWaterAt4DegreesC()
            : base("𝛾_0", 1.0, UnitWeightUnits.GramPerCubicCentimeter)
        {
        }
    }
}
