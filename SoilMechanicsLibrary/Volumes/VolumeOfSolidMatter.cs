// <copyright file="VolumeOfSolidMatter.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.Volumes
{
    /// <summary>
    /// <see cref="TotalVolume"/>. This is with respect to the solid particles in the soil.
    /// </summary>
    public class VolumeOfSolidMatter : BaseVolumeScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VolumeOfSolidMatter"/> class.
        /// </summary>
        /// <param name="numericalValue">Decimal value used for calculations.</param>
        /// <param name="units">Measurement units (ie cc).</param>
        public VolumeOfSolidMatter(double numericalValue, VolumeUnits units)
            : base("V_s", numericalValue, units)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VolumeOfSolidMatter"/> class.
        /// </summary>
        /// <param name="voidVolume">V_v in V=V_s+V_v.</param>
        /// <param name="totalVolume">V in V=V_s+V_v.</param>
        /// <param name="units">Measurement units to hold result in after initial calculation.</param>
        public VolumeOfSolidMatter(VolumeOfVoids voidVolume, TotalVolume totalVolume, VolumeUnits units)
            : this(ConvertToUnits(totalVolume, units).NumericValue - ConvertToUnits(voidVolume, units).NumericValue, units)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VolumeOfSolidMatter"/> class.
        /// </summary>
        /// <param name="voidRatio">e in e=V_v/V_s.</param>
        /// <param name="voidVolume">V_v in e=V_v/V_s.</param>
        /// <param name="units">Measurement units to hold result in after initial calculation.</param>
        public VolumeOfSolidMatter(VoidRatio voidRatio, VolumeOfVoids voidVolume, VolumeUnits units)
            : this(BaseVolumeScalar.ConvertToUnits(voidVolume, units).NumericValue / voidRatio.NumericValue, units)
        {
        }
    }
}
