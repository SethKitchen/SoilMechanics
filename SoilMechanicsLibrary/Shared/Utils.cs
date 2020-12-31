// <copyright file="Utils.cs" company="Seth Kitchen">
// Copyright (c) Seth Kitchen 2020-2021. All rights reserved.
// </copyright>

namespace SoilMechanicsLibrary.Shared
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Arbitrary Extensions/Helpers shared between all classes.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// For enums, this function pulls the Description attribute annotated above each option.
        /// </summary>
        /// <typeparam name="T">An enum.</typeparam>
        /// <param name="e">The enum option to pull description from.</param>
        /// <returns>The Description attribute annotated above each option. Empty String if type is not enum.</returns>
        public static string GetDescription<T>(this T e)
            where T : IConvertible
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

            return string.Empty;
        }
    }
}