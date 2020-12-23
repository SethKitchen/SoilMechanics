// <copyright file="VolumeOfVoids.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.Volumes
{
    /// <summary>
    /// <see cref="TotalVolume"/>. This is with respect to the water and gas particles in the soil.
    /// </summary>
    public class VolumeOfVoids : BaseVolumeScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VolumeOfVoids"/> class.
        /// </summary>
        /// <param name="numericalValue">Decimal value used for calculations.</param>
        /// <param name="units">Measurement units (ie cc).</param>
        public VolumeOfVoids(double numericalValue, VolumeUnits units)
            : base("V_v", numericalValue, units)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VolumeOfVoids"/> class.
        /// </summary>
        /// <param name="waterVolume">V_w in V_v=V_w+V_g.</param>
        /// <param name="gasVolume">V_g in V_v=V_w+V_g.</param>
        /// <param name="units">Measurement units to hold value after initial calculation (ie cc).</param>
        public VolumeOfVoids(WaterVolume waterVolume, GasVolume gasVolume, VolumeUnits units)
            : this(ConvertToUnits(waterVolume, units).NumericValue + ConvertToUnits(gasVolume, units).NumericValue, units)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VolumeOfVoids"/> class.
        /// </summary>
        /// <param name="solidVolume">V_s in V=V_s+V_v.</param>
        /// <param name="totalVolume">V in V=V_s+V_v.</param>
        /// <param name="units">Measurement units to hold value after initial calculation (ie cc).</param>
        public VolumeOfVoids(VolumeOfSolidMatter solidVolume, TotalVolume totalVolume, VolumeUnits units)
            : this(ConvertToUnits(totalVolume, units).NumericValue - ConvertToUnits(solidVolume, units).NumericValue, units)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VolumeOfVoids"/> class.
        /// </summary>
        /// <param name="porosity">n in n=V_v/V.</param>
        /// <param name="totalVolume">V in n=V_v/V.</param>
        /// <param name="units">Measurement units to hold value after initial calculation (ie cc).</param>
        public VolumeOfVoids(Porosity porosity, TotalVolume totalVolume, VolumeUnits units)
            : this(BaseVolumeScalar.ConvertToUnits(totalVolume, units).NumericValue * porosity.NumericValue, units)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VolumeOfVoids"/> class.
        /// </summary>
        /// <param name="voidRatio">e in e=V_v/V_s.</param>
        /// <param name="solidVolume">V_s in e=V_v/V_s.</param>
        /// <param name="units">Measurement units to hold value after initial calculation (ie cc).</param>
        public VolumeOfVoids(VoidRatio voidRatio, VolumeOfSolidMatter solidVolume, VolumeUnits units)
            : this(BaseVolumeScalar.ConvertToUnits(solidVolume, units).NumericValue * voidRatio.NumericValue, units)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VolumeOfVoids"/> class.
        /// </summary>
        /// <param name="degreeOfSaturation">S in S=V_w/V_v.</param>
        /// <param name="waterVolume">V_w in S=V_w/V_v.</param>
        /// <param name="units">Measurement units to hold value after initial calculation (ie cc).</param>
        public VolumeOfVoids(DegreeOfSaturation degreeOfSaturation, WaterVolume waterVolume, VolumeUnits units)
            : this(BaseVolumeScalar.ConvertToUnits(waterVolume, units).NumericValue / degreeOfSaturation.NumericValue, units)
        {
        }
    }
}
