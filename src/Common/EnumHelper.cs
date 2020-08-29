using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace IntrepidProducts.Common
{
    public static class EnumHelper
    {
        public static String GetEnumDescription(Enum e)
        {
            var enumInfo = e.GetType().GetField(e.ToString());

            DescriptionAttribute[] enumAttributes;
            try
            {
                enumAttributes = (DescriptionAttribute[])enumInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            }
            catch (NullReferenceException)
            {
                return null;
            }

            return enumAttributes.Length > 0 ? enumAttributes[0].Description : e.ToString();
        }

        public static TEnum? GetEnumFromString<TEnum>(string value) where TEnum : struct, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("TEnum must be an enumerated type");
            }

            var enumType = typeof(TEnum);

            try
            {
                var enumValue = Enum.Parse(enumType, value, true);
                if (Enum.IsDefined(enumType, enumValue))
                {
                    return (TEnum)enumValue;
                }
            }
            catch (ArgumentException)
            { }

            return null;
        }

        public static IEnumerable<TEnum> GetAllValues<TEnum>(this TEnum e) where TEnum : struct
        {
            return Enum.GetValues(e.GetType()).Cast<TEnum>();
        }
    }
}