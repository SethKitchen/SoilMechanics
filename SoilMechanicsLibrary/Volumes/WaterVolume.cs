// <copyright file="WaterVolume.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.Volumes
{
    /// <summary>
    /// Part of the Volume of Voids that is made of water.
    /// </summary>
    public class WaterVolume : BaseVolumeScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WaterVolume"/> class.
        /// </summary>
        /// <param name="numericalValue">Decimal value used for calculations.</param>
        /// <param name="units">Measurement units (ie cc).</param>
        public WaterVolume(double numericalValue, VolumeUnits units)
            : base("V_w", numericalValue, units)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WaterVolume"/> class.
        /// </summary>
        /// <param name="voidVolume">V_v in V_v=V_w+V_g.</param>
        /// <param name="gasVolume">V_g in V_v=V_w+V_g.</param>
        /// <param name="units">Measurement units to hold value after initial calculation (ie cc).</param>
        public WaterVolume(VolumeOfVoids voidVolume, GasVolume gasVolume, VolumeUnits units)
            : this(ConvertToUnits(voidVolume, units).NumericValue - ConvertToUnits(gasVolume, units).NumericValue, units)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WaterVolume"/> class.
        /// </summary>
        /// <param name="degreeOfSaturation">S in S=V_w/V_v.</param>
        /// <param name="voidVolume">V_v in S=V_w/V_v.</param>
        /// <param name="units">Measurement units to hold value after initial calculation (ie cc).</param>
        public WaterVolume(DegreeOfSaturation degreeOfSaturation, VolumeOfVoids voidVolume, VolumeUnits units)
            : this(ConvertToUnits(voidVolume, units).NumericValue * degreeOfSaturation.NumericValue, units)
        {
        }
    }
}
