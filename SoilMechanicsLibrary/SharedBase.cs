using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace SoilMechanicsLibrary
{
    public abstract class BaseScalar
    {
        public String m_Symbol { get; set; }
        public double m_NumericValue { get; set; }

        public override string ToString()
        {
            return m_Symbol + " = " + Math.Round(m_NumericValue,2);
        }
    }

    public static class Utils
    {
        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = System.Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(DescriptionAttribute), false)
                            .FirstOrDefault() as DescriptionAttribute;

                        if (descriptionAttribute != null)
                        {
                            return descriptionAttribute.Description;
                        }
                    }
                }
            }

            return String.Empty; // could also return string.Empty
        }
    }
}