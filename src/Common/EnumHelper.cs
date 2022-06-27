using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace IntrepidProducts.Common
{
    public static class EnumHelper
    {
        public static String GetDescription(Enum e)
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

        public static TEnum? GetFromString<TEnum>(string value) where TEnum : struct, IConvertible
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
            {
                try
                {
                    //TODO: Consolidate parse methods?
                    //Backup method that can handle values with underscores
                    return GetEnumValueFromDescription<TEnum>(value);
                }
                catch (Exception)
                {
                    return null;
                }
            }

            return null;
        }

        public static T GetEnumValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum)
            {
                throw new ArgumentException("Type must be an Enum");
            }

            var fields = type.GetFields();
            var field = fields
                .SelectMany(f => f.GetCustomAttributes(
                    typeof(DescriptionAttribute), false), (
                    f, a) => new { Field = f, Att = a }).SingleOrDefault(a => ((DescriptionAttribute)a.Att)
                    .Description.ToLower() == description.ToLower());

            if (field == null)
            {
                throw new ArgumentException("Unable to parse Enum");
            }

            return (T)field.Field.GetRawConstantValue();
        }

            public static IEnumerable<TEnum> GetAllValues<TEnum>(this TEnum e) where TEnum : struct
        {
            return Enum.GetValues(e.GetType()).Cast<TEnum>();
        }
    }
}