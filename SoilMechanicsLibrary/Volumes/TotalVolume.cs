// <copyright file="TotalVolume.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.Volumes
{
    /// <summary>
    /// p. 12 "Network or skeleton of solid particles enclosing voids or interspaces of various size".
    /// </summary>
    public class TotalVolume : BaseVolumeScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TotalVolume"/> class.
        /// </summary>
        /// <param name="numericalValue">Decimal value to do calculations with.</param>
        /// <param name="units">Measurement system (ie cc).</param>
        public TotalVolume(double numericalValue, VolumeUnits units)
            : base("V", numericalValue, units)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TotalVolume"/> class.
        /// </summary>
        /// <param name="solidVolume">V_s in V = V_s+V_v.</param>
        /// <param name="voidVolume">V_v in V = V_s+V_v.</param>
        /// <param name="units">Measurement system to hold value after initial calculation (ie cc).</param>
        public TotalVolume(VolumeOfSolidMatter solidVolume, VolumeOfVoids voidVolume, VolumeUnits units)
            : this(ConvertToUnits(solidVolume, units).NumericValue + ConvertToUnits(voidVolume, units).NumericValue, units)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TotalVolume"/> class.
        /// </summary>
        /// <param name="porosity">n in n=V_v/V.</param>
        /// <param name="voidVolume">V_v in n=V_v/V.</param>
        /// <param name="units">Measurement system to hold value after initial calculation (ie cc).</param>
        public TotalVolume(Porosity porosity, VolumeOfVoids voidVolume, VolumeUnits units)
            : this(BaseVolumeScalar.ConvertToUnits(voidVolume, units).NumericValue / porosity.NumericValue, units)
        {
        }
    }
}
