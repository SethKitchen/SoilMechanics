using System;
using System.ComponentModel;

namespace SoilMechanicsLibrary
{

    public class BaseVolumeScalar : BaseScalar
    {
        public VolumeUnits m_UnitOfMeasure { get; set; }

        public BaseVolumeScalar(String symbol, double numericalValue, VolumeUnits units)
        {
            m_UnitOfMeasure = units;
            m_Symbol = symbol;
            m_NumericValue = numericalValue;
        }

        public static BaseVolumeScalar ConvertToUnits(BaseVolumeScalar toConvert, VolumeUnits toConvertTo)
        {
            if (toConvert.m_UnitOfMeasure == toConvertTo)
            {
                return toConvert;
            }
            double newVal = toConvert.m_NumericValue;
            if (toConvert.m_UnitOfMeasure == VolumeUnits.CubicCentimeters && toConvertTo == VolumeUnits.CubicMeters)
            {
                newVal /= 1e6;
            }
            else if (toConvert.m_UnitOfMeasure == VolumeUnits.CubicMeters && toConvertTo == VolumeUnits.CubicCentimeters)
            {
                newVal *= 1e6;
            }
            BaseVolumeScalar toReturn = new BaseVolumeScalar(toConvert.m_Symbol, newVal, toConvertTo);
            return toReturn;
        }

        public override string ToString()
        {
            return m_Symbol+" = "+Math.Round(m_NumericValue,2)+" "+Utils.GetDescription(m_UnitOfMeasure);
        }
    }

    public enum VolumeUnits
    {
        [Description("m^3")]
        CubicMeters,
        [Description("cc")]
        CubicCentimeters,
        [Description("ft^3")]
        CubicFeet,
    }

    public class TotalVolume : BaseVolumeScalar
    {
        public TotalVolume(double numericalValue, VolumeUnits units) : base("V", numericalValue, units)
        {

        }

        public TotalVolume(VolumeOfSolidMatter solidVolume, VolumeOfVoids voidVolume, VolumeUnits units) : this(ConvertToUnits(solidVolume, units).m_NumericValue + ConvertToUnits(voidVolume, units).m_NumericValue, units)
        {

        }

        public TotalVolume(Porosity porosity, VolumeOfVoids voidVolume, VolumeUnits units): this(BaseVolumeScalar.ConvertToUnits(voidVolume, units).m_NumericValue/porosity.m_NumericValue, units) {

        }
    }

    public class VolumeOfSolidMatter : BaseVolumeScalar
    {
        public VolumeOfSolidMatter(double numericalValue, VolumeUnits units) : base("V_s", numericalValue, units)
        {

        }

        public VolumeOfSolidMatter(VolumeOfVoids voidVolume, TotalVolume totalVolume, VolumeUnits units) : this(ConvertToUnits(totalVolume, units).m_NumericValue - ConvertToUnits(voidVolume, units).m_NumericValue, units)
        {

        }

        public VolumeOfSolidMatter(VoidRatio voidRatio, VolumeOfVoids voidVolume, VolumeUnits units): this(BaseVolumeScalar.ConvertToUnits(voidVolume, units).m_NumericValue / voidRatio.m_NumericValue, units) {

        }
    }

    public class VolumeOfVoids : BaseVolumeScalar
    {
        public VolumeOfVoids(double numericalValue, VolumeUnits units) : base("V_v", numericalValue, units)
        {

        }

        public VolumeOfVoids(WaterVolume waterVolume, GasVolume gasVolume, VolumeUnits units) : this(ConvertToUnits(waterVolume, units).m_NumericValue + ConvertToUnits(gasVolume, units).m_NumericValue, units)
        {

        }

        public VolumeOfVoids(VolumeOfSolidMatter solidVolume, TotalVolume totalVolume, VolumeUnits units) : this(ConvertToUnits(totalVolume, units).m_NumericValue - ConvertToUnits(solidVolume, units).m_NumericValue, units)
        {

        }

        public VolumeOfVoids(Porosity porosity, TotalVolume totalVolume, VolumeUnits units): this(BaseVolumeScalar.ConvertToUnits(totalVolume, units).m_NumericValue*porosity.m_NumericValue, units) {

        }

        public VolumeOfVoids(VoidRatio voidRatio, VolumeOfSolidMatter solidVolume, VolumeUnits units): this(BaseVolumeScalar.ConvertToUnits(solidVolume, units).m_NumericValue*voidRatio.m_NumericValue, units) {

        }

        public VolumeOfVoids(DegreeOfSaturation degreeOfSaturation, WaterVolume waterVolume, VolumeUnits units): this(BaseVolumeScalar.ConvertToUnits(waterVolume, units).m_NumericValue/degreeOfSaturation.m_NumericValue, units) {

        }
    }

    public class WaterVolume : BaseVolumeScalar
    {
        public WaterVolume(double numericalValue, VolumeUnits units) : base("V_w", numericalValue, units)
        {

        }

         public WaterVolume(VolumeOfVoids voidVolume, GasVolume gasVolume, VolumeUnits units) : this(ConvertToUnits(voidVolume, units).m_NumericValue - ConvertToUnits(gasVolume, units).m_NumericValue, units)
        {

        }

        public WaterVolume(DegreeOfSaturation degreeOfSaturation, VolumeOfVoids voidVolume, VolumeUnits units) : this(ConvertToUnits(voidVolume, units).m_NumericValue * degreeOfSaturation.m_NumericValue, units)
        {

        }
    }

    public class GasVolume : BaseVolumeScalar
    {
        public GasVolume(double numericalValue, VolumeUnits units) : base("V_g", numericalValue, units)
        {

        }

        public GasVolume(VolumeOfVoids voidVolume, WaterVolume waterVolume, VolumeUnits units) : this(ConvertToUnits(voidVolume, units).m_NumericValue - ConvertToUnits(waterVolume, units).m_NumericValue, units)
        {

        }
    }


    public class Porosity: BaseScalar
    {
        public Porosity(double numericalValue)
        {
            m_Symbol = "n";
            m_NumericValue = numericalValue;
        }

        public Porosity(VolumeOfVoids voidVolume, TotalVolume totalVolume) {
            m_Symbol= "n";
            var converted = BaseVolumeScalar.ConvertToUnits(voidVolume, totalVolume.m_UnitOfMeasure);
            m_NumericValue = converted.m_NumericValue / totalVolume.m_NumericValue;
        }

        public override string ToString()
        {
            return m_Symbol+" = "+Math.Round(m_NumericValue*100,2)+" %";
        }
    }

    public class VoidRatio: BaseScalar
    {
        public VoidRatio(double numericalValue)
        {
            m_Symbol = "e";
            m_NumericValue = numericalValue;
        }

        public VoidRatio(VolumeOfVoids voidVolume, VolumeOfSolidMatter solidVolume) {
            m_Symbol= "e";
            var converted = BaseVolumeScalar.ConvertToUnits(voidVolume, solidVolume.m_UnitOfMeasure);
            m_NumericValue = converted.m_NumericValue / solidVolume.m_NumericValue;
        }
    }

    public class DegreeOfSaturation: BaseScalar
    {
        public DegreeOfSaturation(double numericalValue)
        {
            m_Symbol = "S";
            m_NumericValue = numericalValue;
        }

        public DegreeOfSaturation(WaterVolume waterVolume, VolumeOfVoids voidVolume) {
            m_Symbol= "S";
            var converted = BaseVolumeScalar.ConvertToUnits(waterVolume, voidVolume.m_UnitOfMeasure);
            m_NumericValue = converted.m_NumericValue / voidVolume.m_NumericValue;
        }

        public override string ToString()
        {
            return m_Symbol+" = "+Math.Round(m_NumericValue*100,2)+" %";
        }
    }    
}
