using System;
using System.ComponentModel;

namespace SoilMechanicsLibrary
{
    public class BaseWeightScalar : BaseScalar
    {
        public WeightUnits m_UnitOfMeasure { get; set; }

        public BaseWeightScalar(String symbol, double numericalValue, WeightUnits units)
        {
            m_UnitOfMeasure = units;
            m_Symbol = symbol;
            m_NumericValue = numericalValue;
        }

        public static BaseWeightScalar ConvertToUnits(BaseWeightScalar toConvert, WeightUnits toConvertTo)
        {
            if (toConvert.m_UnitOfMeasure == toConvertTo)
            {
                return toConvert;
            }
            double newVal = toConvert.m_NumericValue;
            if (toConvert.m_UnitOfMeasure == WeightUnits.Grams && toConvertTo == WeightUnits.Kilograms)
            {
                newVal /= 1000.0;
            }
            else if (toConvert.m_UnitOfMeasure == WeightUnits.Grams && toConvertTo == WeightUnits.Pounds)
            {
                newVal /= 454.0;
            }
            else if(toConvert.m_UnitOfMeasure==WeightUnits.Kilograms && toConvertTo == WeightUnits.Pounds){
                newVal *= 2.205;
            }
            else if(toConvert.m_UnitOfMeasure==WeightUnits.Kilograms && toConvertTo == WeightUnits.Grams) {
                newVal *= 1000.0;
            }
            else if(toConvert.m_UnitOfMeasure==WeightUnits.Pounds && toConvertTo==WeightUnits.Grams) {
                newVal *= 454.0;
            }
            else if(toConvert.m_UnitOfMeasure==WeightUnits.Pounds && toConvertTo==WeightUnits.Kilograms) {
                newVal /= 2.205;
            }
            BaseWeightScalar toReturn = new BaseWeightScalar(toConvert.m_Symbol, newVal, toConvertTo);
            return toReturn;
        }

        public override string ToString()
        {
            return m_Symbol+" = "+Math.Round(m_NumericValue,2)+" "+Utils.GetDescription(m_UnitOfMeasure);
        }
    }

    public enum WeightUnits
    {
        [Description("kg")]
        Kilograms,
        [Description("g")]
        Grams,
        [Description("lb")]
        Pounds,
    }

    public class TotalWeight : BaseWeightScalar
    {
        public TotalWeight(double numericalValue, WeightUnits units) : base("W", numericalValue, units)
        {

        }

        public TotalWeight(WeightOfSolidMatter solidWeight, WeightOfWater waterWeight, WeightUnits units) : this(ConvertToUnits(solidWeight, units).m_NumericValue + ConvertToUnits(waterWeight, units).m_NumericValue, units)
        {

        }
    }

    public class WeightOfSolidMatter : BaseWeightScalar
    {
        public WeightOfSolidMatter(double numericalValue, WeightUnits units) : base("W_s", numericalValue, units)
        {

        }

        public WeightOfSolidMatter(WeightOfWater waterWeight, TotalWeight totalWeight, WeightUnits units) : this(ConvertToUnits(totalWeight, units).m_NumericValue - ConvertToUnits(waterWeight, units).m_NumericValue, units)
        {

        }

        public WeightOfSolidMatter(WaterContent waterContent, WeightOfWater waterWeight, WeightUnits units): this(BaseWeightScalar.ConvertToUnits(waterWeight, units).m_NumericValue / waterContent.m_NumericValue, units) {

        }
    }

       public class WeightOfWater : BaseWeightScalar
    {
        public WeightOfWater(double numericalValue, WeightUnits units) : base("W_w", numericalValue, units)
        {

        }

        public WeightOfWater(WeightOfSolidMatter solidWeight, TotalWeight totalWeight, WeightUnits units) : this(ConvertToUnits(totalWeight, units).m_NumericValue - ConvertToUnits(solidWeight, units).m_NumericValue, units)
        {

        }

        public WeightOfWater(WaterContent waterContent, WeightOfSolidMatter solidWeight, WeightUnits units): this(BaseWeightScalar.ConvertToUnits(solidWeight, units).m_NumericValue * waterContent.m_NumericValue, units) {

        }
    }

    /// NOT the same as geology which is a percentage of the total weight
    public class WaterContent: BaseScalar
    {
        public WaterContent(double numericalValue)
        {
            m_Symbol = "w";
            m_NumericValue = numericalValue;
        }

        public WaterContent(WeightOfSolidMatter solidWeight, WeightOfWater waterWeight) {
            m_Symbol= "w";
            var converted = BaseWeightScalar.ConvertToUnits(solidWeight, waterWeight.m_UnitOfMeasure);
            m_NumericValue = waterWeight.m_NumericValue / converted.m_NumericValue;
        }

        public override string ToString()
        {
            return m_Symbol+" = "+Math.Round(m_NumericValue*100,2)+" %";
        }
    }
}
