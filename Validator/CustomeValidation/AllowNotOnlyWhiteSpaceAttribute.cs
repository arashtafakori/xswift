using Artaco.Infrastructure.CoreX.Structure.Properties;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CoreX.Structure
{
    public class AllowNotOnlyWhiteSpaceAttribute : ValidationAttribute
    {
        public AllowNotOnlyWhiteSpaceAttribute() : base(string.Format(CultureInfo.CurrentCulture,
                    Resources.AllowNotOnlyWhiteSpace))
        {

        }

        public override bool IsValid(object value)
        {
            if(value == null)
                throw new ArgumentNullException();
 
            if (new Regex(CommonRegexPatterns.ALLOW_NOT_ONLY_WHITE_SPACE).IsMatch((string)value!))
                return false;
        
            return true;
        }
    }
}
