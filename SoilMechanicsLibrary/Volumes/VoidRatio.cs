// <copyright file="VoidRatio.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.Volumes
{
    using SoilMechanicsLibrary.Shared;

    /// <summary>
    /// The ratio of the volume of voids to the volume of solid.
    /// </summary>
    public class VoidRatio : BaseScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VoidRatio"/> class.
        /// </summary>
        /// <param name="numericalValue">Decimal value used for calculations.</param>
        public VoidRatio(double numericalValue)
        {
            this.Symbol = "e";
            this.NumericValue = numericalValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VoidRatio"/> class.
        /// </summary>
        /// <param name="voidVolume">V_v in e=V_v/V_s.</param>
        /// <param name="solidVolume">V_s in e=V_v/V_s.</param>
        public VoidRatio(VolumeOfVoids voidVolume, VolumeOfSolidMatter solidVolume)
        {
            this.Symbol = "e";
            var converted = BaseVolumeScalar.ConvertToUnits(voidVolume, solidVolume.UnitOfMeasure);
            this.NumericValue = converted.NumericValue / solidVolume.NumericValue;
        }
    }
}
