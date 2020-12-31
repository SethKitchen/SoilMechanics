// <copyright file="UnitWeightUnits.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.UnitWeights
{
    using System.ComponentModel;

    /// <summary>
    /// Which system of measurement - Metric Units and English.
    /// </summary>
    public enum UnitWeightUnits
    {
        /// <summary>
        /// kg/m^3
        /// </summary>
        [Description("kg/m^3")]
        KilogramPerMeterCubed,

        /// <summary>
        /// g/cc
        /// </summary>
        [Description("g/cc")]
        GramPerCubicCentimeter,

        /// <summary>
        /// lb/ft^3
        /// </summary>
        [Description("lb/ft^3")]
        PoundPerCubicFoot,
    }
}
