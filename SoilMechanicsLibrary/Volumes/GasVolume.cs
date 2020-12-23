// <copyright file="GasVolume.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.Volumes
{
    /// <summary>
    /// Part of the Volume of Voids that is made of gas.
    /// </summary>
    public class GasVolume : BaseVolumeScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GasVolume"/> class.
        /// </summary>
        /// <param name="numericalValue">Decimal value used for calculations.</param>
        /// <param name="units">Measurement unit (ie cc).</param>
        public GasVolume(double numericalValue, VolumeUnits units)
            : base("V_g", numericalValue, units)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GasVolume"/> class.
        /// </summary>
        /// <param name="voidVolume">V_v in V_v=V_g+V_w.</param>
        /// <param name="waterVolume">V_w in V_v=V_g+V_w.</param>
        /// <param name="units">Measurement unit to hold value after initial calculation (ie cc).</param>
        public GasVolume(VolumeOfVoids voidVolume, WaterVolume waterVolume, VolumeUnits units)
            : this(ConvertToUnits(voidVolume, units).NumericValue - ConvertToUnits(waterVolume, units).NumericValue, units)
        {
        }
    }
}
