using System.Globalization;
using System.Resources;

namespace XSwift.Base
{
    public static class EnumHelper
    {
        public static string GetEnumMemberResourceName(Type enumType, object enumValue)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("Type provided is not an enum", nameof(enumType));
            }

            if (enumValue == null || !Enum.IsDefined(enumType, enumValue))
            {
                throw new ArgumentException("Invalid enum value", nameof(enumValue));
            }

            return $"{enumType.Name}.{enumValue}";
        }

        public static string GetEnumMemberResourceValue<TEnum>(
            ResourceManager resourceManager, TEnum enumValue)
            where TEnum : Enum
        {
            return GetEnumMemberResourceValue(resourceManager, typeof(TEnum), enumValue);
        }

        public static string GetEnumMemberResourceValue<TEnum>(
            ResourceManager resourceManager, int enumValue)
            where TEnum : Enum
        {
            return GetEnumMemberResourceValue(resourceManager, typeof(TEnum),
                ConvertToEnum<TEnum>(enumValue)  );
        }
        public static string GetEnumMemberResourceValue<TEnum>(
            ResourceManager resourceManager, bool enumValue)
            where TEnum : Enum
        {
            return GetEnumMemberResourceValue(resourceManager, typeof(TEnum), 
                ConvertToEnum<TEnum>(Convert.ToByte(enumValue)));
        }
        public static List<KeyValuePair<int, string>> ToKeyValuePairList<TEnum>()
            where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum))
            .Cast<TEnum>()
            .Select(item => new KeyValuePair<int, string>((int)(object)item, item.ToString()))
            .ToList();
        }

        public static List<KeyValuePair<int, string>> ToKeyValuePairList<TEnum>(
            ResourceManager resourceManager)
            where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum))
            .Cast<TEnum>()
            .Select(item => new KeyValuePair<int, string>(
                (int)(object)item,
                GetEnumMemberResourceValue<TEnum>(resourceManager, item)))
            .ToList();
        }

        public static TEnum ConvertToEnum<TEnum>(int value) where TEnum : Enum
        {
            if (Enum.IsDefined(typeof(TEnum), value))
            {
                return (TEnum)Enum.ToObject(typeof(TEnum), value);
            }
            else
            {
                throw new ArgumentException($"The integer value {value} does not correspond to any value in the {typeof(TEnum).Name} enum.");
            }
        }

        private static string GetEnumMemberResourceValue(
            ResourceManager resourceManager, Type enumType, object enumValue)
        {
            return string.Format(CultureInfo.CurrentCulture,
                resourceManager.GetString(GetEnumMemberResourceName(enumType, enumValue))!);
        }
    }
}
