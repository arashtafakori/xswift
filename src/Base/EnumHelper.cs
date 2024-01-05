using System.Globalization;
using System.Resources;

namespace XSwift.Base
{
    /// <summary>
    /// Helper class providing utility methods for working with enums.
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Gets the resource name for a specific enum member.
        /// </summary>
        /// <param name="enumType">The type of the enum.</param>
        /// <param name="enumValue">The value of the enum member.</param>
        /// <returns>The resource name for the enum member.</returns>
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

        /// <summary>
        /// Gets the resource value for a specific enum member of type <typeparamref name="TEnum"/>.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="resourceManager">The resource manager for retrieving resource values.</param>
        /// <param name="enumValue">The value of the enum member.</param>
        /// <returns>The resource value for the enum member.</returns>
        public static string GetEnumMemberResourceValue<TEnum>(
            ResourceManager resourceManager, TEnum enumValue)
            where TEnum : Enum
        {
            return GetEnumMemberResourceValue(resourceManager, typeof(TEnum), enumValue);
        }

        /// <summary>
        /// Gets the resource value for a specific enum member of type <typeparamref name="TEnum"/> using its integer value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="resourceManager">The resource manager for retrieving resource values.</param>
        /// <param name="enumValue">The integer value corresponding to the enum member.</param>
        /// <returns>The resource value for the enum member.</returns>
        public static string GetEnumMemberResourceValue<TEnum>(
            ResourceManager resourceManager, int enumValue)
            where TEnum : Enum
        {
            return GetEnumMemberResourceValue(resourceManager, typeof(TEnum),
                ConvertToEnum<TEnum>(enumValue)  );
        }

        /// <summary>
        /// Gets the resource value for a specific enum member of type <typeparamref name="TEnum"/> using its boolean value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="resourceManager">The resource manager for retrieving resource values.</param>
        /// <param name="enumValue">The boolean value corresponding to the enum member.</param>
        /// <returns>The resource value for the enum member.</returns>
        public static string GetEnumMemberResourceValue<TEnum>(
            ResourceManager resourceManager, bool enumValue)
            where TEnum : Enum
        {
            return GetEnumMemberResourceValue(resourceManager, typeof(TEnum),
                ConvertToEnum<TEnum>(Convert.ToByte(enumValue)));
        }

        /// <summary>
        /// Converts a list of enum values to a list of key-value pairs, where the key is the integer value
        /// and the value is the string representation of the enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <returns>A list of key-value pairs representing the enum values.</returns>
        public static List<KeyValuePair<int, string>> ToKeyValuePairList<TEnum>()
            where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum))
            .Cast<TEnum>()
            .Select(item => new KeyValuePair<int, string>((int)(object)item, item.ToString()))
            .ToList();
        }

        /// <summary>
        /// Converts a list of enum values to a list of key-value pairs, where the key is the integer value
        /// and the value is the resource value of the enum member.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="resourceManager">The resource manager for retrieving resource values.</param>
        /// <returns>A list of key-value pairs representing the enum values with resource values.</returns>
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

        /// <summary>
        /// Converts an integer value to the corresponding enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The integer value to convert.</param>
        /// <returns>The enum value corresponding to the provided integer value.</returns>
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

        /// <summary>
        /// Gets the resource value for a specific enum member.
        /// </summary>
        /// <param name="resourceManager">The resource manager for retrieving resource values.</param>
        /// <param name="enumType">The type of the enum.</param>
        /// <param name="enumValue">The value of the enum member.</param>
        /// <returns>The resource value for the enum member.</returns>
        private static string GetEnumMemberResourceValue(
            ResourceManager resourceManager, Type enumType, object enumValue)
        {
            // Formats the resource value using the resource manager and the enum member's resource name.
            return string.Format(CultureInfo.CurrentCulture,
                resourceManager.GetString(GetEnumMemberResourceName(enumType, enumValue))!);
        }
    }
}
