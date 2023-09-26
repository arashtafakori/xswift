using System.Globalization;
using System.Resources;

namespace CoreX.Base
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
        public static string GetEnumMemberResourceValue(
            ResourceManager resourceManager, Type enumType, object enumValue)
        {
            return string.Format(CultureInfo.CurrentCulture,
                resourceManager.GetString(
                GetEnumMemberResourceName(enumType, enumValue))!);
        }
        public static string GetEnumMemberResourceName<TEnum>(object enumValue)
            where TEnum : Enum
        {
            return GetEnumMemberResourceName(typeof(TEnum), enumValue);
        }
        public static string GetEnumMemberResourceValue<TEnum>(
            ResourceManager resourceManager, object enumValue)
            where TEnum : Enum
        {
            return GetEnumMemberResourceValue(resourceManager, typeof(TEnum), enumValue);
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
    }
}
