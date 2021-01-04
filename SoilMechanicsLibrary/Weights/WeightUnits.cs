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
        Kilograms = 0,

        /// <summary>
        /// g
        /// </summary>
        [Description("g")]
        Grams = 1,

        /// <summary>
        /// lb
        /// </summary>
        [Description("lb")]
        Pounds = 2,
    }
}
