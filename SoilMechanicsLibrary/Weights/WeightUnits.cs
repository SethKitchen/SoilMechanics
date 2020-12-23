// <copyright file="WeightUnits.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.Weights
{
    using System.ComponentModel;

    /// <summary>
    /// Which system of measurement - Metric Units and English.
    /// </summary>
    public enum WeightUnits
    {
        /// <summary>
        /// kg
        /// </summary>
        [Description("kg")]
        Kilograms,

        /// <summary>
        /// g
        /// </summary>
        [Description("g")]
        Grams,

        /// <summary>
        /// lb
        /// </summary>
        [Description("lb")]
        Pounds,
    }
}
