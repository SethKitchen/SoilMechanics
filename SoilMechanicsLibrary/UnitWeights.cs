using System;
using System.ComponentModel;

namespace SoilMechanicsLibrary
{
    public class BaseUnitWeightScalar : BaseScalar
    {
        public UnitWeightUnits m_UnitOfMeasure { get; set; }

        public BaseUnitWeightScalar(String symbol, double numericalValue, UnitWeightUnits units)
        {
            m_UnitOfMeasure = units;
            m_Symbol = symbol;
            m_NumericValue = numericalValue;
        }

        public static BaseUnitWeightScalar ConvertToUnits(BaseUnitWeightScalar toConvert, UnitWeightUnits toConvertTo)
        {
            if (toConvert.m_UnitOfMeasure == toConvertTo)
            {
                return toConvert;
            }
            double newVal = toConvert.m_NumericValue;
            if (toConvert.m_UnitOfMeasure == UnitWeightUnits.GramPerCubicCentimeter && toConvertTo == UnitWeightUnits.KilogramPerMeterCubed)
            {
                newVal *= 1000.0;
            }
            else if (toConvert.m_UnitOfMeasure == UnitWeightUnits.GramPerCubicCentimeter && toConvertTo == UnitWeightUnits.PoundPerCubicFoot)
            {
                newVal *= 62.428;
            }
            else if (toConvert.m_UnitOfMeasure == UnitWeightUnits.KilogramPerMeterCubed && toConvertTo == UnitWeightUnits.GramPerCubicCentimeter)
            {
                newVal /= 1000.0;
            }
            else if (toConvert.m_UnitOfMeasure == UnitWeightUnits.KilogramPerMeterCubed && toConvertTo == UnitWeightUnits.PoundPerCubicFoot)
            {
                newVal /= 16.018;
            }
            else if (toConvert.m_UnitOfMeasure == UnitWeightUnits.PoundPerCubicFoot && toConvertTo == UnitWeightUnits.GramPerCubicCentimeter)
            {
                newVal /= 62.428;
            }
            else if (toConvert.m_UnitOfMeasure == UnitWeightUnits.PoundPerCubicFoot && toConvertTo == UnitWeightUnits.KilogramPerMeterCubed)
            {
                newVal *= 16.018;
            }
            BaseUnitWeightScalar toReturn = new BaseUnitWeightScalar(toConvert.m_Symbol, newVal, toConvertTo);
            return toReturn;
        }

        public override string ToString()
        {
            return m_Symbol + " = " + Math.Round(m_NumericValue, 2) + " " + Utils.GetDescription(m_UnitOfMeasure);
        }
    }

    public enum UnitWeightUnits
    {
        [Description("kg/m^3")]
        KilogramPerMeterCubed,
        [Description("g/cc")]
        GramPerCubicCentimeter,
        [Description("lb/ft^3")]
        PoundPerCubicFoot,
    }

    public class TotalUnitWeight : BaseUnitWeightScalar
    {
        public TotalUnitWeight(double numericalValue, UnitWeightUnits units) : base("𝛾_t", numericalValue, units)
        {

        }

        public TotalUnitWeight(TotalWeight totalWeight, TotalVolume totalVolume, UnitWeightUnits units) : this(ConvertToUnits(new BaseUnitWeightScalar("𝛾", BaseWeightScalar.ConvertToUnits(totalWeight, WeightUnits.Kilograms).m_NumericValue / BaseVolumeScalar.ConvertToUnits(totalVolume, VolumeUnits.CubicMeters).m_NumericValue, UnitWeightUnits.KilogramPerMeterCubed), units).m_NumericValue, units)
        {

        }
   
    }
}
