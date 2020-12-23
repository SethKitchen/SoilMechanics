// <copyright file="BaseScalar.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.Shared
{
    using System;

    /// <summary>
    /// A numeric, non-directional variable with lateX symbol for pretty printing.
    /// </summary>
    public abstract class BaseScalar
    {
        /// <summary>
        /// Gets or sets the LateX Symbol for Pretty Printing.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Gets or sets the decimal value used in calculations.
        /// </summary>
        public double NumericValue { get; set; }

        /// <summary>
        /// Pretty prints the LateX Symbol with its numeric value in equation form.
        /// </summary>
        /// <returns>A string ready to be pretty printed. </returns>
        public override string ToString()
        {
            return this.Symbol + " = " + Math.Round(this.NumericValue, 2);
        }
    }
}
