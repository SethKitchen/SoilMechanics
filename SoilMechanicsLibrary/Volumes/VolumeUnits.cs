// <copyright file="VolumeUnits.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.Volumes
{
    using System.ComponentModel;

    /// <summary>
    /// Which system of measurement - Metric Units and English.
    /// </summary>
    public enum VolumeUnits
    {
        /// <summary>
        /// m^3
        /// </summary>
        [Description("m^3")]
        CubicMeters,

        /// <summary>
        /// cc
        /// </summary>
        [Description("cc")]
        CubicCentimeters,

        /// <summary>
        /// ft^3
        /// </summary>
        [Description("ft^3")]
        CubicFeet,
    }
}