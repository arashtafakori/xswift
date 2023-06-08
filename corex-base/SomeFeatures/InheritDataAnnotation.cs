using System.ComponentModel.DataAnnotations;

namespace CoreX.Base
{
    /// <summary>
    /// To inherit the EmailAddress data annotation attribute from the Person
    /// entity's email field to the email field of a command, you can create a
    /// custom attribute that copies the attribute from the source property to
    /// the target property. Here's an example:
    /// 
    /// public class Person
    /// {
    /// [EmailAddress(ErrorMessage = "Invalid email address.")]
    /// public string Email { get; set; }
    /// }

    /// public class CommandWithEmail
    /// {
    ///     [InheritDataAnnotation(typeof(Person), nameof(Person.Email))]
    ///     public string Email { get; set; }
    /// }
    /// 
    /// </summary>

    [AttributeUsage(AttributeTargets.Property)]
    public class InheritDataAnnotationAttribute : Attribute
    {
        public Type SourceType { get; }
        public string SourcePropertyName { get; }

        public InheritDataAnnotationAttribute(Type sourceType, string sourcePropertyName)
        {
            SourceType = sourceType;
            SourcePropertyName = sourcePropertyName;
        }
    }
    public class InheritDataAnnotationAttributeProcessor
    {
        public static void Process(object target)
        {
            var targetType = target.GetType();
            var properties = targetType.GetProperties();

            foreach (var property in properties)
            {
                var inheritAttribute = (InheritDataAnnotationAttribute)Attribute.GetCustomAttribute(property, typeof(InheritDataAnnotationAttribute));

                if (inheritAttribute != null)
                {
                    var sourceProperty = inheritAttribute.SourceType.GetProperty(inheritAttribute.SourcePropertyName);
                    var attribute = (ValidationAttribute)Attribute.GetCustomAttribute(sourceProperty, typeof(ValidationAttribute));

                    if (attribute != null)
                    {
                        property.SetCustomAttributes(attribute);
                    }
                }
            }
        }
    }
    public static class PropertyInfoExtensions
    {
        public static void SetCustomAttributes(this System.Reflection.PropertyInfo property, ValidationAttribute attribute)
        {
            property.SetCustomAttributes(attribute);
            property.SetCustomAttributes(new RequiredAttribute());
            // Optional: Add additional attributes if needed
            // Add any other attribute you want to copy or modify
        }
    }
}
