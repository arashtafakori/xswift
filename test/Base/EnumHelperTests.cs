using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XSwift.Base;

namespace XSwift.Test.Base
{
    [TestClass]
    public class EnumHelperTests
    {
        public enum TestEnum
        {
            Value1 = 1,
            Value2 = 2
        }

        [TestMethod]
        public void GetEnumMemberResourceName_Should_ReturnResourceName()
        {
            // Arrange
            var enumType = typeof(TestEnum);
            var enumValue = TestEnum.Value1;

            // Act
            var resourceName = EnumHelper.GetEnumMemberResourceName(enumType, enumValue);

            // Assert
            resourceName.Should().Be($"{enumType.Name}.{enumValue}");
        }

        [TestMethod]
        public void ToKeyValuePairList_Should_ReturnKeyValuePairList()
        {
            // Act
            var keyValuePairs = EnumHelper.ToKeyValuePairList<TestEnum>();

            // Assert
            keyValuePairs.Should().HaveCount(2);
            keyValuePairs.Should().Contain(new KeyValuePair<int, string>((int)TestEnum.Value1, TestEnum.Value1.ToString()));
            keyValuePairs.Should().Contain(new KeyValuePair<int, string>((int)TestEnum.Value2, TestEnum.Value2.ToString()));
        }

        [TestMethod]
        public void ConvertToEnum_Should_ReturnEnumValue_When_GivenValidIntegerValue()
        {
            // Arrange
            var intValue = (int)TestEnum.Value1;

            // Act
            var enumValue = EnumHelper.ConvertToEnum<TestEnum>(intValue);

            // Assert
            enumValue.Should().Be(TestEnum.Value1);
        }

        [TestMethod]
        public void ConvertToEnum_Should_ThrowArgumentException_When_GivenInvalidIntegerValue()
        {
            // Arrange
            var invalidValue = 999; // An invalid integer value

            // Act
            Action act = () => EnumHelper.ConvertToEnum<TestEnum>(invalidValue);

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage($"The integer value {invalidValue} does not correspond to any value in the {typeof(TestEnum).Name} enum.");
        }
    }
}
