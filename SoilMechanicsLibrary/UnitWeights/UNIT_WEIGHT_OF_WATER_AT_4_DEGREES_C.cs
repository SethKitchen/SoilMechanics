// <copyright file="UNIT_WEIGHT_OF_WATER_AT_4_DEGREES_C.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.UnitWeights
{
    /// <summary>
    /// p. 15 "At a temperature of 4 degrees C the value is exactly 1 gram per cc and designated by gamma_0".
    /// </summary>
    public class UNIT_WEIGHT_OF_WATER_AT_4_DEGREES_C : BaseUnitWeightScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UNIT_WEIGHT_OF_WATER_AT_4_DEGREES_C"/> class.
        /// </summary>
        public UNIT_WEIGHT_OF_WATER_AT_4_DEGREES_C()
            : base("𝛾_0", 1.0, UnitWeightUnits.GramPerCubicCentimeter)
        {
        }
    }
}
